using System;
using System.Collections;
using System.Text;

namespace NrOA.CheckAccount.em
{
	/// <summary>
	/// t_huikuan ��ժҪ˵����
	/// </summary>
	public class t_huikuan
	{
		public t_huikuan()
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

		private string _usernb;
		/// <summary>
		/// �û���
		/// </summary>
		public string usernb
		{
			get { return _usernb; }
			set { _usernb = value; }
		}

		private string _t_month;
		/// <summary>
		/// ¼���·�
		/// </summary>
		public string t_month
		{
			get { return _t_month; }
			set { _t_month = value; }
		}

		private string _t_year;
		/// <summary>
		/// ¼�����
		/// </summary>
		public string t_year
		{
			get { return _t_year; }
			set { _t_year = value; }
		}

		private string _month_pay;
		/// <summary>
		/// ����
		/// </summary>
		public string month_pay
		{
			get { return _month_pay; }
			set { _month_pay = value; }
		}
		private string _month_fc;
		/// <summary>
		/// �ֳ�
		/// </summary>
		public string month_fc
		{
			get { return _month_fc; }
			set { _month_fc = value; }
		}
	}
}
