using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Controllers
{
    public class HibernateSequenceManager
    {

        public static void incrementHibernateSequence()
        {
            string connStr = "server=localhost;user=root;database=pidev;port=3306;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
               
                conn.Open();

                int currentHiber = getCurrentHibernateSequence();
              currentHiber++;

                string sql = "UPDATE hibernate_sequence SET next_val=" + currentHiber;
                //  string sql = "DELETE FROM hibernate_sequence";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               
            }

            conn.Close();
           


        }

        public static int getCurrentHibernateSequence()
        {
            string connStr = "server=localhost;user=root;database=pidev;port=3306;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                
                conn.Open();

                string sql = "SELECT next_val FROM hibernate_sequence";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int r = Convert.ToInt32(result);
                   
                    return r;
                }
            }

            catch (Exception ex)
            {
              
            }

            conn.Close();
            return -1;
        }




    }
}