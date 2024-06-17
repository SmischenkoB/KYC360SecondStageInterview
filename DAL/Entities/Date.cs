using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Date
    {
        public int Id { get; set; }
        public string? DateType { get; set; }
        public DateTime? DateTime { get; set; }
        public Entity? Entity { get; set; }
    }
}
