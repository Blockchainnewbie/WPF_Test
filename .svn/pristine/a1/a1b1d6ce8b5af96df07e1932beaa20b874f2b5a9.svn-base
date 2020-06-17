using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen_anwendung_staudinger
{
    class Projekt
    {
        public int id { get; set; }
        public string name { get; set; }
        public int kunde_id { get; set; }
        public string ort { get; set; }
        public int pro_leit_ma_id { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }     
        public int deleted { get; set; }

        public Projekt()
        {
            this.id = 0;
            this.kunde_id = 0;
            this.pro_leit_ma_id = 0;
            this.start_date = "";
            this.end_date = "";
            this.name = "";
            this.ort = "";
            this.deleted = 0;
        }

        public Projekt(int in_id)
        {
            this.id = in_id;

            if (this.id == 0)
            {
                return;
            }
            string sql = "SELECT * FROM projekt WHERE id = " + in_id;
            IDataReader reader = MyDB.db_exec(sql);

            if (reader.Read() == true)
            {
                // übertragung der daten aus DB Result in klassen Variablen
                this.kunde_id = (int)(reader["kunde_id"]);
                this.pro_leit_ma_id = (int)(reader["pro_leit_ma_id"]);
                this.start_date = Tools.conv_mysql_date_2_string( reader , "start_date" );
                this.end_date = Tools.conv_mysql_date_2_string( reader , "end_date" );
                this.name = (string)reader["name"];
                this.ort = (string)reader["ort"];
                this.deleted = Int32.Parse(reader["deleted"].ToString());
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
            string sql = "INSERT INTO `projekt`" +
                " (`id`, `name`, `kunde_id`, `ort`, `pro_leit_ma_id`, `start_date`, `end_date`, `deleted`)" + "" +
                " VALUES ('', '" + this.name + "', '" + this.kunde_id + "', '" + this.ort + "', '" + this.pro_leit_ma_id + "', '" + this.start_date + "', '" + this.end_date + "', '"+this.deleted+"');";

            this.id = MyDB.db_insert_return_id(sql);
        }

        private void edit()
        {
            string sql = "UPDATE `projekt` SET" +
                          "`name` = '" + this.name + "'," +
                          " `kunde_id` = '" + this.kunde_id + "' , " +
                          " `ort` = '" + this.ort + "' , " +
                          " `pro_leit_ma_id` = '" + this.pro_leit_ma_id + "' , " +
                          " `start_date` = '" + this.start_date + "' , " +
                          " `end_date` = '" + this.end_date + "' , " +
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

        public static ArrayList getAll()
        {
            string sql = "SELECT * FROM projekt ";
            IDataReader reader = MyDB.db_exec(sql);

            ArrayList liste = new ArrayList();

            while (reader.Read() == true)
            {
                int id = (int)reader["id"];
                liste.Add(new Projekt(id));
            }

            return liste;
        }


    }
}
