<%@ Page language="c#" Codebehind="CodeTree.aspx.cs" AutoEventWireup="false" Inherits="NrOA.CodeChage.CodeTree" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CodeTree</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="../css/nroa.css" rel="stylesheet" type="text/css">
		<script language="JavaScript" type="text/javascript">
		//
		</script>
		<style type="text/css">
.STYLE3 { FONT-SIZE: 18pt; FONT-FAMILY: "黑体" }
		</style>
	</HEAD>
	<body id="nonbg">
		<table width="100%" border="0" align="right" cellpadding="0" cellspacing="0">
			<form id="Form1" method="post" runat="server">
				<TBODY>
					<tr>
						<td height="20" colspan="3" class="content-top">&nbsp;&nbsp;<asp:Label ID="Label1" runat="server">所有部门</asp:Label></td>
						<td width="4%" class="content-top-2">&nbsp;</td>
					</tr>
					<tr>
						<td width="2%" class="content-middle">&nbsp;</td>
						<td height="400" width="94%" colspan="2" valign="top"><TABLE id="Table2" cellSpacing="1" cellPadding="0" width="100%" border="0">
								<TR>
									<TD height="30"></TD>
									<TD height="30"></TD>
								</TR>
								<TR>
									<TD id="td1" style="DISPLAY: none; BACKGROUND-COLOR: white"><div id="divTree" onMouseOver="TreeList()" onMouseOut="displayDiv()" style="OVERFLOW-Y: auto; Z-INDEX: 999999; OVERFLOW: auto; WIDTH: 140px; POSITION: absolute; TOP: 43px; HEIGHT: 200px; BACKGROUND-COLOR: white">
											<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" align="left">
												<tr>
													<td valign="top" align="left"><iewc:treeview id="Treeview2" runat="server" style="FONT-SIZE: 9pt; CURSOR: hand" BorderStyle="None"
															AutoSelect="True" SelectExpands="True" valign="top" align="left"></iewc:treeview></td>
												</tr>
											</table>
										</div>
									</TD>
									<TD style="DISPLAY: none; BACKGROUND-COLOR: white"></TD>
								</TR>
								<TR>
									<TD height="20"><asp:Label id="Label2" runat="server">部门列表</asp:Label></TD>
									<TD height="20"></TD>
								</TR>
								<TR>
									<TD valign="top"><FONT face="宋体">
											<iewc:TreeView id="TreeView1" runat="server" SelectExpands="True"></iewc:TreeView>
										</FONT><INPUT type="hidden" name="Calling_ID" runat="server" id="module"></TD>
									<TD vAlign="top"></TD>
								</TR>
							</TABLE>
						</td>
						<td width="4%" class="content-middle2">&nbsp;</td>
					</tr>
					<tr>
						<td colspan="3" class="content-bottom">&nbsp;</td>
						<td width="4%" class="content-bottom-2">&nbsp;</td>
					</tr>
			</form>
			</TBODY>
		</table>
	</body>
</HTML>
