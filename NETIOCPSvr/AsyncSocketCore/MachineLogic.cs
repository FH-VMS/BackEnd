using SocketService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocketAsyncSvr.AsyncSocketCore
{
    public class MachineLogic
    {
        //处理机器消息
        private void HandleHexByte(byte[] byteInfo)
        {
            //Utility.byteToHexStr(byteInfo.Take(4).ToArray());
            //byte[] byteInfo = Utility.strToToHexByte(info);
            //包头
            string infoHead = byteInfo[0].ToString();
            //大小
            int infoSize = Convert.ToInt32(byteInfo[1]);
            //验证码
            string infoVerify = byteInfo[2].ToString();
            //数据
            byte[] data = byteInfo.Skip(3).Take(infoSize).ToArray();
            //string machine_num = Encoding.ASCII.GetString(data, 1, 4); 
            //验证是否为有效包
            if (!IsValidPackage(infoVerify, data))
            {
                return;
            }

            int retResult = 0;
            //Dao daoBll = new Dao();
            try
            {


                //验证通过
                switch (Utility.Ten2Hex(data[0].ToString()).ToUpper())
                {

                    case "A1": //告警信息
                        int resultA1 = 0;
                        string machineNumA1 = Utility.GenerateRealityData(data.Skip(1).Take(4).ToArray(), "intval");
                        string serialNumA1 = Utility.GenerateRealityData(data.Skip(5).Take(4).ToArray(), "intval");
                        string warningTypeA1 = data[9].ToString();//报警类型
                        byte warningDesA1 = data[10];//报警描述

                        //resultA1 = daoBll.CreateWarning(serialNumA1, machineNumA1, warningTypeA1, GetWarningDescribe(warningDesA1), DateTime.Now);



                        byte[] returnByteA1 = new byte[14];
                        returnByteA1[0] = byteInfo[0];//包头;
                        returnByteA1[1] = 10; //size
                        returnByteA1[3] = data[0];
                        data.Skip(1).Take(4).ToArray().CopyTo(returnByteA1, 4);//机器编号
                        data.Skip(5).Take(4).ToArray().CopyTo(returnByteA1, 8);//流水号
                        if (resultA1 == 1)
                        {
                            returnByteA1[12] = 0;
                        }
                        else if (resultA1 == 15)
                        {
                            returnByteA1[12] = 2;
                        }
                        else
                        {
                            returnByteA1[12] = 8;
                        }

                        returnByteA1[13] = 238;
                        //验证码生成
                        byte resultA1Chunk = new byte();
                        byte[] finalResultA1 = returnByteA1.Skip(3).Take(returnByteA1[1]).ToArray();
                        for (int i = 0; i < finalResultA1.Length; i++)
                        {
                            resultA1Chunk ^= finalResultA1[i];
                        }
                        finalResultA1[2] = resultA1Chunk;
                        //SendMsg(finalResultA1, myClientSocket);


                        break;
                    case "A2": //销售信息
                        int resultA2 = 0;
                        string machineNum = Utility.GenerateRealityData(data.Skip(1).Take(4).ToArray(), "intval");
                        string serialNum = Utility.GenerateRealityData(data.Skip(5).Take(4).ToArray(), "intval");
                        string tunnelNum = Utility.GenerateRealityData(data.Skip(9).Take(5).ToArray(), "stringval");
                        string amount = data[14].ToString();//数量
                        string currStock = data[15].ToString();//存量
                        string typeVal = data[16].ToString();//刷卡/现金   0-现金1-刷卡 2-二维码取货255-销售失败
                        string cardNum = Utility.byteToHexStr(data.Skip(17).Take(4).ToArray());

                        byte[] returnByteA2 = new byte[14];
                        returnByteA2[0] = byteInfo[0];//包头;
                        returnByteA2[1] = 10; //size
                        returnByteA2[3] = data[0];
                        data.Skip(1).Take(4).ToArray().CopyTo(returnByteA2, 4);//机器编号
                        data.Skip(5).Take(4).ToArray().CopyTo(returnByteA2, 8);//流水号

                        //判断是否重复发包
                        /*
                        if (daoBll.RepeatSend(machineNum, serialNum, myClientSocket) > 0)
                        {
                            returnByteA2[12] = 2;
                        }
                        else if (daoBll.ExistMachine(machineNum) < 1)//检查是否存在机器
                        {
                            returnByteA2[12] = 6;
                        }
                        else if (daoBll.VerifyCard(cardNum) < 1)
                        {
                            returnByteA2[12] = 8;
                        }
                        else
                        {
                            try
                            {
                                resultA2 = daoBll.CreateMaterialRecord(serialNum, DateTime.Now, machineNum, tunnelNum, cardNum, amount, typeVal);
                                if (resultA2 > 0)
                                {
                                    returnByteA2[12] = 0;
                                }
                            }
                            catch
                            {
                                returnByteA2[12] = 10;
                            }

                        }
                         * 
                         * */







                        returnByteA2[13] = 238;
                        //验证码生成
                        byte resultA2Chunk = new byte();
                        byte[] finalResultA2 = returnByteA2.Skip(3).Take(returnByteA2[1]).ToArray();
                        for (int i = 0; i < finalResultA2.Length; i++)
                        {
                            resultA2Chunk ^= finalResultA2[i];
                        }
                        returnByteA2[2] = resultA2Chunk;
                        //SendMsg(returnByteA2, myClientSocket);


                        break;
                    case "A6": //满仓信息 (一键补货)
                        string machineNumA6 = Utility.GenerateRealityData(data.Skip(1).Take(4).ToArray(), "intval");
                        int execResultA6 = 0;//daoBll.FullfilGoodsOneKey(machineNumA6);
                        byte[] returnByteA6 = new byte[10];
                        returnByteA6[0] = byteInfo[0];//包头;
                        returnByteA6[1] = 6; //size
                        returnByteA6[3] = data[0];
                        data.Skip(1).Take(4).ToArray().CopyTo(returnByteA6, 4);
                        returnByteA6[9] = 238;

                        //验证码生成
                        byte resultA6 = new byte();
                        byte[] finalResultA6 = returnByteA6.Skip(3).Take(returnByteA6[1]).ToArray();
                        for (int i = 0; i < finalResultA6.Length; i++)
                        {
                            resultA6 ^= finalResultA6[i];
                        }
                        if (execResultA6 > 1)
                        {
                            returnByteA6[8] = 0;
                        }
                        else
                        {
                            returnByteA6[8] = 6;
                        }
                        returnByteA6[2] = resultA6;
                        //SendMsg(returnByteA6, myClientSocket);
                        break;
                    case "A0": //心跳包
                        string machineNumA0 = Utility.GenerateRealityData(data.Skip(1).Take(4).ToArray(), "intval");
                        int execResultA0 = 0;//daoBll.ExistMachine(machineNumA0);
                        byte[] returnByteA0 = new byte[10];
                        returnByteA0[0] = byteInfo[0];//包头;
                        returnByteA0[1] = 5; //size
                        returnByteA0[3] = data[0];
                        data.Skip(1).Take(4).ToArray().CopyTo(returnByteA0, 4);
                        returnByteA0[9] = 238;
                        //验证码生成
                        byte resultA0 = new byte();
                        byte[] finalResultA0 = returnByteA0.Skip(3).Take(returnByteA0[1]).ToArray();
                        for (int i = 0; i < finalResultA0.Length; i++)
                        {
                            resultA0 ^= finalResultA0[i];
                        }
                        if (execResultA0 > 1)
                        {
                            returnByteA0[8] = 0;
                        }
                        else
                        {
                            returnByteA0[8] = 6;
                        }
                        returnByteA0[2] = resultA0;
                        //SendMsg(returnByteA0, myClientSocket);
                        break;
                    case "A7": //读卡验证信息
                        int execResult = 0;//daoBll.VerifyCard(Utility.byteToHexStr(data.Skip(1).Take(4).ToArray()));
                        if (execResult <= 0)
                        {
                            retResult = 10;
                        }
                        byte[] returnByte = new byte[6];
                        returnByte[0] = byteInfo[0];//包头;
                        returnByte[1] = 2; //size
                        returnByte[3] = data[0];
                        returnByte[4] = (byte)retResult;
                        returnByte[5] = 238;
                        //验证码生成
                        byte result = new byte();
                        byte[] finalResult = returnByte.Skip(3).Take(returnByte[1]).ToArray();
                        for (int i = 0; i < finalResult.Length; i++)
                        {
                            result ^= finalResult[i];
                        }
                        returnByte[2] = result;
                        //SendMsg(returnByte, myClientSocket);

                        break;
                    case "A5": //按货道补货
                        string machineNumA5 = Utility.GenerateRealityData(data.Skip(1).Take(4).ToArray(), "intval");
                        string serialNumA5 = Utility.GenerateRealityData(data.Skip(5).Take(4).ToArray(), "intval");
                        //string tunnelNumA5 = Utility.GenerateRealityData(data.Skip(9).Take(5).ToArray(), "stringval");

                        byte[] returnByteA5 = new byte[10];
                        returnByteA5[0] = byteInfo[0];//包头;
                        returnByteA5[1] = 6; //size
                        returnByteA5[3] = data[0];
                        data.Skip(1).Take(4).ToArray().CopyTo(returnByteA5, 4);
                        returnByteA5[9] = 238;

                        byte[] tunnels = data.Skip(9).Take(data.Length - 9).ToArray();
                        int loopTimes = (tunnels.Length / 4);
                        int resultA5 = 0;//daoBll.FullfilGoodsByTunnel(tunnels, loopTimes, machineNumA5);
                        if (resultA5 == 1)
                        {
                            returnByteA5[8] = 0;
                        }
                        else
                        {
                            returnByteA5[8] = 8;
                        }
                        byte resultByteA5 = new byte();
                        byte[] finalResultA5 = returnByteA5.Skip(3).Take(returnByteA5[1]).ToArray();
                        for (int i = 0; i < finalResultA5.Length; i++)
                        {
                            resultByteA5 ^= finalResultA5[i];
                        }
                        returnByteA5[2] = resultByteA5;
                        //SendMsg(returnByteA5, myClientSocket);
                        break;
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }


            /*
           
             returnByte[13] = (byte)retResult;
             //时间转换成十六进制
             DateTime DT = DateTime.Now;
             double D = DT.ToOADate();
             Byte[] bitDate = BitConverter.GetBytes(D);
             bitDate.CopyTo(returnByte, 14);
             //验证码生成
             byte result = new byte();
             byte[] finalResult = data.Skip(3).Take(22).ToArray();
             for (int i = 0; i < finalResult.Length; i++)
             {
                 result ^= finalResult[i];
             }
             returnByte[2] = result; //验证码
             returnByte[21] = 238;
             */

        }

        //11个字节做异或处理
        private bool IsValidPackage(string infoVerify, byte[] data)
        {
            try
            {
                string finalResult = string.Empty;
                byte result = new byte();
                for (int i = 0; i < data.Length; i++)
                {
                    result ^= data[i];
                }


                return result.ToString() == infoVerify;
            }
            catch (Exception e)
            {
                
                return false;
            }

        }
    }
}
