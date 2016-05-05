using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DBHelper;


namespace Тестовое_задание
{
    public partial class PersonnelDepartment : System.Web.UI.Page
    {
        private List<Employee> employeesList;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                employeesList = DBHelper.DBHelper.GetEmployees();


                for (int i = 0; i < employeesList.Count; i++)
                {
                    ddlChiefs.Items.Add(employeesList[i].Surname + " " + employeesList[i].Name + " " +
                                        employeesList[i].MiddleName);
                }
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {

            DBHelper.DBHelper.AddEmployee(tbSurname.Text, tbName.Text, tbMiddleName.Text, ddlRole.SelectedValue, tbEmail.Text, Convert.ToInt64(tbPhone.Text), ddlChiefs.SelectedIndex + 1, ddlDivision.Text);
            Response.Redirect("PersonnelDepartment.aspx");
         
        }

        protected void btnShowHierarchy_Click(object sender, EventArgs e)
        {
            List<List<string>> newList = DataAnalyser.DataAnalyser.CreateHierarchy(DBHelper.DBHelper.GetEmployees());
            this.Page.Session["list"] = newList;
            Response.Redirect("Hierarchy.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            FileHelper.FileHelper.SaveEmploees(GridView1);
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            Response.Redirect("FileForm.aspx");
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

          
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DropDownList ddlRoleList = (DropDownList)(GridView1.Rows[e.RowIndex].FindControl("DropDownList2"));
            DropDownList ddlChiefList = (DropDownList)(GridView1.Rows[e.RowIndex].FindControl("DropDownList3"));
            DropDownList ddlDivisionDownList = (DropDownList)(GridView1.Rows[e.RowIndex].FindControl("DropDownList1"));
            if (Convert.ToInt32(ddlChiefList.Text.Substring(0, 1)) == e.RowIndex + 1)
            {
                e.NewValues.Add("ChiefId", -1);
                DBHelper.DBHelper.UpdateEmployee(-1, e.RowIndex + 1);
            }
            else
            {
                 e.NewValues.Add("ChiefId", ddlChiefList.Text.Substring(0,1));
            }

            e.NewValues.Add("Role", ddlRoleList.Text);
           
            e.NewValues.Add("Division", ddlDivisionDownList.Text);
        }

        protected void ddlChiefs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}