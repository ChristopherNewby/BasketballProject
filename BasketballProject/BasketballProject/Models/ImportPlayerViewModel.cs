using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketballProject.Models
{
    public class ImportPlayerViewModel
    {
        public List<ImportPlayer> ImPlayers;

        public ImportPlayerViewModel()
        {
            ImPlayers = new List<ImportPlayer>();
        }

    }
}