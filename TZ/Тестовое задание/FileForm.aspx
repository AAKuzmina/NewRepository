<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileForm.aspx.cs" Inherits="Тестовое_задание.FileForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
        <br />
        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Вернуться на главную форму" />
    </form>
</body>
</html>
