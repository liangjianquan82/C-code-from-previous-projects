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
	/// newlist 的摘要说明。
	/// </summary>
	public class newlist : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist3;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList DropDownList5;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.CheckBox CheckBox2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblPageCount;
		protected System.Web.UI.WebControls.Label lblCurrentIndex;
		protected System.Web.UI.WebControls.LinkButton btnFirst;
		protected System.Web.UI.WebControls.LinkButton btnPrev;
		protected System.Web.UI.WebControls.LinkButton btnNext;
		protected System.Web.UI.WebControls.LinkButton btnLast;
		protected System.Web.UI.HtmlControls.HtmlInputHidden selvalues;


		protected Hashtable ht = null;
		protected System.Web.UI.WebControls.Button Button4;
		protected int count;

		protected NrOA.Client.em.Client CL = new NrOA.Client.em.Client();
		protected NrOA.Client.pkg.DOClient DOCL = new NrOA.Client.pkg.DOClient();
		private string find = "";
		private string UserName = "";
		private string AreaName = "";
		NrOA.Area.pkg.DOArea doa = new NrOA.Area.pkg.DOArea();
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		NrOA.Area.em.Area area = new NrOA.Area.em.Area();

		NrOA.CheckAccount.pkg.dao_t_huikuan dth = new NrOA.CheckAccount.pkg.dao_t_huikuan();
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected System.Web.UI.WebControls.Label TaskID;
		protected System.Web.UI.WebControls.LinkButton LB;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox CheckAll;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox CheckID;
		NrOA.CheckAccount.pkg.dao_t_yicixing dty = new NrOA.CheckAccount.pkg.dao_t_yicixing();
		NrOA.CheckAccount.pkg.dao_pay_info dpi = new NrOA.CheckAccount.pkg.dao_pay_info();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			btnFirst.Text = "最首页";
			btnPrev.Text = "前一页";
			btnNext.Text = "下一页";
			btnLast.Text = "最后页";

			try
			{
				AreaName = Request["AreaName"].ToString();
			}
			catch{}					

			try
			{
				DropDownList4.SelectedValue = Session.Contents["year"].ToString();
			}
			catch{}
			
			//CheckBox2.Checked = true;
			Inits();
			
//			if(Page.IsPostBack)
//				return;

			try
			{
				UserName = ht["EmployeeName"].ToString();
			}
			catch{}
			if(Page.IsPostBack)
			{
				try
				{
					find = Session.Contents["find"].ToString();
				}
				catch{}		
				return;
			}

			
			Session["find"] = 0;

			IList list = null;
			try
			{
				list = doa.SelectArea_By_ID(int.Parse(AreaName));				
			}
			catch{}
			if(list!=null)
			{
				if(list.Count>0)
					Label3.Text = ((NrOA.Area.em.Area)(list)[0]).AreaName+"客户各年收费列表";
			}

			try
			{
				if (Request["page"]!=null)
					DataGrid1.CurrentPageIndex = int.Parse(Request["page"].ToString());
			}
			catch
			{
				DataGrid1.CurrentPageIndex = 0;
			}

			NrOA.Area.em.Area AR = new NrOA.Area.em.Area();
			NrOA.Area.pkg.DOArea DoAr = new NrOA.Area.pkg.DOArea();

		
			// 默认获取套餐列表
			BindGrid();

			//部分权限
			if(UserName=="user")
			{
				
			}
//			Button4.Visible = false;
			DropDownList4.SelectedValue = DateTime.Now.Year.ToString();
			Dropdownlist3.SelectedValue = DateTime.Now.Month.ToString();
			DropDownList5.SelectedValue = DateTime.Now.Month.ToString();
			//Session["year"] = DropDownList4.SelectedValue;
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.CheckBox2.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
			this.CheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
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
//			Button1.Attributes.Add("onclick", "javascript: return checksave()");
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
			//加载数据集
//			IList list = null;
//			if(this.find!="1")
//			{
//				list = DOCL.SelectClient_byAreaName(AreaName);
//				//RadioButton1.Checked = true; 
//				
//			}
//			else
//			{
//				if(TextBox1.Text.Trim()=="")
//				{
//
//					list = DOCL.SelectClient_byAreaName(AreaName,DropDownList2.SelectedValue,DropDownList4.SelectedValue,Dropdownlist3.SelectedValue,DropDownList5.SelectedValue);
//
//				}
//				else
//				{
//
//					list = DOCL.SelectClientByFind(TextBox1.Text.Trim(),DropDownList2.SelectedValue,AreaName);
//				}
//			}
			DataTable dt = new DataTable();

			#region 构造显示的表单

			dt = build_list();

			#endregion

			DataView dv = new DataView();
			dv = dt.DefaultView;
			dv.Sort = " ClientListID asc";
			
		    DataGrid1.DataSource = dv;
			
			try
			{
				count =  dt.Rows.Count;
			}
			catch
			{
			}

			if(CheckBox2.Checked)
			{
				try
				{
					DataGrid1.PageSize = count;
				}
				catch{}
			}
			else
			{

			}


			this.DataGrid1.DataKeyField = "Client_ID";
			int tmp=count%DataGrid1.PageSize !=0 || count==0 ? (int) (count/DataGrid1.PageSize) + 1 : (int)(count/DataGrid1.PageSize);
			if(tmp<DataGrid1.CurrentPageIndex + 1)
			{
				DataGrid1.CurrentPageIndex = tmp - 1;
				
			}

			DataGrid1.DataBind();
			Session["PageIndex"] = DataGrid1.CurrentPageIndex;			
		}

		private DataTable build_list()
		{
			DataTable dt = new DataTable();
			DataColumn Client_ID = new DataColumn("Client_ID",typeof(System.Int32));
			DataColumn ClientListID = new DataColumn("ClientListID",typeof(System.Int32));
			DataColumn ClientName = new DataColumn("ClientName",typeof(System.String));
			DataColumn ClientOperationID = new DataColumn("ClientOperationID",typeof(System.String));
			DataColumn fc = new DataColumn("fc",typeof(System.String));
			DataColumn jr = new DataColumn("jr",typeof(System.String));
			DataColumn yr1 = new DataColumn("yr",typeof(System.String));
			DataColumn RunDate = new DataColumn("RunDate",typeof(System.String));
			DataColumn type = new DataColumn("type",typeof(System.String));
			DataColumn bz = new DataColumn("bz",typeof(System.String));
			DataColumn month1 = new DataColumn("month1",typeof(System.String));
			DataColumn month2 = new DataColumn("month2",typeof(System.String));
			DataColumn month3 = new DataColumn("month3",typeof(System.String));
			DataColumn month4 = new DataColumn("month4",typeof(System.String));
			DataColumn month5 = new DataColumn("month5",typeof(System.String));
			DataColumn month6 = new DataColumn("month6",typeof(System.String));
			DataColumn month7 = new DataColumn("month7",typeof(System.String));
			DataColumn month8 = new DataColumn("month8",typeof(System.String));
			DataColumn month9 = new DataColumn("month9",typeof(System.String));
			DataColumn month10 = new DataColumn("month10",typeof(System.String));
			DataColumn month11 = new DataColumn("month11",typeof(System.String));
			DataColumn month12 = new DataColumn("month12",typeof(System.String));
			DataColumn ProductType = new DataColumn("ProductType",typeof(System.String));



			dt.Columns.Add(Client_ID);
			dt.Columns.Add(ClientListID);
			dt.Columns.Add(ClientName);
			dt.Columns.Add(ClientOperationID);
			dt.Columns.Add(fc);
			dt.Columns.Add(jr);
			dt.Columns.Add(month1);
			dt.Columns.Add(month2);
			dt.Columns.Add(month3);
			dt.Columns.Add(month4);
			dt.Columns.Add(month5);
			dt.Columns.Add(month6);
			dt.Columns.Add(month7);
			dt.Columns.Add(month8);
			dt.Columns.Add(month9);
			dt.Columns.Add(month10);
			dt.Columns.Add(month11);
			dt.Columns.Add(month12);
			dt.Columns.Add(yr1);
			dt.Columns.Add(RunDate);
			dt.Columns.Add(type);
			dt.Columns.Add(bz);
			dt.Columns.Add(ProductType);


			IList min_yr = null;
			min_yr = dth.min_year();

			
			string yr = "2008";
			if(this.find!="1")
			{
				try
				{
					yr =((NrOA.CheckAccount.em.t_huikuan)(min_yr)[0]).t_year.Trim();
				}
				catch{}
			
			}
			else
			{
				yr = DropDownList4.SelectedValue;
			}
			//			int count_sum = 0;
			//			count_sum = DateTime.Now.Year - int.Parse(yr);
			#region 注销该部分
//			if(list!=null)
//			{
//				if(list.Count>0)
//				{
//					for(int i=0;i<list.Count;i++)
//					{						
//						string araename = ((NrOA.Client.em.Client)(list)[i]).AreaName;
//						string fc = "0.5";
//						try
//						{
//							fc = ((NrOA.Area.em.Area)(doa.SelectArea_By_ID(int.Parse(araename)))[0]).Poundage;
//						}
//						catch{}
//						for(int n=int.Parse(yr);n<=DateTime.Now.Year;n++)
//						{
//							DataRow dr=dt.NewRow();
//							dr["Client_ID"] = ((NrOA.Client.em.Client)(list)[i]).Client_ID;
//							dr["ClientListID"] = ((NrOA.Client.em.Client)(list)[i]).ClientListID;
//							dr["ClientOperationID"] = ((NrOA.Client.em.Client)(list)[i]).ClientOperationID;
//							dr["ClientName"] = ((NrOA.Client.em.Client)(list)[i]).ClientName;
//							dr["RunDate"] = ((NrOA.Client.em.Client)(list)[i]).RunDate;
//							dr["yr"] = n;
//							dr["fc"] = fc;
//							NrOA.CheckAccount.em.t_yicixing ty = new NrOA.CheckAccount.em.t_yicixing();
//							ty.t_year = n.ToString();
//							ty.usernb = ((NrOA.Client.em.Client)(list)[i]).ClientOperationID;
//
//							IList ycxlist = null;
//							string jr = "";
//							try
//							{
//								string jrf = "0";
//								ycxlist = dty.ycx_by_year_id(ty);
//								for(int s=0;s<ycxlist.Count;s++)
//								{
//									jrf = ((NrOA.CheckAccount.em.t_yicixing)(ycxlist)[s]).t_onepay;
//									if(s!=0)
//									{
//										jr = jr+"+"+jrf;
//									}
//									else
//									{
//										jr =jrf;
//									}
//								}
//							}
//							catch{jr ="0";}
//							dr["jr"] = jr;
//
//							NrOA.CheckAccount.em.t_huikuan hk = new NrOA.CheckAccount.em.t_huikuan();
//							hk.t_year = n.ToString();
//							hk.usernb = ((NrOA.Client.em.Client)(list)[i]).ClientOperationID;
//							IList hklist = null;
//
//							for(int m=1;m<=12;m++)
//							{
//								hk.t_month = m.ToString();
//								hklist = dth.hu_by_year_id(hk);
//								if(hklist!=null)
//								{
//									if(hklist.Count>0)
//									{
//										for(int s=0;s<hklist.Count;s++)
//										{
//											string t_m = "";
//											string t_s = "";
//											try
//											{
//												t_m = ((NrOA.CheckAccount.em.t_huikuan)(hklist)[s]).month_pay;
//											}
//											catch{t_m = "0";}
//											if(s!=0)
//											{
//												t_s = t_s +"+"+ t_m;
//											}
//											else
//											{
//												t_s = t_m;
//											}
//											dr["month"+m] = t_s;
//										}
//											
//									}
//								}
//							}
//							
//							dt.Rows.Add(dr);
//						}
//					}
//				}
//			}
			#endregion

			for(int i=int.Parse(yr);i<=DateTime.Now.Year;i++)
			{
				IList list = null;
				NrOA.CheckAccount.em.pay_info pi = new NrOA.CheckAccount.em.pay_info();
				pi.yr = i.ToString().Trim();
				pi.AreaName = AreaName;
				pi.start_mon = Dropdownlist3.SelectedValue.Trim();
				pi.end_Month = DropDownList5.SelectedValue.Trim();
				if(this.find!="1")
				{
					list = dpi.Selectpay_info_byAreaName(pi);
				}
				else
				{
					if(TextBox1.Text.Trim()=="")
					{
						pi.yr = DropDownList4.SelectedValue.Trim();
						list = dpi.Selectpay_info_byAreaName1(pi);

					}
					else
					{

						list = DOCL.SelectClientByFind(TextBox1.Text.Trim(),DropDownList2.SelectedValue,AreaName);
					}
				}

				if(list != null)
				{
					if(list.Count>0)
					{
						for(int n=0;n<list.Count;n++)
						{
							DataRow dr=dt.NewRow();
							dr["Client_ID"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).Client_ID;
							try
							{
								dr["ClientListID"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).ClientListID;
							}
							catch{dr["ClientListID"] = 0;}
							dr["ClientOperationID"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).ClientOperationID;
							dr["ClientName"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).ClientName;
							dr["RunDate"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).RunDate;
							dr["month1"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).month1;
							dr["month2"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).month2;
							dr["month3"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).month3;
							dr["month4"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).month4;
							dr["month5"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).month5;
							dr["month6"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).month6;
							dr["month7"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).month7;
							dr["month8"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).month8;
							dr["month9"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).month9;
							dr["month10"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).month10;
							dr["month11"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).month11;
							dr["month12"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).month12;
							dr["bz"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).bz;
							dr["jr"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).jr;
							dr["yr"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).yr;
							dr["ProductType"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).ProductType;
							//dr["yr"] = yr;

							try
							{
								dr["type"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).type;
							}
							catch
							{dr["type"] = "";}
							dr["fc"] = ((NrOA.CheckAccount.em.pay_info)(list)[n]).fc;

							dt.Rows.Add(dr);
						}
					}
				}
				
			}
			return dt;
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
		private void Button1_Click(object sender, System.EventArgs e)
		{
			DataGrid1.CurrentPageIndex = 0;
			this.find = "1";
			Session["find"] = 1;			
			BindGrid();
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.AlternatingItem) ||
				(e.Item.ItemType == ListItemType.Item))
			{
				//string s = e.Item.Cells[19].Text;

				try
				{
					e.Item.Cells[5].Text = DateTime.Parse(e.Item.Cells[5].Text.Trim()).ToString("yyyy-MM-dd");
					if(DateTime.Parse(e.Item.Cells[5].Text.Trim()).Year<=int.Parse(e.Item.Cells[6].Text.Trim()))
					{
						e.Item.Visible = true;
					}
					else
					{
						e.Item.Visible = false;
					}
				}
				catch{}
				try
				{
					e.Item.Cells[5].Text = e.Item.Cells[5].Text.Substring(0,10);
				}
				catch{}
				try
				{
					e.Item.Cells[2].Text = int.Parse(e.Item.Cells[2].Text).ToString("#");
				}
				catch{}
				string ss = e.Item.Cells[22].Text.Trim();
				if(e.Item.Cells[22].Text.Trim()=="1")
				{
					e.Item.BackColor = Color.Red;
					e.Item.Cells[22].Text = "异常";
				}
				else
				{
					e.Item.Cells[22].Text = "正常";
				}
			}
		}

		private void CheckBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			BindGrid();
		}

		protected void LinkButton_Command(Object sender, CommandEventArgs e) 
		{
			//打开备注页面
			Session["AreaName"] = AreaName;
			Session["year"] = DropDownList4.SelectedValue;
			Session["str"] = TextBox1.Text.Trim();
			Session["st"] = Dropdownlist3.SelectedValue;
			Session["et"] = DropDownList5.SelectedValue;

			Response.Redirect("t_year_bz_view.aspx?ClientOperationID="+e.CommandArgument.ToString()+"&yr="+DropDownList4.SelectedValue);
		}

		private void CheckBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			BindGrid();
		}





	}
}
