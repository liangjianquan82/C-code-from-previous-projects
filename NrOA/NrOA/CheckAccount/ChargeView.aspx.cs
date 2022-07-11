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
	/// ChargeView ��ժҪ˵����
	/// </summary>
	public class ChargeView : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label_Title;
		protected System.Web.UI.WebControls.Button ok2;
		protected System.Web.UI.WebControls.Button Button11;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.TextBox TextBox11;
		protected System.Web.UI.WebControls.TextBox TextBox12;
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox tmpTaskID;
		protected System.Web.UI.WebControls.TextBox tmpReturnUrl;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.HtmlControls.HtmlForm addtask;

		protected Hashtable ht = null;

		private string state = "";

		private string Area_id = "";

		private string Charge_ID = "";
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected System.Web.UI.WebControls.DropDownList DropDownList5;

		
		NrOA.Area.pkg.DOArea DoA = new NrOA.Area.pkg.DOArea();
		NrOA.Client.pkg.DOClient DOCL = new NrOA.Client.pkg.DOClient();
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.TextBox TextBox4;

		NrOA.CheckAccount.pkg.DOChargeInfo doci = new NrOA.CheckAccount.pkg.DOChargeInfo();
	
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
				Area_id = Request["Area_id"].ToString();
			}
			catch{}

			try
			{
				Charge_ID = Request["Charge_ID"].ToString();
			}
			catch{}

			Inits();
			if(Page.IsPostBack)
				return;

			NrOA.Poundage.pkg.DOPoundage dop = new NrOA.Poundage.pkg.DOPoundage();
			
			DropDownList3.DataSource = dop.Selet_AllPoundage();
			DropDownList3.DataTextField = "PoundageValue";
			DropDownList3.DataValueField = "PoundageValue";
			DropDownList3.DataBind();

			DropDownList4.DataSource = DoA.SelectAreaAll_LoginIn();
			DropDownList4.DataTextField = "AreaName";
			DropDownList4.DataValueField = "Area_ID";
			DropDownList4.DataBind();
			if(Area_id!="")
			{
				DropDownList4.SelectedValue = Area_id;
			}

			DropDownList5.DataSource = DOCL.SelectClient_byAreaName(DropDownList4.SelectedValue);
			DropDownList5.DataTextField = "ClientName";
			DropDownList5.DataValueField = "ClientOperationID";
			DropDownList5.DataBind();

			DropDownList3.SelectedValue = ((NrOA.Area.em.Area)(DoA.SelectArea_By_ID(int.Parse(DropDownList4.SelectedValue)))[0]).Poundage;

			TextBox2.Text = DropDownList5.SelectedValue;

			if(state=="new")
			{
				Label_Title.Text = "�������";
				TextBox11.Text =  ht["EmployeeName"].ToString();
				TextBox12.Text = DateTime.Now.ToString("yyyy-MM-dd");
			}
			else
			{
				Add();
				Label_Title.Text = "�޸����";
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
			this.DropDownList4.SelectedIndexChanged += new System.EventHandler(this.DropDownList4_SelectedIndexChanged);
			this.DropDownList5.SelectedIndexChanged += new System.EventHandler(this.DropDownList5_SelectedIndexChanged);
			this.ok.Click += new System.EventHandler(this.ok_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//��ʼ������
		private void Inits()
		{			
			
			//����û���Ϣ
			ht=CheckUserLogin();
			//���������ȷ��
			
			//			Button3.Attributes.Add("onclick", "javascript: return isdel()");
			//			Button4.Attributes.Add("onclick", "javascript: return ispost()");
		}
		//����û���Ϣ
		private Hashtable CheckUserLogin()
		{
			Hashtable _ht = (Hashtable)Session["userinfo"];
		
			if(_ht == null)
			{
				Response.Redirect("../login.aspx");
				return null;
			}
			return _ht;
		}
		private void Add()
		{
			IList list = null;
			list = doci.selectCharge_by_id(int.Parse(Charge_ID));
			DropDownList5.SelectedValue = ((NrOA.CheckAccount.em.ChargeInfo)(list)[0]).ClientOperationID;
			TextBox2.Text = ((NrOA.CheckAccount.em.ChargeInfo)(list)[0]).ClientOperationID;
			DropDownList3.SelectedValue = ((NrOA.CheckAccount.em.ChargeInfo)(list)[0]).Now_Poundage;
			DropDownList1.SelectedValue = ((NrOA.CheckAccount.em.ChargeInfo)(list)[0]).Payment_by_Year;
			DropDownList2.SelectedValue = ((NrOA.CheckAccount.em.ChargeInfo)(list)[0]).Payment_by_Month;
			TextBox3.Text = ((NrOA.CheckAccount.em.ChargeInfo)(list)[0]).PaymentYear;

			TextBox11.Text = ((NrOA.CheckAccount.em.ChargeInfo)(list)[0]).RegisterMane;
			TextBox12.Text = ((NrOA.CheckAccount.em.ChargeInfo)(list)[0]).RegisterTime;


		}

		private void save()
		{
			NrOA.CheckAccount.em.ChargeInfo CI = new NrOA.CheckAccount.em.ChargeInfo();
			NrOA.CheckAccount.pkg.DOChargeInfo doci = new NrOA.CheckAccount.pkg.DOChargeInfo();

			CI.ClientName = DropDownList5.SelectedItem.Text;
			
			CI.ClientOperationID = TextBox2.Text;//ҵ�����

			CI.Now_Poundage =DropDownList3.SelectedValue;//�ֳɱ���

			CI.FirstPayment = TextBox3.Text;//������	
				
			CI.PaymentYear = TextBox3.Text;//������

			CI.Payment_by_Year = DropDownList1.SelectedValue;//��Ӧ�ɷ���

			CI.Payment_by_Month =DropDownList2.SelectedValue;//��Ӧ�ɷ���

			CI.RegisterMane = ht["EmployeeName"].ToString();//��ǰ�û�

			CI.RegisterTime = TextBox12.Text;

			int year = int.Parse(CI.Payment_by_Year)+1;

			CI.UseCyc = year.ToString()+"-"+CI.Payment_by_Month;

			if(state=="new")
			{
				doci.FirstPaymentList(CI);
			}
			else
			{
				CI.Charge_ID = int.Parse(Charge_ID);
				doci.Update_Charge_year(CI);
			}

			Response.Write("<script>window.alert('���ݱ���ɹ�');window.location='../CheckAccount/ChargeList.aspx';</script>");
		}
		private void ok2_Click(object sender, System.EventArgs e)
		{
			save();
		}


		private void ok_Click(object sender, System.EventArgs e)
		{
			save();
		}

		private void Button11_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ChargeList.aspx");
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ChargeList.aspx");
		}

		private void DropDownList4_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			DropDownList5.DataSource = DOCL.SelectClient_byAreaName(DropDownList4.SelectedValue);
			DropDownList5.DataTextField = "ClientName";
			DropDownList5.DataValueField = "ClientOperationID";
			DropDownList5.DataBind();		
			TextBox2.Text = DropDownList5.SelectedValue;
			DropDownList3.SelectedValue = ((NrOA.Area.em.Area)(DoA.SelectArea_By_ID(int.Parse(DropDownList4.SelectedValue)))[0]).Poundage;

		}

		private void DropDownList5_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TextBox2.Text = DropDownList5.SelectedValue;
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			IList list = null;
			list = DOCL.SelectClientByFind(TextBox4.Text.Trim(),"0");
			if(list!=null)
			{
				if(list.Count>0)
				{
					DropDownList5.SelectedValue = ((NrOA.Client.em.Client)(list)[0]).ClientOperationID;
					TextBox2.Text = ((NrOA.Client.em.Client)(list)[0]).ClientOperationID;
					DropDownList4.SelectedValue = ((NrOA.Client.em.Client)(list)[0]).AreaName;
				}
			}
		}
	}
}
