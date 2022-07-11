<%@ Page language="c#" Codebehind="select.aspx.cs" AutoEventWireup="false" Inherits="NrOA.select" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>select</title>
		<meta http-equiv="Pragma" content="No-cache">
		<meta http-equiv="Cache-Control" content="no-cache, must-revalidate">
		<meta http-equiv="Expires" content="-1">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/nroa.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		var oMyObject = window.dialogArguments;
		
		function reLoad()
		{
			if(oMyObject.strUserName!=null && oMyObject.strUserName!="" && oMyObject.strUserName!=undefined)
			{
				var arrUserName = oMyObject.strUserName.split(",");
				var arrUserID = oMyObject.strUserID.split(",");
				
				len = arrUserName.length;
				
				for(i=0;i<len;i++)
				{
					document.Form1.lbChoose.options.add(new Option(arrUserName[i],arrUserID[i],null,null));
				}
			}
		}
		
		
		//提交
		function ret(ret){
			if(!ret){
				window.returnValue = false;
				self.close();
			}
			len = document.Form1.lbChoose.options.length;
			//alert(len);
			if(len==0)
			{
				window.alert("请选择人员");
				return false;
			}
			var temp = new Array();
			for(i=0;i<len;i++){
				temp.push(document.Form1.lbChoose.options[i].text+ ','+document.Form1.lbChoose.options[i].value);
			}
			window.returnValue = temp;
			//dialogArguments.to = temp;
			//document.innerHtml += dialogArguments.to.valueOf();
			self.close();
		}
		  function btnRemoveOne_Click() //移去某个人
		  {
				var index=document.Form1.lbChoose.selectedIndex;
				if(index>=0)
				{
					
					document.Form1.lbChoose.options[index]  = null; //删除其中的一项
					
					if(document.Form1.lbChoose.options.length==0) //表明没有剩余项
					{
					   document.Form1.btnRemoveAll.enabled=false;  
		               document.Form1.btnRemoveOne.enabled=false;
					}
					return true;
				}
				else
				{ 
					window.alert("请选择某一已选人员");
					return false;
				}
		  }
		  
		  
		  function btnRemoveAll_Click() //移去所有人员
		  {
		     
		     if(confirm("是否要移去所有已选人员？？"))
		     {
		        var num=document.Form1.lbChoose.options.length;
		        if(num>0)
		        {
		           for(var i=num-1;i>=0;i--)
		           document.Form1.lbChoose.options[i]  = null; //删除其中的一项
		           document.Form1.lbChoose.clear;
		           document.Form1.btnRemoveAll.enabled=false;  
		           document.Form1.btnRemoveOne.enabled=false;
		        }
		     }
		     
		     return true;
		  }
		  
		 
		  function CheckExist(ValueStr) //检查是否已添加了某人员
		  {
		        var num=document.Form1.lbChoose.options.length;
		        if(num>0)
		        {
		           for(var i=0;i<num;i++)
		           {
		              if(document.Form1.lbChoose.options[i].value==ValueStr)
		              return true;
		           }
		         }
		         
		         return false;
		  }
		  
		  function btnAddOne_Click() //添加某个人到已选
		  {
		        var index=document.Form1.lbPerson.selectedIndex;
				if(index>=0)
				{
					var ValueStr=document.Form1.lbPerson.options[index].value
					if(CheckExist(ValueStr))
					{
					    window.alert("已添加了该人员!!")
					    return false;
					}
					else
					{
					   var len=document.Form1.lbChoose.options.length;
					   var NameStr=document.Form1.lbPerson.options[index].text
					   document.Form1.lbChoose.options[len]=new Option(NameStr,ValueStr,null,null);
					   
					   document.Form1.btnRemoveAll.enabled=true;  
		               document.Form1.btnRemoveOne.enabled=true;
		               return true;
		            }
				}
				else
				{
					window.alert("请选择某一待选人员");
					return false;
				}
		  }
		  
		  
		  function btnAddAll_Click() //添加某个人到已选
		  {
		        var num=document.Form1.lbPerson.options.length
				if(num>=0)
				{
					
					var ValueStr;
					var len;
					var NameStr;
					for(var i=0;i<num;i++)
					{
					   ValueStr=document.Form1.lbPerson.options[i].value;
					   if(CheckExist(ValueStr)==false)
					   {
							len=document.Form1.lbChoose.options.length;
							NameStr=document.Form1.lbPerson.options[i].text
							document.Form1.lbChoose.options[len]=new Option(NameStr,ValueStr,null,null);
						}
					}
					document.Form1.btnRemoveAll.enabled=true;  
				    document.Form1.btnRemoveOne.enabled=true;
				    
				    return true;
				}
				else
				{
					window.alert("没有待选人员");
					return false;
				}
		  }
		  
		  function BuildIdAndName() //在点击确定前，把已选人员的id,name以逗号隔开记录到隐藏域中。
		  {
		      var idStr="";
		      var nameStr="";
		      var num=document.Form1.lbChoose.options.length
		      if(num>0)
		      {
		         for(var i=0;i<num;i++)
		         {
		            if(idStr=="")
		            idStr=document.Form1.lbChoose.options[i].value;
		            else
		            idStr=idStr+","+document.Form1.lbChoose.options[i].value;
		            
		            if(nameStr=="")
		            nameStr=document.Form1.lbChoose.options[i].text;
		            else
		            nameStr=nameStr+","+document.Form1.lbChoose.options[i].text;
		         }
		         
		         document.Form1.hidChooseName.value=nameStr;
		         document.Form1.hidChooseId.value=idStr;
		         return true;
		      }
		      else
		      {
		         window.alert("请至少添加一个人员");
		         return false;
		      }
		  }	  
		  
		  
		  function LoadEmployeeGroup(dp) 
		  { 
			//alert(window.dialogArguments);
			var dt = NrOA.select.GetEmployeeGroup(dp).value;
			//var strName = dt.Rows[0].EmployeeNameStr;
			//var strID = dt.Rows[0].EmployeeIDStr;
			if(dt != null && typeof(dt) == "object")
			{
				document.Form1.lbChoose.options.length = 0;
				var arrUserName = dt.Rows[0].EmployeeNameStr.split(",");
				var arrUserID = dt.Rows[0].EmployeeIDStr.split(",");
				len = arrUserName.length;
				if(len>0)
				{
					for(i=0;i<len;i++)
					{
						document.Form1.lbChoose.options.add(new Option(arrUserName[i],arrUserID[i],null,null));
					}
				}
			}
		  }
		  
		  function LoadPart(unitid,partid)
		  {
			
			var dt = NrOA.select.GetPart(unitid,partid).value;
			//alert(dt.Rows.length);
			if(dt != null && typeof(dt) == "object")
			{
				document.Form1.lbPerson.options.length = 0;
				for(var i=0; i<dt.Rows.length; i++)
				{
					var id = dt.Rows[i].employee_id;
					var name = dt.Rows[i].employee_name;
					//alert(name);
					document.Form1.lbPerson.options.add(new Option(name,id));
				}
			}
		  }	 
		  
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" align="center" border="0">
				<TR>
					<TD>
						<TABLE id="Table3" style="WIDTH: 232px; HEIGHT: 44px" cellSpacing="0" cellPadding="0" width="232"
							border="0">
							<br>
							<TR>
								<TD style="WIDTH: 33px"><asp:label id="labPart" runat="server" Width="32px">部门</asp:label></TD>
								<TD><FONT face="宋体"><asp:dropdownlist id="ddlPart" runat="server" Width="192px" AutoPostBack="True">
											<asp:ListItem Value="AllPart">所有部门</asp:ListItem>
										</asp:dropdownlist></FONT></TD>
							</TR>
						</TABLE>
					</TD>
					<TD><FONT face="宋体"></FONT></TD>
					<TD><INPUT id="hidChooseName" style="WIDTH: 120px; HEIGHT: 22px" size="14" value="隐藏域,值:张三,李四"
							type="hidden" name="Hidden2" runat="server"> <INPUT id="hidChooseId" style="WIDTH: 96px; HEIGHT: 22px" type="hidden" size="10" value="隐藏域,值:id,id"
							name="Hidden1" runat="server"></TD>
				</TR>
				<TR>
					<TD><FONT face="宋体">待选</FONT></TD>
					<TD><FONT face="宋体"></FONT></TD>
					<TD><FONT face="宋体"><FONT face="宋体">已选</FONT></FONT></TD>
				</TR>
				<TR>
					<TD><FONT face="宋体"><asp:listbox id="lbPerson" ondblclick="javascript:return btnAddOne_Click()" runat="server" Width="243px"
								Height="168px"></asp:listbox></FONT></TD>
					<TD>
						<TABLE id="Table2" style="WIDTH: 56px; HEIGHT: 96px" cellSpacing="0" cellPadding="0" width="56"
							border="0">
							<TR>
								<TD><INPUT id="btnAddAll" style="WIDTH: 56px; HEIGHT: 24px" onclick="javascript:return btnAddAll_Click()"
										type="button" value="全添加"></TD>
							</TR>
							<TR>
								<TD><INPUT id="btnAddOne" style="WIDTH: 56px; HEIGHT: 24px" onclick="javascript:return btnAddOne_Click()"
										type="button" value="添加"></TD>
							</TR>
							<TR>
								<TD><INPUT id="btnRemoveOne" style="WIDTH: 56px; HEIGHT: 24px" onclick="javascript:return btnRemoveOne_Click()"
										type="button" value="删除"></TD>
							</TR>
							<TR>
								<TD><INPUT id="btnRemoveAll" style="WIDTH: 56px; HEIGHT: 24px" onclick="javascript:return btnRemoveAll_Click()"
										type="button" value="全删除"></TD>
							</TR>
						</TABLE>
					</TD>
					<TD><asp:listbox id="lbChoose" ondblclick="javascript:return btnRemoveOne_Click()" runat="server"
							Width="243px" Height="168px"></asp:listbox></TD>
				</TR>
				<TR>
					<TD><FONT face="宋体"><asp:label id="labId" runat="server" Width="200px"></asp:label></FONT></TD>
					<TD></TD>
					<TD align="right"><asp:button id="btnOK" runat="server" Width="56px" Text="确定"></asp:button><INPUT onclick="javascript:window.close()" type="button" value="关闭"></TD>
				</TR>
				<TR>
					<TD><asp:label id="labName" runat="server" Width="224px"></asp:label></TD>
					<TD></TD>
					<TD align="right"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
