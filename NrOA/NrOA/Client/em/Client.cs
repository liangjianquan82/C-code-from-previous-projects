using System;

namespace NrOA.Client.em
{
	/// <summary>
	/// 客户资料实体
	/// </summary>
	public class Client
	{
		public Client()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private int _Client_ID;
		/// <summary>
		/// 客户编号
		/// </summary>
		public int Client_ID
		{
			get { return _Client_ID; }
			set { _Client_ID = value; }
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
		private string _ClientPhone;
		/// <summary>
		/// 客户电话
		/// </summary>
		public string ClientPhone
		{
			get { return _ClientPhone; }
			set { _ClientPhone = value; }
		}
		private string _ClientAddress;
		/// <summary>
		/// 客户地址
		/// </summary>
		public string ClientAddress
		{
			get { return _ClientAddress; }
			set { _ClientAddress = value; }
		}
		private string _ClientAccounts;
		/// <summary>
		/// 客户帐号
		/// </summary>
		public string ClientAccounts
		{
			get { return _ClientAccounts; }
			set { _ClientAccounts = value; }
		}
		private string _ClientPassword;
		/// <summary>
		/// 客户密码
		/// </summary>
		public string ClientPassword
		{
			get { return _ClientPassword; }
			set { _ClientPassword = value; }
		}
		private string _AcceptDate;
		/// <summary>
		/// 受理日期
		/// </summary>
		public string AcceptDate
		{
			get { return _AcceptDate; }
			set { _AcceptDate = value; }
		}
		private string _RunDate;
		/// <summary>
		/// 开通日期
		/// </summary>
		public string RunDate
		{
			get { return _RunDate; }
			set { _RunDate = value; }
		}
		private string _IDCard;
		/// <summary>
		/// 身份证号码
		/// </summary>
		public string IDCard
		{
			get { return _IDCard; }
			set { _IDCard = value; }
		}
		private string _ProductType;
		/// <summary>
		/// 套餐类型
		/// </summary>
		public string ProductType
		{
			get { return _ProductType; }
			set { _ProductType = value; }
		}
		private string _CircsDescribe;
		/// <summary>
		/// 缴费情况相对网通描述
		/// </summary>
		public string CircsDescribe
		{
			get { return _CircsDescribe; }
			set { _CircsDescribe = value; }
		}
		private string _Remark;
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			get { return _Remark; }
			set { _Remark = value; }
		}
		private string _AreaName;
		/// <summary>
		/// 所属小区
		/// </summary>
		public string AreaName
		{
			get { return _AreaName; }
			set { _AreaName = value; }
		}
		private string _AvDate;
		/// <summary>
		/// 使用有效期
		/// </summary>
		public string AvDate
		{
			get { return _AvDate; }
			set { _AvDate = value; }
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
		private string _ClientListID;
		/// <summary>
		/// 客户序列号
		/// </summary>
		public string ClientListID
		{
			get { return _ClientListID; }
			set { _ClientListID = value; }
		}
		
		private string _ClientState;
		/// <summary>
		/// 客户状态
		/// </summary>
		public string ClientState
		{
			get { return _ClientState; }
			set { _ClientState = value; }
		}

		private string _Year;
		/// <summary>
		/// 年份
		/// </summary>
		public string Year
		{
			get { return _Year; }
			set { _Year = value; }
		}
		private string _startMonth;
		/// <summary>
		/// 开始月份
		/// </summary>
		public string startMonth
		{
			get { return _startMonth; }
			set { _startMonth = value; }
		}
		private string _endMonth;
		/// <summary>
		/// 结束月份
		/// </summary>
		public string endMonth
		{
			get { return _endMonth; }
			set { _endMonth = value; }
		}
	}
}
