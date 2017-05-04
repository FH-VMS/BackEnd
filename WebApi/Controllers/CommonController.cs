using Chuang.Back.Base;
using Interface;
using Model.Common;
using Model.Resource;
using Model.Sys;
using Model.User;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Utility;

namespace Chuang.Back.Controllers
{
    public class CommonController : ApiBaseController
    {
        public ResultObj<List<MenuModel>> GetMenus()
        {
            ICommon menusService = new CommonService();
            var menuList = menusService.GetMenus("");
            return Content(menuList);
        }

        public ResultObj<int> GetWebAPIAndModel()
        {
            // ServiceInfoHelper.WriteWebAPI();
            ServiceInfoHelper.WriteWebModels();
            return Content(1);
        }

        public ResultObj<UserModel> PostLogin(UserModel userInfo)
        {
            ICommon common = new CommonService();
            var user = common.PostUser(userInfo);
            if (user == null)
            {
                return Content(new UserModel(), ResultCode.NoAccess, "用户名密码不正确！");
            }
            else
            {
                return Content(user);
            }
            
        }

        public ResultObj<List<DicModel>> GetDic(string id)
        {
            ICommon menusService = new CommonService();
            return Content(menusService.GetDic(id));
        }

        public ResultObj<List<DicModel>> GetRank(string id)
        {
            ICommon menusService = new CommonService();
            return Content(menusService.GetRank(id));
        }

        public ResultObj<List<CommonDic>> GetUserByClientId(string id)
        {
            ICommon menusService = new CommonService();
            return Content(menusService.GetUserByClientId(id));
        }

        // 机器字典
        public ResultObj<List<CommonDic>> GetMachineDic()
        {
            ICommon menusService = new CommonService();
            return Content(menusService.GetMachineDic());
        }

        // 上传图片
        public ResultObj<List<CommonDic>> PostUpload()
        {
            var hfc = HttpContext.Current.Request.Files;
            const string localPath = "Attachment/";
            var path = HttpContext.Current.Request.PhysicalApplicationPath + localPath;
            List<CommonDic> lstCommonDic = new List<CommonDic>();
            if (hfc.Count == 0)
            {
                return Content(lstCommonDic);
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            IBase<PictureModel> _ibase = new PictureService();
          
            for (var i = 0; i < hfc.Count; i++)
            {
                var fileName = hfc[i].FileName.Split('.')[0] + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfffff") + "." + hfc[i].FileName.Split('.')[1];
                try
                {
                    hfc[i].SaveAs(path + fileName);
                    var pictureInfo = new PictureModel();
                    string guild = Guid.NewGuid().ToString();
                    pictureInfo.PicId=guild;
                    pictureInfo.PicName = fileName;
                    pictureInfo.PicPath = "Attachment/" + fileName;
                    _ibase.PostData(pictureInfo);
                    lstCommonDic.Add(new CommonDic
                    {
                        Id = guild,
                        Name = fileName
                    });
                }
                catch (Exception ex)
                {
                    return Content(lstCommonDic);
                }
            }
            return Content(lstCommonDic);
        }

        // 图片字典
        public ResultObj<List<CommonDic>> GetPictureDic()
        {
            ICommon menusService = new CommonService();
            return Content(menusService.GetPictureDic());
        }

        // 取商品作字典
        public ResultObj<List<CommonDic>> GetProductDic()
        {
            ICommon menusService = new CommonService();
            return Content(menusService.GetProductDic());
        }

        // 取货柜作字典
        public ResultObj<List<CommonDic>> GetCabinetDic()
        {
            ICommon menusService = new CommonService();
            return Content(menusService.GetCabinetDic());
        }

        //修改密码
        public ResultObj<int> PutPassword(UserModel userInfo)
        {
            ICommon menusService = new CommonService();
           
            return Content(menusService.UpdatePassword(userInfo));
        }
    }
}
