using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BasketballProject.Models
{
    public class IUtils
    {
        public static void FixITeam(ref ILineupGenModel a)
        {
            string PlayerChange;
            BasketballEntities db = new BasketballEntities();

            List<ImportPlayer> newLu = new List<ImportPlayer>();
            newLu.Add(a.Player1);
            newLu.Add(a.Player2);
            newLu.Add(a.Player3);
            newLu.Add(a.Player4);
            newLu.Add(a.Player5);
            newLu.Add(a.Player6);
            newLu.Add(a.Player7);
            newLu.Add(a.Player8);
            newLu.Add(a.Player9);

            var LuTotal = (Convert.ToInt32(a.Player1.Salary) + Convert.ToInt32(a.Player2.Salary) +
                Convert.ToInt32(a.Player3.Salary) + Convert.ToInt32(a.Player4.Salary) + Convert.ToInt32(a.Player5.Salary)
                + Convert.ToInt32(a.Player6.Salary) + Convert.ToInt32(a.Player7.Salary)
                + Convert.ToInt32(a.Player8.Salary) + Convert.ToInt32(a.Player9.Salary));

            List<ImportPlayer> PointGuards = new List<ImportPlayer>();
            PointGuards = (from x in db.ImportPlayers
                           where x.Position == "PG"
                           select x).ToList();
            foreach (ImportPlayer P in newLu)
            {
                if (P.Position == "PG" && FindIPlayer(PointGuards, P) == true)
                {
                    PointGuards.RemoveAll(x => x.Id == P.Id);
                }
            }

            List<ImportPlayer> ShootingGuards = new List<ImportPlayer>();
            ShootingGuards = (from x in db.ImportPlayers
                              where x.Position == "SG"
                              select x).ToList();
            foreach (ImportPlayer P in newLu)
            {
                if (P.Position == "SG" && FindIPlayer(ShootingGuards, P) == true)
                {
                    ShootingGuards.RemoveAll(x => x.Id == P.Id);
                }
            }

            List<ImportPlayer> SmallForwards = new List<ImportPlayer>();
            SmallForwards = (from x in db.ImportPlayers
                             where x.Position == "SF"
                             select x).ToList();
            foreach (ImportPlayer P in newLu)
            {
                if (P.Position == "SF" && FindIPlayer(SmallForwards, P) == true)
                {
                    SmallForwards.RemoveAll(x => x.Id == P.Id);
                }
            }

            List<ImportPlayer> PowerForwards = new List<ImportPlayer>();
            PowerForwards = (from x in db.ImportPlayers
                             where x.Position == "PF"
                             select x).ToList();
            foreach (ImportPlayer P in newLu)
            {
                if (P.Position == "PF" && FindIPlayer(PowerForwards, P) == true)
                {
                    PowerForwards.RemoveAll(x => x.Id == P.Id);
                }
            }

            List<ImportPlayer> Centers = new List<ImportPlayer>();
            Centers = (from x in db.ImportPlayers
                       where x.Position == "C"
                       select x).ToList();
            foreach (ImportPlayer P in newLu)
            {
                if (P.Position == "C" && FindIPlayer(Centers, P) == true)
                {
                    Centers.RemoveAll(x => x.Id == P.Id);
                }
            }

            while (LuTotal > 60000)
            {
                var HP = newLu.OrderByDescending(item => item.Salary).First();

                switch (HP.Position)
                {
                    case "PG":
                        {
                            PlayerChange = SwitchIPg(ref HP, ref PointGuards);
                            if (a.Player1.Id == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.Id == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player1 = HP;

                                var indexPg = PointGuards.FindIndex(x => x.Id == HP.Id);
                                PointGuards.RemoveAt(indexPg);
                            }
                            else if (a.Player2.Id == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.Id == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player2 = HP;

                                var indexPg = PointGuards.FindIndex(x => x.Id == HP.Id);
                                PointGuards.RemoveAt(indexPg);
                            }

                            break;
                        }
                    case "SG":
                        {
                            PlayerChange = SwitchISg(ref HP, ref ShootingGuards);
                            if (a.Player3.Id == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.Id == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player3 = HP;

                                var indexSg = ShootingGuards.FindIndex(x => x.Id == HP.Id);
                                ShootingGuards.RemoveAt(indexSg);
                            }
                            else if (a.Player4.Id == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.Id == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player4 = HP;

                                var indexSg = ShootingGuards.FindIndex(x => x.Id == HP.Id);
                                ShootingGuards.RemoveAt(indexSg);
                            }
                            break;
                        }
                    case "SF":
                        {
                            PlayerChange = SwitchISf(ref HP, ref SmallForwards);
                            if (a.Player5.Id == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.Id == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player5 = HP;

                                var indexSf = SmallForwards.FindIndex(x => x.Id == HP.Id);
                                SmallForwards.RemoveAt(indexSf);
                            }
                            else if (a.Player6.Id == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.Id == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player6 = HP;

                                var indexSf = SmallForwards.FindIndex(x => x.Id == HP.Id);
                                SmallForwards.RemoveAt(indexSf);
                            }
                            break;
                        }
                    case "PF":
                        {
                            PlayerChange = SwitchIPf(ref HP, ref PowerForwards);
                            if (a.Player7.Id == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.Id == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player7 = HP;

                                var indexPf = PowerForwards.FindIndex(x => x.Id == HP.Id);
                                PowerForwards.RemoveAt(indexPf);
                            }
                            else if (a.Player8.Id == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.Id == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player8 = HP;

                                var indexPf = PowerForwards.FindIndex(x => x.Id == HP.Id);
                                PowerForwards.RemoveAt(indexPf);
                            }
                            break;
                        }
                    default:
                        {
                            PlayerChange = SwitchIC(ref HP, ref Centers);
                            if (a.Player9.Id == PlayerChange)
                            {
                                var index = newLu.FindIndex(x => x.Id == PlayerChange);
                                newLu.RemoveAt(index);
                                newLu.Insert(index, HP);
                                a.Player9 = HP;

                                var indexC = Centers.FindIndex(x => x.Id == HP.Id);
                                Centers.RemoveAt(indexC);
                            }
                            break;
                        }
                }

                LuTotal = (Convert.ToInt32(a.Player1.Salary) + Convert.ToInt32(a.Player2.Salary) +
                Convert.ToInt32(a.Player3.Salary) + Convert.ToInt32(a.Player4.Salary) + Convert.ToInt32(a.Player5.Salary)
                + Convert.ToInt32(a.Player6.Salary) + Convert.ToInt32(a.Player7.Salary)
                + Convert.ToInt32(a.Player8.Salary) + Convert.ToInt32(a.Player9.Salary));
            }

        }
       

        public static string SwitchIPg(ref ImportPlayer d, ref List<ImportPlayer> PointGuards)
        {

            var PlayerChange = d.Id;

            foreach (var IPlayer in PointGuards)
            {
                if (IPlayer.Id == d.Id)
                {
                    IPlayer.Id = "Gone";
                }
            }
            PointGuards.RemoveAll(x => x.Id == "Gone");

            d = PointGuards.OrderByDescending(item => item.Salary).First();

            return PlayerChange;
        }

        public static string SwitchISg(ref ImportPlayer d, ref List<ImportPlayer> ShootingGuards)
        {
            var PlayerChange = d.Id;

            foreach (var IPlayer in ShootingGuards)
            {
                if (IPlayer.Id == d.Id)
                {
                    IPlayer.Id = "Gone";
                }
            }
            ShootingGuards.RemoveAll(x => x.Id == "Gone");

            d = ShootingGuards.OrderByDescending(item => item.Salary).First();

            return PlayerChange;
        }

        public static string SwitchISf(ref ImportPlayer d, ref List<ImportPlayer> SmallForwards)
        {

            var PlayerChange = d.Id;

            foreach (var IPlayer in SmallForwards)
            {
                if (IPlayer.Id == d.Id)
                {
                    IPlayer.Id = "Gone";
                }
            }
            SmallForwards.RemoveAll(x => x.Id == "Gone");

            d = SmallForwards.OrderByDescending(item => item.Salary).First();

            return PlayerChange;
        }

        public static string SwitchIPf(ref ImportPlayer d, ref List<ImportPlayer> PowerForwards)
        {

            var PlayerChange = d.Id;

            foreach (var IPlayer in PowerForwards)
            {
                if (IPlayer.Id == d.Id)
                {
                    IPlayer.Id = "Gone";
                }
            }
            PowerForwards.RemoveAll(x => x.Id == "Gone");

            d = PowerForwards.OrderByDescending(item => item.Salary).First();

            return PlayerChange;
        }

        public static string SwitchIC(ref ImportPlayer d, ref List<ImportPlayer> Centers)
        {
            var PlayerChange = d.Id;

            foreach (var IPlayer in Centers)
            {
                if (IPlayer.Id == d.Id)
                {
                    IPlayer.Id = "Gone";
                }
            }
            Centers.RemoveAll(x => x.Id == "Gone");

            d = Centers.OrderByDescending(item => item.Salary).First();

            return PlayerChange;
        }

        public static bool FindIPlayer(List<ImportPlayer> c, ImportPlayer d)
        {
            var PChange = false;

            foreach (ImportPlayer x in c)
            {
                if (x.Id == d.Id)
                {
                    PChange = true;
                }
            }
            return (PChange);
        }
        public static void AddToDb(List<ImportPlayer> a)
        {
            BasketballEntities db = new BasketballEntities();

            foreach (ImportPlayer Ip in a)
            {
                db.ImportPlayers.Add(Ip);
            }
            db.SaveChanges();
        }

        public static void ClearTable()
        {
            try
            {
                BasketballEntities db = new BasketballEntities();

                var itemsToDelete = from ip in db.ImportPlayers select ip;
                db.ImportPlayers.RemoveRange(itemsToDelete);
                db.SaveChanges();
            }
            catch (DataException e)
            {
                // Process exception and return.
                Console.WriteLine("Exception of type {0} occurred.",
                    e.GetType());
            }

        }
    }
}
