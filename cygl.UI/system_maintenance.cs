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
    public partial class system_maintenance : Form
    {
        public system_maintenance()
        {
            InitializeComponent();
        }
        BLL.user us = new cygl.BLL.user();
        Model.user ur = new cygl.Model.user();
        public string bt;
        public string la;
        public string sUser;
        private void xtwh_Load(object sender, EventArgs e)
        {
            button1.Text = bt;
            label1.Text = la;
                     
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("�û�������Ϊ��");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("���벻��Ϊ��");
                // ������www.mycodes.net
            }
            else if (button1.Text == "ע��")
            {
                SqlConnection conn = cygl.Helper.DBHelper.getconn();
                conn.Open();
                sUser = textBox2.Text.Trim();
                string sPwd = textBox1.Text.Trim();
                string str = "select name from users where name='" + sUser + "'";
                SqlCommand comm = new SqlCommand(str, conn);
                int i = Convert.ToInt32(comm.ExecuteScalar());
                if (i > 0)
                {
                    MessageBox.Show("�û��Ѿ�����");                 
                }

                else 
                {
                    ur.name = textBox2.Text;
                    ur.pwd = textBox1.Text;
                    us.insert(ur);
                    MessageBox.Show("ע��ɹ�");
                }
            }
            if (button1.Text == "�޸�")
            {
               

                    ur.name = textBox2.Text;
                    ur.pwd = textBox1.Text;
                    us.update(ur);
                    MessageBox.Show("�޸ĳɹ�");
                
                
            }
            if (button1.Text == "ע��")
            {
                    ur.name = textBox2.Text;
                    ur.pwd = textBox1.Text;
                    us.delete(ur);
                    MessageBox.Show("ע���ɹ�");
                
            }
        }
       
        
    }
}

       