using MySql.Data.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace klassen_anwendung_staudinger
{
    class Tools
    {

        public static string conv_mysql_date_2_string(IDataReader reader, string feld)
        {
            MySqlDateTime ob = (MySqlDateTime)reader.GetValue(reader.GetOrdinal(feld));

            string ausgabe = "";

            if (ob.Year < 1)
                ausgabe = "0000-00-00";
            else
                ausgabe = ob.GetDateTime().ToString("yyyy-MM-dd");

            return ausgabe;
        }

        public static string conv_mysql_datetime_2_string(IDataReader reader, string feld)
        {
            MySqlDateTime ob = (MySqlDateTime)reader.GetValue(reader.GetOrdinal(feld));

            string ausgabe = "";

            if (ob.Year < 1)
                ausgabe = "0000-00-00 00:00:00";
            else
                ausgabe = ob.GetDateTime().ToString("yyyy-MM-dd HH:mm:ss");

            return ausgabe;
        }


        public static string makeSHA256(string wert)
        {
            string resultat = "";

            SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(wert));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            resultat = builder.ToString();

            return resultat;
        }


        public static string mensch2computer(string inwert)
        {
            //12.456,23
            inwert = inwert.Replace(".", "");
            inwert = inwert.Replace(",", ".");

            return inwert;
        }

        public static string computer2mensch(string inwert)
        {
            //12.456,23
            inwert = inwert.Replace(".", ",");

            return inwert;
        }
        // Key    , Value
        // data["id"] = 1
        public static List<Dictionary<string, string>> iReader2dict(IDataReader reader)
        {
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();

            // hat der Datareader Zeilen
            while (reader.Read())
            {
                Dictionary<string, string> tmp = new Dictionary<string, string>();
                //in jeder Zeile
                // für alle Felder die Werte auslesen
                for (int f = 0; f < reader.FieldCount; f++)
                {
                    string feldname = reader.GetName(f);
                    string wert = reader[feldname].ToString();
                    tmp.Add(feldname, wert);
                }
                data.Add(tmp);
            }

            return data;
        }
    }
}
        // alle Zeilen nacheinander durchlaufen
        // in jeder Zeile
        // für alle felder die werte auslesen
        


        
    

