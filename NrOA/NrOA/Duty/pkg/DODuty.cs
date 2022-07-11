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

namespace NrOA.Duty.pkg
{
	/// <summary>
	/// DODuty ��ժҪ˵����
	/// </summary>
	public class DODuty
	{
		public DODuty()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ��ѯȫ��ְ��
		/// </summary>
		/// <returns></returns>

		public IList selectAllDuty()
		{
			return Mapper.Instance().QueryForList("selectAllDuty",null);
		}

		public IList select_Duty_id(string id)
		{
			return Mapper.Instance().QueryForList("select_Duty_id",id);
		}

		public void insertDuty(NrOA.Duty.em.Duty dy)
		{
			dy.Duty_ID = DutyMaxID();
			Mapper.Instance().Insert("insertDuty",dy);
		}
		public void updateDuty(NrOA.Duty.em.Duty dy)
		{
			Mapper.Instance().Update("updateDuty",dy);

		}

		/// <summary>
		/// ���������
		/// </summary>
		/// <returns></returns>
		public int DutyMaxID()
		{
			int id = -1;
			id = ((NrOA.Duty.em.Duty)(Mapper.Instance().QueryForList("DutyMaxID",null))[0]).Duty_ID+1;
			return id;
		}
	}
}
