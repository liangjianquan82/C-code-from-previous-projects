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
	/// dao_pay_info 的摘要说明。
	/// </summary>
	public class dao_pay_info
	{
		public dao_pay_info()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 根据小区全部查询（小区编号AreaName，年份yr）
		/// </summary>
		/// <param name="pi">（小区编号AreaName，年份yr）</param>
		/// <returns></returns>
		public IList Selectpay_info_byAreaName(NrOA.CheckAccount.em.pay_info pi)
		{
			return Mapper.Instance().QueryForList("Selectpay_info_byAreaName",pi);
		}

		/// <summary>
		/// 根据用户开通时间查询（年yr,月start_mon-end_Month,小区编号AreaName）
		/// </summary>
		/// <param name="pi">（年yr,月mon,小区编号AreaName）</param>
		/// <returns></returns>
		public IList Selectpay_info_byAreaName1(NrOA.CheckAccount.em.pay_info pi)
		{
			return Mapper.Instance().QueryForList("Selectpay_info_byAreaName1",pi);
		}

		/// <summary>
		/// 模糊查询（模糊信息ClientName，年份yr）
		/// </summary>
		/// <param name="pi">（模糊信息ClientName，年份yr）</param>
		/// <returns></returns>
		public IList Selectpay_infoByFind(NrOA.CheckAccount.em.pay_info pi)
		{
			return Mapper.Instance().QueryForList("Selectpay_infoByFind",pi);
		}
			
	}
}
