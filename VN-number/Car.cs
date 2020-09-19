using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_number
{
    class Car
    {
        int id_firm;
        string firm_name;
        string model;
        string body;
        int year;
        string producter;
        string engine;

        public Car()
        {
             firm_name = "--";
             model= "--";
             body = "--"; 
             year =  0;
             producter= "--";
             engine = "--";
        }

        public int firmId
        {
            get { return id_firm; }
            set { id_firm = value; }
        }
        public string firmName
        {
            get { return firm_name; }
            set { standartSet(value, ref firm_name); }
        }
        public string Model
        {
            get { return model; }
            set { standartSet(value, ref model); }
        }
        public string Body
        {
            get { return body; }
            set { standartSet(value, ref body); }
        }
        public string Engine
        {
            get { return engine; }
            set { standartSet(value, ref engine); }
        }
        public int Year
        {
            get { return year; }
            set { if (value != 0) { if (value > 1970) year = value; } }
        }
        public string Producter
        {
            get { return producter; }
            set { standartSet(value, ref producter); }
        }

        static void standartSet(string val, ref string param)
        {
            if (val != null) param = val.Replace("  ", ""); else param = "--";
        }

        public void UncnownCar()
        {
            firm_name = "Неизвестная";
        }
    }
}
