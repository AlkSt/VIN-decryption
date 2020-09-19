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
        Controller control;
        public Form1()
        {
            control = new Controller();
            InitializeComponent();
        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            string vin = VINMaskedTextBox.Text.ToLower();
            if (vin.Length != 17) MessageBox.Show("VIN-код должен содержать 17 символов");
            else { 
            if (vin.Contains("i") || vin.Contains("o") || vin.Contains("q"))
                wrongLabel.Text = "Не верно введен VIN-код (не должно присудствовать символов: I,O,Q)";
            else
            {
                    wrongLabel.Text = "Производится рассчет.";
                //if (control.Correct(vin)) { wrongLabel.Text = " Введен коррекный VIN-код";
                //}
                //else wrongLabel.Text = "(CHK не совпадает)";
                    ViewInfomation(control.getAllInformation(vin));
                }
            }
        }

        private void ViewInfomation(Car car)
        {
            carYearLabel.Text = car.Year.ToString()=="0"?"--": car.Year.ToString();
            carFirmLabel.Text = car.firmName.ToString();
            carModelLable.Text = car.Model.ToString();
            carProducterLabel.Text = car.Producter.ToString();
            carBodyLabel.Text = car.Body.ToString();
            carEngineLabel.Text = car.Engine.ToString();
            wrongLabel.Text = "";
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
