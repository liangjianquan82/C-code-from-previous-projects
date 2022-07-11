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
using NrOA.Affiche.em;

namespace NrOA.Affiche.pkg
{
	/// <summary>
	/// DOaffiche 的摘要说明。
	/// </summary>
	public class DOaffiche
	{
		public DOaffiche()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 根据状态查询公告
		/// </summary>
		/// <param name="state">0-未发布，1-发布</param>
		/// <returns></returns>
		public IList SelectAffiche_state(string state)
		{
			if(state=="-1")
			{
				return SelectAfficheAll();
			}
			else
			{
				return Mapper.Instance().QueryForList("SelectAffiche_state",state);
			}
		}

		/// <summary>
		/// 查询全部公告
		/// </summary>
		/// <returns></returns>
		public IList SelectAfficheAll()
		{
			return Mapper.Instance().QueryForList("SelectAfficheAll",null);
		}
		/// <summary>
		/// 根据编号查询公告
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public IList SelectAffiche_By_ID(int id)
		{
			return Mapper.Instance().QueryForList("SelectAffiche_By_ID",id);
		}
		/// <summary>
		/// 更新公告状态
		/// </summary>
		/// <param name="af"></param>
		public void Affiche_State_Change(Affiche.em.affiche af)
		{
			Mapper.Instance().Update("Affiche_State_Change",af);
		}
		/// <summary>
		/// 新增公告
		/// </summary>
		/// <param name="af"></param>
		public void InsertafficheInfo(Affiche.em.affiche af)
		{
			Mapper.Instance().Insert("InsertafficheInfo",af);
		}
		/// <summary>
		/// 更新公告内容
		/// </summary>
		/// <param name="af"></param>
		public void Update_afficheInfo(Affiche.em.affiche af)
		{
			Mapper.Instance().Update("Update_AreaInfo",af);
		}
		/// <summary>
		/// 删除公告
		/// </summary>
		/// <param name="id"></param>
		public void delete_afficheInfo(int id)
		{
			Mapper.Instance().Delete("delete_afficheInfo",id);
		}
	}
}
