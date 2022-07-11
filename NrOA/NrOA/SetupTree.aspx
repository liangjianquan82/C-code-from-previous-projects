<%@ Page language="c#" Codebehind="SetupTree.aspx.cs" AutoEventWireup="false" Inherits="NrOA.SetupTree" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SetupTree</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="css/nroa.css" type="text/css" rel="stylesheet">
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
									<TD height="20"><asp:label id="Label2" runat="server">设置管理</asp:label></TD>
									<TD height="20"></TD>
								</TR>
								<TR>
									<TD valign="top">
										<iewc:TreeView id="TreeView1" runat="server" SelectedNodeIndex="0">
											<iewc:TreeNode NavigateUrl="Branch/BranchList.aspx" Text="部门管理" Target="right"></iewc:TreeNode>
											<iewc:TreeNode NavigateUrl="Duty/DutyList.aspx" Text="职务管理" Expanded="True" Target="right"></iewc:TreeNode>
											<iewc:TreeNode NavigateUrl="Area/Arealist.aspx" Text="客户小区管理" Expanded="True" Target="right"></iewc:TreeNode>
											<iewc:TreeNode NavigateUrl="ProductType/ProductTypeList.aspx" Text="套餐设置" Expanded="True" Target="right"></iewc:TreeNode>
											<iewc:TreeNode NavigateUrl="Poundage/PoundageList.aspx" Text="分成比例设置" Expanded="True" Target="right"></iewc:TreeNode>
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
