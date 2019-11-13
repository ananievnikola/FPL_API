using System;
using System.Collections.Generic;
using System.Text;

namespace TopkaE.FPLDataDownloader.Models.InputModels
{
    public interface IFPLModel
    {
        DateTime? LastUpdated { get; set; }
    }
}
