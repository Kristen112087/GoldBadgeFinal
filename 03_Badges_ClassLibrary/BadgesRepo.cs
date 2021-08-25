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

        public bool AddDoorsToBadge(int badgeNum, List<string> doors)
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

        //public bool AddAnotherDoorToBadge(int badgeNum, List<string> doors)
        //{
        //    try
        //    {
        //        _employeeBadges.Add(badgeNum, List<string> doors);
        //        return true
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public bool GetBadgeByBadgeId(int badgeNum)
        {
            // return _employeeBadges.Where(b => b. == badgeNum).FirstOrDefault();
            if (_employeeBadges.ContainsKey(badgeNum))
            {
                badgeNum = badgeNum;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateDoorOnBadge(int badgeNum, List<string> doors)
        {
            

        }

        public bool RemoveDoorFromBadge(int badgeNum, List<string> doors)
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

        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _employeeBadges;
        }

    }
}
