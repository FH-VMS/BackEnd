using SqlDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AbstractService
    {
        private static ISqlGenerator _generateDal;

        protected ISqlGenerator GenerateDal
        {
            get
            {
                if (_generateDal == null)
                {
                    try
                    {
                        var dalAssemble = Assembly.Load("SqlDataAccess");

                        if (dalAssemble != null)

                            _generateDal = (ISqlGenerator)dalAssemble.CreateInstance("SqlDataAccess.SqlGenerator");
                        else
                            throw new Exception("no generatedal defined");
                    }
                    catch (Exception ee)
                    {
                        //Logger.LogInfo(ee.Message, 0, LogType.FATAL);
                        throw new Exception(ee.Message);
                    }

                }
                return _generateDal;
            }
        }
    }
}
