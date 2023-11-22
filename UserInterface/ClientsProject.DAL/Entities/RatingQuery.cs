using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsProject.DAL.Entities
{
    public class RatingQuery
    {
        public string Name { get; set; } = null!;
        public int Count { get; set; }
    }
}
