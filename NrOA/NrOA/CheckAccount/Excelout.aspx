<%@ Page language="c#" Codebehind="Excelout.aspx.cs" AutoEventWireup="false" Inherits="NrOA.TroubleDeal.CheckAccount" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Excelout</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
					<td vAlign="middle" align="center" colSpan="2" height="30"><FONT face="����" color="#3399cc" size="3"><B></B></FONT></td>
					<td class="content-middle2">&nbsp;</td>
				</tr>
				<tr>
					<td class="content-middle" width="2%">&nbsp;</td>
					<td vAlign="top" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td>&nbsp;&nbsp;&nbsp; </FONT><asp:button id="Button5" runat="server" Text="����Excel"></asp:button></td>
								<TD width="60"></TD>
								<TD width="60"></TD>
								<td width="60"><FONT face="����">
										<asp:Button id="Button1" runat="server" Text="����"></asp:Button></FONT></td>
							</tr>
						</table>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<asp:datagrid id="DataGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" HorizontalAlign="Left"
										BorderColor="#CCCCCC" BorderWidth="1px" BackColor="White" CellPadding="3">
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
													<input type="checkbox" ID="CheckID" OnClick="javascript: return select_deselectAll (this.checked, this.id, this);" value='<%#DataBinder.Eval(Container,"DataItem.id")%>' runat="server" NAME="CheckID"/>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn Visible="False" HeaderText="���">
												<ItemTemplate>
													<asp:Label ID="TaskID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.id") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="ClientListID" HeaderText="�ͻ����">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ClientOperationID" HeaderText="�ͻ�ҵ���">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ClientName" ReadOnly="True" HeaderText="�ͻ�����">
												<HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="areaname" HeaderText="С������">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ProductType" HeaderText="�ײ�����">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RunDate" HeaderText="��ͨ����">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Poundage" HeaderText="ԭ�ֳɱ���">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="OneOffConnectFees" HeaderText="�����">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MovePay" HeaderText="Ǩ�Ʒ�">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="oneyue" HeaderText="һ�·�">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="twoyue" HeaderText="���·�">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="threeyue" HeaderText="���·�">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="fouryue" HeaderText="���·�">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="fiveyue" HeaderText="���·�">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="sixyue" HeaderText="���·�">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="sevenyue" HeaderText="���·�">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="eightyue" HeaderText="���·�">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="nineyue" HeaderText="���·�">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="tenyue" HeaderText="ʮ�·�">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="elevenyue" HeaderText="ʮһ�·�">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="twelveyue" HeaderText="ʮ���·�">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="remark" HeaderText="��ע">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="state" HeaderText="״̬">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="OMPoundage" HeaderText="OMPoundage"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="onePoundage" HeaderText="1"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="twoPoundage" HeaderText="2"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="threePoundage" HeaderText="3"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="fourPoundage" HeaderText="4"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="fivePoundage" HeaderText="5"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="sixPoundage" HeaderText="6"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="sevenPoundage" HeaderText="7"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="eightPoundage" HeaderText="8"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="ninePoundage" HeaderText="9"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="tenPoundage" HeaderText="10"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="elevenPoundage" HeaderText="11"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="twelvePoundage" HeaderText="12"></asp:BoundColumn>
										</Columns>
										<PagerStyle VerticalAlign="Bottom" HorizontalAlign="Right" ForeColor="#000066" BackColor="White"
											Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</table>
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td>&nbsp;
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
