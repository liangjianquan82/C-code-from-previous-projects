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

namespace NrOA.Affiche
{
	/// <summary>
	/// Affichelist 的摘要说明。
	/// </summary>
	public class Affichelist : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
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


		protected Hashtable ht = null;
		protected int count=0;
		NrOA.Affiche.em.affiche Ar = new NrOA.Affiche.em.affiche();
		NrOA.Affiche.pkg.DOaffiche doar = new NrOA.Affiche.pkg.DOaffiche();
		protected System.Web.UI.WebControls.Button Button5;
		private string UserName = "";
	
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
			if(Page.IsPostBack)
				return;
			try
			{
				if (Request["page"]!=null)
					DataGrid1.CurrentPageIndex = int.Parse(Request["page"].ToString());
			}
			catch
			{
				DataGrid1.CurrentPageIndex = 0;
			}

			BindGrid();

			if(UserName=="user")
			{
				Button4.Visible = false;
				Button2.Visible = false;
				Button3.Visible = false;
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
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button5.Click += new System.EventHandler(this.Button5_Click);
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
			
			Button3.Attributes.Add("onclick", "javascript: return isdel()");
			Button4.Attributes.Add("onclick", "javascript: return ispost()");
			Button5.Attributes.Add("onclick", "javascript: return deleteinfo()");
			
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
			list = doar.SelectAffiche_state(DropDownList2.SelectedValue);

			if(list!=null)
			{
				count =  list.Count;
			}

			DataGrid1.DataSource = list;
			DataGrid1.DataBind();
			
			//this.DataGrid1.DataKeyField = "Client_ID";
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

		protected void LinkButton_Command(Object sender, CommandEventArgs e) 
		{
			Response.Redirect("AfficheView.aspx?Affiche_ID="+e.CommandArgument.ToString()+"&state=update");
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AfficheView.aspx?state=new");
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			//取消发布
			if(selvalues.Value.ToString() != "" && selvalues.Value.ToString().Length > 1)
			{
				string [] Area_IDs = selvalues.Value.ToString().Split(',');
				foreach(string Area_ID in Area_IDs)
				{
					if(Area_ID!="")
					{
						Ar.Affiche_ID = int.Parse(Area_ID);
						Ar.state = "0";
						try
						{							
							doar.Affiche_State_Change(Ar);
						}
						catch{}
					}
				}
				selvalues.Value = ",";
			}
			BindGrid();
		}

		private void Button4_Click(object sender, System.EventArgs e)
		{
			//发布
			if(selvalues.Value.ToString() != "" && selvalues.Value.ToString().Length > 1)
			{
				string [] Area_IDs = selvalues.Value.ToString().Split(',');
				foreach(string Area_ID in Area_IDs)
				{
					if(Area_ID!="")
					{
						Ar.Affiche_ID = int.Parse(Area_ID);
						Ar.state = "1";
						try
						{							
							doar.Affiche_State_Change(Ar);
						}
						catch{}
					}
				}
				selvalues.Value = ",";
			}
			BindGrid();
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			BindGrid();
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.AlternatingItem) ||
				(e.Item.ItemType == ListItemType.Item))
			{
				string s = e.Item.Cells[4].Text.Trim();
				if(s == "1")
				{
					e.Item.Cells[4].Text = "发布";
					e.Item.Cells[4].ForeColor = Color.Green;
				}
				else
				{
					(e.Item.Cells[4]).Text = "未发布";
				}
			}
		}

		private void Button5_Click(object sender, System.EventArgs e)
		{
			//删除
			if(selvalues.Value.ToString() != "" && selvalues.Value.ToString().Length > 1)
			{
				string [] Area_IDs = selvalues.Value.ToString().Split(',');
				foreach(string Area_ID in Area_IDs)
				{
					if(Area_ID!="")
					{
						Ar.Affiche_ID = int.Parse(Area_ID);
						
						try
						{							
							doar.delete_afficheInfo(Ar.Affiche_ID);
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
