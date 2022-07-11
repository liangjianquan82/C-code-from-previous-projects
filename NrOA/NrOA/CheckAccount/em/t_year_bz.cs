using System;

namespace NrOA.CheckAccount.em
{
	/// <summary>
	/// t_year_bz 的摘要说明。
	/// </summary>
	public class t_year_bz
	{
		public t_year_bz()
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
		private string _remark;
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			get { return _remark; }
			set { _remark = value; }
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
		private string _type;
		/// <summary>
		/// 类型
		/// </summary>
		public string type
		{
			get { return _type; }
			set { _type = value; }
		}
		

	}
}
