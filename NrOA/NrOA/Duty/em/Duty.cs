using System;

namespace NrOA.Duty.em
{
	/// <summary>
	/// ְ��ʵ��
	/// </summary>
	public class Duty
	{
		public Duty()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		private int _Duty_ID;
		/// <summary>
		/// ְ����
		/// </summary>
		public int Duty_ID
		{
			get { return _Duty_ID; }
			set { _Duty_ID = value; }
		}
		private string _DutyName;
		/// <summary>
		/// ְ������
		/// </summary>
		public string DutyName
		{
			get { return _DutyName; }
			set { _DutyName = value; }
		}
	}
}
