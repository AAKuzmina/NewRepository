using System;

namespace GridViewHelper
{
    public class GridViewHelper
    {
        public static string[] TitlesOfChief
        { 
           get { return DBHelper.DBHelper.GetIdAndFIO(DBHelper.DBHelper.GetEmployees()); }
        }

        public static int GetSelectedChief(object title)
        {
            return Array.IndexOf(TitlesOfChief, Convert.ToInt32(title));
        }

       

    }
}
