<%@ Page language="c#" Codebehind="newlist.aspx.cs" AutoEventWireup="false" Inherits="NrOA.CheckAccount.newlist" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>客户列表</title>
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
				if( !confirm('确定注销吗？'))
					return false;
				return check_sel();
			}
			
			function ispost()
			{
				if( !confirm('确定启用吗？'))
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
					alert("没有选择客户!");
					return false;
				}
				return true;
			}
			
			function checksave()
			{
				if (document.Form1.TextBox1.value=="")
				{
					window.alert("请输入模糊查询条件！");
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
					<td vAlign="middle" align="center" colSpan="2" height="30"><FONT face="宋体" color="#3399cc" size="3"><B><asp:label id="Label3" runat="server" Font-Size="Medium" ForeColor="#3399CC">客户各年收费列表</asp:label></B></FONT></td>
					<td class="content-middle2">&nbsp;</td>
				</tr>
				<tr>
					<td class="content-middle" width="2%">&nbsp;</td>
					<td vAlign="top" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td><asp:label id="Label1" runat="server">模糊查询：</asp:label>&nbsp;&nbsp;&nbsp;
									<asp:textbox id="TextBox1" runat="server" ToolTip="模糊查询业务号或者名称"></asp:textbox><asp:dropdownlist id="DropDownList2" runat="server" AutoPostBack="True" Visible="False">
										<asp:ListItem Value="0">启用</asp:ListItem>
										<asp:ListItem Value="1">挂起</asp:ListItem>
									</asp:dropdownlist><asp:label id="Label5" runat="server" Visible="False">入网年份：</asp:label><asp:dropdownlist id="DropDownList4" runat="server">
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
									</asp:dropdownlist></FONT><asp:label id="Label4" runat="server" Visible="False">入网月份：</asp:label><asp:dropdownlist id="Dropdownlist3" runat="server">
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
									</asp:dropdownlist><asp:button id="Button1" runat="server" Text="查询"></asp:button><asp:checkbox id="CheckBox2" runat="server" Text="显示全部" Checked="True"></asp:checkbox><asp:checkbox id="CheckBox1" runat="server" Text="异常"></asp:checkbox></td>
							</tr>
						</table>
						<table cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td align="left" width="98%">
									<div style="WIDTH: 98%" align="left">
										<table>
											<tr>
												<td style="WIDTH: 54px" align="center" bgColor="#006699">编号
												</td>
												<td style="WIDTH: 109px" align="center" bgColor="#006699">客户名称
												</td>
												<td style="WIDTH: 100px" align="center" bgColor="#006699">客户业务号
												</td>
												<td style="WIDTH: 145px" align="center" bgColor="#006699">开通日期
												</td>
												<td style="WIDTH: 60px" align="center" bgColor="#006699">年份
												</td>
												<td style="WIDTH: 50px" align="center" bgColor="#006699">分成
												</td>
												<td style="WIDTH: 80px" align="center" bgColor="#006699">接入费
												</td>
												<td style="WIDTH: 80px" align="center" bgColor="#006699">一月份
												</td>
												<td style="WIDTH: 80px" align="center" bgColor="#006699">二月份
												</td>
												<td style="WIDTH: 80px" align="center" bgColor="#006699">三月份
												</td>
												<td style="WIDTH: 80px" align="center" bgColor="#006699">四月份
												</td>
												<td style="WIDTH: 80px" align="center" bgColor="#006699">五月份
												</td>
												<td style="WIDTH: 80px" align="center" bgColor="#006699">六月份
												</td>
												<td style="WIDTH: 80px" align="center" bgColor="#006699">七月份
												</td>
												<td style="WIDTH: 80px" align="center" bgColor="#006699">八月份
												</td>
												<td style="WIDTH: 80px" align="center" bgColor="#006699">九月份
												</td>
												<td style="WIDTH: 80px" align="center" bgColor="#006699">十月份
												</td>
												<td style="WIDTH: 80px" align="center" bgColor="#006699">十一月份
												</td>
												<td style="WIDTH: 80px" align="center" bgColor="#006699">十二月份
												</td>
												<td style="WIDTH: 150px" align="center" bgColor="#006699">备注
												</td>
												<td style="WIDTH: 50px" align="center" bgColor="#006699">状态
												</td>
												<td style="WIDTH: 50px" align="center" bgColor="#006699">套餐
												</td>
											</tr>
										</table>
									</div>
									<DIV id="SelectShow1" style="OVERFLOW-Y: auto; OVERFLOW-X: auto; WIDTH: 100%; HEIGHT: 450px"><asp:datagrid id="DataGrid1" runat="server" AllowSorting="True" AllowPaging="True" CellPadding="3"
											BackColor="White" BorderWidth="1px" BorderColor="#CCCCCC" HorizontalAlign="Left" AutoGenerateColumns="False">
											<FooterStyle ForeColor="#000066" VerticalAlign="Bottom" BackColor="White"></FooterStyle>
											<SelectedItemStyle Font-Bold="True" Height="20px" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
											<ItemStyle Height="20px" ForeColor="#000066"></ItemStyle>
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" Height="20px" ForeColor="White" VerticalAlign="Middle"
												BackColor="#006699"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn Visible="False">
													<HeaderStyle Width="15px"></HeaderStyle>
													<HeaderTemplate>
														<input type="checkbox" ID="CheckAll" OnClick="javascript: return select_deselectAll (this.checked, this.id, this);"
															runat="server" NAME="CheckAll" />
													</HeaderTemplate>
													<ItemTemplate>
														<input type="checkbox" ID="CheckID" OnClick="javascript: return select_deselectAll (this.checked, this.id, this);" value='<%#DataBinder.Eval(Container,"DataItem.Client_ID")%>' runat="server" NAME="CheckID"/>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn Visible="False" HeaderText="客户编号">
													<ItemTemplate>
														<asp:Label ID="TaskID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Client_ID") %>'>
														</asp:Label>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="ClientListID" HeaderText="编号" >
													<HeaderStyle Width="50px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="客户名称">
													<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton ID="LB" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.ClientOperationID") %>' OnCommand="LinkButton_Command" runat="server" >
															<%#DataBinder.Eval(Container,"DataItem.ClientName")%>
														</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="ClientOperationID" ReadOnly="True" HeaderText="客户业务号">
													<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="RunDate" HeaderText="开通日期">
													<HeaderStyle Width="150px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="yr" HeaderText="年份">
													<HeaderStyle Width="60px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="fc" HeaderText="分成">
													<HeaderStyle Width="50px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="jr" HeaderText="接入费">
													<HeaderStyle Width="80px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="month1" HeaderText="一月份">
													<HeaderStyle Width="80px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="month2" HeaderText="二月份">
													<HeaderStyle Width="80px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="month3" HeaderText="三月份">
													<HeaderStyle Width="80px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="month4" HeaderText="四月份">
													<HeaderStyle Width="80px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="month5" HeaderText="五月份">
													<HeaderStyle Width="80px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="month6" HeaderText="六月份">
													<HeaderStyle Width="80px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="month7" HeaderText="七月份">
													<HeaderStyle Width="80px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="month8" HeaderText="八月份">
													<HeaderStyle Width="80px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="month9" HeaderText="九月份">
													<HeaderStyle Width="80px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="month10" HeaderText="十月份">
													<HeaderStyle Width="80px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="month11" HeaderText="十一月份">
													<HeaderStyle Width="80px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="month12" HeaderText="十二月份">
													<HeaderStyle Width="80px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="bz" HeaderText="备注">
													<HeaderStyle Width="150px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="type" HeaderText="状态">
													<HeaderStyle Width="50px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="ProductType" HeaderText="套餐">
													<HeaderStyle Width="50px"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle VerticalAlign="Bottom" HorizontalAlign="Right" ForeColor="#000066" BackColor="White"
												Mode="NumericPages"></PagerStyle>
										</asp:datagrid></DIV>
								</td>
							</tr>
						</table>
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td><asp:label id="lblPageCount" runat="server" Width="172px"></asp:label><asp:label id="lblCurrentIndex" runat="server" Width="114px"></asp:label><asp:linkbutton id="btnFirst" onclick="PagerButtonClick" runat="server" ForeColor="navy" CommandArgument="0"
										Font-size="8pt" Font-Name="verdana"></asp:linkbutton><asp:linkbutton id="btnPrev" onclick="PagerButtonClick" runat="server" ForeColor="navy" CommandArgument="prev"
										Font-size="8pt" Font-Name="verdana"></asp:linkbutton><asp:linkbutton id="btnNext" onclick="PagerButtonClick" runat="server" ForeColor="navy" CommandArgument="next"
										Font-size="8pt" Font-Name="verdana"></asp:linkbutton><asp:linkbutton id="btnLast" onclick="PagerButtonClick" runat="server" ForeColor="navy" CommandArgument="last"
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
			<P><FONT face="宋体"></FONT>&nbsp;</P>
		</form>
	</body>
</HTML>
