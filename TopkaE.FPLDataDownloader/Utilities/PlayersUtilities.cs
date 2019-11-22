﻿namespace TopkaE.FPLDataDownloader.Utilities
{
    public static class PlayersUtilities
    {
        public static string GetTeamName(int teamCode)
        {
            string teamName = string.Empty;
            //use the constants in the future
            switch (teamCode)
            {
                case 3:
                    teamName = "Arsenal";
                    break;
                case 7:
                    teamName = "Aston Villa";
                    break;
                case 91:
                    teamName = "Bournemouth";
                    break;
                case 36:
                    teamName = "Brighton";
                    break;
                case 90:
                    teamName = "Burnley";
                    break;
                case 8:
                    teamName = "Chelsea";
                    break;
                case 31:
                    teamName = "Crystal Palace";
                    break;
                case 11:
                    teamName = "Everton";
                    break;
                case 13:
                    teamName = "Leicester";
                    break;
                case 14:
                    teamName = "Liverpool";
                    break;
                case 43:
                    teamName = "Manchester City";
                    break;
                case 1:
                    teamName = "Manchester United";
                    break;
                case 4:
                    teamName = "Newcastle";
                    break;
                case 45:
                    teamName = "Norwich";
                    break;
                case 49:
                    teamName = "Sheffield United";
                    break;
                case 20:
                    teamName = "Southampton";
                    break;
                case 6:
                    teamName = "Tottenham";
                    break;
                case 57:
                    teamName = "Watford";
                    break;
                case 21:
                    teamName = "West Ham";
                    break;
                case 39:
                    teamName = "Wolverhampton";
                    break;
                default:
                    break;
            }
            return teamName;

        }
    }
}
