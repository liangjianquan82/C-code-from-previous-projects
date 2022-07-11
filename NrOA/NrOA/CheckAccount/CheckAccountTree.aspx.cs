using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Microsoft.Web.UI.WebControls;

namespace NrOA.CheckAccount
{
	/// <summary>
	/// CheckAccountTree 的摘要说明。
	/// </summary>
	public class CheckAccountTree : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected Microsoft.Web.UI.WebControls.TreeView TreeView1;
		protected System.Web.UI.HtmlControls.HtmlForm tree;
	

		Hashtable hast=null;
		private string UserName = "";

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面

			hast = (Hashtable)Session["userinfo"];

			try
			{
				UserName = hast["EmployeeName"].ToString();
			}
			catch{}
			//部分权限
			if(UserName == "NrOA"|| UserName =="黄菲")
			{
			}
			else if(UserName=="zhb"||UserName=="user")
			{
				Response.Write("<script language='javascript'>window.parent.location='../desktop.aspx'</script>");
			}
			else
			{
				Response.Write("<script language='javascript'>window.parent.location='../desktop.aspx'</script>");
			}
			
				
			if(hast == null)
			{
				Response.Redirect("login.aspx");
			}
			
			// 在此处放置用户代码以初始化页面
			if(IsPostBack)
				return;

			Create_Tree();
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void Create_Tree()
		{
			NrOA.Area.em.Area AR = new NrOA.Area.em.Area();
			NrOA.Area.pkg.DOArea DoAr = new NrOA.Area.pkg.DOArea();

			//查询小区列表
			IList dt = null;
			dt = DoAr.SelectAreaAll_LoginIn();
			if(dt!=null)
			{
				if(dt.Count>0)
				{
					TreeNode Node1=new TreeNode();
					Node1.Text = "小区列表";
					for(int i=0 ;i<dt.Count;i++)
					{						
						TreeNode Node2=new TreeNode();
						Node2.Text = ((NrOA.Area.em.Area)(dt)[i]).Area_listid+"-"+((NrOA.Area.em.Area)(dt)[i]).AreaName;
						Node2.NavigateUrl = "newlist.aspx?AreaName="+((NrOA.Area.em.Area)(dt)[i]).Area_ID;
						Node2.Target = "right";
						if(Node2.Text!="-请选择小区-")
						{
							Node1.Nodes.Add(Node2);
						}
					}
					TreeView1.Nodes.Add(Node1);
					Node1.Expanded=true;
//					TreeNode Node=new TreeNode();
//					Node.Text = "小区用户信息导入";
//					Node.NavigateUrl = "ClientInput.aspx";
//					Node.Target = "right";
//					TreeView1.Nodes.Add(Node);
				}
			}
		}
	}
}
