using System;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.Hosting;
namespace FileHelper
{
    public class FileHelper
    {
       
        public static void ShowEmploees(GridView employeesGridView)
        {
            employeesGridView.DataSource = File.ReadLines(HostingEnvironment.MapPath("~/App_Data/Emploees.txt"),Encoding.GetEncoding("utf-8"));
            employeesGridView.DataBind(); 
        }

        public static void SaveEmploees(GridView employeesGridView)
        {
            using (var stw = new StreamWriter(HostingEnvironment.MapPath("~/App_Data/Emploees.txt")))
            {
                for (int i = 0; i < employeesGridView.Rows.Count; i++)
                {
                    string dataEmployee = "";
                    for (int j = 0; j < employeesGridView.Columns.Count; j++)
                    {
                        dataEmployee += employeesGridView.Rows[i].Cells[j].Text + " ";
                    }
                    stw.WriteLine(dataEmployee);
                }
            }
        }
    }
}