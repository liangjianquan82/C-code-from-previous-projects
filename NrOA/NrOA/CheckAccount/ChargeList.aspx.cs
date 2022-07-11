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
	/// ChargeList ��ժҪ˵����
	/// </summary>
	public class ChargeList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblPageCount;
		protected System.Web.UI.WebControls.Label lblCurrentIndex;
		protected System.Web.UI.WebControls.LinkButton btnFirst;
		protected System.Web.UI.WebControls.LinkButton btnPrev;
		protected System.Web.UI.WebControls.LinkButton btnNext;
		protected System.Web.UI.WebControls.LinkButton btnLast;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden selvalues;


		protected Hashtable ht = null;
		protected int count =0;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected System.Web.UI.WebControls.Button Button4;
		protected System.Web.UI.WebControls.Button Button5;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList DropDownList5;
		private string find = "1";

		protected NrOA.CheckAccount.em.ChargeInfo CIF = new NrOA.CheckAccount.em.ChargeInfo();
		protected NrOA.CheckAccount.pkg.DOChargeInfo DCI = new NrOA.CheckAccount.pkg.DOChargeInfo();
		protected NrOA.CheckAccount.em.ChargeInfo CI = new NrOA.CheckAccount.em.ChargeInfo();
		protected NrOA.CheckAccount.pkg.DealChargeTable DCT = new NrOA.CheckAccount.pkg.DealChargeTable();
		protected NrOA.Poundage.pkg.DOPoundage dopd = new NrOA.Poundage.pkg.DOPoundage();

		private decimal yearPay =0;
		private decimal monthPay =0;
		private decimal CFP = 0;
		private decimal one = 1;

//		private string year="";
//		private string startMonth="";
//		private string endMonth="";
//		private string Area_ID = "";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			btnFirst.Text = "����ҳ";
			btnPrev.Text = "ǰһҳ";
			btnNext.Text = "��һҳ";
			btnLast.Text = "���ҳ";

//			try
//			{
//				year = Session.Contents["year"].ToString();
//				startMonth = Session.Contents["startMonth"].ToString();
//				endMonth = Session.Contents["endMonth"].ToString();
//				Area_ID = Session.Contents["Area_ID"].ToString();
//			}
//			catch{}

			Inits();
			if(Page.IsPostBack)
				return;
			
			DropDownList1.SelectedValue = DateTime.Today.Year.ToString();
//			Session["year"] = DropDownList1.SelectedValue;
			DropDownList2.SelectedValue = DateTime.Today.AddMonths(-1).Month.ToString();
//			Session["startMonth"]  = DropDownList2.SelectedValue;
			DropDownList5.SelectedValue = DateTime.Today.AddMonths(-1).Month.ToString();
//			Session["endMonth"] = DropDownList5.SelectedValue;
			
			try
			{
				if (Request["page"]!=null)
					DataGrid1.CurrentPageIndex = int.Parse(Request["page"].ToString());
			}
			catch
			{
				DataGrid1.CurrentPageIndex = 0;
			}

			NrOA.Area.pkg.DOArea DoA = new NrOA.Area.pkg.DOArea();

			DropDownList3.DataSource = DoA.SelectAreaAll_LoginIn();
			DropDownList3.DataTextField = "AreaName";
			DropDownList3.DataValueField = "Area_ID";
			DropDownList3.DataBind();
			//Session["Area_ID"] = DropDownList3.SelectedValue.ToString();
			DropDownList3.Items.Insert(0,"����С��");

			BindGrid();

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
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Button5.Click += new System.EventHandler(this.Button5_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//��ʼ������
		private void Inits()
		{
			int screen_width = 1024;
			try
			{
				screen_width = int.Parse(Session["screen_width"].ToString());
			}
			catch
			{
				screen_width = 1024;
			}

			if(screen_width == 800)
			{
				this.DataGrid1.Height = 255;
				this.DataGrid1.PageSize = 10;
			}
			else if(screen_width == 1024)
			{
				this.DataGrid1.Height = 425;
				this.DataGrid1.PageSize = 15;
			}
			
			//����û���Ϣ
			ht=CheckUserLogin();
			//���������ȷ��
			
			Button3.Attributes.Add("onclick", "javascript: return isdel()");
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
		private void LoadData()
		{
			//�������ݼ�

			IList list = null;
			DataTable dt = null;

			try
			{
				DropDownList2.SelectedValue = Session.Contents["strMonth"].ToString();
				DropDownList5.SelectedValue = Session.Contents["endMonth"].ToString();
			}
			catch{}

			//-��ѡ��С��-
			if(this.find=="1")
			{
				if(DropDownList4.SelectedValue=="1")
				{
					//δ�ؿ��û�
					Label6.Text = "δ�ؿ��û�";
					//list = DCI.Find_List();
				}
				else if(DropDownList4.SelectedValue=="2")
				{
					//���ֳɱ�������
					Label6.Text = "���ֳɱ�������";
					
					DataGrid1.Columns[5].Visible = true;
					DataGrid1.Columns[6].Visible = true;
					DataGrid1.Columns[7].Visible = true;

					DataGrid1.Columns[8].Visible = false;
					DataGrid1.Columns[9].Visible = false;
					DataGrid1.Columns[10].Visible = false;
					DataGrid1.Columns[11].Visible = false;
					DataGrid1.Columns[12].Visible = false;
					DataGrid1.Columns[13].Visible = false;
					DataGrid1.Columns[14].Visible = false;
					DataGrid1.Columns[15].Visible = false;

					list = DCI.Find_List(DropDownList1.SelectedValue,DropDownList2.SelectedValue,DropDownList5.SelectedValue,DropDownList3.SelectedValue,2);
				}
				else if(DropDownList4.SelectedValue=="3")
				{
					//����ѽɷ��û�
					Label6.Text = "����ѽɷ��û�";
					DataGrid1.Columns[5].Visible = false;
					DataGrid1.Columns[6].Visible = false;
					DataGrid1.Columns[7].Visible = false;

					DataGrid1.Columns[8].Visible = true;
					DataGrid1.Columns[9].Visible = true;
					DataGrid1.Columns[10].Visible = true;

					DataGrid1.Columns[11].Visible = false;
					DataGrid1.Columns[12].Visible = false;
					DataGrid1.Columns[13].Visible = false;
					
					DataGrid1.Columns[14].Visible = false;
					DataGrid1.Columns[15].Visible = false;
					list = DCI.Find_List(DropDownList1.SelectedValue,DropDownList2.SelectedValue,DropDownList5.SelectedValue,DropDownList3.SelectedValue,3);
				}
				else if(DropDownList4.SelectedValue=="4")
				{
					//Ǩ�Ʒѽɷ��û�
					Label6.Text = "Ǩ�Ʒѽɷ��û�";
					DataGrid1.Columns[5].Visible = false;
					DataGrid1.Columns[6].Visible = false;
					DataGrid1.Columns[7].Visible = false;

					DataGrid1.Columns[8].Visible = false;
					DataGrid1.Columns[9].Visible = false;
					DataGrid1.Columns[10].Visible = true;

					DataGrid1.Columns[11].Visible = false;
					DataGrid1.Columns[12].Visible = false;
					DataGrid1.Columns[13].Visible = false;

					DataGrid1.Columns[14].Visible = true;
					DataGrid1.Columns[15].Visible = true;
					list = DCI.Find_List(DropDownList1.SelectedValue,DropDownList2.SelectedValue,DropDownList5.SelectedValue,DropDownList3.SelectedValue,4);
				}
				else if(DropDownList4.SelectedValue=="5")
				{
					//����б�
					Label6.Text = "����б�";
					DataGrid1.Columns[5].Visible = true;
					DataGrid1.Columns[6].Visible = true;
					DataGrid1.Columns[7].Visible = true;

					DataGrid1.Columns[8].Visible = false;
					DataGrid1.Columns[9].Visible = false;
					DataGrid1.Columns[10].Visible = false;

					DataGrid1.Columns[11].Visible = false;
					DataGrid1.Columns[12].Visible = false;
					DataGrid1.Columns[13].Visible = false;

					DataGrid1.Columns[14].Visible = false;
					DataGrid1.Columns[15].Visible = false;
					list = DCI.Find_List(DropDownList1.SelectedValue,DropDownList2.SelectedValue,DropDownList5.SelectedValue,DropDownList3.SelectedValue,5);
				}
				else if(DropDownList4.SelectedValue=="6")
				{
					//һ�����б�
					Label6.Text = "һ�����б�";
					DataGrid1.Columns[5].Visible = false;
					DataGrid1.Columns[6].Visible = false;
					DataGrid1.Columns[7].Visible = false;

					DataGrid1.Columns[8].Visible = true;
					DataGrid1.Columns[9].Visible = true;
					DataGrid1.Columns[10].Visible = true;

					DataGrid1.Columns[11].Visible = false;
					DataGrid1.Columns[12].Visible = false;
					DataGrid1.Columns[13].Visible = false;

					DataGrid1.Columns[14].Visible = true;
					DataGrid1.Columns[15].Visible = true;
					list = DCI.Find_List(DropDownList1.SelectedValue,DropDownList2.SelectedValue,DropDownList5.SelectedValue,DropDownList3.SelectedValue,6);
				}
				else if(DropDownList4.SelectedValue=="7")
				{
					//�ؿ�/�½��б�
					Label6.Text = "�ؿ�/�½��б�";
					DataGrid1.Columns[5].Visible = false;
					DataGrid1.Columns[6].Visible = false;
					DataGrid1.Columns[7].Visible = false;

					DataGrid1.Columns[8].Visible = false;
					DataGrid1.Columns[9].Visible = false;
					DataGrid1.Columns[10].Visible = false;

					DataGrid1.Columns[11].Visible = true;
					DataGrid1.Columns[12].Visible = true;
					DataGrid1.Columns[13].Visible = true;

					DataGrid1.Columns[14].Visible = false;
					DataGrid1.Columns[15].Visible = false;
					list = DCI.Find_List(DropDownList1.SelectedValue,DropDownList2.SelectedValue,DropDownList5.SelectedValue,DropDownList3.SelectedValue,7);
				}
				else if(DropDownList4.SelectedValue=="8")
				{
					//�½�ֳɱ�������
					Label6.Text = "�½�ֳɱ�������";
					list = DCI.Find_List(DropDownList1.SelectedValue,DropDownList2.SelectedValue,DropDownList5.SelectedValue,DropDownList3.SelectedValue,8);
				}
				else if(DropDownList4.SelectedValue=="9")
				{
					//һ���Էֳɱ�������
					Label6.Text = "һ���Էֳɱ�������";
					DataGrid1.Columns[5].Visible = false;
					DataGrid1.Columns[6].Visible = false;
					DataGrid1.Columns[7].Visible = false;

					DataGrid1.Columns[8].Visible = true;
					DataGrid1.Columns[9].Visible = true;
					DataGrid1.Columns[10].Visible = true;

					DataGrid1.Columns[11].Visible = false;
					DataGrid1.Columns[12].Visible = false;
					DataGrid1.Columns[13].Visible = false;

					DataGrid1.Columns[14].Visible = true;
					DataGrid1.Columns[15].Visible = true;
					list = DCI.Find_List(DropDownList1.SelectedValue,DropDownList2.SelectedValue,DropDownList5.SelectedValue,DropDownList3.SelectedValue,9);
				}

				if(TextBox1.Text.Trim()!="")
				{
					list = DCI.select_ChargeStr(TextBox1.Text.Trim());
				}				
			}
			else
			{
				//��һ�� ��ѯ ��Ӧ���� ���е� δ�ؿ��û� ��Ϣ
				Label6.Text = "δ�ؿ��û�";
			}
			
			if(list!=null)
			{
				if(list.Count>0)
				{
					count =  list.Count;
					DataGrid1.DataSource = list;
				}				
			}
			
			int tmp=count%DataGrid1.PageSize !=0 || count==0 ? (int) (count/DataGrid1.PageSize) + 1 : (int)(count/DataGrid1.PageSize);
			if(tmp<DataGrid1.CurrentPageIndex + 1)
			{
				DataGrid1.CurrentPageIndex = tmp - 1;
			}		
			DataGrid1.DataBind();

		}
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			int startIndex ;
			startIndex = DataGrid1.CurrentPageIndex * DataGrid1.PageSize;
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
		public void PagerButtonClick(object sender, EventArgs e)
		{
			string arg = ((LinkButton)sender).CommandArgument.ToString();
			switch(arg)
			{
				case "next":
					if (DataGrid1.CurrentPageIndex < (DataGrid1.PageCount - 1))
					{
						DataGrid1.CurrentPageIndex += 1;
					}
					break;
				case "prev":
					if (DataGrid1.CurrentPageIndex > 0)
					{
						DataGrid1.CurrentPageIndex -= 1;
					}
					break;
				case "last":
					DataGrid1.CurrentPageIndex = (DataGrid1.PageCount - 1);
					break;
				default:
					DataGrid1.CurrentPageIndex = System.Convert.ToInt32(arg);
					break;
			}
			BindGrid();
		}

		public void BindGrid()
		{
			LoadData();
			ShowStats();
		}
		private void ShowStats()
		{
			lblCurrentIndex.Text = "�� " + (DataGrid1.CurrentPageIndex + 1).ToString() + " ҳ";
			lblPageCount.Text = "�ܹ� " +count.ToString() + " ����¼ �� " +DataGrid1.PageCount.ToString() + " ҳ";
		}
		protected void LinkButton_Command(Object sender, CommandEventArgs e) 
		{
			//�޸����
			Response.Redirect("ChargeView.aspx?Charge_ID="+e.CommandArgument.ToString()+"&state=update"+"&Area_id="+DropDownList3.SelectedValue);
		}
		protected void LinkButton_Command1(Object sender, CommandEventArgs e) 
		{
			//�޸�һ����
			Response.Redirect("ChargeOneVeiw.aspx?Charge_ID="+e.CommandArgument.ToString()+"&state=update"+"&Area_id="+DropDownList3.SelectedValue+"&state1=one");
		}
		protected void LinkButton_Command2(Object sender, CommandEventArgs e) 
		{
			//�޸��½�
			Response.Redirect("BackFundView.aspx?Charge_ID="+e.CommandArgument.ToString()+"&state=update"+"&Area_id="+DropDownList3.SelectedValue);
		}
		protected void LinkButton_Command3(Object sender, CommandEventArgs e) 
		{
			//�޸�Ǩ�Ʒ�
			Response.Redirect("ChargeOneVeiw.aspx?Charge_ID="+e.CommandArgument.ToString()+"&state=update"+"&Area_id="+DropDownList3.SelectedValue+"&state1=move");
		}
		private void Button2_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ChargeView.aspx?state=new");
		}
		private void Button4_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ChargeOneVeiw.aspx?state=new");
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.AlternatingItem) ||
				(e.Item.ItemType == ListItemType.Item))
			{
				if(e.Item.Cells[4].Text != e.Item.Cells[7].Text)
				{
					e.Item.Cells[7].ForeColor = System.Drawing.Color.Red;
				}
				if(e.Item.Cells[4].Text != e.Item.Cells[10].Text)
				{
					e.Item.Cells[10].ForeColor = System.Drawing.Color.Red;
				}
				if(e.Item.Cells[4].Text != e.Item.Cells[13].Text)
				{
					e.Item.Cells[13].ForeColor = System.Drawing.Color.Red;
				}
				
				try
				{
					yearPay = decimal.Parse(((NrOA.Poundage.em.Poundage)(dopd.Select_pd_by_Value(e.Item.Cells[7].Text))[0]).UseExpenseProportion)* decimal.Parse(e.Item.Cells[17].Text);
					e.Item.Cells[6].Text = yearPay.ToString("0.0");
				}
				catch{}
				try
				{
					if(((NrOA.Poundage.em.Poundage)(dopd.Select_pd_by_Value(e.Item.Cells[10].Text))[0]).ConnectFeesProportion=="2/3")
					{
						CFP = (one*2)/3;
					}
					else
					{
						CFP = decimal.Parse(((NrOA.Poundage.em.Poundage)(dopd.Select_pd_by_Value(e.Item.Cells[10].Text))[0]).ConnectFeesProportion);
					}
					monthPay = CFP * decimal.Parse(e.Item.Cells[18].Text);
					e.Item.Cells[9].Text = monthPay.ToString("0.0");
				}
				catch{}
				try
				{
					monthPay = decimal.Parse(((NrOA.Poundage.em.Poundage)(dopd.Select_pd_by_Value(e.Item.Cells[13].Text))[0]).UseExpenseProportion)* decimal.Parse(e.Item.Cells[19].Text);
					e.Item.Cells[12].Text = monthPay.ToString("0.0");
				}
				catch{}
				try
				{
					if(((NrOA.Poundage.em.Poundage)(dopd.Select_pd_by_Value(e.Item.Cells[10].Text))[0]).ConnectFeesProportion=="2/3")
					{
						CFP = (one*2)/3;
					}
					else
					{
						CFP = decimal.Parse(((NrOA.Poundage.em.Poundage)(dopd.Select_pd_by_Value(e.Item.Cells[10].Text))[0]).ConnectFeesProportion);
					}
					monthPay = CFP* decimal.Parse(e.Item.Cells[20].Text);
					e.Item.Cells[15].Text = monthPay.ToString("0.0");
				}
				catch{}
			}
		}
		private void Button1_Click(object sender, System.EventArgs e)
		{
			find = "1";
			Session["strMonth"] = DropDownList2.SelectedValue;
			Session["endMonth"] = DropDownList5.SelectedValue;
			if(int.Parse(DropDownList2.SelectedValue)>int.Parse(DropDownList5.SelectedValue))
			{
				Response.Write("<script> alert('ѡ��Ŀ�ʼ�·ݲ��ܴ��ڽ����·�!')</script>");
				return;
			}
			if(DropDownList3.SelectedValue=="1")
			{
				Response.Write("<script> alert('��ѡ��С��!')</script>");
				return;
			}
			if(DropDownList4.SelectedValue =="-��ѡ��-")
			{
				Response.Write("<script> alert('��ѡ���ѯ����!')</script>");
				return;
			}
			BindGrid();
		}

		private void Button5_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("BackFundView.aspx?state=new");
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			if(selvalues.Value.ToString() != "" && selvalues.Value.ToString().Length > 1)
			{
				string [] Charge_IDs = selvalues.Value.ToString().Split(',');
				foreach(string Charge_ID in Charge_IDs)
				{
					if(Charge_ID!="")
					{
						CI.Charge_ID= int.Parse(Charge_ID);
						try
						{							
							DCI.delete_Charge_ID(CI.Charge_ID);
						}
						catch{}
					}
				}
				selvalues.Value = ",";
			}
			BindGrid();
		}
	}
}
