using System;

namespace NrOA.CheckAccount.em
{
	/// <summary>
	/// 回款实体
	/// </summary>
	public class BackFundInfo
	{
		public BackFundInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private int _BackFund_ID;
		/// <summary>
		/// 回款编号
		/// </summary>
		public int BackFund_ID
		{
			get { return _BackFund_ID; }
			set { _BackFund_ID = value; }
		}
		private string _ClientName;
		/// <summary>
		/// 客户姓名
		/// </summary>
		public string ClientName
		{
			get { return _ClientName; }
			set { _ClientName = value; }
		}
		private string _ClientOperationID;
		/// <summary>
		/// 客户业务号
		/// </summary>
		public string ClientOperationID
		{
			get { return _ClientOperationID; }
			set { _ClientOperationID = value; }
		}
		private string _BackFund;
		/// <summary>
		/// 回款
		/// </summary>
		public string BackFund
		{
			get { return _BackFund; }
			set { _BackFund = value; }
		}
		private string _BackFund_Year;
		/// <summary>
		/// 回款年(年份)
		/// </summary>
		public string BackFund_Year
		{
			get { return _BackFund_Year; }
			set { _BackFund_Year = value; }
		}
		private string _BackFund_Month;
		/// <summary>
		/// 回款月(月份)
		/// </summary>
		public string BackFund_Month
		{
			get { return _BackFund_Month; }
			set { _BackFund_Month = value; }
		}
		private string _RegisterMane;
		/// <summary>
		/// 记录人
		/// </summary>
		public string RegisterMane
		{
			get { return _RegisterMane; }
			set { _RegisterMane = value; }
		}
		private string _RegisterTime;
		/// <summary>
		/// 记录时间
		/// </summary>
		public string RegisterTime
		{
			get { return _RegisterTime; }
			set { _RegisterTime = value; }
		}
		private string _Now_Poundage;
		/// <summary>
		/// 录入的分成比例（注意取值  空为 0.5 有的为 0.45）
		/// </summary>
		public string Now_Poundage
		{
			get { return _Now_Poundage; }
			set { _Now_Poundage = value; }
		}

	}
}
