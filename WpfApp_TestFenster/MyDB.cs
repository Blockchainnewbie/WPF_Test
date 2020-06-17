
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
        public static IDataReader reader = null;
       private static string Connectionstring = "server=127.0.0.1;user id=root;password=;port=3306;database=staudinger;SslMode=Preferred; Allow Zero Datetime = true"; //SslMode=Preferred

        private static MySqlConnection mySqlConnection = null;

        public static void checkConnection()
        {
            if( mySqlConnection == null )
            {
                mySqlConnection = new MySqlConnection(Connectionstring);
                mySqlConnection.Open();
            }
        }

        public static List<Dictionary<string, string >> db_exec(String abfrage)
        {
            checkConnection();

            MySqlCommand command = mySqlConnection.CreateCommand();
            command.CommandText = abfrage;

            reader = command.ExecuteReader();

            List<Dictionary<string, string>> tmp = Tools.iReader2dict(reader);

            reader.Close();
            reader.Close();
            return tmp;
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
