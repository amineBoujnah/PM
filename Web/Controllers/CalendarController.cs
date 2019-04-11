using MySql.Data.MySqlClient;
//using Presentation.Controllers;
using Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult findAll()
        {


            string connStr = "server=localhost;user=root;database=pidev;port=3306;password=";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {

                conn.Open();

                string sql = "SELECT idDeclaration,dateDeclaration,titre,fichier,DTYPE FROM declaration WHERE adherent_idAdherent="+LoginAdherentController.currentAdherent;
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                List<DeclarationCalendarVM> values = new List<DeclarationCalendarVM>();


                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    DeclarationCalendarVM ldv = new DeclarationCalendarVM();
                    ldv.idDeclaration = (int)reader["idDeclaration"];
                    ldv.DateDeclaration = (DateTime)reader["dateDeclaration"];
                    ldv.titre = (string)reader["titre"];
                    ldv.fichier = (string)reader["fichier"];
                    ldv.DTYPE = (string)reader["DTYPE"];


                    values.Add(ldv);

                }

                return Json(values.AsEnumerable().Select(e => new
                {
                    id = e.idDeclaration,
                    title = e.titre,
                    start = e.DateDeclaration.ToString("MM/dd/yyyy"),
                    fichier = "http://localhost/OTDAV/" + e.fichier,
                    DTYPE = e.DTYPE


                }).ToList(), JsonRequestBehavior.AllowGet);


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();

            return Json("erroroooorrr", JsonRequestBehavior.AllowGet);

        }
        }
    }