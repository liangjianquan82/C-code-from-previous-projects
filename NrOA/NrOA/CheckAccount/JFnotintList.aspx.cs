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
	/// JFnotintList 的摘要说明。
	/// </summary>
	public class JFnotintList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist2;
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblPageCount;
		protected System.Web.UI.WebControls.Label lblCurrentIndex;
		protected System.Web.UI.WebControls.LinkButton btnFirst;
		protected System.Web.UI.WebControls.LinkButton btnPrev;
		protected System.Web.UI.WebControls.LinkButton btnNext;
		protected System.Web.UI.WebControls.LinkButton btnLast;

		NrOA.Client.pkg.DOClient dc = new NrOA.Client.pkg.DOClient();
		NrOA.CheckAccount.pkg.DOChargeInfo dci = new NrOA.CheckAccount.pkg.DOChargeInfo();
		NrOA.Area.pkg.DOArea DoA = new NrOA.Area.pkg.DOArea();
		NrOA.CheckAccount.em.ChargeInfo CI = new NrOA.CheckAccount.em.ChargeInfo();

		NrOA.CheckAccount.em.t_huikuan hk = new NrOA.CheckAccount.em.t_huikuan();
		NrOA.CheckAccount.em.t_yicixing yc = new NrOA.CheckAccount.em.t_yicixing();
		NrOA.CheckAccount.pkg.dao_t_huikuan dhk = new NrOA.CheckAccount.pkg.dao_t_huikuan();
		NrOA.CheckAccount.pkg.dao_t_yicixing dyc = new NrOA.CheckAccount.pkg.dao_t_yicixing();
		protected Hashtable ht = null;
		protected System.Web.UI.WebControls.RadioButton rb_ycx;
		protected System.Web.UI.WebControls.RadioButton rb_sy;
		protected System.Web.UI.WebControls.DataGrid Datagrid2;
		protected int count =0;
	
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

			Dropdownlist2.SelectedValue = DateTime.Now.Year.ToString();			

//			DropDownList3.DataSource = DoA.SelectAreaAll_LoginIn();
//			DropDownList3.DataTextField = "AreaName";
//			DropDownList3.DataValueField = "Area_ID";
//			DropDownList3.DataBind();
//			//Session["Area_ID"] = DropDownList3.SelectedValue.ToString();
//			DropDownList3.Items.Insert(0,"所有小区");
			try
			{
				DataGrid1.CurrentPageIndex = int.Parse(Session.Contents["PageIndex"].ToString());
			}
			catch{DataGrid1.CurrentPageIndex =0;}
			try
			{
				Dropdownlist2.SelectedValue = Session.Contents["year"].ToString();
			}
			catch{Dropdownlist2.SelectedValue = DateTime.Now.Year.ToString();}
			try
			{
				DropDownList4.SelectedValue = Session.Contents["month"].ToString();
			}
			catch{DropDownList4.SelectedValue = DateTime.Now.Month.ToString();}

			
			

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
			this.rb_ycx.CheckedChanged += new System.EventHandler(this.rb_ycx_CheckedChanged);
			this.rb_sy.CheckedChanged += new System.EventHandler(this.rb_sy_CheckedChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.Datagrid2.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.Datagrid2_PageIndexChanged);
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
				this.Datagrid2.Height = 255;
				this.Datagrid2.PageSize = 10;
			}
			else if(screen_width == 1024)
			{
				this.DataGrid1.Height = 425;
				this.DataGrid1.PageSize = 15;
				this.Datagrid2.Height = 255;
				this.Datagrid2.PageSize = 15;
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
			//list = dci.SelectChargeinfo_list(Dropdownlist2.SelectedValue,DropDownList4.SelectedValue, DropDownList3.SelectedValue,DropDownList1.SelectedValue,TextBox1.Text.Trim());
			//list = dci.jfnotintlist(Dropdownlist2.SelectedValue,DropDownList4.SelectedValue,TextBox1.Text.Trim());
			if(rb_ycx.Checked)
			{
				Datagrid2.Visible = false;
				DataGrid1.Visible = true;
				list = dyc.ycx_notin_client(Dropdownlist2.SelectedValue,DropDownList4.SelectedValue,TextBox1.Text.Trim());
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
			else if(rb_sy.Checked)
			{
				Datagrid2.Visible = true;
				DataGrid1.Visible = false;
				list = dhk.hk_notin_client(Dropdownlist2.SelectedValue,DropDownList4.SelectedValue,TextBox1.Text.Trim());
				if(list!=null)
				{
					if(list.Count>0)
					{
						count =  list.Count;
						Datagrid2.DataSource = list;
					}				
				}
			
				int tmp=count%Datagrid2.PageSize !=0 || count==0 ? (int) (count/Datagrid2.PageSize) + 1 : (int)(count/Datagrid2.PageSize);
				if(tmp<Datagrid2.CurrentPageIndex + 1)
				{
					Datagrid2.CurrentPageIndex = tmp - 1;
				}		
				Datagrid2.DataBind();
			}

			
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			BindGrid();
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			int startIndex ;
			startIndex = DataGrid1.CurrentPageIndex * DataGrid1.PageSize;
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
		private void Datagrid2_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			int startIndex ;
			startIndex = Datagrid2.CurrentPageIndex * Datagrid2.PageSize;
			Datagrid2.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}
		public void PagerButtonClick(object sender, EventArgs e)
		{
			if(rb_ycx.Checked)
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
			}
			else
			{

				string arg = ((LinkButton)sender).CommandArgument.ToString();
				switch(arg)
				{
					case "next":
						if (Datagrid2.CurrentPageIndex < (Datagrid2.PageCount - 1))
						{
							Datagrid2.CurrentPageIndex += 1;
						}
						break;
					case "prev":
						if (Datagrid2.CurrentPageIndex > 0)
						{
							Datagrid2.CurrentPageIndex -= 1;
						}
						break;
					case "last":
						Datagrid2.CurrentPageIndex = (Datagrid2.PageCount - 1);
						break;
					default:
						Datagrid2.CurrentPageIndex = System.Convert.ToInt32(arg);
						break;
				}
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
			if(rb_ycx.Checked)
			{
				lblCurrentIndex.Text = "第 " + (DataGrid1.CurrentPageIndex + 1).ToString() + " 页";
				lblPageCount.Text = "总共 " +count.ToString() + " 条记录 共 " +DataGrid1.PageCount.ToString() + " 页";
			}
			else
			{
				lblCurrentIndex.Text = "第 " + (Datagrid2.CurrentPageIndex + 1).ToString() + " 页";
				lblPageCount.Text = "总共 " +count.ToString() + " 条记录 共 " +Datagrid2.PageCount.ToString() + " 页";
			}
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.AlternatingItem) ||
				(e.Item.ItemType == ListItemType.Item))
			{
			}
		}
		protected void LinkButton_Command(Object sender, CommandEventArgs e) 
		{
//			Session["PageIndex"] = DataGrid1.CurrentPageIndex;
//			Session["year"] = Dropdownlist2.SelectedValue;
//			Session["month"] = DropDownList4.SelectedValue;
//			Response.Redirect("edchargeview.aspx?id="+e.CommandArgument.ToString());
		}

		private void rb_ycx_CheckedChanged(object sender, System.EventArgs e)
		{
			rb_ycx.Checked=true;
			rb_sy.Checked = false;
			BindGrid();
		}

		private void rb_sy_CheckedChanged(object sender, System.EventArgs e)
		{
			rb_ycx.Checked=false;
			rb_sy.Checked = true;
			BindGrid();
		}

		



	}
}
