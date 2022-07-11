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
	/// DOClient ��ժҪ˵����
	/// </summary>
	public class DOClient
	{
		public DOClient()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ȫ���û�
		/// </summary>
		/// <returns></returns>
		public IList SelectAllClient()
		{
			return Mapper.Instance().QueryForList("SelectAllClient",null);
		}

		/// <summary>
		/// ����С�����Ʋ�ѯ�û��б�
		/// </summary>
		/// <param name="AreaName"></param>
		/// <returns></returns>
		public IList SelectClient_byAreaName(string AreaName)
		{
			return Mapper.Instance().QueryForList("SelectClient_byAreaName",AreaName);
		}

		/// <summary>
		/// ����С�����Ʋ�ѯ�û��б�
		/// </summary>
		/// <param name="AreaName"></param>
		/// <param name="state"></param>
		/// <param name="year"></param>
		/// <param name="sta_month"></param>
		/// <param name="end_month"></param>
		/// <returns></returns>
		public IList SelectClient_byAreaName(string AreaName,string state,string year,string sta_month,string end_month)
		{

			NrOA.Client.em.Client cl = new NrOA.Client.em.Client();
			cl.ClientState = state;
			cl.AreaName = AreaName;
			cl.Year = year;
			if(int.Parse(sta_month)>9)
			{
				cl.startMonth = sta_month;
			}
			else
			{
				cl.startMonth = "0"+sta_month;
			}
			if(int.Parse(end_month)>9)
			{
				cl.endMonth = end_month;
			}
			else
			{
				cl.endMonth = "0"+end_month;
			}
			return Mapper.Instance().QueryForList("SelectClient_byAreaName1",cl);
		}
		public IList SelectClient_byAreaName1(string AreaName,string state,string year,string sta_month,string end_month)
		{

			NrOA.Client.em.Client cl = new NrOA.Client.em.Client();
			cl.ClientState = state;
			cl.AreaName = AreaName;
			cl.Year = year;
			if(int.Parse(sta_month)>9)
			{
				cl.startMonth = sta_month;
			}
			else
			{
				cl.startMonth = "0"+sta_month;
			}
			if(int.Parse(end_month)>9)
			{
				cl.endMonth = end_month;
			}
			else
			{
				cl.endMonth = "0"+end_month;
			}
			return Mapper.Instance().QueryForList("SelectClient_byAreaName2",cl);
		}
		/// <summary>
		/// ����������Ϣģ����ѯ�ͻ���Ϣ
		/// </summary>
		/// <param name="NameOrId">�����ѯ��Ϣ</param>
		/// <returns></returns>
		public IList SelectClientByFind(string NameOrId)
		{
			NameOrId = "%"+NameOrId+"%";
			return Mapper.Instance().QueryForList("SelectClientByFind",NameOrId);
		}
		/// <summary>
		/// ģ����ѯȫ��С��
		/// </summary>
		/// <param name="NameOrId">��ѯ�ֶ�</param>
		/// <param name="state">״̬</param>
		/// <returns></returns>
		public IList SelectClientByFind(string NameOrId,string state)
		{
			NrOA.Client.em.Client cl = new NrOA.Client.em.Client();
			cl.ClientName = "%"+NameOrId+"%";
			cl.ClientState = state;
			return Mapper.Instance().QueryForList("SelectClientByFind",cl);
		}
		/// <summary>
		/// ģ����ѯ���С��
		/// </summary>
		/// <param name="NameOrId">��ѯ�ֶ�</param>
		/// <param name="state">״̬</param>
		/// <param name="AreaName">С�����</param>
		/// <returns></returns>
		public IList SelectClientByFind(string NameOrId,string state,string AreaName)
		{
			NrOA.Client.em.Client cl = new NrOA.Client.em.Client();
			cl.ClientName = "%"+NameOrId+"%";
			cl.ClientState = state;
			cl.AreaName = AreaName;
			return Mapper.Instance().QueryForList("SelectClientByFind1",cl);
		}

		/// <summary>
		/// ���ӿͻ���Ϣ
		/// </summary>
		/// <param name="CI"></param>
		public void InsertClientList(NrOA.Client.em.Client CI)
		{			
			Mapper.Instance().Insert("InsertClientList",CI);			
		}
		/// <summary>
		/// ���¿ͻ���Ϣ
		/// </summary>
		/// <param name="CI"></param>
		public void updateClientList(NrOA.Client.em.Client CI)
		{			
			Mapper.Instance().Update("updateClientList",CI);			
		}
		/// <summary>
		/// ���ݱ�Ų�ѯ�ͻ���Ϣ
		/// </summary>
		/// <param name="id">�ͻ����</param>
		public IList SelectClient_by_id(int id)
		{
			return Mapper.Instance().QueryForList("SelectClient_by_id",id);
		}
		/// <summary>
		/// ���¿ͻ�״̬
		/// </summary>
		/// <param name="CI"></param>
		public void upateClientstate(NrOA.Client.em.Client CI)
		{
			Mapper.Instance().Update("upateClientstate",CI);
		}
		/// <summary>
		/// ���ݿͻ�ҵ��Ų�ѯ�ͻ���Ϣ
		/// </summary>
		/// <param name="opid"></param>
		/// <returns></returns>
		public IList selectClient_by_opid(string opid)
		{
			return Mapper.Instance().QueryForList("selectClient_by_opid",opid);
		}
		/// <summary>
		/// ����С����ȡ��С��������
		/// </summary>
		/// <param name="Area_id">С�����</param>
		/// <returns></returns>
		public string selectClient_Arae_by_MaxClistid(string Area_id)
		{
			IList list = null;
			list = Mapper.Instance().QueryForList("selectClient_Arae_by_MaxClistid",Area_id);
			string ss = ((NrOA.Client.em.Client)(list)[0]).ClientListID;
			int sum = 0;
			if(ss == null)
			{
				sum = 0;
			}
			else
			{
				sum = int.Parse(((NrOA.Client.em.Client)(list)[0]).ClientListID.ToString().Trim());
			}
			sum = sum+1;
			return sum.ToString();
		}
		/// <summary>
		/// ���ݱ��ɾ���û�
		/// </summary>
		/// <param name="id"></param>
		public void deleteClient_by_id(string id)
		{
			Mapper.Instance().Delete("deleteClient_by_id",id);
		}
		/// <summary>
		/// ����Ϊ��
		/// </summary>
		/// <returns></returns>
		public IList selecjgwk()
		{
			return Mapper.Instance().QueryForList("selecjgwk",null);
		}
		/// <summary>
		/// ����״̬��ѯ�û��б�
		/// </summary>
		/// <param name="state"></param>
		/// <returns></returns>
		public IList Client_by_state(string state)
		{
			return Mapper.Instance().QueryForList("Client_by_state",state);
		}
	}
}
