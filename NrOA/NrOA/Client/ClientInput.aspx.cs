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
using Microsoft.Web.UI.WebControls;

using System.Data.OleDb;


namespace NrOA.Client
{
	/// <summary>
	/// ClientInput 的摘要说明。
	/// </summary>
	public class ClientInput : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button UploadButton;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblPageCount;
		protected System.Web.UI.WebControls.Label lblCurrentIndex;
		protected System.Web.UI.WebControls.LinkButton btnFirst;
		protected System.Web.UI.WebControls.LinkButton btnPrev;
		protected System.Web.UI.WebControls.LinkButton btnNext;
		protected System.Web.UI.WebControls.LinkButton btnLast;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden deptid;

		protected Hashtable ht = null;
		protected System.Web.UI.WebControls.Button Button1;
		protected int count=0;
		protected System.Web.UI.WebControls.Button Button2;
		protected int find=0;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			btnFirst.Text = "最首页";
			btnPrev.Text = "前一页";
			btnNext.Text = "下一页";
			btnLast.Text = "最后页";
			Inits();

			

			if (this.IsPostBack) 
			{
				return;
			}

			NrOA.Area.pkg.DOArea doa = new NrOA.Area.pkg.DOArea();
			DropDownList1.DataSource = doa.SelectAreaAll_LoginIn();
			DropDownList1.DataTextField = "AreaName";
			DropDownList1.DataValueField = "Area_ID";
			DropDownList1.DataBind();

			try
			{
				if (Request["page"]!=null)
					DataGrid1.CurrentPageIndex = int.Parse(Request["page"].ToString());
			}
			catch
			{
				DataGrid1.CurrentPageIndex = 0;
			}

			if(DropDownList1.SelectedValue=="1")
			{
				UploadButton.Attributes.Add("onclick","javascript: return ischeck()");
			}
			else
			{
				UploadButton.Attributes.Add("onclick", "javascript: return confirm('导入数据将不进行检查,确定导入吗？')");
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
			this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
			this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
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
			NrOA.Client.pkg.DOClient docl = new NrOA.Client.pkg.DOClient();
			IList list = null;
			if(find==1)
			{
				list = docl.SelectClient_byAreaName(DropDownList1.SelectedValue.ToString());
			}
			else
			{
//				list = docl.
			}
			//DataGrid1.DataSource = dopt.SelectAllProductType();

//			this.DataGrid1.DataKeyField = "Product_ID";

			if(list!=null)
			{
				if(list.Count>0)
				{
					DataGrid1.DataSource = list;
					count =  list.Count;
				}
			}
			

			DataGrid1.DataBind();
			int tmp=count%DataGrid1.PageSize !=0 || count==0 ? (int) (count/DataGrid1.PageSize) + 1 : (int)(count/DataGrid1.PageSize);
			if(tmp<DataGrid1.CurrentPageIndex + 1)
			{
				DataGrid1.CurrentPageIndex = tmp - 1;
			}

			

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

		private void UploadButton_Click(object sender, System.EventArgs e)
		{
			// 导入用户信息
			this.SaveFile();
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
			ImportData(ReadExcel(path, "Sheet1"));
		}
		public DataSet ReadExcel(string path,string sheet)
		{
			string mystring = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = '"+path+"';Extended Properties=Excel 8.0";
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
		public int ImportData(DataSet ds)
		{
			NrOA.Client.em.Client CI = new NrOA.Client.em.Client();
			NrOA.Client.pkg.DOClient dobfi = new NrOA.Client.pkg.DOClient();
			NrOA.comm.TransactionSession ts = new NrOA.comm.TransactionSession();
			int i = 0;
			DataTable dt=ds.Tables[0];	
			ts.BeginTransaction();
			try
			{
				
				
				for (int j = 0; j < dt.Rows.Count; j++)
				{
					if(dt.Rows[j][0].ToString() == "")  
						continue;
					//					

					CI.ClientListID = dt.Rows[j][0].ToString();//编号
					CI.ClientName = dt.Rows[j][1].ToString();//客户名称
					CI.ClientOperationID = dt.Rows[j][2].ToString();//业务号码
					CI.ClientPhone = dt.Rows[j][3].ToString();//电话
					CI.ClientAddress = dt.Rows[j][4].ToString();//客户地址
					CI.ClientAccounts = dt.Rows[j][5].ToString();//账号
					CI.ClientPassword = dt.Rows[j][6].ToString();//密码
					CI.IDCard = dt.Rows[j][7].ToString();//身份证
					CI.AcceptDate = dt.Rows[j][8].ToString();//受理日期
					CI.RunDate = dt.Rows[j][9].ToString();//开通日期
					CI.AvDate = dt.Rows[j][10].ToString();//使用有效期

					CI.ProductType = dt.Rows[j][11].ToString();//套餐

					CI.CircsDescribe = dt.Rows[j][12].ToString();//相对网通情况
					CI.Remark = dt.Rows[j][13].ToString();//备注

					CI.AreaName = DropDownList1.SelectedValue.ToString();//小区编号
					CI.RegisterMane = ht["EmployeeName"].ToString();//处理人

					dobfi.InsertClientList(CI);
					
					i++;   
				}
				ts.CommitTransaction();
//				ts.CloseConnection();
			}
			catch{ts.RollBackTransaction();}
			
			
			Response.Write("<script> alert('导入"+i.ToString()+"条记录完成!')</script>");			
			find = 1;
			this.BindGrid();
			return i;        
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			find = 1;
			this.BindGrid();
		}

		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropDownList1.SelectedValue=="1")
			{
				UploadButton.Attributes.Add("onclick","javascript: return ischeck()");
			}
			else
			{
				UploadButton.Attributes.Add("onclick", "javascript: return confirm('导入数据将不进行检查,确定导入吗？')");
			}
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			NrOA.Client.pkg.DoClient_Rundate dcr = new NrOA.Client.pkg.DoClient_Rundate();
			dcr.Add_Update_Client_Rundate();
			return;
		}		
	}
}
