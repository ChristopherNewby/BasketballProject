using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketballProject.Models
{
    public class LineupGeneratorModel
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player Player3 { get; set; }
        public Player Player4 { get; set; }
        public Player Player5 { get; set; }
        public Player Player6 { get; set; }
        public Player Player7 { get; set; }
        public Player Player8 { get; set; }
        public Player Player9 { get; set; }

        public IEnumerable<Player> PointGuards;
        public IEnumerable<Player> ShootingGuards;
        public IEnumerable<Player> SmallForwards;
        public IEnumerable<Player> PowerFowards;
        public IEnumerable<Player> Centers;

        public IEnumerable<Player> Guards;
        public IEnumerable<Player> Forwards;

    }
}