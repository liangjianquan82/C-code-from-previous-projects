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
	/// dao_t_yicixing 的摘要说明。
	/// </summary>
	public class dao_t_yicixing
	{
		public dao_t_yicixing()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 根据年月和编号查找一次性收款
		/// </summary>
		/// <param name="ty"></param>
		/// <returns></returns>
		public IList ycx_by_year_id(NrOA.CheckAccount.em.t_yicixing ty)
		{
			return Mapper.Instance().QueryForList("ycx_by_year_id",ty);
		}

		public IList ycx_notin_client(string year,string month,string sta)
		{
			NrOA.CheckAccount.em.t_yicixing ci = new NrOA.CheckAccount.em.t_yicixing();
			ci.t_year = year;
			ci.t_month = month;
			ci.usernb = "%"+sta+"%";
			IList list = null;
			if(month=="0"&&sta=="")
			{
				list =Mapper.Instance().QueryForList("ycx_notin_client1",ci);
			}
			else if(month!="0"&&sta=="")
			{
				list =Mapper.Instance().QueryForList("ycx_notin_client2",ci);
			}
			else if((month=="0"&&sta!=""))
			{
				list =Mapper.Instance().QueryForList("ycx_notin_client3",ci);
			}
			else if((month!="0"&&sta!=""))
			{
				list = Mapper.Instance().QueryForList("ycx_notin_client4",ci);
			}
			return list;
		}

		public void update_ycx(NrOA.CheckAccount.em.t_yicixing ci)
		{
			Mapper.Instance().Update("update_ycx",ci);
		}
	}
}
