<%@ Page language="c#" Codebehind="TrbDView.aspx.cs" AutoEventWireup="false" Inherits="NrOA.TroubleDeal.TrbDView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TrbDView</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/nroa.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../js/calendar.js"></script>
		<script language="javascript">
		function checksave()
		{
			if (document.addtask.Trouble_nb.value=="")
			{
				
			}
			else if (document.addtask.Proposer.value=="")
			{
				
			}
			else if (document.addtask.ddListstate.value=="0")
			{
				window.alert("��ѡ��״̬��");
				return false;
			}			
			else if(document.addtask.ddListstate.value=="3"&&document.addtask.DealResult.value=="")
			{				
				window.alert("�����봦������");
				return false;
			}
			
		}
		
		function select_users(obj_ctrl_name_text, obj_ctrl_value_text)
		{
			var myObject = new Object();
			myObject.strUserName = document.getElementById(obj_ctrl_name_text).value;
			
			//����ѡ����ȥ��ǰ�󶺺�
			if(document.getElementById(obj_ctrl_value_text).value.substring(0,1) == ",")
			{
				myObject.strUserID = document.getElementById(obj_ctrl_value_text).value.slice(1,-1);
			}
			else
			{
				myObject.strUserID = document.getElementById(obj_ctrl_value_text).value;
			}
						
			var return_value=showModalDialog("../select.aspx",myObject,"dialogWidth:35;dialogHeight:20;dialogTop:150;dialogLeft:180;status:no;scrollbars:no;help:no");
			if(return_value)
			{
				var str1="";
				var str2="";
				var tmpstr="";
				len = return_value.length;
				for(i=0;i<len;i++)
				{
					tmpstr = return_value[i].split(",");
					str1 += tmpstr[0]+",";
					str2 += tmpstr[1]+",";
				}
				str1 = str1.slice(0,-1);
				str2 = str2.slice(0,-1);
				//ǰ����Ӷ���
				if(str2.substring(1,1) != ",")
					str2 = "," + str2;
				if(str2.substring(str2.length,1) != ",")
					str2 = str2  +  ",";
					
				document.getElementById(obj_ctrl_name_text).value = str1;
				document.getElementById(obj_ctrl_value_text).value = str2;
				
				return false;
			}
			return false;			
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
						<td class="content-middle" width="2%">&nbsp;</td>
						<td vAlign="middle" align="center" colSpan="2" height="30"><asp:label id="Label_Title" runat="server" Font-Bold="True" ForeColor="#3399CC" Font-Size="Medium">����/�޸Ĺ�����Ϣ</asp:label></td>
						<td class="content-middle2">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-middle" width="2%">&nbsp;</td>
						<td vAlign="middle" align="right" colSpan="2" height="30"><asp:button id="ok2" runat="server" Text="����"></asp:button><asp:button id="Button11" runat="server" Text="����"></asp:button></td>
						<td class="content-middle2">&nbsp;</td>
					</tr>
					<tr>
						<td class="content-middle" width="2%">&nbsp;</td>
						<td vAlign="top" colSpan="2"><FONT face="����">
								<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
									<TR>
										<TD width="15%">���ϵ��ţ�</TD>
										<TD style="WIDTH: 801px; HEIGHT: 25px"><asp:textbox id="Trouble_nb" runat="server" Width="80%"></asp:textbox>
											<asp:RadioButton id="RadioButton1" runat="server" Text="����˾" AutoPostBack="True" Checked="True"></asp:RadioButton>
											<asp:RadioButton id="RadioButton2" runat="server" Text="��ͨ" AutoPostBack="True"></asp:RadioButton></TD>
										<TD style="HEIGHT: 25px" width="5%">&nbsp;</TD>
									</TR>
									<TR>
										<TD width="15%">�����걨ʱ�䣺</TD>
										<TD style="WIDTH: 801px; HEIGHT: 25px"><asp:textbox id="Trouble_date" onfocus="calendar()" runat="server" Width="150px" AutoPostBack="True"></asp:textbox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD width="15%">������ҵ��ţ�</TD>
										<TD style="WIDTH: 801px; HEIGHT: 25px"><asp:textbox id="OperationID" runat="server" Width="98%"></asp:textbox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD width="15%">�걨�ˣ�</TD>
										<TD style="WIDTH: 801px; HEIGHT: 25px"><asp:textbox id="Proposer" runat="server" Width="98%"></asp:textbox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD>�걨�˵�ַ��</TD>
										<TD style="WIDTH: 801px; HEIGHT: 25px"><asp:textbox id="ProposerAddress" runat="server" Width="98%"></asp:textbox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD>�걨�˵绰��</TD>
										<TD style="WIDTH: 801px; HEIGHT: 25px"><asp:textbox id="ProposerPhone" runat="server" Width="98%"></asp:textbox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD>����������</TD>
										<TD style="WIDTH: 801px; HEIGHT: 25px"><asp:textbox id="Trouble_Describe" runat="server" Width="98%" Height="64px" TextMode="MultiLine"></asp:textbox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD>�ɹ���Ա��</TD>
										<TD style="WIDTH: 801px; HEIGHT: 25px"><asp:textbox id="Dispatch_man" runat="server" Width="98%"></asp:textbox><INPUT id="Dispatch_man1" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="tbCheckObject"
												runat="server"></TD>
										<TD style="HEIGHT: 25px" align="center"><asp:linkbutton id="LinkButton1" runat="server">ѡ��</asp:linkbutton></TD>
									</TR>
									<TR>
										<TD>�ɹ�ʱ�䣺</TD>
										<TD style="WIDTH: 801px; HEIGHT: 25px"><asp:textbox id="Dispatch_date" onfocus="calendar()" runat="server" Width="150px" Enabled="False"></asp:textbox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 17px">��������</TD>
										<TD style="WIDTH: 801px; HEIGHT: 17px"><asp:textbox id="DealResult" runat="server" Width="98%" Height="64px" TextMode="MultiLine"></asp:textbox></TD>
										<TD style="HEIGHT: 17px">&nbsp;</TD>
									</TR>
									<TR>
										<TD>�������ʱ�䣺</TD>
										<TD style="WIDTH: 801px; HEIGHT: 25px"><asp:textbox id="Deal_date" onfocus="calendar()" runat="server" Width="150px"></asp:textbox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD>�طã�</TD>
										<TD style="WIDTH: 801px"><asp:textbox id="BackCallContent" runat="server" Width="98%" Height="64px" TextMode="MultiLine"></asp:textbox></TD>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>״̬��</TD>
										<TD style="WIDTH: 801px; HEIGHT: 25px"><asp:dropdownlist id="ddListstate" runat="server">
												<asp:ListItem Value="0">-��ѡ��״̬-</asp:ListItem>
												<asp:ListItem Value="1">δ����</asp:ListItem>
												<asp:ListItem Value="2">������</asp:ListItem>
												<asp:ListItem Value="3">�������</asp:ListItem>
												<asp:ListItem Value="4">����</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD style="HEIGHT: 25px"></TD>
									</TR>
									<TR>
										<TD><asp:label id="Label1" runat="server">�ͻ�Ͷ�ߣ�</asp:label></TD>
										<TD style="WIDTH: 801px; HEIGHT: 25px"><asp:textbox id="Complaints" runat="server" Width="98%" Height="64px" TextMode="MultiLine"></asp:textbox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD>��ˮ��Ϣ��</TD>
										<TD style="WIDTH: 801px; HEIGHT: 25px"><asp:textbox id="Moveinfo" runat="server" Width="98%" Height="64px" TextMode="MultiLine"></asp:textbox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD>��ע��</TD>
										<TD style="WIDTH: 801px; HEIGHT: 25px"><asp:textbox id="remark" runat="server" Width="98%" Height="64px" TextMode="MultiLine"></asp:textbox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD>��¼�ˣ�</TD>
										<TD style="WIDTH: 801px; HEIGHT: 25px"><asp:textbox id="Register_man" runat="server" Enabled="False"></asp:textbox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD>��¼ʱ�䣺</TD>
										<TD style="WIDTH: 801px; HEIGHT: 25px"><asp:textbox id="Register_date" runat="server" Enabled="False"></asp:textbox></TD>
										<TD style="HEIGHT: 25px">&nbsp;</TD>
									</TR>
									<TR>
										<TD align="right" colSpan="3"><asp:button id="ok" runat="server" Text="����"></asp:button><asp:button id="Button1" runat="server" Text="����"></asp:button></TD>
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
