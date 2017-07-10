using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdModelsLayer.Interface
{
    public interface IDvdRepository
    {
        List<Dvd> GetAll();
        Dvd Get(string id);
        void Add(Dvd dvd);
        void Edit(Dvd dvd);
        void Delete(int id);
        List<Dvd> FindAll(string category, string term);
    }
}
