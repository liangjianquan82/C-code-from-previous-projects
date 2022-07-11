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
	/// TrbDInput ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
			btnFirst.Text = "����ҳ";
			btnPrev.Text = "ǰһҳ";
			btnNext.Text = "��һҳ";
			btnLast.Text = "���ҳ";
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
			UploadButton.Attributes.Add("onclick", "javascript: return confirm('�������ݽ������м��,ȷ��������')");

			TextBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
			BindGrid();
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
			this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
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
			lblCurrentIndex.Text = "�� " + (DataGrid1.CurrentPageIndex + 1).ToString() + " ҳ";
			lblPageCount.Text = "�ܹ� " +count.ToString() + " ����¼ �� " +DataGrid1.PageCount.ToString() + " ҳ";
		}


		private void UploadButton_Click(object sender, System.EventArgs e)
		{
			// �����û���Ϣ
			this.SaveFile();
		}
		private bool SaveFile()
		{
			///'����File��Ԫ��
			HttpFileCollection files  = HttpContext.Current.Request.Files;

			///'״̬��Ϣ
			System.Text.StringBuilder strMsg = new System.Text.StringBuilder();
			strMsg.Append("�ϴ����ļ��ֱ��ǣ�<hr color=red>");
			try
			{
				for(int iFile = 0; iFile < files.Count; iFile++)
				{
					///'����ļ���չ���� 
					HttpPostedFile postedFile = files[iFile];
					string fileName, fileExtension;
					fileName = System.IO.Path.GetFileName(postedFile.FileName);
					if (fileName != "")
					{
						fileExtension = System.IO.Path.GetExtension(fileName);
						if((postedFile.ContentType.ToString() == "application/vnd.ms-excel" || postedFile.ContentType.ToString() == "application/octet-stream")&& fileExtension == ".xls")
						{
							
							///ע�⣺����Ҫ�޸�����ļ��е�����д��Ȩ�ޡ�
							//							postedFile.SaveAs(System.Web.HttpContext.Current.Request.MapPath("employeelist/") + fileName);
							postedFile.SaveAs(System.Web.HttpContext.Current.Request.MapPath("/") + fileName);

							// ��ȡ��ʽ,д�����ݿ�
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
		/// ���ݲ�ͬExcel��ǩ �洢���������
		/// </summary>
		/// <param name="ds">Excel����</param>
		/// <param name="state">��ǩ �ؿһ���ԡ������</param>
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
					CI.Trouble_nb = dt.Rows[j][0].ToString();//���ϵ���

					opid = dt.Rows[j][1].ToString().Trim();//ҵ�����
					CI.Proposer = dt.Rows[j][2].ToString();//�ͻ�����
					CI.Complaints = dt.Rows[j][3].ToString();//�ͻ�Ͷ��

					//��������ʱ��
					if(dt.Rows[j][4].ToString().Trim()=="")
					{
						CI.Trouble_date = DateTime.Today.ToString("yyyy-MM-dd");
					}
					else
					{
						CI.Trouble_date = dt.Rows[j][4].ToString().Trim();
					}
					CI.Trouble_Describe = dt.Rows[j][5].ToString();//��������
					CI.ProposerPhone = dt.Rows[j][6].ToString();//�绰
					CI.Moveinfo = dt.Rows[j][8].ToString().Trim();//��ˮ��Ϣ
					CI.remark = dt.Rows[j][9].ToString().Trim();//��ע
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
			
			
			Response.Write("<script> alert('����"+i.ToString()+"����¼���!')</script>");			
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
