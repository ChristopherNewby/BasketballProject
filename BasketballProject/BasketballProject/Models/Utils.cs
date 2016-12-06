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
            var PlayerChange = 0;
            BasketballEntities db = new BasketballEntities();

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

            List<Player> PointGuards = new List<Player>();
            PointGuards = (from x in db.Players
                           where x.Position == 1
                           select x).ToList();

            while (LuTotal > 60000)
            {
                var HP = newLu.OrderByDescending(item => item.Price).First();

                switch (HP.Position)
                {
                    case 1:
                        {
                            PlayerChange = SwitchPg(ref HP, ref PointGuards);
                            if (a.Player1.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player1 = HP;
                            }
                            else if (a.Player2.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player2 = HP;
                            }

                            break;
                        }
                    case 2:
                        {
                            PlayerChange = SwitchSg(ref HP);
                            if (a.Player3.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player3 = HP;
                            }
                            else if (a.Player4.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player4 = HP;
                            }
                            break;
                        }
                    case 3:
                        {
                            PlayerChange = SwitchSf(ref HP);
                            if (a.Player5.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player5 = HP;
                            }
                            else if (a.Player6.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player6 = HP;
                            }
                            break;
                        }
                    case 4:
                        {
                            PlayerChange = SwitchPf(ref HP);
                            if (a.Player7.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player7 = HP;
                            }
                            else if (a.Player8.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player8 = HP;
                            }
                            break;
                        }
                    default:
                        {
                            PlayerChange = SwitchC(ref HP);
                            if (a.Player9.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player9 = HP;
                            }
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

        public static int SwitchPg(ref Player d, ref List<Player>PointGuards)
        {
            //BasketballEntities db = new BasketballEntities();

            var PlayerChange = d.PlayerId;

            //List<Player> PointGuards = new List<Player>();

            //PointGuards = (from a in db.Players
            //                 where a.Position == 1
            //                 select a).ToList();

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

        public static int SwitchSg(ref Player d)
        {
            BasketballEntities db = new BasketballEntities();

            var PlayerChange = d.PlayerId;

            List<Player> ShootingGuards = new List<Player>();

            ShootingGuards = (from a in db.Players
                              where a.Position == 2
                              select a).ToList();

            ShootingGuards = ShootingGuards.OrderByDescending(item => item.Price).ToList();

            foreach (var Player in ShootingGuards)
            {
                if (Player.PlayerId == d.PlayerId)
                {
                    Player.PlayerId = 999;
                }
            }
            ShootingGuards.RemoveAll(x => x.PlayerId == 999);

            ShootingGuards = ShootingGuards.OrderByDescending(item => item.Price).ToList();

            d = ShootingGuards.OrderByDescending(item => item.PlayerId).First();

            return PlayerChange;
        }

        public static int SwitchSf(ref Player d)
        {
            BasketballEntities db = new BasketballEntities();

            var PlayerChange = d.PlayerId;

            List<Player> SmallForwards = new List<Player>();

            SmallForwards = (from a in db.Players
                             where a.Position == 3
                             select a).ToList();

            SmallForwards = SmallForwards.OrderByDescending(item => item.Price).ToList();

            foreach (var Player in SmallForwards)
            {
                if (Player.PlayerId == d.PlayerId)
                {
                    Player.PlayerId = 999;
                }
            }
            SmallForwards.RemoveAll(x => x.PlayerId == 999);

            SmallForwards = SmallForwards.OrderByDescending(item => item.Price).ToList();

            d = SmallForwards.OrderByDescending(item => item.PlayerId).First();

            return PlayerChange;
        }

        public static int SwitchPf(ref Player d)
        {
            BasketballEntities db = new BasketballEntities();

            var PlayerChange = d.PlayerId;

            List<Player> PowerForwards = new List<Player>();

            PowerForwards = (from a in db.Players
                             where a.Position == 4
                             select a).ToList();

            PowerForwards = PowerForwards.OrderByDescending(item => item.Price).ToList();

            foreach (var Player in PowerForwards)
            {
                if (Player.PlayerId == d.PlayerId)
                {
                    Player.PlayerId = 999;
                }
            }
            PowerForwards.RemoveAll(x => x.PlayerId == 999);

            PowerForwards = PowerForwards.OrderByDescending(item => item.Price).ToList();

            d = PowerForwards.OrderByDescending(item => item.PlayerId).First();

            return PlayerChange;
        }

        public static int SwitchC(ref Player d)
        {
            BasketballEntities db = new BasketballEntities();

            var PlayerChange = d.PlayerId;

            List<Player> Centers = new List<Player>();

            Centers = (from a in db.Players
                       where a.Position == 5
                       select a).ToList();

            Centers = Centers.OrderByDescending(item => item.Price).ToList();

            foreach (var Player in Centers)
            {
                if (Player.PlayerId == d.PlayerId)
                {
                    Player.PlayerId = 999;
                }
            }
            Centers.RemoveAll(x => x.PlayerId == 999);

            Centers = Centers.OrderByDescending(item => item.Price).ToList();

            d = Centers.OrderByDescending(item => item.PlayerId).First();

            return PlayerChange;
        }
    }

}