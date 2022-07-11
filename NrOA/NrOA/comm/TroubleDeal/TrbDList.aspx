<%@ Page language="c#" Codebehind="TrbDList.aspx.cs" AutoEventWireup="false" Inherits="NrOA.TroubleDeal.TroubleDealList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TroubleDealList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/nroa.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../js/calendar.js"></script>
		<script language="javascript">
		
		function popwin(TaskID)
		{
    		window.open("AddTask.aspx?TaskID="+TaskID,"","left=150,top=100,height=500,width=600,resizable=no,scrollbars=yes,status=no,toolbar=no,menubar=no,location=no");
		}
			function checkclick()
			{
				// �ֽ�����
				var aDate1 = document.all["Textbox2"].value.split("-");
				var oDate1 = new Date(aDate1[0],aDate1[1],aDate1[2]) ;
				
				var aDate2 = document.all["Textbox3"].value.split("-");
				var oDate2 = new Date(aDate2[0],aDate2[1],aDate2[2]) ;
				
				if(oDate2 < oDate1)
				{
					window.alert('�������ڲ���С�ڿ�ʼ����!');
					return false;
				}
				return true;
			}
			
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
				if( !confirm('ȷ��ɾ����'))
					return false;
				return check_sel();
			}
			
			function ispost()
			{
				if( !confirm('ȷ��������'))
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
					alert("û��ѡ��ͻ�!");
					return false;
				}
				return true;
			}
			
			function checksave()
			{
				if (document.Form1.DropDownList1.value=="-��ѡ��С��-")
				{
					window.alert("û��ѡ��С����");
					return false;
				}
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
					<td vAlign="middle" align="center" colSpan="2" height="30"><FONT face="����" color="#3399cc" size="3"><B><asp:label id="Label3" runat="server" ForeColor="#3399CC" Font-Size="Medium">δ�����б�</asp:label></B></FONT></td>
					<td class="content-middle2">&nbsp;</td>
				</tr>
				<tr>
					<td class="content-middle" width="2%">&nbsp;</td>
					<td vAlign="top" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td><asp:label id="Label1" runat="server">ģ����ѯ��</asp:label>&nbsp;&nbsp;&nbsp;
									<asp:textbox id="TextBox1" runat="server" ToolTip="ģ����ѯҵ��Ż�������"></asp:textbox><asp:label id="Label5" runat="server">ѡ�����ڣ�</asp:label><asp:textbox id="TextBox2" onfocus="calendar()" runat="server" Width="100px"></asp:textbox></FONT><asp:label id="Label7" runat="server">��</asp:label><asp:textbox id="TextBox3" onfocus="calendar()" runat="server" Width="100px"></asp:textbox><asp:dropdownlist id="DropDownList2" runat="server">
										<asp:ListItem Value="0">-��ѡ��-</asp:ListItem>
										<asp:ListItem Value="WT">��ͨ</asp:ListItem>
										<asp:ListItem Value="NR">ŵ��</asp:ListItem>
										<asp:ListItem Value="All">ȫ������ʱ��</asp:ListItem>
									</asp:dropdownlist><asp:button id="Button1" runat="server" Text="��ѯ"></asp:button><asp:button id="Button5" runat="server" Text="���ϴ���������" Visible="False"></asp:button></td>
								<TD width="60"><asp:button id="Button3" runat="server" Text="ɾ��"></asp:button></TD>
								<TD width="60"><asp:button id="Button4" runat="server" Text="����" Visible="False"></asp:button></TD>
								<td width="60"><asp:button id="Button2" runat="server" Text="����"></asp:button></td>
							</tr>
						</table>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td><asp:datagrid id="DataGrid1" runat="server" Width="100%" AutoGenerateColumns="False" HorizontalAlign="Left"
										BorderColor="#CCCCCC" BorderWidth="1px" BackColor="White" CellPadding="3" AllowPaging="True"
										AllowSorting="True">
										<FooterStyle ForeColor="#000066" VerticalAlign="Bottom" BackColor="White"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" Height="20px" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
										<ItemStyle Height="20px" ForeColor="#000066"></ItemStyle>
										<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Height="20px" ForeColor="White" VerticalAlign="Middle"
											BackColor="#006699"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<HeaderStyle Width="15px"></HeaderStyle>
												<HeaderTemplate>
													<input type="checkbox" ID="CheckAll" OnClick="javascript: return select_deselectAll (this.checked, this.id, this);"
														runat="server" NAME="CheckAll" />
												</HeaderTemplate>
												<ItemTemplate>
													<input type="checkbox" ID="CheckID" OnClick="javascript: return select_deselectAll (this.checked, this.id, this);" value='<%#DataBinder.Eval(Container,"DataItem.Trouble_id")%>' runat="server" NAME="CheckID"/>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn Visible="False" HeaderText="���ϱ��">
												<ItemTemplate>
													<asp:Label ID="TaskID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Trouble_id") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="���ϵ���">
												<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
												<ItemTemplate>
													<asp:LinkButton ID="LB" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Trouble_id") %>' OnCommand="LinkButton_Command" runat="server" >
														<%#DataBinder.Eval(Container,"DataItem.Trouble_nb")%>
													</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="Proposer" HeaderText="������">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Trouble_date" HeaderText="�걨����">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="OperationID" ReadOnly="True" HeaderText="ҵ���">
												<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ProposerAddress" HeaderText="��ַ">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ProposerPhone" HeaderText="�绰">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Trouble_Describe" HeaderText="��������">
												<HeaderStyle Width="150px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Dispatch_man" HeaderText="�ɹ���Ա">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Dispatch_date" HeaderText="�ɹ����ʱ��">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DealResult" HeaderText="������">
												<HeaderStyle Width="150px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Deal_date" HeaderText="�������ʱ��">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="BackCallContent" HeaderText="�ط�">
												<HeaderStyle Width="150px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="remark" HeaderText="��ע">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="state" HeaderText="״̬">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle VerticalAlign="Bottom" HorizontalAlign="Right" ForeColor="#000066" BackColor="White"
											Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</table>
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td><asp:label id="lblPageCount" runat="server" Width="172px"></asp:label><asp:label id="lblCurrentIndex" runat="server" Width="114px"></asp:label><asp:linkbutton id="btnFirst" onclick="PagerButtonClick" runat="server" ForeColor="navy" Font-Name="verdana"
										Font-size="8pt" CommandArgument="0"></asp:linkbutton><asp:linkbutton id="btnPrev" onclick="PagerButtonClick" runat="server" ForeColor="navy" Font-Name="verdana"
										Font-size="8pt" CommandArgument="prev"></asp:linkbutton><asp:linkbutton id="btnNext" onclick="PagerButtonClick" runat="server" ForeColor="navy" Font-Name="verdana"
										Font-size="8pt" CommandArgument="next"></asp:linkbutton><asp:linkbutton id="btnLast" onclick="PagerButtonClick" runat="server" ForeColor="navy" Font-Name="verdana"
										Font-size="8pt" CommandArgument="last"></asp:linkbutton><INPUT id="selvalues" style="WIDTH: 72px; HEIGHT: 22px" type="hidden" size="6" value=","
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
