using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_ClassLibrary
{
    public class BadgesRepo
    {
        Dictionary<int, List<string>> _employeeBadges = new Dictionary<int, List<string>>();
        public bool CreateNewBadge(int badgeNum)
        {
            try
            {
                _employeeBadges.Add(badgeNum, new List<string>());
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _employeeBadges;
        }
        public List<string> GetDoorsByBadgeId(int badgeNum)
        {
            if (_employeeBadges.ContainsKey(badgeNum))
            {
                return _employeeBadges[badgeNum];
            }
            else
            {
                return new List<string>(); // if badge number doesnt exist, will return empty list of 'doors'
            }
        }
        public bool AddDoorToBadge(int badgeNum, string door)
        {
            try
            {
                _employeeBadges[badgeNum].Add(door);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateBadge(int badgeNum, List<string> doors)
        {
            try
            {
                _employeeBadges[badgeNum] = doors;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveDoorFromBadge(int badgeNum, string door)
        {
            try
            {
                _employeeBadges[badgeNum].Remove(door);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
