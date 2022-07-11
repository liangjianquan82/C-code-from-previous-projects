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
using NrOA.Affiche.em;

namespace NrOA.Affiche.pkg
{
	/// <summary>
	/// DOaffiche ��ժҪ˵����
	/// </summary>
	public class DOaffiche
	{
		public DOaffiche()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ����״̬��ѯ����
		/// </summary>
		/// <param name="state">0-δ������1-����</param>
		/// <returns></returns>
		public IList SelectAffiche_state(string state)
		{
			if(state=="-1")
			{
				return SelectAfficheAll();
			}
			else
			{
				return Mapper.Instance().QueryForList("SelectAffiche_state",state);
			}
		}

		/// <summary>
		/// ��ѯȫ������
		/// </summary>
		/// <returns></returns>
		public IList SelectAfficheAll()
		{
			return Mapper.Instance().QueryForList("SelectAfficheAll",null);
		}
		/// <summary>
		/// ���ݱ�Ų�ѯ����
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public IList SelectAffiche_By_ID(int id)
		{
			return Mapper.Instance().QueryForList("SelectAffiche_By_ID",id);
		}
		/// <summary>
		/// ���¹���״̬
		/// </summary>
		/// <param name="af"></param>
		public void Affiche_State_Change(Affiche.em.affiche af)
		{
			Mapper.Instance().Update("Affiche_State_Change",af);
		}
		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="af"></param>
		public void InsertafficheInfo(Affiche.em.affiche af)
		{
			Mapper.Instance().Insert("InsertafficheInfo",af);
		}
		/// <summary>
		/// ���¹�������
		/// </summary>
		/// <param name="af"></param>
		public void Update_afficheInfo(Affiche.em.affiche af)
		{
			Mapper.Instance().Update("Update_AreaInfo",af);
		}
		/// <summary>
		/// ɾ������
		/// </summary>
		/// <param name="id"></param>
		public void delete_afficheInfo(int id)
		{
			Mapper.Instance().Delete("delete_afficheInfo",id);
		}
	}
}
