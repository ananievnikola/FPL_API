using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using TopkaE.FPLDataDownloader.Models.InputModels;
using TopkaE.FPLDataDownloader.Models.OutputModels;
using TopkaE.FPLDataDownloader.Extensions;

namespace TopkaE.FPLDataDownloader.Repository
{
    public class MariaDBPlayerRepository : IPlayerRepository
    {
        private string _connectionString = string.Empty;
        public MariaDBPlayerRepository(IConfiguration config) 
        {
            Configuration = config;
            _connectionString = Configuration["MariaDBConnection"];
        }

        public IConfiguration Configuration { get; }

        public IEnumerable<Player> GetAll(int? points)
        {
            List<Player> players = new List<Player>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("fpldatabase.SP_Players_GetAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        players.Add(this.MapElement(reader));
                    }
                }
            }
            return players;
        }

        public Player GetById(int id)
        {
            Player player = null;
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("fpldatabase.SP_Players_GetById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PlayerId", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        player = this.MapElement(reader);
                    }
                }
            }
            return player;
        }

        public IEnumerable<EventTransfers> GetMostTransferedIn(int? top)
        {
            List<EventTransfers> players = new List<EventTransfers>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("fpldatabase.SP_Players_MostTransferedIn", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Top", top);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        players.Add(this.MapEventTransfer(reader));
                    }
                }
            }
            return players;
        }

        public IEnumerable<EventTransfers> GetMostTransferedOut(int? top)
        {
            List<EventTransfers> players = new List<EventTransfers>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("fpldatabase.SP_Players_MostTransferedOut", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Top", top);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        players.Add(this.MapEventTransfer(reader));
                    }
                }
            }
            return players;
        }

        public IEnumerable<MostGoals> GetMostGoals(int? top)
        {
            List<MostGoals> players = new List<MostGoals>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("fpldatabase.SP_Players_MostGoals", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Top", top);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        players.Add(this.MapMostGoals(reader));
                    }
                }
            }
            return players;
        }

        public IEnumerable<MostGoals> GetMostGoalsForTeam()
        {
            List<MostGoals> players = new List<MostGoals>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("fpldatabase.SP_Players_MostGoalsForTeam", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        players.Add(this.MapMostGoals(reader));
                    }
                }
            }
            return players;
        }

        public IEnumerable<MostGoals> GetMostGoalsInvovement(int? top)
        {
            List<MostGoals> players = new List<MostGoals>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("fpldatabase.SP_Players_MostGoalsInvovement", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Top", top);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        players.Add(this.MapMostGoals(reader));
                    }
                }
            }
            return players;
        }

        //If it is not too slow - refactor to use reflection instead
        private Player MapElement(MySqlDataReader reader)
        {
            Player currentPlayer = new Player();
            currentPlayer.Id = reader.GetInt32("Id");
            currentPlayer.ChanceOfPlayingNextRound = reader.SaveReadSByte("ChanceOfPlayingNextRound");
            currentPlayer.ChanceOfPlayingThisRound = reader.SaveReadSByte("ChanceOfPlayingThisRound");
            currentPlayer.Code = reader.GetInt32("Code");
            currentPlayer.CostChangeEvent = reader.GetInt16("CostChangeEvent");
            currentPlayer.CostChangeEventFall = reader.GetInt16("CostChangeEventFall");
            currentPlayer.CostChangeStart = reader.GetInt16("CostChangeStart");
            currentPlayer.CostChangeStartFall = reader.GetInt16("CostChangeStartFall");
            currentPlayer.DreamteamCount = reader.GetByte("DreamteamCount");
            currentPlayer.ElementType = reader.GetByte("ElementType");
            currentPlayer.EpNext = reader.GetFloat("EpNext");
            currentPlayer.EpThis = reader.GetFloat("EpThis");
            currentPlayer.EventPoints = reader.GetSByte("EventPoints");
            currentPlayer.FirstName = reader.GetString("FirstName");
            currentPlayer.Form = reader.GetFloat("Form");
            currentPlayer.InDreamteam = reader.GetBoolean("InDreamteam");
            currentPlayer.News = reader.GetString("News");
            currentPlayer.NewsAdded = reader.SaveReadDateTime("NewsAdded");//reader.GetDateTime("NewsAdded");
            currentPlayer.NowCost = reader.GetInt32("NowCost");
            currentPlayer.Photo = reader.GetString("Photo");
            //Change to double
            currentPlayer.PointsPerGame = reader.GetFloat("PointsPerGame");
            currentPlayer.SecondName = reader.GetString("SecondName");
            //Change to double
            currentPlayer.SelectedByPercent = reader.GetFloat("SelectedByPercent");
            currentPlayer.Special = reader.GetBoolean("Special");
            currentPlayer.Status = reader.GetString("Status");
            //Review this field. It should be int but it is changed to string in the model (quick fix)
            currentPlayer.Team = reader.GetString("Team");
            currentPlayer.TeamCode = reader.GetByte("TeamCode");
            currentPlayer.TotalPoints = reader.GetInt16("TotalPoints");
            currentPlayer.TransfersIn = reader.GetInt32("TransfersIn");
            currentPlayer.TransfersInEvent = reader.GetInt32("TransfersInEvent");
            currentPlayer.TransfersOut = reader.GetInt32("TransfersOut");
            currentPlayer.TransfersOutEvent = reader.GetInt32("TransfersOutEvent");
            currentPlayer.ValueForm = reader.GetFloat("ValueForm");
            currentPlayer.ValueSeason = reader.GetFloat("ValueSeason");
            currentPlayer.WebName = reader.GetString("WebName");
            currentPlayer.Minutes = reader.GetInt16("Minutes");
            currentPlayer.GoalsScored = reader.GetByte("GoalsScored");
            currentPlayer.Assists = reader.GetByte("Assists");
            currentPlayer.CleanSheets = reader.GetByte("CleanSheets");
            currentPlayer.GoalsConceded = reader.GetByte("GoalsConceded");
            currentPlayer.OwnGoals = reader.GetByte("OwnGoals");
            currentPlayer.PenaltiesSaved = reader.GetByte("PenaltiesSaved");
            currentPlayer.PenaltiesMissed = reader.GetByte("PenaltiesMissed");
            currentPlayer.YellowCards = reader.GetByte("YellowCards");
            currentPlayer.RedCards = reader.GetByte("RedCards");
            currentPlayer.Saves = reader.GetByte("Saves");
            currentPlayer.Bonus = reader.GetByte("Bonus");
            currentPlayer.Bps = reader.GetInt32("Bps");
            currentPlayer.Influence = reader.GetFloat("Influence");
            currentPlayer.Creativity = reader.GetFloat("Creativity");
            currentPlayer.IctIndex = reader.GetFloat("IctIndex");
            currentPlayer.TeamName = reader.GetString("TeamName");
            return currentPlayer;
        }

        private EventTransfers MapEventTransfer(MySqlDataReader reader)
        {
            EventTransfers et = new EventTransfers();
            et.Id = reader.GetInt32("Id");
            et.FirstName = reader.GetString("FirstName");
            et.SecondName = reader.GetString("SecondName");
            et.TeamName = reader.GetString("TeamName");
            et.TransfersInEvent = reader.GetInt32("TransfersInEvent");
            et.TransfersOutEvent = reader.GetInt32("TransfersOutEvent");
            et.SelectedByPercent = reader.GetString("SelectedByPercent");
            return et;
            
        }

        private MostGoals MapMostGoals(MySqlDataReader reader)
        {
            MostGoals player = new MostGoals();
            player.Id = reader.GetInt32("Id");
            player.FirstName = reader.GetString("FirstName");
            player.SecondName = reader.GetString("SecondName");
            player.TeamName = reader.GetString("TeamName");
            player.GoalsScored = reader.GetInt32("GoalsScored");
            player.Assists = reader.GetInt32("Assists");
            long? overall = reader.SaveReadInt64("Overall");
            if (overall != null)
            {
                player.Overall = (int)overall;
            }
            else
            {
                player.Overall = null;
            }
            return player;
        }


    }
}
