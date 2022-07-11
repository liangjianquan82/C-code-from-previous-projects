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
using NrOA.TroubleDeal.em;

namespace NrOA.TroubleDeal.pkg
{
	/// <summary>
	/// DoTroubleDeal 的摘要说明。
	/// </summary>
	public class DoTroubleDeal
	{
		public DoTroubleDeal()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 新增导入的故障信息
		/// </summary>
		/// <param name="td"></param>
		public void insertTroubleDealDR(NrOA.TroubleDeal.em.TroubleDeal td)
		{
			Mapper.Instance().Insert("insertTroubleDealDR",td);
		}

		/// <summary>
		/// 根据下列条件查询故障单列表
		/// </summary>
		/// <param name="state">状态</param>
		/// <param name="str">模糊查询</param>
		/// <param name="startmonth">开始日期</param>
		/// <param name="endmonth">结束日期</param>
		/// <returns></returns>
		public IList selectTrblist(string state,string str,string staDate,string endDate,string type)
		{
			NrOA.TroubleDeal.em.TroubleDeal td = new NrOA.TroubleDeal.em.TroubleDeal();
			IList list = null;

			td.startmonth = DateTime.Parse(staDate).ToString("yyyy-MM-dd 00:00:00");
			td.endmonth = DateTime.Parse(endDate).ToString("yyyy-MM-dd 23:59:59");
			td.state = state;
			if(type!="All")
			{
				if(str!=""&&type!="0")
				{
					td.Proposer = "%"+str+"%";
					td.Trouble_nb = type+"%";
					if(type!="WT")
					{
						list =  Mapper.Instance().QueryForList("selectTrblist_str2",td);
					}
					else
					{
						list =  Mapper.Instance().QueryForList("selectTrblist_str22",td);
					}
				}
				else if(str!=""&&type=="0")
				{
					td.Proposer = "%"+str+"%";
					list = Mapper.Instance().QueryForList("selectTrblist_str",td);
				}
				else if(str==""&&type!="0")
				{
					td.Trouble_nb = type+"%";
					if(type!="WT")
					{
						list =  Mapper.Instance().QueryForList("selectTrblist_str1",td);
					}
					else
					{
						list =  Mapper.Instance().QueryForList("selectTrblist_str11",td);
					}
				}
				else
				{
					list = Mapper.Instance().QueryForList("selectTrblist",td);
				}
			}
			else
			{
				if(str!="")
				{
					list = Mapper.Instance().QueryForList("SelectAllTB",td);
				}
				else
				{
					list = Mapper.Instance().QueryForList("SelectAllTB1",td);
				}
			}
			return list;
			
		}

		/// <summary>
		/// 根据编号删除
		/// </summary>
		/// <param name="id">编号</param>
		public void deleteTrbinfo(string id)
		{
			Mapper.Instance().Delete("deleteTrbinfo",id);
		}
		/// <summary>
		/// 根据编号查询故障信息
		/// </summary>
		/// <param name="id">编号</param>
		/// <returns></returns>
		public IList selectTrbid(string id)
		{
			return Mapper.Instance().QueryForList("selectTrbid",id);
		}
		/// <summary>
		/// 更新故障单
		/// </summary>
		/// <param name="td"></param>
		public void UpdateTrbinfo(NrOA.TroubleDeal.em.TroubleDeal td)
		{
			Mapper.Instance().Update("UpdateTrbinfo",td);
		}
		public void insertTrbinfo(NrOA.TroubleDeal.em.TroubleDeal td,string tou)
		{
			td.Trouble_nb = MaxTrouble_nb(tou);
			Mapper.Instance().Insert("insertTrbinfo",td);
		}
		/// <summary>
		/// 根据故障单号选择
		/// </summary>
		/// <param name="Trouble_nb"></param>
		/// <returns></returns>
		public IList selectTrouble_nb(string Trouble_nb)
		{
			return Mapper.Instance().QueryForList("selectTrouble_nb",Trouble_nb);
		}
		/// <summary>
		/// 获取最大编号
		/// </summary>
		/// <param name="tou"></param>
		/// <returns></returns>
		public string MaxTrouble_nb(string tou)
		{
			string s = tou+"%";
			IList list = null;
			list = Mapper.Instance().QueryForList("MaxTrouble_nb",s);
			string Max_nb = "";
			string m = "";
			string m1 = "";
			try
			{
				Max_nb = ((NrOA.TroubleDeal.em.TroubleDeal)(list)[0]).Trouble_nb.Substring(2);
			}
			catch
			{
				Max_nb = "0000000000";
			}
			try
			{
				m = Max_nb.Substring(8);
				m1= Max_nb.Substring(0,8);
			}
			catch{}
			int date = int.Parse(DateTime.Today.ToString("yyyyMMdd"));
			int sum = 0;
			if(m!="")
			{
				if(m1==DateTime.Today.ToString("yyyyMMdd"))
				{
					sum = int.Parse(m)+1;
				}
				else
				{
					sum = 1;
				}
			}
			else
			{
				sum = 1;
			}
			
			Max_nb = tou+date.ToString()+sum.ToString();
			return Max_nb;
		}
		/// <summary>
		/// 根据记录日期删除
		/// </summary>
		/// <param name="date"></param>
		public void deleteTrbinfo_by_RDate(string date)
		{
			date = "%"+date+"%";
			Mapper.Instance().Delete("deleteTrbinfo_by_RDate",date);
		}
	}
}
