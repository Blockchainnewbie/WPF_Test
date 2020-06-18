using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen_anwendung_staudinger
{
    class Datei
    {
        public int id { get; set; }
        public string rel_tab { get; set; }
        public int rel_id { get; set; }
        public string org_name { get; set; }
        public string gen_name { get; set; }
        public int deleted { get; set; }
        public string datum { get; set; }

        public Datei()
        {
            this.id = 0;
            this.rel_tab = "";
            this.rel_id = 0;
            this.org_name = "";
            this.gen_name = "";
            this.datum = "";
            this.deleted = 0;
        }

        public Datei(int in_id)
        {
            this.id = in_id;

            if (this.id == 0)
            {
                return;
            }
            string sql = "SELECT * FROM datei WHERE id = " + in_id;
            List<Dictionary<string, string>> data = MyDB.db_exec(sql);

            if ( data.Count > 0 )
            {
                Dictionary<string, string> reader = data[0];
                // übertragung der daten aus DB Result in klassen Variablen
                this.rel_tab = reader["rel_tab"];
                this.rel_id  = Int32.Parse(reader["rel_id"]);
                this.org_name = (reader["org_name"]);
                this.gen_name = (reader["gen_name"]);
                this.deleted = Int32.Parse(reader["deleted"].ToString());
                this.datum = reader [ "datum" ];
            }
            else
            {
                this.id = 0;
                Console.WriteLine("This ID is not exsit");
            }
         
        }

        private void neu()
        {
            string sql = "INSERT INTO `datei`" +
                " (`id`, `rel_tab`, `rel_id`, `org_name`, `gen_name`, `deleted`, `datum`)" + "" +
                " VALUES ('', '" + this.rel_tab + "', '" + this.rel_id + "', '" + this.org_name + "', '" + this.gen_name + "', '" + this.deleted + "', '" + this.datum + "');";

            this.id = MyDB.db_insert_return_id(sql);
        }

        private void edit()
        {
            string sql = "UPDATE `datei` SET" +
                          "`rel_tab` = '" + this.rel_tab + "'," +
                          " `rel_id` = '" + this.rel_id + "' , " +
                          " `org_name` = '" + this.org_name + "' , " +
                          " `gen_name` = '" + this.gen_name + "' , " +
                          " `deleted` = '" + this.deleted + "' , " +
                          " `datum` = '" + this.datum + "'  " +
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
            string sql = "SELECT id FROM datei ";
            List<Dictionary<string, string>> data = MyDB.db_exec(sql);

            ArrayList liste = new ArrayList();

            for (int x = 0; x < data.Count; x++)
            {
                Dictionary<string, string> tmp_data = data[x];

                int id = Int32.Parse(tmp_data["id"]);

                liste.Add(new Datei(id));
            }

            return liste;
        }

    }
}
