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
    class Benutzer
    {
        public int id { get; set; }
        public string vorname { get; set; }
        public string nachname { get; set; }
        public int typ { get; set; }
        public string email { get; set; }
        private string passwort { get; set; }
        public int deleted { get; set; }

        public Benutzer()
        {
            this.id = 0;
            this.vorname = "";
            this.nachname = "";
            this.typ = 0;
            this.email = "";
            this.passwort = "";
            this.deleted = 0;
        }

        public Benutzer(int in_id)
        {
            this.id = in_id;

            if (this.id == 0)
            {
                return;
            }
            string sql = "SELECT * FROM benutzer WHERE id = " + in_id;
            IDataReader reader = MyDB.db_exec(sql);

            if (reader.Read() == true)
            {
                // übertragung der daten aus DB Result in klassen Variablen
                this.vorname    = (string)reader["vorname"];
                this.nachname   = (string)reader["nachname"];
                this.typ        = Int32.Parse(reader["typ"].ToString());
                this.email      = (string)(reader["email"]);
                this.passwort   = (string)reader["passwort"];
                this.deleted    = Int32.Parse(reader["deleted"].ToString());
            }
            else
            {
                this.id = 0;
                Console.WriteLine("This ID is not exsit");
            }
            reader.Close();
        }

        private void neu()
        {
            string sql = "INSERT INTO `benutzer`" +
                " (`id`, `vorname`, `nachname`, `typ`, `email`, `passwort`, `deleted`)" + "" +
                " VALUES " +
                "('', '" + this.vorname + "', '" + this.nachname + "', '" + this.typ + "', '" + this.email + "', '" + this.passwort + "', '" + this.deleted + "');";

            this.id = MyDB.db_insert_return_id(sql);
        }

        private void edit()
        {
            string sql = "UPDATE `benutzer` SET" +
                          "`vorname` = '" + this.vorname + "'," +
                          " `nachname` = '" + this.nachname + "' , " +
                          " `typ` = '" + this.typ + "' , " +
                          " `email` = '" + this.email + "' , " +
                          " `passwort` = '" + this.passwort + "' , " +
                          " `deleted` = '" + this.deleted + "' " +
                          "WHERE `id` = " + this.id + ";";

            int eff_rows = MyDB.db_update_return_eff_rows(sql);
        }

        public void save()
        {
            if (this.id == 0)
            {
                this.neu();
            }
            else
            {
                this.edit();
            }
        }

        public void delete()
        {
            this.deleted = 1;
            this.save();
        }

        public void setPasswort( string new_pass )
        {
           this.passwort = Tools.makeSHA256(new_pass);
        }

        public static ArrayList getAll()
        {
            string sql = "SELECT * FROM benutzer ";
            IDataReader reader = MyDB.db_exec(sql);

            ArrayList liste = new ArrayList();

            while (reader.Read() == true)
            {
                int id = (int)reader["id"];
                liste.Add(new Benutzer(id));
            }

            return liste;
        }
    }
}
