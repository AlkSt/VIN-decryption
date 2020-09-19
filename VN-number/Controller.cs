using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_number
{
    class Controller
    {
        Inverter model = new Inverter();
        public Car getAllInformation( string vin)
        {
            return model.decodeVIN(vin);
        }

        public bool Correct(string vin)
        {
            return model.CorrectCHK(vin);
        }
    }
}
