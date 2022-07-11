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
using NrOA.Area.em;

namespace NrOA.Area.pkg
{
	/// <summary>
	/// DOArea ��ժҪ˵����
	/// </summary>
	public class DOArea
	{
		public DOArea()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ���������
		/// </summary>
		/// <returns></returns>
		public int AreaMaxID()
		{
			int id = -1;
			id = ((NrOA.Area.em.Area)(Mapper.Instance().QueryForList("AreaMaxID",null))[0]).Area_ID+1;
			return id;
		}
		/// <summary>
		/// ��ѯȫ��δע��С��
		/// </summary>
		/// <returns></returns>
		public IList SelectAreaAll_LoginIn(string Area_state)
		{
			return Mapper.Instance().QueryForList("SelectAreaAll_LoginIn1",Area_state);
		}
		/// <summary>
		/// ��ѯȫ��δע��С��
		/// </summary>
		/// <returns></returns>
		public IList SelectAreaAll_LoginIn()
		{
			return Mapper.Instance().QueryForList("SelectAreaAll_LoginIn",null);
		}
		/// <summary>
		/// ��ѯȫ��δע��С��(�������)
		/// </summary>
		/// <returns></returns>
		public IList SelectAreaAll()
		{
			return Mapper.Instance().QueryForList("SelectAreaAll",null);
		}

		/// <summary>
		/// ����С�����ѡ��С����Ϣ
		/// </summary>
		/// <param name="Area_ID">С�����</param>
		/// <returns></returns>
		public IList SelectArea_By_ID(int Area_ID)
		{
			return Mapper.Instance().QueryForList("SelectArea_By_ID",Area_ID);
		}
		/// <summary>
		/// �ı�С����״̬
		/// </summary>
		/// <param name="Ar">С����Ϣ</param>
		public void Area_State_Change(NrOA.Area.em.Area Ar)
		{
			Mapper.Instance().Update("Area_State_Change",Ar);
		}
		/// <summary>
		/// ����С����Ϣ
		/// </summary>
		/// <param name="Ar">С����Ϣ</param>
		public void InsertAreaInfo(NrOA.Area.em.Area Ar)
		{
			Ar.Area_ID = AreaMaxID();
			Mapper.Instance().Insert("InsertAreaInfo",Ar);
		}
		/// <summary>
		/// ����С����Ϣ
		/// </summary>
		/// <param name="Ar"></param>
		public void Update_AreaInfo(NrOA.Area.em.Area Ar)
		{
			Mapper.Instance().Update("Update_AreaInfo",Ar);
		}
	}
}
