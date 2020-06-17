
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen_anwendung_staudinger
{
    class Faehigkeit
    {
        public int id { get; set; }
        public string name { get; set; }
        public int deleted { get; set; }

        public Faehigkeit()
        {
            this.id = 0;
            this.name = "";
            this.deleted = 0;
        }

        public Faehigkeit( int in_id )
        {
            this.id = in_id;

            if(this.id == 0)
            {
                return;
            }
            string sql = "SELECT * FROM faehigkeit WHERE id = " + in_id;
            List<Dictionary<string, string>> data =  MyDB.db_exec(sql);

            if( data.Count > 0 )
            {
                Dictionary<string, string> reader = data[0];
                // übertragung der daten aus DB Result in klassen Variablen
                this.name = reader["name"];
                this.deleted = Int32.Parse(reader["deleted"]);
            }
            else
            {
                this.id = 0;
                Console.WriteLine("This ID does not exist");
            }
        
        }

        private void neu()
        {
            string sql = " INSERT INTO `faehigkeit`" +
                         " (`id`, `name`, `deleted`)" +
                         " VALUES " +
                         "('' , '"+this.name+"', '"+this.deleted+"' );";

            this.id = MyDB.db_insert_return_id(sql);
        }

        private void edit()
        {
            string sql = "UPDATE `faehigkeit` SET" +
                          " `name` = '"+ this.name + "'," +
                          " `deleted` = '" + this.deleted + "'  "+
                          "WHERE " +
                          "`id` = "+this.id+";";

            int eff_rows = MyDB.db_update_return_eff_rows(sql);
        }

        public void save()
        {
            if(this.id == 0)
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
            string sql = "SELECT id FROM faehigkeit ORDER BY name  ";
            List<Dictionary<string, string>> data = MyDB.db_exec(sql);

            ArrayList liste = new ArrayList();

            for (int x = 0; x < data.Count; x++)
            {
                Dictionary<string, string> tmp_data = data[x];

                int id = Int32.Parse(tmp_data["id"]);

                liste.Add(new Faehigkeit(id));
            }

            return liste;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
