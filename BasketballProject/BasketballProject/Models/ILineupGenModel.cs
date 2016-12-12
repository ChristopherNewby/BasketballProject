using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketballProject.Models
{
    public class ILineupGenModel
    {
        public ImportPlayer Player1 { get; set; }
        public ImportPlayer Player2 { get; set; }
        public ImportPlayer Player3 { get; set; }
        public ImportPlayer Player4 { get; set; }
        public ImportPlayer Player5 { get; set; }
        public ImportPlayer Player6 { get; set; }
        public ImportPlayer Player7 { get; set; }
        public ImportPlayer Player8 { get; set; }
        public ImportPlayer Player9 { get; set; }

        public IEnumerable<ImportPlayer> PointGuards;
        public IEnumerable<ImportPlayer> ShootingGuards;
        public IEnumerable<ImportPlayer> SmallForwards;
        public IEnumerable<ImportPlayer> PowerFowards;
        public IEnumerable<ImportPlayer> Centers;

        public IEnumerable<ImportPlayer> Guards;
        public IEnumerable<ImportPlayer> Forwards;
    }
}