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
using AjaxPro;

namespace NrOA.TroubleDeal
{
	/// <summary>
	/// VeiwTB ��ժҪ˵����
	/// </summary>
	public class VeiwTB : System.Web.UI.Page
	{
		[AjaxMethod]
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			//AjaxPro.Utility.RegisterTypeForAjax(typeof(TroubleDeal));
			string str = "<frameset rows=\"0,*\" >";
			str += "<frame src=\"about:blank\" >";
			str += "<frame src=\"../select.aspx?\" >";
			Response.Write(str);
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
