<%@ Page language="c#" Codebehind="t_year_bz_view.aspx.cs" AutoEventWireup="false" Inherits="NrOA.CheckAccount.t_year_bz_view" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>t_year_bz_view</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
						<td class="content-middle" width="2%" style="HEIGHT: 46px">&nbsp;</td>
						<td vAlign="middle" align="center" colSpan="2" height="46" style="HEIGHT: 46px"><asp:label id="Label_Title" runat="server" Font-Bold="True" ForeColor="#3399CC" Font-Size="Medium">��ע��Ϣ</asp:label></td>
						<td class="content-middle2" style="HEIGHT: 46px">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-middle" width="2%">&nbsp;</td>
						<td vAlign="top" colSpan="2"><FONT face="����">
								<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
									<TR>
										<TD style="HEIGHT: 25px">ѡ�����£�</TD>
										<TD style="HEIGHT: 25px"><asp:dropdownlist id="DropDownList1" runat="server" AutoPostBack="True">
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
											</asp:dropdownlist><asp:dropdownlist id="DropDownList2" runat="server" AutoPostBack="True">
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
											</asp:dropdownlist></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">�ͻ����ƣ�</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="tb_name" runat="server"></asp:TextBox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD width="15%">�ͻ�ҵ��ţ�</TD>
										<TD><asp:textbox id="tb_ClientOperationID" runat="server" Width="276px"></asp:textbox></TD>
										<TD width="5%">&nbsp;</TD>
									</TR>
									<TR>
										<TD>������ã�</TD>
										<TD><asp:textbox id="tb_jr" runat="server" Width="150px">0</asp:textbox></TD>
										<TD align="center"></TD>
									</TR>
									<TR>
										<TD>����ѷֳɣ�</TD>
										<TD>
											<asp:textbox id="tb_jrfc" runat="server" Width="150px">0</asp:textbox></TD>
										<TD align="center"><asp:button id="bt_jr" runat="server" Text="��������"></asp:button></TD>
									</TR>
									<TR>
										<TD>ʹ�÷��ã�</TD>
										<TD>
											<asp:textbox id="tb_sy" runat="server" Width="150px">0</asp:textbox></TD>
										<TD align="center"></TD>
									</TR>
									<TR>
										<TD>ʹ�÷ѷֳɣ�</TD>
										<TD>
											<asp:textbox id="tb_syfc" runat="server" Width="150px">0</asp:textbox></TD>
										<TD align="center">
											<asp:button id="bt_sy" runat="server" Text="����ʹ�÷�"></asp:button></TD>
									</TR>
									<TR>
										<TD>ԭʼ�ֳɱ�����</TD>
										<TD>
											<asp:textbox id="tb_fc" runat="server" Width="150px">0</asp:textbox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>�Ƿ��쳣��</TD>
										<TD>
											<asp:RadioButton id="RadioButton1" runat="server" Text="����" TextAlign="Left" Checked="True" AutoPostBack="True"></asp:RadioButton>
											<asp:RadioButton id="RadioButton2" runat="server" Text="�쳣" TextAlign="Left" AutoPostBack="True"></asp:RadioButton></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD>��ע</TD>
										<TD>
											<asp:TextBox id="tb_bz" runat="server" Width="394px" TextMode="MultiLine" Height="62px"></asp:TextBox></TD>
										<TD>&nbsp;<asp:button id="bt_bz" runat="server" Text="���汸ע"></asp:button></TD>
									</TR>
									<TR>
										<TD align="right" colSpan="3"><asp:button id="Button1" runat="server" Text="����"></asp:button></TD>
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
