using System;

namespace NrOA.CheckAccount.em
{
	/// <summary>
	/// �շ�ʵ��
	/// </summary>
	public class ChargeInfo
	{
		public ChargeInfo()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#region �շ�ʵ��
		private int _Charge_ID;
		/// <summary>
		/// �շѱ��
		/// </summary>
		public int Charge_ID
		{
			get { return _Charge_ID; }
			set { _Charge_ID = value; }
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
		private string _ProductType;
		/// <summary>
		/// �ײ�
		/// </summary>
		public string ProductType
		{
			get { return _ProductType; }
			set { _ProductType = value; }
		}
		private string _UseCyc;
		/// <summary>
		/// ʹ����Ч��
		/// </summary>
		public string UseCyc
		{
			get { return _UseCyc; }
			set { _UseCyc = value; }
		}
		private string _OneOffConnectFees;
		/// <summary>
		/// һ���Խ����շ�
		/// </summary>
		public string OneOffConnectFees
		{
			get { return _OneOffConnectFees; }
			set { _OneOffConnectFees = value; }
		}
		private string _FirstPayment;
		/// <summary>
		/// ��һ�νɷѣ����νɷѣ�
		/// </summary>
		public string FirstPayment
		{
			get { return _FirstPayment; }
			set { _FirstPayment = value; }
		}
		private string _Payment_by_Year;
		/// <summary>
		/// �ɷѰ���    ��Ч�� �� ��һ�� ����ͬ����ͬ��(��¼�ɷ����)
		/// </summary>
		public string Payment_by_Year
		{
			get { return _Payment_by_Year; }
			set { _Payment_by_Year = value; }
		}
		private string _Payment_by_Month;
		/// <summary>
		/// �ɷѰ���    ��Ч����Ϊ �¸��µ���һ��(��¼�ɷ��·�)
		/// </summary>
		public string Payment_by_Month
		{
			get { return _Payment_by_Month; }
			set { _Payment_by_Month = value; }
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
		/// ��¼����
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

		private string _PaymentMonth;
		/// <summary>
		/// �½�ɿ�»ؿ
		/// </summary>
		public string PaymentMonth
		{
			get { return _PaymentMonth; }
			set { _PaymentMonth = value; }
		}
		private string _PaymentYear;
		/// <summary>
		/// ���ɿ�
		/// </summary>
		public string PaymentYear
		{
			get { return _PaymentYear; }
			set { _PaymentYear = value; }
		}

		private string _MovePay;
		/// <summary>
		/// Ǩ�Ʒ�
		/// </summary>
		public string MovePay
		{
			get { return _MovePay; }
			set { _MovePay = value; }
		}

		#endregion

		#region ���� ��ʾ��
		private string _Area_ID;
		/// <summary>
		/// С�����
		/// </summary>
		public string Area_ID
		{
			get { return _Area_ID; }
			set { _Area_ID = value; }
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

		private string _PoundageValue;
		/// <summary>
		/// �ֳɱ���ֵ
		/// </summary>
		public string PoundageValue
		{
			get { return _PoundageValue; }
			set { _PoundageValue = value; }
		}

		private string _state;
		/// <summary>
		/// ״̬
		/// </summary>
		public string state
		{
			get { return _state; }
			set { _state = value; }
		}

		private string _str;
		/// <summary>
		/// ģ������
		/// </summary>
		public string str
		{
			get { return _str; }
			set { _str = value; }
		}
		#endregion


	}
}
