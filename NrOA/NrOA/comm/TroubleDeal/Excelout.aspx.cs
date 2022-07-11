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
	/// Excelout 的摘要说明。
	/// </summary>
	public class Excelout : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button5;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button Button1;
		private IList list = null;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			try
			{
				list = (IList)Session.Contents["list"];
			}
			catch{}
			try
			{
				DataGrid1.PageSize = list.Count;
			}
			catch{}
			DataGrid1.DataSource = list;
			DataGrid1.DataBind();

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
			this.Button5.Click += new System.EventHandler(this.Button5_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button5_Click(object sender, System.EventArgs e)
		{
			Response.Clear();
			Response.Buffer=   true;
			Response.Charset="GB2312";
			Response.AppendHeader("Content-Disposition","attachment;filename=故障处理结果.xls");
			Response.ContentEncoding=System.Text.Encoding.GetEncoding("GB2312"); //设置输出流为简体中文
			Response.ContentType   =   "application/ms-excel"; //设置输出文件类型为excel文件。
			this.EnableViewState   =   false;
			System.Globalization.CultureInfo   myCItrad   =   new   System.Globalization.CultureInfo("ZH-CN",true); 
			System.IO.StringWriter   oStringWriter   =   new   System.IO.StringWriter(myCItrad);
			System.Web.UI.HtmlTextWriter   oHtmlTextWriter   =   new   System.Web.UI.HtmlTextWriter(oStringWriter);
			this.DataGrid1.RenderControl(oHtmlTextWriter); // 在这里设置保存那个数据源的数据.
			Response.Write(oStringWriter.ToString());
			Response.End();
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("TrbDList.aspx?state=end");
		}
	}
}
