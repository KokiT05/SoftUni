namespace _07.MilitaryElite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, IPrivate> privates = new Dictionary<string, IPrivate>();
            Dictionary<string, ISoldier> soldiers = new Dictionary<string, ISoldier>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] soldierInformation = input.Split();
                string soldierType = soldierInformation[0];
                string id = soldierInformation[1];
                string firstName = soldierInformation[2];
                string lastName = soldierInformation[3];
                decimal salary = decimal.Parse(soldierInformation[4]);

                if (soldierType == "Private")
                {
                    IPrivate @private = new Private(id, firstName, lastName, salary);
                    privates.Add(id, @private);
                    soldiers.Add(id, @private);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id,
                                                                                firstName,
                                                                                lastName,
                                                                                salary);
                    for (int i = 5; i < soldierInformation.Length; i++)
                    {
                        string soldierId = soldierInformation[i];
                        if (soldiers.ContainsKey(soldierId))
                        {
                            IPrivate currentPrivate = privates[soldierId];
                            lieutenantGeneral.AddPrivate(currentPrivate);
                        }
                    }

                    soldiers.Add(id, lieutenantGeneral);
                }
                else if (soldierType == "Engineer")
                {
                    string corps = soldierInformation[5];

                    if (!Validator.IsValidCorps(corps, 
                        GlobalConstants.CorpsMarines, 
                        GlobalConstants.CorpsAirforces))
                    {
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < soldierInformation.Length; i = i + 2)
                    {
                        string repairName = soldierInformation[i];
                        int repairHour = int.Parse(soldierInformation[i + 1]);
                        IRepair repair = new Repair(repairName, repairHour);
                        engineer.AddRepair(repair);
                    }

                    soldiers.Add(id, engineer);
                }
                else if (soldierType == "Commando")
                {
                    string corps = soldierInformation[5];

                    if (!Validator.IsValidCorps(corps,
                        GlobalConstants.CorpsMarines,
                        GlobalConstants.CorpsAirforces))
                    {
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, corps);
                    for (int i = 6; i < soldierInformation.Length; i++)
                    {
                        string missionCodeName = soldierInformation[i];
                        string missionState = soldierInformation[i+1];

                        if (!Validator.IsValidMissionState(missionState, 
                            GlobalConstants.MissionStateInProgress,
                            GlobalConstants.MissionStateFinished))
                        {
                            continue;
                        }

                        IMissions missions = new Mission(missionCodeName, missionState);
                        commando.AddMission(missions);
                    }

                    soldiers.Add(id, commando);
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(soldierInformation[4]);
                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                }

                input = Console.ReadLine();
            }

            Console.WriteLine();

            foreach (ISoldier soldier in soldiers.Values)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
