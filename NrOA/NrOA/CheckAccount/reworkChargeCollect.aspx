<%@ Page language="c#" Codebehind="reworkChargeCollect.aspx.cs" AutoEventWireup="false" Inherits="NrOA.CheckAccount.reworkChargeCollect" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ChargeView</title>
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
						<td class="content-middle" width="2%" style="HEIGHT: 13px">&nbsp;</td>
						<td vAlign="middle" align="center" colSpan="2" height="13" style="HEIGHT: 13px"><asp:label id="Label_Title" runat="server" Font-Bold="True" ForeColor="#3399CC" Font-Size="Medium">�޸Ľɷ���Ϣ</asp:label></td>
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
										<TD style="HEIGHT: 25px">�ͻ�ҵ��ţ�</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="ClientOperationID" runat="server" ReadOnly="True"></asp:TextBox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">�ͻ����ƣ�</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="TextBox4" runat="server" ReadOnly="True"></asp:TextBox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">ԭ�ֳɱ�����</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="Poundage" runat="server" ReadOnly="True">0</asp:TextBox></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">һ���Է��ã�</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="OneOffConnectFees" runat="server">0</asp:TextBox></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">Ǩ�Ʒѣ�</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="MovePay" runat="server">0</asp:TextBox></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">һ��/Ǩ�Ʒֳɱ�����</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="OMPoundage" runat="server">0</asp:TextBox></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">1�£�</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="oneyue" runat="server">0</asp:TextBox>
											<asp:TextBox id="onePoundage" runat="server">0</asp:TextBox></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">2�£�</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="twoyue" runat="server">0</asp:TextBox>
											<asp:TextBox id="twoPoundage" runat="server">0</asp:TextBox></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">3�£�</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="threeyue" runat="server">0</asp:TextBox>
											<asp:TextBox id="threePoundage" runat="server">0</asp:TextBox></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">4�£�</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="fouryue" runat="server">0</asp:TextBox>
											<asp:TextBox id="fourPoundage" runat="server">0</asp:TextBox></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">5�£�</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="fiveyue" runat="server">0</asp:TextBox>
											<asp:TextBox id="fivePoundage" runat="server">0</asp:TextBox></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">6�£�</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="sixyue" runat="server">0</asp:TextBox>
											<asp:TextBox id="sixPoundage" runat="server">0</asp:TextBox></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">7�£�</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="sevenyue" runat="server">0</asp:TextBox>
											<asp:TextBox id="sevenPoundage" runat="server">0</asp:TextBox></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">8�£�</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="eightyue" runat="server">0</asp:TextBox>
											<asp:TextBox id="eightPoundage" runat="server">0</asp:TextBox></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 28px">9�£�</TD>
										<TD style="HEIGHT: 28px">
											<asp:TextBox id="nineyue" runat="server">0</asp:TextBox>
											<asp:TextBox id="ninePoundage" runat="server">0</asp:TextBox></TD>
										<TD style="HEIGHT: 28px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">10�£�</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="tenyue" runat="server">0</asp:TextBox>
											<asp:TextBox id="tenPoundage" runat="server">0</asp:TextBox></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 28px">11�£�</TD>
										<TD style="HEIGHT: 28px">
											<asp:TextBox id="elevenyue" runat="server">0</asp:TextBox>
											<asp:TextBox id="elevenPoundage" runat="server">0</asp:TextBox></TD>
										<TD style="HEIGHT: 28px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">12�£�</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="twelveyue" runat="server">0</asp:TextBox>
											<asp:TextBox id="twelvePoundage" runat="server">0</asp:TextBox></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">��ע��</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="remark" runat="server" Width="98%" TextMode="MultiLine"></asp:TextBox></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px">״̬��</TD>
										<TD style="HEIGHT: 25px">
											<asp:DropDownList id="state" runat="server">
												<asp:ListItem Value="0">-��ѡ��-</asp:ListItem>
												<asp:ListItem Value="1">һ��״̬</asp:ListItem>
												<asp:ListItem Value="2">�쳣</asp:ListItem>
											</asp:DropDownList></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px"></TD>
										<TD style="HEIGHT: 25px"></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px"></TD>
										<TD style="HEIGHT: 25px"></TD>
										<TD style="HEIGHT: 25px"></TD>
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
