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
	/// Excelout ��ժҪ˵����
	/// </summary>
	public class Excelout : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button5;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button Button1;
		private IList list = null;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
			Response.AppendHeader("Content-Disposition","attachment;filename=���ϴ�����.xls");
			Response.ContentEncoding=System.Text.Encoding.GetEncoding("GB2312"); //���������Ϊ��������
			Response.ContentType   =   "application/ms-excel"; //��������ļ�����Ϊexcel�ļ���
			this.EnableViewState   =   false;
			System.Globalization.CultureInfo   myCItrad   =   new   System.Globalization.CultureInfo("ZH-CN",true); 
			System.IO.StringWriter   oStringWriter   =   new   System.IO.StringWriter(myCItrad);
			System.Web.UI.HtmlTextWriter   oHtmlTextWriter   =   new   System.Web.UI.HtmlTextWriter(oStringWriter);
			this.DataGrid1.RenderControl(oHtmlTextWriter); // ���������ñ����Ǹ�����Դ������.
			Response.Write(oStringWriter.ToString());
			Response.End();
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("TrbDList.aspx?state=end");
		}
	}
}
