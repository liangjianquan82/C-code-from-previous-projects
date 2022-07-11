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
	/// ClientList ��ժҪ˵����
	/// </summary>
	public class ClientList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button3;
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
		protected System.Web.UI.WebControls.Button Button4;
		protected int count;

		protected NrOA.Client.em.Client CL = new NrOA.Client.em.Client();
		protected NrOA.Client.pkg.DOClient DOCL = new NrOA.Client.pkg.DOClient();
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Button Button1;

		private string AreaName = "";
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button UploadButton;
		protected System.Web.UI.HtmlControls.HtmlInputHidden deptid;

		private string find = "";
		private string UserName = "";

		NrOA.Area.pkg.DOArea doa = new NrOA.Area.pkg.DOArea();
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.DropDownList DropDownList5;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected System.Web.UI.WebControls.RadioButton RadioButton1;
		protected System.Web.UI.WebControls.Label Label1;
		NrOA.Area.em.Area area = new NrOA.Area.em.Area();
		protected System.Web.UI.WebControls.Button Button5;
		protected System.Web.UI.WebControls.RadioButton RadioButton2;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected System.Web.UI.WebControls.CheckBox CheckBox2;
		protected String strViewString ="";

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			btnFirst.Text = "����ҳ";
			btnPrev.Text = "ǰһҳ";
			btnNext.Text = "��һҳ";
			btnLast.Text = "���ҳ";

						
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

			Inits();
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
				Label3.Text = ((NrOA.Area.em.Area)(list)[0]).AreaName+"�ͻ��б�";
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

//			DropDownList1.DataSource = DoAr.SelectAreaAll_LoginIn();
//			DropDownList1.DataTextField = "AreaName";
//			DropDownList1.DataValueField = "AreaName";
//			DropDownList1.DataBind();
			// Ĭ�ϻ�ȡ�ײ��б�
			BindGrid();

			//����Ȩ��
			if(UserName=="user")
			{
				Button2.Visible = false;
				Button4.Visible = false;
				Button3.Visible = false;
				Button5.Visible = false;
			}
			Button4.Visible = false;
			DropDownList4.SelectedValue = DateTime.Now.Year.ToString();
			Dropdownlist3.SelectedValue = DateTime.Now.Month.ToString();
			DropDownList5.SelectedValue = DateTime.Now.Month.ToString();
			//Session["year"] = DropDownList4.SelectedValue;
			
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.DropDownList2.SelectedIndexChanged += new System.EventHandler(this.DropDownList2_SelectedIndexChanged);
			this.DropDownList4.SelectedIndexChanged += new System.EventHandler(this.DropDownList4_SelectedIndexChanged);
			this.RadioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
			this.RadioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			this.Button5.Click += new System.EventHandler(this.Button5_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DataGrid1_SortCommand);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.CheckBox2.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		//��ʼ������
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
			
			//����û���Ϣ
			ht=CheckUserLogin();
			//���������ȷ��
//			Button1.Attributes.Add("onclick", "javascript: return checksave()");
			Button3.Attributes.Add("onclick", "javascript: return isdel()");
			Button4.Attributes.Add("onclick", "javascript: return ispost()");
		}
		//����û���Ϣ
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
			//�������ݼ�
			IList list = null;
			if(this.find!="1")
			{
				list = DOCL.SelectClient_byAreaName(AreaName);
				RadioButton1.Checked = true; 
				
			}
			else
			{
				if(TextBox1.Text.Trim()=="")
				{
					if(RadioButton1.Checked)
					{
						list = DOCL.SelectClient_byAreaName1(AreaName,DropDownList2.SelectedValue,DropDownList4.SelectedValue,Dropdownlist3.SelectedValue,DropDownList5.SelectedValue);
					}
					else
					{
						list = DOCL.SelectClient_byAreaName(AreaName,DropDownList2.SelectedValue,DropDownList4.SelectedValue,Dropdownlist3.SelectedValue,DropDownList5.SelectedValue);
					}
					//Response.Write( " <script> alert( '����дģ����ѯ����! ') </script> ");   
					//return;
				}
				else
				{
					if(RadioButton1.Checked)
					{
						list = DOCL.SelectClientByFind(TextBox1.Text.Trim(),DropDownList2.SelectedValue);
					}
					else
					{
						list = DOCL.SelectClientByFind(TextBox1.Text.Trim(),DropDownList2.SelectedValue,AreaName);
					}
				}
			}

			if(CheckBox1.Checked)
			{
				list = DOCL.selecjgwk();
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

			if(CheckBox2.Checked)
			{
				DataGrid1.PageSize = count;
			}


			this.DataGrid1.DataKeyField = "Client_ID";
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
			lblCurrentIndex.Text = "�� " + (DataGrid1.CurrentPageIndex + 1).ToString() + " ҳ";
			lblPageCount.Text = "�ܹ� " +count.ToString() + " ����¼ �� " +DataGrid1.PageCount.ToString() + " ҳ";
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
			Session["AreaName"] = AreaName;
			Response.Redirect("ClientView.aspx?Client_ID="+e.CommandArgument.ToString()+"&state=update");
			
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ClientView.aspx?state=new&AreaName="+AreaName);
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			//ע��
			if(selvalues.Value.ToString() != "" && selvalues.Value.ToString().Length > 1)
			{
				string [] Client_IDs = selvalues.Value.ToString().Split(',');
				foreach(string Client_ID in Client_IDs)
				{
					if(Client_ID!="")
					{
						CL.Client_ID = int.Parse(Client_ID);
						CL.ClientState = "1";
						try
						{							
							DOCL.upateClientstate(CL);
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
			//����
			if(selvalues.Value.ToString() != "" && selvalues.Value.ToString().Length > 1)
			{
				string [] Client_IDs = selvalues.Value.ToString().Split(',');
				foreach(string Client_ID in Client_IDs)
				{
					if(Client_ID!="")
					{
						CL.Client_ID = int.Parse(Client_ID);
						CL.ClientState = "0";
						try
						{							
							DOCL.upateClientstate(CL);
						}
						catch{}
					}
				}
				selvalues.Value = ",";
			}
			BindGrid();
		}


		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.AlternatingItem) ||
				(e.Item.ItemType == ListItemType.Item))
			{
				if(e.Item.Cells[11].Text == "1")
				{
					e.Item.Cells[11].Text = "����";
					e.Item.Cells[11].ForeColor = Color.Red;
				}
				else
				{
					(e.Item.Cells[11]).Text = "����";
				}
			}
		}

		private void DropDownList2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DropDownList2.SelectedValue=="0")
			{
				Button3.Visible = true;
				Button4.Visible = false;
				Button5.Visible = true;
			}
			else
			{
				Button3.Visible = false;
				Button4.Visible = true;
				Button5.Visible = false;
			}
		}

		private void DataGrid1_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if (e.SortExpression == "ClientListID")
				strViewString = "ClientListID";
			else
				strViewString = e.SortExpression;
			BindGrid();

		}

		private void Button5_Click(object sender, System.EventArgs e)
		{
			//ע��
			if(selvalues.Value.ToString() != "" && selvalues.Value.ToString().Length > 1)
			{
				string [] Client_IDs = selvalues.Value.ToString().Split(',');
				foreach(string Client_ID in Client_IDs)
				{
					if(Client_ID!="")
					{
						
						try
						{							
							DOCL.deleteClient_by_id(Client_ID);
						}
						catch{}
					}
				}

				selvalues.Value = ",";
			}
			BindGrid();
		}

		private void RadioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(RadioButton1.Checked)
			{
				RadioButton2.Checked=false;
			}
			else
			{
				RadioButton2.Checked=true;
			}
			
		}

		private void RadioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			if(RadioButton2.Checked)
			{
				RadioButton1.Checked=false;
			}
			else
			{
				RadioButton1.Checked=true;
			}
			
		}

		private void DropDownList4_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session["year"] = DropDownList4.SelectedValue;
		}

		private void CheckBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			BindGrid();
		}
		
	}
}
