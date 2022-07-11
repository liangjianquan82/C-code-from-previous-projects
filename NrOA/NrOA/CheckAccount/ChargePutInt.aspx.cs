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
using NrOA.CheckAccount.em;
using Microsoft.Web.UI.WebControls;

using System.Data.OleDb;

namespace NrOA.CheckAccount
{
	/// <summary>
	/// ChargePutInt 的摘要说明。
	/// </summary>
	public class ChargePutInt : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblPageCount;
		protected System.Web.UI.WebControls.Label lblCurrentIndex;
		protected System.Web.UI.WebControls.LinkButton btnFirst;
		protected System.Web.UI.WebControls.LinkButton btnPrev;
		protected System.Web.UI.WebControls.LinkButton btnNext;
		protected System.Web.UI.WebControls.LinkButton btnLast;
		protected System.Web.UI.HtmlControls.HtmlInputHidden deptid;

		protected Hashtable ht = null;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.Button Button1;
		protected int count=0;
		protected System.Web.UI.WebControls.Button UploadButton;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.Button Button4;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Button Button5;

		private int find = 0;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			btnFirst.Text = "最首页";
			btnPrev.Text = "前一页";
			btnNext.Text = "下一页";
			btnLast.Text = "最后页";
			Inits();
//			ht = (Hashtable)Session["userinfo"];
//		
//			if(ht == null)
//			{
//				Response.Redirect("../login.aspx");
//				return;
//			}


//			try
//			{
//				DropDownList3.SelectedValue = Session.Contents["year"].ToString();
//			}
//			catch{}
//
//			try
//			{
//				DropDownList2.SelectedValue = Session.Contents["month"].ToString();
//			}
//			catch{}


			if(DropDownList3.SelectedValue=="-选择年份-"||DropDownList2.SelectedValue=="-选择月份-")
			{
				UploadButton.Attributes.Add("onclick","javascript: return ischeck()");
			}
			else
			{
				UploadButton.Attributes.Add("onclick", "javascript: return confirm('导入数据将不进行检查,确定导入吗？')");
			}

//			UploadButton.Attributes.Add("onclick", "javascript: return addFile()");
			
			if (this.IsPostBack) 
			{
				return;
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
			this.DropDownList3.SelectedIndexChanged += new System.EventHandler(this.DropDownList3_SelectedIndexChanged);
			this.DropDownList2.SelectedIndexChanged += new System.EventHandler(this.DropDownList2_SelectedIndexChanged);
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button5.Click += new System.EventHandler(this.Button5_Click);
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
			//DataGrid1.DataSource = dopt.SelectAllProductType();
			this.DataGrid1.DataKeyField = "Product_ID";

			//count =  dopt.SelectAllProductType().Count;

			
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

		private bool SaveFile()
		{
			///'遍历File表单元素
			HttpFileCollection files  = HttpContext.Current.Request.Files;

			///'状态信息
			System.Text.StringBuilder strMsg = new System.Text.StringBuilder();
			strMsg.Append("上传的文件分别是：<hr color=red>");
			try
			{
				for(int iFile = 0; iFile < files.Count; iFile++)
				{
					///'检查文件扩展名字 
					HttpPostedFile postedFile = files[iFile];
					string fileName, fileExtension;
					fileName = System.IO.Path.GetFileName(postedFile.FileName);
					if (fileName != "")
					{
						fileExtension = System.IO.Path.GetExtension(fileName);
						if((postedFile.ContentType.ToString() == "application/vnd.ms-excel" || postedFile.ContentType.ToString() == "application/octet-stream")&& fileExtension == ".xls")
						{
							
							///注意：可能要修改你的文件夹的匿名写入权限。
//							postedFile.SaveAs(System.Web.HttpContext.Current.Request.MapPath("employeelist/") + fileName);
							postedFile.SaveAs(System.Web.HttpContext.Current.Request.MapPath("/") + fileName);

							// 读取格式,写入数据库
//							DoWithFile(System.Web.HttpContext.Current.Request.MapPath("employeelist/") + fileName);
							DoWithFile(System.Web.HttpContext.Current.Request.MapPath("/") + fileName);
						}
					}
				}
				//Label1.Text = strMsg.ToString();
				return true;
			}
			catch(System.Exception Ex)
			{
				Label1.Text = Ex.Message;
				return false;
			}
		}
		private void DoWithFile(string path)
		{
//			ImportData(ReadExcel(path, "Sheet1"));
//			ImportData(ReadExcel(path, "北湖小区"));
			try
			{
				ImportData(ReadExcel(path, "回款"),"回款");
			}
			catch(System.Exception Ex){Label1.Text = Ex.Message;}
			try
			{
				ImportData(ReadExcel(path, "一次性"),"一次性");
			}
			catch(System.Exception Ex){Label1.Text = Ex.Message;}

			try
			{
				ImportData(ReadExcel(path, "按年结"),"按年结");
			}
			catch(System.Exception Ex){Label1.Text = Ex.Message;}
		}
		public DataSet ReadExcel1(string path,string sheet)
		{
			string mystring = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = '"+path+"';Extended Properties=Excel 8.0";
			OleDbConnection cnnxls = new OleDbConnection(mystring);
			OleDbDataAdapter myDa = new OleDbDataAdapter("SELECT * FROM ["+sheet+"$]", cnnxls);
			DataSet myDs = new DataSet();
			myDa.Fill(myDs);
			return myDs;
		}
		public DataSet ReadExcel(string path,string sheet)
		{
			string mystring = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = "+Server.MapPath("../报表.xls")+";Extended Properties=Excel 8.0";
			OleDbConnection cnnxls = new OleDbConnection(mystring);
			OleDbDataAdapter myDa = new OleDbDataAdapter("SELECT * FROM ["+sheet+"$]", cnnxls);
			DataSet myDs = new DataSet();
			myDa.Fill(myDs);
			return myDs;
		}
		/// <summary>
		/// 根据不同Excel标签 存储导入的数据
		/// </summary>
		/// <param name="ds">Excel数据</param>
		/// <param name="state">标签 回款、一次性、按年结</param>
		/// <returns></returns>
		public int ImportData(DataSet ds,string state)
		{
			NrOA.CheckAccount.em.ChargeInfo CI = new ChargeInfo();
			NrOA.CheckAccount.em.BackFundInfo bfi = new BackFundInfo();
			NrOA.CheckAccount.pkg.DOChargeInfo doci = new NrOA.CheckAccount.pkg.DOChargeInfo();
			NrOA.CheckAccount.pkg.DOBackFundInfo dobfi = new NrOA.CheckAccount.pkg.DOBackFundInfo();
			int i = 0;
			DataTable dt=ds.Tables[0];	
			if(state=="一次性")
			{
				for (int j = 0; j < dt.Rows.Count; j++)
				{
					if(dt.Rows[j][1].ToString() == "")  
						continue;
					

					CI.ClientName = dt.Rows[j][1].ToString();//客户姓名

					CI.ClientOperationID = dt.Rows[j][2].ToString();//客户业务号

					CI.Now_Poundage = now_Poundage(dt.Rows[j][3].ToString());//分成比例

					if(Move_or_Connect(dt.Rows[j][7].ToString())=="接入费")
					{
						CI.OneOffConnectFees = dt.Rows[j][6].ToString();//接入费
						CI.MovePay = "0";
					}
					else if(Move_or_Connect(dt.Rows[j][7].ToString())=="迁移费")
					{
						CI.MovePay = dt.Rows[j][6].ToString();//接入费
						CI.OneOffConnectFees = "0";
					}					

					CI.Payment_by_Year = DropDownList3.SelectedValue.ToString();

					CI.Payment_by_Month = DropDownList2.SelectedValue.ToString();

					CI.RegisterMane = ht["EmployeeName"].ToString();

					doci.AddOneOffConnectFeesList(CI);

					i++;   
				}
			}
			else if(state=="按年结")
			{
				for (int j = 0; j < dt.Rows.Count; j++)
				{
					if(dt.Rows[j][1].ToString() == "")  
						continue;
					
					
					CI.ClientName = dt.Rows[j][1].ToString();//客户名称

					CI.ClientOperationID = dt.Rows[j][2].ToString();//业务号码

					CI.Now_Poundage = now_Poundage(dt.Rows[j][3].ToString());//分成比例

					CI.FirstPayment = dt.Rows[j][6].ToString();//年结费用	
				
					CI.PaymentYear = dt.Rows[j][6].ToString();//年结费用

					CI.Payment_by_Year = DropDownList3.SelectedValue.ToString();//对应缴费年

					CI.Payment_by_Month = DropDownList2.SelectedValue.ToString();//对应缴费月

					CI.RegisterMane = ht["EmployeeName"].ToString();//当前用户

					//套餐费用 判断是 缴费一年 还是缴费两年
					
					if(CI.FirstPayment=="480"||CI.FirstPayment=="540"||CI.FirstPayment=="600"||CI.FirstPayment=="540"||CI.FirstPayment=="1080")
					{
						int year = int.Parse(CI.Payment_by_Year)+1;
						CI.UseCyc = year.ToString()+"-"+CI.Payment_by_Month;
					}
					else
					{
					}
					//比对 用户信息的有效时间 然后对应的 输入 使用有效期

					//判断 如果是第一次 缴年费 就以客户信息中 使用有效期为本次的 有效期

					//否则 根据回款 年结信息 中的 使用有效期来 确定 使用有效期的时间

					doci.FirstPaymentList(CI);

					i++;   
				}
			}
			else if(state=="回款")
			{
				for (int j = 0; j < dt.Rows.Count; j++)
				{
					if(dt.Rows[j][1].ToString() == "")  
						continue;	
					
					bfi.ClientName = dt.Rows[j][1].ToString();//客户名称

					bfi.ClientOperationID = dt.Rows[j][2].ToString();//客户业务号

					bfi.Now_Poundage = now_Poundage(dt.Rows[j][3].ToString());	//分成比例							

					bfi.BackFund = dt.Rows[j][6].ToString();//回款

					bfi.BackFund_Year = DropDownList3.SelectedValue.ToString();//回款年份

					bfi.BackFund_Month = DropDownList2.SelectedValue.ToString();//回款月份

					bfi.RegisterMane = ht["EmployeeName"].ToString();

					//记录回款信息
					dobfi.BackFundInfoList(bfi);

					//插入收费信息
					CI.ClientName = dt.Rows[j][1].ToString();//客户名称

					CI.ClientOperationID = dt.Rows[j][2].ToString();//业务号码

					CI.Now_Poundage = now_Poundage(dt.Rows[j][3].ToString());//分成比例
				
					CI.PaymentMonth = dt.Rows[j][6].ToString();//月结费用

					CI.Payment_by_Year = DropDownList3.SelectedValue.ToString();//对应缴费年

					CI.Payment_by_Month = DropDownList2.SelectedValue.ToString();//对应缴费月

					CI.RegisterMane = ht["EmployeeName"].ToString();//当前用户

					int month = int.Parse(CI.Payment_by_Month)+1;

					CI.UseCyc = CI.Payment_by_Year +"-"+month.ToString();

					doci.BackMonthPay(CI);

					i++;   
				}
			}

			
			Response.Write("<script> alert('导入"+i.ToString()+"条记录完成!')</script>");

			find = 1;
			this.BindGrid();
			return i; 
		}

		private void DropDownList3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session["year"]=DropDownList3.SelectedValue;
		}
		private void DropDownList2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session["month"] = DropDownList2.SelectedValue;
		}

		/// <summary>
		/// 解析字符串 返回 分成比例
		/// </summary>
		/// <param name="Now_Poundage">分成比例字符串</param>
		/// <returns>返回 分成比例</returns>
		private string now_Poundage(string Now_Poundage)
		{
			if(Now_Poundage.IndexOf("0.45")>-1 )
			{
				return "0.45";
			}
			else
			{
				return "0.5";
			}			
		}
		private string  Move_or_Connect(string Move_or_Connect)
		{
			if(Move_or_Connect.IndexOf("接入费")>-1)
			{
				return "接入费";
			}
			else if(Move_or_Connect.IndexOf("工料费")>-1)
			{
				return "迁移费";
			}
			else
			{
				return "";
			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			find = 1;
			this.BindGrid();
		}

		private void UploadButton_Click(object sender, System.EventArgs e)
		{
			// 导入用户信息
			this.SaveFile();
			// 整合用户信息存入T_ChargeCollect表
			//this.putint_T_ChargeCollect();
			
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			//删除对应年月的汇款信息
			NrOA.CheckAccount.pkg.DOChargeInfo doci = new NrOA.CheckAccount.pkg.DOChargeInfo();
			doci.delete_Chargeinfo_by_YearAndMonth(DropDownList3.SelectedValue,DropDownList2.SelectedValue);
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			DoWithFile("TextBox1.Text");
		}

		private void Button4_Click(object sender, System.EventArgs e)
		{
//			TextBox1.Text = path.Value;
		}
		/// <summary>
		/// 整理更新回款数据
		/// </summary>
		private void putint_T_ChargeCollect()
		{
			//查询全部的用户及对应年份数据
//			NrOA.CheckAccount.pkg.DOBackFundInfo dobfi = new NrOA.CheckAccount.pkg.DOBackFundInfo();
//			dobfi.Putint_T_ChargeCollect(DropDownList3.SelectedValue);
			#region
//			NrOA.Client.pkg.DOClient dc = new NrOA.Client.pkg.DOClient();
//			NrOA.CheckAccount.pkg.DOBackFundInfo dobfi = new NrOA.CheckAccount.pkg.DOBackFundInfo();
//			IList Cllist = null;
//			IList ClientintChargellist = null;
//			Cllist = dc.SelectAllClient();
//			if(Cllist!=null)
//			{
//				for(int i=0;i<Cllist.Count;i++)
//				{
//					string cid = "";
//					try
//					{
//						cid = ((NrOA.Client.em.Client)(Cllist)[i]).ClientOperationID;
//					}
//					catch{cid = "";}
//					//根据用户号，年份查询是否已经存在
//					if(cid!="")
//					{
//						ClientintChargellist = dobfi.ClientintCharge(DropDownList3.SelectedValue,cid);
//					}
//					else
//					{
//						ClientintChargellist = null;
//					}
//					if(ClientintChargellist!=null)
//					{
//						NrOA.CheckAccount.em.ChargeCollect cc = new ChargeCollect();
//						if(ClientintChargellist.Count>0)//存在则更新对应月的数据。
//						{
//							cc.id = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).id;
//							cc.ClientOperationID = cid;
//							cc.Poundage = "";
//							cc.OneOffConnectFees = "";
//							cc.MovePay = "";
//							cc.OMPoundage = "";
//							cc.oneyue = "";
//							cc.onePoundage = "";
//							cc.twoyue = "";
//							cc.twoPoundage = "";
//							cc.threeyue = "";
//							cc.threePoundage = "";
//							cc.fouryue = "";
//							cc.fourPoundage = "";
//							cc.fiveyue = "";
//							cc.fivePoundage = "";
//							cc.sixyue = "";
//							cc.sixPoundage = "";
//							cc.sevenyue = "";
//							cc.sevenPoundage = "";
//							cc.eightyue = "";
//							cc.eightPoundage = "";
//							cc.nineyue = "";
//							cc.ninePoundage = "";
//							cc.tenyue = "";
//							cc.tenPoundage = "";
//							cc.elevenyue = "";
//							cc.elevenPoundage = "";
//							cc.twelveyue = "";
//							cc.twelvePoundage = "";
//
//							cc.remark = "";
//							cc.Year = DropDownList3.SelectedValue;
//							cc.area_id = ((NrOA.Client.em.Client)(Cllist)[i]).AreaName;
//
//							dobfi.updateClientintChargel();
//						}
//						else//不存在添加一条对应该客户数据
//						{
//							cc.ClientOperationID = cid;
//							cc.Poundage = "";
//							cc.OneOffConnectFees = "";
//							cc.MovePay = "";
//							cc.OMPoundage = "";
//							cc.oneyue = "";
//							cc.onePoundage = "";
//							cc.twoyue = "";
//							cc.twoPoundage = "";
//							cc.threeyue = "";
//							cc.threePoundage = "";
//							cc.fouryue = "";
//							cc.fourPoundage = "";
//							cc.fiveyue = "";
//							cc.fivePoundage = "";
//							cc.sixyue = "";
//							cc.sixPoundage = "";
//							cc.sevenyue = "";
//							cc.sevenPoundage = "";
//							cc.eightyue = "";
//							cc.eightPoundage = "";
//							cc.nineyue = "";
//							cc.ninePoundage = "";
//							cc.tenyue = "";
//							cc.tenPoundage = "";
//							cc.elevenyue = "";
//							cc.elevenPoundage = "";
//							cc.twelveyue = "";
//							cc.twelvePoundage = "";
//
//							cc.remark = "";
//							cc.Year = DropDownList3.SelectedValue;
//							cc.area_id = ((NrOA.Client.em.Client)(Cllist)[i]).AreaName;
//						}
//					}
//					
//				}
//			}	
			#endregion
		}

		private void Button5_Click(object sender, System.EventArgs e)
		{
			//查询已注销用户
			NrOA.Client.pkg.DOClient dc = new NrOA.Client.pkg.DOClient();
			NrOA.Client.pkg.DoClient_Rundate dcr = new NrOA.Client.pkg.DoClient_Rundate();
			NrOA.CheckAccount.pkg.DOChargeInfo dci = new NrOA.CheckAccount.pkg.DOChargeInfo();
			IList list = null;
			list = dc.Client_by_state("1");
			if(list!=null)
			{
				if(list.Count>0)
				{
					//查询T_Client_Rundate和T_ChargeCollect
					for(int i=0;i<list.Count;i++)
					{
						string ClientOperationID = "";
						try
						{
							ClientOperationID = ((NrOA.Client.em.Client)(list)[i]).ClientOperationID;
						}
						catch{ClientOperationID = "";}

						if(ClientOperationID!="")
						{
							dcr.delete_Client_Rundate(ClientOperationID);
							dci.delete_ChargeCollect(ClientOperationID);
						}
					}

				}
			}
		}
		

	}
}
