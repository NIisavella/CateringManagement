using System;
using System.Collections.Generic;
using System.Text;

namespace cygl.Model
{
     public class food
    {
        public string id;//ʳ��id
        public string foodtype;//ʳ������
        public string foodnum;//ʳ������
        public string foodname;//ʳ������
        public string foodprice;//ʳ��۸�
        //get�����Դ��� setд���Դ���
        //�������Զ�д���������
        public string Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Foodtype
        {
            set { foodtype = value; }
            get { return foodtype; }

        }
        public string Foodnum
        {
            set { foodnum = value; }
            get { return foodnum; }
        }
        public string Foodname
        {
            set { foodname = value; }
            get { return foodname; }

        }
        public string Foodprice
        {
            set { foodprice = value; }
            get { return foodprice; }
        }
    }
}
