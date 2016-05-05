<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonnelDepartment.aspx.cs" Inherits="Тестовое_задание.PersonnelDepartment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" Font-Strikeout="False" Text="Сотрудники"></asp:Label>
        <br />
    
    </div>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" Width="1106px" OnRowUpdated="GridView1_RowUpdated" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Surname" HeaderText="Фамилия" SortExpression="Surname" />
                <asp:BoundField DataField="Name" HeaderText="Имя" SortExpression="Name" />
                <asp:BoundField DataField="MiddleName" HeaderText="Отчество" SortExpression="MiddleName" />
             
              <asp:TemplateField HeaderText="Роль" SortExpression="Role">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            
                            <asp:ListItem>qa</asp:ListItem>
                            <asp:ListItem>developer</asp:ListItem>
                            <asp:ListItem>business analyst</asp:ListItem>
                            <asp:ListItem>progect manager</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                       <ItemTemplate>
                          <asp:Label ID="Label2" runat="server" Text='<%# Bind("Role") %>'></asp:Label>
                      </ItemTemplate>    
                         </asp:TemplateField>

       
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Phone" HeaderText="Телефон" SortExpression="Phone" />     
                
                

            
                <asp:TemplateField HeaderText="ChiefId" SortExpression="ChiefId">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList3" runat="server"
                                          SelectedIndex='<%# GridViewHelper.GridViewHelper.GetSelectedChief(Eval("ChiefId")) %>'
                                          DataSource='<%# GridViewHelper.GridViewHelper.TitlesOfChief %>'/>                   
                    </EditItemTemplate>
                       <ItemTemplate>
                          <asp:Label ID="Label3" runat="server" Text='<%# Bind("ChiefId") %>'></asp:Label>
                      </ItemTemplate>
             
                         </asp:TemplateField>
          

                  <asp:TemplateField HeaderText="Подразделение" SortExpression="Division">
                      <EditItemTemplate>
                          <asp:DropDownList ID="DropDownList1" runat="server">
                              <asp:ListItem>Отдел разработки ПО</asp:ListItem>
                              <asp:ListItem>Отдел развития ИТ</asp:ListItem>
                              <asp:ListItem>Отдел контроля и качества и процессов ИТ</asp:ListItem> 
                          </asp:DropDownList>
                      </EditItemTemplate>
                      <ItemTemplate>
                          <asp:Label ID="Label1" runat="server" Text='<%# Bind("Division") %>'></asp:Label>
                      </ItemTemplate>
                </asp:TemplateField>
             
                
                   <asp:CommandField ShowEditButton="True" />
            </Columns>
            

        </asp:GridView>
        <br />
        <asp:Button ID="btnShowHierarchy" runat="server" OnClick="btnShowHierarchy_Click" Text="Показать иерархию связей" />
        &nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Сохранить содержимое в файл" Width="204px" />
        <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Показать содержимое файла" />
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PersonnelDepartmentDBConnectionString %>" DeleteCommand="DELETE FROM [Employee] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Employee] ([Surname], [Name], [MiddleName], [Role], [Email], [Phone], [ChiefId], [Division]) VALUES (@Surname, @Name, @MiddleName, @Role, @Email, @Phone, @ChiefId, @Division)" SelectCommand="SELECT * FROM [Employee]"
             UpdateCommand="UPDATE [Employee] SET [Surname] = @Surname, [Name] = @Name, [MiddleName] = @MiddleName, [Role] = @Role, [Email] = @Email, [Phone] = @Phone, [ChiefId] = @ChiefId, [Division] = @Division WHERE [Id] = @Id"
            >
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Surname" Type="String" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="MiddleName" Type="String" />
                <asp:Parameter Name="Role" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="Phone" Type="Decimal" />
                <asp:Parameter Name="ChiefId" Type="Int32" />
                <asp:Parameter Name="Division" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Surname" Type="String" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="MiddleName" Type="String" />
                <asp:Parameter Name="Role" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="Phone" Type="Decimal" />
                <asp:Parameter Name="ChiefId" Type="Int32" />
                <asp:Parameter Name="Division" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:Label ID="lbSurname" runat="server" Text="Фамилия"></asp:Label>
        <asp:TextBox ID="tbSurname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbSurname" ErrorMessage="пожалуйста, заполните данное поле" ForeColor="Red" ValidationGroup="test"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbName" runat="server" Text="Имя"></asp:Label>
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbName" ErrorMessage="пожалуйста, заполните данное поле" ForeColor="Red" ValidationGroup="test"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbMiddleName" runat="server" Text="Отчество"></asp:Label>
        <asp:TextBox ID="tbMiddleName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbMiddleName" ErrorMessage="пожалуйста, заполните данное поле" ForeColor="Red" ValidationGroup="test"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbRole" runat="server" Text="Роль"></asp:Label>
        <asp:DropDownList ID="ddlRole" runat="server">
            <asp:ListItem>qa</asp:ListItem>
            <asp:ListItem>developer</asp:ListItem>
            <asp:ListItem>business analyst</asp:ListItem>
            <asp:ListItem>project manager</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="lbEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbEmail" ErrorMessage="пожалуйста, заполните данное поле" ForeColor="Red" ValidationGroup="test"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbPhone" runat="server" Text="Телефон"></asp:Label>
        <asp:TextBox ID="tbPhone" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbPhone" ErrorMessage="пожалуйста, заполните данное поле" ForeColor="Red" ValidationGroup="test"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lbChief" runat="server" Text="Руководитель"></asp:Label>
        <asp:DropDownList ID="ddlChiefs" runat="server" OnSelectedIndexChanged="ddlChiefs_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lbDivision" runat="server" Text="Подразделение"></asp:Label>
&nbsp;&nbsp;
        &nbsp;
        <asp:DropDownList ID="ddlDivision" runat="server">
            <asp:ListItem>Отдел разработки ПО</asp:ListItem>
            <asp:ListItem>Отдел контроля и качества и процессов ИТ</asp:ListItem>
            <asp:ListItem>Отдел развития ИТ</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Добавить" ValidationGroup="test" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>
