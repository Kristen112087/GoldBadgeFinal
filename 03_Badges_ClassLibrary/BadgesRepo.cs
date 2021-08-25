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
        //public BadgesRepo GetBadgeByBadgeId(int badgeNum)
        //{
        //    return badgeNum.Where(b => b. == badgeNum).FirstOrDefault();
        //}

        //public bool UpdateBadge(int badgeNum, List<string> doors)
        //{
            
        //    // return badgeNum where badgeNum == badgeNum .FirstOrDefault();
        //    // we want to return the badge that matches the userInput, so the user can update it 
        //}
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
        // Do i need either of these below? or would these both be the same thing as UpdateBadge?

        //public bool AddDoorsToBadge(int badgeNum, List<string> doors)
        //{
        //    try
        //    {
        //        _employeeBadges[badgeNum] = doors;
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public bool AddAnotherDoorToBadge(int badgeNum, List<string> doors)
        {
            try
            {
                _employeeBadges.Add(badgeNum, List<string> doors);
                return true
            }
            catch
            {
                return false;
            }
        }



    }
}
