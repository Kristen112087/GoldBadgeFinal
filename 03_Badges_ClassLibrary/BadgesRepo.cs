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

        //public bool AddDoorToBadge(int badgeNum, string door)
        //{
        //    try
        //    {
        //        _employeeBadges[badgeNum].Add(door);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

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

        public bool UpdateDoorOnBadge(int badgeNum, List<string> doors)
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

        public bool RemoveDoorFromBadge(int badgeNum, List<string> doors)
        {
            try
            {
                foreach (List<string> door in doors)
                {
                    if (door.Contains door)
                    {

                    }
                    else
                    {

                    }
                }
            }
            catch
            {
                return false;
            }

        }

    }
}
