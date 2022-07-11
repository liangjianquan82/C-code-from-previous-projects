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

namespace NrOA.CheckAccount.pkg
{
	/// <summary>
	/// dao_pay_info ��ժҪ˵����
	/// </summary>
	public class dao_pay_info
	{
		public dao_pay_info()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ����С��ȫ����ѯ��С�����AreaName�����yr��
		/// </summary>
		/// <param name="pi">��С�����AreaName�����yr��</param>
		/// <returns></returns>
		public IList Selectpay_info_byAreaName(NrOA.CheckAccount.em.pay_info pi)
		{
			return Mapper.Instance().QueryForList("Selectpay_info_byAreaName",pi);
		}

		/// <summary>
		/// �����û���ͨʱ���ѯ����yr,��start_mon-end_Month,С�����AreaName��
		/// </summary>
		/// <param name="pi">����yr,��mon,С�����AreaName��</param>
		/// <returns></returns>
		public IList Selectpay_info_byAreaName1(NrOA.CheckAccount.em.pay_info pi)
		{
			return Mapper.Instance().QueryForList("Selectpay_info_byAreaName1",pi);
		}

		/// <summary>
		/// ģ����ѯ��ģ����ϢClientName�����yr��
		/// </summary>
		/// <param name="pi">��ģ����ϢClientName�����yr��</param>
		/// <returns></returns>
		public IList Selectpay_infoByFind(NrOA.CheckAccount.em.pay_info pi)
		{
			return Mapper.Instance().QueryForList("Selectpay_infoByFind",pi);
		}
			
	}
}
