using System;

namespace NrOA.CheckAccount.em
{
	/// <summary>
	/// ChargeCollect 的摘要说明。
	/// </summary>
	public class ChargeCollect
	{
		public ChargeCollect()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private int _id;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			get { return _id; }
			set { _id = value; }
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
		private string _Poundage;
		/// <summary>
		/// 原分成比例
		/// </summary>
		public string Poundage
		{
			get { return _Poundage; }
			set { _Poundage = value; }
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
		private string _MovePay;
		/// <summary>
		/// 迁移费
		/// </summary>
		public string MovePay
		{
			get { return _MovePay; }
			set { _MovePay = value; }
		}
		private string _OMPoundage;
		/// <summary>
		/// 迁移费/一次性接入费分成比例
		/// </summary>
		public string OMPoundage
		{
			get { return _OMPoundage; }
			set { _OMPoundage = value; }
		}

		#region 一月份
		private string _oneyue;
		/// <summary>
		/// 一月份缴费
		/// </summary>
		public string oneyue
		{
			get { return _oneyue; }
			set { _oneyue = value; }
		}
		private string _onePoundage;
		/// <summary>
		/// 一月份分成比例
		/// </summary>
		public string onePoundage
		{
			get { return _onePoundage; }
			set { _onePoundage = value; }
		}
        #endregion

		#region 二月份
		private string _twoyue;
		/// <summary>
		/// 二月份缴费
		/// </summary>
		public string twoyue
		{
			get { return _twoyue; }
			set { _twoyue = value; }
		}
		private string _twoPoundage;
		/// <summary>
		/// 二月份分成比例
		/// </summary>
		public string twoPoundage
		{
			get { return _twoPoundage; }
			set { _twoPoundage = value; }
		}
		#endregion

		#region 三月份
		private string _threeyue;
		/// <summary>
		/// 三月份缴费
		/// </summary>
		public string threeyue
		{
			get { return _threeyue; }
			set { _threeyue = value; }
		}
		private string _threePoundage;
		/// <summary>
		/// 三月份分成比例
		/// </summary>
		public string threePoundage
		{
			get { return _threePoundage; }
			set { _threePoundage = value; }
		}
		#endregion

		#region 四月份
		private string _fouryue;
		/// <summary>
		/// 四月份缴费
		/// </summary>
		public string fouryue
		{
			get { return _fouryue; }
			set { _fouryue = value; }
		}
		private string _fourPoundage;
		/// <summary>
		/// 四月份分成比例
		/// </summary>
		public string fourPoundage
		{
			get { return _fourPoundage; }
			set { _fourPoundage = value; }
		}
		#endregion

		#region 五月份
		private string _fiveyue;
		/// <summary>
		/// 五月份缴费
		/// </summary>
		public string fiveyue
		{
			get { return _fiveyue; }
			set { _fiveyue = value; }
		}
		private string _fivePoundage;
		/// <summary>
		/// 五月份分成比例
		/// </summary>
		public string fivePoundage
		{
			get { return _fivePoundage; }
			set { _fivePoundage = value; }
		}
		#endregion

		#region 六月份
		private string _sixyue;
		/// <summary>
		/// 六月份缴费
		/// </summary>
		public string sixyue
		{
			get { return _sixyue; }
			set { _sixyue = value; }
		}
		private string _sixPoundage;
		/// <summary>
		/// 六月份分成比例
		/// </summary>
		public string sixPoundage
		{
			get { return _sixPoundage; }
			set { _sixPoundage = value; }
		}
		#endregion

		#region 七月份
		private string _sevenyue;
		/// <summary>
		/// 七月份缴费
		/// </summary>
		public string sevenyue
		{
			get { return _sevenyue; }
			set { _sevenyue = value; }
		}
		private string _sevenPoundage;
		/// <summary>
		/// 七月份分成比例
		/// </summary>
		public string sevenPoundage
		{
			get { return _sevenPoundage; }
			set { _sevenPoundage = value; }
		}
		#endregion

		#region 八月份
		private string _eightyue;
		/// <summary>
		/// 八月份缴费
		/// </summary>
		public string eightyue
		{
			get { return _eightyue; }
			set { _eightyue = value; }
		}
		private string _eightPoundage;
		/// <summary>
		/// 八月份分成比例
		/// </summary>
		public string eightPoundage
		{
			get { return _eightPoundage; }
			set { _eightPoundage = value; }
		}
		#endregion

		#region 九月份
		private string _nineyue;
		/// <summary>
		/// 九月份缴费
		/// </summary>
		public string nineyue
		{
			get { return _nineyue; }
			set { _nineyue = value; }
		}
		private string _ninePoundage;
		/// <summary>
		/// 九月份分成比例
		/// </summary>
		public string ninePoundage
		{
			get { return _ninePoundage; }
			set { _ninePoundage = value; }
		}
		#endregion

		#region 十月份
		private string _tenyue;
		/// <summary>
		/// 十月份缴费
		/// </summary>
		public string tenyue
		{
			get { return _tenyue; }
			set { _tenyue = value; }
		}
		private string _tenPoundage;
		/// <summary>
		/// 十月份分成比例
		/// </summary>
		public string tenPoundage
		{
			get { return _tenPoundage; }
			set { _tenPoundage = value; }
		}
		#endregion

		#region 十一月份
		private string _elevenyue;
		/// <summary>
		/// 十一月份缴费
		/// </summary>
		public string elevenyue
		{
			get { return _elevenyue; }
			set { _elevenyue = value; }
		}
		private string _elevenPoundage;
		/// <summary>
		/// 十一月份分成比例
		/// </summary>
		public string elevenPoundage
		{
			get { return _elevenPoundage; }
			set { _elevenPoundage = value; }
		}
		#endregion

		#region 十二月份
		private string _twelveyue;
		/// <summary>
		/// 十二月份缴费
		/// </summary>
		public string twelveyue
		{
			get { return _twelveyue; }
			set { _twelveyue = value; }
		}
		private string _twelvePoundage;
		/// <summary>
		/// 十二月份分成比例
		/// </summary>
		public string twelvePoundage
		{
			get { return _twelvePoundage; }
			set { _twelvePoundage = value; }
		}
		#endregion

		private string _Year;
		/// <summary>
		/// 年份
		/// </summary>
		public string year
		{
			get { return _Year; }
			set { _Year = value; }
		}
		private string _Year1;
		/// <summary>
		/// 年份1
		/// </summary>
		public string year1
		{
			get { return _Year1; }
			set { _Year1 = value; }
		}
		private string _Month;
		/// <summary>
		/// 月份
		/// </summary>
		public string month
		{
			get { return _Month; }
			set { _Month = value; }
		}
		private string _remark;
		/// <summary>
		/// 备份
		/// </summary>
		public string remark
		{
			get { return _remark; }
			set { _remark = value; }
		}
		private string _area_id;
		/// <summary>
		/// 小区编号
		/// </summary>
		public string area_id
		{
			get { return _area_id; }
			set { _area_id = value; }
		}
		private string _state;
		/// <summary>
		/// 状态 1一般状态 2-异常状态
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

		private string _AreaName;
		/// <summary>
		/// 小区名称
		/// </summary>
		public string AreaName
		{
			get { return _AreaName; }
			set { _AreaName = value; }
		}

		private string _RunDate;
		/// <summary>
		/// 开通时间
		/// </summary>
		public string RunDate
		{
			get { return _RunDate; }
			set { _RunDate = value; }
		}

		private string _ClientName;
		/// <summary>
		/// 用户名
		/// </summary>
		public string ClientName
		{
			get { return _ClientName; }
			set { _ClientName = value; }
		}
		private string _ProductType;
		/// <summary>
		/// 分成比例
		/// </summary>
		public string ProductType
		{
			get { return _ProductType; }
			set { _ProductType = value; }
		}

		private string _ClientListID;
		/// <summary>
		/// 序号
		/// </summary>
		public string ClientListID
		{
			get { return _ClientListID; }
			set { _ClientListID = value; }
		}

	}
}
