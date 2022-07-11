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
	/// DOBranch ��ժҪ˵����
	/// </summary>
	public class DOBranch
	{
		public DOBranch()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ���������
		/// </summary>
		/// <returns></returns>
		public int BranchMaxID()
		{
			int id = -1;
			id = ((NrOA.Branch.em.Branch)(Mapper.Instance().QueryForList("BranchMaxID",null))[0]).Branch_ID+1;
			return id;
		}

		/// <summary>
		/// ��ѯ���еĲ���
		/// </summary>
		/// <returns></returns>
		public IList SelectAllBranch()
		{
			return Mapper.Instance().QueryForList("SelectAllBranch",null);
		}
		/// <summary>
		/// ���ݱ��ɾ������
		/// </summary>
		/// <param name="Branch_ID">���ű��</param>
		public void DelectBranch_by_ID(int Branch_ID)
		{
			Mapper.Instance().Delete("DelectBranch_by_ID",Branch_ID);
		}
		/// <summary>
		/// ���ݱ�Ų�ѯ�ͻ���Ϣ
		/// </summary>
		/// <param name="Branch_ID">�ͻ����</param>
		/// <returns></returns>
		public IList BranchInfo_by_id(int Branch_ID)
		{
			return Mapper.Instance().QueryForList("BranchInfo_by_id",Branch_ID);
		}
		/// <summary>
		/// ����������Ϣ
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
