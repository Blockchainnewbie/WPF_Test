using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen_anwendung_staudinger
{
    class Einsatz
    {
        public int id { get; set; }
        public int bau_id { get; set; }
        public int ma_id { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public int forecast { get; set; }      
        public int deleted { get; set; }

        public Einsatz()
        {
            this.id = 0;
            this.bau_id = 0;
            this.ma_id = 0;
            this.start_date = "";
            this.end_date = "";
            this.deleted = 0;
        }

        public Einsatz(int in_id)
        {
            this.id = in_id;

            if (this.id == 0)
            {
                return;
            }
            string sql = "SELECT * FROM einsatz WHERE id = " + in_id;
            List<Dictionary<string, string>> data = MyDB.db_exec(sql);

            if (data.Count > 0)
            {
                Dictionary<string, string> reader = data[0];
                // übertragung der daten aus DB Result in klassen Variablen
                this.start_date = reader [ "start_date"];
                this.end_date = reader [ "end_date" ] ;
                this.bau_id = Int32.Parse(reader["bau_id"]);
                this.ma_id = Int32.Parse(reader["ma_id"]);
                this.forecast = Int32.Parse(reader["forecast"].ToString());
                this.deleted = Int32.Parse(reader["deleted"].ToString());

            }
            else
            {
                this.id = 0;
                Console.WriteLine("This ID is not exsit");
            }
        }

        private void neu()
        {
            string sql = "INSERT INTO `einsatz`" +
                " (`id`, `bau_id`, `ma_id`, `start_date`, `end_date`, `deleted`, `forecast`)" + "" +
                " VALUES ('', '" + this.bau_id + "', '" + this.ma_id + "', '" + this.start_date + "', '" + this.end_date + "', '" + this.deleted + "', '" + this.forecast + "');";

            this.id = MyDB.db_insert_return_id(sql);
        }

        private void edit()
        {
            string sql = "UPDATE `einsatz` SET" +
                          "`bau_id` = '" + this.bau_id + "'," +
                          " `ma_id` = '" + this.ma_id + "' , " +
                          " `start_date` = '" + this.start_date + "' , " +
                          " `end_date` = '" + this.end_date + "' , " +
                          " `deleted` = '" + this.deleted + "' , " +
                          " `forecast` = '" + this.forecast + "'  " +                
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
            string sql = "SELECT id FROM einsatz ";
            List<Dictionary<string, string>> data = MyDB.db_exec(sql);

            ArrayList liste = new ArrayList();

            for (int x = 0; x < data.Count; x++)
            {
                Dictionary<string, string> tmp_data = data[x];

                int id = Int32.Parse(tmp_data["id"]);

                liste.Add(new Einsatz(id));
            }

            return liste;
        }
        public override string ToString()
        {
            return this.id + " \t " + this.bau_id;
        }

    }
}
