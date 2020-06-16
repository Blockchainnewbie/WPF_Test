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
            IDataReader reader = MyDB.db_exec(sql);

            if (reader.Read() == true)
            {
                // übertragung der daten aus DB Result in klassen Variablen
                this.text = (string)reader["text"];
                this.rel_tab = (string)reader["rel_tab"];
                this.rel_id = (int)(reader["rel_id"]);
                this.deleted = Int32.Parse(reader["deleted"].ToString());
                this.datum = Tools.conv_mysql_datetime_2_string(reader , "datum" );
                this.benutzer_id = (int)reader["benutzer_id"];              
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
            string sql = "SELECT * FROM bemerkung ";
            IDataReader reader = MyDB.db_exec(sql);

            ArrayList liste = new ArrayList();

            while (reader.Read() == true)
            {
                int id = (int)reader["id"];
                liste.Add(new Bemerkung(id));
            }

            return liste;
        }

    }
}
