<%@ Page language="c#" Codebehind="BackFundList.aspx.cs" AutoEventWireup="false" Inherits="NrOA.CheckAccount.BackFundList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�ؿ��б�</title>
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
				var aDate1 = document.all["Textbox1"].value.split("-");
				var oDate1 = new Date(aDate1[0],aDate1[1],aDate1[2]) ;
				
				var aDate2 = document.all["Textbox2"].value.split("-");
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
					alert("û��ѡ������!");
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
					<td vAlign="middle" align="center" colSpan="2" height="30"><FONT face="����" color="#3399cc" size="3"><B><asp:label id="Label6" runat="server" ForeColor="#3399CC" Font-Size="Medium">�ɷ���Ϣ�б�</asp:label></B></FONT></td>
					<td class="content-middle2">&nbsp;</td>
				</tr>
				<tr>
					<td class="content-middle" width="2%">&nbsp;</td>
					<td vAlign="top" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD style="WIDTH: 199px; HEIGHT: 24px" width="199"><FONT face="����"><asp:dropdownlist id="Dropdownlist2" runat="server">
											<asp:ListItem Value="-��ѡ����-">-��ѡ����-</asp:ListItem>
											<asp:ListItem Value="2004">2004</asp:ListItem>
											<asp:ListItem Value="2005">2005</asp:ListItem>
											<asp:ListItem Value="2006">2006</asp:ListItem>
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
										</asp:dropdownlist><asp:dropdownlist id="DropDownList4" runat="server">
											<asp:ListItem Value="0">-��ѡ����-</asp:ListItem>
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
										</asp:dropdownlist></FONT></TD>
								<TD style="WIDTH: 566px; HEIGHT: 24px"><asp:label id="Label4" runat="server">ѡ��С����</asp:label><asp:dropdownlist id="DropDownList3" runat="server"></asp:dropdownlist><asp:label id="Label1" runat="server">��ѯ������</asp:label><asp:dropdownlist id="DropDownList1" runat="server" AutoPostBack="True">
										<asp:ListItem Value="0">-ѡ������-</asp:ListItem>
										<asp:ListItem Value="1">�ֳɱ�������</asp:ListItem>
										<asp:ListItem Value="2">����û�лؿ�</asp:ListItem>
										<asp:ListItem Value="3">�û���������</asp:ListItem>
									</asp:dropdownlist><asp:label id="Label3" runat="server">״̬��</asp:label><asp:dropdownlist id="DropDownList5" runat="server">
										<asp:ListItem Value="0">-��ѡ��-</asp:ListItem>
										<asp:ListItem Value="1">һ��</asp:ListItem>
										<asp:ListItem Value="2">�쳣</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="HEIGHT: 24px" width="60"></TD>
								<TD style="HEIGHT: 24px" width="60"><asp:button id="Button3" runat="server" Text="����Excel"></asp:button></TD>
								<TD style="HEIGHT: 24px" width="60"><asp:button id="Button2" runat="server" Text="��������"></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 199px; HEIGHT: 25px" width="199"><FONT face="����"><asp:dropdownlist id="Dropdownlist6" runat="server" Visible="False">
											<asp:ListItem Value="-�ɷ����-">-�ɷ����-</asp:ListItem>
											<asp:ListItem Value="2004">2004</asp:ListItem>
											<asp:ListItem Value="2005">2005</asp:ListItem>
											<asp:ListItem Value="2006">2006</asp:ListItem>
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
										</asp:dropdownlist></FONT></TD>
								<TD style="WIDTH: 566px; HEIGHT: 25px"><FONT face="����"><asp:label id="Label2" runat="server">ģ����ѯ��</asp:label><asp:textbox id="TextBox1" runat="server" Width="103px"></asp:textbox><asp:checkbox id="CheckBox1" runat="server" Text="ȫ����ʾ" Checked="True" TextAlign="Left"></asp:checkbox></FONT></TD>
								<TD style="HEIGHT: 25px" width="60"></TD>
								<TD style="HEIGHT: 25px" width="60"><asp:button id="Button1" runat="server" Text="��ѯ"></asp:button></TD>
								<TD style="HEIGHT: 25px" width="60"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 199px" width="199"><FONT face="����"></FONT></TD>
								<TD style="WIDTH: 565px"><FONT face="����"></FONT></TD>
								<TD width="60"></TD>
								<TD width="60"></TD>
							</TR>
						</table>
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD><asp:datagrid id="DataGrid1" runat="server" AllowPaging="True" CellPadding="3" BackColor="White"
										BorderWidth="1px" BorderColor="#CCCCCC" HorizontalAlign="Left" AutoGenerateColumns="False">
										<FooterStyle ForeColor="#000066" VerticalAlign="Bottom" BackColor="White"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" Height="20px" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
										<ItemStyle Height="20px" ForeColor="#000066"></ItemStyle>
										<HeaderStyle Font-Bold="True" Height="20px" ForeColor="White" BackColor="#006699"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn Visible="False">
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
											<asp:TemplateColumn HeaderText="�ͻ�ҵ���">
												<HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
												<ItemTemplate>
													<asp:LinkButton ID="LB" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.id") %>' OnCommand="LinkButton_Command" runat="server" >
														<%#DataBinder.Eval(Container,"DataItem.ClientOperationID")%>
													</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
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
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Poundage" HeaderText="ԭ�ֳɱ���">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="OneOffConnectFees" HeaderText="�����">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MovePay" HeaderText="Ǩ�Ʒ�">
												<HeaderStyle Width="80px"></HeaderStyle>
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
									</asp:datagrid></TD>
							</TR>
						</TABLE>
						<TABLE cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD><asp:label id="lblPageCount" runat="server" Width="172px"></asp:label><asp:label id="lblCurrentIndex" runat="server" Width="114px"></asp:label><asp:linkbutton id="btnFirst" onclick="PagerButtonClick" runat="server" ForeColor="navy" CommandArgument="0"
										Font-size="8pt" Font-Name="verdana"></asp:linkbutton><asp:linkbutton id="btnPrev" onclick="PagerButtonClick" runat="server" ForeColor="navy" CommandArgument="prev"
										Font-size="8pt" Font-Name="verdana"></asp:linkbutton><asp:linkbutton id="btnNext" onclick="PagerButtonClick" runat="server" ForeColor="navy" CommandArgument="next"
										Font-size="8pt" Font-Name="verdana"></asp:linkbutton><asp:linkbutton id="btnLast" onclick="PagerButtonClick" runat="server" ForeColor="navy" CommandArgument="last"
										Font-size="8pt" Font-Name="verdana"></asp:linkbutton><INPUT id="selvalues" style="WIDTH: 72px; HEIGHT: 22px" type="hidden" size="6" value=","
										name="selvalues" runat="server">
								</TD>
							</TR>
						</TABLE>
					</td>
					<TD class="content-middle2">&nbsp;</TD>
				</tr>
				<TR>
					<TD class="content-bottom" colSpan="3">&nbsp;</TD>
					<TD class="content-bottom-2" width="2%">&nbsp;</TD>
				</TR>
			</TABLE>
			<P></P>
			<P><FONT face="����"></FONT>&nbsp;</P>
		</form>
	</body>
</HTML>
