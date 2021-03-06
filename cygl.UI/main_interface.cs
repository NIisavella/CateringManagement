using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace cygl.UI
{
    public partial class main_interface : Form
    {
        public main_interface()
        {
            InitializeComponent();
        }
        public SqlDataReader sdr;
        public string Times;
        public string Names;
        Model.user us = new cygl.Model.user();
        private void 桌台信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            table_info fm = new table_info();
            fm.Show();
        }

        private void 职员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            staff_info fm = new staff_info();
            fm.Show();
        }
        private void 菜品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            food_info fm = new food_info();
            fm.Show();
        }

        private void 注册管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            system_maintenance fm = new system_maintenance();
            fm.bt = "注册";
            fm.la = "注册";
            fm.Show();
        }

        private void 修改管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            system_maintenance fm = new system_maintenance();
            fm.bt = "修改";
            fm.la = "修改";
            fm.Show();
        }

        private void 注销管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            system_maintenance fm = new system_maintenance();
            fm.bt = "注销";
            fm.la = "注销";
            fm.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确定退出本系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void AddItems(string rzt)
        {
            if (rzt == "使用")
            {
                lvDesk.Items.Add(sdr["roomname"].ToString(), 1);
            }
            else
            {
                lvDesk.Items.Add(sdr["roomName"].ToString(), 0);
            }
        }

        private void zjm_Activated(object sender, EventArgs e)
        {
            lvDesk.Items.Clear();
            SqlConnection conn = cygl.Helper.DBHelper.getconn();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from room", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                string zt = sdr["roomzt"].ToString().Trim();
                AddItems(zt);
            }
            conn.Close();
        }

        private void 开台ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDesk.SelectedItems.Count != 0)
            {

                string names = lvDesk.SelectedItems[0].SubItems[0].Text;
                kt openroom = new kt();
                openroom.name = names;
                openroom.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择桌台");
            }
        }

        private void 取消开台ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDesk.SelectedItems.Count != 0)
            {
                SqlConnection conn = cygl.Helper.DBHelper.getconn();
                conn.Open();
                string names = lvDesk.SelectedItems[0].SubItems[0].Text;
                SqlCommand cmd = new SqlCommand("Select * from guestfood where roomname='" + names + "'", conn);
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                if (i > 0)
                {
                    MessageBox.Show("请先结帐!!");

                }
                else
                {
                    cmd = new SqlCommand("update room set roomzt='待用' where roomname='" + names + "'", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("delete from guestfood where roomname='" + names + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    zjm_Activated(sender, e);
                }
            }
            else
            {
                MessageBox.Show("请选择桌台");

            }
        }

        private void 点加菜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDesk.SelectedItems.Count != 0)
            {
                string names = lvDesk.SelectedItems[0].SubItems[0].Text;
                order_add_food dc = new order_add_food();
                dc.RName = names;
                dc.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择桌台");
            }
        }

        private void lvDesk_Click(object sender, EventArgs e)
        {
            string names = lvDesk.SelectedItems[0].SubItems[0].Text;
            SqlConnection conn = cygl.Helper.DBHelper.getconn();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from room where roomname='" + names + "'", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            string zt = sdr["roomzt"].ToString().Trim();
            sdr.Close();
            if (zt == "使用")
            {
                this.yjcd.Items[0].Enabled = false;
                this.yjcd.Items[1].Enabled = true;
                this.yjcd.Items[3].Enabled = true;
                this.yjcd.Items[5].Enabled = true;
                this.yjcd.Items[6].Enabled = true;
            }
            if (zt == "待用")
            {
                this.yjcd.Items[0].Enabled = true;
                this.yjcd.Items[1].Enabled = false;
                this.yjcd.Items[3].Enabled = false;
                this.yjcd.Items[5].Enabled = false;
                this.yjcd.Items[6].Enabled = false;
            }
            conn.Close();
        }

        private void 结账ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDesk.SelectedItems.Count != 0)
            {
                string names = lvDesk.SelectedItems[0].SubItems[0].Text;
                Payment jza = new Payment();
                jza.Rname = names;
                jza.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择桌台");
            }
        }

        private void 消费查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDesk.SelectedItems.Count != 0)
            {
                string names = lvDesk.SelectedItems[0].SubItems[0].Text;
                consumption_inquiry serch = new consumption_inquiry();
                serch.RName = names;
                serch.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择桌台");
            }
        }

        private void 历史账单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bill_history fm = new bill_history();
            fm.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();

        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void zjm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void zjm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            designer_info fm = new designer_info();
            fm.Show();
        }

        private void 日历ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calender fm = new calender();
            fm.Show();
        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void 记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void zjm_Load(object sender, EventArgs e)
        {

        }

        private void zcd_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}