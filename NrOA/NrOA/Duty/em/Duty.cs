using System;

namespace NrOA.Duty.em
{
	/// <summary>
	/// 职务实体
	/// </summary>
	public class Duty
	{
		public Duty()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private int _Duty_ID;
		/// <summary>
		/// 职务编号
		/// </summary>
		public int Duty_ID
		{
			get { return _Duty_ID; }
			set { _Duty_ID = value; }
		}
		private string _DutyName;
		/// <summary>
		/// 职务名称
		/// </summary>
		public string DutyName
		{
			get { return _DutyName; }
			set { _DutyName = value; }
		}
	}
}
