using System;
using System.Collections.Generic;
using System.Text;

namespace cygl.Model
{
    public class room
    {
        public string id;//������
        public string roomname;//��������
        public string roomabb;//������
        public string roomfee;//��������
        public string roomlocation;//����λ��
        public string roomstate;//����״̬

        public string Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Roomname
        {
            set { roomname = value; }
            get { return roomname; }
        }
        public string Roomabb
        {
            set { roomabb = value; }
            get { return roomabb; }
        }
        public string Roomfee
        {
            set { roomfee = value; }
            get { return roomfee; }
        }
        public string Roomlocation
        {
            set { roomlocation = value; }
            get { return roomlocation; }
        }
        public string Roomstate
        {
            set { roomstate = value; }
            get { return roomstate; }
        }
        
    }
}
