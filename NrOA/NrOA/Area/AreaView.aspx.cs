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

namespace NrOA.Area
{
	/// <summary>
	/// AreaView ��ժҪ˵����
	/// </summary>
	public class AreaView : System.Web.UI.Page
	{

		private int Area_ID = 0;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.TextBox tbTaskTitls;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.TextBox tbText;
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox tmpTaskID;
		protected System.Web.UI.WebControls.TextBox tmpReturnUrl;
		protected System.Web.UI.WebControls.Button ok2;
		protected System.Web.UI.WebControls.Button Button11;
		protected System.Web.UI.WebControls.Label Label_Title;
		private string state = "";

		protected Hashtable ht = null;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		private string UserName = "";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��

			ok.Attributes.Add("onclick","javascript: return checksave()");
			ok2.Attributes.Add("onclick","javascript: return checksave()");

			try
			{
				state = Request["state"].ToString();
			}
			catch{}

			try
			{
				Area_ID = int.Parse(Request["Area_ID"].ToString());
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
			NrOA.Poundage.pkg.DOPoundage dop = new NrOA.Poundage.pkg.DOPoundage();
			DropDownList1.DataSource = dop.Selet_AllPoundage();
			DropDownList1.DataTextField = "PoundageValue";
			DropDownList1.DataValueField = "PoundageValue";
			DropDownList1.DataBind();

			if(UserName=="user")
			{
				ok.Visible = false;
				ok2.Visible = false;
				
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
			this.ok2.Click += new System.EventHandler(this.ok2_Click);
			this.Button11.Click += new System.EventHandler(this.Button11_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Add()
		{
			NrOA.Area.pkg.DOArea doa = new NrOA.Area.pkg.DOArea();
			IList list = doa.SelectArea_By_ID(Area_ID);
			if(list!=null)
			{
				if(list.Count!=0)
				{
					tbTaskTitls.Text= ((NrOA.Area.em.Area)(list)[0]).AreaName;
					DropDownList1.SelectedValue = ((NrOA.Area.em.Area)(list)[0]).Poundage;
					tbText.Text = ((NrOA.Area.em.Area)(list)[0]).AreaRemark;
					TextBox1.Text = ((NrOA.Area.em.Area)(list)[0]).Area_listid;
				}
			}
		}

		private void ok2_Click(object sender, System.EventArgs e)
		{
			
			SaveData();
		}

		private void ok_Click(object sender, System.EventArgs e)
		{
			SaveData();
		}
		private void SaveData()
		{
			NrOA.Area.pkg.DOArea doa = new NrOA.Area.pkg.DOArea();
			NrOA.Area.em.Area ar = new NrOA.Area.em.Area();
			ar.AreaName = tbTaskTitls.Text.Trim();
			ar.Poundage = DropDownList1.SelectedValue.ToString();
			ar.AreaRemark = tbText.Text.Trim();
			ar.Area_listid = TextBox1.Text.Trim();
			if(state=="new")
			{
				doa.InsertAreaInfo(ar);
			}
			else
			{
				ar.Area_ID = Area_ID;
				doa.Update_AreaInfo(ar);

			}
			Response.Write("<script>window.alert('���ݱ���ɹ�');window.location='../Area/Arealist.aspx';</script>");
		}

		private void Button11_Click(object sender, System.EventArgs e)
		{
			Page.Response.Redirect("Arealist.aspx");
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Page.Response.Redirect("Arealist.aspx");
		}
	}
}
