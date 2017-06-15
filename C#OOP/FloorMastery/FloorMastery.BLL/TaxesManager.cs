using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloorMastery.Data.Interfaces;

namespace FloorMastery.BLL
{
    public class TaxesManager
    {
        //factory method returns one of these
        private ITaxesRepository _taxesRepository = null;

        public TaxesManager(ITaxesRepository taxesRepository)
        {
            _taxesRepository = taxesRepository;
        }

    }
}
