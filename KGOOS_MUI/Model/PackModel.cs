using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGOOS_MUI.Model
{
    public class PackModel
    {
        //表一
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


        //表二
        private string _order_id;
        public string order_id
        {
            get { return _order_id; }
            set { _order_id = value; }
        }
        private string _order_date;
        public string order_date
        {
            get { return _order_date; }
            set { _order_date = value; }
        }
        private string _order_con_id;
        public string order_con_id
        {
            get { return _order_con_id; }
            set { _order_con_id = value; }
        }
        private string _order_con;
        public string order_con
        {
            get { return _order_con; }
            set { _order_con = value; }
        }
        private string _order_destrination;
        public string order_destrination
        {
            get { return _order_destrination; }
            set { _order_destrination = value; }
        }
        private string _pack_type;
        public string pack_type
        {
            get { return _pack_type; }
            set { _pack_type = value; }
        }
        private string _order_note;
        public string order_note
        {
            get { return _order_note; }
            set { _order_note = value; }
        }
        private string _order_put_type;
        public string order_put_type
        {
            get { return _order_put_type; }
            set { _order_put_type = value; }
        }


        //表三
        private string _order_person;
        public string order_person
        {
            get { return _order_person; }
            set { _order_person = value; }
        }

        private string _order_phone;
        public string order_phone
        {
            get { return _order_phone; }
            set { _order_phone = value; }
        }

        private string _order_adress;
        public string order_adress
        {
            get { return _order_adress; }
            set { _order_adress = value; }
        }

        private string _order_company;
        public string order_company
        {
            get { return _order_company; }
            set { _order_company = value; }
        }

        private string _order_zhou;
        public string order_zhou
        {
            get { return _order_zhou; }
            set { _order_zhou = value; }
        }


        //表四
        private string _order_thing;
        public string order_thing
        {
            get { return _order_thing; }
            set { _order_thing = value; }
        }
        private string _order_money;
        public string order_money
        {
            get { return _order_money; }
            set { _order_money = value; }
        }
        private string _order_china;
        public string order_china
        {
            get { return _order_china; }
            set { _order_china = value; }
        }
        private string _order_idcard;
        public string order_idcard
        {
            get { return _order_idcard; }
            set { _order_idcard = value; }
        }
        private string _order_num;
        public string order_num
        {
            get { return _order_num; }
            set { _order_num = value; }
        }
        private string _order_unit;
        public string order_unit
        {
            get { return _order_unit; }
            set { _order_unit = value; }
        }

        //表五
        private string _pack_staff;
        public string pack_staff
        {
            get { return _pack_staff; }
            set { _pack_staff = value; }
        }
        private string _pack_now_helf;
        public string pack_now_helf
        {
            get { return _pack_now_helf; }
            set { _pack_now_helf = value; }
        }
        private string _pack_note;
        public string pack_note
        {
            get { return _pack_note; }
            set { _pack_note = value; }
        }
        private string _pack_scan;
        public string pack_scan
        {
            get { return _pack_scan; }
            set { _pack_scan = value; }
        }
        private string _pack_time;
        public string pack_time
        {
            get { return _pack_time; }
            set { _pack_time = value; }
        }
        private string _pack_num;
        public string pack_num
        {
            get { return _pack_num; }
            set { _pack_num = value; }
        }
        private string _pack_font_helf;
        public string pack_font_helf
        {
            get { return _pack_font_helf; }
            set { _pack_font_helf = value; }
        }
        private string _pack_font_freight;
        public string pack_font_freight
        {
            get { return _pack_font_freight; }
            set { _pack_font_freight = value; }
        }
        private string _pack_real_company;
        public string pack_real_company
        {
            get { return _pack_real_company; }
            set { _pack_real_company = value; }
        }                     
    }
}
