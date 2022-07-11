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

namespace NrOA.Branch
{
	/// <summary>
	/// BranchView ��ժҪ˵����
	/// </summary>
	public class BranchView : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label_Title;
		protected System.Web.UI.WebControls.Button ok2;
		protected System.Web.UI.WebControls.Button Button11;
		protected System.Web.UI.WebControls.TextBox tbTaskTitls;
		protected System.Web.UI.WebControls.TextBox tbText;
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox tmpTaskID;
		protected System.Web.UI.WebControls.TextBox tmpReturnUrl;
		protected System.Web.UI.HtmlControls.HtmlForm addtask;


		private string state = "";
		private int Branch_ID = 0;
	
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
				Branch_ID = int.Parse(Request["Branch_ID"].ToString());
			}
			catch{}
			if(IsPostBack)
				return;
			if(state=="update")
			{
				Add();
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
			this.ok.Click += new System.EventHandler(this.ok_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Add()
		{
			NrOA.Branch.pkg.DOBranch dob = new NrOA.Branch.pkg.DOBranch();
			IList list = dob.BranchInfo_by_id(Branch_ID);
			if(list!=null)
			{
				if(list.Count!=0)
				{
					tbTaskTitls.Text= ((NrOA.Branch.em.Branch)(list)[0]).BranchName;
					
					tbText.Text = ((NrOA.Branch.em.Branch)(list)[0]).BranchRemark;
				}
			}
		}

		private void SaveData()
		{
			NrOA.Branch.pkg.DOBranch dob = new NrOA.Branch.pkg.DOBranch();
			NrOA.Branch.em.Branch ar = new NrOA.Branch.em.Branch();
			ar.BranchName = tbTaskTitls.Text.Trim();
			
			ar.BranchRemark = tbText.Text.Trim();
			if(state=="new")
			{
				dob.insertBranchInfo(ar);
			}
			else
			{
				ar.Branch_ID = Branch_ID;
				dob.UpdateBranchInfo(ar);

			}
			Response.Write("<script>window.alert('���ݱ���ɹ�');window.location='../Branch/BranchList.aspx';</script>");
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
			Page.Response.Redirect("BranchList.aspx");
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Page.Response.Redirect("BranchList.aspx");
		}
	}
}
