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
using NrOA.Area.em;

namespace NrOA.Area.pkg
{
	/// <summary>
	/// DOArea 的摘要说明。
	/// </summary>
	public class DOArea
	{
		public DOArea()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 给出最大编号
		/// </summary>
		/// <returns></returns>
		public int AreaMaxID()
		{
			int id = -1;
			id = ((NrOA.Area.em.Area)(Mapper.Instance().QueryForList("AreaMaxID",null))[0]).Area_ID+1;
			return id;
		}
		/// <summary>
		/// 查询全部未注销小区
		/// </summary>
		/// <returns></returns>
		public IList SelectAreaAll_LoginIn(string Area_state)
		{
			return Mapper.Instance().QueryForList("SelectAreaAll_LoginIn1",Area_state);
		}
		/// <summary>
		/// 查询全部未注销小区
		/// </summary>
		/// <returns></returns>
		public IList SelectAreaAll_LoginIn()
		{
			return Mapper.Instance().QueryForList("SelectAreaAll_LoginIn",null);
		}
		/// <summary>
		/// 查询全部未注销小区(倒序输出)
		/// </summary>
		/// <returns></returns>
		public IList SelectAreaAll()
		{
			return Mapper.Instance().QueryForList("SelectAreaAll",null);
		}

		/// <summary>
		/// 根据小区编号选择小区信息
		/// </summary>
		/// <param name="Area_ID">小区编号</param>
		/// <returns></returns>
		public IList SelectArea_By_ID(int Area_ID)
		{
			return Mapper.Instance().QueryForList("SelectArea_By_ID",Area_ID);
		}
		/// <summary>
		/// 改变小区的状态
		/// </summary>
		/// <param name="Ar">小区信息</param>
		public void Area_State_Change(NrOA.Area.em.Area Ar)
		{
			Mapper.Instance().Update("Area_State_Change",Ar);
		}
		/// <summary>
		/// 新增小区信息
		/// </summary>
		/// <param name="Ar">小区信息</param>
		public void InsertAreaInfo(NrOA.Area.em.Area Ar)
		{
			Ar.Area_ID = AreaMaxID();
			Mapper.Instance().Insert("InsertAreaInfo",Ar);
		}
		/// <summary>
		/// 跟新小区信息
		/// </summary>
		/// <param name="Ar"></param>
		public void Update_AreaInfo(NrOA.Area.em.Area Ar)
		{
			Mapper.Instance().Update("Update_AreaInfo",Ar);
		}
	}
}
