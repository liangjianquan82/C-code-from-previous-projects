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
	/// dao_t_huikuan 的摘要说明。
	/// </summary>
	public class dao_t_huikuan
	{
		public dao_t_huikuan()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public IList min_year()
		{
			return Mapper.Instance().QueryForList("min_year",null);
		}
		/// <summary>
		/// 根据年月，用户号查询使用费信息
		/// </summary>
		/// <param name="hk"></param>
		/// <returns></returns>
		public IList hu_by_year_id(NrOA.CheckAccount.em.t_huikuan hk)
		{
			return Mapper.Instance().QueryForList("hu_by_year_id",hk);
		}

		public IList hk_notin_client(string year,string month,string sta)
		{
			NrOA.CheckAccount.em.t_huikuan ci = new NrOA.CheckAccount.em.t_huikuan();
			ci.t_year = year;
			ci.t_month = month;
			ci.usernb = "%"+sta+"%";
			IList list = null;
			if(month=="0"&&sta=="")
			{
				list =Mapper.Instance().QueryForList("hk_notin_client1",ci);
			}
			else if(month!="0"&&sta=="")
			{
				list =Mapper.Instance().QueryForList("hk_notin_client2",ci);
			}
			else if((month=="0"&&sta!=""))
			{
				list =Mapper.Instance().QueryForList("hk_notin_client3",ci);
			}
			else if((month!="0"&&sta!=""))
			{
				list = Mapper.Instance().QueryForList("hk_notin_client4",ci);
			}
			return list;
		}
		public void update_hk(NrOA.CheckAccount.em.t_huikuan hk)
		{
			Mapper.Instance().Update("update_hk",hk);
		}
	}
}
