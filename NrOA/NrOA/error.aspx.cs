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
	/// error ��ժҪ˵����
	/// </summary>
	public class error : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		NrOA.Client.pkg.DOClient dc = new NrOA.Client.pkg.DOClient();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			NrOA.CheckAccount.pkg.DOBackFundInfo dci = new NrOA.CheckAccount.pkg.DOBackFundInfo();
			dci.hkinfo("1982043919820530","2008","1","���");
			string value1 = dci.Value;
			string pd1 = dci.Poundage;

			dci.hkinfo("1982043919820530","2008","1","�½�");
			string value2 = dci.Value;
			string pd2 = dci.Poundage;
			 getdata();
			
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

		private void getdata()
		{
			IList list = null;
			list = dc.SelectAllClient();
			string date ="";
			string cid ="";
			string runyear = "";
			string runmonth = "";
			DataTable dt = new DataTable();
			dt.Columns.Add("ClientOperationID");
			dt.Columns.Add("Clientname");
			dt.Columns.Add("runyear");
			dt.Columns.Add("runmonth");
			for(int i=0;i<list.Count;i++)
			{

				DataRow dr = dt.NewRow();
				cid = ((NrOA.Client.em.Client)(list)[i]).ClientOperationID;
				try
				{
					date = ((NrOA.Client.em.Client)(list)[i]).RunDate;
				}
				catch
				{
					date = "2008-1-1";
				}
				dr["ClientOperationID"] = cid;
				dr["Clientname"] = ((NrOA.Client.em.Client)(list)[i]).ClientName;
				date = "-"+DateTime.Parse(date).ToString("yyyy-MM");
				string []dates = date.Split('-');
				for(int n=0;n<dates.Length;n++)
				{
					if(n==1)
					{
						runyear =  dates.GetValue(n).ToString();
						dr["runyear"] = runyear;
					}
					else if(n==2)
					{
						runmonth =  dates.GetValue(n).ToString();
						dr["runmonth"] = runmonth;
					}
				}
				dt.Rows.Add(dr);
			}
			

			DataGrid1.DataSource = dt;
			DataGrid1.DataBind();
		}

	}
}
