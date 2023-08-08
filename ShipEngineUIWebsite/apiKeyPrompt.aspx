<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="apiKeyPrompt.aspx.cs" Inherits="ShipEngineUIWebsite.apiKeyPrompt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
        .auto-style2 {
            height: 50px;
        }
        .auto-style3 {
            height: 27px;
            width: 61px;
        }
        .auto-style4 {
            height: 50px;
            width: 441px;
        }
    </style>
</head>
<body>  
    <form id="form1" runat="server" class="auto-style1">  
    
        <fieldset id="Fieldset1" runat="server" class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="Enter your API Key to begin"></asp:Label>
        </fieldset>

         <fieldset id="Fieldset2" runat="server" class="auto-style4">
             <asp:TextBox ID="apiKeyTextBox" runat="server"  Text="ENTER API KEY TO BEGIN"></asp:TextBox>
        </fieldset>&nbsp;

         <fieldset id="Fieldset3" runat="server" class="auto-style3">
             <asp:Button ID="doneButton" runat="server" Text="DONE" Height="26px" Width="73px" />
        </fieldset><p>
            &nbsp;</p>

    </form>  
</body>
</html>
