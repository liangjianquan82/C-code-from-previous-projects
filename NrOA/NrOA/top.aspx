<%@ Page language="c#" Codebehind="top.aspx.cs" AutoEventWireup="false" Inherits="NrOA.top" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>top</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Refresh" content="300">
		<LINK href="css/nroa.css" type="text/css" rel="stylesheet">
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		<script language="javascript">	
			
		</script>
	</HEAD>
	<body>
		<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" background="images/di.gif"
			border="0" name="Table1">
			<form id="Form1" method="post" runat="server">
				<TBODY>
					<TR>
						<TD align="left" width="785" style="FONT-WEIGHT: bolder; FONT-SIZE: 20pt; VISIBILITY: visible; WIDTH: 785px; COLOR: #ffffcc; FONT-STYLE: italic; FONT-FAMILY: 幼圆">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;齐瑞</TD>
						<TD class="white_font" align="center" width="188">欢迎您&nbsp;
							<asp:label id="strUserName" runat="server" Width="40px"></asp:label><br>
							<asp:label id="SessNum" runat="server"></asp:label>个用户在线</TD>
						<TD class="white_font" width="44">|&nbsp;<A href="login.aspx?logout=y" target="_parent"><font color="#ffffff">退出</font></A></TD>
						<TD width="6">&nbsp;</TD>
					</TR>
					<tr>
						<td colSpan="6">
							<MARQUEE style="WIDTH: 1010px; HEIGHT: 3px" scrollAmount="3" scrollDelay="2" width="1010"
								height="1">
								<DIV style="DISPLAY: inline; WIDTH: 592px; COLOR: #ffffff; HEIGHT: 15px" ms_positioning="FlowLayout"
									id="lbWarn" runat="server">Label</DIV>
							</MARQUEE>
						</td>
					</tr>
					<tr>
						<td colSpan="6" height="36">
							<table height="25" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
								<tr class="toptd" id="top">
									<td class="topltdbgimg" width="16">&nbsp;</td>
									<td>
										<div align="center"><A href="desktop.aspx" target="main">智能桌面</A></div>
									</td>
									<!--<td><div align="center"><a href="Mode.aspx?mode=0" target="main">工作计划</a></div></td>-->
									<td>
										<div align="center"><A href="CheckAccount/CheckAccount.htm" target="main">对帐管理</A></div>
									</td>
									<td>
										<div align="center"><A href="Client/Client.htm" target="main">客户管理</A></div>
									</td>
									<td>
										<div align="center"><A href="NewAndFinish/NewAndFin.htm" target="main">新装竣工</A></div>
									</td>
									<td>
										<div align="center"><A href="TroubleDeal/TrbD.htm" target="main">故障处理</A></div>
									</td>
									<td>
										<div align="center"><A href="LogManage/LogM.htm" target="main">工作记录</A></div>
									</td>
									<td>
										<div align="center"><A href="Affiche/Affichelist.aspx" target="main">公告管理</A></div>
									</td>
									<td>
										<div align="center"><A href="jxgl/jxgl.htm" target="main">机箱管理</A></div>
									</td>
									<td>
										<div align="center"><A href="Employee/Employee.htm" target="main">员工管理</A></div>
									</td>
									<!--<td>
										<div align="center"><A href=".aspx" target="main">部门管理</A></div>
									</td>-->
									<td>
										<div align="center"><A href="Setup.htm" target="main">设置管理</A></div>
									</td>
									<td>
										<div align="center"><A href="CodeChage/Code.htm" target="main">密码设置</A></div>
									</td>
									<td class="toprtdbgimg" width="16"></td>
								</tr>
							</table>
						</td>
					</tr>
				</TBODY>
			</form>
		</TABLE>
	</body>
</HTML>
