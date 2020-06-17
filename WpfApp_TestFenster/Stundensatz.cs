using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen_anwendung_staudinger
{
    class Stundensatz
    {
        public int id { get; set; }
        public int ma_id { get; set; }
        public int faeihg_id { get; set; }
        public string ort { get; set; }
        public float euro { get; set; }
        public int deleted { get; set; }

        public Stundensatz()
        {
            this.id = 0;
            this.ma_id = 0;
            this.faeihg_id = 0;
            this.ort = "";
            this.euro = 0.0f;
            this.deleted = 0;
        }

        public Stundensatz(int in_id)
        {
            this.id = in_id;

            if (this.id == 0)
            {
                return;
            }

            string sql = "SELECT * FROM stundensatz WHERE id = " + in_id;
            List<Dictionary<string, string>> data = MyDB.db_exec(sql);

            if (data.Count > 0)
            {
                Dictionary<string, string> reader = data[0];
                this.ma_id = Int32.Parse(reader["ma_id"]);
                this.faeihg_id = Int32.Parse(reader["faeihg_id"]);
                this.ort = reader["ort"];
                this.euro = float.Parse( reader["euro"] );
                this.deleted = Int32.Parse(reader["deleted"].ToString());
            }
            else
            {
                this.id = 0;
            }

        
        }

        public void neu()
        {
            string sql = "INSERT INTO `stundensatz`" +
                " (`id`, `ma_id`, `faeihg_id`, `ort`, `euro`, `deleted`)" +
                " VALUES (NULL, '"+ this.ma_id + "', '" + this.faeihg_id + "', '" + this.ort + "', '" + Tools.mensch2computer( this.euro.ToString() ) + "', '" + this.deleted + "');";

            this.id = MyDB.db_insert_return_id(sql);
        }

        public void edit()
        {
            string sql = "UPDATE `stundensatz` SET" +
                " `ma_id` = '"+this.ma_id+"',"+
                " `faeihg_id` = '" + this.faeihg_id + "'," +
                " `ort` = '" + this.ort + "', " +
                " `euro` = '" + Tools.mensch2computer( this.euro.ToString() ) + "' , " +
                " `deleted` = '" + this.deleted + "' " +
                "WHERE" +
                " `stundensatz`.`id` = "+this.id+";";

            Console.WriteLine( sql );

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
            string sql = "SELECT id FROM stundensatz ";
            List<Dictionary<string, string>> data = MyDB.db_exec(sql);

            ArrayList liste = new ArrayList();

            for (int x = 0; x < data.Count; x++)
            {
                Dictionary<string, string> tmp_data = data[x];

                int id = Int32.Parse(tmp_data["id"]);

                liste.Add(new Stundensatz(id));
            }
            return liste;
        }

    }
}
