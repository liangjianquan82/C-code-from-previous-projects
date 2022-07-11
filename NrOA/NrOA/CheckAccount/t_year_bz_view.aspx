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
				window.alert("客户名称不能为空哦！");
				return false;
			}
			
			if (document.addtask.DropDownList1.value=="-请选择年份-")
			{
				window.alert("请选择年份！");
				return false;
			}
			if (document.addtask.DropDownList2.value=="-请选择月份-")
			{
				window.alert("请选择月份！");
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
						<td vAlign="middle" align="center" colSpan="2" height="46" style="HEIGHT: 46px"><asp:label id="Label_Title" runat="server" Font-Bold="True" ForeColor="#3399CC" Font-Size="Medium">备注信息</asp:label></td>
						<td class="content-middle2" style="HEIGHT: 46px">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-middle" width="2%">&nbsp;</td>
						<td vAlign="top" colSpan="2"><FONT face="宋体">
								<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
									<TR>
										<TD style="HEIGHT: 25px">选择年月：</TD>
										<TD style="HEIGHT: 25px"><asp:dropdownlist id="DropDownList1" runat="server" AutoPostBack="True">
												<asp:ListItem Value="-请选择年份-">-请选择年份-</asp:ListItem>
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
												<asp:ListItem Value="-请选择月份-">-请选择月份-</asp:ListItem>
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
										<TD style="HEIGHT: 25px">客户名称：</TD>
										<TD style="HEIGHT: 25px">
											<asp:TextBox id="tb_name" runat="server"></asp:TextBox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD width="15%">客户业务号：</TD>
										<TD><asp:textbox id="tb_ClientOperationID" runat="server" Width="276px"></asp:textbox></TD>
										<TD width="5%">&nbsp;</TD>
									</TR>
									<TR>
										<TD>接入费用：</TD>
										<TD><asp:textbox id="tb_jr" runat="server" Width="150px">0</asp:textbox></TD>
										<TD align="center"></TD>
									</TR>
									<TR>
										<TD>接入费分成：</TD>
										<TD>
											<asp:textbox id="tb_jrfc" runat="server" Width="150px">0</asp:textbox></TD>
										<TD align="center"><asp:button id="bt_jr" runat="server" Text="保存接入费"></asp:button></TD>
									</TR>
									<TR>
										<TD>使用费用：</TD>
										<TD>
											<asp:textbox id="tb_sy" runat="server" Width="150px">0</asp:textbox></TD>
										<TD align="center"></TD>
									</TR>
									<TR>
										<TD>使用费分成：</TD>
										<TD>
											<asp:textbox id="tb_syfc" runat="server" Width="150px">0</asp:textbox></TD>
										<TD align="center">
											<asp:button id="bt_sy" runat="server" Text="保存使用费"></asp:button></TD>
									</TR>
									<TR>
										<TD>原始分成比例：</TD>
										<TD>
											<asp:textbox id="tb_fc" runat="server" Width="150px">0</asp:textbox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>是否异常：</TD>
										<TD>
											<asp:RadioButton id="RadioButton1" runat="server" Text="正常" TextAlign="Left" Checked="True" AutoPostBack="True"></asp:RadioButton>
											<asp:RadioButton id="RadioButton2" runat="server" Text="异常" TextAlign="Left" AutoPostBack="True"></asp:RadioButton></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD>备注</TD>
										<TD>
											<asp:TextBox id="tb_bz" runat="server" Width="394px" TextMode="MultiLine" Height="62px"></asp:TextBox></TD>
										<TD>&nbsp;<asp:button id="bt_bz" runat="server" Text="保存备注"></asp:button></TD>
									</TR>
									<TR>
										<TD align="right" colSpan="3"><asp:button id="Button1" runat="server" Text="返回"></asp:button></TD>
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
