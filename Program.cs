using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using gts;

namespace GoogolDemo
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool bDebugMode = false;
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (bDebugMode) AllocConsole();
            Application.Run(new FormMain());
            if (bDebugMode) FreeConsole();
        }
    }
    public class GoogolMoto
    {
        public void Initialize()
        {
            short s_SlotNum;
            mc.GT_Open(0, 0);
            mc.GT_GetCardNo(out s_SlotNum);
            mc.GT_Reset();
            //mc.GT_LoadConfig("20130821.cfg");
            mc.GT_ClrSts(1, 8);
            mc.GT_EncSns(0);
        }
    }
    public class GoogolAxis
    {
        public short s_AxisName;
        public GoogolAxis(short axis)
        {
            s_AxisName = axis;
        }
        public void Initialize()
        {
            mc.GT_StepPulse(s_AxisName);//设置轴输出正负脉冲信号            
            mc.GT_LmtsOff(s_AxisName, mc.MC_LIMIT_POSITIVE);//负限位无效
            mc.GT_LmtsOff(s_AxisName, mc.MC_LIMIT_NEGATIVE);//正限位无效
            mc.GT_EncOn(s_AxisName);
            mc.GT_AlarmOn(s_AxisName);
            mc.GT_AxisOn(s_AxisName);//驱动使能 
            mc.GT_ClrSts(s_AxisName, 8);//控制轴状态寄存器复位 
            mc.GT_ZeroPos(s_AxisName, 1);
            mc.GT_SetAxisBand(s_AxisName, 5, 4);
        }
        public void GoHome()
        {
            int axisMask;
            int intTemp;
            intTemp = s_AxisName - 1;
            axisMask = 1 << intTemp;
            short captureStatus;
            uint clock;
            bool HomeFlag = true;
            int HomeState;
            mc.TTrapPrm trap;
            mc.TJogPrm returnJogPrm;
            int Status;
            int captureValue;

            double HomeVel = 0;//归零速度
            double HomeAcc = 0;//归零加速度
            double HomeVel1 = -5;
            double HomeAcc1 = 1;
            double HomeVel2 = 5;
            double HomeAcc2 = 1;
            double HomeVel3 = 20;
            double HomeAcc3 = 4;
            double HomeVel4 = 20;
            double HomeAcc4 = 4;
            //double homeReturnVel = 5;
            int homeReturnOffset = 0;
            int homeReturnOffset1 = -1500;
            int homeReturnOffset2 = 0;
            int homeReturnOffset3 = 0;
            int homeReturnOffset4 = 0;
            mc.GT_ZeroPos(s_AxisName, 1);//实际,规划,目标位置清零
            mc.GT_ClrSts(s_AxisName, 1);

            mc.GT_GetDi(mc.MC_HOME, out HomeState);//GTS卡的读原点状态home0、1、2、3分别对应着第四位的bit0、bit1、bit2、bit3，挡住是相应的位为0，未挡住相应的位为1.
            switch (this.s_AxisName)
            {
                case 1:
                    if ((HomeState & 0x01) == 1) HomeFlag = true;//传感器未挡，BAT674未挡悬空                             
                    else HomeFlag = false;
                    HomeVel = HomeVel1;
                    HomeAcc = HomeAcc1;
                    homeReturnOffset = homeReturnOffset1;//偏移量赋值
                    break;
                case 2:
                    if ((HomeState & 0x2) == 2) HomeFlag = true;//传感器未挡住,BAZ471挡悬空
                    else HomeFlag = false;
                    HomeVel = HomeVel2;
                    HomeAcc = HomeAcc2;
                    homeReturnOffset = homeReturnOffset2;//偏移量赋值
                    break;
                case 3:
                    if ((HomeState & 0x4) == 4) HomeFlag = true;//传感器未挡住,EJP674未挡悬空
                    else HomeFlag = false;
                    HomeVel = HomeVel3;
                    HomeAcc = HomeAcc3;
                    homeReturnOffset = homeReturnOffset3;//偏移量赋值
                    break;
                case 4:
                    if ((HomeState & 0x8) == 8) HomeFlag = true;//传感器未挡住,EAZ673未挡悬空
                    else HomeFlag = false;
                    HomeVel = HomeVel4;
                    HomeAcc = HomeAcc4;
                    homeReturnOffset = homeReturnOffset4;//偏移量赋值
                    break;
            }
            if (HomeFlag)
            {
                mc.GT_SetCaptureSense(s_AxisName, mc.CAPTURE_HOME, 0);//设置各轴home为下降沿触发
                mc.GT_SetCaptureMode(s_AxisName, mc.CAPTURE_HOME);//设置为home信号捕获
                //mc.GT_SetAxisBand(s_AxisName, 5, 4);
                mc.GT_PrfJog(s_AxisName);
                mc.GT_GetJogPrm(s_AxisName, out returnJogPrm);
                returnJogPrm.acc = HomeAcc;//Jog运动参数初始化
                returnJogPrm.dec = HomeAcc;
                mc.GT_SetJogPrm(s_AxisName, ref returnJogPrm);
                mc.GT_SetVel(s_AxisName, HomeVel);
                mc.GT_Update(axisMask);//刷新控制轴参数 
                do
                {
                    mc.GT_GetCaptureStatus(s_AxisName, out captureStatus, out captureValue, 1, out clock);//读取读取捕获状态和捕获时的位置信息;
                } while (captureStatus == 0);//归零传感器是否触发  
                mc.GT_Stop(axisMask, axisMask);//急停止当前轴的运动
                mc.GT_Update(axisMask);
                mc.GT_ClrSts(this.s_AxisName, 1);
            }
            Thread.Sleep(100);//平滑停止，一定要加的。“可能指令发完了，平滑停止还没真正停止”
            mc.GT_SetCaptureSense(s_AxisName, mc.CAPTURE_HOME, 1);//设置各轴home为上升沿触发
            mc.GT_SetCaptureMode(s_AxisName, mc.CAPTURE_HOME);//设置为home信号捕获
            //mc.GT_SetAxisBand(s_AxisName, 5, 4);
            mc.GT_PrfJog(s_AxisName);
            mc.GT_GetJogPrm(s_AxisName, out returnJogPrm);
            returnJogPrm.acc = HomeAcc;//Jog运动参数初始化
            returnJogPrm.dec = HomeAcc;
            mc.GT_SetJogPrm(s_AxisName, ref returnJogPrm);
            mc.GT_SetVel(s_AxisName, -HomeVel);
            mc.GT_Update(axisMask);//刷新控制轴参数 
            do
            {
                mc.GT_GetCaptureStatus(s_AxisName, out captureStatus, out captureValue, 1, out clock);//读取捕获状态和捕获时的位置信息;
            } while (captureStatus == 0);//归零传感器是否触发 
            mc.GT_Stop(axisMask, axisMask);//停止当前轴的运动
            mc.GT_Update(axisMask);
            mc.GT_ClrSts(this.s_AxisName, 1);
            Thread.Sleep(100);
            //Console.WriteLine("捕获位置：{0}", captureValue);
            do
            {
                mc.GT_GetSts(s_AxisName, out Status, 1, out clock);//读取轴状态
            } while ((Status & (1 << 10)) != 0);//判断轴状态,常用的有第10位和第11位来判断轴是否停止,第10位为0或者第11位为1时，表示电机已停止。
            //伺服也可以用while((Status & (1 << 11)) == 0) 来做判断，而步进不能
            //Console.WriteLine("停止规划位置：{0}",this.StepPosition );
            //Console.WriteLine("停止编码器位置：{0}", this.StepEncPosition);
            mc.GT_PrfTrap(s_AxisName);
            mc.GT_GetTrapPrm(s_AxisName, out trap);
            trap.acc = 0.5;
            trap.dec = 0.5;
            mc.GT_SetTrapPrm(s_AxisName, ref trap);
            double doubleTemp = Math.Abs(HomeVel);
            double backVel = doubleTemp * 0.5;
            mc.GT_SetVel(s_AxisName, backVel);
            mc.GT_SetPos(s_AxisName, captureValue + homeReturnOffset);//设置p2p运动模式，回到原点+偏置
            mc.GT_Update(axisMask);
            do
            {
                mc.GT_GetSts(s_AxisName, out Status, 1, out clock);
            } while ((Status & (1 << 10)) != 0);//判断轴状态,常用的有第10位和第11位来判断轴是否停止,第10位为0或者第11位为1时，表示电机已停止。
            //伺服也可以用while((Status & (1 << 11)) == 0) 来做判断，而步进不能
            Thread.Sleep(200);
            mc.GT_ZeroPos(s_AxisName, 1);
            mc.GT_ClrSts(s_AxisName, 1);
            //Console.WriteLine("{home success}");
        }
        public void StartMoveTo(int step)
        {
            //mc.GT_SetPos(s_AxisName, step);//设置控制轴目标位置 
            //mc.GT_Update(s_AxisName);  //刷新控制轴参数
            mc.GT_SetPos(s_AxisName, step);
            mc.GT_Update(1 << (s_AxisName - 1));
        }
        public void StartMove(int step)
        {
            //int pos;
            ////mc.GT_GetPos(s_AxisName, out pos);
            //mc.GT_GetPrfPos(s_AxisName, out pos);
            //mc.GT_SetPos(s_AxisName, pos + step);//设置控制轴目标位置 
            //mc.GT_Update(s_AxisName);//刷新控制轴参数 

            //GTS
            ////如果需要相对运动，可以先将当前位置读出，在运动step
            double pos;
            uint pClock;
            mc.GT_GetPrfPos(s_AxisName, out pos, 1, out pClock);//读取当前位置，存储在pos中 
            mc.GT_SetPos(s_AxisName, Convert.ToInt32(pos + step));//把“当前位置+相对运动值”作为目标值
            mc.GT_Update(1 << (s_AxisName - 1));
            //GTS
        }
        public void ApplyConfigT(double MaxVel, double MAcc)
        {
            //设置Profile
            //mc.GT_PrflT(s_AxisName);//设置为梯形曲线加减速 
            //mc.GT_SetVel(s_AxisName, MaxVel);//设置控制轴速度 
            //mc.GT_SetAcc(s_AxisName, MAcc);//设置控制轴加速度 
            mc.TTrapPrm trap;
            mc.GT_PrfTrap(s_AxisName);
            mc.GT_GetTrapPrm(s_AxisName, out trap);
            trap.acc = MAcc;
            trap.dec = MAcc;
            trap.velStart = 0;
            trap.smoothTime = 0;//平滑时间等于0
            mc.GT_SetTrapPrm(s_AxisName, ref trap);
            mc.GT_SetVel(s_AxisName, MaxVel);
        }
        public void ApplyConfigS(double MaxVel, double MAcc, short Jerk)
        {
            //mc.GT_PrflS(s_AxisName);//设置为梯形曲线加减速 
            //mc.GT_SetVel(s_AxisName, MaxVel);//设置控制轴速度 
            //mc.GT_SetMAcc(s_AxisName, MAcc);//设置控制轴加速度 
            //mc.GT_SetJerk(s_AxisName, Jerk);//设置控制轴加加速度   

            //GTS
            mc.TTrapPrm trap;
            mc.GT_PrfTrap(s_AxisName);
            mc.GT_GetTrapPrm(s_AxisName, out trap);
            trap.acc = MAcc;
            trap.dec = MAcc;
            trap.velStart = 0;
            trap.smoothTime = Jerk;
            mc.GT_SetTrapPrm(s_AxisName, ref trap);
            mc.GT_SetVel(s_AxisName, MaxVel);
            //GTS
        }
        public bool CheckMotorArrive()
        {
            ////读取IO
            //return true;
            int pSts;
            uint pClock;
            mc.GT_GetSts(s_AxisName, out pSts, 1, out pClock);//读取轴状态
                                                              //参数：1.要读取状态轴的起始轴号。2.轴状态返回值 3.轴数量。4.系统时钟

            if ((pSts & (1 << 10)) == 0 & ((pSts & (1 << 11))) != 0)
            {//电机停止  
                return true;                                 //判断轴状态，请参考轴状态定义表。
            }                                                //常用的有第10位和第11位来判断轴是否停止。
            else                                             //第10位为0或者第11位为1时，表示电机已停止。
            {//电机运动
                return false;
            }
        }
        public bool CheckDone()
        {
            int pSts;
            uint pClock;
            mc.GT_GetSts(s_AxisName, out pSts, 1, out pClock); //读取轴状态
            //参数：1.要读取状态轴的起始轴号。2.轴状态返回值
            //      3.轴数量。4.系统时钟
            if ((pSts & (1 << 10)) == 0)
            {//电机停止  
                return true;                                 //判断轴状态，请参考轴状态定义表。
            }                                                //常用的有第10位和第11位来判断轴是否停止。
            else                                             //第10位为0或者第11位为1时，表示电机已停止。
            {//电机运动
                return false;
            }

        }
        public double StepPosition
        {
            get
            {
                uint pClock;
                double prfpos;
                mc.GT_GetPrfPos(s_AxisName, out prfpos, 8, out pClock);  //读取规划位置
                return prfpos;
            }
        }
        public double StepEncPosition
        {
            get
            {
                uint pClock;
                double prfpos;
                mc.GT_GetEncPos(s_AxisName, out prfpos, 8, out pClock);  //读取规划位置
                return prfpos;
            }
        }
        public void SetSevonStatus(bool status)
        {
            if (status)
            {
                mc.GT_AxisOn(s_AxisName);
            }
            else
                mc.GT_AxisOff(s_AxisName);
        }
        public void AbortMotion()
        {
            mc.GT_Stop(s_AxisName, 1);
        }

        public void ReleaseUnitCell()
        {
            mc.GT_Stop(s_AxisName, 1);

            mc.GT_AxisOff(s_AxisName);
        }
        public void SearchMode(double vel, double acc)
        {
            //mc.GT_PrflV(s_AxisName);  //设置为速度控制模式 
            //mc.GT_SetVel(s_AxisName, vel);    //设置控制轴速度 
            //mc.GT_SetAcc(s_AxisName, acc);    //设置控制轴加速度 
            //mc.GT_Update(s_AxisName);  //刷新控制轴参数 
        }
        public void Test1(double MaxVel, double MAcc, double Jerk, int step)
        {
            //int pos1;
            //int EncPos;
            //int PrfPos;

            //mc.GT_GetPos(s_AxisName, out pos1);
            //mc.GT_GetAtlPos(s_AxisName, out EncPos);
            //mc.GT_GetPrfPos(s_AxisName, out PrfPos);
            //Console.WriteLine("PrfPos = " + PrfPos);
            //Console.WriteLine("GetPos = " + pos1);
            //Console.WriteLine("EncPos = " + EncPos);

            //Console.WriteLine("Test "+"s_AxisName = " + s_AxisName);
            //mc.GT_PrflS(s_AxisName);  //设置为梯形曲线加减速 
            //mc.GT_SetVel(s_AxisName, MaxVel);      //设置控制轴速度 
            //mc.GT_SetMAcc(s_AxisName, MAcc);    //设置控制轴加速度 
            //mc.GT_SetJerk(s_AxisName, Jerk);    //设置控制轴加加速度   

            //mc.GT_PrflT(s_AxisName);  //设置为梯形曲线加减速 
            //mc.GT_SetVel(s_AxisName, MaxVel);      //设置控制轴速度 
            //mc.GT_SetAcc(s_AxisName, MAcc);    //设置控制轴加速度 


            //int pos;
            //mc.GT_GetPos(s_AxisName, out pos);
            //mc.GT_GetPrfPos(s_AxisName, out pos);
            //mc.GT_SetPos(s_AxisName, pos + step);    //设置控制轴目标位置 
            //mc.GT_Update(s_AxisName);  //刷新控制轴参数 
        }
        public void Test2()
        {
            //int pos;
            //mc.GT_GetAtlPos(s_AxisName, out pos);
            //mc.GT_SetAtlPos(s_AxisName, 0);

            //mc.GT_ZeroPos(s_AxisName);

            //Thread.Sleep(10);

            //short rtn1, rtn2, rtn3, rtn4;
            //rtn1 = mc.GT_PrflV(s_AxisName);  //设置为速度控制模式 
            //rtn2 = mc.GT_SetVel(s_AxisName, -20);    //设置控制轴速度 
            //rtn3 = mc.GT_SetAcc(s_AxisName, 5);    //设置控制轴加速度 
            //rtn4 = mc.GT_Update(s_AxisName);  //刷新控制轴参数 
            //Console.WriteLine("rtn1 = " + rtn1 + " rtn2 = " + rtn2 + " rtn3 = " + rtn3 + " rtn4 = " + rtn4);

            //Thread.Sleep(1000);

            //mc.GT_AbptStp(s_AxisName);

            //Thread.Sleep(100);

            //int pos1;
            //int EncPos;
            //int PrfPos;

            //mc.GT_GetPos(s_AxisName, out pos1);
            //mc.GT_GetAtlPos(s_AxisName, out EncPos);
            //mc.GT_GetPrfPos(s_AxisName, out PrfPos);
            //Console.WriteLine("PrfPos = " + PrfPos);
            //Console.WriteLine("GetPos = " + pos1);
            //Console.WriteLine("EncPos = " + EncPos);
            //插补运动代码
            mc.TCrdPrm TCrdPrm;
            TCrdPrm.dimension = 2;
            TCrdPrm.synVelMax = 500;
            TCrdPrm.synAccMax = 1;
            TCrdPrm.evenTime = 0;
            TCrdPrm.profile1 = 1;
            TCrdPrm.profile2 = 2;
            TCrdPrm.profile3 = 0;
            TCrdPrm.profile4 = 0;
            TCrdPrm.profile5 = 0;
            TCrdPrm.profile6 = 0;
            TCrdPrm.profile7 = 0;
            TCrdPrm.profile8 = 0;
            TCrdPrm.setOriginFlag = 1;
            TCrdPrm.originPos1 = 10000;
            TCrdPrm.originPos2 = 10000;
            TCrdPrm.originPos3 = 0;
            TCrdPrm.originPos4 = 0;
            TCrdPrm.originPos5 = 0;
            TCrdPrm.originPos6 = 0;
            TCrdPrm.originPos7 = 0;
            TCrdPrm.originPos8 = 0;

            mc.GT_SetCrdPrm(1, ref TCrdPrm);

            mc.GT_CrdClear(1, 0);

            mc.GT_LnXY(1, 2000, 2000, 100, 0.8, 0, 0);
            mc.GT_LnXY(1, 2000, 4000, 100, 0.8, 0, 0);
            mc.GT_LnXY(1, -2000, 2000, 100, 0.8, 0, 0);
            mc.GT_LnXY(1, 0, 0, 100, 0.8, 0, 0);

            mc.GT_CrdStart(1, 0);
        }
    }
}
