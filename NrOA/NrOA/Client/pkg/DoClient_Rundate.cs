using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.UI.HtmlControls;

using System.Collections;


using IBatisNet.DataMapper;
using IBatisNet.Common;
using NrOA.Client.em;

namespace NrOA.Client.pkg
{
	/// <summary>
	/// DoClient_Rundate ��ժҪ˵����
	/// </summary>
	public class DoClient_Rundate
	{
		public DoClient_Rundate()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		NrOA.Client.pkg.DOClient dc = new NrOA.Client.pkg.DOClient();
		NrOA.Client.em.Client_Rundate CR = new NrOA.Client.em.Client_Rundate();
		public IList selectClient_Rundate(int Client_ID)
		{
			return Mapper.Instance().QueryForList("selectClient_Rundate",Client_ID);
		}

		/// <summary>
		/// ����
		/// </summary>
		/// <param name="cr"></param>
		public void addClient_Rundate(NrOA.Client.em.Client_Rundate cr)
		{
            Mapper.Instance().Insert("addClient_Rundate",cr);
		}
		/// <summary>
		/// ����
		/// </summary>
		/// <param name="cr"></param>
		public void updateClient_Rundate(NrOA.Client.em.Client_Rundate cr)
		{
			Mapper.Instance().Update("updateClient_Rundate",cr);
		}
		/// <summary>
		/// ������������������
		/// </summary>
		public void Add_Update_Client_Rundate()
		{
			//��ȡû��ע�����û���Ϣ
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
			dt.Columns.Add("Client_id");
			dt.Columns.Add("area_id");
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
				dr["Client_id"] = ((NrOA.Client.em.Client)(list)[i]).Client_ID;
				dr["area_id"] = ((NrOA.Client.em.Client)(list)[i]).AreaName;
				try
				{
					date = "-"+DateTime.Parse(date).ToString("yyyy-MM");
				}
				catch{date ="-"+DateTime.Now.Year.ToString("yyyy")+"-01"; }
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
			for(int i=0;i<dt.Rows.Count;i++)
			{
				CR.Client_ID = int.Parse(dt.Rows[i]["Client_id"].ToString());
				CR.ClientOperationID = dt.Rows[i]["ClientOperationID"].ToString();
				CR.Runyear = dt.Rows[i]["runyear"].ToString();
				CR.Runmonth = dt.Rows[i]["runmonth"].ToString();
				CR.area_id = dt.Rows[i]["area_id"].ToString();

				delete_Client_Rundate(CR.ClientOperationID);
				IList list1 = null; 
				try
				{
					list1 = this.selectClient_Rundate(CR.Client_ID);
				}
				catch{list1 = null; }
				if(CR.ClientOperationID=="19820108701")
				{
					string s=  CR.ClientOperationID;
				}
				if(list1!=null)
				{
					if(list1.Count>0)
					{
						this.updateClient_Rundate(CR);
					}
					else
					{
						this.addClient_Rundate(CR);
					}
				}
			}
		}

		/// <summary>
		/// ����ҵ��Ų�ѯ
		/// </summary>
		/// <param name="ClientOperationID">ҵ���</param>
		/// <returns></returns>
		public IList selectClient_Rundate_by_ClientOperationID(string ClientOperationID)
		{
			return Mapper.Instance().QueryForList("selectClient_Rundate_by_ClientOperationID",ClientOperationID);
		}
		public void delete_Client_Rundate(string ClientOperationID)
		{
			Mapper.Instance().Delete("delete_Client_Rundate",ClientOperationID);
		}
	}
}
