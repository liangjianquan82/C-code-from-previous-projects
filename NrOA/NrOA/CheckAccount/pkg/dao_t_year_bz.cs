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
	/// dao_t_year_bz 的摘要说明。
	/// </summary>
	public class dao_t_year_bz
	{
		public dao_t_year_bz()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void insert_t_year_bz(NrOA.CheckAccount.em.t_year_bz tyb)
		{
			Mapper.Instance().Insert("insert_t_year_bz",tyb);
		}
		public void update_t_year_bz_by_year_userid(NrOA.CheckAccount.em.t_year_bz tyb)
		{
			Mapper.Instance().Update("update_t_year_bz_by_year_userid",tyb);
		}
		public IList select_t_year_bz_by_year_userid(NrOA.CheckAccount.em.t_year_bz tyb)
		{
			return Mapper.Instance().QueryForList("select_t_year_bz_by_year_userid",tyb);
		}

	}
}
