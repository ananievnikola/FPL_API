using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopkaE.FPLDataDownloader.Utilities
{
    public class OutputCamelCaseSerializer
    {
        public ContentResult Serialize<T>(T obj, ControllerBase controller)
        {
            //List<Element> players = await _context.Elements.ToListAsync();
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultPropertyNamesResolver()
            };
            return controller.Content(JsonConvert.SerializeObject(obj, settings));
        }
    }
}
