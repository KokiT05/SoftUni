using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite
{
    public static class Validator
    {
        public static bool IsValidCorps(string currentCorps, 
            params string[] corps)
        {
            if (corps.Contains(currentCorps))
            {
                return true;
            }

            return false;
        }

        public static bool IsValidMissionState(string currentMissionState,
                                        params string[] missionStates)
        {
            if (missionStates.Contains(currentMissionState))
            {
                return true;
            }

            return false;
        }
    }
}
