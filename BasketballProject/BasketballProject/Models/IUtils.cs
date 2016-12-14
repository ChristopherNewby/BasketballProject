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
            //ImportPlayer LockedPG = checkForLocked(PointGuards);
            //if (LockedPG.Played == "Locked")
            //{
            //    var index = newLu.FindIndex(x => x.Position == LockedPG.Position);
            //    newLu.RemoveAt(index);
            //    newLu.Insert(index, LockedPG);
            //    //a.Player1 = LockedPG;
            //}
            RemoveFromList(newLu, ref PointGuards, "PG");

            List<ImportPlayer> ShootingGuards = new List<ImportPlayer>();
            FillList(ref ShootingGuards, "SG");
            //ImportPlayer LockedSG = checkForLocked(ShootingGuards);
            //if (LockedSG.Played == "Locked")
            //{
            //    var index = newLu.FindIndex(x => x.Position == LockedSG.Position);
            //    newLu.RemoveAt(index);
            //    newLu.Insert(index, LockedSG);
            //    //a.Player1 = LockedPG;
            //}
            RemoveFromList(newLu, ref ShootingGuards, "SG");

            List<ImportPlayer> SmallForwards = new List<ImportPlayer>();
            FillList(ref SmallForwards, "SF");
            //ImportPlayer LockedSF = checkForLocked(SmallForwards);
            //if (LockedSF.Played == "Locked")
            //{
            //    var index = newLu.FindIndex(x => x.Position == LockedSF.Position);
            //    newLu.RemoveAt(index);
            //    newLu.Insert(index, LockedSF);
            //    //a.Player1 = LockedPG;
            //}
            RemoveFromList(newLu, ref SmallForwards, "SF");

            List<ImportPlayer> PowerForwards = new List<ImportPlayer>();
            FillList(ref PowerForwards, "PF");
            //ImportPlayer LockedPF = checkForLocked(PowerForwards);
            //if (LockedPF.Played == "Locked")
            //{
            //    var index = newLu.FindIndex(x => x.Position == LockedPF.Position);
            //    newLu.RemoveAt(index);
            //    newLu.Insert(index, LockedPF);
            //    //a.Player1 = LockedPG;
            //}
            RemoveFromList(newLu, ref PowerForwards, "PF");

            List<ImportPlayer> Centers = new List<ImportPlayer>();
            FillList(ref Centers, "C");
            //ImportPlayer LockedC = checkForLocked(Centers);
            //if (LockedC.Played == "Locked")
            //{
            //    var index = newLu.FindIndex(x => x.Position == LockedC.Position);
            //    newLu.RemoveAt(index);
            //    newLu.Insert(index, LockedC);
            //    //a.Player1 = LockedPG;
            //}
            RemoveFromList(newLu, ref Centers, "C");

            List<ImportPlayer> LockedPlayers = new List<ImportPlayer>();
            List<ImportPlayer> NotLockedPlayers = new List<ImportPlayer>();

            foreach (ImportPlayer Ip in newLu)
            {
                if (Ip.Played == "Locked")
                {
                    LockedPlayers.Add(Ip);
                }
                else
                {
                    NotLockedPlayers.Add(Ip);
                }
            }

             var newLuTotal = TotalSalary(LockedPlayers) + TotalSalary(NotLockedPlayers);

            while (LuTotal > 60000)
            {
                var HP = newLu.OrderByDescending(item => item.Salary).First();

                switch (HP.Position)
                {
                    case "PG":
                        {
                            PlayerChange = SwitchPlayer(ref HP, ref PointGuards);
                            if (a.Player1.Id == PlayerChange && a.Player1.Played != "Locked")
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


        public static void FixITeamSInj(ref ILineupGenModel a)
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
            FillListInj(ref PointGuards, "PG");
            RemoveFromList(newLu, ref PointGuards, "PG");

            List<ImportPlayer> ShootingGuards = new List<ImportPlayer>();
            FillListInj(ref ShootingGuards, "SG");
            RemoveFromList(newLu, ref ShootingGuards, "SG");

            List<ImportPlayer> SmallForwards = new List<ImportPlayer>();
            FillListInj(ref SmallForwards, "SF");
            RemoveFromList(newLu, ref SmallForwards, "SF");

            List<ImportPlayer> PowerForwards = new List<ImportPlayer>();
            FillListInj(ref PowerForwards, "PF");
            RemoveFromList(newLu, ref PowerForwards, "PF");

            List<ImportPlayer> Centers = new List<ImportPlayer>();
            FillListInj(ref Centers, "C");
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

        public static void FixITeamSO(ref ILineupGenModel a)
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
            FillListO(ref PointGuards, "PG");
            RemoveFromList(newLu, ref PointGuards, "PG");

            List<ImportPlayer> ShootingGuards = new List<ImportPlayer>();
            FillListO(ref ShootingGuards, "SG");
            RemoveFromList(newLu, ref ShootingGuards, "SG");

            List<ImportPlayer> SmallForwards = new List<ImportPlayer>();
            FillListO(ref SmallForwards, "SF");
            RemoveFromList(newLu, ref SmallForwards, "SF");

            List<ImportPlayer> PowerForwards = new List<ImportPlayer>();
            FillListO(ref PowerForwards, "PF");
            RemoveFromList(newLu, ref PowerForwards, "PF");

            List<ImportPlayer> Centers = new List<ImportPlayer>();
            FillListO(ref Centers, "C");
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

        public static void FixITeamFpg(ref ILineupGenModel a)
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
            FillListO(ref PointGuards, "PG");
            RemoveFromList(newLu, ref PointGuards, "PG");


            List<ImportPlayer> ShootingGuards = new List<ImportPlayer>();
            FillListO(ref ShootingGuards, "SG");
            RemoveFromList(newLu, ref ShootingGuards, "SG");

            List<ImportPlayer> SmallForwards = new List<ImportPlayer>();
            FillListO(ref SmallForwards, "SF");
            RemoveFromList(newLu, ref SmallForwards, "SF");

            List<ImportPlayer> PowerForwards = new List<ImportPlayer>();
            FillListO(ref PowerForwards, "PF");
            RemoveFromList(newLu, ref PowerForwards, "PF");

            List<ImportPlayer> Centers = new List<ImportPlayer>();
            FillListO(ref Centers, "C");
            RemoveFromList(newLu, ref Centers, "C");


            while (LuTotal > 60000)
            {
                var HP = Copy(newLu);

                switch (HP.Position)
                {
                    case "PG":
                        {
                            PlayerChange = SwitchPlayerFFPG(ref HP, ref PointGuards);
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
                            PlayerChange = SwitchPlayerFFPG(ref HP, ref ShootingGuards);
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
                            PlayerChange = SwitchPlayerFFPG(ref HP, ref SmallForwards);
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
                            PlayerChange = SwitchPlayerFFPG(ref HP, ref PowerForwards);
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
                            PlayerChange = SwitchPlayerFFPG(ref HP, ref Centers);
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

            if (PToChange.Played == "Locked")
            {
                return PlayerChange;
            }

            ListToSearch.RemoveAll(x => x.Id == "Gone");

            PToChange = ListToSearch.OrderByDescending(x => x.Salary).First();

            return PlayerChange;
        }
        public static string SwitchPlayerFFPG(ref ImportPlayer PToChange, ref List<ImportPlayer> ListToSearch)
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

            PToChange = Copy(ListToSearch);

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



        public static List<ImportPlayer> FillListInj(ref List<ImportPlayer> PosToFill, string Position)
        {
            BasketballEntities db = new BasketballEntities();

            PosToFill = (from x in db.ImportPlayers
                         where x.Position == Position
                         select x).ToList();

            foreach (ImportPlayer InjP in PosToFill)
            {
                if (InjP.Injury_Indicator != "")
                {
                    InjP.Id = "Injured";
                }
            }

            PosToFill.RemoveAll(x => x.Id == "Injured");

            return (PosToFill);
        }
        public static List<ImportPlayer> FillListO(ref List<ImportPlayer> PosToFill, string Position)
        {
            BasketballEntities db = new BasketballEntities();

            PosToFill = (from x in db.ImportPlayers
                         where x.Position == Position
                         select x).ToList();

            foreach (ImportPlayer InjP in PosToFill)
            {
                if (InjP.Injury_Details == "O")
                {
                    InjP.Id = "Injured";
                }
            }

            PosToFill.RemoveAll(x => x.Id == "Injured");

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

        public static ImportPlayer Copy(List<ImportPlayer> ListToChange)
        {
            List<TempPlayer> SwappedList = new List<TempPlayer>();

            foreach (var IP in ListToChange)
            {
                TempPlayer Tp = new TempPlayer();

                Tp.Id = IP.Id;
                Tp.Position = IP.Position;
                Tp.Last_Name = IP.Last_Name;
                Tp.Nickname = IP.Nickname;
                Tp.First_Name = IP.First_Name;
                Tp.FPPG = Convert.ToDouble(IP.FPPG);
                Tp.Played = IP.Played;
                Tp.Salary = IP.Salary;
                Tp.Game = IP.Game;
                Tp.Team = IP.Team;
                Tp.Opponent = IP.Opponent;
                Tp.Injury_Indicator = IP.Injury_Indicator;
                Tp.Injury_Details = IP.Injury_Details;

                SwappedList.Add(Tp);
            }
            var SelP = SwappedList.OrderByDescending(x => x.FPPG).First();
            ImportPlayer playerToReturn = null;

            foreach (ImportPlayer Ip in ListToChange)
            {
                if (Ip.Id == SelP.Id)
                {
                    playerToReturn = Ip;
                    break;
                }
            }
            return (playerToReturn);
        }
        //public static ImportPlayer checkForLocked(List<ImportPlayer> listToBeChecked)
        //{
        //    ImportPlayer d = null;

        //    foreach (ImportPlayer Ip in listToBeChecked)
        //    {
        //        if (Ip.Played == "Locked")
        //        {
        //            d = Ip;
        //        }               
        //    }
        //    return d;
        //}
    }
}


