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
	/// BackFundPutInt 的摘要说明。
	/// </summary>
	public class BackFundPutInt : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button UploadButton;
		protected System.Web.UI.HtmlControls.HtmlInputHidden deptid;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DoWithFile(string path)
		{
			ImportData(ReadExcel(path, "回款"));
		}

		private void UploadButton_Click(object sender, System.EventArgs e)
		{
			string ss = "eee";
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
							postedFile.SaveAs(System.Web.HttpContext.Current.Request.MapPath("/") + fileName);

							// 读取格式,写入数据库
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
			Response.Write("<script> alert('导入"+i.ToString()+"条记录完成!')</script>");		
			return i;
		}
	}
}
