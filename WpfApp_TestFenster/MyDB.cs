
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen_anwendung_staudinger
{
    class MyDB
    {
       private static string Connectionstring = "server=127.0.0.1;user id=root;password=;port=3306;database=staudinger;SslMode=Preferred; Allow Zero Datetime = true"; //SslMode=Preferred

        public static IDataReader db_exec(String abfrage)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(Connectionstring);
            mySqlConnection.Open();

            MySqlCommand command = mySqlConnection.CreateCommand();
            command.CommandText = abfrage;

            IDataReader reader = command.ExecuteReader();

            return reader;
        }

        public static int db_insert_return_id(String abfrage)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(Connectionstring);
            mySqlConnection.Open();

            MySqlCommand command = mySqlConnection.CreateCommand();
            command.CommandText = abfrage;
            command.ExecuteNonQuery();

            long insert_id = command.LastInsertedId;

            return (int)insert_id;
        }

        public static int db_update_return_eff_rows(String abfrage)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(Connectionstring);
            mySqlConnection.Open();

            MySqlCommand command = mySqlConnection.CreateCommand();
            command.CommandText = abfrage;

            long eff_rows = command.ExecuteNonQuery();

            return (int)eff_rows;
        }
    }
}
