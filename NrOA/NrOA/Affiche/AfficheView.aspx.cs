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

namespace NrOA.Affiche
{
	/// <summary>
	/// AfficheView 的摘要说明。
	/// </summary>
	public class AfficheView : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button ok2;
		protected System.Web.UI.WebControls.Button Button11;
		protected System.Web.UI.WebControls.DropDownList dl_state;
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox tmpTaskID;
		protected System.Web.UI.WebControls.TextBox tmpReturnUrl;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label Label_Title;
		protected System.Web.UI.WebControls.TextBox tb_Affiche_content;
		protected System.Web.UI.WebControls.TextBox tb_RegisterMane;
	


		private int Affiche_ID = 0;
		private string state = "";

		protected Hashtable ht = null;
		private string UserName = "";

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			ok.Attributes.Add("onclick","javascript: return checksave()");
			ok2.Attributes.Add("onclick","javascript: return checksave()");

			try
			{
				state = Request["state"].ToString();
			}
			catch{}

			try
			{
				Affiche_ID = int.Parse(Request["Affiche_ID"].ToString());
			}
			catch{}

			ht = (Hashtable)Session["userinfo"];
			try
			{
				UserName = ht["EmployeeName"].ToString();
			}
			catch{}

			if(IsPostBack)
				return;
			if(state=="update")
			{
				Add();
			}

			if(UserName=="user")
			{
				ok.Visible = false;
				ok2.Visible = false;				
			}
			tb_RegisterMane.Text =UserName;
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
			this.Button11.Click += new System.EventHandler(this.Button11_Click);
			this.ok.Click += new System.EventHandler(this.ok_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Add()
		{
			NrOA.Affiche.pkg.DOaffiche doa = new NrOA.Affiche.pkg.DOaffiche();
			IList list = doa.SelectAffiche_By_ID(Affiche_ID);
			if(list!=null)
			{
				if(list.Count!=0)
				{
					tb_Affiche_content.Text= ((NrOA.Affiche.em.affiche)(list)[0]).Affiche_content;
					dl_state.SelectedValue = ((NrOA.Affiche.em.affiche)(list)[0]).state.Trim();
					tb_RegisterMane.Text = ((NrOA.Affiche.em.affiche)(list)[0]).RegisterMane;
				}
			}
		}

		private void SaveData()
		{
			NrOA.Affiche.pkg.DOaffiche doa = new NrOA.Affiche.pkg.DOaffiche();
			NrOA.Affiche.em.affiche ar = new NrOA.Affiche.em.affiche();
			ar.Affiche_content = this.tb_Affiche_content.Text.Trim();
			ar.state = this.dl_state.SelectedValue.ToString().Trim();
			ar.RegisterMane = tb_RegisterMane.Text.Trim();
			
			if(state=="new")
			{
				doa.InsertafficheInfo(ar);
			}
			else
			{
				ar.Affiche_ID = Affiche_ID;
				doa.Update_afficheInfo(ar);

			}
			Response.Write("<script>window.alert('数据保存成功');window.location='../Affiche/Affichelist.aspx';</script>");
		}

		private void ok2_Click(object sender, System.EventArgs e)
		{
			SaveData();
		}

		private void ok_Click(object sender, System.EventArgs e)
		{
			SaveData();
		}

		private void Button11_Click(object sender, System.EventArgs e)
		{
			Page.Response.Redirect("Affichelist.aspx");
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Page.Response.Redirect("Affichelist.aspx");
		}
	}
}
