<%@ Page language="c#" Codebehind="BackFundView.aspx.cs" AutoEventWireup="false" Inherits="NrOA.CheckAccount.BackFundView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BackFundView</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../css/nroa.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../js/calendar.js"></script>
		<script language="javascript">
		function checksave()
		{
			if (document.addtask.DropDownList5.value=="")
			{
				window.alert("�ͻ����Ʋ���Ϊ��Ŷ��");
				return false;
			}			
			if (document.addtask.DropDownList1.value=="-��ѡ�����-")
			{
				window.alert("��ѡ����ݣ�");
				return false;
			}
			if (document.addtask.DropDownList2.value=="-��ѡ���·�-")
			{
				window.alert("��ѡ���·ݣ�");
				return false;
			}
		}
		</script>
	</HEAD>
	<body>
		<table cellSpacing="0" cellPadding="0" width="99%" align="center" border="0">
			<FORM id="addtask" method="post" runat="server">
				<TBODY>
					<tr>
						<td class="content-top" colSpan="3" height="20">&nbsp;</td>
						<td class="content-top-2" width="2%">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-middle" width="2%">&nbsp;</td>
						<td vAlign="middle" align="center" colSpan="2" height="30"><asp:label id="Label_Title" runat="server" Font-Size="Medium" ForeColor="#3399CC" Font-Bold="True">����/�޸Ļؿ���Ϣ</asp:label></td>
						<td class="content-middle2">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-middle" width="2%">&nbsp;</td>
						<td vAlign="middle" align="right" colSpan="2" height="30"><asp:button id="ok2" runat="server" Text="����"></asp:button><asp:button id="Button11" runat="server" Text="����"></asp:button></td>
						<td class="content-middle2">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-middle" width="2%">&nbsp;</td>
						<td vAlign="top" colSpan="2"><FONT face="����">
								<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
									<TR>
										<TD style="HEIGHT: 25px">С������</TD>
										<TD style="HEIGHT: 25px">
											<asp:DropDownList id="DropDownList4" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">�ͻ����ƣ�</TD>
										<TD style="HEIGHT: 25px">
											<asp:DropDownList id="DropDownList5" runat="server" AutoPostBack="True"></asp:DropDownList>
											<asp:TextBox id="TextBox1" runat="server"></asp:TextBox>
											<asp:Button id="Button2" runat="server" Text="�鿴"></asp:Button></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD width="15%">�ͻ�ҵ��ţ�</TD>
										<TD><asp:textbox id="TextBox2" runat="server" Width="98%"></asp:textbox></TD>
										<TD width="5%">&nbsp;</TD>
									</TR>
									<TR>
										<TD>�ؿ</TD>
										<TD>
											<asp:TextBox id="TextBox4" runat="server" Width="98%">0</asp:TextBox></TD>
										<TD align="center">&nbsp;</TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 26px">�ֳɱ�����</TD>
										<TD style="HEIGHT: 26px">
											<asp:DropDownList id="DropDownList3" runat="server"></asp:DropDownList></TD>
										<TD style="HEIGHT: 26px">&nbsp;</TD>
									</TR>
									<TR>
										<TD>ѡ�����£�</TD>
										<TD><asp:dropdownlist id="DropDownList1" runat="server">
												<asp:ListItem Value="-��ѡ�����-">-��ѡ�����-</asp:ListItem>
												<asp:ListItem Value="2007">2007</asp:ListItem>
												<asp:ListItem Value="2008">2008</asp:ListItem>
												<asp:ListItem Value="2009">2009</asp:ListItem>
												<asp:ListItem Value="2010">2010</asp:ListItem>
												<asp:ListItem Value="2011">2011</asp:ListItem>
												<asp:ListItem Value="2012">2012</asp:ListItem>
												<asp:ListItem Value="2013">2013</asp:ListItem>
												<asp:ListItem Value="2014">2014</asp:ListItem>
												<asp:ListItem Value="2015">2015</asp:ListItem>
												<asp:ListItem Value="2016">2016</asp:ListItem>
												<asp:ListItem Value="2017">2017</asp:ListItem>
												<asp:ListItem Value="2018">2018</asp:ListItem>
												<asp:ListItem Value="2019">2019</asp:ListItem>
												<asp:ListItem Value="2020">2020</asp:ListItem>
											</asp:dropdownlist>
											<asp:DropDownList id="DropDownList2" runat="server">
												<asp:ListItem Value="-��ѡ���·�-">-��ѡ���·�-</asp:ListItem>
												<asp:ListItem Value="1">1</asp:ListItem>
												<asp:ListItem Value="2">2</asp:ListItem>
												<asp:ListItem Value="3">3</asp:ListItem>
												<asp:ListItem Value="4">4</asp:ListItem>
												<asp:ListItem Value="5">5</asp:ListItem>
												<asp:ListItem Value="6">6</asp:ListItem>
												<asp:ListItem Value="7">7</asp:ListItem>
												<asp:ListItem Value="8">8</asp:ListItem>
												<asp:ListItem Value="9">9</asp:ListItem>
												<asp:ListItem Value="10">10</asp:ListItem>
												<asp:ListItem Value="11">11</asp:ListItem>
												<asp:ListItem Value="12">12</asp:ListItem>
											</asp:DropDownList></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>��¼�ˣ�</TD>
										<TD><asp:textbox id="TextBox11" runat="server" Width="98%" Enabled="False"></asp:textbox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>��¼ʱ�䣺</TD>
										<TD><asp:textbox id="TextBox12" runat="server" Enabled="False"></asp:textbox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD align="right" colSpan="3"><asp:button id="ok" runat="server" Text="����"></asp:button><asp:button id="Button1" runat="server" Text="����"></asp:button></TD>
									</TR>
									<TR>
										<TD colSpan="3"><asp:textbox id="tmpTaskID" runat="server" Visible="False"></asp:textbox><asp:textbox id="tmpReturnUrl" runat="server" Visible="False"></asp:textbox></TD>
									</TR>
								</TABLE>
							</FONT>
						</td>
						<td class="content-middle2">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-bottom" colSpan="3">&nbsp;</td>
						<td class="content-bottom-2" width="2%">&nbsp;</td>
					</tr>
			</FORM>
			</TBODY></table>
	</body>
</HTML>
