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
	/// DealChargeTable 的摘要说明。
	/// </summary>
	public class DealChargeTable
	{
		public DealChargeTable()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 根据当前 年月 列出未回款用户表
		/// </summary>
		/// <param name="year">年份</param>
		/// <param name="month">月份</param>
		/// <returns>未回款用户表</returns>
		public DataTable NotPayMoneyClient(string year,string month)
		{

			//查询所有 已经回款用户列表 （包括年结款 和 回款 ）t1

			//查询 现有用户t2

			//比较 t1.t2 筛选出 没有 缴款信息的 用户 作为 Table

			//将Table用户中没有到当前月缴款期的用户 剔除出去（针对以年以上为有效期的用户）

			//（如果用户信息没有有效日期的 要查询该用户的收费记录 看看有没有已经收过 回款 或者年结，如果没有剔出，有则比对收款 有效期是否是本年月 大于 剔出，等于小于保留）

			//最后Table用户为实际没有缴款用户

			return null;
		}


	}
}
