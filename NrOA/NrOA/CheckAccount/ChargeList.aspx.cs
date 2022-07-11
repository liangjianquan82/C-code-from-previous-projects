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
	/// ChargeList 的摘要说明。
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
			// 在此处放置用户代码以初始化页面
			btnFirst.Text = "最首页";
			btnPrev.Text = "前一页";
			btnNext.Text = "下一页";
			btnLast.Text = "最后页";

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
			DropDownList3.Items.Insert(0,"所有小区");

			BindGrid();

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

		//初始化程序
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
			
			//检查用户信息
			ht=CheckUserLogin();
			//检查日期正确性
			
			Button3.Attributes.Add("onclick", "javascript: return isdel()");
//			Button4.Attributes.Add("onclick", "javascript: return ispost()");
		}
		//检查用户信息
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
			//加载数据集

			IList list = null;
			DataTable dt = null;

			try
			{
				DropDownList2.SelectedValue = Session.Contents["strMonth"].ToString();
				DropDownList5.SelectedValue = Session.Contents["endMonth"].ToString();
			}
			catch{}

			//-请选择小区-
			if(this.find=="1")
			{
				if(DropDownList4.SelectedValue=="1")
				{
					//未回款用户
					Label6.Text = "未回款用户";
					//list = DCI.Find_List();
				}
				else if(DropDownList4.SelectedValue=="2")
				{
					//年结分成比例出错
					Label6.Text = "年结分成比例出错";
					
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
					//接入费缴费用户
					Label6.Text = "接入费缴费用户";
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
					//迁移费缴费用户
					Label6.Text = "迁移费缴费用户";
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
					//年结列表
					Label6.Text = "年结列表";
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
					//一次性列表
					Label6.Text = "一次性列表";
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
					//回款/月结列表
					Label6.Text = "回款/月结列表";
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
					//月结分成比例错误
					Label6.Text = "月结分成比例错误";
					list = DCI.Find_List(DropDownList1.SelectedValue,DropDownList2.SelectedValue,DropDownList5.SelectedValue,DropDownList3.SelectedValue,8);
				}
				else if(DropDownList4.SelectedValue=="9")
				{
					//一次性分成比例错误
					Label6.Text = "一次性分成比例错误";
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
				//第一次 查询 对应年月 所有的 未回款用户 信息
				Label6.Text = "未回款用户";
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
			lblCurrentIndex.Text = "第 " + (DataGrid1.CurrentPageIndex + 1).ToString() + " 页";
			lblPageCount.Text = "总共 " +count.ToString() + " 条记录 共 " +DataGrid1.PageCount.ToString() + " 页";
		}
		protected void LinkButton_Command(Object sender, CommandEventArgs e) 
		{
			//修改年结
			Response.Redirect("ChargeView.aspx?Charge_ID="+e.CommandArgument.ToString()+"&state=update"+"&Area_id="+DropDownList3.SelectedValue);
		}
		protected void LinkButton_Command1(Object sender, CommandEventArgs e) 
		{
			//修改一次性
			Response.Redirect("ChargeOneVeiw.aspx?Charge_ID="+e.CommandArgument.ToString()+"&state=update"+"&Area_id="+DropDownList3.SelectedValue+"&state1=one");
		}
		protected void LinkButton_Command2(Object sender, CommandEventArgs e) 
		{
			//修改月结
			Response.Redirect("BackFundView.aspx?Charge_ID="+e.CommandArgument.ToString()+"&state=update"+"&Area_id="+DropDownList3.SelectedValue);
		}
		protected void LinkButton_Command3(Object sender, CommandEventArgs e) 
		{
			//修改迁移费
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
				Response.Write("<script> alert('选择的开始月份不能大于结束月份!')</script>");
				return;
			}
			if(DropDownList3.SelectedValue=="1")
			{
				Response.Write("<script> alert('请选择小区!')</script>");
				return;
			}
			if(DropDownList4.SelectedValue =="-请选择-")
			{
				Response.Write("<script> alert('请选择查询条件!')</script>");
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
