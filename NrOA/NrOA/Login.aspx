<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="NrOA.Login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>诺瑞办公管理系统</title>
		<meta content="True" name="vs_showGrid">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style type="text/css"> .STYLE1 { FONT-WEIGHT: bold; FONT-SIZE: 18px; COLOR: #ffffff } .STYLE2 { FONT-SIZE: 18px; FONT-FAMILY: "黑体" } .1 { BORDER-RIGHT: #336699 2px solid; BORDER-TOP: #336699 2px solid; BORDER-LEFT: #336699 2px solid; BORDER-BOTTOM: #336699 2px solid } .s1 { BORDER-RIGHT: #336699 2px dotted; BORDER-TOP: #336699 2px; BORDER-LEFT: #336699 2px dotted; BORDER-BOTTOM: #336699 2px } .list { FONT-WEIGHT: bold; FONT-SIZE: 12pt; COLOR: #336699 } .f { FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #000000 } .2 { FONT-SIZE: 14px; COLOR: #333333; LINE-HEIGHT: normal; FONT-STYLE: normal; FONT-FAMILY: "仿宋_GB2312" } .td { FONT-WEIGHT: bold; FONT-SIZE: 16px; COLOR: #336699; FONT-FAMILY: "Times New Roman", Times, serif } .1 .css0023 { FONT-WEIGHT: bolder; FONT-SIZE: 14px; COLOR: #dc0c0c; FONT-FAMILY: "Times New Roman", Times, serif } .STYLE2 { LINE-HEIGHT: 20pt; FONT-FAMILY: "宋体" } BODY { MARGIN: 0px } .STYLE5 { COLOR: #ff0000 } </style>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
	</HEAD>
	<body MS_POSITIONING="GridLayout" background="images/login/11.gif">
		<table width="724" height="535" border="0" align="center" cellpadding="0" cellspacing="0">
			<tr>
				<td height="147" valign="middle" style="FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: mintcream; FONT-STYLE: normal; FONT-FAMILY: 宋体; FONT-VARIANT: normal"
					align="center">
					齐瑞
				</td>
			</tr>
			<tr>
				<td valign="top"><table width="100%" height="386" border="0" cellpadding="0" cellspacing="0" class="s1">
						<tr>
							<td width="50%" valign="top">
								<table width="50%" height="287" border="0" cellpadding="0" cellspacing="0" class="1" align="center">
									<tr>
										<td height="32" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#336699">
												<tr>
													<td width="57%" height="32" align="center"><div align="center"><span class="STYLE1">登录到系统</span></div>
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td valign="top"><table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
												<form id="fornetoalogin" method="post" runat="server">
													<TBODY>
														<tr>
															<td height="20">&nbsp;</td>
														</tr>
														<tr>
															<td valign="top" align="center"><table width="100%" border="0" cellpadding="0" cellspacing="0">
																	<tr>
																		<td align="center"><asp:Label ID="message" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
																	</tr>
																	<tr>
																		<td height="33" class="td">&nbsp;&nbsp;工号：
																			<asp:TextBox ID="TextBox1" runat="server" Width="248px" TabIndex="1"></asp:TextBox></td>
																	</tr>
																	<tr>
																		<td height="33" class="td">&nbsp;&nbsp;密码：
																			<asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="248px" TabIndex="2"></asp:TextBox></td>
																	</tr>
																	<tr>
																	</tr>
																</table>
																<asp:Button id="Button1" runat="server" Width="70px" Text="登录"></asp:Button>
															</td>
														</tr>
														<tr>
															<td height="58" align="center" bgcolor="#336699"><span style="FONT-SIZE: 9pt;COLOR: #ffffff">建议使用IE6.0和1024*768屏幕分辨率浏览</span></td>
														</tr>
												</form>
											</table>
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			</TBODY></table>
		<table width="100%" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td height="100" align="center" bgcolor="#336699"><FONT color="#ffffff" size="2">@ 
						版权所有.保留所有权利.</FONT></td>
			</tr>
		</table>
	</body>
</HTML>
