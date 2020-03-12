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

        public IEnumerable<Element> GetAll(int? points, string team)
        {
            List<Element> players = new List<Element>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_Players_GetAll", conn);
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

        public Element GetById(int id)
        {
            Element player = null;
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_Players_GetById", conn);
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
                MySqlCommand cmd = new MySqlCommand("SP_Players_MostTransferedIn", conn);
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
                MySqlCommand cmd = new MySqlCommand("SP_Players_MostTransferedOut", conn);
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
                MySqlCommand cmd = new MySqlCommand("SP_Players_MostGoals", conn);
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
        private Element MapElement(MySqlDataReader reader)
        {
            Element currentPlayer = new Element();
            currentPlayer.Id = reader.GetInt32("Id");
            currentPlayer.ChanceOfPlayingNextRound = reader.SaveReadInt32("ChanceOfPlayingNextRound");
            currentPlayer.ChanceOfPlayingThisRound = reader.SaveReadInt32("ChanceOfPlayingThisRound");
            currentPlayer.Code = reader.GetInt32("Code");
            currentPlayer.CostChangeEvent = reader.GetInt32("CostChangeEvent");
            currentPlayer.CostChangeEventFall = reader.GetInt32("CostChangeEventFall");
            currentPlayer.CostChangeStart = reader.GetInt32("CostChangeStart");
            currentPlayer.CostChangeStartFall = reader.GetInt32("CostChangeStartFall");
            currentPlayer.DreamteamCount = reader.GetInt32("DreamteamCount");
            currentPlayer.ElementType = reader.GetInt32("ElementType");
            currentPlayer.EpNext = reader.GetString("EpNext");
            currentPlayer.EpThis = reader.GetString("EpThis");
            currentPlayer.EventPoints = reader.GetInt32("EventPoints");
            currentPlayer.FirstName = reader.GetString("FirstName");
            currentPlayer.Form = reader.GetString("Form");
            currentPlayer.InDreamteam = reader.GetBoolean("InDreamteam");
            currentPlayer.News = reader.GetString("News");
            currentPlayer.NewsAdded = reader.SaveReadDateTime("NewsAdded");//reader.GetDateTime("NewsAdded");
            currentPlayer.NowCost = reader.GetInt32("NowCost");
            currentPlayer.Photo = reader.GetString("Photo");
            //Change to double
            currentPlayer.PointsPerGame = reader.GetString("PointsPerGame");
            currentPlayer.SecondName = reader.GetString("SecondName");
            //Change to double
            currentPlayer.SelectedByPercent = reader.GetString("SelectedByPercent");
            currentPlayer.Special = reader.GetBoolean("Special");
            currentPlayer.Status = reader.GetString("Status");
            //Review this field. It should be int but it is changed to string in the model (quick fix)
            currentPlayer.Team = reader.GetString("Team");
            currentPlayer.TeamCode = reader.GetInt32("TeamCode");
            currentPlayer.TotalPoints = reader.GetInt32("TotalPoints");
            currentPlayer.TransfersIn = reader.GetInt32("TransfersIn");
            currentPlayer.TransfersInEvent = reader.GetInt32("TransfersInEvent");
            currentPlayer.TransfersOut = reader.GetInt32("TransfersOut");
            currentPlayer.TransfersOutEvent = reader.GetInt32("TransfersOutEvent");
            //Change to double
            currentPlayer.ValueForm = reader.GetString("ValueForm");
            //Change to double
            currentPlayer.ValueSeason = reader.GetString("ValueSeason");
            currentPlayer.WebName = reader.GetString("WebName");
            currentPlayer.Minutes = reader.GetInt32("Minutes");
            currentPlayer.GoalsScored = reader.GetInt32("GoalsScored");
            currentPlayer.Assists = reader.GetInt32("Assists");
            currentPlayer.CleanSheets = reader.GetInt32("CleanSheets");
            currentPlayer.GoalsConceded = reader.GetInt32("GoalsConceded");
            currentPlayer.OwnGoals = reader.GetInt32("OwnGoals");
            currentPlayer.PenaltiesSaved = reader.GetInt32("PenaltiesSaved");
            currentPlayer.PenaltiesMissed = reader.GetInt32("PenaltiesMissed");
            currentPlayer.YellowCards = reader.GetInt32("YellowCards");
            currentPlayer.RedCards = reader.GetInt32("RedCards");
            currentPlayer.Saves = reader.GetInt32("Saves");
            currentPlayer.Bonus = reader.GetInt32("Bonus");
            currentPlayer.Bps = reader.GetInt32("Bps");
            //Change to double
            currentPlayer.Influence = reader.GetString("Influence");
            //Change to double
            currentPlayer.Creativity = reader.GetString("Creativity");
            //Change to double
            currentPlayer.IctIndex = reader.GetString("IctIndex");
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
            return player;
        }
    }
}
