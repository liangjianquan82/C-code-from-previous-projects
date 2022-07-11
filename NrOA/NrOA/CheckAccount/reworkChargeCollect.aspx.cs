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
	/// reworkChargeCollect 的摘要说明。
	/// </summary>
	public class reworkChargeCollect : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label_Title;
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox tmpTaskID;
		protected System.Web.UI.WebControls.TextBox tmpReturnUrl;
		protected System.Web.UI.WebControls.TextBox TextBox4;
		protected System.Web.UI.WebControls.TextBox ClientOperationID;
		protected System.Web.UI.WebControls.TextBox Poundage;
		protected System.Web.UI.WebControls.TextBox OneOffConnectFees;
		protected System.Web.UI.WebControls.TextBox MovePay;
		protected System.Web.UI.WebControls.TextBox OMPoundage;
		protected System.Web.UI.WebControls.TextBox oneyue;
		protected System.Web.UI.WebControls.TextBox onePoundage;
		protected System.Web.UI.WebControls.TextBox twoyue;
		protected System.Web.UI.WebControls.TextBox twoPoundage;
		protected System.Web.UI.WebControls.TextBox threeyue;
		protected System.Web.UI.WebControls.TextBox threePoundage;
		protected System.Web.UI.WebControls.TextBox fouryue;
		protected System.Web.UI.WebControls.TextBox fourPoundage;
		protected System.Web.UI.WebControls.TextBox fiveyue;
		protected System.Web.UI.WebControls.TextBox fivePoundage;
		protected System.Web.UI.WebControls.TextBox sixyue;
		protected System.Web.UI.WebControls.TextBox sixPoundage;
		protected System.Web.UI.WebControls.TextBox sevenyue;
		protected System.Web.UI.WebControls.TextBox sevenPoundage;
		protected System.Web.UI.WebControls.TextBox eightyue;
		protected System.Web.UI.WebControls.TextBox eightPoundage;
		protected System.Web.UI.WebControls.TextBox nineyue;
		protected System.Web.UI.WebControls.TextBox ninePoundage;
		protected System.Web.UI.WebControls.TextBox tenyue;
		protected System.Web.UI.WebControls.TextBox tenPoundage;
		protected System.Web.UI.WebControls.TextBox elevenyue;
		protected System.Web.UI.WebControls.TextBox elevenPoundage;
		protected System.Web.UI.WebControls.TextBox twelveyue;
		protected System.Web.UI.WebControls.TextBox twelvePoundage;
		protected System.Web.UI.WebControls.TextBox remark;
		protected System.Web.UI.WebControls.DropDownList state;
		protected System.Web.UI.HtmlControls.HtmlForm addtask;
		protected string id = "";
		NrOA.CheckAccount.pkg.DOBackFundInfo dbfi = new NrOA.CheckAccount.pkg.DOBackFundInfo();
		protected string year = "";
		protected string area_id = "";
		protected string year1 = "";
		protected string area_id1 = "";
		protected string PageIndex = "";
		protected string state1 = "";
		protected string month = "";
		protected IList list = null;
		NrOA.Client.pkg.DOClient dc = new NrOA.Client.pkg.DOClient();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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
				year1 = Session.Contents["year"].ToString();
			}
			catch{year1 = "0";}
			try
			{
				month = Session.Contents["month"].ToString();
			}
			catch{month = "0";}
			try
			{
				area_id1 = Session.Contents["Area_id"].ToString();
			}
			catch{area_id1 = "0";}
			try
			{
				state1 = Session.Contents["state"].ToString();
			}
			catch{state1 = "0";}
			list = dbfi.selectChargeCollect_by_id(id);
			TextBox4.Text =((NrOA.Client.em.Client)( dc.selectClient_by_opid(((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).ClientOperationID))[0]).ClientName;
			year = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).year;
			area_id = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).area_id;
			if(Page.IsPostBack)
				return;
			getdata();
			
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
			this.ok.Click += new System.EventHandler(this.ok_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void getdata()
		{
					
			

			OneOffConnectFees.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).OneOffConnectFees;
			MovePay.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).MovePay;
			OMPoundage.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).OMPoundage;

			oneyue.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).oneyue;
			onePoundage.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).onePoundage;

			twoyue.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).twoyue;
			twoPoundage.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).twoPoundage;

			threeyue.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).threeyue;
			threePoundage.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).threePoundage;

			fouryue.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).fouryue;
			fourPoundage.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).fourPoundage;

			fiveyue.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).fiveyue;
			fivePoundage.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).fivePoundage;

			sixPoundage.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).sixPoundage;
			sixyue.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).sixyue;

			sevenPoundage.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).sevenPoundage;
			sevenyue.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).sevenyue;

			eightyue.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).eightyue;
			eightPoundage.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).eightPoundage;

			nineyue.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).nineyue;
			ninePoundage.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).ninePoundage;

			tenyue.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).tenyue;
			tenPoundage.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).tenPoundage;

			elevenyue.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).elevenyue;
			elevenPoundage.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).elevenPoundage;

			twelveyue.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).twelveyue;
			twelvePoundage.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).twelvePoundage;

			ClientOperationID.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).ClientOperationID;
			Poundage.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).Poundage;
			remark.Text = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).remark;

			state.SelectedValue = ((NrOA.CheckAccount.em.ChargeCollect)(list)[0]).state;
		}

		private void savedata()
		{
			NrOA.CheckAccount.em.ChargeCollect cc = new NrOA.CheckAccount.em.ChargeCollect();
			cc.year = year ;
			cc.area_id = area_id ;

			cc.OneOffConnectFees = OneOffConnectFees.Text ;
			cc.MovePay = MovePay.Text ;
			cc.OMPoundage = OMPoundage.Text ;

			cc.oneyue = oneyue.Text ;
			cc.onePoundage = onePoundage.Text ;

			cc.twoyue = twoyue.Text ;
			cc.twoPoundage = twoPoundage.Text ;

			cc.threeyue = threeyue.Text ;
			cc.threePoundage = threePoundage.Text ;

			cc.fouryue = fouryue.Text ;
			cc.fourPoundage = fourPoundage.Text ;

			cc.fiveyue = fiveyue.Text ;
			cc.fivePoundage = fivePoundage.Text ;

			cc.sixPoundage = sixPoundage.Text ;
			cc.sixyue = sixyue.Text ;

			cc.sevenPoundage = sevenPoundage.Text ;
			cc.sevenyue = sevenyue.Text ;

			cc.eightyue = eightyue.Text ;
			cc.eightPoundage = eightPoundage.Text ;

			cc.nineyue = nineyue.Text ;
			cc.ninePoundage = ninePoundage.Text ;

			cc.tenyue = tenyue.Text ;
			cc.tenPoundage = tenPoundage.Text ;

			cc.elevenyue = elevenyue.Text ;
			cc.elevenPoundage = elevenPoundage.Text ;

			cc.twelveyue = twelveyue.Text ;
			cc.twelvePoundage = twelvePoundage.Text ;

			cc.ClientOperationID = ClientOperationID.Text ;
			cc.Poundage = Poundage.Text ;
			cc.remark = remark.Text ;

			cc.state = state.SelectedValue ;
			cc.id = int.Parse(id);
			try
			{
				dbfi.updateClientintChargel(cc);
			
				Session["PageIndex"] = PageIndex;
				Session["year"] =year1;
				Session["month"] =month;
				Session["Area_id"] =area_id1;
				Session["state"] =state1;

				Response.Write("<script>window.alert('数据保存成功');window.location='../CheckAccount/BackFundList.aspx';</script>");
			}
			catch
			{
				return ;
			}
		}

		private void ok_Click(object sender, System.EventArgs e)
		{
			//提交
			savedata();
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Session["PageIndex"] = PageIndex;
			Session["year"] =year1;
			Session["month"] =month;
			Session["Area_id"] =area_id1;
			Session["state"] =state1;
			Response.Redirect("BackFundList.aspx");
		}
	}
}
