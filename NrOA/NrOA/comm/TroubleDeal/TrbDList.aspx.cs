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

namespace NrOA.TroubleDeal
{
	/// <summary>
	/// TroubleDealList 的摘要说明。
	/// </summary>
	public class TroubleDealList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.Button Button4;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblPageCount;
		protected System.Web.UI.WebControls.Label lblCurrentIndex;
		protected System.Web.UI.WebControls.LinkButton btnFirst;
		protected System.Web.UI.WebControls.LinkButton btnPrev;
		protected System.Web.UI.WebControls.LinkButton btnNext;
		protected System.Web.UI.WebControls.LinkButton btnLast;
		protected System.Web.UI.HtmlControls.HtmlInputHidden selvalues;

		NrOA.TroubleDeal.pkg.DoTroubleDeal dtd = new NrOA.TroubleDeal.pkg.DoTroubleDeal();


		protected Hashtable ht = null;
		protected int count;
		private string find = "";
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		private string UserName = "";
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.Button Button5;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		private string state = "";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面

			btnFirst.Text = "最首页";
			btnPrev.Text = "前一页";
			btnNext.Text = "下一页";
			btnLast.Text = "最后页";
	
			Inits();
			try
			{
				UserName = ht["EmployeeName"].ToString();
			}
			catch{}
			try
			{
				state = Request["state"].ToString();
			}
			catch{}			
			if(state=="")
			{
				try
				{
					state = Session.Contents["state"].ToString();
				}
				catch{}
			}
			else
			{
				Session["state"] = state;
			}

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

			try
			{
				if (Request["page"]!=null)
					DataGrid1.CurrentPageIndex = int.Parse(Request["page"].ToString());
			}
			catch
			{
				DataGrid1.CurrentPageIndex = 0;
			}
			

			//部分权限
			if(UserName=="user")
			{
				Button2.Visible = false;
				Button4.Visible = false;
				Button3.Visible = false;
			}
			Button4.Visible = false;
//			DropDownList4.SelectedValue = DateTime.Now.Year.ToString();
//			Dropdownlist3.SelectedValue = DateTime.Now.Month.ToString();
//			DropDownList5.SelectedValue = DateTime.Now.Month.ToString();
			if(Session["query_bdate"] == null || Session["query_bdate"].ToString() == "")
				TextBox2.Text = DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-1";
			else
				TextBox2.Text = Session["query_bdate"].ToString();
			if(Session["query_edate"] == null || Session["query_edate"].ToString() == "")
				TextBox3.Text = DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.DaysInMonth(DateTime.Today.Year,DateTime.Today.Month).ToString();
			else
				TextBox3.Text = Session["query_edate"].ToString();

			
			if(state=="new")
			{
				DataGrid1.Columns[9].Visible = false;
				DataGrid1.Columns[10].Visible = false;
				DataGrid1.Columns[11].Visible = false;
				DataGrid1.Columns[12].Visible = false;
				DataGrid1.Columns[13].Visible = false;

				Button3.Visible = true;
				Button2.Visible = true;
			}
			else if(state=="deal")
			{
				Label3.Text = "已处理列表";
				DataGrid1.Columns[11].Visible = false;
				DataGrid1.Columns[12].Visible = false;
				DataGrid1.Columns[13].Visible = false;
				DataGrid1.Columns[9].HeaderStyle.Width= 80;
				DataGrid1.Columns[10].HeaderStyle.Width= 80;
				Button3.Visible = false;
				Button2.Visible = false;
			}
			else if(state=="end")
			{
				Label3.Text = "处理结束列表";
				Button3.Visible = false;
				Button2.Visible = false;
				DataGrid1.Columns[14].Visible = false;
				DataGrid1.Columns[9].HeaderStyle.Width= 80;
				DataGrid1.Columns[11].HeaderStyle.Width= 80;
				DataGrid1.Columns[12].HeaderStyle.Width= 80;
				DataGrid1.Columns[13].HeaderStyle.Width= 80;
				DataGrid1.Columns[7].Visible = false;
				DataGrid1.Columns[8].Visible = false;
				DataGrid1.Columns[10].Visible = false;
				Button5.Visible = true;
			}

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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button5.Click += new System.EventHandler(this.Button5_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
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
			Button4.Attributes.Add("onclick", "javascript: return ispost()");
			Button1.Attributes.Add("onclick", "javascript: return checkclick()");
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
			
			//
			if(state=="new")
			{
				list = dtd.selectTrblist("1",TextBox1.Text.Trim(),TextBox2.Text.Trim(),TextBox3.Text.Trim(),DropDownList2.SelectedValue);
			}
			else if(state=="deal")
			{
				list = dtd.selectTrblist("2",TextBox1.Text.Trim(),TextBox2.Text.Trim(),TextBox3.Text.Trim(),DropDownList2.SelectedValue);
			}
			else if(state=="end")
			{
				list = dtd.selectTrblist("3",TextBox1.Text.Trim(),TextBox2.Text.Trim(),TextBox3.Text.Trim(),DropDownList2.SelectedValue);
			}

			DataGrid1.DataSource = list;
			DataGrid1.DataBind();
			try
			{
				count =  list.Count;
			}
			catch
			{
			}

			//this.DataGrid1.DataKeyField = "Client_ID";
			int tmp=count%DataGrid1.PageSize !=0 || count==0 ? (int) (count/DataGrid1.PageSize) + 1 : (int)(count/DataGrid1.PageSize);
			if(tmp<DataGrid1.CurrentPageIndex + 1)
			{
				DataGrid1.CurrentPageIndex = tmp - 1;
			}

			try
			{
				DataGrid2.PageSize = list.Count;
			}
			catch{}
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

		private void Button1_Click(object sender, System.EventArgs e)
		{
			DataGrid1.CurrentPageIndex = 0;
			this.find = "1";
			Session["find"] = 1;			
			BindGrid();
		}
		protected void LinkButton_Command(Object sender, CommandEventArgs e) 
		{
			Session["PageIndex"] = DataGrid1.CurrentPageIndex;
			//Session["AreaName"] = AreaName;
			Response.Redirect("TrbDView.aspx?Trouble_id="+e.CommandArgument.ToString()+"&state=update&state1="+state);
			
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.AlternatingItem) ||
				(e.Item.ItemType == ListItemType.Item))
			{
				if(e.Item.Cells[15].Text=="1")
				{
					e.Item.Cells[15].Text = "未处理";
				}
				else if(e.Item.Cells[15].Text=="2")
				{
					e.Item.Cells[15].Text = "处理中";
				}
				else if(e.Item.Cells[15].Text=="3")
				{
					e.Item.Cells[15].Text = "处理结束";
				}

				if(e.Item.Cells[8].Text.Length>20)
				e.Item.Cells[8].Text = e.Item.Cells[8].Text.Substring(0,20)+"...";
			}
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("TrbDView.aspx?state=new");
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			//删除
			if(selvalues.Value.ToString() != "" && selvalues.Value.ToString().Length > 1)
			{
				string [] Client_IDs = selvalues.Value.ToString().Split(',');
				foreach(string Client_ID in Client_IDs)
				{
					if(Client_ID!="")
					{
						try
						{							
							dtd.deleteTrbinfo(Client_ID);
						}
						catch{}
					}
				}
				selvalues.Value = ",";
			}
			BindGrid();
		}

		private void Button5_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Excelout.aspx");

		}
	}
}
