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

namespace NrOA.comm
{
	/// <summary>
	/// TransactionSession 的摘要说明。
	/// </summary>
	public class TransactionSession
	{
		public TransactionSession()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 事务开始
		/// </summary>
		public void BeginTransaction()
		{
			Mapper.Instance().BeginTransaction();
			
		}
		/// <summary>
		/// 事务提交
		/// </summary>
		public void CommitTransaction ()
		{
			Mapper.Instance().CommitTransaction();
		}
		/// <summary>
		/// 连接结束
		/// </summary>
		public void CloseConnection()
		{
			Mapper.Instance().CloseConnection();
			
		}
		/// <summary>
		/// 事务回滚
		/// </summary>
		public void RollBackTransaction()
		{
			Mapper.Instance().RollBackTransaction();
			
		}
	}
}
