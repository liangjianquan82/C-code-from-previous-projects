<%@ Page language="c#" Codebehind="desktop.aspx.cs" AutoEventWireup="false" Inherits="NrOA.desktop" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>desktop</title>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/nroa.css" type="text/css" rel="stylesheet">
		<style type="text/css">.STYLE3 { FONT-SIZE: 18pt; FONT-FAMILY: "黑体" }
		</style>
	</HEAD>
	<body>
		<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
			<form id="Form1" method="post" runat="server">
				<TBODY>
					<tr>
						<td width="34%" rowspan="2" valign="top">
							<table width="99%" height="100%" border="0" align="center" cellpadding="0" cellspacing="0"
								bgcolor="#deebf5">
								<tr bgcolor="#3e86bd">
									<td height="20" align="center" class="content-top">&nbsp;</td>
									<td width="20%" height="15" align="center" class="content-top"><img src="images/ico.gif" width="14" height="13"></td>
									<td width="76%" height="20" class="content-top"><a href="./Affiche/Affichelist.aspx"><span class="white_font" style="FONT-SIZE:12pt">公司公告</span></a></td>
									<td width="2%" class="content-top-2">&nbsp;</td>
								</tr>
								<tr>
									<td width="2%" class="content-middle">&nbsp;</td>
									<td height="400" colspan="2" valign="top">
										<!--<MARQUEE direction="up" style="HEIGHT: 100%" scrollAmount="3" scrollDelay="2">
											<DIV style=" DISPLAY: inline;  WIDTH: 100%;  HEIGHT: 100%" ms_positioning="FlowLayout"
												id="lbWarn" runat="server">Label</DIV>
										</MARQUEE>-->
										<asp:DataGrid id="DataGrid1"  runat="server" Width="100%" AutoGenerateColumns="False" ShowHeader="False">
											<Columns>
												<asp:BoundColumn DataField="Affiche_content" ReadOnly="True"></asp:BoundColumn>
											</Columns>
										</asp:DataGrid>
									</td>
									<td class="content-middle2">&nbsp;</td>
								</tr>
							</table>
						</td>
						<td width="34%" valign="top">
							<table width="100%" border="0" cellpadding="0" cellspacing="0">
								<TBODY>
									<tr>
										<td width="14%" height="20" align="center" bgcolor="#d2eaf6"><img src="images/i_sort_descen.gif" width="16" height="16"></td>
										<td width="86%" bgcolor="#d2eaf6"><span style="FONT-SIZE:12pt">故障信息</span></td>
									</tr>
									<tr>
										<td height="200" colspan="2" valign="top">
											<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD width="30%">
														<asp:LinkButton id="LinkButton1" runat="server">未处理故障单</asp:LinkButton></TD>
													<TD>
														<asp:Label id="Label2" runat="server" ForeColor="Red">Label</asp:Label></TD>
												</TR>
												<TR>
													<TD>
														<asp:LinkButton id="LinkButton2" runat="server">处理中故障单</asp:LinkButton></TD>
													<TD>
														<asp:Label id="Label4" runat="server" ForeColor="#00C000">Label</asp:Label></TD>
												</TR>
											</TABLE>
										</td>
									</tr>
									<tr>
										<td width="14%" height="20" align="center" bgcolor="#d2eaf6"><img src="images/i_sort_descen.gif" width="16" height="16"></td>
										<td width="86%" bgcolor="#d2eaf6"><span style="FONT-SIZE:12pt">工作信息</span></td>
									</tr>
									<tr>
										<td height="200" colspan="2" valign="top">
											<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD width="30%">
														<asp:LinkButton id="LinkButton6" runat="server">未处理工作</asp:LinkButton></TD>
													<TD>
														<asp:Label id="Label10" runat="server" ForeColor="Red">Label</asp:Label></TD>
												</TR>
												<TR>
													<TD>
														<asp:LinkButton id="LinkButton7" runat="server">处理中工作</asp:LinkButton></TD>
													<TD>
														<asp:Label id="Label12" runat="server" ForeColor="#00C000">Label</asp:Label></TD>
												</TR>
											</TABLE>
										</td>
									</tr>
								</TBODY>
							</table>
						</td>
						<td width="34%" valign="top">
							<table width="100%" border="0" cellpadding="0" cellspacing="0">
								<TBODY>
									<tr>
										<td width="14%" height="20" align="center" bgcolor="#d2eaf6"><img src="images/i_sort_descen.gif" width="16" height="16"></td>
										<td width="86%" bgcolor="#d2eaf6"><span style="FONT-SIZE:12pt">新装信息</span></td>
									</tr>
									<tr>
										<td height="200" colspan="2" valign="top">
											<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD width="30%">
														<asp:LinkButton id="LinkButton3" runat="server">待安装用户</asp:LinkButton></TD>
													<TD>
														<asp:Label id="Label6" runat="server" ForeColor="Red">Label</asp:Label></TD>
												</TR>
												<TR>
													<TD>
														<asp:LinkButton id="LinkButton5" runat="server">安装中用户</asp:LinkButton></TD>
													<TD>
														<asp:Label id="Label8" runat="server" ForeColor="#00C000">Label</asp:Label></TD>
												</TR>
												<TR>
													<TD>
														<asp:LinkButton id="LinkButton4" runat="server">未导入到客户信息</asp:LinkButton></TD>
													<TD>
														<asp:Label id="Label14" runat="server">Label</asp:Label></TD>
												</TR>
											</TABLE>
										</td>
									</tr>
								</TBODY>
							</table>
						</td>
					</tr>
			</form>
			</TBODY></table>
		</TR></TBODY></TABLE></TR></TBODY></FORM></TABLE>
	</body>
</HTML>
