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

namespace NrOA.Client
{
	/// <summary>
	/// ClientView 的摘要说明。
	/// </summary>
	public class ClientView : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label_Title;
		protected System.Web.UI.WebControls.Button ok2;
		protected System.Web.UI.WebControls.Button Button11;
		protected System.Web.UI.WebControls.TextBox tbExpectBeginTime;
		protected System.Web.UI.WebControls.TextBox tbExpectEndTime;
		protected System.Web.UI.WebControls.Button ok;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox tmpTaskID;
		protected System.Web.UI.WebControls.TextBox tmpReturnUrl;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.TextBox TextBox5;
		protected System.Web.UI.WebControls.TextBox TextBox6;
		protected System.Web.UI.WebControls.TextBox TextBox7;
		protected System.Web.UI.WebControls.TextBox TextBox8;
		protected System.Web.UI.WebControls.TextBox TextBox9;
		protected System.Web.UI.WebControls.TextBox TextBox10;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.TextBox TextBox11;
		protected System.Web.UI.WebControls.TextBox Textbox13;
		protected System.Web.UI.WebControls.TextBox TextBox12;
		protected System.Web.UI.HtmlControls.HtmlForm addtask;

		private int Client_ID = -1;
		protected System.Web.UI.WebControls.TextBox TextBox14;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		private string state = "";

		private string RegisterMane = "";
		Hashtable hast=null;
		private int PageIndex=0;
		private string AName="";
		private string AreaName = "";
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面

			try
			{
				if (Session["PageIndex"]!=null && Session["PageIndex"].ToString()!="")
					PageIndex = int.Parse(Session["PageIndex"].ToString());
			}
			catch{}

			try
			{
				AreaName = Request["AreaName"].ToString();
			}
			catch{}
			try
			{
				if (Session["AreaName"]!=null && Session["AreaName"].ToString()!="")
					AreaName = Session["AreaName"].ToString();
			}
			catch{}

			ok.Attributes.Add("onclick","javascript: return checksave()");
			ok2.Attributes.Add("onclick","javascript: return checksave()");
			try
			{
				state = Request["state"].ToString();
			}
			catch{}
			try{Client_ID = int.Parse(Request["Client_ID"].ToString());}
			catch{}
			hast = (Hashtable)Session["userinfo"];
		
			RegisterMane = hast["EmployeeName"].ToString();

			if(Page.IsPostBack)
				return;

			this.tbExpectBeginTime.Text = DateTime.Today.ToString("yyyy-MM-dd");
			this.tbExpectEndTime.Text  = DateTime.Today.AddDays(3).ToString("yyyy-MM-dd");
			this.Textbox13.Text = DateTime.Today.AddYears(1).AddDays(3).ToString("yyyy-MM-dd");

			NrOA.ProductType.pkg.DOProductType Dop = new NrOA.ProductType.pkg.DOProductType();
			DropDownList1.DataSource = Dop.selectPTA();
			DropDownList1.DataTextField = "Product_Type";
			DropDownList1.DataValueField = "Product_Type";
			DropDownList1.DataBind();
			NrOA.Area.pkg.DOArea doa = new NrOA.Area.pkg.DOArea();
			DropDownList2.DataSource = doa.SelectAreaAll_LoginIn();
			DropDownList2.DataTextField = "AreaName";
			DropDownList2.DataValueField = "Area_ID";
			DropDownList2.DataBind();
			DropDownList3.DataSource = Dop.SelectProductType_loginint();
			DropDownList3.DataTextField = "Product_Type";
			DropDownList3.DataValueField = "Product_Type";
			DropDownList3.DataBind();
			DropDownList3.Items.Insert(0,ListItem.FromString("-选择套餐-"));

			if(state=="update")
			{
				Label_Title.Text = "修改用户信息";
				Add();
			}
			else
			{
				Label_Title.Text = "新增用户信息";
				TextBox11.Text = RegisterMane;
				TextBox12.Text = DateTime.Today.ToString();
				DropDownList1.Visible = false;
				DropDownList2.SelectedValue = AreaName;
				NrOA.Client.pkg.DOClient dc = new NrOA.Client.pkg.DOClient();			
				TextBox14.Text = dc.selectClient_Arae_by_MaxClistid(DropDownList2.SelectedValue);;
			}

			if(RegisterMane=="user")
			{
				ok2.Visible = false;
				ok.Visible=false;
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
			this.ok2.Click += new System.EventHandler(this.ok2_Click);
			this.Button11.Click += new System.EventHandler(this.Button11_Click);
			this.DropDownList2.SelectedIndexChanged += new System.EventHandler(this.DropDownList2_SelectedIndexChanged);
			this.ok.Click += new System.EventHandler(this.ok_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		private void Add()
		{
			NrOA.Client.pkg.DOClient doc = new NrOA.Client.pkg.DOClient();
			IList list = null;
			list = doc.SelectClient_by_id(Client_ID);
			if(list!=null)
			{
				if(list.Count>0)
				{
					TextBox14.Text = ((NrOA.Client.em.Client)(list)[0]).ClientListID;
					TextBox1.Text = ((NrOA.Client.em.Client)(list)[0]).ClientName;
					TextBox2.Text = ((NrOA.Client.em.Client)(list)[0]).ClientOperationID;
					TextBox3.Text = ((NrOA.Client.em.Client)(list)[0]).ClientPhone;
					TextBox5.Text = ((NrOA.Client.em.Client)(list)[0]).ClientAddress;
					TextBox6.Text = ((NrOA.Client.em.Client)(list)[0]).ClientAccounts;
					TextBox7.Text = ((NrOA.Client.em.Client)(list)[0]).ClientPassword;

					try
					{
						tbExpectBeginTime.Text = ((NrOA.Client.em.Client)(list)[0]).AcceptDate.ToString();
						if(tbExpectBeginTime.Text.Trim()!="")
						{
							tbExpectBeginTime.Text = DateTime.Parse(tbExpectBeginTime.Text).ToString("yyyy-MM-dd");
						}
					}
					catch{}
					try
					{
						tbExpectEndTime.Text = ((NrOA.Client.em.Client)(list)[0]).RunDate.ToString();
						if(tbExpectEndTime.Text.Trim()!="")
						{
							tbExpectEndTime.Text = DateTime.Parse(tbExpectEndTime.Text).ToString("yyyy-MM-dd");
						}
					}
					catch{}
					try
					{
						Textbox13.Text = ((NrOA.Client.em.Client)(list)[0]).AvDate.ToString();
						if(Textbox13.Text.Trim()!="")
						{
							Textbox13.Text = DateTime.Parse(Textbox13.Text).ToString("yyyy-MM-dd");
						}
					}
					catch{}
					TextBox10.Text = ((NrOA.Client.em.Client)(list)[0]).IDCard;
					TextBox8.Text = ((NrOA.Client.em.Client)(list)[0]).CircsDescribe;
					TextBox9.Text = ((NrOA.Client.em.Client)(list)[0]).Remark;
					try
					{
						DropDownList1.SelectedValue = ((NrOA.Client.em.Client)(list)[0]).ProductType;
					}
					catch{}
					DropDownList2.SelectedValue =  ((NrOA.Client.em.Client)(list)[0]).AreaName;

					TextBox11.Text = ((NrOA.Client.em.Client)(list)[0]).RegisterMane;
					TextBox12.Text = ((NrOA.Client.em.Client)(list)[0]).RegisterTime;
				}
			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			this.Page.Response.Redirect("ClientList.aspx?AreaName="+AreaName+"&page="+PageIndex.ToString());
		}

		private void Button11_Click(object sender, System.EventArgs e)
		{
			this.Page.Response.Redirect("ClientList.aspx?AreaName="+AreaName+"&page="+PageIndex.ToString());
		}

		private void ok2_Click(object sender, System.EventArgs e)
		{
			Savedata();
		}

		private void ok_Click(object sender, System.EventArgs e)
		{
			Savedata();
		}

		private void Savedata()
		{
			NrOA.Client.pkg.DOClient doc = new NrOA.Client.pkg.DOClient();
			NrOA.Client.em.Client cl = new NrOA.Client.em.Client();

			cl.ClientListID = TextBox14.Text.Trim();
			cl.ClientName = TextBox1.Text.Trim();
			cl.ClientOperationID=TextBox2.Text.Trim();
			cl.ClientPhone = TextBox3.Text .Trim();
			cl.ClientAddress  = TextBox5.Text.Trim();
			cl.ClientAccounts = TextBox6.Text.Trim();
			cl.ClientPassword = TextBox7.Text.Trim();
			cl.AcceptDate = tbExpectBeginTime.Text.Trim();			
			cl.RunDate = tbExpectEndTime.Text.Trim();			
			cl.AvDate = Textbox13.Text.Trim();			
			cl.IDCard = TextBox10.Text.Trim();
			cl.CircsDescribe = TextBox8.Text.Trim();
			cl.Remark = TextBox9.Text.Trim();

			if(state=="update"&&DropDownList3.SelectedValue =="-选择套餐-")
			{
				cl.ProductType = DropDownList1.SelectedValue;
			}
			else
			{
				cl.ProductType = DropDownList3.SelectedValue;
			}

			if(DropDownList2.SelectedValue =="-请选择小区-" )
			{
				
				Response.Write("<script> alert('请选择小区!')</script>");	
				return;
			}
			else
			{cl.AreaName = DropDownList2.SelectedValue ;}
			
			

			if(state=="new")
			{
				cl.RegisterMane = TextBox11.Text.Trim();
				doc.InsertClientList(cl);

			} 
			else if(state=="update")
			{
				cl.RegisterTime = TextBox12.Text.Trim();
				cl.RegisterMane= RegisterMane;
				cl.Client_ID = Client_ID;
				doc.updateClientList(cl); 				
			}
			Response.Write("<script>window.alert('数据保存成功');window.location='../Client/ClientList.aspx?AreaName="+AreaName+"&page="+PageIndex.ToString()+"';</script>");
		}

		private void DropDownList2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(state=="update")
			{
			}
			else
			{
				NrOA.Client.pkg.DOClient dc = new NrOA.Client.pkg.DOClient();			
				TextBox14.Text = dc.selectClient_Arae_by_MaxClistid(DropDownList2.SelectedValue);
			}			
		}
	}
}
