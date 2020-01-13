using System;
using System.Collections.Generic;
using System.Text;
using TopkaE.FPLDataDownloader.Models.InputModels;

namespace TopkaE.FPLDataDownloader.Models.OutputModels
{
    public class MostGoals : PlayerModelBase, IOutputModel
    {
        public MostGoals(Element player)
        {
            this.Map(player);
        }

        public int Goals { get; set; }
        public int Assists { get; set; }

        public void Map(IFPLModel player)
        {
            Element pl = player as Element;
            this.FirstName = pl.FirstName;
            this.SecondName = pl.SecondName;
            this.TeamName = pl.TeamName;
            this.Goals = pl.GoalsScored;
            this.Assists = pl.Assists;
        }

        public static List<MostGoals> MapList(List<Element> inputModel)
        {
            List<MostGoals> result = new List<MostGoals>();
            foreach (var item in inputModel)
            {
                result.Add(new MostGoals(item));
            }
            return result;
        }
    }
}
