using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasketballProject.Models
{
    public class Utils
    {


        public static void FixTeam(ref LineupGeneratorModel a)
        {
            List<Player> newLu = new List<Player>();
            newLu.Add(a.Player1);
            newLu.Add(a.Player2);
            newLu.Add(a.Player3);
            newLu.Add(a.Player4);
            newLu.Add(a.Player5);
            newLu.Add(a.Player6);
            newLu.Add(a.Player7);
            newLu.Add(a.Player8);
            newLu.Add(a.Player9);

            var LuTotal = (a.Player1.Price + a.Player2.Price + a.Player3.Price + a.Player4.Price + a.Player5.Price
                + a.Player6.Price + a.Player7.Price + a.Player8.Price + a.Player9.Price);

            while (LuTotal > 60000) 
            {
                var HP = newLu.OrderByDescending(item => item.Price).First();

                switch (HP.Position)
                {
                    case 1:
                        {
                            SwitchPg(ref HP);
                            
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                LuTotal = (a.Player1.Price + a.Player2.Price + a.Player3.Price + a.Player4.Price + a.Player5.Price
                + a.Player6.Price + a.Player7.Price + a.Player8.Price + a.Player9.Price);
            }
          
        }

        public static void Query(ref LineupSelectionViewModel c)
        {
            BasketballEntities db = new BasketballEntities();

            c = new LineupSelectionViewModel();

            c.PointGuards = (from a in db.Players
                                   where a.Position == 1
                                   select a).ToList();

            c.ShootingGuards = (from b in db.Players
                                      where b.Position == 2
                                      select b).ToList();

            c.SmallForwards = (from b in db.Players
                                     where b.Position == 3
                                     select b).ToList();

            c.PowerFowards = (from b in db.Players
                                    where b.Position == 4
                                    select b).ToList();

            c.Centers = (from b in db.Players
                               where b.Position == 5
                               select b).ToList();
        }

        public static int SwitchPg(ref Player d)
        {
            BasketballEntities db = new BasketballEntities();

            var PlayerChange = d.PlayerId;

            List<Player> PointGuards = new List<Player>();

            PointGuards = (from a in db.Players
                             where a.Position == 1
                             select a).ToList();

            PointGuards = PointGuards.OrderByDescending(item => item.Price).ToList();

            foreach (var Player in PointGuards)  
            {
                if (Player.PlayerId == d.PlayerId)
                {
                    Player.PlayerId = 999;
                }
            }
            PointGuards.RemoveAll(x => x.PlayerId == 999);

            PointGuards = PointGuards.OrderByDescending(item => item.Price).ToList();

            d = PointGuards.OrderByDescending(item => item.PlayerId).First();

            return PlayerChange;               
        }
    }
    
}