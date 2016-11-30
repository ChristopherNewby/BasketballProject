using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketballProject.Models
{
    public class LineupSelectionViewModel
    {
        public IEnumerable<Player> PointGuards;
        public IEnumerable<Player> ShootingGuards;
        public IEnumerable<Player> SmallForwards;
        public IEnumerable<Player> PowerFowards;
        public IEnumerable<Player> Centers;

        public IEnumerable<Player> Guards;
        public IEnumerable<Player> Forwards;

    }
}