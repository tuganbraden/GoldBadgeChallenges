using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<String> Doors { get; set; }

        public Badge() { }

        public Badge(int id, List<String> doors)
        {
            BadgeID = id;
            Doors = doors;
        }
    }
}
