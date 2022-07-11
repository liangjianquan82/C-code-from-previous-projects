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

namespace NrOA.TroubleDeal
{
	/// <summary>
	/// TrbDView 的摘要说明。
	/// </summary>
	public class TrbDView : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label_Title;
		protected System.Web.UI.WebControls.Button ok2;
		protected System.Web.UI.WebControls.Button Button11;
		protected System.Web.UI.WebControls.TextBox Employee_Phone;
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox tmpTaskID;
		protected System.Web.UI.WebControls.TextBox tmpReturnUrl;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.TextBox Dispatch_man;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Dispatch_man1;
		protected System.Web.UI.HtmlControls.HtmlForm addtask;

		private string state = "";
		private Hashtable ht = null;
		private string UserName = "";
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox Trouble_nb;
		protected System.Web.UI.WebControls.TextBox Trouble_date;
		protected System.Web.UI.WebControls.TextBox OperationID;
		protected System.Web.UI.WebControls.TextBox Proposer;
		protected System.Web.UI.WebControls.TextBox ProposerAddress;
		protected System.Web.UI.WebControls.TextBox ProposerPhone;
		protected System.Web.UI.WebControls.TextBox Trouble_Describe;
		protected System.Web.UI.WebControls.TextBox Dispatch_date;
		protected System.Web.UI.WebControls.TextBox DealResult;
		protected System.Web.UI.WebControls.TextBox Deal_date;
		protected System.Web.UI.WebControls.TextBox BackCallContent;
		protected System.Web.UI.WebControls.DropDownList ddListstate;
		protected System.Web.UI.WebControls.TextBox Complaints;
		protected System.Web.UI.WebControls.TextBox Moveinfo;
		protected System.Web.UI.WebControls.TextBox remark;
		protected System.Web.UI.WebControls.TextBox Register_man;
		protected System.Web.UI.WebControls.TextBox Register_date;
		private string Trouble_id = "";
		private string state1 = "";
		protected System.Web.UI.WebControls.RadioButton RadioButton1;
		protected System.Web.UI.WebControls.RadioButton RadioButton2;
		private string tou = "";

		NrOA.TroubleDeal.pkg.DoTroubleDeal dtd = new NrOA.TroubleDeal.pkg.DoTroubleDeal();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面

			ok.Attributes.Add("onclick", "javascript: return checksave()");
			ok2.Attributes.Add("onclick", "javascript: return checksave()");

			string vbCrLf="\n";
			if (!IsClientScriptBlockRegistered("clientScript")) 
			{
				string  strScript = "<script>" + vbCrLf;
				strScript += "function OpenWin(){" + vbCrLf;
				strScript += "var strs ='' "+vbCrLf;
				strScript += "var strr ='' "+vbCrLf;
				strScript += "var str=window.showModalDialog('VeiwTB.aspx?','选择人员','dialogWidth:35;dialogHeight:20;dialogTop:150;dialogLeft:180;status:no;scrollbars:no;help:no')" + vbCrLf;
				strScript += "if(str!=null) { "+ vbCrLf;
				strScript += " var strold = document.addtask.Dispatch_man.value"+ vbCrLf;
				strScript += " strs = strold + unescape(str)" + vbCrLf;
				strScript += " strr = strs.split('|') "+ vbCrLf;
				strScript += " document.addtask.Dispatch_man1.value = strr[0] " + vbCrLf;
				strScript += " document.addtask.Dispatch_man.value = strr[1] " + vbCrLf;
				strScript += "}" + vbCrLf;
				strScript += "}" + vbCrLf;
				strScript += "</script>" + vbCrLf;
				RegisterClientScriptBlock("clientScript", strScript);
			}

			ht = (Hashtable)Session["userinfo"];

			try
			{
				UserName = ht["EmployeeName"].ToString();
			}
			catch{}

			try
			{
				Trouble_id = Request["Trouble_id"].ToString();
			}
			catch{}
			try
			{
				state1 = Request["state1"].ToString();
			}
			catch{}

			try
			{
				state = Request["state"].ToString();
			}
			catch{}


			if(Page.IsPostBack)
				return;
			LinkButton1.Attributes.Add("onclick", "OpenWin()");

			Dispatch_date.Text = DateTime.Now.ToString("yyyy-MM-dd");
			
			if(state=="update")
			{
				Label_Title.Text = "处理故障信息";
				AddDate();
			}
			else
			{
				Label_Title.Text = "新增故障信息";
				Trouble_nb.Enabled = false;
				Trouble_date.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				ddListstate.SelectedValue="1";
			}

			if(ddListstate.SelectedValue=="2")
			{
				Deal_date.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			}
			else
			{
				Deal_date.Text = "";
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
			this.Button11.Click += new System.EventHandler(this.Button11_Click);
			this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);
			this.Dispatch_date.TextChanged += new System.EventHandler(this.Dispatch_date_TextChanged);
			this.ok.Click += new System.EventHandler(this.ok_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.RadioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
			this.RadioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void AddDate()
		{
			//添加
			IList list = null;
			list = dtd.selectTrbid(Trouble_id);
			try
			{
				Trouble_nb.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).Trouble_nb;
			}
			catch{}			
			try
			{
				Trouble_date.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).Trouble_date;
			}
			catch{}			
			try
			{
				OperationID.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).OperationID;
			}
			catch{}			
			try
			{
				Proposer.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).Proposer;
			}
			catch{}			
			try
			{
				ProposerAddress.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).ProposerAddress;
			}
			catch{}			
			try
			{
				ProposerPhone.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).ProposerPhone;
			}
			catch{}			
			try
			{
				Trouble_Describe.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).Trouble_Describe;
			}
			catch{}			
			try
			{
				Dispatch_man.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).Dispatch_man;
			}
			catch{}			
			try
			{
				Dispatch_date.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).Dispatch_date;
			}
			catch{}			
			try
			{
				DealResult.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).DealResult;
			}
			catch{}			
			try
			{
				Deal_date.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).Deal_date;
			}
			catch{}			
			try
			{
				BackCallContent.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).BackCallContent;
			}
			catch{}			
			try
			{
				ddListstate.SelectedValue = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).state;
			}
			catch{}			
			try
			{
				Complaints.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).Complaints;
			}
			catch{}			
			try
			{
				Moveinfo.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).Moveinfo;
			}
			catch{}			
			try
			{
				remark.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).remark;
			}
			catch{}			
			try
			{
				Register_man.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).Register_man;
			}
			catch{}			
			try
			{
				Register_date.Text = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).Register_date;
			}
			catch{}
		}

		private void ok2_Click(object sender, System.EventArgs e)
		{
			savedata();
		}

		private void ok_Click(object sender, System.EventArgs e)
		{
			savedata();
		}

		private void savedata()
		{
			NrOA.TroubleDeal.em.TroubleDeal td = new NrOA.TroubleDeal.em.TroubleDeal();
			td.Trouble_nb = Trouble_nb.Text.Trim();
			td.Trouble_date = Trouble_date.Text.Trim();
			td.OperationID = OperationID.Text.Trim();
			td.Proposer = Proposer.Text.Trim();
			td.ProposerAddress = ProposerAddress.Text.Trim();
			td.ProposerPhone = ProposerPhone.Text.Trim();
			td.Trouble_Describe = Trouble_Describe.Text.Trim();
			td.Dispatch_man = Dispatch_man.Text.Trim();


			if(Dispatch_date.Text.Trim()!="")
			{
				td.Dispatch_date = DateTime.Parse(Dispatch_date.Text.Trim()).ToString("yyyy-MM-dd HH:mm:ss");
			}
			else
				td.Dispatch_date = "";

			td.DealResult = DealResult.Text.Trim();
			td.Deal_date = Deal_date.Text.Trim();
			td.BackCallContent = BackCallContent.Text.Trim();
			td.state = ddListstate.SelectedValue;
			td.Complaints = Complaints.Text.Trim();
			td.Moveinfo = Moveinfo.Text.Trim();
			td.remark = remark.Text.Trim();
			td.Register_man = Register_man.Text.Trim();
			td.Register_date = Register_date.Text.Trim();

			if(state=="update")
			{
				td.Trouble_id = int.Parse(Trouble_id);
				//更新
				dtd.UpdateTrbinfo(td);
			}
			else
			{
				//新增
				if(RadioButton1.Checked)
				{
					tou = "NR";
				}
				else
				{
					tou = "WT";
				}
				td.Register_man = UserName;
				dtd.insertTrbinfo(td,tou);
			}
			Response.Write("<script>window.alert('数据保存成功');window.location='../TroubleDeal/TrbDList.aspx?state="+state1+"';</script>");
		
		}

		private void Button11_Click(object sender, System.EventArgs e)
		{
			this.Page.Response.Redirect("TrbDList.aspx?state="+state1);
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			this.Page.Response.Redirect("TrbDList.aspx?state="+state1);
		}

		private void Dispatch_date_TextChanged(object sender, System.EventArgs e)
		{
			ddListstate.SelectedValue = "2";
		}

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
			ddListstate.SelectedValue = "2";
			if(Dispatch_date.Text.Trim()=="")
			{
				Dispatch_date.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			}
			else
			{
				Dispatch_date.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			}
		}

		private void RadioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			RadioButton1.Checked = true;
			RadioButton2.Checked = false;
		}

		private void RadioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			RadioButton1.Checked = false;
			RadioButton2.Checked = true;
		}

	}

}
