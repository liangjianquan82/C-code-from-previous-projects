<%@ Page language="c#" Codebehind="CodeView.aspx.cs" AutoEventWireup="false" Inherits="NrOA.CodeChage.CodeView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CodeView</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../css/nroa.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../js/calendar.js"></script>
		<script language="javascript">
		function checksave()
		{
			if (document.addtask.Employee_Nb.value=="")
			{
				window.alert("Ա�����Ų���Ϊ�գ�");
				return false;
			}
			else if (document.addtask.EmployeeName.value=="")
			{
				window.alert("Ա�����Ʋ���Ϊ�գ�");
				return false;
			}
			else if (document.addtask.DropDownList2.value=="-��ѡ����-")
			{
				window.alert("��ѡ���ţ�");
				return false;
			}
			else if (document.addtask.EmployeeName.value=="-��ѡ��ְ��-")
			{
				window.alert("��ѡ��ְ��");
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
						<td vAlign="middle" align="center" colSpan="2" height="30"><asp:label id="Label_Title" runat="server" Font-Size="Medium" ForeColor="#3399CC" Font-Bold="True">�޸�����</asp:label></td>
						<td class="content-middle2">&nbsp;</td>
					</tr>
					<TR>
						<TD class="content-middle" width="2%"></TD>
						<TD vAlign="middle" align="right" colSpan="2"><FONT face="����">
								<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
									<TR>
										<TD width="10%">&nbsp;</TD>
										<TD align="right" width="30%">ְԱ���ƣ�</TD>
										<TD>
											<asp:TextBox id="TextBox4" runat="server" Width="154px" ReadOnly="True"></asp:TextBox></TD>
										<TD width="10%">&nbsp;</TD>
									</TR>
									<TR>
										<TD>&nbsp;</TD>
										<TD align="right" width="30%">ְԱ���ţ�</TD>
										<TD>
											<asp:TextBox id="TextBox5" runat="server" Width="154px" ReadOnly="True"></asp:TextBox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>&nbsp;</TD>
										<TD align="right" width="30%">ԭ���룺</TD>
										<TD>
											<asp:TextBox id="TextBox1" runat="server" Width="154px" TextMode="Password"></asp:TextBox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>&nbsp;</TD>
										<TD align="right" width="30%">�����룺</TD>
										<TD>
											<asp:TextBox id="TextBox2" runat="server" Width="154px" TextMode="Password"></asp:TextBox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>&nbsp;</TD>
										<TD align="right" width="30%">������ȷ�ϣ�</TD>
										<TD>
											<asp:TextBox id="TextBox3" runat="server" Width="154px" TextMode="Password"></asp:TextBox></TD>
										<TD>&nbsp;</TD>
									</TR>
								</TABLE>
							</FONT>
						</TD>
						<TD class="content-middle2"></TD>
					</TR>
					<tr>
						<td class="content-middle" width="2%">&nbsp;</td>
						<td vAlign="middle" align="right" colSpan="2" height="30"><asp:button id="ok2" runat="server" Text="����"></asp:button></td>
						<td class="content-middle2">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-middle" width="2%">&nbsp;</td>
						<td vAlign="top" colSpan="2"><FONT face="����"> </FONT>
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
