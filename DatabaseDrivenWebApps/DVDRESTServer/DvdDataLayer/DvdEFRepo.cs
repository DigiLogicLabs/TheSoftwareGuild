using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdModelsLayer;
using DvdDataLayer;
using DvdModelsLayer.Interface;


namespace DvdDataLayer
{
    public class DvdEFRepo : IDvdRepository
    {
        public List<Dvd> GetAll()
        {
            throw new NotImplementedException();
        }

        public Dvd Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Add(Dvd dvd)
        {
            throw new NotImplementedException();
        }

        public void Edit(Dvd dvd)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> FindAll(string category, string term)
        {
            throw new NotImplementedException();
        }
    }
}
