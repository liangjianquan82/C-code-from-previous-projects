using System;

namespace NrOA.Area.em
{
	/// <summary>
	/// С��ʵ��
	/// </summary>
	public class Area
	{
		public Area()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		private int _Area_ID;
		/// <summary>
		/// С�����
		/// </summary>
		public int Area_ID
		{
			get { return _Area_ID; }
			set { _Area_ID = value; }
		}
		private string _Area_listid;
		/// <summary>
		/// С�����
		/// </summary>
		public string Area_listid
		{
			get { return _Area_listid; }
			set { _Area_listid = value; }
		}
		private string _AreaName;
		/// <summary>
		/// С������
		/// </summary>
		public string AreaName
		{
			get { return _AreaName; }
			set { _AreaName = value; }
		}
		private string _AreaRemark;
		/// <summary>
		/// С����Ϣ����
		/// </summary>
		public string AreaRemark
		{
			get { return _AreaRemark; }
			set { _AreaRemark = value; }
		}
		private string _Poundage;
		/// <summary>
		/// С���ֳɱ���
		/// </summary>
		public string Poundage
		{
			get { return _Poundage; }
			set { _Poundage = value; }
		}
		private string _Area_state;
		/// <summary>
		/// ����״̬
		/// </summary>
		public string Area_state
		{
			get { return _Area_state; }
			set { _Area_state = value; }
		}
	}
}
