using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.UI.HtmlControls;

using System.Collections;


using IBatisNet.DataMapper;
using IBatisNet.Common;

namespace NrOA.Branch.pkg
{
	/// <summary>
	/// DOBranch 的摘要说明。
	/// </summary>
	public class DOBranch
	{
		public DOBranch()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 给出最大编号
		/// </summary>
		/// <returns></returns>
		public int BranchMaxID()
		{
			int id = -1;
			id = ((NrOA.Branch.em.Branch)(Mapper.Instance().QueryForList("BranchMaxID",null))[0]).Branch_ID+1;
			return id;
		}

		/// <summary>
		/// 查询所有的部门
		/// </summary>
		/// <returns></returns>
		public IList SelectAllBranch()
		{
			return Mapper.Instance().QueryForList("SelectAllBranch",null);
		}
		/// <summary>
		/// 根据编号删除部门
		/// </summary>
		/// <param name="Branch_ID">部门编号</param>
		public void DelectBranch_by_ID(int Branch_ID)
		{
			Mapper.Instance().Delete("DelectBranch_by_ID",Branch_ID);
		}
		/// <summary>
		/// 根据编号查询客户信息
		/// </summary>
		/// <param name="Branch_ID">客户编号</param>
		/// <returns></returns>
		public IList BranchInfo_by_id(int Branch_ID)
		{
			return Mapper.Instance().QueryForList("BranchInfo_by_id",Branch_ID);
		}
		/// <summary>
		/// 新增部门信息
		/// </summary>
		/// <param name="br"></param>
		public void insertBranchInfo(NrOA.Branch.em.Branch br)
		{
			br.Branch_ID = this.BranchMaxID();
			Mapper.Instance().Insert("insertBranchInfo",br);
		}
		public void UpdateBranchInfo(NrOA.Branch.em.Branch br)
		{
			Mapper.Instance().Update("UpdateBranchInfo",br);
		}
	}
}
