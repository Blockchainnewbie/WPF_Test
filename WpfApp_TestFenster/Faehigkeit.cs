
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
            IDataReader reader =  MyDB.db_exec(sql);

            if( reader.Read() == true)
            {
                // übertragung der daten aus DB Result in klassen Variablen
                this.name = (string)reader["name"];
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
            string sql = "SELECT * FROM faehigkeit ORDER BY name  ";
            IDataReader reader = MyDB.db_exec(sql);

            ArrayList liste = new ArrayList();

            while (reader.Read() == true)
            {
                int id = (int)reader["id"];
                liste.Add( new Faehigkeit(id) );
            }

            return liste;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
