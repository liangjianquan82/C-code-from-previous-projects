<%@ Page language="c#" Codebehind="AfficheView.aspx.cs" AutoEventWireup="false" Inherits="NrOA.Affiche.AfficheView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AfficheView</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../css/nroa.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../js/calendar.js"></script>
		<script language="javascript">
		function checksave()
		{
			if (document.Form1.tb_Affiche_content.value=="")
			{
				window.alert("公告不能为空哦！");
				return false;
			}
		}
		</script>
	</HEAD>
	<body>
		<table cellSpacing="0" cellPadding="0" width="99%" align="center" border="0">
			<FORM id="Form1" method="post" runat="server">
				<TBODY>
					<tr>
						<td class="content-top" colSpan="3" height="20">&nbsp;</td>
						<td class="content-top-2" width="2%">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-middle" width="2%">&nbsp;</td>
						<td vAlign="middle" align="center" colSpan="2" height="30"><asp:label id="Label_Title" runat="server" Font-Bold="True" ForeColor="#3399CC" Font-Size="Medium">新增/修改公告</asp:label></td>
						<td class="content-middle2">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-middle" width="2%">&nbsp;</td>
						<td vAlign="middle" align="right" colSpan="2" height="30">
							<asp:button id="ok2" runat="server" Text="保存"></asp:button>
							<asp:button id="Button11" runat="server" Text="返回"></asp:button></td>
						<td class="content-middle2">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-middle" width="2%">&nbsp;</td>
						<td vAlign="top" colSpan="2"><FONT face="宋体">
								<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
									<TR>
										<TD style="HEIGHT: 25px" width="150">公告内容：</TD>
										<TD style="HEIGHT: 25px">
											<asp:textbox id="tb_Affiche_content" runat="server" Width="98%" Height="64px" TextMode="MultiLine"></asp:textbox></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 25px" width="150">记录人：</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="tb_RegisterMane" runat="server"></asp:TextBox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD>状态：</TD>
										<TD>
											<asp:DropDownList id="dl_state" runat="server">
												<asp:ListItem Value="0">未发布</asp:ListItem>
												<asp:ListItem Value="1">发布</asp:ListItem>
											</asp:DropDownList></TD>
										<TD align="center">&nbsp;</TD>
									</TR>
									<TR>
										<TD align="right" colSpan="3"><asp:button id="ok" runat="server" Text="保存"></asp:button><asp:button id="Button1" runat="server" Text="返回"></asp:button></TD>
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
						<td class="content-bottom-2" width="2%">&nbsp;
						</td>
					</tr>
			</FORM>
			</TBODY></table>
	</body>
</HTML>
