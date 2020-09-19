using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VN_number
{
    class Inverter
    { 
        public Car decodeVIN( string vin)
        {
            Car car = new Car();
            //найдем есть ли такая машина если нет выводим неизвестно и заканчиваем
            int idFirm = getFirmId(vin.Substring(0, 3));
            if (idFirm != 0)
                car.firmId = idFirm;
            else { car.UncnownCar(); return car; }
            //ищем в каком порядке и какой длинны коды
            Dictionary<int, Point> pozLenCode = null;
            string pozitionString = getPozitionString(car.firmId);
            if (pozitionString == null)
                return car;
            else pozLenCode = extractPozition(pozitionString);
           // ищем марку (название фирмы) автомобиля
            car.firmName = getFirmName(car.firmId);
            // ищем модель 
            car.Model = getModel(vin, car.firmId,pozLenCode[0]);
            //знаяодель можем найти двигатель
            car.Engine = getEngine(vin, car.Model, pozLenCode[2]);
            //ищем особенности кузова
            car.Body = getBody(vin, car.firmId, pozLenCode[1]);
            //ище производителя машины
            car.Producter = getProducter(vin,car.firmId);
            int pozYear = 9;
            car.Year = extractYearFtomVIN(vin[pozYear]);
            
            return car;
        }

        public bool CorrectCHK(string vin)
        {
            int controlSum = 0, vinSum;
            if (vin[8] == 'x') vinSum = 10;
            else vinSum = int.Parse(vin[8].ToString());
            var equivalent = new Dictionary<char, int>();
            int k = 0;
            //генерация таблицы эквивалентных чисел
            for (var el = 'a'; el <= 'z'; el++, k++)
            {
                if (el != 'o' || el != 'q' || el != 'i')
                    if (el == 's') k++;
                equivalent.Add(el, k % 9 + 1);
            }
            //соответствующие коэффициенты
            var coef = new List<int> { 8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2 };
            for (int i = 0; i < vin.Length; i++)
            {
                if (i == 8) continue;
                if (vin[i] > '9') controlSum += equivalent[vin[i]] * coef[i];
                else controlSum += int.Parse(vin[i].ToString()) * coef[i];
            }
            return (controlSum - (controlSum / 11) * 11) == vinSum;
        }

        int extractYearFtomVIN(char yearCode)
        {
            List<char> alphabet = new List<char> { '1', '2' ,'3', '4', '5', '6', '7', '8', '9','a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j',
            'k', 'l', 'm', 'n', 'p', 'r', 's', 't', 'v', 'w', 'x', 'y'};
            //2001 = 1
            int index = alphabet.FindIndex(i => i == yearCode);
            if (index == -1) return 0;
            if (index > DateTime.Now.Year - 2000)
                return 2001 - (alphabet.Count - index);
            return 2001 + index;
        }

        int getFirmId(string WMI)
        {
            WMI = WMI.ToUpper();
            int id=0;
            using(VinCarDBEntities database = new VinCarDBEntities())
            {
                var firms = database.WMITable.Where(i => i.wmi.Replace(" ", "").Equals(WMI)).ToList();
                if (firms.Count!=0)
                    id = firms.FirstOrDefault().id_firm;                
            }
            return id;
        }

        string getFirmName(int idFirm)
        {
            string name=null;
            using (VinCarDBEntities database = new VinCarDBEntities())
            {
                var firms = database.firmTable.Where(i => i.id_firm.Equals(idFirm)).ToList(); ;
                if (firms.Count != 0)
                    name = firms.FirstOrDefault().firm_name;
            }
            return name;
        }

        string getModel(string vin, int idFirm, Point pozLen)
        {
            vin = vin.ToUpper();
            string code = vin.Substring(pozLen.X, pozLen.Y);
            string model = null;
            using (VinCarDBEntities database = new VinCarDBEntities())
            {
                //если производмтель колируется одним символом
                var prod = database.modelTable.Where(i => i.id_firm == idFirm && i.code.Replace(" ", "") == code).ToList();
                if (prod.Count!=0)
                    model = prod.FirstOrDefault().decrypte;
            }
            return model;
        }

        string getBody(string vin, int idFirm, Point pozLen)
        {
            vin = vin.ToUpper();
            string code = vin.Substring(pozLen.X, pozLen.Y);
            string body = null;
            using (VinCarDBEntities database = new VinCarDBEntities())
            {
                var prod = database.bodyTable.Where(i => i.id_firm == idFirm && i.code.Replace(" ", "") == code).ToList();
                if (prod.Count != 0)
                    body = prod.FirstOrDefault().decrypte;               
            }
            return body;
        }

        string getProducter(string vin, int idFirm)
        {
            string code = vin[10].ToString().ToUpper();
            string producter = null;
            using (VinCarDBEntities database = new VinCarDBEntities())
            {
                var finds = database.producterTable.Where(i => i.id_firm.Equals(idFirm) && i.code.Replace(" ", "") == code).ToList(); ;
                if (finds.Count!=0)
                    producter = finds.FirstOrDefault().decrypte;
            }
            return producter;
        }

        string getEngine(string vin, string modelname, Point pozLen)
        {
            modelname = modelname.ToUpper();
            string code = vin.Substring(pozLen.X, pozLen.Y).ToUpper();
            string engine = null;
            using (var database = new VinCarDBEntities())
            {
                var finds = database.engineTable.Where(i => i.model.ToUpper().Equals(modelname) && i.code.Replace(" ", "") == code) ;
                if (finds.Count() == 1 )
                    engine = finds.FirstOrDefault().decrypte;
            }
            return engine;
        }
        string getPozitionString(int idFirm)
        {
            string pozString = null;
            using (VinCarDBEntities database = new VinCarDBEntities())
            {
                var finds = database.firmTable.Where(i => i.id_firm == idFirm);
                if (finds.Count() == 1)
                    pozString = finds.FirstOrDefault().code_pizition;
            }
            return pozString;
        }
        Dictionary<int,Point> extractPozition(string box)
        {
            box = box.Replace(" ", "");
            string[] poz = box.Split(',');
            var rezult = new Dictionary<int, Point>();
            int i = 0;
            foreach (var item in poz)
            {
                if (item.Contains('+')) { 
                    string[] one = item.Split('+');
                    rezult.Add(i++,new Point(int.Parse(one.First())-1, int.Parse(one.Last())));
                }
                else rezult.Add(i++, new Point(int.Parse(item)-1, 1));
            }
            return rezult;
        }
    }
}
