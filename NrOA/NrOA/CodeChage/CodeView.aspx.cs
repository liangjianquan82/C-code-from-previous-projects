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

namespace NrOA.CodeChage
{
	/// <summary>
	/// CodeView 的摘要说明。
	/// </summary>
	public class CodeView : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label_Title;
		protected System.Web.UI.WebControls.Button ok2;
		protected System.Web.UI.HtmlControls.HtmlForm addtask;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox TextBox4;
		protected System.Web.UI.WebControls.TextBox TextBox5;
		protected System.Web.UI.WebControls.TextBox TextBox3;

		protected Hashtable ht = null;
		private string UserName = "";
		private string Employee_Nb = "";
		private string Employee_ID = "";
		private string Password = "";
		NrOA.Employee.pkg.DOEmployee dc = new NrOA.Employee.pkg.DOEmployee();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			ht = (Hashtable)Session["userinfo"];
			UserName = ht["EmployeeName"].ToString();
			Employee_Nb = ht["Employee_Nb"].ToString();
			TextBox4.Text = UserName;
			TextBox5.Text = Employee_Nb;
			try
			{
				Password = ht["Password"].ToString();
			}
			catch{}

			try
			{
				Employee_ID = Request["Employee_ID"].ToString();
			}
			catch{}
			IList list = null;
			
			if(Employee_ID=="")
			{
				Employee_ID = ht["Employee_ID"].ToString();
			}
			else
			{
			}
			try
			{
				list = dc.select_Employee_id(Employee_ID);
			}
			catch{}
			
			if(list!=null)
			{
				if(list.Count>0)
				{
					TextBox4.Text = ((NrOA.Employee.em.Employee)(list)[0]).EmployeeName;
					TextBox5.Text = ((NrOA.Employee.em.Employee)(list)[0]).Employee_Nb;
					Password = ((NrOA.Employee.em.Employee)(list)[0]).Password;
				}
			}
			
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
			this.ok2.Click += new System.EventHandler(this.ok2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ok2_Click(object sender, System.EventArgs e)
		{
			NrOA.Employee.em.Employee El = new NrOA.Employee.em.Employee();
			NrOA.Employee.pkg.DOEmployee de = new NrOA.Employee.pkg.DOEmployee();

			string str = "";
			bool state = false;
			if(TextBox1.Text.Trim()=="")
			{
				str="原密码不能为空！";
			}
			else if(Password!=TextBox1.Text.Trim())
			{
				str="原密码填写错误！";
			}
			else if(TextBox2.Text.Trim()=="")
			{
				str="新密码不能为空！";
			}
			else if(TextBox3.Text.Trim()=="")
			{
				str="新密码确认不能为空！";
			}
			else if(TextBox3.Text.Trim()!=TextBox2.Text.Trim())
			{
				str="新密码与新密码确认必须相同！";
				TextBox3.Text = "";
				TextBox2.Text = "";
			}
			else
			{
				El.Employee_ID = int.Parse(Employee_ID);
				El.Password = TextBox2.Text.Trim();
				de.updateEmployee_Password(El);
				str="新密码修改成功！";
				state = true;
			}
			Response.Write("<script>window.alert('"+str+"');</script>");
			if(!state)
			{
				return;
			}
		}
	}
}
