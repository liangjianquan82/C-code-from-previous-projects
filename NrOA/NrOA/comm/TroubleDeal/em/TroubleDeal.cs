using System;

namespace NrOA.TroubleDeal.em
{
	/// <summary>
	/// TroubleDeal 的摘要说明。
	/// </summary>
	public class TroubleDeal
	{
		public TroubleDeal()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 实体
		/// 故障单号
		private int _Trouble_id;
		/// <summary>
		/// 故障单号
		/// </summary>
		public int Trouble_id
		{
			get { return _Trouble_id; }
			set { _Trouble_id = value; }
		}
		/// 故障号码
		private string _Trouble_nb;
		/// <summary>
		/// 故障号码
		/// </summary>
		public string Trouble_nb
		{
			get { return _Trouble_nb; }
			set { _Trouble_nb = value; }
		}
		/// 故障申报日期
		private string _Trouble_date;
		/// <summary>
		/// 故障申报日期
		/// </summary>
		public string Trouble_date
		{
			get { return _Trouble_date; }
			set { _Trouble_date = value; }
		}
		/// 申报人
		private string _Proposer;
		/// <summary>
		/// 申报人
		/// </summary>
		public string Proposer
		{
			get { return _Proposer; }
			set { _Proposer = value; }
		}
		/// 申报人地址
		private string _ProposerAddress;
		/// <summary>
		/// 申报人地址
		/// </summary>
		public string ProposerAddress
		{
			get { return _ProposerAddress; }
			set { _ProposerAddress = value; }
		}
		/// 申报人电话
		private string _ProposerPhone;
		/// <summary>
		/// 申报人电话
		/// </summary>
		public string ProposerPhone
		{
			get { return _ProposerPhone; }
			set { _ProposerPhone = value; }
		}
		/// 故障描述
		private string _Trouble_Describe;
		/// <summary>
		/// 故障描述
		/// </summary>
		public string Trouble_Describe
		{
			get { return _Trouble_Describe; }
			set { _Trouble_Describe = value; }
		}
		/// 派工人员
		private string _Dispatch_man;
		/// <summary>
		/// 派工人员
		/// </summary>
		public string Dispatch_man
		{
			get { return _Dispatch_man; }
			set { _Dispatch_man = value; }
		}
		/// 派工完成时间
		private string _Dispatch_date;
		/// <summary>
		/// 派工完成时间
		/// </summary>
		public string Dispatch_date
		{
			get { return _Dispatch_date; }
			set { _Dispatch_date = value; }
		}
		/// 记录人
		private string _Register_man;
		/// <summary>
		/// 记录人
		/// </summary>
		public string Register_man
		{
			get { return _Register_man; }
			set { _Register_man = value; }
		}
		/// 记录时间
		private string _Register_date;
		/// <summary>
		/// 记录时间
		/// </summary>
		public string Register_date
		{
			get { return _Register_date; }
			set { _Register_date = value; }
		}
		/// 处理结果
		private string _DealResult;
		/// <summary>
		/// 处理结果
		/// </summary>
		public string DealResult
		{
			get { return _DealResult; }
			set { _DealResult = value; }
		}
		/// 处理完成时间
		private string _Deal_date;
		/// <summary>
		/// 处理完成时间
		/// </summary>
		public string Deal_date
		{
			get { return _Deal_date; }
			set { _Deal_date = value; }
		}
		/// 回访
		private string _BackCallContent;
		/// <summary>
		/// 回访
		/// </summary>
		public string BackCallContent
		{
			get { return _BackCallContent; }
			set { _BackCallContent = value; }
		}
		/// 状态
		private string _state;
		/// <summary>
		/// 状态
		/// </summary>
		public string state
		{
			get { return _state; }
			set { _state = value; }
		}
		private string _OperationID;
		/// <summary>
		/// 业务号
		/// </summary>
		public string OperationID
		{
			get { return _OperationID; }
			set { _OperationID = value; }
		}

		/// 客户投诉
		private string _Complaints;
		/// <summary>
		/// 客户投诉
		/// </summary>
		public string Complaints
		{
			get { return _Complaints; }
			set { _Complaints = value; }
		}
		private string _Moveinfo;
		/// <summary>
		/// 流水信息
		/// </summary>
		public string Moveinfo
		{
			get { return _Moveinfo; }
			set { _Moveinfo = value; }
		}

		private string _remark;
		public string remark
		{
			get { return _remark; }
			set { _remark = value; }
		}
		#endregion

		private string _year;
		public string year
		{
			get { return _year; }
			set { _year = value; }
		}
		private string _startmonth;
		public string startmonth
		{
			get { return _startmonth; }
			set { _startmonth = value; }
		}
		private string _endmonth;
		public string endmonth
		{
			get { return _endmonth; }
			set { _endmonth = value; }
		}

	}
}
