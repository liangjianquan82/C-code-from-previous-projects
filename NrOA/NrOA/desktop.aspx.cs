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
	/// desktop 的摘要说明。
	/// </summary>
	public class desktop : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataList Datalist2;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.LinkButton LinkButton2;
		protected System.Web.UI.WebControls.LinkButton LinkButton3;
		protected System.Web.UI.WebControls.LinkButton LinkButton4;
		protected System.Web.UI.WebControls.LinkButton LinkButton5;
		protected System.Web.UI.WebControls.LinkButton LinkButton6;
		protected System.Web.UI.WebControls.LinkButton LinkButton7;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		private Hashtable ht = null;
		protected System.Web.UI.HtmlControls.HtmlGenericControl lbWarn;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		private string UserName="";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			NrOA.TroubleDeal.pkg.DoTroubleDeal dtd = new NrOA.TroubleDeal.pkg.DoTroubleDeal();
			NrOA.LogManage.pkg.DoLogManange dlm = new NrOA.LogManage.pkg.DoLogManange();
			NrOA.NewAndFinish.pkg.DoNewAndFinish dnf = new NrOA.NewAndFinish.pkg.DoNewAndFinish();
			NrOA.Affiche.pkg.DOaffiche dof = new NrOA.Affiche.pkg.DOaffiche();

			IList listdtd1 = null;
			IList listdtd2 = null;
			IList listdlm1 = null;
			IList listdlm2 = null;
			IList listdnf1 = null;
			IList listdnf2 = null;
			IList listdnf3 = null;
			
			listdtd1 = dtd.selectTrblist("1","",DateTime.Today.Year.ToString()+"-1"+"-1",DateTime.Today.Year.ToString()+"-12"+"-31","0");
			listdtd2 =dtd.selectTrblist("2","",DateTime.Today.Year.ToString()+"-1"+"-1",DateTime.Today.Year.ToString()+"-12"+"-31","0");

			ht = (Hashtable)Session["userinfo"];

			try
			{
				UserName = ht["EmployeeName"].ToString();
			}
			catch{}
			try
			{
				Label2.Text = listdtd1.Count.ToString();
			}
			catch{Label2.Text = "0";}
			try
			{
				Label4.Text = listdtd2.Count.ToString();
			}
			catch{Label4.Text = "0";}

			listdlm1 = dlm.SelectLogM("1","",DateTime.Today.Year.ToString()+"-1"+"-1",DateTime.Today.Year.ToString()+"-12"+"-31",UserName);
			listdlm2 = dlm.SelectLogM("2","",DateTime.Today.Year.ToString()+"-1"+"-1",DateTime.Today.Year.ToString()+"-12"+"-31",UserName);
			try
			{Label10.Text = listdlm1.Count.ToString();}
			catch{Label10.Text = "0";}
			try
			{Label12.Text = listdlm2.Count.ToString();}
			catch{Label12.Text = "0";}

			listdnf1 = dnf.SelectNAF("1","",DateTime.Today.Year.ToString()+"-1"+"-1",DateTime.Today.Year.ToString()+"-12"+"-31","0");
			listdnf2 = dnf.SelectNAF("2","",DateTime.Today.Year.ToString()+"-1"+"-1",DateTime.Today.Year.ToString()+"-12"+"-31","0");
			listdnf3 = dnf.SelectNAF("3","",DateTime.Today.Year.ToString()+"-1"+"-1",DateTime.Today.Year.ToString()+"-12"+"-31","0");

			try
			{Label6.Text = listdnf1.Count.ToString();}
			catch{Label6.Text = "0";}
			try
			{Label8.Text = listdnf2.Count.ToString();}
			catch{Label8.Text = "0";}
			try
			{Label14.Text = listdnf3.Count.ToString();}
			catch{Label14.Text = "0";}

			IList list =  null;
			list = dof.SelectAffiche_state("1");
			DataGrid1.DataSource = list;
			DataGrid1.DataBind();
			string info = "";
			if(list!=null)
			{
				if(list.Count>0)
				{
					for(int i=0;i<list.Count;i++)
					{
						int n= i+1;
						info +="("+n+")、";
						info +=((NrOA.Affiche.em.affiche)(list)[i]).Affiche_content;
						info +="                                                  ";
					}
				}
			}

			//lbWarn.InnerText = info;


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
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);
			this.LinkButton2.Click += new System.EventHandler(this.LinkButton2_Click);
			this.LinkButton6.Click += new System.EventHandler(this.LinkButton6_Click);
			this.LinkButton7.Click += new System.EventHandler(this.LinkButton7_Click);
			this.LinkButton3.Click += new System.EventHandler(this.LinkButton3_Click);
			this.LinkButton5.Click += new System.EventHandler(this.LinkButton5_Click);
			this.LinkButton4.Click += new System.EventHandler(this.LinkButton4_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.location='TroubleDeal/TrbD.htm';</script>");
		}

		private void LinkButton2_Click(object sender, System.EventArgs e)
		{
			Session["state"] = "deal";
			Response.Write("<script>window.location='TroubleDeal/TrbD.htm';</script>");
		}

		private void LinkButton6_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.location='LogManage/LogM.htm';</script>");
		}

		private void LinkButton7_Click(object sender, System.EventArgs e)
		{
			Session["state"] = "deal";
			Response.Write("<script>window.location='LogManage/LogM.htm';</script>");
		}

		private void LinkButton3_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script>window.location='NewAndFinish/NewAndFin.htm';</script>");
		}

		private void LinkButton4_Click(object sender, System.EventArgs e)
		{
			Session["state"] = "end";
			Response.Write("<script>window.location='NewAndFinish/NewAndFin.htm';</script>");
		}

		private void LinkButton5_Click(object sender, System.EventArgs e)
		{
			Session["state"] = "deal";
			Response.Write("<script>window.location='NewAndFinish/NewAndFin.htm';</script>");
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.AlternatingItem) ||
				(e.Item.ItemType == ListItemType.Item))
			{
				
			}
		}
	}
}
