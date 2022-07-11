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

namespace NrOA.Duty
{
	/// <summary>
	/// DutyView ��ժҪ˵����
	/// </summary>
	public class DutyView : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label_Title;
		protected System.Web.UI.WebControls.Button ok2;
		protected System.Web.UI.WebControls.Button Button11;
		protected System.Web.UI.WebControls.TextBox tbTaskTitls;
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox tmpTaskID;
		protected System.Web.UI.WebControls.TextBox tmpReturnUrl;
		protected System.Web.UI.HtmlControls.HtmlForm addtask;

		NrOA.Duty.pkg.DODuty dd = new NrOA.Duty.pkg.DODuty();

		private string Duty_ID = "0";
		private string state = "";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			try
			{
				Duty_ID = Request["Duty_ID"].ToString();
			}
			catch{}
			try
			{
				state = Request["state"].ToString();
			}
			catch{}


			if(Page.IsPostBack)
				return;

			if(state=="update")
			{
				Label_Title.Text = "�޸�ְ����Ϣ";
				AddDate();
			}
			else
			{
				Label_Title.Text = "����ְ����Ϣ";
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

		private void AddDate()
		{
			IList list = null; 
			list = dd.select_Duty_id(Duty_ID);
			tbTaskTitls.Text = ((NrOA.Duty.em.Duty)(list)[0]).DutyName; 
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
			if(tbTaskTitls.Text.Trim() =="" )
			{
				
				Response.Write("<script> alert('������ְ������!')</script>");	
				return;
			}
			NrOA.Duty.em.Duty dy = new NrOA.Duty.em.Duty();
			dy.DutyName = tbTaskTitls.Text.Trim();
			if(state=="update")
			{
				dy.Duty_ID = int.Parse(Duty_ID);
				dd.updateDuty(dy);
			}
			else
			{
				dd.insertDuty(dy);
			}
			Response.Write("<script>window.alert('���ݱ���ɹ�');window.location='../Duty/DutyList.aspx?';</script>");
		}

		private void Button11_Click(object sender, System.EventArgs e)
		{
			this.Page.Response.Redirect("DutyList.aspx?");
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			this.Page.Response.Redirect("DutyList.aspx?");
		}
	}
}
