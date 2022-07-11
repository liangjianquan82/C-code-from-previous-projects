<%@ Page language="c#" Codebehind="TrbDInput.aspx.cs" AutoEventWireup="false" Inherits="NrOA.TroubleDeal.TrbDInput" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TrbDInput</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../css/nroa.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../js/calendar.js"></script>
		<script language="JavaScript">
			function addFile()
			{
    			var str = '<br><INPUT type="file" size="50" NAME="File">'
    			document.getElementById('MyFile').insertAdjacentHTML("beforeEnd",str)
			}
			function ischeck()
			{
				alert("没有选择小区!");
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
									<TD align="center"><asp:label id="Label1" runat="server" ForeColor="LightSeaGreen" Font-Size="Medium" Font-Bold="True">故障信息导入</asp:label></TD>
								</TR>
								<TR>
									<TD></TD>
								</TR>
							</table>
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					</tr>
					<TBODY>
						<tr>
							<td><input type="file" size="40" name="File"></td>
							<td><asp:button id="UploadButton" runat="server" ToolTip="此处导入年结信息" Text="导入"></asp:button></td>
							<td><input onclick="addFile()" type="hidden" value="增加(Add)" name="hidden"> <input id="deptid" type="hidden" size="4" name="hidden2" runat="server">
							</td>
							</TD></tr>
						<TR>
							<TD><FONT face="宋体">
									<asp:TextBox id="TextBox2" onfocus="calendar()" runat="server" Width="100px"></asp:TextBox><asp:button id="Button1" runat="server" Text="删除当日导入故障信息"></asp:button></FONT></TD>
							<TD></TD>
							<TD><FONT face="宋体"></FONT></TD>
						</TR>
					</TBODY>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td><asp:datagrid id="DataGrid1" runat="server" AllowPaging="True" HorizontalAlign="Center" CellPadding="3"
							BackColor="White" BorderWidth="1px" BorderColor="#CCCCCC" Width="100%" AutoGenerateColumns="False">
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
								<asp:BoundColumn DataField="Trouble_nb" ReadOnly="True" HeaderText="故障单号">
									<HeaderStyle Width="80px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Proposer" HeaderText="申报人">
									<HeaderStyle Width="80px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ProposerPhone" ReadOnly="True" HeaderText="电话">
									<HeaderStyle Width="80px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ProposerAddress" ReadOnly="True" HeaderText="地址">
									<HeaderStyle Width="80px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Trouble_Describe" ReadOnly="True" HeaderText="故障描述">
									<HeaderStyle Width="80px"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle VerticalAlign="Bottom" HorizontalAlign="Right" ForeColor="#000066" BackColor="White"
								Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td><asp:label id="lblPageCount" runat="server" Width="172px"></asp:label><asp:label id="lblCurrentIndex" runat="server" Width="114px"></asp:label><asp:linkbutton id="btnFirst" onclick="PagerButtonClick" runat="server" ForeColor="navy" Font-Size="8pt"
							CommandArgument="0" Font-Name="verdana"></asp:linkbutton><asp:linkbutton id="btnPrev" onclick="PagerButtonClick" runat="server" ForeColor="navy" Font-Size="8pt"
							CommandArgument="prev" Font-Name="verdana"></asp:linkbutton><asp:linkbutton id="btnNext" onclick="PagerButtonClick" runat="server" ForeColor="navy" Font-Size="8pt"
							CommandArgument="next" Font-Name="verdana"></asp:linkbutton><asp:linkbutton id="btnLast" onclick="PagerButtonClick" runat="server" Font-Size="8pt" ForeColor="navy"
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
