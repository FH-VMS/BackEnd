﻿using Interface;
using Model.Customer;
using Model.Machine;
using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Service
{
    public class CustomerService:AbstractService, IBase<CustomerModel>
    {

        public List<CustomerModel> GetAll(CustomerModel customerInfo)
        {
            string userStatus = HttpContextHandler.GetHeaderObj("Sts").ToString();
            var userClientId = HttpContextHandler.GetHeaderObj("UserClientId").ToString();


            var conditions = new List<Condition>();

            if (!string.IsNullOrEmpty(customerInfo.ClientName))
            {
                conditions.Add(new Condition
                {
                    LeftBrace = " AND ",
                    ParamName = "ClientName",
                    DbColumnName = "client_name",
                    ParamValue = "%" + customerInfo.ClientName + "%",
                    Operation = ConditionOperate.Like,
                    RightBrace = "",
                    Logic = ""
                });
            }

            conditions.Add(new Condition
            {
                LeftBrace = "",
                ParamName = "ClientId",
                DbColumnName = "",
                ParamValue = userClientId,
                Operation = ConditionOperate.None,
                RightBrace = "",
                Logic = ""
            });

            conditions.AddRange(CreatePaginConditions(customerInfo.PageIndex, customerInfo.PageSize));
           // var dics = new Dictionary<string, object>();

            //dics.Add("ClientName", customerInfo.ClientName + "%");
            List<CustomerModel> result = null;
            /*
            if (userStatus == "100" || userStatus == "99")
            {
                dics.Add("ClientId", "self");
            }
            else
            {
                dics.Add("ClientId", userClientId);
               
            }
                dics.Add("PageIndex", customerInfo.PageIndex - 1);
                dics.Add("PageSize", customerInfo.PageSize);
            
            */
            result = GenerateDal.LoadByConditions<CustomerModel>(CommonSqlKey.GetCustomer, conditions);
            CustomerModel curItem = new CustomerModel();
            curItem.Id = userClientId;
            var finalResult = LoopToAppendChildren(result, curItem);


            return finalResult;
        }

        private int keyI = 0;
        private int keyJ = 0;
        private List<CustomerModel> LoopToAppendChildren(List<CustomerModel> all, CustomerModel curItem)
        {
            var subItems = all.Where(ee => ee.ClientFatherId == curItem.Id).ToList();
            if (subItems.Count > 0)
            {
                curItem.children = new List<CustomerModel>();
                curItem.children.AddRange(subItems);
            }
           
            foreach (var subItem in subItems)
            {
                
                subItem.key = keyI.ToString() + keyJ.ToString();
                keyJ++;
                LoopToAppendChildren(all, subItem);
            }
            keyI++;
            return subItems;
        }


        public int GetCount(CustomerModel customerInfo)
        {
            var result = 0;
            string userStatus = HttpContextHandler.GetHeaderObj("Sts").ToString();
            var userClientId = HttpContextHandler.GetHeaderObj("UserClientId").ToString();

            var dics = new Dictionary<string, object>();

            dics.Add("ClientName", customerInfo.ClientName + "%");
            if (userStatus == "100" || userStatus == "99")
            {
                dics.Add("ClientId", "self");
            }
            else
            {
                dics.Add("ClientId", userClientId);

            }

            result = GenerateDal.CountByDictionary<CustomerModel>(CommonSqlKey.GetCustomerCount, dics);

            return result;
        }


        /// <summary>
        /// 新增/修改会员信息
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public int PostData(CustomerModel customerInfo)
        {
            int result;
            string userClientId = HttpContextHandler.GetHeaderObj("UserClientId").ToString();
            string userAccount = HttpContextHandler.GetHeaderObj("UserAccount").ToString();
            if(!string.IsNullOrEmpty(userClientId))
            {
                customerInfo.ClientFatherId = userClientId;
            }

            if (!string.IsNullOrEmpty(userAccount))
            {
                customerInfo.Creator = userAccount;
            }

            //customerInfo.Id = Guid.NewGuid().ToString();

            result = GenerateDal.Create(customerInfo);

            //操作日志
            OperationLogService operationService = new OperationLogService();
            operationService.PostData(new OperationLogModel() { Remark = customerInfo.Id, OptContent = "新增或修改会员信息" });


            return result;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public int DeleteData(string id)
        {
            string userClientId = HttpContextHandler.GetHeaderObj("UserClientId").ToString();
            try
            {
                
                GenerateDal.BeginTransaction();
                // 删除有子客户的客户 将子客户父级更新为删除对象的父级
                string fatherId = string.Empty;
                var fatherClientInfo = GenerateDal.Get<CustomerModel>(id);
                if (fatherClientInfo != null)
                {
                    fatherId = fatherClientInfo.ClientFatherId;
                }
                CustomerModel customerInfo = new CustomerModel();
                customerInfo.Id = id;
                int delResult = GenerateDal.Delete<CustomerModel>(CommonSqlKey.DeleteCustomer, customerInfo);
                if (delResult > 0)
                {
                    CustomerModel updInfo = new CustomerModel();
                    updInfo.ClientFatherId = fatherId;
                    updInfo.Id = id;
                    string userAccount = HttpContextHandler.GetHeaderObj("UserAccount").ToString();
                    if (!string.IsNullOrEmpty(userAccount))
                    {
                        updInfo.Updater = userAccount;
                    }
                    GenerateDal.Update(CommonSqlKey.UpdateChildCustomer, updInfo);
                }

                //操作日志
                OperationLogService operationService = new OperationLogService();
                operationService.PostData(new OperationLogModel() { Remark = customerInfo.Id, OptContent = "删除客户" });

                GenerateDal.CommitTransaction();
                return 1;
            }
            catch (Exception ee)
            {
                GenerateDal.RollBack();
                return 0;
            }
           
        }

        public int UpdateData(CustomerModel customerInfo)
        {
            string userAccount = HttpContextHandler.GetHeaderObj("UserAccount").ToString();
            if (!string.IsNullOrEmpty(userAccount))
            {
                customerInfo.Updater = userAccount;
            }
            //操作日志
            OperationLogService operationService = new OperationLogService();
            operationService.PostData(new OperationLogModel() { Remark = customerInfo.Id, OptContent = "更新客户" });
            return GenerateDal.Update(CommonSqlKey.UpdateCustomer, customerInfo);
        }
    }
}
