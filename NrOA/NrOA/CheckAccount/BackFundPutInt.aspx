<%@ Page language="c#" Codebehind="BackFundPutInt.aspx.cs" AutoEventWireup="false" Inherits="NrOA.CheckAccount.BackFundPutInt" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BackFundPutInt</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../css/nroa.css" type="text/css" rel="stylesheet">
		<script language="JavaScript">
			function addFile()
			{
    			var str = '<br><INPUT type="file" size="50" NAME="File">'
    			document.getElementById('MyFile').insertAdjacentHTML("beforeEnd",str)
			}
		</script>
	</HEAD>
	<body>
		<table cellSpacing="0" cellPadding="0" width="99%" align="center" border="0">
			<form id="Form1" method="post" encType="multipart/form-data" runat="server">
				<TBODY>
					<tr>
						<td class="content-top" colSpan="3" height="20">&nbsp;</td>
						<td class="content-top-2" width="2%">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-middle" width="2%">&nbsp;</td>
						<td vAlign="top" colSpan="2">
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<td><input type="file" size="27" name="File"></td>
									<td><asp:button id="UploadButton" runat="server" Text="导入"></asp:button></td>
									<td><input onclick="addFile()" type="hidden" value="增加(Add)" name="hidden"> <input id="deptid" type="hidden" size="4" name="hidden2" runat="server">
									</td>
								</TR>
							</table>
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td></td>
								</tr>
							</table>
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td></td>
								</tr>
							</table>
						</td>
						<td class="content-middle2">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-bottom" colSpan="3">&nbsp;</td>
						<td class="content-bottom-2" width="2%">&nbsp;</td>
					</tr>
			</form>
			</TBODY>
		</table>
	</body>
</HTML>
