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
            foreach (Player P in newLu)
            {
                if (P.Position == 1 && FindPlayer(PointGuards,P) == true)
                {
                    PointGuards.RemoveAll(x => x.PlayerId == P.PlayerId);
                }
            }

            List<Player> ShootingGuards = new List<Player>();
            ShootingGuards = (from x in db.Players
                              where x.Position == 2
                              select x).ToList();
            foreach (Player P in newLu)
            {
                if (P.Position == 2 && FindPlayer(ShootingGuards, P) == true)
                {
                    ShootingGuards.RemoveAll(x => x.PlayerId == P.PlayerId);
                }
            }

            List<Player> SmallForwards = new List<Player>();
            SmallForwards = (from x in db.Players
                             where x.Position == 3
                             select x).ToList();
            foreach (Player P in newLu)
            {
                if (P.Position == 3 && FindPlayer(SmallForwards, P) == true)
                {
                    SmallForwards.RemoveAll(x => x.PlayerId == P.PlayerId);
                }
            }

            List<Player> PowerForwards = new List<Player>();
            PowerForwards = (from x in db.Players
                             where x.Position == 4
                             select x).ToList();
            foreach (Player P in newLu)
            {
                if (P.Position == 4 && FindPlayer(PowerForwards, P) == true)
                {
                    PowerForwards.RemoveAll(x => x.PlayerId == P.PlayerId);
                }
            }

            List<Player> Centers = new List<Player>();
            Centers = (from x in db.Players
                       where x.Position == 5
                       select x).ToList();
            foreach (Player P in newLu)
            {
                if (P.Position == 5 && FindPlayer(Centers, P) == true)
                {
                    Centers.RemoveAll(x => x.PlayerId == P.PlayerId);
                }
            }

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

                                var indexPg = PointGuards.FindIndex(x => x.PlayerId == HP.PlayerId);
                                PointGuards.RemoveAt(indexPg);
                            }
                            else if (a.Player2.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player2 = HP;

                                var indexPg = PointGuards.FindIndex(x => x.PlayerId == HP.PlayerId);
                                PointGuards.RemoveAt(indexPg);
                            }

                            break;
                        }
                    case 2:
                        {
                            PlayerChange = SwitchSg(ref HP, ref ShootingGuards);
                            if (a.Player3.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player3 = HP;

                                var indexSg = ShootingGuards.FindIndex(x => x.PlayerId == HP.PlayerId);
                                ShootingGuards.RemoveAt(indexSg);
                            }
                            else if (a.Player4.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player4 = HP;

                                var indexSg = ShootingGuards.FindIndex(x => x.PlayerId == HP.PlayerId);
                                ShootingGuards.RemoveAt(indexSg);
                            }
                            break;
                        }
                    case 3:
                        {
                            PlayerChange = SwitchSf(ref HP, ref SmallForwards);
                            if (a.Player5.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player5 = HP;

                                var indexSf = SmallForwards.FindIndex(x => x.PlayerId == HP.PlayerId);
                                SmallForwards.RemoveAt(indexSf);
                            }
                            else if (a.Player6.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player6 = HP;

                                var indexSf = SmallForwards.FindIndex(x => x.PlayerId == HP.PlayerId);
                                SmallForwards.RemoveAt(indexSf);
                            }
                            break;
                        }
                    case 4:
                        {
                            PlayerChange = SwitchPf(ref HP, ref PowerForwards);
                            if (a.Player7.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player7 = HP;

                                var indexPf = PowerForwards.FindIndex(x => x.PlayerId == HP.PlayerId);
                                PowerForwards.RemoveAt(indexPf);
                            }
                            else if (a.Player8.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player8 = HP;

                                var indexPf = PowerForwards.FindIndex(x => x.PlayerId == HP.PlayerId);
                                PowerForwards.RemoveAt(indexPf);
                            }
                            break;
                        }
                    default:
                        {
                            PlayerChange = SwitchC(ref HP, ref Centers);
                            if (a.Player9.PlayerId == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.PlayerId == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player9 = HP;

                                var indexC = Centers.FindIndex(x => x.PlayerId == HP.PlayerId);
                                Centers.RemoveAt(indexC);
                            }
                            break;
                        }
                }

                LuTotal = (a.Player1.Price + a.Player2.Price + a.Player3.Price + a.Player4.Price + a.Player5.Price
                + a.Player6.Price + a.Player7.Price + a.Player8.Price + a.Player9.Price);
            }

        }

        public static void Query(ref LineupGeneratorModel c)
        {
            BasketballEntities db = new BasketballEntities();

            c = new LineupGeneratorModel();

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

            var PlayerChange = d.PlayerId;           

            foreach (var Player in PointGuards)
            {
                if (Player.PlayerId == d.PlayerId)
                {
                    Player.PlayerId = 999;
                }
            }
            PointGuards.RemoveAll(x => x.PlayerId == 999);

            d = PointGuards.OrderByDescending(item => item.Price).First();

            return PlayerChange;
        }

        public static int SwitchSg(ref Player d, ref List<Player> ShootingGuards)
        {           
            var PlayerChange = d.PlayerId;           

            foreach (var Player in ShootingGuards)
            {
                if (Player.PlayerId == d.PlayerId)
                {
                    Player.PlayerId = 999;
                }
            }
            ShootingGuards.RemoveAll(x => x.PlayerId == 999);

            d = ShootingGuards.OrderByDescending(item => item.Price).First();

            return PlayerChange;
        }

        public static int SwitchSf(ref Player d, ref List<Player> SmallForwards)
        {

            var PlayerChange = d.PlayerId;
           
            foreach (var Player in SmallForwards)
            {
                if (Player.PlayerId == d.PlayerId)
                {
                    Player.PlayerId = 999;
                }
            }
            SmallForwards.RemoveAll(x => x.PlayerId == 999);

            d = SmallForwards.OrderByDescending(item => item.Price).First();

            return PlayerChange;
        }

        public static int SwitchPf(ref Player d, ref List<Player> PowerForwards)
        {

            var PlayerChange = d.PlayerId;         

            foreach (var Player in PowerForwards)
            {
                if (Player.PlayerId == d.PlayerId)
                {
                    Player.PlayerId = 999;
                }
            }
            PowerForwards.RemoveAll(x => x.PlayerId == 999);

            d = PowerForwards.OrderByDescending(item => item.Price).First();

            return PlayerChange;
        }

        public static int SwitchC(ref Player d, ref List<Player> Centers)
        {
            var PlayerChange = d.PlayerId;            

            foreach (var Player in Centers)
            {
                if (Player.PlayerId == d.PlayerId)
                {
                    Player.PlayerId = 999;
                }
            }
            Centers.RemoveAll(x => x.PlayerId == 999);
                      
            d = Centers.OrderByDescending(item => item.Price).First();

            return PlayerChange;
        }

        public static bool FindPlayer(List<Player> c,Player d)
        {
            var PChange = false;

            foreach (Player x in c)
            {
                if (x.PlayerId == d.PlayerId)
                {
                    PChange = true;
                }
            }
            return (PChange);
        }
    }

}