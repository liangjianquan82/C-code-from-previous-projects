<%@ Page language="c#" Codebehind="ClientView.aspx.cs" AutoEventWireup="false" Inherits="NrOA.Client.ClientView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�ͻ�������Ϣ��ʾ</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/nroa.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../js/calendar.js"></script>
		<script language="javascript">
		function checksave()
		{
			if (document.addtask.TextBox14.value=="")
			{
				window.alert("�ͻ���Ų���Ϊ��Ŷ��");
				return false;
			}
			else if(document.addtask.TextBox1.value=="")
			{
				window.alert("�ͻ����Ʋ���Ϊ��Ŷ��");
				return false;
			}
			else if(document.addtask.TextBox2.value=="")
			{
				window.alert("�ͻ�ҵ��Ų���Ϊ��Ŷ��");
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
						<td vAlign="middle" align="center" colSpan="2" height="30"><asp:label id="Label_Title" runat="server" Font-Size="Medium" ForeColor="#3399CC" Font-Bold="True">����/�޸Ŀͻ���Ϣ</asp:label></td>
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
										<TD style="HEIGHT: 25px">�ͻ���ţ�</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="TextBox14" runat="server" Width="98%"></asp:TextBox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">�ͻ����ƣ�</TD>
										<TD style="HEIGHT: 25px"><asp:textbox id="TextBox1" runat="server" Width="98%"></asp:textbox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD width="15%">�ͻ�ҵ��ţ�</TD>
										<TD><asp:textbox id="TextBox2" runat="server" Width="98%"></asp:textbox></TD>
										<TD width="5%">&nbsp;</TD>
									</TR>
									<TR>
										<TD>��ϵ�绰��</TD>
										<TD><asp:textbox id="TextBox3" runat="server" Width="98%"></asp:textbox></TD>
										<TD align="center">&nbsp;</TD>
									</TR>
									<TR>
										<TD>�û���ַ��</TD>
										<TD><asp:textbox id="TextBox5" runat="server" Width="98%" TextMode="MultiLine"></asp:textbox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>�ʺţ�</TD>
										<TD><asp:textbox id="TextBox6" runat="server" Width="98%"></asp:textbox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>���룺</TD>
										<TD><asp:textbox id="TextBox7" runat="server" Width="98%"></asp:textbox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>�������ڣ�</TD>
										<TD><asp:textbox id="tbExpectBeginTime" onfocus="calendar()" runat="server"></asp:textbox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>��ͨ���ڣ�</TD>
										<TD><asp:textbox id="tbExpectEndTime" onfocus="calendar()" runat="server"></asp:textbox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>ʹ����Ч�ڣ�</TD>
										<TD><asp:textbox id="Textbox13" onfocus="calendar()" runat="server"></asp:textbox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>���֤���룺</TD>
										<TD><asp:textbox id="TextBox10" runat="server" Width="98%"></asp:textbox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>�ײ����ͣ�</TD>
										<TD><asp:dropdownlist id="DropDownList1" runat="server" Enabled="False"></asp:dropdownlist>
											<asp:DropDownList id="DropDownList3" runat="server"></asp:DropDownList></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>�ɷ������</TD>
										<TD><asp:textbox id="TextBox8" runat="server" Width="98%" TextMode="MultiLine" Height="76px"></asp:textbox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>��ע��</TD>
										<TD><asp:textbox id="TextBox9" runat="server" Width="98%" TextMode="MultiLine" Height="78px"></asp:textbox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>����С����</TD>
										<TD><asp:dropdownlist id="DropDownList2" runat="server"></asp:dropdownlist></TD>
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
