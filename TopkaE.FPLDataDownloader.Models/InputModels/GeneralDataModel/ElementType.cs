using System;
using System.Collections.Generic;

namespace TopkaE.FPLDataDownloader.Models.InputModels
{
    public class ElementType : IFPLModel
    {
        public int id { get; set; }
        public string plural_name { get; set; }
        public string plural_name_short { get; set; }
        public string singular_name { get; set; }
        public string singular_name_short { get; set; }
        public int squad_select { get; set; }
        public int squad_min_play { get; set; }
        public int squad_max_play { get; set; }
        public bool ui_shirt_specific { get; set; }
        //TODO: check this
        //public List<object> sub_positions_locked { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
