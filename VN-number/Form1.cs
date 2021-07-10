using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VN_number
{
    public partial class Form1 : Form
    {
        Inverter model;
        public Form1()
        {
            model = new Inverter();
            InitializeComponent();
        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            string vin = VINMaskedTextBox.Text.ToLower();
            if (vin.Length != 17) 
                statusLabel.Text = "VIN-код должен содержать 17 символов";
            else
            {
                if (vin.Contains("i") || vin.Contains("o") || vin.Contains("q"))
                    statusLabel.Text = "Не верно введен VIN-код (не должно присудствовать символов: I,O,Q)";
                else
                {
                    statusLabel.Text = "Производится рассчет.";
                    try
                    {

                        ViewInfomation(model.DecodeVIN(vin));
                    }
                    catch (Exception)
                    {
                        statusLabel.Text = "Произошла ошибка получения данных.";
                    }
                }
            }
        }
        /// <summary>
        /// Выводит на форму результат расщифровки
        /// </summary>
        /// <param name="car">объект машины</param>
        private void ViewInfomation(Car car)
        {
            carYearTextBox.Text = car.Year.ToString()=="0"?"--": car.Year.ToString();
            carFirmTextBox.Text = car.FirmName.ToString();
            carModelTextBox.Text = car.Model.ToString();
            carProducterLabel.Text = car.Producter.ToString();
            carBodyLabel.Text = car.Body.ToString();
            carEngineLabel.Text = car.Engine.ToString();
            statusLabel.Text = "";
        }

        private void VINMaskedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                decodeButton_Click(sender, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
