<%@ Page language="c#" Codebehind="ChargePutInt.aspx.cs" AutoEventWireup="false" Inherits="NrOA.CheckAccount.ChargePutInt" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ChargePutInt</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/nroa.css" type="text/css" rel="stylesheet">
		<script language="JavaScript">
			function addFile()
			{
    			var str = '<br><INPUT type="file" size="50" NAME="File">'
    			document.getElementById('MyFile').insertAdjacentHTML("beforeEnd",str)
    			alert(str);
			}
			function ischeck()
			{
				alert("没有选择年份或者月份!");
				return false;
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<table cellSpacing="0" cellPadding="0" width="99%" align="center" border="0">
				<TBODY>
					<tr>
						<td class="content-top" colSpan="3" height="20">&nbsp;</td>
						<td class="content-top-2" width="4%">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-middle" width="4%">&nbsp;</td>
						<td vAlign="top" colSpan="2">
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD align="center"><asp:label id="Label1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="LightSeaGreen">缴费信息导入</asp:label></TD>
								</TR>
								<tr>
									<td><asp:label id="Label2" runat="server" ForeColor="Red">注意：导入请按照所给的导入格式。</asp:label></td>
								</tr>
								<TR>
									<TD><FONT face="宋体">&nbsp;</FONT></TD>
								</TR>
								<TR>
									<TD><asp:label id="Label3" runat="server">选择年份</asp:label><asp:dropdownlist id="DropDownList3" runat="server" AutoPostBack="True">
											<asp:ListItem Value="-选择年份-">-选择年份-</asp:ListItem>
											<asp:ListItem Value="2007">2006</asp:ListItem>
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
										</asp:dropdownlist><asp:label id="Label4" runat="server">选择月份</asp:label><asp:dropdownlist id="DropDownList2" runat="server" AutoPostBack="True">
											<asp:ListItem Value="-选择月份-">-选择月份-</asp:ListItem>
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
										</asp:dropdownlist><asp:textbox id="TextBox1" runat="server" Visible="False"></asp:textbox><asp:button id="Button4" runat="server" Text="选择" Visible="False"></asp:button></TD>
								</TR>
							</table>
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					</tr>
					<TBODY>
						<tr>
							<td><input type="file" size="40" name="File"></td>
							<td><asp:button id="UploadButton" runat="server" Text="导入"></asp:button></td>
							<td><input onclick="addFile()" type="hidden" value="增加(Add)" name="hidden"> <input id="deptid" type="hidden" size="4" name="hidden2" runat="server">
								<asp:button id="Button3" runat="server" Text="导入2" Visible="False"></asp:button></td>
							</TD></tr>
						<TR>
							<TD><FONT face="宋体"><asp:dropdownlist id="DropDownList1" runat="server">
										<asp:ListItem Value="回款">回款</asp:ListItem>
										<asp:ListItem Value="一次性">一次性</asp:ListItem>
										<asp:ListItem Value="按年结">按年结</asp:ListItem>
									</asp:dropdownlist></FONT></TD>
							<TD><asp:button id="Button1" runat="server" Text="查看"></asp:button></TD>
							<TD><FONT face="宋体"><asp:button id="Button2" runat="server" Text="删除"></asp:button>&nbsp;&nbsp;
									<asp:Button id="Button5" runat="server" Text="删除对应业务号已注销用户"></asp:Button></FONT></TD>
						</TR>
					</TBODY>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" Width="100%" BorderColor="#CCCCCC"
							BorderWidth="1px" BackColor="White" CellPadding="3" HorizontalAlign="Center" AllowPaging="True">
							<FooterStyle ForeColor="#000066" VerticalAlign="Bottom" BackColor="White"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" Height="20px" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
							<ItemStyle HorizontalAlign="Left" Height="20px" ForeColor="#000066" VerticalAlign="Top"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Height="20px" ForeColor="White" VerticalAlign="Middle"
								BackColor="#006699"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="15px"></HeaderStyle>
									<HeaderTemplate>
										<asp:CheckBox ID="CheckAll" onclick="javascript: return select_deselectAll (this.checked, this.id);"
											runat="server" />
									</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox ID="CheckID" onclick="javascript: return select_deselectAll (this.checked, this.id);"
											runat="server" />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False" HeaderText="人员编号">
									<ItemTemplate>
										<asp:Label ID="employee_id" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.employee_id") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn ReadOnly="True" HeaderText="用户号">
									<HeaderStyle Width="100px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" ReadOnly="True" HeaderText="年结费用">
									<HeaderStyle Width="100px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn ReadOnly="True" HeaderText="套餐">
									<HeaderStyle Width="80px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="缴费按年">
									<HeaderStyle Width="100px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn ReadOnly="True" HeaderText="使用有效期">
									<HeaderStyle Width="100px"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle VerticalAlign="Bottom" HorizontalAlign="Right" ForeColor="#000066" BackColor="White"
								Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td><asp:label id="lblPageCount" runat="server" Width="172px"></asp:label><asp:label id="lblCurrentIndex" runat="server" Width="114px"></asp:label><asp:linkbutton id="btnFirst" onclick="PagerButtonClick" runat="server" Font-Size="8pt" ForeColor="navy"
							Font-Name="verdana" CommandArgument="0"></asp:linkbutton><asp:linkbutton id="btnPrev" onclick="PagerButtonClick" runat="server" Font-Size="8pt" ForeColor="navy"
							Font-Name="verdana" CommandArgument="prev"></asp:linkbutton><asp:linkbutton id="btnNext" onclick="PagerButtonClick" runat="server" Font-Size="8pt" ForeColor="navy"
							Font-Name="verdana" CommandArgument="next"></asp:linkbutton><asp:linkbutton id="btnLast" onclick="PagerButtonClick" runat="server" Font-Size="8pt" ForeColor="navy"
							Font-Name="verdana" CommandArgument="last"></asp:linkbutton></td>
				</tr>
			</table>
			</TD>
			<td class="content-middle2">&nbsp;</td>
			</TR>
			<tr>
				<td class="content-bottom" colSpan="3">&nbsp;</td>
				<td class="content-bottom-2" width="2%">&nbsp;</td>
			</tr>
		</form>
		</TBODY></TABLE>
	</body>
</HTML>
