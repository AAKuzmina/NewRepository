using System.Collections.Generic;
using DBHelper;


namespace DataAnalyser
{
    public class DataAnalyser
    {
        public static List<List<string>> CreateHierarchy(List<Employee> employeesList )
        {
            var chirfsIdList = FindChiefs(employeesList);
            var hierarchyList = new List<List<string>>();
            for (int i = 0; i < chirfsIdList.Count; i++)
            {
                hierarchyList.Add(new List<string>());
                hierarchyList[i].Add(DBHelper.DBHelper.GetChief(chirfsIdList[i]));
                for (int j = 0; j < employeesList.Count; j++)
                {
                    if (employeesList[j].ChiefId ==chirfsIdList[i])
                        hierarchyList[i].Add(employeesList[j].Surname+" "+employeesList[j].Name+" "+employeesList[j].MiddleName);
                }   
            }
            return hierarchyList;
        }

        
        public static List<int> FindChiefs(List<Employee> employeesList)
        {
            var chiefsList = new List<int>();
            for (int i = 0; i < employeesList.Count; i++)
            {

                if (employeesList[i].ChiefId != -1 && !chiefsList.Contains(employeesList[i].ChiefId))
                {
                    chiefsList.Add(employeesList[i].ChiefId);
                }
            }
            return chiefsList;
        }

     

    }
}
