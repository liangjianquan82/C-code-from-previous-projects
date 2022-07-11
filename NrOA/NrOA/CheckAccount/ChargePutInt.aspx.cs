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
	/// ChargePutInt ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
			btnFirst.Text = "����ҳ";
			btnPrev.Text = "ǰһҳ";
			btnNext.Text = "��һҳ";
			btnLast.Text = "���ҳ";
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


			if(DropDownList3.SelectedValue=="-ѡ�����-"||DropDownList2.SelectedValue=="-ѡ���·�-")
			{
				UploadButton.Attributes.Add("onclick","javascript: return ischeck()");
			}
			else
			{
				UploadButton.Attributes.Add("onclick", "javascript: return confirm('�������ݽ������м��,ȷ��������')");
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
			lblCurrentIndex.Text = "�� " + (DataGrid1.CurrentPageIndex + 1).ToString() + " ҳ";
			lblPageCount.Text = "�ܹ� " +count.ToString() + " ����¼ �� " +DataGrid1.PageCount.ToString() + " ҳ";
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
//			ImportData(ReadExcel(path, "Sheet1"));
//			ImportData(ReadExcel(path, "����С��"));
			try
			{
				ImportData(ReadExcel(path, "�ؿ�"),"�ؿ�");
			}
			catch(System.Exception Ex){Label1.Text = Ex.Message;}
			try
			{
				ImportData(ReadExcel(path, "һ����"),"һ����");
			}
			catch(System.Exception Ex){Label1.Text = Ex.Message;}

			try
			{
				ImportData(ReadExcel(path, "�����"),"�����");
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
			string mystring = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = "+Server.MapPath("../����.xls")+";Extended Properties=Excel 8.0";
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
		public int ImportData(DataSet ds,string state)
		{
			NrOA.CheckAccount.em.ChargeInfo CI = new ChargeInfo();
			NrOA.CheckAccount.em.BackFundInfo bfi = new BackFundInfo();
			NrOA.CheckAccount.pkg.DOChargeInfo doci = new NrOA.CheckAccount.pkg.DOChargeInfo();
			NrOA.CheckAccount.pkg.DOBackFundInfo dobfi = new NrOA.CheckAccount.pkg.DOBackFundInfo();
			int i = 0;
			DataTable dt=ds.Tables[0];	
			if(state=="һ����")
			{
				for (int j = 0; j < dt.Rows.Count; j++)
				{
					if(dt.Rows[j][1].ToString() == "")  
						continue;
					

					CI.ClientName = dt.Rows[j][1].ToString();//�ͻ�����

					CI.ClientOperationID = dt.Rows[j][2].ToString();//�ͻ�ҵ���

					CI.Now_Poundage = now_Poundage(dt.Rows[j][3].ToString());//�ֳɱ���

					if(Move_or_Connect(dt.Rows[j][7].ToString())=="�����")
					{
						CI.OneOffConnectFees = dt.Rows[j][6].ToString();//�����
						CI.MovePay = "0";
					}
					else if(Move_or_Connect(dt.Rows[j][7].ToString())=="Ǩ�Ʒ�")
					{
						CI.MovePay = dt.Rows[j][6].ToString();//�����
						CI.OneOffConnectFees = "0";
					}					

					CI.Payment_by_Year = DropDownList3.SelectedValue.ToString();

					CI.Payment_by_Month = DropDownList2.SelectedValue.ToString();

					CI.RegisterMane = ht["EmployeeName"].ToString();

					doci.AddOneOffConnectFeesList(CI);

					i++;   
				}
			}
			else if(state=="�����")
			{
				for (int j = 0; j < dt.Rows.Count; j++)
				{
					if(dt.Rows[j][1].ToString() == "")  
						continue;
					
					
					CI.ClientName = dt.Rows[j][1].ToString();//�ͻ�����

					CI.ClientOperationID = dt.Rows[j][2].ToString();//ҵ�����

					CI.Now_Poundage = now_Poundage(dt.Rows[j][3].ToString());//�ֳɱ���

					CI.FirstPayment = dt.Rows[j][6].ToString();//������	
				
					CI.PaymentYear = dt.Rows[j][6].ToString();//������

					CI.Payment_by_Year = DropDownList3.SelectedValue.ToString();//��Ӧ�ɷ���

					CI.Payment_by_Month = DropDownList2.SelectedValue.ToString();//��Ӧ�ɷ���

					CI.RegisterMane = ht["EmployeeName"].ToString();//��ǰ�û�

					//�ײͷ��� �ж��� �ɷ�һ�� ���ǽɷ�����
					
					if(CI.FirstPayment=="480"||CI.FirstPayment=="540"||CI.FirstPayment=="600"||CI.FirstPayment=="540"||CI.FirstPayment=="1080")
					{
						int year = int.Parse(CI.Payment_by_Year)+1;
						CI.UseCyc = year.ToString()+"-"+CI.Payment_by_Month;
					}
					else
					{
					}
					//�ȶ� �û���Ϣ����Чʱ�� Ȼ���Ӧ�� ���� ʹ����Ч��

					//�ж� ����ǵ�һ�� ����� ���Կͻ���Ϣ�� ʹ����Ч��Ϊ���ε� ��Ч��

					//���� ���ݻؿ� �����Ϣ �е� ʹ����Ч���� ȷ�� ʹ����Ч�ڵ�ʱ��

					doci.FirstPaymentList(CI);

					i++;   
				}
			}
			else if(state=="�ؿ�")
			{
				for (int j = 0; j < dt.Rows.Count; j++)
				{
					if(dt.Rows[j][1].ToString() == "")  
						continue;	
					
					bfi.ClientName = dt.Rows[j][1].ToString();//�ͻ�����

					bfi.ClientOperationID = dt.Rows[j][2].ToString();//�ͻ�ҵ���

					bfi.Now_Poundage = now_Poundage(dt.Rows[j][3].ToString());	//�ֳɱ���							

					bfi.BackFund = dt.Rows[j][6].ToString();//�ؿ�

					bfi.BackFund_Year = DropDownList3.SelectedValue.ToString();//�ؿ����

					bfi.BackFund_Month = DropDownList2.SelectedValue.ToString();//�ؿ��·�

					bfi.RegisterMane = ht["EmployeeName"].ToString();

					//��¼�ؿ���Ϣ
					dobfi.BackFundInfoList(bfi);

					//�����շ���Ϣ
					CI.ClientName = dt.Rows[j][1].ToString();//�ͻ�����

					CI.ClientOperationID = dt.Rows[j][2].ToString();//ҵ�����

					CI.Now_Poundage = now_Poundage(dt.Rows[j][3].ToString());//�ֳɱ���
				
					CI.PaymentMonth = dt.Rows[j][6].ToString();//�½����

					CI.Payment_by_Year = DropDownList3.SelectedValue.ToString();//��Ӧ�ɷ���

					CI.Payment_by_Month = DropDownList2.SelectedValue.ToString();//��Ӧ�ɷ���

					CI.RegisterMane = ht["EmployeeName"].ToString();//��ǰ�û�

					int month = int.Parse(CI.Payment_by_Month)+1;

					CI.UseCyc = CI.Payment_by_Year +"-"+month.ToString();

					doci.BackMonthPay(CI);

					i++;   
				}
			}

			
			Response.Write("<script> alert('����"+i.ToString()+"����¼���!')</script>");

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
		/// �����ַ��� ���� �ֳɱ���
		/// </summary>
		/// <param name="Now_Poundage">�ֳɱ����ַ���</param>
		/// <returns>���� �ֳɱ���</returns>
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
			if(Move_or_Connect.IndexOf("�����")>-1)
			{
				return "�����";
			}
			else if(Move_or_Connect.IndexOf("���Ϸ�")>-1)
			{
				return "Ǩ�Ʒ�";
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
			// �����û���Ϣ
			this.SaveFile();
			// �����û���Ϣ����T_ChargeCollect��
			//this.putint_T_ChargeCollect();
			
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			//ɾ����Ӧ���µĻ����Ϣ
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
		/// ������»ؿ�����
		/// </summary>
		private void putint_T_ChargeCollect()
		{
			//��ѯȫ�����û�����Ӧ�������
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
//					//�����û��ţ���ݲ�ѯ�Ƿ��Ѿ�����
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
//						if(ClientintChargellist.Count>0)//��������¶�Ӧ�µ����ݡ�
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
//						else//���������һ����Ӧ�ÿͻ�����
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
			//��ѯ��ע���û�
			NrOA.Client.pkg.DOClient dc = new NrOA.Client.pkg.DOClient();
			NrOA.Client.pkg.DoClient_Rundate dcr = new NrOA.Client.pkg.DoClient_Rundate();
			NrOA.CheckAccount.pkg.DOChargeInfo dci = new NrOA.CheckAccount.pkg.DOChargeInfo();
			IList list = null;
			list = dc.Client_by_state("1");
			if(list!=null)
			{
				if(list.Count>0)
				{
					//��ѯT_Client_Rundate��T_ChargeCollect
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
