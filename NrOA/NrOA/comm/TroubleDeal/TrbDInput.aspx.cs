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

namespace NrOA.TroubleDeal
{
	/// <summary>
	/// TrbDInput 的摘要说明。
	/// </summary>
	public class TrbDInput : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button UploadButton;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblPageCount;
		protected System.Web.UI.WebControls.Label lblCurrentIndex;
		protected System.Web.UI.WebControls.LinkButton btnFirst;
		protected System.Web.UI.WebControls.LinkButton btnPrev;
		protected System.Web.UI.WebControls.LinkButton btnNext;
		protected System.Web.UI.WebControls.LinkButton btnLast;
		protected System.Web.UI.HtmlControls.HtmlInputHidden deptid;

		protected Hashtable ht = null;
		protected int count=0;
		protected int find=0;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected string UserName = "";
		NrOA.TroubleDeal.pkg.DoTroubleDeal dtd = new NrOA.TroubleDeal.pkg.DoTroubleDeal();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			btnFirst.Text = "最首页";
			btnPrev.Text = "前一页";
			btnNext.Text = "下一页";
			btnLast.Text = "最后页";
			Inits();

			

			UserName = ht["EmployeeName"].ToString();
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
			UploadButton.Attributes.Add("onclick", "javascript: return confirm('导入数据将不进行检查,确定导入吗？')");

			TextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
			this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
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
			//NrOA.Client.pkg.DOClient docl = new NrOA.Client.pkg.DOClient();
			IList list = null;
			
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
			NrOA.TroubleDeal.em.TroubleDeal CI = new NrOA.TroubleDeal.em.TroubleDeal();
			NrOA.TroubleDeal.pkg.DoTroubleDeal dtd = new NrOA.TroubleDeal.pkg.DoTroubleDeal();
			NrOA.comm.TransactionSession ts = new NrOA.comm.TransactionSession();
			NrOA.Client.pkg.DOClient dc = new NrOA.Client.pkg.DOClient();
			int i = 0;
			DataTable dt=ds.Tables[0];	
			ts.BeginTransaction();
			IList li = null;
			
			try
			{		
				
				for (int j = 0; j < dt.Rows.Count; j++)
				{
					IList slist = null;
					if(dt.Rows[j][0].ToString() == "")  
						continue;

					string opid ="";
					CI.Trouble_nb = dt.Rows[j][0].ToString();//故障单号

					opid = dt.Rows[j][1].ToString().Trim();//业务号码
					CI.Proposer = dt.Rows[j][2].ToString();//客户名称
					CI.Complaints = dt.Rows[j][3].ToString();//客户投诉

					//故障申请时间
					if(dt.Rows[j][4].ToString().Trim()=="")
					{
						CI.Trouble_date = DateTime.Today.ToString("yyyy-MM-dd");
					}
					else
					{
						CI.Trouble_date = dt.Rows[j][4].ToString().Trim();
					}
					CI.Trouble_Describe = dt.Rows[j][5].ToString();//故障描述
					CI.ProposerPhone = dt.Rows[j][6].ToString();//电话
					CI.Moveinfo = dt.Rows[j][8].ToString().Trim();//流水信息
					CI.remark = dt.Rows[j][9].ToString().Trim();//备注
					CI.Register_man = UserName;
				
					if(opid!="")
					{
						
						CI.OperationID = opid.Substring(3);
						
						li = dc.selectClient_by_opid(CI.OperationID);
						if(li!=null)
						{
							if(li.Count>0)						
								CI.ProposerAddress = ((NrOA.Client.em.Client)(li)[0]).ClientAddress;
							else
								CI.ProposerAddress = "";
						}

					}
					else
					{
						CI.ProposerAddress = "";
						CI.OperationID = "";
					}         

					slist = dtd.selectTrouble_nb(dt.Rows[j][0].ToString());
					if(slist!=null)
					{
						if(slist.Count>0)
						{
						}
						else
						{
							dtd.insertTroubleDealDR(CI);
							i++;  
						}
					}
					else
					{
						dtd.insertTroubleDealDR(CI);
						i++;  
					}
										 
				}
				ts.CommitTransaction();
			}
			catch(System.Exception Ex)
			{
				Label1.Text = Ex.Message;
				ts.RollBackTransaction();
			}
			
			
			Response.Write("<script> alert('导入"+i.ToString()+"条记录完成!')</script>");			
			find = 1;
			this.BindGrid();
			return i;        
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			dtd.deleteTrbinfo_by_RDate(TextBox2.Text.Trim());
		}
	}
}
