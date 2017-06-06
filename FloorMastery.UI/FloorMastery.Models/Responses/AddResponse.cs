using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMastery.Models.Responses
{
    public class AddResponse : Response
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
    }
}
