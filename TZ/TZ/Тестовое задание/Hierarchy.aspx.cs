using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Тестовое_задание
{
    public partial class Hierarchy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<List<string>> newList = (List<List<string>>) this.Page.Session["list"];
        
            for (int i = 0; i <newList.Count; i++)
            {
                
                 Label newLabelChief = new Label
                    {
                        Text = "Руководитель: ",
                        ForeColor = Color.Blue
                    }; 
                    this.Controls.Add(newLabelChief);

                Label newLabelChiefFIO = new Label
                {
                    Text = newList[i][0]+"  "
                };
                this.Controls.Add(newLabelChiefFIO);

                Label newLabelSubordinates = new Label
                {
                    Text = "Подчиненные: ",
                    ForeColor = Color.Blue
                };
                this.Controls.Add(newLabelSubordinates);
                string text = "";
                for (int j = 1; j < newList[i].Count; j++)
                {
                    text += newList[i][j] + ", ";
                }

                Label newLabelSubordinate = new Label
                {
                    Text = text+"<br/>"
                
                };
                this.Controls.Add(newLabelSubordinate);


                
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonnelDepartment.aspx");
        }
    }
}