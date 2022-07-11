using System;

namespace NrOA.CheckAccount.em
{
	/// <summary>
	/// t_yicixing 的摘要说明。
	/// </summary>
	public class t_yicixing
	{
		public t_yicixing()
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

		private string _usernb;
		/// <summary>
		/// 用户号
		/// </summary>
		public string usernb
		{
			get { return _usernb; }
			set { _usernb = value; }
		}

		private string _t_month;
		/// <summary>
		/// 录入月份
		/// </summary>
		public string t_month
		{
			get { return _t_month; }
			set { _t_month = value; }
		}

		private string _t_year;
		/// <summary>
		/// 录入年份
		/// </summary>
		public string t_year
		{
			get { return _t_year; }
			set { _t_year = value; }
		}

		private string _t_onepay;
		/// <summary>
		/// 款项
		/// </summary>
		public string t_onepay
		{
			get { return _t_onepay; }
			set { _t_onepay = value; }
		}
		private string _month_fc;
		/// <summary>
		/// 分成
		/// </summary>
		public string month_fc
		{
			get { return _month_fc; }
			set { _month_fc = value; }
		}
		private string _t_type;
		/// <summary>
		/// 类型
		/// </summary>
		public string t_type
		{
			get { return _t_type; }
			set { _t_type = value; }
		}
        
        
	}
}
