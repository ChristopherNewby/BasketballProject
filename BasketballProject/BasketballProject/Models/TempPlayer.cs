using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketballProject.Models
{
    public class TempPlayer
    {
        public string Id { get; set; }
        public string Position { get; set; }

        public string First_Name { get; set; }

        public string Nickname { get; set; }

        public string Last_Name { get; set; }

        public double FPPG { get; set; }

        public string Played { get; set; }

        public string Salary { get; set; }

        public string Game { get; set; }

        public string Team { get; set; }

        public string Opponent { get; set; }

        public string Injury_Indicator { get; set; }

        public string Injury_Details { get; set; }

    }
}