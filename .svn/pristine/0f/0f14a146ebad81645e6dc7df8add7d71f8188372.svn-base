using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen_anwendung_staudinger
{
    class Bemerkung
    {
        public int id { get; set; }
        public string text { get; set; }
        public string rel_tab { get; set; }
        public int rel_id { get; set; }
        public int deleted { get; set; }
        public string datum { get; set; }
        public int benutzer_id { get; set; }

        public Bemerkung()
        {
            this.id = 0;
            this.text = "";
            this.rel_tab = "";
            this.rel_id = 0;
            this.deleted = 0;
            this.datum = "";
            this.benutzer_id = 0;
        }

        public Bemerkung(int in_id)
        {
            this.id = in_id;

            if (this.id == 0)
            {
                return;
            }
            string sql = "SELECT * FROM bemerkung WHERE id = " + in_id;
            
            List<Dictionary<string, string>> data = MyDB.db_exec(sql);

            if (data.Count > 0 )
            {
                Dictionary<string, string> reader = data[0];
                // übertragung der daten aus DB Result in klassen Variablen
                this.text = reader["text"];
                this.rel_tab = reader["rel_tab"];
                this.rel_id = Int32.Parse(reader["rel_id"]);
                this.deleted = Int32.Parse(reader["deleted"]);
                this.datum = reader [ "datum"  ];
                this.benutzer_id = Int32.Parse( reader["benutzer_id"] );              
            }
            else
            {
                this.id = 0;
                Console.WriteLine("This ID doesn`t exist");
            }
          
        }

        private void neu()
        {
            string sql = "INSERT INTO `bemerkung`" +
                " ( `id`, `text`             , `rel_tab`             , `rel_id`             , `deleted`             , `datum`             , `benutzer_id`)" + "" +
                " VALUES " +
                "( ''   , '" + this.text + "', '" + this.rel_tab + "', '" + this.rel_id + "', '" + this.deleted + "', '" + this.datum + "', '" + this.benutzer_id + "');";
            
            //Console.WriteLine(sql);

            this.id = MyDB.db_insert_return_id(sql);
        }

        private void edit()
        {
            string sql = "UPDATE `bemerkung` SET" +
                          "`text` = '" + this.text + "'," +
                          " `rel_tab` = '" + this.rel_tab + "' , " +
                          " `rel_id` = '" + this.rel_id + "' , " +
                          " `deleted` = '" + this.deleted + "' , " +
                          " `datum` = '" + this.datum + "' , " +
                          " `benutzer_id` = '" + this.benutzer_id + "' " +
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

        public static ArrayList getAll()
        {
            string sql = "SELECT id FROM bemerkung ";
            List<Dictionary<string, string>> data = MyDB.db_exec(sql);

            ArrayList liste = new ArrayList();

            for (int x = 0; x < data.Count; x++)
            {
                Dictionary<string, string> tmp_data = data[x];

                int id = Int32.Parse(tmp_data["id"]);

                liste.Add(new Bemerkung  (id));
            }

            return liste;
        }

    }
}
