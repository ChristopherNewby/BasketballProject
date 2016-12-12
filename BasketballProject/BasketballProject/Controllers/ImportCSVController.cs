using BasketballProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Text;

namespace BasketballProject.Controllers
{
    public class ImportCSVController : Controller
    {
        private BasketballEntities db = new BasketballEntities();

        // GET: ImportCSV
        public ActionResult Index()
        {
            Utils.ClearTable();

            string fileName = "FanDuel-NBA-2016-12-12-17268-players-list.csv";

            List<ImportPlayer> ImPlayers = new List<ImportPlayer>();

            StreamReader sr = new StreamReader(fileName);
            if (System.IO.File.Exists(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();
                    string[] values = temp.Split(',');

                    ImportPlayer c2 = new ImportPlayer();
                    c2.Id = values[0].Replace("\\", "").Replace("\"", "");
                    c2.Position = values[1].Replace("\\", "").Replace("\"", ""); ;
                    c2.First_Name = values[2].Replace("\\", "").Replace("\"", ""); ;
                    c2.Nickname = values[3].Replace("\\", "").Replace("\"", ""); ;
                    c2.Last_Name = values[4].Replace("\\", "").Replace("\"", ""); ;
                    c2.FPPG = values[5].Replace("\\", "").Replace("\"", ""); ;
                    c2.Played = values[6].Replace("\\", "").Replace("\"", ""); ;
                    c2.Salary = values[7].Replace("\\", "").Replace("\"", ""); ;
                    c2.Game = values[8].Replace("\\", "").Replace("\"", ""); ;
                    c2.Team = values[9].Replace("\\", "").Replace("\"", ""); ;
                    c2.Opponent = values[10].Replace("\\", "").Replace("\"", ""); ;
                    c2.Injury_Details = values[11].Replace("\\", "").Replace("\"", ""); ;
                    c2.Injury_Indicator = values[12].Replace("\\", "").Replace("\"", ""); ;

                    ImPlayers.Add(c2);
                                       
                }
                Utils.AddToDb(ImPlayers);
            }
            else
            {
                Console.WriteLine("File not found");
            }

            return View();
        }

        
    }
}