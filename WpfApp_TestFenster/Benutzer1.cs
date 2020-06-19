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
    class Benutzer1
    {
        public int id { get; set; }
        public string vorname { get; set; }
        public string nachname { get; set; }
        public int typ { get; set; }
        public string email { get; set; }
        private string passwort { get; set; }
        public int deleted { get; set; }

        public Benutzer1()
        {
            this.id = 0;
            this.vorname = "";
            this.nachname = "";
            this.typ = 0;
            this.email = "";
            this.passwort = "";
            this.deleted = 0;
        }

        public Benutzer1(int in_id)
        {
            this.id = in_id;

            if (this.id == 0)
            {
                return;
            }
            string sql = "SELECT * FROM benutzer WHERE id = " + in_id;
            List<Dictionary<string, string>> data = MyDB.db_exec(sql);

            if (data.Count > 0 )
            {
                Dictionary<string, string> reader = data[0];
                // übertragung der daten aus DB Result in klassen Variablen
                this.vorname    = reader["vorname"];
                this.nachname   = reader["nachname"];
                this.typ        = Int32.Parse(reader["typ"]);
                this.email      = reader["email"];
                this.passwort   = reader["passwort"];
                this.deleted    = Int32.Parse(reader["deleted"]);
            }
            else
            {
                this.id = 0;
                Console.WriteLine("This ID does not exist");
            }
          
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
            string sql = "SELECT id FROM benutzer WHERE deleted ='0'";
            List<Dictionary<string, string>> data = MyDB.db_exec(sql);

            ArrayList liste = new ArrayList();

            for (int x = 0; x < data.Count; x++)
            {
                Dictionary<string, string> tmp_data = data[x];

                int id = Int32.Parse(tmp_data["id"]);

                liste.Add(new Benutzer1(id));
            }
            return liste;
        }

        public override string ToString()
        {
            return this.nachname + " " + this.vorname;
        }
    }
}
