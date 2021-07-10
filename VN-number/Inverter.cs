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
        public Car DecodeVIN( string vin)
        {
            Car car = new Car();
            //найдем есть ли такая машина если нет выводим неизвестно и заканчиваем
            int idFirm = GetFirmId(vin.Substring(0, 3));
            if (idFirm != 0)
                car.firmId = idFirm;
            else { car.UncnownCar(); return car; }
            //ищем в каком порядке и какой длинны коды
            // так же извлечем марку авто
            Dictionary<int, Point> pozLenCode = null;
            string pozitionString= null;
            (car.firmName, pozitionString) = GetFirmParams(car.firmId);
            // проврка есть ли данные для дальнейшей расшифровки
            if (pozitionString == null)
                return car;
            else pozLenCode = ExtractPozition(pozitionString);
            // ищем модель 
            car.Model = GetModel(vin, car.firmId,pozLenCode[0]);
            //знаяодель можем найти двигатель
            car.Engine = GetEngine(vin, car.Model, pozLenCode[2]);
            //ищем особенности кузова
            car.Body = GetBody(vin, car.firmId, pozLenCode[1]);
            //ище производителя машины
            car.Producter = GetProducter(vin,car.firmId);
            int pozYear = 9;
            car.Year = ExtractYearFtomVIN(vin[pozYear]);
            return car;
        }

        /// <summary>
        /// расчет правильности вин кода
        /// по соответствию с контрольной суммой
        /// </summary>
        /// <param name="vin">вин-код</param>
        /// <returns></returns>
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

        /// <summary>
        /// В соответствии с алфавитом для ассоциирования кода и года
        /// рассчитывает модельный год автомобиля
        /// </summary>
        /// <param name="yearCode">символ из vin кода</param>
        /// <returns></returns>
        int ExtractYearFtomVIN(char yearCode)
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

        int GetFirmId(string WMI)
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
        
        (string, string) GetFirmParams(int idFirm)
        {
            string name=null;
            string pozString = null;
            using (VinCarDBEntities database = new VinCarDBEntities())
            {
                var firms = database.firmTable.Where(i => i.id_firm.Equals(idFirm)).ToList(); ;
                if (firms.Count != 0)
                {
                    name = firms.FirstOrDefault().firm_name;
                    pozString = firms.FirstOrDefault().code_pizition;
                }
                }
            return (name, pozString);
        }

        string GetModel(string vin, int idFirm, Point pozLen)
        {
            string code = vin.Substring(pozLen.X, pozLen.Y).ToUpper();
            string model = null;
            using (VinCarDBEntities database = new VinCarDBEntities())
            {
                var prod = database.modelTable.Where(i => i.id_firm == idFirm && i.code.Replace(" ", "") == code).ToList();
                if (prod.Count!=0)
                    model = prod.FirstOrDefault().decrypte;
            }
            return model;
        }

        string GetBody(string vin, int idFirm, Point pozLen)
        {
            string code = vin.Substring(pozLen.X, pozLen.Y).ToUpper();
            string body = null;
            using (VinCarDBEntities database = new VinCarDBEntities())
            {
                var prod = database.bodyTable.Where(i => i.id_firm == idFirm && i.code.Replace(" ", "") == code).ToList();
                if (prod.Count != 0)
                    body = prod.FirstOrDefault().decrypte;               
            }
            return body;
        }

        string GetProducter(string vin, int idFirm)
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

        string GetEngine(string vin, string modelname, Point pozLen)
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
       
        /// <summary>
        /// Извлекает из получанной строки положение кодов 
        /// параметров в вин-еоде а так же длинну кода
        /// </summary>
        /// <param name="box">строка в которой находятся данные о длинне и позиции кодов параметров</param>
        /// <returns></returns>
        Dictionary<int,Point> ExtractPozition(string box)
        {
            string[] poz = box.Replace(" ", "").Split(',');
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
