using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;



namespace WC
{
    




    public class Program
    {


        public class Team
        {
            public string Name { get; set; }
            public int Power { get; set; }
            public int Points { get; set; }
            public int Scored { get; set; }
            public int Conceded { get; set; }
            public int Member { get; set; }
            public string Inter { get; set; }
            public Team(string name, int power, int points, int scored, int conceded, int member, string inter)
            {
                Name = name;
                Power = power;
                Points = points;
                Scored = scored;
                Conceded = conceded;
                Member = member;
                Inter = inter;
            }
        }


        static double Rando() {

            RNGCryptoServiceProvider _secureRng = new RNGCryptoServiceProvider();
            var bytes = new byte[8];
            _secureRng.GetBytes(bytes);
            var v = BitConverter.ToUInt64(bytes, 0);
            v &= ((1UL << 53) - 1);
            var r = (double)v / (double)(1UL << 53);
            return r;

        }
 

        static Tuple<int, int, int, int, int, int> ResultGroup(Team x, Team y)
        {

            double[] coeficients = new double[] { 0.8, 0.7, 0.65, 0.55, 0.53, 0.52, 0.51, 0.505 };
            double gx = 0;
            double gy = 0;
                       
            for (int i = 0; i < coeficients.Length; i++)
                {               
                gx += Math.Round(Rando() * coeficients[i] * x.Power / y.Power);
                gy += Math.Round(Rando() * coeficients[i] * y.Power / x.Power);

            }

            //         return new Tuple<double, double>(gx, gy);
            //  Console.Write(gx);
            /*
                        gx = Math.Round(Rando() * 3.2 * x.Power / y.Power);
                        gy = Math.Round(Rando() * 3.2 * y.Power / x.Power);
             */
            int sx = Convert.ToInt32(gx);
            int sy = Convert.ToInt32(gy);

            x.Scored += sx;
            y.Scored += sy;
            x.Conceded += sy;
            y.Conceded += sx;

            if (gx>gy)
                        {
                            x.Points += 3;
                
                        }
                        else if (gx<gy)
                        {
                            y.Points += 3;
                        }
                        else
                        {
                            x.Points += 1;
                            y.Points += 1;
                        }


            
                      Console.WriteLine(x.Name + " VS " + y.Name + " : " + gx + " - " + gy);
                       return new Tuple<int, int, int, int, int, int> (x.Points,y.Points,x.Scored,y.Scored,x.Conceded,y.Conceded);
            
            }




        static Team ResultKnock(Team x, Team y, string str)
        {


            string[] extraTime = new string[] {"1-0","2-1","3-2","2-0","3-1","3-0","4-1","4-2","1-0","1-0","2-1","2-1","2-0","2-0","1-0"};
            double[] coeficients = new double[] { 0.8, 0.7, 0.65, 0.55, 0.53, 0.52, 0.51, 0.505 };
            double gx = 0;
            double gy = 0;

            for (int i = 0; i < coeficients.Length; i++)
            {
                gx += Math.Round(Rando() * coeficients[i] * x.Power / y.Power);
                gy += Math.Round(Rando() * coeficients[i] * y.Power / x.Power);

            }

            //         return new Tuple<double, double>(gx, gy);
            //  Console.Write(gx);
            /*
                        gx = Math.Round(Rando() * 3.2 * x.Power / y.Power);
                        gy = Math.Round(Rando() * 3.2 * y.Power / x.Power);
             */
            //    int sx = Convert.ToInt32(gx);
            //    int sy = Convert.ToInt32(gy);          


            if (gx > gy)
            {
                Console.WriteLine(x.Name + " won " + gx + " - " + gy + " against " + y.Name + " and " + /*" and goes to next stage!"*/ str);
                return x;

            }
            else if (gx < gy)
            {
                Console.WriteLine(y.Name + " won " + gy + " - " + gx + " against " + x.Name + " and " + /*" and goes to next stage!"*/ str);
                return y;
            }
            else
            {
                Console.WriteLine(x.Name + " and " + y.Name + " drew " + gx + " - " + gy + " in regular time. ");
                var pen = Math.Round(Rando() * 3);
                int et = Convert.ToInt32(Math.Round(Rando() * 14));
                if (pen == 0)
                {
                    Console.WriteLine(x.Name + " won on penalties and " + /*goes to next stage!"*/ str);
                    return x;
                }
                else if (pen == 1)
                {
                    Console.WriteLine(y.Name + " won on penalties and " + /*goes to next stage!"*/ str);
                    return y;
                }
                else if (pen == 2)
                {

                   
                    Console.WriteLine(x.Name + " won " + extraTime[et] + " during extra time and " +/*goes to next stage!"*/ str);
                    return x;
                }
                else 
                {
                    Console.WriteLine(y.Name + " won " + extraTime[et] + " during extra time and " +/*goes to next stage!"*/ str);
                    return y;

                }
            }
            


            //   Console.WriteLine(x.Name + " VS " + y.Name + " : " + gx + " - " + gy);


        }


        static void Main(string[] args)
        {




            Team russia = new Team("Russia", 90, 0, 0, 0, 0, "");
            Team saudiArabia = new Team("Saudi Arabia", 80, 0, 0, 0, 1, "");
            Team egypt = new Team("Egypt", 86, 0, 0, 0, 2, "");
            Team uruguay = new Team("Uruguay", 88, 0, 0, 0, 3, "");
            var groupA = new List<Team> {
                russia,
                saudiArabia,
                egypt,
                uruguay
            };
            var groupAsort = new List<Team>();

            Team portugal = new Team("Portugal", 96, 0, 0, 0, 0, "");
            Team spain = new Team("Spain", 95, 0, 0, 0, 1, "");
            Team morocco = new Team("Morocco", 85, 0, 0, 0, 2, "");
            Team iran = new Team("Iran", 86, 0, 0, 0, 3, "");
            var groupB = new List<Team> {
                portugal,
                spain,
                morocco,
                iran
            };
            var groupBsort = new List<Team>();


            Team france = new Team("France", 95, 0, 0, 0, 0, "");
            Team australia = new Team("Australia", 85, 0, 0, 0, 1, "");
            Team peru = new Team("Peru", 89, 0, 0, 0, 2, "");
            Team denmark = new Team("Denmark", 89, 0, 0, 0, 3, "");
            var groupC = new List<Team> {
                france,
                australia,
                peru,
                denmark
            };
            var groupCsort = new List<Team>();


            Team argentina = new Team("Argentina", 96, 0, 0, 0, 0, "");
            Team iceland = new Team("Iceland", 89, 0, 0, 0, 1, "");
            Team croatia = new Team("Croatia", 91, 0, 0, 0, 2, "");
            Team nigeria = new Team("Nigeria", 83, 0, 0, 0, 3, "");
            var groupD = new List<Team> {
                argentina,
                iceland,
                croatia,
                nigeria
            };
            var groupDsort = new List<Team>();


            Team brazil = new Team("Brazil", 98, 0, 0, 0, 0, "");
            Team switzerland = new Team("Switzerland", 92, 0, 0, 0, 1, "");
            Team costaRica = new Team("Costa Rica", 86, 0, 0, 0, 2, "");
            Team serbia = new Team("Serbia", 86, 0, 0, 0, 3, "");
            var groupE = new List<Team> {
                brazil,
                switzerland,
                costaRica,
                serbia
            };
            var groupEsort = new List<Team>();


            Team germany = new Team("Germany", 99, 0, 0, 0, 0, "");
            Team mexico = new Team("Mexico", 90, 0, 0, 0, 1, "");
            Team sweden = new Team("Sweden", 89, 0, 0, 0, 2, "");
            Team southKorea = new Team("South Korea", 81, 0, 0, 0, 3, "");
            var groupF = new List<Team> {
                germany,
                mexico,
                sweden,
                southKorea
            };
            var groupFsort = new List<Team>();


            Team belgium = new Team("Belgium", 95, 0, 0, 0, 0, "");
            Team panama = new Team("Panama", 83, 0, 0, 0, 1, "");
            Team tunisia = new Team("Tunisia", 88, 0, 0, 0, 2, "");
            Team england = new Team("England", 94, 0, 0, 0, 3, "");
            var groupG = new List<Team> {
                belgium,
                panama,
                tunisia,
                england
            };
            var groupGsort = new List<Team>();


            Team poland = new Team("Poland", 93, 0, 0, 0, 0, "");
            Team senegal = new Team("Senegal", 87, 0, 0, 0, 1, "");
            Team colombia = new Team("Colombia", 92, 0, 0, 0, 2, "");
            Team japan = new Team("Japan", 82, 0, 0, 0, 3, "");
            var groupH = new List<Team> {
                poland,
                senegal,
                colombia,
                japan
            };
            

            

            var groups = new List<List<Team>>()
            {
                groupA,
                groupB,
                groupC,
                groupD,
                groupE,
                groupF,
                groupG,
                groupH
            };




            var groupHsort = new List<Team>();

            var groupsSort = new List<List<Team>>()
            {
                groupAsort,
                groupBsort,
                groupCsort,
                groupDsort,
                groupEsort,
                groupFsort,
                groupGsort,
                groupHsort
            };

            

            Console.WriteLine("Press enter to start World Cup 2018 simulation!");

            List<Team> progress = new List<Team>();

            for (int i = 0; i < 8; i++)
            {
                Console.Read();
                ResultGroup(groups[i][0], groups[i][1]);
                ResultGroup(groups[i][2], groups[i][3]);
                ResultGroup(groups[i][0], groups[i][2]);
                ResultGroup(groups[i][1], groups[i][3]);
                ResultGroup(groups[i][0], groups[i][3]);
                ResultGroup(groups[i][1], groups[i][2]);

                groupsSort[i] = groups[i].OrderByDescending(c => c.Points).ThenByDescending(c => (c.Scored - c.Conceded)).ThenByDescending(c => c.Scored).ThenByDescending(c => c.Conceded).ToList();

                Console.WriteLine();

                foreach (Team x in groupsSort[i])
                {
                   
                    Console.WriteLine("NAME:{0} / POINTS:{1} / SCORED:{2} / CONCEDED:{3} / GOAL DIFFERENCE:{4}", x.Name, x.Points, x.Scored, x.Conceded, (x.Scored - x.Conceded));
                    
                }

                progress.Add(groupsSort[i][0]);
                progress.Add(groupsSort[i][1]);

                Console.Read();


            }

 /*

            groupAsort = groupA.OrderByDescending(c => c.Points).ThenByDescending(c => (c.Scored - c.Conceded)).ThenByDescending(c => c.Scored).ThenByDescending(c => c.Conceded).ToList();
            groupBsort = groupB.OrderByDescending(c => c.Points).ThenByDescending(c => (c.Scored - c.Conceded)).ThenByDescending(c => c.Scored).ThenByDescending(c => c.Conceded).ToList();
            groupCsort = groupC.OrderByDescending(c => c.Points).ThenByDescending(c => (c.Scored - c.Conceded)).ThenByDescending(c => c.Scored).ThenByDescending(c => c.Conceded).ToList();
            groupDsort = groupD.OrderByDescending(c => c.Points).ThenByDescending(c => (c.Scored - c.Conceded)).ThenByDescending(c => c.Scored).ThenByDescending(c => c.Conceded).ToList();
            groupEsort = groupE.OrderByDescending(c => c.Points).ThenByDescending(c => (c.Scored - c.Conceded)).ThenByDescending(c => c.Scored).ThenByDescending(c => c.Conceded).ToList();
            groupFsort = groupF.OrderByDescending(c => c.Points).ThenByDescending(c => (c.Scored - c.Conceded)).ThenByDescending(c => c.Scored).ThenByDescending(c => c.Conceded).ToList();
            groupGsort = groupG.OrderByDescending(c => c.Points).ThenByDescending(c => (c.Scored - c.Conceded)).ThenByDescending(c => c.Scored).ThenByDescending(c => c.Conceded).ToList();
            groupHsort = groupH.OrderByDescending(c => c.Points).ThenByDescending(c => (c.Scored - c.Conceded)).ThenByDescending(c => c.Scored).ThenByDescending(c => c.Conceded).ToList();

            for (int i = 0; i < 8; i++)
            {
                foreach (Team x in groups[i])
                {
                    Console.Read();
                    Console.WriteLine("NAME:{0} / POINTS:{1} / SCORED:{2} / CONCEDED:{3} / GOAL DIFFERENCE:{4}", x.Name, x.Points, x.Scored, x.Conceded, (x.Scored-x.Conceded));
                    Console.Read();
                }

            }

*/
/*
            List<Team> progress = new List<Team>();

            progress.Add(groupAsort[0]);
            progress.Add(groupAsort[1]);
            progress.Add(groupBsort[0]);
            progress.Add(groupBsort[1]);
            progress.Add(groupCsort[0]);
            progress.Add(groupCsort[1]);
            progress.Add(groupDsort[0]);
            progress.Add(groupDsort[1]);
            progress.Add(groupEsort[0]);
            progress.Add(groupEsort[1]);
            progress.Add(groupFsort[0]);
            progress.Add(groupFsort[1]);
            progress.Add(groupGsort[0]);
            progress.Add(groupGsort[1]);
            progress.Add(groupHsort[0]);
            progress.Add(groupHsort[1]);

*/
            List<Team> quarterfinal = new List<Team>();
            string quarter = "goes to quarterfinal!\n";


            Console.WriteLine();

            Console.WriteLine("Teams that progressed from group stage to knockout phase are: ");

            for (int i = 0; i < 16; i++)
            {               
                Console.WriteLine(progress[i].Name + " ");
            }

            Console.WriteLine();

            Console.ReadLine();

            quarterfinal.Add(ResultKnock(progress[4], progress[7], quarter));
            quarterfinal.Add(ResultKnock(progress[0], progress[3], quarter));
            quarterfinal.Add(ResultKnock(progress[2], progress[1], quarter));
            quarterfinal.Add(ResultKnock(progress[6], progress[5], quarter));
            quarterfinal.Add(ResultKnock(progress[8], progress[11], quarter));
            quarterfinal.Add(ResultKnock(progress[12], progress[15], quarter));
            quarterfinal.Add(ResultKnock(progress[10], progress[9], quarter));
            quarterfinal.Add(ResultKnock(progress[14], progress[13], quarter));




            //   Console.WriteLine();
         

            List<Team> semifinal = new List<Team>();
            string semi = "goes to semifinal!\n";

            Console.WriteLine();

            Console.ReadLine();

            semifinal.Add(ResultKnock(quarterfinal[0], quarterfinal[1], semi));
            semifinal.Add(ResultKnock(quarterfinal[4], quarterfinal[5], semi));
            semifinal.Add(ResultKnock(quarterfinal[6], quarterfinal[7], semi));
            semifinal.Add(ResultKnock(quarterfinal[2], quarterfinal[3], semi));

            

            List<Team> final = new List<Team>();
            List<Team> third = new List<Team>();
            string fin = "goes to final!\n";

            Console.WriteLine();

            Console.ReadLine();

            final.Add(ResultKnock(semifinal[0], semifinal[1], fin));
            final.Add(ResultKnock(semifinal[2], semifinal[3], fin));


            for (int o = 0; o < semifinal.Capacity; o++)
            {
                if (final.Contains(semifinal[o]))
                {
                    continue;
                }
                else
                {
                    third.Add(semifinal[o]);
                }
            }

            string win = "wins the World Cup!!!\n";
            string bronze = "finishes third!\n";

            Console.WriteLine();

            Console.ReadLine();

            ResultKnock(third[0], third[1], bronze);

            Console.WriteLine();

            Console.ReadLine();

            ResultKnock(final[0], final[1], win);
            
/*
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(third[i].Name);
            }
*/
            Console.WriteLine("\nTHE END");
            
            Console.ReadLine();

            

        }

        







        






    }
}

