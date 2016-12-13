using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BasketballProject.Models
{
    public class IUtils
    {
        public static void FixITeamS(ref ILineupGenModel a)
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

            var LuTotal = TotalSalary(newLu);

            List<ImportPlayer> PointGuards = new List<ImportPlayer>();
            FillList(ref PointGuards, "PG");
            RemoveFromList(newLu, ref PointGuards, "PG");

            List<ImportPlayer> ShootingGuards = new List<ImportPlayer>();
            FillList(ref ShootingGuards, "SG");
            RemoveFromList(newLu, ref ShootingGuards, "SG");

            List<ImportPlayer> SmallForwards = new List<ImportPlayer>();
            FillList(ref SmallForwards, "SF");
            RemoveFromList(newLu, ref SmallForwards, "SF");

            List<ImportPlayer> PowerForwards = new List<ImportPlayer>();
            FillList(ref PowerForwards, "PF");
            RemoveFromList(newLu, ref PowerForwards, "PF");

            List<ImportPlayer> Centers = new List<ImportPlayer>();
            FillList(ref Centers, "C");
            RemoveFromList(newLu, ref Centers, "C");


            while (LuTotal > 60000)
            {
                var HP = newLu.OrderByDescending(item => item.Salary).First();

                switch (HP.Position)
                {
                    case "PG":
                        {
                            PlayerChange = SwitchPlayer(ref HP, ref PointGuards);
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
                            PlayerChange = SwitchPlayer(ref HP, ref ShootingGuards);
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
                            PlayerChange = SwitchPlayer(ref HP, ref SmallForwards);
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
                            PlayerChange = SwitchPlayer(ref HP, ref PowerForwards);
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
                            PlayerChange = SwitchPlayer(ref HP, ref Centers);
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

                LuTotal = TotalSalary(newLu);
            }

        }

        //public static void FixITeamF(ref ILineupGenModel a)
        //{
        //    string PlayerChange;
        //    BasketballEntities db = new BasketballEntities();

        //    List<ImportPlayer> newLu = new List<ImportPlayer>();
        //    newLu.Add(a.Player1);
        //    newLu.Add(a.Player2);
        //    newLu.Add(a.Player3);
        //    newLu.Add(a.Player4);
        //    newLu.Add(a.Player5);
        //    newLu.Add(a.Player6);
        //    newLu.Add(a.Player7);
        //    newLu.Add(a.Player8);
        //    newLu.Add(a.Player9);

        //    var LuTotal = (Convert.ToInt32(a.Player1.Salary) + Convert.ToInt32(a.Player2.Salary) +
        //        Convert.ToInt32(a.Player3.Salary) + Convert.ToInt32(a.Player4.Salary) + Convert.ToInt32(a.Player5.Salary)
        //        + Convert.ToInt32(a.Player6.Salary) + Convert.ToInt32(a.Player7.Salary)
        //        + Convert.ToInt32(a.Player8.Salary) + Convert.ToInt32(a.Player9.Salary));


        //    List<ImportPlayer> PointGuards = new List<ImportPlayer>();

        //    PointGuards = (from x in db.ImportPlayers
        //                   where x.Position == "PG"
        //                   select x).ToList();
        //    foreach (ImportPlayer P in newLu)
        //    {
        //        if (P.Position == "PG" && FindIPlayer(PointGuards, P) == true)
        //        {
        //            PointGuards.RemoveAll(x => x.Id == P.Id);
        //        }
        //    }

        //    List<ImportPlayer> ShootingGuards = new List<ImportPlayer>();
        //    ShootingGuards = (from x in db.ImportPlayers
        //                      where x.Position == "SG"
        //                      select x).ToList();
        //    foreach (ImportPlayer P in newLu)
        //    {
        //        if (P.Position == "SG" && FindIPlayer(ShootingGuards, P) == true)
        //        {
        //            ShootingGuards.RemoveAll(x => x.Id == P.Id);
        //        }
        //    }

        //    List<ImportPlayer> SmallForwards = new List<ImportPlayer>();
        //    SmallForwards = (from x in db.ImportPlayers
        //                     where x.Position == "SF"
        //                     select x).ToList();
        //    foreach (ImportPlayer P in newLu)
        //    {
        //        if (P.Position == "SF" && FindIPlayer(SmallForwards, P) == true)
        //        {
        //            SmallForwards.RemoveAll(x => x.Id == P.Id);
        //        }
        //    }

        //    List<ImportPlayer> PowerForwards = new List<ImportPlayer>();
        //    PowerForwards = (from x in db.ImportPlayers
        //                     where x.Position == "PF"
        //                     select x).ToList();
        //    foreach (ImportPlayer P in newLu)
        //    {
        //        if (P.Position == "PF" && FindIPlayer(PowerForwards, P) == true)
        //        {
        //            PowerForwards.RemoveAll(x => x.Id == P.Id);
        //        }
        //    }

        //    List<ImportPlayer> Centers = new List<ImportPlayer>();
        //    Centers = (from x in db.ImportPlayers
        //               where x.Position == "C"
        //               select x).ToList();
        //    foreach (ImportPlayer P in newLu)
        //    {
        //        if (P.Position == "C" && FindIPlayer(Centers, P) == true)
        //        {
        //            Centers.RemoveAll(x => x.Id == P.Id);
        //        }
        //    }

        //    while (LuTotal > 60000)
        //    {
        //        var HP = newLu.OrderByDescending(item => item.FPPG).First();

        //        switch (HP.Position)
        //        {
        //            case "PG":
        //                {
        //                    PlayerChange = SwitchPlayer(ref HP, ref PointGuards);
        //                    if (a.Player1.Id == PlayerChange)
        //                    {
        //                        var index = newLu.FindIndex(x => x.Id == PlayerChange);
        //                        newLu.RemoveAt(index);
        //                        newLu.Insert(index, HP);
        //                        a.Player1 = HP;

        //                        var indexPg = PointGuards.FindIndex(x => x.Id == HP.Id);
        //                        PointGuards.RemoveAt(indexPg);
        //                    }
        //                    else if (a.Player2.Id == PlayerChange)
        //                    {
        //                        var index = newLu.FindIndex(x => x.Id == PlayerChange);
        //                        newLu.RemoveAt(index);
        //                        newLu.Insert(index, HP);
        //                        a.Player2 = HP;

        //                        var indexPg = PointGuards.FindIndex(x => x.Id == HP.Id);
        //                        PointGuards.RemoveAt(indexPg);
        //                    }

        //                    break;
        //                }
        //            case "SG":
        //                {
        //                    PlayerChange = SwitchPlayer(ref HP, ref ShootingGuards);
        //                    if (a.Player3.Id == PlayerChange)
        //                    {
        //                        var index = newLu.FindIndex(x => x.Id == PlayerChange);
        //                        newLu.RemoveAt(index);
        //                        newLu.Insert(index, HP);
        //                        a.Player3 = HP;

        //                        var indexSg = ShootingGuards.FindIndex(x => x.Id == HP.Id);
        //                        ShootingGuards.RemoveAt(indexSg);
        //                    }
        //                    else if (a.Player4.Id == PlayerChange)
        //                    {
        //                        var index = newLu.FindIndex(x => x.Id == PlayerChange);
        //                        newLu.RemoveAt(index);
        //                        newLu.Insert(index, HP);
        //                        a.Player4 = HP;

        //                        var indexSg = ShootingGuards.FindIndex(x => x.Id == HP.Id);
        //                        ShootingGuards.RemoveAt(indexSg);
        //                    }
        //                    break;
        //                }
        //            case "SF":
        //                {
        //                    PlayerChange = SwitchPlayer(ref HP, ref SmallForwards);
        //                    if (a.Player5.Id == PlayerChange)
        //                    {
        //                        var index = newLu.FindIndex(x => x.Id == PlayerChange);
        //                        newLu.RemoveAt(index);
        //                        newLu.Insert(index, HP);
        //                        a.Player5 = HP;

        //                        var indexSf = SmallForwards.FindIndex(x => x.Id == HP.Id);
        //                        SmallForwards.RemoveAt(indexSf);
        //                    }
        //                    else if (a.Player6.Id == PlayerChange)
        //                    {
        //                        var index = newLu.FindIndex(x => x.Id == PlayerChange);
        //                        newLu.RemoveAt(index);
        //                        newLu.Insert(index, HP);
        //                        a.Player6 = HP;

        //                        var indexSf = SmallForwards.FindIndex(x => x.Id == HP.Id);
        //                        SmallForwards.RemoveAt(indexSf);
        //                    }
        //                    break;
        //                }
        //            case "PF":
        //                {
        //                    PlayerChange = SwitchPlayer(ref HP, ref PowerForwards);
        //                    if (a.Player7.Id == PlayerChange)
        //                    {
        //                        var index = newLu.FindIndex(x => x.Id == PlayerChange);
        //                        newLu.RemoveAt(index);
        //                        newLu.Insert(index, HP);
        //                        a.Player7 = HP;

        //                        var indexPf = PowerForwards.FindIndex(x => x.Id == HP.Id);
        //                        PowerForwards.RemoveAt(indexPf);
        //                    }
        //                    else if (a.Player8.Id == PlayerChange)
        //                    {
        //                        var index = newLu.FindIndex(x => x.Id == PlayerChange);
        //                        newLu.RemoveAt(index);
        //                        newLu.Insert(index, HP);
        //                        a.Player8 = HP;

        //                        var indexPf = PowerForwards.FindIndex(x => x.Id == HP.Id);
        //                        PowerForwards.RemoveAt(indexPf);
        //                    }
        //                    break;
        //                }
        //            default:
        //                {
        //                    PlayerChange = SwitchPlayer(ref HP, ref Centers);
        //                    if (a.Player9.Id == PlayerChange)
        //                    {
        //                        var index = newLu.FindIndex(x => x.Id == PlayerChange);
        //                        newLu.RemoveAt(index);
        //                        newLu.Insert(index, HP);
        //                        a.Player9 = HP;

        //                        var indexC = Centers.FindIndex(x => x.Id == HP.Id);
        //                        Centers.RemoveAt(indexC);
        //                    }
        //                    break;
        //                }
        //        }

        //        LuTotal = (Convert.ToInt32(a.Player1.Salary) + Convert.ToInt32(a.Player2.Salary) +
        //        Convert.ToInt32(a.Player3.Salary) + Convert.ToInt32(a.Player4.Salary) + Convert.ToInt32(a.Player5.Salary)
        //        + Convert.ToInt32(a.Player6.Salary) + Convert.ToInt32(a.Player7.Salary)
        //        + Convert.ToInt32(a.Player8.Salary) + Convert.ToInt32(a.Player9.Salary));
        //    }

        //}

        public static string SwitchPlayer(ref ImportPlayer PToChange, ref List<ImportPlayer> ListToSearch)
        {
            var PlayerChange = PToChange.Id;

            foreach (var IPlayer in ListToSearch)
            {
                if (IPlayer.Id == PToChange.Id)
                {
                    IPlayer.Id = "Gone";
                }
            }
            ListToSearch.RemoveAll(x => x.Id == "Gone");

            PToChange = ListToSearch.OrderByDescending(item => item.Salary).First();

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

        public static List<ImportPlayer> FillList(ref List<ImportPlayer> PosToFill, string Position)
        {
            BasketballEntities db = new BasketballEntities();

            PosToFill = (from x in db.ImportPlayers
                         where x.Position == Position
                         select x).ToList();
            return (PosToFill);
        }

        public static void RemoveFromList(List<ImportPlayer> LU, ref List<ImportPlayer> Pos, string Position)
        {
            foreach (ImportPlayer P in LU)
            {
                if (P.Position == Position && FindIPlayer(Pos, P) == true)
                {
                    Pos.RemoveAll(x => x.Id == P.Id);
                }
            }
        }

        public static int TotalSalary(List<ImportPlayer> b)
        {
            var LU = 0;

            foreach (ImportPlayer a in b)
            {
                LU = LU + Convert.ToInt32(a.Salary);
            }
            return (LU);
        }
    }
}
