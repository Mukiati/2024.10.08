using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace _2024._10._08
{
    public class databasehandler
    {
        MySqlConnection connection;
        string tablename = "autok";
        public databasehandler()
        {
            string host = "localhost";
            string dbname = "auto";
            string passw = "";
            string username = "root";
            string connectionstring = $"database ={dbname};username ={username};password={passw};host={host}";

            connection = new MySqlConnection(connectionstring);
        }
        public void Readall()
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM {tablename}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    car onecar = new car();
                    onecar.id = read.GetInt32(read.GetOrdinal("id"));
                    onecar.name = read.GetString(read.GetOrdinal("nev"));
                    onecar.hp = read.GetInt32(read.GetOrdinal("power"));

                    car.cars.Add(onecar);

                }
                MessageBox.Show("sikeres beolvasás");
                read.Close();
                command.Dispose();
                connection.Close();
        
            }
            catch (Exception e)
            {

                MessageBox.Show("A Hiba :" + e.Message);
            }
        }
       public  void delete(car onecar)
        {
            try
            {
                connection.Open();
                string query = $"DELETE FROM `{tablename}` WHERE id = {onecar.id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();
                MessageBox.Show("sikeres törlés");
            }
            catch (Exception e)
            {

                MessageBox.Show("A Hiba : " + e.Message);
            }
        }
        public void deleteall()
        {
            try
            {
                connection.Open();
                string query = $"DELETE FROM `{tablename}`";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();
                MessageBox.Show("sikeres törlés");
            }
            catch (Exception e)
            {

                MessageBox.Show("A Hiba : " + e.Message);
            }
        }
        public void insert(car onecar)
        {
            try
            {
                connection.Open();
                string query = $"INSERT INTO `{tablename}`( `nev`, `power`) VALUES ('{onecar.name}',{onecar.hp})";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();
                MessageBox.Show("sikeres hozzáadás");
            }
            catch (Exception e)
            {

                MessageBox.Show("A Hiba : " + e.Message);
            }
        }
    }
}
