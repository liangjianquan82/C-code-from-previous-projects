using System;

namespace NrOA.CheckAccount.em
{
	/// <summary>
	/// �ؿ�ʵ��
	/// </summary>
	public class BackFundInfo
	{
		public BackFundInfo()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		private int _BackFund_ID;
		/// <summary>
		/// �ؿ���
		/// </summary>
		public int BackFund_ID
		{
			get { return _BackFund_ID; }
			set { _BackFund_ID = value; }
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
		private string _BackFund;
		/// <summary>
		/// �ؿ�
		/// </summary>
		public string BackFund
		{
			get { return _BackFund; }
			set { _BackFund = value; }
		}
		private string _BackFund_Year;
		/// <summary>
		/// �ؿ���(���)
		/// </summary>
		public string BackFund_Year
		{
			get { return _BackFund_Year; }
			set { _BackFund_Year = value; }
		}
		private string _BackFund_Month;
		/// <summary>
		/// �ؿ���(�·�)
		/// </summary>
		public string BackFund_Month
		{
			get { return _BackFund_Month; }
			set { _BackFund_Month = value; }
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
		private string _Now_Poundage;
		/// <summary>
		/// ¼��ķֳɱ�����ע��ȡֵ  ��Ϊ 0.5 �е�Ϊ 0.45��
		/// </summary>
		public string Now_Poundage
		{
			get { return _Now_Poundage; }
			set { _Now_Poundage = value; }
		}

	}
}
