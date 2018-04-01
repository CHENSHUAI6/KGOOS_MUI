using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGOOS_MUI.Model
{
    public class PackModel
    {

        private bool _paid;
        public bool paid
        {
            get { return _paid; }
            set { _paid = value; }
        }
        private bool _informPay;
        public bool informPay
        {
            get { return _informPay; }
            set { _informPay = value; }
        }
        private bool _processed;
        public bool processed
        {
            get { return _processed; }
            set { _processed = value; }
        }
        private bool _read;
        public bool read
        {
            get { return _read; }
            set { _read = value; }
        }
        private string _pack_state;
        public string pack_state
        {
            get { return _pack_state; }
            set { _pack_state = value; }
        }
        private string _pack_user_id;
        public string pack_user_id
        {
            get { return _pack_user_id; }
            set { _pack_user_id = value; }
        }
        private string _pack_user_name;
        public string pack_user_name
        {
            get { return _pack_user_name; }
            set { _pack_user_name = value; }
        }
    }
}
