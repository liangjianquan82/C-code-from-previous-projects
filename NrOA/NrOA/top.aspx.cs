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

namespace NrOA
{
	/// <summary>
	/// top ��ժҪ˵����
	/// </summary>
	public class top : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label strUserName;
		protected System.Web.UI.WebControls.Label SessNum;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl lbWarn;

		Hashtable hast=null;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			lbWarn.InnerText = "��ӭʹ��ŵ��칫ϵͳ";

			//��ȡsession��Ϣ
			hast = (Hashtable)Session["userinfo"];

			//��ӭ�û���
			strUserName.Text = hast["EmployeeName"].ToString();
			//��������
			try
			{
				SessNum.Text = Page.Application["count"].ToString();
			}
			catch{}
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
