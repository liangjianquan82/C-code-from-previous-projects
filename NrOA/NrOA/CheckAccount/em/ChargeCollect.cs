using System;

namespace NrOA.CheckAccount.em
{
	/// <summary>
	/// ChargeCollect ��ժҪ˵����
	/// </summary>
	public class ChargeCollect
	{
		public ChargeCollect()
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
		private string _ClientOperationID;
		/// <summary>
		/// �ͻ�ҵ���
		/// </summary>
		public string ClientOperationID
		{
			get { return _ClientOperationID; }
			set { _ClientOperationID = value; }
		}
		private string _Poundage;
		/// <summary>
		/// ԭ�ֳɱ���
		/// </summary>
		public string Poundage
		{
			get { return _Poundage; }
			set { _Poundage = value; }
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
		private string _MovePay;
		/// <summary>
		/// Ǩ�Ʒ�
		/// </summary>
		public string MovePay
		{
			get { return _MovePay; }
			set { _MovePay = value; }
		}
		private string _OMPoundage;
		/// <summary>
		/// Ǩ�Ʒ�/һ���Խ���ѷֳɱ���
		/// </summary>
		public string OMPoundage
		{
			get { return _OMPoundage; }
			set { _OMPoundage = value; }
		}

		#region һ�·�
		private string _oneyue;
		/// <summary>
		/// һ�·ݽɷ�
		/// </summary>
		public string oneyue
		{
			get { return _oneyue; }
			set { _oneyue = value; }
		}
		private string _onePoundage;
		/// <summary>
		/// һ�·ݷֳɱ���
		/// </summary>
		public string onePoundage
		{
			get { return _onePoundage; }
			set { _onePoundage = value; }
		}
        #endregion

		#region ���·�
		private string _twoyue;
		/// <summary>
		/// ���·ݽɷ�
		/// </summary>
		public string twoyue
		{
			get { return _twoyue; }
			set { _twoyue = value; }
		}
		private string _twoPoundage;
		/// <summary>
		/// ���·ݷֳɱ���
		/// </summary>
		public string twoPoundage
		{
			get { return _twoPoundage; }
			set { _twoPoundage = value; }
		}
		#endregion

		#region ���·�
		private string _threeyue;
		/// <summary>
		/// ���·ݽɷ�
		/// </summary>
		public string threeyue
		{
			get { return _threeyue; }
			set { _threeyue = value; }
		}
		private string _threePoundage;
		/// <summary>
		/// ���·ݷֳɱ���
		/// </summary>
		public string threePoundage
		{
			get { return _threePoundage; }
			set { _threePoundage = value; }
		}
		#endregion

		#region ���·�
		private string _fouryue;
		/// <summary>
		/// ���·ݽɷ�
		/// </summary>
		public string fouryue
		{
			get { return _fouryue; }
			set { _fouryue = value; }
		}
		private string _fourPoundage;
		/// <summary>
		/// ���·ݷֳɱ���
		/// </summary>
		public string fourPoundage
		{
			get { return _fourPoundage; }
			set { _fourPoundage = value; }
		}
		#endregion

		#region ���·�
		private string _fiveyue;
		/// <summary>
		/// ���·ݽɷ�
		/// </summary>
		public string fiveyue
		{
			get { return _fiveyue; }
			set { _fiveyue = value; }
		}
		private string _fivePoundage;
		/// <summary>
		/// ���·ݷֳɱ���
		/// </summary>
		public string fivePoundage
		{
			get { return _fivePoundage; }
			set { _fivePoundage = value; }
		}
		#endregion

		#region ���·�
		private string _sixyue;
		/// <summary>
		/// ���·ݽɷ�
		/// </summary>
		public string sixyue
		{
			get { return _sixyue; }
			set { _sixyue = value; }
		}
		private string _sixPoundage;
		/// <summary>
		/// ���·ݷֳɱ���
		/// </summary>
		public string sixPoundage
		{
			get { return _sixPoundage; }
			set { _sixPoundage = value; }
		}
		#endregion

		#region ���·�
		private string _sevenyue;
		/// <summary>
		/// ���·ݽɷ�
		/// </summary>
		public string sevenyue
		{
			get { return _sevenyue; }
			set { _sevenyue = value; }
		}
		private string _sevenPoundage;
		/// <summary>
		/// ���·ݷֳɱ���
		/// </summary>
		public string sevenPoundage
		{
			get { return _sevenPoundage; }
			set { _sevenPoundage = value; }
		}
		#endregion

		#region ���·�
		private string _eightyue;
		/// <summary>
		/// ���·ݽɷ�
		/// </summary>
		public string eightyue
		{
			get { return _eightyue; }
			set { _eightyue = value; }
		}
		private string _eightPoundage;
		/// <summary>
		/// ���·ݷֳɱ���
		/// </summary>
		public string eightPoundage
		{
			get { return _eightPoundage; }
			set { _eightPoundage = value; }
		}
		#endregion

		#region ���·�
		private string _nineyue;
		/// <summary>
		/// ���·ݽɷ�
		/// </summary>
		public string nineyue
		{
			get { return _nineyue; }
			set { _nineyue = value; }
		}
		private string _ninePoundage;
		/// <summary>
		/// ���·ݷֳɱ���
		/// </summary>
		public string ninePoundage
		{
			get { return _ninePoundage; }
			set { _ninePoundage = value; }
		}
		#endregion

		#region ʮ�·�
		private string _tenyue;
		/// <summary>
		/// ʮ�·ݽɷ�
		/// </summary>
		public string tenyue
		{
			get { return _tenyue; }
			set { _tenyue = value; }
		}
		private string _tenPoundage;
		/// <summary>
		/// ʮ�·ݷֳɱ���
		/// </summary>
		public string tenPoundage
		{
			get { return _tenPoundage; }
			set { _tenPoundage = value; }
		}
		#endregion

		#region ʮһ�·�
		private string _elevenyue;
		/// <summary>
		/// ʮһ�·ݽɷ�
		/// </summary>
		public string elevenyue
		{
			get { return _elevenyue; }
			set { _elevenyue = value; }
		}
		private string _elevenPoundage;
		/// <summary>
		/// ʮһ�·ݷֳɱ���
		/// </summary>
		public string elevenPoundage
		{
			get { return _elevenPoundage; }
			set { _elevenPoundage = value; }
		}
		#endregion

		#region ʮ���·�
		private string _twelveyue;
		/// <summary>
		/// ʮ���·ݽɷ�
		/// </summary>
		public string twelveyue
		{
			get { return _twelveyue; }
			set { _twelveyue = value; }
		}
		private string _twelvePoundage;
		/// <summary>
		/// ʮ���·ݷֳɱ���
		/// </summary>
		public string twelvePoundage
		{
			get { return _twelvePoundage; }
			set { _twelvePoundage = value; }
		}
		#endregion

		private string _Year;
		/// <summary>
		/// ���
		/// </summary>
		public string year
		{
			get { return _Year; }
			set { _Year = value; }
		}
		private string _Year1;
		/// <summary>
		/// ���1
		/// </summary>
		public string year1
		{
			get { return _Year1; }
			set { _Year1 = value; }
		}
		private string _Month;
		/// <summary>
		/// �·�
		/// </summary>
		public string month
		{
			get { return _Month; }
			set { _Month = value; }
		}
		private string _remark;
		/// <summary>
		/// ����
		/// </summary>
		public string remark
		{
			get { return _remark; }
			set { _remark = value; }
		}
		private string _area_id;
		/// <summary>
		/// С�����
		/// </summary>
		public string area_id
		{
			get { return _area_id; }
			set { _area_id = value; }
		}
		private string _state;
		/// <summary>
		/// ״̬ 1һ��״̬ 2-�쳣״̬
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

		private string _AreaName;
		/// <summary>
		/// С������
		/// </summary>
		public string AreaName
		{
			get { return _AreaName; }
			set { _AreaName = value; }
		}

		private string _RunDate;
		/// <summary>
		/// ��ͨʱ��
		/// </summary>
		public string RunDate
		{
			get { return _RunDate; }
			set { _RunDate = value; }
		}

		private string _ClientName;
		/// <summary>
		/// �û���
		/// </summary>
		public string ClientName
		{
			get { return _ClientName; }
			set { _ClientName = value; }
		}
		private string _ProductType;
		/// <summary>
		/// �ֳɱ���
		/// </summary>
		public string ProductType
		{
			get { return _ProductType; }
			set { _ProductType = value; }
		}

		private string _ClientListID;
		/// <summary>
		/// ���
		/// </summary>
		public string ClientListID
		{
			get { return _ClientListID; }
			set { _ClientListID = value; }
		}

	}
}
