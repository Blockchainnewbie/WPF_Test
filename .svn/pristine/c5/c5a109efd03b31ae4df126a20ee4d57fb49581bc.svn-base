using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen_anwendung_staudinger
{
    class Kunde
    {

        public int id { get; set; }
        public string name { get; set; }
        public string strasse { get; set; }
        public string hsnr { get; set; }
        public string plz { get; set; }
        public string ort { get; set; }
        public string land { get; set; }
        public int deleted { get; set; }

        public Kunde()
        {
            this.id = 0;
            this.name = "";
            this.strasse = "";
            this.hsnr = "";
            this.plz = "";
            this.ort = "";
            this.land = "";
            this.deleted = 0;
        }

        public Kunde(int in_id)
        {
            this.id = in_id;

            if (this.id == 0)
            {
                return;
            }
            string sql = "SELECT * FROM kunde WHERE id = " + in_id;
            List<Dictionary<string, string>> data = MyDB.db_exec(sql);

            if (data.Count > 0)
            {
                Dictionary<string, string> reader = data[0];
                // übertragung der daten aus DB Result in klassen Variablen
                this.name = reader["name"];
                this.deleted = Int32.Parse(reader["deleted"].ToString());
                this.strasse = reader["strasse"];
                this.hsnr = reader["hsnr"];
                this.plz = reader["plz"];
                this.ort = reader["ort"];
                this.land = reader["land"];
            }
            else
            {
                this.id = 0;
                Console.WriteLine("This ID is not exist");
            }
           
        }

        private void neu()
        {
            string sql = "INSERT INTO `kunde`" +
                " (`id`, `name`, `strasse`, `hsnr`, `plz`, `ort`, `land`, `deleted`)" + "" +
                " VALUES ('', '" + this.name + "', '" + this.strasse + "', '" + this.hsnr + "', '" + this.plz + "', '" + this.ort + "', '" + this.land + "', '" + this.deleted + "');";

            this.id = MyDB.db_insert_return_id(sql);
        }

        private void edit()
        {
            string sql = "UPDATE `kunde` SET" +
                          "`name` = '" + this.name + "'," +
                          " `strasse` = '" + this.strasse + "' , " +
                          " `hsnr` = '" + this.hsnr + "' , " +
                          " `plz` = '" + this.plz + "' , " +
                          " `ort` = '" + this.ort + "' , " +
                          " `land` = '" + this.land + "' , " +
                          " `deleted` = '" + this.deleted + "' " +
                          "WHERE " +
                          "`id` = " + this.id + ";";

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
            string sql =    "SELECT id FROM kunde "+
                            "WHERE " +
                            "deleted = 0 " +
                            "ORDER BY name ";

            List<Dictionary<string, string>> data = MyDB.db_exec(sql);

            ArrayList liste = new ArrayList();

            for (int x = 0; x < data.Count; x++)
            {
                Dictionary<string, string> tmp_data = data[x];

                int id = Int32.Parse(tmp_data["id"]);

                liste.Add(new Kunde(id));
            }

            return liste;
        }

        // Zeigt die Datenbank Spalten Namen in der Listbox, ansonsten würde nur der Klassenname erscheinen
        public override string ToString()
        {
            return this.name +" \t "+ this.strasse +" \t "+ this.hsnr +" \t "+ this.plz +" \t "+ this.ort +" \t "+ this.land;
            
        }
    }
}
