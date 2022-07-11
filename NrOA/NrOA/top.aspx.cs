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

namespace NrOA
{
	/// <summary>
	/// top 的摘要说明。
	/// </summary>
	public class top : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label strUserName;
		protected System.Web.UI.WebControls.Label SessNum;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl lbWarn;

		Hashtable hast=null;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			lbWarn.InnerText = "欢迎使用诺瑞办公系统";

			//读取session信息
			hast = (Hashtable)Session["userinfo"];

			//欢迎用户名
			strUserName.Text = hast["EmployeeName"].ToString();
			//在线人数
			try
			{
				SessNum.Text = Page.Application["count"].ToString();
			}
			catch{}
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
	}
}
