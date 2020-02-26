using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopkaE.FPLDataDownloader.Models.InputModels;
using TopkaE.FPLDataDownloader.Models.OutputModels;

namespace TopkaE.FPLDataDownloader.Repository
{
    public interface IPlayerRepository
    {
        //maybe a mapper between Element and another entity (Player) so I need output models only????
        IEnumerable<Element> GetAll(int? points, string team);
        Element GetById();
        IEnumerable<EventTransfers> GetMostTransferedIn(bool isCsv = false);
        //IEnumerable<Employee> GetAll();
        //Employee GetById(int EmployeeID);
        //void Insert(Employee employee);
        //void Update(Employee employee);
        //void Delete(int EmployeeID);

    }
}
