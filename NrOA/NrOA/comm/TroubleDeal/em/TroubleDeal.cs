using System;

namespace NrOA.TroubleDeal.em
{
	/// <summary>
	/// TroubleDeal ��ժҪ˵����
	/// </summary>
	public class TroubleDeal
	{
		public TroubleDeal()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		#region ʵ��
		/// ���ϵ���
		private int _Trouble_id;
		/// <summary>
		/// ���ϵ���
		/// </summary>
		public int Trouble_id
		{
			get { return _Trouble_id; }
			set { _Trouble_id = value; }
		}
		/// ���Ϻ���
		private string _Trouble_nb;
		/// <summary>
		/// ���Ϻ���
		/// </summary>
		public string Trouble_nb
		{
			get { return _Trouble_nb; }
			set { _Trouble_nb = value; }
		}
		/// �����걨����
		private string _Trouble_date;
		/// <summary>
		/// �����걨����
		/// </summary>
		public string Trouble_date
		{
			get { return _Trouble_date; }
			set { _Trouble_date = value; }
		}
		/// �걨��
		private string _Proposer;
		/// <summary>
		/// �걨��
		/// </summary>
		public string Proposer
		{
			get { return _Proposer; }
			set { _Proposer = value; }
		}
		/// �걨�˵�ַ
		private string _ProposerAddress;
		/// <summary>
		/// �걨�˵�ַ
		/// </summary>
		public string ProposerAddress
		{
			get { return _ProposerAddress; }
			set { _ProposerAddress = value; }
		}
		/// �걨�˵绰
		private string _ProposerPhone;
		/// <summary>
		/// �걨�˵绰
		/// </summary>
		public string ProposerPhone
		{
			get { return _ProposerPhone; }
			set { _ProposerPhone = value; }
		}
		/// ��������
		private string _Trouble_Describe;
		/// <summary>
		/// ��������
		/// </summary>
		public string Trouble_Describe
		{
			get { return _Trouble_Describe; }
			set { _Trouble_Describe = value; }
		}
		/// �ɹ���Ա
		private string _Dispatch_man;
		/// <summary>
		/// �ɹ���Ա
		/// </summary>
		public string Dispatch_man
		{
			get { return _Dispatch_man; }
			set { _Dispatch_man = value; }
		}
		/// �ɹ����ʱ��
		private string _Dispatch_date;
		/// <summary>
		/// �ɹ����ʱ��
		/// </summary>
		public string Dispatch_date
		{
			get { return _Dispatch_date; }
			set { _Dispatch_date = value; }
		}
		/// ��¼��
		private string _Register_man;
		/// <summary>
		/// ��¼��
		/// </summary>
		public string Register_man
		{
			get { return _Register_man; }
			set { _Register_man = value; }
		}
		/// ��¼ʱ��
		private string _Register_date;
		/// <summary>
		/// ��¼ʱ��
		/// </summary>
		public string Register_date
		{
			get { return _Register_date; }
			set { _Register_date = value; }
		}
		/// ������
		private string _DealResult;
		/// <summary>
		/// ������
		/// </summary>
		public string DealResult
		{
			get { return _DealResult; }
			set { _DealResult = value; }
		}
		/// �������ʱ��
		private string _Deal_date;
		/// <summary>
		/// �������ʱ��
		/// </summary>
		public string Deal_date
		{
			get { return _Deal_date; }
			set { _Deal_date = value; }
		}
		/// �ط�
		private string _BackCallContent;
		/// <summary>
		/// �ط�
		/// </summary>
		public string BackCallContent
		{
			get { return _BackCallContent; }
			set { _BackCallContent = value; }
		}
		/// ״̬
		private string _state;
		/// <summary>
		/// ״̬
		/// </summary>
		public string state
		{
			get { return _state; }
			set { _state = value; }
		}
		private string _OperationID;
		/// <summary>
		/// ҵ���
		/// </summary>
		public string OperationID
		{
			get { return _OperationID; }
			set { _OperationID = value; }
		}

		/// �ͻ�Ͷ��
		private string _Complaints;
		/// <summary>
		/// �ͻ�Ͷ��
		/// </summary>
		public string Complaints
		{
			get { return _Complaints; }
			set { _Complaints = value; }
		}
		private string _Moveinfo;
		/// <summary>
		/// ��ˮ��Ϣ
		/// </summary>
		public string Moveinfo
		{
			get { return _Moveinfo; }
			set { _Moveinfo = value; }
		}

		private string _remark;
		public string remark
		{
			get { return _remark; }
			set { _remark = value; }
		}
		#endregion

		private string _year;
		public string year
		{
			get { return _year; }
			set { _year = value; }
		}
		private string _startmonth;
		public string startmonth
		{
			get { return _startmonth; }
			set { _startmonth = value; }
		}
		private string _endmonth;
		public string endmonth
		{
			get { return _endmonth; }
			set { _endmonth = value; }
		}

	}
}
