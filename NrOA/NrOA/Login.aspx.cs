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

using System.Web.Security;
using System.Data.SqlClient;
using NrOA.comm;

namespace NrOA
{
	/// <summary>
	/// Login ��ժҪ˵����
	/// </summary>
	public class Login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label message;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.HtmlControls.HtmlForm fornetoalogin;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(Request.Params["logout"] == "y")
			{
				Session.Clear();
				System.Web.Security.FormsAuthentication.SignOut();
				message.Text = "���Ѱ�ȫ�˳�";
				message.Visible = true;
				
			}
			
			if(!IsPostBack)
			{
				if(Request.Params["login"]!="y")
				{
					Response.Write("<script type=\"text/JavaScript\">");
					Response.Write("window.top.location=\"login.aspx?login=y\"");
					Response.Write("</script>");
					Response.End();
				}
			}
			if(IsPostBack)
				return;

			if(Request.Cookies["userInfor"] != null)
			{
//				try
//				{
					TextBox1.Text =  Request.Cookies["userInfor"].Values["Employee_Nb"].ToString();
//				}
//				catch{}
			}
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Hashtable ht = new Hashtable();
			try
			{
				//��ѯ������û�����Ϣ
				ht = Passport.login(TextBox1.Text,TextBox2.Text);
			}
			catch(System.Data.SqlClient.SqlException)
			{
				message.Text = "���ݿ��쳣����";
				message.Visible = true;
			}
			String login_out = "";
			try
			{
				login_out = ht["Login_out"].ToString();
			}
			catch{}
			if(ht!=null)
			{
				if(login_out!="1")
				{
					Session["userinfo"]=ht;
					System.Web.Security.FormsAuthentication.SetAuthCookie(TextBox1.Text,false);
					//System.Web.Security.FormsAuthentication.SetAuthCookie(TextBox1.Text,CheckBox1.Checked);
					if(Request.Cookies["userInfor"] != null)
					{
						Request.Cookies["userInfor"].Values["Employee_Nb"] = TextBox1.Text;
						Request.Cookies["userInfor"].Expires = DateTime.Today .AddMonths(6);
						Response.AppendCookie(Request.Cookies["userInfor"]);
					}
					else
					{
						System.Web.HttpCookie readcookie = new System.Web.HttpCookie("userInfor");
						readcookie.Values.Add("Employee_Nb", TextBox1.Text);
						readcookie.Expires=DateTime.Today .AddMonths(6);
						Response.Cookies.Add(readcookie);
					}
					//Ȩ��
//					FornetOA.PurviewModel.SelectPurview SP = new FornetOA.PurviewModel.SelectPurview();
//					SP.dt = FornetOA.PurviewModel.GetEmployeePurview.EmpolyeePurviewFunction(ht["employee_id"].ToString());
//					Session["MYEPF"] = SP;
					Response.Redirect("main.htm");
				}
				else
				{
					message.Text = "�û�δ����";
					message.Visible = true;
				}
			}
			else
			{
				message.Text = "�û������������";
				message.Visible = true;
			}
		}
	}
}
