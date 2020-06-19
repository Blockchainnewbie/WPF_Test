using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen_anwendung_staudinger
{
    class Mitarbeiter
    {
        public int id { get; set; }
        public string vorname { get; set; }
        public string nachname { get; set; }
        public int anrede { get; set; }
        public string strasse { get; set; }
        public string hsnr { get; set; }
        public string plz { get; set; }
        public string ort { get; set; }
        public string land { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public string persnr { get; set; }
        public int firmen_id { get; set; }
        public int deleted { get; set; }
        public int funktion { get; set; }

        public Mitarbeiter()
        {
            this.id = 0;
            this.vorname = "";
            this.nachname = "";
            this.anrede = 0;
            this.strasse = "";
            this.hsnr = "";
            this.plz = "";
            this.ort = "";
            this.land = "";
            this.tel = "";
            this.email = "";
            this.persnr = "";
            this.firmen_id = 0;
            this.deleted = 0;
            this.funktion = 0;
        }

        public Mitarbeiter(int in_id)
        {
            this.id = in_id;

            if (this.id == 0)
            {
                return;
            }
            string sql = "SELECT * FROM mitarbeiter WHERE id = " + in_id;
            List<Dictionary<string, string>> data = MyDB.db_exec(sql);

            if (data.Count > 0)
            {
                Dictionary<string, string> reader = data[0];
                // übertragung der daten aus DB Result in klassen Variablen
                this.vorname = reader["vorname"];
                this.nachname = reader["nachname"];
                this.anrede = Int32.Parse(reader["anrede"].ToString());
                this.strasse = reader["strasse"];
                this.hsnr = reader["hsnr"];
                this.plz = reader["plz"];
                this.ort = reader["ort"];
                this.land = reader["land"];
                this.tel = reader["tel"];
                this.email = reader["email"];
                this.persnr = reader["persnr"];
                this.firmen_id = Int32.Parse(reader["firmen_id"]);
                this.deleted = Int32.Parse(reader["deleted"].ToString());
                this.funktion = Int32.Parse(reader["funktion"].ToString());                              
            }
            else
            {
                this.id = 0;
                Console.WriteLine("This ID is not exsit");
            }
            
        }

        private void neu()
        {
            string sql = "INSERT INTO `mitarbeiter`" +
                " (`id`, `vorname`             , `nachname`             , `anrede`             , `strasse`             , `hsnr`             , `plz`             , `ort`             , `land`             , `tel`             ,`email`              ,`persnr`              , `firmen_id`             , `deleted`             , `funktion`)" + "" +
                " VALUES " +
                "(   '', '" + this.vorname + "', '" + this.nachname + "', '" + this.anrede + "', '" + this.strasse + "', '" + this.hsnr + "', '" + this.plz + "', '" + this.ort + "', '" + this.land + "', '" + this.tel + "', '" + this.email + "', '" + this.persnr + "', '" + this.firmen_id + "', '" + this.deleted + "', '" + this.funktion + "' );";

            this.id = MyDB.db_insert_return_id(sql);
        }

        private void edit()
        {
            string sql = "UPDATE `mitarbeiter` SET" +
                          "`vorname` = '" + this.vorname + "'," +
                          "`nachname` = '" + this.nachname + "'," +
                          "`anrede` = '" + this.anrede + "'," +
                          " `strasse` = '" + this.strasse + "' , " +
                          " `hsnr` = '" + this.hsnr + "' , " +
                          " `plz` = '" + this.plz + "' , " +
                          " `ort` = '" + this.ort + "' , " +
                          " `land` = '" + this.land + "' , " +
                          " `tel` = '" + this.tel + "' , " +
                          " `email` = '" + this.email + "' , " +
                          " `persnr` = '" + this.persnr + "' , " +
                          " `firmen_id` = '" + this.firmen_id + "' , " +
                          " `deleted` = '" + this.deleted + "' , " +
                          " `funktion` = '" + this.funktion + "'  " +
                          "WHERE" +
                          " `id` = " + this.id + ";";

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

        public static ArrayList getAll()
        {
            string sql = "SELECT id FROM mitarbeiter WHERE deleted='0'";
            List<Dictionary<string, string>> data = MyDB.db_exec(sql);

            ArrayList liste = new ArrayList();

            for (int x = 0; x < data.Count; x++)
            {
                Dictionary<string, string> tmp_data = data[x];

                int id = Int32.Parse(tmp_data["id"]);

                liste.Add(new Mitarbeiter(id));
            }
            return liste;
        }
        public override string ToString()
        {
            return this.vorname + " " + this.nachname;
        }
    }
}
