<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Restrict.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form runat="server">
        <input type="submit" id="Restrict" value="限制下载" onserverclick="Restrict_ServerClick" runat="server" />
        <input type="submit" id="Recover" value="恢复下载" onserverclick="Recover_ServerClick" runat="server" />
        <div style="font-weight: bold" id="Result" runat="server"></div>
    </form>
</body>
</html>
