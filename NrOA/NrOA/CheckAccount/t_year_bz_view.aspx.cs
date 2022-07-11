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
	/// t_year_bz_view ��ժҪ˵����
	/// </summary>
	public class t_year_bz_view : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label_Title;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox tmpTaskID;
		protected System.Web.UI.WebControls.TextBox tmpReturnUrl;
		protected System.Web.UI.WebControls.RadioButton RadioButton1;
		protected System.Web.UI.WebControls.RadioButton RadioButton2;
		protected System.Web.UI.WebControls.Button bt_jr;
		protected System.Web.UI.WebControls.Button bt_sy;
		protected System.Web.UI.WebControls.Button bt_bz;
		protected System.Web.UI.HtmlControls.HtmlForm addtask;
		protected System.Web.UI.WebControls.TextBox tb_name;
		protected System.Web.UI.WebControls.TextBox tb_ClientOperationID;
		protected System.Web.UI.WebControls.TextBox tb_jr;
		protected System.Web.UI.WebControls.TextBox tb_sy;
		protected System.Web.UI.WebControls.TextBox tb_syfc;
		protected System.Web.UI.WebControls.TextBox tb_jrfc;
		protected System.Web.UI.WebControls.TextBox tb_fc;
	
		private string ClientOperationID = "";
		NrOA.CheckAccount.pkg.dao_t_yicixing dyc = new NrOA.CheckAccount.pkg.dao_t_yicixing();
		NrOA.CheckAccount.pkg.dao_t_huikuan dhk = new NrOA.CheckAccount.pkg.dao_t_huikuan();
		protected System.Web.UI.WebControls.TextBox tb_bz;
		NrOA.CheckAccount.pkg.dao_t_year_bz dbz = new NrOA.CheckAccount.pkg.dao_t_year_bz();
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��

			try
			{
				ClientOperationID = Request["ClientOperationID"].ToString();
			}
			catch{}

			

			if(Page.IsPostBack)
				return;


			tb_ClientOperationID.Text = ClientOperationID;
			IList list = null;
			NrOA.Client.pkg.DOClient dc = new NrOA.Client.pkg.DOClient();
			try
			{
				list = dc.selectClient_by_opid(ClientOperationID);
				tb_name.Text  =  ((NrOA.Client.em.Client)(list)[0]).ClientName;
			}
			catch{}
			try
			{
				tb_fc.Text = ((NrOA.Area.em.Area)( new NrOA.Area.pkg.DOArea().SelectArea_By_ID(int.Parse(((NrOA.Client.em.Client)(list)[0]).AreaName)))[0]).Poundage;
			}
			catch{}
			//Session["ClientOperationID"] = ClientOperationID;
			GetData();
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
			this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
			this.DropDownList2.SelectedIndexChanged += new System.EventHandler(this.DropDownList2_SelectedIndexChanged);
			this.bt_jr.Click += new System.EventHandler(this.bt_jr_Click);
			this.bt_sy.Click += new System.EventHandler(this.bt_sy_Click);
			this.RadioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
			this.RadioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
			this.bt_bz.Click += new System.EventHandler(this.bt_bz_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void  GetData()
		{

			//��ȡ�����			
			IList jrlist = null;
			if(DropDownList1.SelectedValue!="-��ѡ�����-")
			{
				NrOA.CheckAccount.em.t_yicixing yc = new NrOA.CheckAccount.em.t_yicixing();
				yc.t_year = DropDownList1.SelectedValue.Trim();
				yc.usernb = ClientOperationID;
				jrlist = dyc.ycx_by_year_id(yc);

				try
				{
					tb_jr.Text = ((NrOA.CheckAccount.em.t_yicixing)(jrlist)[0]).t_onepay;
				}
				catch{tb_jr.Text ="0";}
				try
				{
					tb_jrfc.Text = ((NrOA.CheckAccount.em.t_yicixing)(jrlist)[0]).month_fc;
				}
				catch{tb_jrfc.Text ="0";}
			}
			



			//��ȡʹ�÷ѣ��������»�ȡ��
			IList sylist = null;
			if(DropDownList1.SelectedValue!="-��ѡ�����-"&&DropDownList2.SelectedValue!="-��ѡ���·�-")
			{
				NrOA.CheckAccount.em.t_huikuan hc = new NrOA.CheckAccount.em.t_huikuan();
				hc.t_year = DropDownList1.SelectedValue.Trim();
				hc.t_month = DropDownList2.SelectedValue.Trim();
				hc.usernb = ClientOperationID;
				sylist = dhk.hu_by_year_id(hc);
				try
				{
					tb_sy.Text = ((NrOA.CheckAccount.em.t_huikuan)(sylist)[0]).month_pay;
				}
				catch{tb_sy.Text = "0";}
				try
				{
					tb_syfc.Text = ((NrOA.CheckAccount.em.t_huikuan)(sylist)[0]).month_fc;
				}
				catch{tb_syfc.Text ="0";}
			}



			//��ȡ��ע��Ϣ
			IList bzlist = null;
			if(DropDownList1.SelectedValue!="-��ѡ�����-")
			{
				NrOA.CheckAccount.em.t_year_bz bz = new NrOA.CheckAccount.em.t_year_bz();
				bz.usernb = ClientOperationID;
				bz.t_year = DropDownList1.SelectedValue.Trim();
				bzlist =dbz.select_t_year_bz_by_year_userid(bz);
				try
				{
					tb_bz.Text = ((NrOA.CheckAccount.em.t_year_bz)(bzlist)[0]).remark;
				}
				catch{tb_bz.Text ="";}
				try
				{
					string type = ((NrOA.CheckAccount.em.t_year_bz)(bzlist)[0]).type.Trim();
					if(type!="1")
					{
						RadioButton1.Checked = true;
						RadioButton2.Checked = false;
					}
					else
					{
						RadioButton1.Checked = false;
						RadioButton2.Checked = true;
					}
				}
				catch
				{
					RadioButton1.Checked = true;
					RadioButton2.Checked = false;
				}
				
			}
			else
			{
				
			}
		}

		private void bt_jr_Click(object sender, System.EventArgs e)
		{
			//����Ѹ���
			NrOA.CheckAccount.em.t_yicixing yc = new NrOA.CheckAccount.em.t_yicixing();
			yc.t_onepay = tb_jr.Text.Trim();
			yc.t_year = DropDownList1.SelectedValue.Trim();
			yc.usernb = ClientOperationID;
			yc.month_fc = tb_jrfc.Text.Trim();

			dyc.update_ycx(yc);
			GetData();

			Response.Write("<script>window.alert('��������ݱ���ɹ�,�籾��û�н�������޷�����');</script>");
		}

		private void bt_sy_Click(object sender, System.EventArgs e)
		{
		    //ʹ�÷Ѹ���
			NrOA.CheckAccount.em.t_huikuan hk = new NrOA.CheckAccount.em.t_huikuan();
			hk.month_pay = tb_sy.Text.Trim();
			hk.t_year = DropDownList1.SelectedValue.Trim();
			hk.usernb = ClientOperationID;
			hk.month_fc = tb_syfc.Text.Trim();
			hk.t_month = DropDownList2.SelectedValue.Trim();

			dhk.update_hk(hk);
			GetData();
			Response.Write("<script>window.alert('ʹ�÷����ݱ���ɹ�,�籾��û��ʹ�÷����޷�����');</script>");
		}

		private void bt_bz_Click(object sender, System.EventArgs e)
		{
			//��ע��״̬���� 1Ϊ�쳣
			IList list = null;
			NrOA.CheckAccount.em.t_year_bz bz = new NrOA.CheckAccount.em.t_year_bz();
			if(DropDownList1.SelectedValue!="-��ѡ�����-")
			{
				
				bz.usernb = ClientOperationID;
				bz.t_year = DropDownList1.SelectedValue.Trim();
				list =dbz.select_t_year_bz_by_year_userid(bz);
			}
			bz.remark = tb_bz.Text.Trim();
			if(RadioButton2.Checked)
			{
				bz.type = "1";
			}
			else
			{
				bz.type = "0";
			}

			if(list!=null)
			{
				if(list.Count>0)
				{
					//����
					dbz.update_t_year_bz_by_year_userid(bz);
				}
				else
				{
					//����
					dbz.insert_t_year_bz(bz);
				}
				
			}
			else
			{
				//����
				dbz.insert_t_year_bz(bz);
			}
			GetData();
			Response.Write("<script>window.alert('��ע��Ϣ���ݱ���ɹ�');</script>");
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

		private void Button1_Click(object sender, System.EventArgs e)
		{
			//����
			Response.Redirect("newlist.aspx?AreaName="+Session.Contents["AreaName"].ToString().Trim());
		}

		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//��������·ݲ�ѯ
			GetData();
		}

		private void DropDownList2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GetData();
		}
	}
}
