<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RegistrationWebApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <table>
               <tr>
                   <td>Username</td>
                   <td>
                       <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Password</td>
                   <td>
                       <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                      
                       
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:HiddenField ID="userhdn" runat="server" />
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>

                   </td>
                   <td>  
                        <asp:Label ID="Label1" runat="server"></asp:Label>  
                    </td>  
               </tr>
           </table>
        </div>
    </form>
</body>
</html>
