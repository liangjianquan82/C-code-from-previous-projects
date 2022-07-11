using System;

namespace NrOA.CheckAccount.em
{
	/// <summary>
	/// 收费实体
	/// </summary>
	public class ChargeInfo
	{
		public ChargeInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 收费实体
		private int _Charge_ID;
		/// <summary>
		/// 收费编号
		/// </summary>
		public int Charge_ID
		{
			get { return _Charge_ID; }
			set { _Charge_ID = value; }
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
		private string _ProductType;
		/// <summary>
		/// 套餐
		/// </summary>
		public string ProductType
		{
			get { return _ProductType; }
			set { _ProductType = value; }
		}
		private string _UseCyc;
		/// <summary>
		/// 使用有效期
		/// </summary>
		public string UseCyc
		{
			get { return _UseCyc; }
			set { _UseCyc = value; }
		}
		private string _OneOffConnectFees;
		/// <summary>
		/// 一次性接入收费
		/// </summary>
		public string OneOffConnectFees
		{
			get { return _OneOffConnectFees; }
			set { _OneOffConnectFees = value; }
		}
		private string _FirstPayment;
		/// <summary>
		/// 第一次缴费（本次缴费）
		/// </summary>
		public string FirstPayment
		{
			get { return _FirstPayment; }
			set { _FirstPayment = value; }
		}
		private string _Payment_by_Year;
		/// <summary>
		/// 缴费按年    有效期 到 下一年 的相同月相同日(记录缴费年份)
		/// </summary>
		public string Payment_by_Year
		{
			get { return _Payment_by_Year; }
			set { _Payment_by_Year = value; }
		}
		private string _Payment_by_Month;
		/// <summary>
		/// 缴费按月    有效日期为 下个月的这一天(记录缴费月份)
		/// </summary>
		public string Payment_by_Month
		{
			get { return _Payment_by_Month; }
			set { _Payment_by_Month = value; }
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
		/// 记录日期
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

		private string _PaymentMonth;
		/// <summary>
		/// 月结缴款（月回款）
		/// </summary>
		public string PaymentMonth
		{
			get { return _PaymentMonth; }
			set { _PaymentMonth = value; }
		}
		private string _PaymentYear;
		/// <summary>
		/// 年结缴款
		/// </summary>
		public string PaymentYear
		{
			get { return _PaymentYear; }
			set { _PaymentYear = value; }
		}

		private string _MovePay;
		/// <summary>
		/// 迁移费
		/// </summary>
		public string MovePay
		{
			get { return _MovePay; }
			set { _MovePay = value; }
		}

		#endregion

		#region 补充 显示项
		private string _Area_ID;
		/// <summary>
		/// 小区编号
		/// </summary>
		public string Area_ID
		{
			get { return _Area_ID; }
			set { _Area_ID = value; }
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

		private string _PoundageValue;
		/// <summary>
		/// 分成比例值
		/// </summary>
		public string PoundageValue
		{
			get { return _PoundageValue; }
			set { _PoundageValue = value; }
		}

		private string _state;
		/// <summary>
		/// 状态
		/// </summary>
		public string state
		{
			get { return _state; }
			set { _state = value; }
		}

		private string _str;
		/// <summary>
		/// 模糊条件
		/// </summary>
		public string str
		{
			get { return _str; }
			set { _str = value; }
		}
		#endregion


	}
}
