using System;

namespace NrOA.Client.em
{
	/// <summary>
	/// Client_Rundate ��ժҪ˵����
	/// </summary>
	public class Client_Rundate
	{
		public Client_Rundate()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		private int _id;
		/// <summary>
		/// ���
		/// </summary>
		public int id
		{
			get { return _id; }
			set { _id = value; }
		}
		private int _Client_ID;
		/// <summary>
		/// �ͻ����
		/// </summary>
		public int Client_ID
		{
			get { return _Client_ID; }
			set { _Client_ID = value; }
		}
		private string _ClientOperationID;
		/// <summary>
		/// �ͻ�ҵ���
		/// </summary>
		public string ClientOperationID
		{
			get { return _ClientOperationID; }
			set { _ClientOperationID = value; }
		}
		private string _Runyear;
		/// <summary>
		/// ��
		/// </summary>
		public string Runyear
		{
			get { return _Runyear; }
			set { _Runyear = value; }
		}
		private string _Runmonth;
		/// <summary>
		/// ��
		/// </summary>
		public string Runmonth
		{
			get { return _Runmonth; }
			set { _Runmonth = value; }
		}
		private string _area_id;
		/// <summary>
		/// ��
		/// </summary>
		public string area_id
		{
			get { return _area_id; }
			set { _area_id = value; }
		}
	}
}
