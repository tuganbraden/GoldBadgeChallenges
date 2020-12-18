using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repository
{
    public class BadgeRepo
    {
        Dictionary<int, List<String>> _badgeDict = new Dictionary<int, List<String>>();
        
        // CREATE
        public void AddBadge(Badge badge)
        {
            _badgeDict.Add(badge.BadgeID, badge.Doors);
        }
        
        // READ
        public Dictionary<int, List<String>> GetBadgeDict()
        {
            return _badgeDict;
        }

        // UPDATE
        public bool UpdateBadge(Badge newInfo)
        {
            if (newInfo != null)
            {
                _badgeDict[newInfo.BadgeID] = newInfo.Doors;
                return true;
            }
            else
            {
                return false;
            }
        }

        // DELETE
        public bool RemoveBadge(int badgeID)
        {
            if(_badgeDict[badgeID] != null)
            {
                _badgeDict.Remove(badgeID);
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
