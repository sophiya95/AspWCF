<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="RegistrationWebApplication.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
         .auto-style1 {
            width: 100%;
            align-items: center;
        }

        .auto-style2 {
            height: 102px;
            text-align: center;
            font-size: x-large;
            color:brown;
        }
         .tdclass-1{
            padding-left: 35%;
            display: inline-block;
         }
         .tdclass-2{
            width: 75%;
            padding: 12px;
            border: 1px solid #ccc;
            border-radius: 4px;
         }
         #btnSubmit{
          background-color: #4CAF50;
          color: white;
          padding: 16px 32px;
          border: none;
          border-radius: 4px;
          cursor: pointer;
          align-items: center;
          width: 100%;
         /* margin-top: 8%;
          margin-left: 37%;*/
         }
         .btnrow1{
          background-color: #4CAF50;
          color: white;
          padding: 16px 32px;
          border: none;
          border-radius: 4px;
          cursor: pointer;
          align-items: center;
          margin-top: 20.5%;
          margin-left: -107%;
         }
         .btnrow2{
          background-color: #4CAF50;
          color: white;
          padding: 16px 32px;
          border: none;
          border-radius: 4px;
          cursor: pointer;
          align-items: center;
          margin-top: 20.9%;
          margin-left: -162%;
         }
         #loginBtn{
                float: left;
                background-color: #4CAF50;
                border: none;
                color: white;
                padding: 15px 32px;
                text-align: center;
                text-decoration: none;
                display: inline-block;
                font-size: 16px;
         }




     
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:HiddenField ID="Hdn1" runat="server" />
            
              <table class="auto-style1">
                 <tr>
                    <td class="auto-style2" colspan="2"><strong>STUDENT REGISTRATION FORM</strong></td>
                </tr>
                  <tr>
                      <td>
                          <asp:LinkButton ID="loginBtn" runat="server" OnClick="Reg_Click">Login</asp:LinkButton>
                      </td>
                  </tr>
                  
                <tr>

                    <td class="tdclass-1">
                        First Name:
                    </td>
                    <td >
                        <asp:TextBox ID="txtFname" runat="server" class="tdclass-2"></asp:TextBox>

                    </td>
                </tr>
                 <tr>
                    <td class="tdclass-1">
                        Last Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLname" runat="server" class="tdclass-2"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="tdclass-1">
                        Address:
                    </td>
                    <td>
                        <textarea id="txtaddress" cols="20" rows="2" runat="server" class="tdclass-2"></textarea>

                    </td>
                </tr>
                 <tr>
                    <td class="tdclass-1">
                        Gender:
                    </td>
                    <td>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                             <asp:ListItem>Male</asp:ListItem>  
                              <asp:ListItem>Female</asp:ListItem>  
                              <asp:ListItem>Others</asp:ListItem>  
                            

                        </asp:RadioButtonList>
                                

                    </td>
                </tr>
                <tr>
                    <td class="tdclass-1">
                        Course:
                    </td>
                    <td>
                         <asp:DropDownList ID="DropDownList1" runat="server" class="tdclass-2">

                            <asp:ListItem Text="Select Cource" Value="select" Selected="True"></asp:ListItem>  
                            <asp:ListItem Text="MCA" Value="MCA"></asp:ListItem>  
                            <asp:ListItem Text="MBA" Value="MBA"></asp:ListItem>  
                            <asp:ListItem Text="MSC" Value="MSC"></asp:ListItem>


                        </asp:DropDownList>        

                    </td>
                </tr>
                <tr>
                    <td class="tdclass-1">
                        Sports:
                    </td>
                    
                    <td>
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True">
                             <asp:ListItem>Cricket</asp:ListItem>  
                              <asp:ListItem>Football</asp:ListItem>  
                              <asp:ListItem>Basketball</asp:ListItem>  
                               
                        </asp:CheckBoxList>
                          

                    </td>
                </tr>
                 <tr>
                    <td class="tdclass-1">
                        Phone:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" class="tdclass-2"></asp:TextBox>

                    </td>
                </tr>
                 <tr>
                    <td class="tdclass-1">
                        Email:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" class="tdclass-2"></asp:TextBox>

                    </td>
                </tr>
                 <tr>
                    <td class="tdclass-1">
                        Username:
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server" class="tdclass-2"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="tdclass-1">
                        Password:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="tdclass-2"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                       <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />  
                    </td>
                    
                   

                    
                </tr>
                   <tr>  
                    <td colspan="2">  
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>  
                    </td>  
                </tr> 
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                   <Columns>
                       <asp:BoundField DataField="firstname" HeaderText="First Name" />
                       <asp:BoundField DataField="lastname" HeaderText="Last Name" />
                       <asp:BoundField DataField="studaddress" HeaderText="Address" />
                       <asp:BoundField DataField="gender" HeaderText="Gender" />
                       <asp:BoundField DataField="course" HeaderText="Course" />
                       <asp:BoundField DataField="sports" HeaderText="Sports" />
                       <asp:BoundField DataField="phone" HeaderText="Phone" />
                       <asp:BoundField DataField="emailaddress" HeaderText="Email" />
                       <asp:BoundField DataField="username" HeaderText="Username" />
                       <asp:BoundField DataField="password" HeaderText="Password" />
                       
                          
                     <%--   <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="linkview" runat="server" OnClick="linkonclick" Text="ViewDetais" CommandName="ViewDetails" 
                        CommandArgument='<%#Bind("studid") %>'>VIEW</asp:LinkButton>
                   
                </ItemTemplate>
            </asp:TemplateField>
                       --%>
                        <asp:TemplateField HeaderText="Edit">  
                                    <ItemTemplate>  
                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CausesValidation="false"  
                                            CommandArgument=' <%#Bind("studid") %>'  ToolTip="Edit" OnCommand="lnkEdit_Command"/>  
                                        </ItemTemplate>  
                                    </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Delete">  
                                        <ItemTemplate>  
                                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CausesValidation="false"  
  
                                                    CommandArgument='<%#Bind("studid") %>' CommandName="Delete" 
                                                OnClientClick="return confirm('Are you sure you want to delete?')" ToolTip="Delete" 
                                                OnCommand="lnkDelete_Command"/>  
                                            </ItemTemplate>  
                                        </asp:TemplateField>  
                   
                       
                       
                   </Columns>
               </asp:GridView>
               
            </table>
        </div>
    </form>
</body>
</html>
