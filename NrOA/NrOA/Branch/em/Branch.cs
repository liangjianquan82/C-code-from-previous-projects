using System;

namespace NrOA.Branch.em
{
	/// <summary>
	/// 部门实体
	/// </summary>
	public class Branch
	{
		public Branch()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private int _Branch_ID;
		/// <summary>
		/// 部门编号
		/// </summary>
		public int Branch_ID
		{
			get { return _Branch_ID; }
			set { _Branch_ID = value; }
		}
		private string _BranchName;
		/// <summary>
		/// 部门名称
		/// </summary>
		public string BranchName
		{
			get { return _BranchName; }
			set { _BranchName = value; }
		}
		private string _BranchRemark;
		/// <summary>
		/// 部门备注
		/// </summary>
		public string BranchRemark
		{
			get { return _BranchRemark; }
			set { _BranchRemark = value; }
		}
	}
}
