<%@ Page language="c#" Codebehind="TrbDTree.aspx.cs" AutoEventWireup="false" Inherits="NrOA.TroubleDeal.TrbDTree" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TrbDTree</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../css/nroa.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body id="nonbg">
		<table width="100%" border="0" align="right" cellpadding="0" cellspacing="0">
			<form id="tree" method="post" runat="server">
				<TBODY>
					<tr>
						<td height="20" colspan="3" class="content-top">&nbsp;&nbsp;</td>
						<td width="4%" class="content-top-2">&nbsp;</td>
					</tr>
					<tr>
						<td width="2%" class="content-middle">&nbsp;</td>
						<td width="94%" height="400" colspan="2" valign="top"><TABLE id="Table2" cellSpacing="1" cellPadding="0" width="100%" border="0">
								<TR>
									<TD height="20"></TD>
									<TD height="20"></TD>
								</TR>
								<TR>
									<TD height="20"><asp:label id="Label2" runat="server">故障处理</asp:label></TD>
									<TD height="20"></TD>
								</TR>
								<TR>
									<TD valign="top">
										<iewc:TreeView id="TreeView1" runat="server">
											<iewc:TreeNode NavigateUrl="TrbDList.aspx?state=new" Text="新故障单" Target="right"></iewc:TreeNode>
											<iewc:TreeNode NavigateUrl="TrbDList.aspx?state=deal" Text="处理中故障单" Expanded="True" Target="right"></iewc:TreeNode>
											<iewc:TreeNode NavigateUrl="TrbDList.aspx?state=end" Text="已处理故障单" Expanded="True" Target="right"></iewc:TreeNode>
											<iewc:TreeNode NavigateUrl="TrbDInput.aspx" Text="故障单导入" Expanded="True" Target="right"></iewc:TreeNode>
										</iewc:TreeView></TD>
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
				</TBODY>
			</form>
		</table>
	</body>
</HTML>
