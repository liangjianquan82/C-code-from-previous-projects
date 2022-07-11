<%@ Page language="c#" Codebehind="ChargeList.aspx.cs" AutoEventWireup="false" Inherits="NrOA.CheckAccount.ChargeList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>收费列表</title>
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
				// 分解日期
				var aDate1 = document.all["Textbox1"].value.split("-");
				var oDate1 = new Date(aDate1[0],aDate1[1],aDate1[2]) ;
				
				var aDate2 = document.all["Textbox2"].value.split("-");
				var oDate2 = new Date(aDate2[0],aDate2[1],aDate2[2]) ;
				
				if(oDate2 < oDate1)
				{
					window.alert('结束日期不能小于开始日期!');
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
							// 检查原来是否是真,如果是真不再操作,否则添加到选择集中
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
							// 检查是否是假,如果是是假不再操作,否则从数据集中移除
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
				if( !confirm('确定删除吗？'))
					return false;
				return check_sel();
			}
			
			function ispost()
			{
				if( !confirm('确定提交吗？'))
					return false;
				return check_sel();
			}
			
			function check_sel()
			{				
				// 判断是否选择了需要操作的选项
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
					alert("没有选择任务!");
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
					<td vAlign="middle" align="center" colSpan="2" height="30"><FONT face="宋体" color="#3399cc" size="3"><B><asp:label id="Label6" runat="server" ForeColor="#3399CC" Font-Size="Medium">收费列表</asp:label></B></FONT></td>
					<td class="content-middle2">&nbsp;</td>
				</tr>
				<tr>
					<td class="content-middle" width="2%">&nbsp;</td>
					<td vAlign="top" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD style="WIDTH: 114px; HEIGHT: 24px" width="114"><FONT face="宋体"><asp:label id="Label2" runat="server">选择年：</asp:label></FONT></TD>
								<TD style="HEIGHT: 24px"><asp:dropdownlist id="DropDownList1" runat="server">
										<asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
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
									</asp:dropdownlist><asp:label id="Label3" runat="server">选择月份：</asp:label><asp:dropdownlist id="DropDownList2" runat="server">
										<asp:ListItem Value="0">-请选择-</asp:ListItem>
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
									</asp:dropdownlist><asp:label id="Label7" runat="server">至</asp:label><asp:dropdownlist id="DropDownList5" runat="server">
										<asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
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
									</asp:dropdownlist><asp:label id="Label4" runat="server">选择小区：</asp:label><asp:dropdownlist id="DropDownList3" runat="server"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 24px" width="60"><asp:button id="Button3" runat="server" Text="删除"></asp:button></TD>
								<TD style="HEIGHT: 24px" width="60"><asp:button id="Button5" runat="server" Text="新增月结"></asp:button></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 114px" width="114"><FONT face="宋体"><asp:label id="Label5" runat="server">查询条件：</asp:label></FONT></TD>
								<TD><asp:dropdownlist id="DropDownList4" runat="server">
										<asp:ListItem Value="-请选择-">-请选择-</asp:ListItem>
										<asp:ListItem Value="1">未回款用户和年结</asp:ListItem>
										<asp:ListItem Value="2">年结分成比例出错</asp:ListItem>
										<asp:ListItem Value="3">接入费缴费用户</asp:ListItem>
										<asp:ListItem Value="4">迁移费缴费用户</asp:ListItem>
										<asp:ListItem Value="5">年结列表</asp:ListItem>
										<asp:ListItem Value="6">一次性列表</asp:ListItem>
										<asp:ListItem Value="7">回款/月结列表</asp:ListItem>
										<asp:ListItem Value="8">月结分成比例错误</asp:ListItem>
										<asp:ListItem Value="9">一次性分成比例错误</asp:ListItem>
										<asp:ListItem Value="10">有一次性接入费，按月结</asp:ListItem>
										<asp:ListItem Value="11">有一次性接入费，无年结</asp:ListItem>
									</asp:dropdownlist><asp:label id="Label1" runat="server" Visible="False">模糊查询：</asp:label><asp:textbox id="TextBox1" runat="server"></asp:textbox><asp:button id="Button1" runat="server" Text="查询"></asp:button></TD>
								<td width="60"><asp:button id="Button2" runat="server" Text="新增年结"></asp:button></td>
								<TD width="60"><asp:button id="Button4" runat="server" Text="新增一次性"></asp:button></TD>
							</TR>
						</table>
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td><asp:datagrid id="DataGrid1" runat="server" Width="100%" AutoGenerateColumns="False" HorizontalAlign="Left"
										BorderColor="#CCCCCC" BorderWidth="1px" BackColor="White" CellPadding="3" AllowPaging="True">
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
													<input type="checkbox" ID="CheckID" OnClick="javascript: return select_deselectAll (this.checked, this.id, this);" value='<%#DataBinder.Eval(Container,"DataItem.Charge_ID")%>' runat="server" NAME="CheckID"/>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn Visible="False" HeaderText="编号">
												<ItemTemplate>
													<asp:Label ID="TaskID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Charge_ID") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="ClientOperationID" ReadOnly="True" HeaderText="客户业务号">
												<HeaderStyle HorizontalAlign="Center" Width="65px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ClientName" ReadOnly="True" HeaderText="客户名称">
												<HeaderStyle HorizontalAlign="Center" Width="65px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PoundageValue" HeaderText="原分成比例">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="年结款">
												<HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
												<ItemTemplate>
													<asp:LinkButton ID="LB" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Charge_ID") %>' OnCommand="LinkButton_Command" runat="server" >
														<%#DataBinder.Eval(Container,"DataItem.FirstPayment")%>
													</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn HeaderText="年结款实收">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Now_Poundage" HeaderText="年结实际分成比例">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="一次性收费">
												<HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
												<ItemTemplate>
													<asp:LinkButton ID="Linkbutton1" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Charge_ID") %>' OnCommand="LinkButton_Command1" runat="server" >
														<%#DataBinder.Eval(Container,"DataItem.OneOffConnectFees")%>
													</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn HeaderText="一次性实收">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Now_Poundage" HeaderText="一次性实际分成比例">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="按月交费">
												<HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
												<ItemTemplate>
													<asp:LinkButton ID="Linkbutton2" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Charge_ID") %>' OnCommand="LinkButton_Command2" runat="server" >
														<%#DataBinder.Eval(Container,"DataItem.PaymentMonth")%>
													</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn HeaderText="按月实际缴费">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Now_Poundage" HeaderText="按月分成比例">
												<HeaderStyle Width="90px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="迁移费">
												<HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
												<ItemTemplate>
													<asp:LinkButton ID="Linkbutton3" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Charge_ID") %>' OnCommand="LinkButton_Command3" runat="server" >
														<%#DataBinder.Eval(Container,"DataItem.MovePay")%>
													</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn HeaderText="迁移费实收">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="状态">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="FirstPayment" HeaderText="年结"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="OneOffConnectFees" HeaderText="一次性"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="PaymentMonth" HeaderText="月结"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="MovePay" HeaderText="迁移费"></asp:BoundColumn>
										</Columns>
										<PagerStyle VerticalAlign="Bottom" HorizontalAlign="Right" ForeColor="#000066" BackColor="White"
											Mode="NumericPages"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</TABLE>
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
			<P><FONT face="宋体"></FONT>&nbsp;</P>
		</form>
	</body>
</HTML>
