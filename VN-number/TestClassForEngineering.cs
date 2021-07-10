using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace VN_number
{
    public class TestClassForEngineering
    {
        public static int getFirmIdADO(string WMI)
        {
            //строка подключения
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VinCarDB.mdf;Integrated Security=True;Connect Timeout=30";
            var id = 0;
            // Создание подключения
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //запрос
                string sqlExpression = "SELECT id_firm FROM WMITable WHERE wmi = '" + WMI+"'";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    if (reader.Read()) // считываем данные                    
                         id = (int)reader.GetValue(0);                      
                }
                reader.Close();
            }
            return id;
        }

        public static void CRUDproducter()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;"
                                      + @"AttachDbFilename=|DataDirectory|\VinCarDB.mdf;Integrated Security=True;Connect Timeout=30";

            //изменение данных           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "UPDATE producterTable SET id_firm=10 WHERE id_prod=1";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

            }

            //удаление записи из таблицы 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "DELETE  FROM producterTable WHERE id_prod=1";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

            }

            //добавление данных в таблицу        
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "INSERT INTO producterTable (id_prod, id_firm, code, decrypte) VALUES (1 , 1, '2', 'Russelheim, Германия')";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
            }
        }
    }
}
