using System;

namespace NrOA.Branch.em
{
	/// <summary>
	/// ����ʵ��
	/// </summary>
	public class Branch
	{
		public Branch()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		private int _Branch_ID;
		/// <summary>
		/// ���ű��
		/// </summary>
		public int Branch_ID
		{
			get { return _Branch_ID; }
			set { _Branch_ID = value; }
		}
		private string _BranchName;
		/// <summary>
		/// ��������
		/// </summary>
		public string BranchName
		{
			get { return _BranchName; }
			set { _BranchName = value; }
		}
		private string _BranchRemark;
		/// <summary>
		/// ���ű�ע
		/// </summary>
		public string BranchRemark
		{
			get { return _BranchRemark; }
			set { _BranchRemark = value; }
		}
	}
}
