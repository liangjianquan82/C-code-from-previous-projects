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
	/// BackFundList 的摘要说明。
	/// </summary>
	public class BackFundList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblPageCount;
		protected System.Web.UI.WebControls.Label lblCurrentIndex;
		protected System.Web.UI.WebControls.LinkButton btnFirst;
		protected System.Web.UI.WebControls.LinkButton btnPrev;
		protected System.Web.UI.WebControls.LinkButton btnNext;
		protected System.Web.UI.WebControls.LinkButton btnLast;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden selvalues;


		NrOA.Client.pkg.DOClient dc = new NrOA.Client.pkg.DOClient();
		NrOA.CheckAccount.pkg.DOChargeInfo dci = new NrOA.CheckAccount.pkg.DOChargeInfo();
		NrOA.Area.pkg.DOArea DoA = new NrOA.Area.pkg.DOArea();
		NrOA.CheckAccount.em.ChargeInfo CI = new NrOA.CheckAccount.em.ChargeInfo();
		protected Hashtable ht = null;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected System.Web.UI.WebControls.Button Button3;
		protected int count =0;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList DropDownList5;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist6;
		protected string PageIndex = "0";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			btnFirst.Text = "最首页";
			btnPrev.Text = "前一页";
			btnNext.Text = "下一页";
			btnLast.Text = "最后页";

			
			Inits();
			
			if(Page.IsPostBack)
				return;

			DropDownList3.DataSource = DoA.SelectAreaAll_LoginIn();
			DropDownList3.DataTextField = "AreaName";
			DropDownList3.DataValueField = "Area_ID";
			DropDownList3.DataBind();
			//Session["Area_ID"] = DropDownList3.SelectedValue.ToString();
			DropDownList3.Items.Insert(0,"所有小区");
			try
			{
				DropDownList5.SelectedValue = Session.Contents["state1"].ToString();
			}
			catch{DropDownList5.SelectedValue = "0";}
			try
			{
				PageIndex = Session.Contents["PageIndex"].ToString();
			}
			catch{PageIndex = "0";}
			try
			{
				Dropdownlist2.SelectedValue = Session.Contents["year"].ToString();
			}
			catch{Dropdownlist2.SelectedValue = DateTime.Now.Year.ToString();}
			try
			{
				Dropdownlist6.SelectedValue = Session.Contents["year"].ToString();
			}
			catch{Dropdownlist6.SelectedValue = DateTime.Now.Year.ToString();}
			try
			{
				DropDownList4.SelectedValue = Session.Contents["month"].ToString();
			}
			catch{DropDownList4.SelectedValue =DateTime.Now.Month.ToString();}
			try
			{
				DropDownList3.SelectedValue = Session.Contents["Area_id"].ToString();
			}
			catch{DropDownList3.SelectedValue = "所有小区";}
			try
			{
				DropDownList1.SelectedValue = Session.Contents["state"].ToString();
			}
			catch{DropDownList1.SelectedValue  = "0";}


			DataGrid1.CurrentPageIndex = int.Parse(PageIndex);

			//Dropdownlist2.SelectedValue = DateTime.Now.Year.ToString();			

			

			//Dropdownlist2.SelectedValue = DateTime.Now.Year.ToString();
			//DropDownList4.SelectedValue = DateTime.Now.Month.ToString();

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
			this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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
			
//			Button3.Attributes.Add("onclick", "javascript: return isdel()");
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
			IList list = null;
			//DataTable dt = null;
			

			if(DropDownList5.SelectedValue!="2")
			{
				list = dci.SelectChargeinfo_list1(Dropdownlist2.SelectedValue,DropDownList4.SelectedValue, DropDownList3.SelectedValue,DropDownList1.SelectedValue,TextBox1.Text.Trim(),Dropdownlist6.SelectedValue);
			}
			else
			{
				list = dci.select_Chargeinfostate(DropDownList5.SelectedValue);
			}
			if(list!=null)
			{
				if(list.Count>0)
				{
					count =  list.Count;
					DataGrid1.DataSource = list;
				}				
			}
			if(CheckBox1.Checked)
			{
				try
				{
					DataGrid1.PageSize = count;
				}
				catch{}
			}
			
			int tmp=count%DataGrid1.PageSize !=0 || count==0 ? (int) (count/DataGrid1.PageSize) + 1 : (int)(count/DataGrid1.PageSize);
			if(tmp<DataGrid1.CurrentPageIndex + 1)
			{
				DataGrid1.CurrentPageIndex = tmp - 1;
			}		
			DataGrid1.DataBind();
			

			Session["list"] = list;
			Session["DataSource"] = DataGrid1.DataSource;
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

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.AlternatingItem) ||
				(e.Item.ItemType == ListItemType.Item))
			{
				#region 注销
				//				try
				//				{
				//					e.Item.Cells[5].Text = DateTime.Parse(e.Item.Cells[5].Text.Trim()).ToString("yyy-MM-dd");
				//				}
				//				catch{}
				//
				//				IList listfcbl = null;
				//				IList listdnj = null;
				//				IList listdyj = null;
				//
				//				IList listdycx = null;
				//				IList listdqyf = null;
				//				string area_id = "";
				//				area_id = e.Item.Cells[21].Text.Trim();
				//				try
				//				{
				//					listfcbl = DoA.SelectArea_By_ID(int.Parse(area_id));
				//					e.Item.Cells[6].Text = ((NrOA.Area.em.Area)(listfcbl)[0]).Poundage;
				//				}
				//				catch{}
				//
				//				for(int i=1;i<13;i++)
				//				{
				//					string OneOffConnectFees = "0";//一次性收费
				//					string PaymentMonth = "0";//按月交费
				//					string FirstPayment = "0";//年结款
				//					string MovePay = "0";//迁移费
				//					string Now_Poundage = "0";
				//
				//					listdnj = dci.selectpay_info(e.Item.Cells[2].Text,Dropdownlist2.SelectedValue,i.ToString(),"年结");
				//					listdyj = dci.selectpay_info(e.Item.Cells[2].Text,Dropdownlist2.SelectedValue,i.ToString(),"月结");
				//					listdycx = dci.selectpay_info(e.Item.Cells[2].Text,Dropdownlist2.SelectedValue,i.ToString(),"一次性");
				//					listdqyf = dci.selectpay_info(e.Item.Cells[2].Text,Dropdownlist2.SelectedValue,i.ToString(),"迁移费");
				//					if(listdnj!=null)
				//					{
				//						if(listdnj.Count>0)
				//						{
				//							FirstPayment = ((NrOA.CheckAccount.em.ChargeInfo)(listdnj)[0]).FirstPayment;
				//							Now_Poundage = ((NrOA.CheckAccount.em.ChargeInfo)(listdnj)[0]).Now_Poundage;
				//						}
				//						else
				//						{
				//							FirstPayment = "0";
				//						}
				//					}
				//					
				//					if(listdyj!=null)
				//					{
				//						if(listdyj.Count>0)
				//						{							
				//							PaymentMonth = ((NrOA.CheckAccount.em.ChargeInfo)(listdyj)[0]).PaymentMonth;
				//							Now_Poundage = ((NrOA.CheckAccount.em.ChargeInfo)(listdyj)[0]).Now_Poundage;
				//						}
				//						else
				//						{
				//							PaymentMonth = "0";
				//						}
				//					}
				//
				//					if(FirstPayment!="0"&&PaymentMonth!="0")
				//					{
				//						e.Item.Cells[i+8].Text = FirstPayment+"-"+PaymentMonth;
				//						e.Item.Cells[i+8].ForeColor = System.Drawing.Color.Red;
				//					}
				//					else if(FirstPayment!="0"&&PaymentMonth=="0")
				//					{
				//						e.Item.Cells[i+8].Text = FirstPayment;
				//						if(Now_Poundage != e.Item.Cells[6].Text)
				//						{
				//							e.Item.Cells[i+8].ForeColor = System.Drawing.Color.Red;
				//						}
				//						else
				//						{
				//							e.Item.Cells[i+8].ForeColor = System.Drawing.Color.Black;
				//						}
				//					}
				//					else if(FirstPayment=="0"&&PaymentMonth!="0")
				//					{
				//						e.Item.Cells[i+8].Text = PaymentMonth;
				//						if(Now_Poundage != e.Item.Cells[6].Text)
				//						{
				//							e.Item.Cells[i+8].ForeColor = System.Drawing.Color.Red;
				//						}
				//						else
				//						{
				//							e.Item.Cells[i+8].ForeColor = System.Drawing.Color.Black;
				//						}
				//					}
				//					else if(FirstPayment=="0"&&PaymentMonth=="0")
				//					{
				//						e.Item.Cells[i+8].Text = "0";
				//					}
				//					
				//					if(listdycx!=null)
				//					{
				//						if(listdycx.Count>0)
				//						{
				//							OneOffConnectFees = ((NrOA.CheckAccount.em.ChargeInfo)(listdycx)[0]).OneOffConnectFees;
				//							Now_Poundage = ((NrOA.CheckAccount.em.ChargeInfo)(listdycx)[0]).Now_Poundage;
				//						}
				//						else
				//						{
				//							OneOffConnectFees = "0";
				//						}
				//					}
				//					if(OneOffConnectFees!="0")
				//					{
				//						e.Item.Cells[7].Text = OneOffConnectFees;
				//						if(Now_Poundage != e.Item.Cells[6].Text)
				//						{
				//							e.Item.Cells[7].ForeColor = System.Drawing.Color.Red;
				//						}
				//						else
				//						{
				//							e.Item.Cells[i+8].ForeColor = System.Drawing.Color.Black;
				//						}
				//					}
				//					if(listdycx!=null)
				//					{
				//						if(listdycx.Count>0)
				//						{
				//							MovePay = ((NrOA.CheckAccount.em.ChargeInfo)(listdycx)[0]).MovePay;
				//							Now_Poundage = ((NrOA.CheckAccount.em.ChargeInfo)(listdycx)[0]).Now_Poundage;
				//						}
				//						else
				//						{
				//							MovePay = "0";
				//						}
				//					}
				//					if(MovePay!="0")
				//					{
				//						e.Item.Cells[8].Text = MovePay;
				//						if(Now_Poundage != e.Item.Cells[6].Text)
				//						{
				//							e.Item.Cells[8].ForeColor = System.Drawing.Color.Red;
				//						}
				//						else
				//						{
				//							e.Item.Cells[i+8].ForeColor = System.Drawing.Color.Black;
				//						}
				//					}
				//
				//				}
				#endregion
				if(e.Item.Cells[9].Text.Trim()!="0"&&e.Item.Cells[8].Text.Trim()!=e.Item.Cells[25].Text.Trim())
				{
					e.Item.Cells[9].ForeColor = System.Drawing.Color.Red;
				}
				if(e.Item.Cells[10].Text.Trim()!="0"&&e.Item.Cells[8].Text.Trim()!=e.Item.Cells[25].Text.Trim())
				{
					e.Item.Cells[10].ForeColor = System.Drawing.Color.Red;
				}
				for(int i=1;i<13;i++)
				{
					if(e.Item.Cells[10+i].Text.Trim()!="0"&&e.Item.Cells[8].Text.Trim()!=e.Item.Cells[25+i].Text.Trim())
					{
						e.Item.Cells[10+i].ForeColor = System.Drawing.Color.Red;
					}
				}
				if(e.Item.Cells[24].Text.Trim()=="2")
				{
					e.Item.Cells[24].ForeColor = System.Drawing.Color.Red;

					e.Item.Cells[24].Text = "异常";
				}

				for(int i=10;i<22;i++)
				{
					if(e.Item.Cells[i].Text.Length>7)
					{
						e.Item.Cells[i].Text = e.Item.Cells[i].Text.Substring(0,7);
					}
				}		
				try
				{
					string s = e.Item.Cells[7].Text;
					e.Item.Cells[7].Text = DateTime.Parse(e.Item.Cells[7].Text).ToString("yyyy-MM-dd");
				}
				catch{}

			}
		}
		protected void LinkButton_Command(Object sender, CommandEventArgs e) 
		{
			Session["state1"] = DropDownList5.SelectedValue;
			Session["PageIndex"] = DataGrid1.CurrentPageIndex;
			Session["year"] =Dropdownlist2.SelectedValue;
			Session["month"] =DropDownList4.SelectedValue;
			Session["Area_id"] =DropDownList3.SelectedValue;
			Session["state"] =DropDownList1.SelectedValue;
			Response.Redirect("reworkChargeCollect.aspx?id="+e.CommandArgument.ToString());
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			BindGrid();
		}
		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropDownList1.SelectedValue=="2")
			{
				DropDownList4.SelectedValue = "0";
				DropDownList4.Visible = false;
				Dropdownlist6.Visible = false;
			}
			else if(DropDownList1.SelectedValue=="3")
			{
				Dropdownlist6.Visible = true;
			}
			else
			{
				DropDownList4.Visible = true;
				Dropdownlist6.Visible = false;
			}
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			//将汇款数据整理更新。
			NrOA.CheckAccount.pkg.DOBackFundInfo dobfi = new NrOA.CheckAccount.pkg.DOBackFundInfo();
			dobfi.Putint_T_ChargeCollect(Dropdownlist2.SelectedValue);
			Response.Write("<script> alert('数据整理完成!')</script>");	

		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Excelout.aspx");
		}
	}
}
