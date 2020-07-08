using gts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GoogolDemo
{
    public partial class FormMain : Form
    {
        public bool offline = true;
        public const short BAT = 1;//摆臂
        public const short BAZ = 2;//摆臂上下
        public const short EJP = 3;//顶针
        string[] AllShafts = { "--Select an axis--", ">>BAT<<", ">>BAZ<<", ">>EJP<<" };

        private GoogolMoto moto;
        private GoogolAxis bat, baz, ejp, Axis;
        private bool enBat = false, enBaz = false, enEjp = false;
        int TestNo = 5;
        short Jerk1, Jerk2, Jerk3, Jerk4, Jerk;
        int Dist1, Dist2, Dist3, Dist4, Dist;
        double Macc1, Macc2, Macc3, Macc4, Macc, Vel1, Vel2, Vel3, Vel4, Vel;

        private void button_stoprpt_Click(object sender, EventArgs e)
        {
            flag = true;
        }
        private void button_ChangePos_Click(object sender, EventArgs e)
        {
            if (!offline)
            {
                if (bat == Axis)
                { mc.GT_SetPos(BAT, int.Parse(textBox_pos.Text)); mc.GT_Update(1 << (BAT - 1)); }
                else if (baz == Axis)
                { mc.GT_SetPos(BAZ, int.Parse(textBox_pos.Text)); mc.GT_Update(1 << (BAZ - 1)); }
                else
                { mc.GT_SetPos(EJP, int.Parse(textBox_pos.Text)); mc.GT_Update(1 << (EJP - 1)); }
            }
        }
        private void button_ChangeSpd_Click(object sender, EventArgs e)
        {
            if (!offline)
            {
                if (bat == Axis)
                {
                    mc.GT_SetVel(BAT, double.Parse(textBox_spd.Text)); mc.GT_Update(1 << (BAT - 1));
                }
                else if (baz == Axis)
                {
                    mc.GT_SetVel(BAZ, double.Parse(textBox_spd.Text)); mc.GT_Update(1 << (BAZ - 1));
                }
                else
                {
                    mc.GT_SetVel(EJP, double.Parse(textBox_spd.Text)); mc.GT_Update(1 << (EJP - 1));
                }
            }
        }
        bool flag = false;
        private void button_rpt_Click(object sender, EventArgs e)
        {
            button_rpt.Enabled = false;
            if (!offline)
            {
                Thread t = new Thread(new ThreadStart(Contine_motion_do));
                t.Start();
            }
        }
        private void Contine_motion_do()
        {
            AxisPara();
            TestNo = 5;
            int fromPos = 37500;
            int toPos = -37500;
            for (int i = 0; i < this.TestNo; i++)
            {
                if (this.flag) { this.flag = false; break; }

                #region 摆臂模拟实际情况
                ////**************************************************************************************************//
                //T轴向正方向运动//
                bat.ApplyConfigS(Vel, Macc, Jerk);
                bat.StartMoveTo(fromPos);
                while (!bat.CheckDone()) Thread.Sleep(1);
                while (!bat.CheckMotorArrive()) Thread.Sleep(1);
                ////***************************************************************************************************//
                #region Z轴上下运动               

                baz.ApplyConfigT(Vel, Macc);
                baz.StartMove(Dist);

                while (!baz.CheckDone()) Thread.Sleep(1);
                while (!baz.CheckMotorArrive()) Thread.Sleep(1);

                Thread.Sleep(20);

                baz.ApplyConfigT(Vel, Macc);
                baz.StartMove(-Dist);

                while (!baz.CheckDone()) Thread.Sleep(1);
                while (!baz.CheckMotorArrive()) Thread.Sleep(1);
                #endregion
                ////**************************************************************************************************//
                ////T轴向负方向运动//
                bat.ApplyConfigS(Vel, Macc, Jerk);
                bat.StartMoveTo(toPos);
                while (!bat.CheckDone()) Thread.Sleep(1);
                while (!bat.CheckMotorArrive()) Thread.Sleep(1);
                ////***************************************************************************************************//
                #region Z轴上下运动

                baz.ApplyConfigT(Vel, Macc);
                baz.StartMove(Dist);

                baz.ApplyConfigS(Vel, Macc, Jerk);
                baz.StartMove(Dist);

                while (!baz.CheckDone()) Thread.Sleep(1);
                while (!baz.CheckMotorArrive()) Thread.Sleep(1);

                Thread.Sleep(200);

                baz.ApplyConfigT(Vel, Macc);
                baz.StartMove(-Dist);

                baz.ApplyConfigS(Vel, Macc, Jerk);
                baz.StartMove(-Dist);

                while (!baz.CheckDone()) Thread.Sleep(1);
                while (!baz.CheckMotorArrive()) Thread.Sleep(1);
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                #endregion
                #endregion
            }
            this.Invoke((MethodInvoker)EnableAxis);
        }
        private void EnableAxis()
        {
            button_rpt.Enabled = true;
        }
        private void button_itpAct_Click(object sender, EventArgs e)
        {
            if (!offline) Axis.Test2();
        }
        private void button_Act_Click(object sender, EventArgs e)
        {
            AxisPara();
            if (!offline) Axis.ApplyConfigT(Vel, Macc);
            if (!offline) Axis.StartMove(Dist);
        }
        public FormMain()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            //SetDesktopLocation(Location.X, Location.Y - 500);
        }
        private void timer_guard_Tick(object sender, EventArgs e)
        {
            if ((enBat == true && enBaz == false && enEjp == false) ||
                (enBaz == true && enBat == false && enEjp == false) ||
                (enEjp == true && enBat == false && enBaz == false))
            {
                groupBox_slg.Enabled = true;
                groupBox_cmd.Enabled = true;
                groupBox_itp.Enabled = false;
            }
            else if (enBat == false && enBaz == false && enEjp == false)
            {
                groupBox_slg.Enabled = false;
                groupBox_cmd.Enabled = false;
                groupBox_itp.Enabled = false;
            }
            else
            {
                groupBox_slg.Enabled = false;
                groupBox_cmd.Enabled = true;
                groupBox_itp.Enabled = true;
            }
        }
        private void button_HomeAct_Click(object sender, EventArgs e)
        {
            if (!offline)
            {
                if (enBat) bat.GoHome();
                if (enBaz) baz.GoHome();
                if (enEjp) ejp.GoHome();
            }
        }
        private void button_EmgStop_Click(object sender, EventArgs e)
        {
            if (!offline)
            {
                if (enBat) bat.AbortMotion();
                if (enBaz) baz.AbortMotion();
                if (enEjp) ejp.AbortMotion();
            }
        }
        private void LoadItems(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            List<string> slist = new List<string>(AllShafts);
            string s1, s2, s3;
            if (comboBox1 == comboBox)
            {
                s2 = comboBox2.GetItemText(comboBox2.SelectedItem);
                s3 = comboBox3.GetItemText(comboBox3.SelectedItem);
                if (s2 != AllShafts[0] || s3 != AllShafts[0])
                {
                    if (s2 != AllShafts[0]) slist.RemoveAt(slist.IndexOf(s2));
                    if (s3 != AllShafts[0]) slist.RemoveAt(slist.IndexOf(s3));
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(slist.ToArray());
                }
                else
                {
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(AllShafts);
                }
            }
            else if (comboBox2 == comboBox)
            {
                s1 = comboBox1.GetItemText(comboBox1.SelectedItem);
                s3 = comboBox3.GetItemText(comboBox3.SelectedItem);
                if (s1 != AllShafts[0] || s3 != AllShafts[0])
                {
                    if (s1 != AllShafts[0]) slist.RemoveAt(slist.IndexOf(s1));
                    if (s3 != AllShafts[0]) slist.RemoveAt(slist.IndexOf(s3));
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(slist.ToArray());
                }
                else
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(AllShafts);
                }
            }
            else
            {
                s1 = comboBox1.GetItemText(comboBox1.SelectedItem);
                s2 = comboBox2.GetItemText(comboBox2.SelectedItem);
                if (s1 != AllShafts[0] || s2 != AllShafts[0])
                {
                    if (s1 != AllShafts[0]) slist.RemoveAt(slist.IndexOf(s1));
                    if (s2 != AllShafts[0]) slist.RemoveAt(slist.IndexOf(s2));
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(slist.ToArray());
                }
                else
                {
                    comboBox3.Items.Clear();
                    comboBox3.Items.AddRange(AllShafts);
                }
            }
        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            short axisNum = 0;
            CheckBox checkBox = (CheckBox)sender;
            ComboBox comboBox = new ComboBox();
            if (checkBox1 == checkBox)
            {
                comboBox = comboBox1;
                axisNum = 1;
            }
            else if (checkBox2 == checkBox)
            {
                comboBox = comboBox2;
                axisNum = 2;
            }
            else
            {
                comboBox = comboBox3;
                axisNum = 3;
            }

            if (comboBox.GetItemText(comboBox.SelectedItem) == AllShafts[0])
            {
                //MessageBox.Show("Choose an axis first in left ComboBox!");                
                checkBox.Checked = false;
                return;
            }
            else
            {
                switch (comboBox.GetItemText(comboBox.SelectedItem))
                {
                    case ">>BAT<<":
                        Axis = bat;
                        //axisNum = BAT;
                        break;
                    case ">>BAZ<<":
                        Axis = baz;
                        //axisNum = BAZ;
                        break;
                    case ">>EJP<<":
                        Axis = ejp;
                        //axisNum = EJP;
                        break;
                }
            }
            if (checkBox.Checked)
            {
                if (!offline) Axis.SetSevonStatus(true);
                RowEnable(axisNum, true);
            }
            else
            {
                if (!offline) Axis.SetSevonStatus(false);
                RowEnable(axisNum, false);
            }
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            moto = new GoogolMoto();
            if (!offline) moto.Initialize();

            bat = new GoogolAxis(BAT);
            baz = new GoogolAxis(BAZ);
            ejp = new GoogolAxis(EJP);
            if (!offline) bat.Initialize();
            if (!offline) baz.Initialize();
            if (!offline) ejp.Initialize();
            Axis = bat;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox1.Items.AddRange(AllShafts);
            comboBox2.Items.AddRange(AllShafts);
            comboBox3.Items.AddRange(AllShafts);
            comboBox1.SelectedIndex = comboBox2.SelectedIndex = comboBox3.SelectedIndex = 0;
            RowEnable(1, false);
            RowEnable(2, false);
            RowEnable(3, false);
            //comboBox1.DisplayMember = comboBox2.DisplayMember = comboBox3.DisplayMember;
            timer_guard.Start();
        }
        private void tableLayoutPanel_para_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0)
            {
                Graphics g = e.Graphics;
                Rectangle r = e.CellBounds;
                g.FillRectangle(Brushes.LightBlue, r);
                //for (int col = 0; col < 6; col++)
                //{
                //    Label label = (Label)tableLayoutPanel_para.Controls[col];
                //    label.BackColor = Color.Blue;
                //}
                label1.BackColor = label2.BackColor = label3.BackColor = label4.BackColor
                    = label5.BackColor = label6.BackColor = Color.LightBlue;
            }
        }
        private void RowEnable(short row, bool en = false)
        {
            switch (row)
            {
                case 1:
                    comboBox1.Enabled = !en;
                    textBox1_1.Enabled = textBox1_2.Enabled = textBox1_3.Enabled = textBox1_4.Enabled = en;
                    //enBat = en;
                    break;
                case 2:
                    comboBox2.Enabled = !en;
                    textBox2_1.Enabled = textBox2_2.Enabled = textBox2_3.Enabled = textBox2_4.Enabled = en;
                    //enBaz = en;
                    break;
                case 3:
                    comboBox3.Enabled = !en;
                    textBox3_1.Enabled = textBox3_2.Enabled = textBox3_3.Enabled = textBox3_4.Enabled = en;
                    //enEjp = en;
                    break;
            }
            if (bat == Axis) enBat = en;
            if (baz == Axis) enBaz = en;
            if (ejp == Axis) enEjp = en;
        }
        private void AxisPara()
        {
            if (groupBox_slg.Enabled)
            {
                if (comboBox1.GetItemText(comboBox1.SelectedItem) != AllShafts[0])
                {
                    Macc = double.Parse(textBox1_1.Text);
                    Jerk = short.Parse(textBox1_2.Text);
                    Vel = double.Parse(textBox1_3.Text);
                    Dist = int.Parse(textBox1_4.Text);
                }
                else if (comboBox2.GetItemText(comboBox2.SelectedItem) != AllShafts[0])
                {
                    Macc = double.Parse(textBox2_1.Text);
                    Jerk = short.Parse(textBox2_2.Text);
                    Vel = double.Parse(textBox2_3.Text);
                    Dist = int.Parse(textBox2_4.Text);
                }
                else
                {
                    Macc = double.Parse(textBox3_1.Text);
                    Jerk = short.Parse(textBox3_2.Text);
                    Vel = double.Parse(textBox3_3.Text);
                    Dist = int.Parse(textBox3_4.Text);
                }
            }
            //this.Dist4 = int.Parse(txbDist4.Text);
        }
    }
}
