using System;

namespace NrOA.Client.em
{
	/// <summary>
	/// �ͻ�����ʵ��
	/// </summary>
	public class Client
	{
		public Client()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
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
		private string _ClientName;
		/// <summary>
		/// �ͻ�����
		/// </summary>
		public string ClientName
		{
			get { return _ClientName; }
			set { _ClientName = value; }
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
		private string _ClientPhone;
		/// <summary>
		/// �ͻ��绰
		/// </summary>
		public string ClientPhone
		{
			get { return _ClientPhone; }
			set { _ClientPhone = value; }
		}
		private string _ClientAddress;
		/// <summary>
		/// �ͻ���ַ
		/// </summary>
		public string ClientAddress
		{
			get { return _ClientAddress; }
			set { _ClientAddress = value; }
		}
		private string _ClientAccounts;
		/// <summary>
		/// �ͻ��ʺ�
		/// </summary>
		public string ClientAccounts
		{
			get { return _ClientAccounts; }
			set { _ClientAccounts = value; }
		}
		private string _ClientPassword;
		/// <summary>
		/// �ͻ�����
		/// </summary>
		public string ClientPassword
		{
			get { return _ClientPassword; }
			set { _ClientPassword = value; }
		}
		private string _AcceptDate;
		/// <summary>
		/// ��������
		/// </summary>
		public string AcceptDate
		{
			get { return _AcceptDate; }
			set { _AcceptDate = value; }
		}
		private string _RunDate;
		/// <summary>
		/// ��ͨ����
		/// </summary>
		public string RunDate
		{
			get { return _RunDate; }
			set { _RunDate = value; }
		}
		private string _IDCard;
		/// <summary>
		/// ���֤����
		/// </summary>
		public string IDCard
		{
			get { return _IDCard; }
			set { _IDCard = value; }
		}
		private string _ProductType;
		/// <summary>
		/// �ײ�����
		/// </summary>
		public string ProductType
		{
			get { return _ProductType; }
			set { _ProductType = value; }
		}
		private string _CircsDescribe;
		/// <summary>
		/// �ɷ���������ͨ����
		/// </summary>
		public string CircsDescribe
		{
			get { return _CircsDescribe; }
			set { _CircsDescribe = value; }
		}
		private string _Remark;
		/// <summary>
		/// ��ע
		/// </summary>
		public string Remark
		{
			get { return _Remark; }
			set { _Remark = value; }
		}
		private string _AreaName;
		/// <summary>
		/// ����С��
		/// </summary>
		public string AreaName
		{
			get { return _AreaName; }
			set { _AreaName = value; }
		}
		private string _AvDate;
		/// <summary>
		/// ʹ����Ч��
		/// </summary>
		public string AvDate
		{
			get { return _AvDate; }
			set { _AvDate = value; }
		}		
		private string _RegisterMane;
		/// <summary>
		/// ��¼��
		/// </summary>
		public string RegisterMane
		{
			get { return _RegisterMane; }
			set { _RegisterMane = value; }
		}
		private string _RegisterTime;
		/// <summary>
		/// ��¼ʱ��
		/// </summary>
		public string RegisterTime
		{
			get { return _RegisterTime; }
			set { _RegisterTime = value; }
		}
		private string _ClientListID;
		/// <summary>
		/// �ͻ����к�
		/// </summary>
		public string ClientListID
		{
			get { return _ClientListID; }
			set { _ClientListID = value; }
		}
		
		private string _ClientState;
		/// <summary>
		/// �ͻ�״̬
		/// </summary>
		public string ClientState
		{
			get { return _ClientState; }
			set { _ClientState = value; }
		}

		private string _Year;
		/// <summary>
		/// ���
		/// </summary>
		public string Year
		{
			get { return _Year; }
			set { _Year = value; }
		}
		private string _startMonth;
		/// <summary>
		/// ��ʼ�·�
		/// </summary>
		public string startMonth
		{
			get { return _startMonth; }
			set { _startMonth = value; }
		}
		private string _endMonth;
		/// <summary>
		/// �����·�
		/// </summary>
		public string endMonth
		{
			get { return _endMonth; }
			set { _endMonth = value; }
		}
	}
}
