<%@ Page language="c#" Codebehind="edchargeview.aspx.cs" AutoEventWireup="false" Inherits="NrOA.CheckAccount.edchargeview" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>edchargeview</title>
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
						<td class="content-middle" width="2%" style="HEIGHT: 13px">&nbsp;</td>
						<td vAlign="middle" align="center" colSpan="2" height="13" style="HEIGHT: 13px"><asp:label id="Label_Title" runat="server" Font-Bold="True" ForeColor="#3399CC" Font-Size="Medium">�ͻ�ҵ����޸�</asp:label></td>
						<td class="content-middle2" style="HEIGHT: 13px">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-middle" width="2%">&nbsp;</td>
						<td vAlign="middle" align="right" colSpan="2" height="30"><FONT face="����"></FONT></td>
						<td class="content-middle2">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-middle" width="2%">&nbsp;</td>
						<td vAlign="top" colSpan="2"><FONT face="����">
								<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
									<TR>
										<TD style="HEIGHT: 25px">�ͻ����ƣ�</TD>
										<TD width="80%">
											<asp:TextBox id="ClientName" runat="server" Width="98%"></asp:TextBox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">�ͻ�ҵ��ţ�</TD>
										<TD>
											<asp:TextBox id="ClientOperationID" runat="server" Width="98%"></asp:TextBox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
										<TD>&nbsp;</TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
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
