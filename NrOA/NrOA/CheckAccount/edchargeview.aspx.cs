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

namespace NrOA.CheckAccount
{
	/// <summary>
	/// edchargeview ��ժҪ˵����
	/// </summary>
	public class edchargeview : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label_Title;
		protected System.Web.UI.WebControls.TextBox ClientOperationID;
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox tmpTaskID;
		protected System.Web.UI.WebControls.TextBox tmpReturnUrl;
		protected System.Web.UI.WebControls.TextBox ClientName;
		protected string id = "";	
		protected string PageIndex = "";	
		protected string year = "";
		protected System.Web.UI.HtmlControls.HtmlForm addtask;	
		protected string month = "";	

		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			try
			{
				id = Request["id"].ToString();
			}
			catch{}
			try
			{
				PageIndex = Session.Contents["PageIndex"].ToString();
			}
			catch{PageIndex = "0";}
			try
			{
				year = Session.Contents["year"].ToString();
			}
			catch{year = DateTime.Now.Year.ToString();}
			try
			{
				month = Session.Contents["month"].ToString();
			}
			catch{month = DateTime.Now.Month.ToString();}
			
			if(Page.IsPostBack)
				return;
			getdata();
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
			this.ok.Click += new System.EventHandler(this.ok_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void getdata()
		{
			IList list = null;
			NrOA.CheckAccount.pkg.DOChargeInfo dc = new NrOA.CheckAccount.pkg.DOChargeInfo();
			list = dc.selectCharge_by_id(int.Parse(id));
			ClientOperationID.Text = ((NrOA.CheckAccount.em.ChargeInfo)(list)[0]).ClientOperationID;
			ClientName.Text = ((NrOA.CheckAccount.em.ChargeInfo)(list)[0]).ClientName;

		}

		private void ok_Click(object sender, System.EventArgs e)
		{
			NrOA.CheckAccount.em.ChargeInfo cc = new NrOA.CheckAccount.em.ChargeInfo();
			NrOA.CheckAccount.pkg.DOChargeInfo dci = new NrOA.CheckAccount.pkg.DOChargeInfo();
			cc.Charge_ID = int.Parse(id);
			cc.ClientName = ClientName.Text.Trim();
			cc.ClientOperationID = ClientOperationID.Text.Trim();
			dci.updateClientOperationID(cc);
			
			Session["PageIndex"] = PageIndex;
			Session["year"] = year;
			Session["month"] = month;
			Response.Write("<script>window.alert('���ݱ���ɹ�');window.location='../CheckAccount/JFnotintList.aspx';</script>");
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Session["PageIndex"] = PageIndex;
			Session["year"] = year;
			Session["month"] = month;
			Response.Redirect("JFnotintList.aspx");
		}
	}
}
