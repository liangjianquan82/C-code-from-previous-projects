using System;

namespace NrOA.Area.em
{
	/// <summary>
	/// 小区实体
	/// </summary>
	public class Area
	{
		public Area()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private int _Area_ID;
		/// <summary>
		/// 小区编号
		/// </summary>
		public int Area_ID
		{
			get { return _Area_ID; }
			set { _Area_ID = value; }
		}
		private string _Area_listid;
		/// <summary>
		/// 小区编号
		/// </summary>
		public string Area_listid
		{
			get { return _Area_listid; }
			set { _Area_listid = value; }
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
		private string _AreaRemark;
		/// <summary>
		/// 小区信息备份
		/// </summary>
		public string AreaRemark
		{
			get { return _AreaRemark; }
			set { _AreaRemark = value; }
		}
		private string _Poundage;
		/// <summary>
		/// 小区分成比例
		/// </summary>
		public string Poundage
		{
			get { return _Poundage; }
			set { _Poundage = value; }
		}
		private string _Area_state;
		/// <summary>
		/// 地区状态
		/// </summary>
		public string Area_state
		{
			get { return _Area_state; }
			set { _Area_state = value; }
		}
	}
}
