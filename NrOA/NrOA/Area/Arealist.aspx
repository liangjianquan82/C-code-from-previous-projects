<%@ Page language="c#" Codebehind="Arealist.aspx.cs" AutoEventWireup="false" Inherits="NrOA.Area.Arealist" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Arealist</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/nroa.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../js/calendar.js"></script>
		<script language="javascript">
					
			function select_deselectAll (chkVal, idVal, oChk) 
			{ 
				var frm = document.forms[0];
				
				if(idVal.indexOf ('CheckID'))
				{
					// 
					if(oChk.checked)
					{
						if(Form1.selvalues.value == "")
							Form1.selvalues.value = ",";
						Form1.selvalues.value += oChk.value + ","; 
					}
					else
						Form1.selvalues.value = Form1.selvalues.value.replace("," + oChk.value + ",",","); 
				}

				// Loop through all elements
				for (i=0; i<frm.length; i++) 
				{
					// Look for our Header Template's Checkbox
					if (idVal.indexOf ('CheckAll') != -1) 
					{
						// Check if main checkbox is checked, then select or deselect datagrid checkboxes 
						if(chkVal == true) 
						{
							// ���ԭ���Ƿ�����,������治�ٲ���,������ӵ�ѡ����
							if(frm.elements[i].checked == false)
							{
								frm.elements[i].checked = true;
								if(frm.elements[i].id.indexOf('CheckID') != -1)
								{
									if(Form1.selvalues.value == "")
										Form1.selvalues.value = ",";
									Form1.selvalues.value += frm.elements[i].value + ",";
								}
							}
						} 
						else 
						{
							// ����Ƿ��Ǽ�,������Ǽٲ��ٲ���,��������ݼ����Ƴ�
							if(frm.elements[i].checked == true)
							{
								frm.elements[i].checked = false;
								if(frm.elements[i].id.indexOf('CheckID') != -1)
								{
									Form1.selvalues.value = Form1.selvalues.value.replace("," + frm.elements[i].value + ",",","); 
								}
							}
						}

						// Work here with the Item Template's multiple checkboxes
						
					} 
					else if (idVal.indexOf ('CheckID') != -1) 
					{

						// Check if any of the checkboxes are not checked, and then uncheck top select all checkbox
						if(frm.elements[i].checked == false) 
						{
							frm.elements[1].checked = false; //Uncheck main select all checkbox
						}
					}
				}
			}
			
			function isdel()
			{
				if( !confirm('ȷ��ע����'))
					return false;
				return check_sel();
			}
			
			function ispost()
			{
				if( !confirm('ȷ���ύ��'))
					return false;
				return check_sel();
			}
			
			function check_sel()
			{				
				// �ж��Ƿ�ѡ������Ҫ������ѡ��
				var frm = document.forms[0];
				var sum=0;
				for (i=0; i<frm.length; i++) 
				{
					if (frm.elements[i].id.indexOf ('CheckID') != -1) 
					{
						if(frm.elements[i].checked)
							sum++; 
					}
				}
				if(sum == 0)
				{
					alert("û��ѡ��С��!");
					return false;
				}
				return true;
			}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="99%" align="center" border="0">
				<tr>
					<td class="content-top" colSpan="3" height="20">&nbsp;</td>
					<td class="content-top-2" width="2%">&nbsp;</td>
				</tr>
				<tr>
					<td class="content-middle" width="2%">&nbsp;</td>
					<td vAlign="middle" align="center" colSpan="2" height="30"><FONT face="����" color="#3399cc" size="3"><B>С���б�</B></FONT></td>
					<td class="content-middle2">&nbsp;</td>
				</tr>
				<tr>
					<td class="content-middle" width="2%">&nbsp;</td>
					<td vAlign="top" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td>&nbsp;
									<asp:DropDownList id="DropDownList2" runat="server">
										<asp:ListItem Value="0">����</asp:ListItem>
										<asp:ListItem Value="1">����</asp:ListItem>
									</asp:DropDownList>
									<asp:Button id="Button1" runat="server" Text="��ѯ"></asp:Button></td>
								<td width="60"><asp:button id="Button3" runat="server" Text="ע��"></asp:button></td>
								<td width="60"><asp:button id="Button4" runat="server" Text="����"></asp:button></td>
								<td width="60"><asp:button id="Button2" runat="server" Text="��С��"></asp:button></td>
							</tr>
						</table>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td><asp:datagrid id="DataGrid1" runat="server" AllowPaging="True" CellPadding="3" BackColor="White"
										BorderWidth="1px" BorderColor="#CCCCCC" HorizontalAlign="Left" AutoGenerateColumns="False"
										Width="100%">
										<FooterStyle ForeColor="#000066" VerticalAlign="Bottom" BackColor="White"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" Height="20px" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
										<ItemStyle Height="20px" ForeColor="#000066"></ItemStyle>
										<HeaderStyle Font-Bold="True" Height="20px" ForeColor="White" BackColor="#006699"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<HeaderStyle Width="15px"></HeaderStyle>
												<HeaderTemplate>
													<input type="checkbox" ID="CheckAll" OnClick="javascript: return select_deselectAll (this.checked, this.id, this);"
														runat="server" NAME="CheckAll" />
												</HeaderTemplate>
												<ItemTemplate>
													<input type="checkbox" ID="CheckID" OnClick="javascript: return select_deselectAll (this.checked, this.id, this);" value='<%#DataBinder.Eval(Container,"DataItem.Area_ID")%>' runat="server" NAME="CheckID"/>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn Visible="False" HeaderText="С�����">
												<ItemTemplate>
													<asp:Label ID="TaskID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Area_ID") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="Area_listid" HeaderText="С�����">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="С������">
												<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
												<ItemTemplate>
													<asp:LinkButton ID="LB" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Area_ID") %>' OnCommand="LinkButton_Command" runat="server" >
														<%#DataBinder.Eval(Container,"DataItem.AreaName")%>
													</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="AreaRemark" HeaderText="��ע">
												<HeaderStyle Width="150px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Poundage" HeaderText="С���ֳɱ���">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Area_state" HeaderText="С��״̬">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn Visible="False" HeaderText="С���б�">
												<ItemTemplate>
													<asp:DropDownList id="DropDownList1" runat="server"></asp:DropDownList>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle VerticalAlign="Bottom" HorizontalAlign="Right" ForeColor="#000066" BackColor="White"
											Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</table>
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td><asp:label id="lblPageCount" runat="server" Width="172px"></asp:label><asp:label id="lblCurrentIndex" runat="server" Width="114px"></asp:label><asp:linkbutton id="btnFirst" onclick="PagerButtonClick" runat="server" CommandArgument="0" ForeColor="navy"
										Font-size="8pt" Font-Name="verdana"></asp:linkbutton><asp:linkbutton id="btnPrev" onclick="PagerButtonClick" runat="server" CommandArgument="prev" ForeColor="navy"
										Font-size="8pt" Font-Name="verdana"></asp:linkbutton><asp:linkbutton id="btnNext" onclick="PagerButtonClick" runat="server" CommandArgument="next" ForeColor="navy"
										Font-size="8pt" Font-Name="verdana"></asp:linkbutton><asp:linkbutton id="btnLast" onclick="PagerButtonClick" runat="server" CommandArgument="last" ForeColor="navy"
										Font-size="8pt" Font-Name="verdana"></asp:linkbutton><INPUT id="selvalues" style="WIDTH: 72px; HEIGHT: 22px" type="hidden" size="6" value=","
										name="selvalues" runat="server">
								</td>
							</tr>
						</table>
					</td>
					<td class="content-middle2">&nbsp;</td>
				</tr>
				<tr>
					<td class="content-bottom" colSpan="3">&nbsp;</td>
					<td class="content-bottom-2" width="2%">&nbsp;</td>
				</tr>
			</TABLE>
			<P></P>
			<P><FONT face="����"></FONT>&nbsp;</P>
		</form>
	</body>
</HTML>
