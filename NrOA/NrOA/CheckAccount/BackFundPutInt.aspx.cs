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

namespace NrOA.CheckAccount
{
	/// <summary>
	/// BackFundPutInt ��ժҪ˵����
	/// </summary>
	public class BackFundPutInt : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button UploadButton;
		protected System.Web.UI.HtmlControls.HtmlInputHidden deptid;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DoWithFile(string path)
		{
			ImportData(ReadExcel(path, "�ؿ�"));
		}

		private void UploadButton_Click(object sender, System.EventArgs e)
		{
			string ss = "eee";
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
							postedFile.SaveAs(System.Web.HttpContext.Current.Request.MapPath("/") + fileName);

							// ��ȡ��ʽ,д�����ݿ�
							DoWithFile(System.Web.HttpContext.Current.Request.MapPath("/") + fileName);
						}
					}
				}
				//Label1.Text = strMsg.ToString();
				return true;
			}
			catch(System.Exception Ex)
			{
				//Label1.Text = Ex.Message;
				return false;
			}
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

		public int ImportData(DataSet ds)
		{
			int i = 0;
			Response.Write("<script> alert('����"+i.ToString()+"����¼���!')</script>");		
			return i;
		}
	}
}
