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
using NrOA.Client.em;

namespace NrOA.Client.pkg
{
	/// <summary>
	/// DOClient 的摘要说明。
	/// </summary>
	public class DOClient
	{
		public DOClient()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 全部用户
		/// </summary>
		/// <returns></returns>
		public IList SelectAllClient()
		{
			return Mapper.Instance().QueryForList("SelectAllClient",null);
		}

		/// <summary>
		/// 根据小区名称查询用户列表
		/// </summary>
		/// <param name="AreaName"></param>
		/// <returns></returns>
		public IList SelectClient_byAreaName(string AreaName)
		{
			return Mapper.Instance().QueryForList("SelectClient_byAreaName",AreaName);
		}

		/// <summary>
		/// 根据小区名称查询用户列表
		/// </summary>
		/// <param name="AreaName"></param>
		/// <param name="state"></param>
		/// <param name="year"></param>
		/// <param name="sta_month"></param>
		/// <param name="end_month"></param>
		/// <returns></returns>
		public IList SelectClient_byAreaName(string AreaName,string state,string year,string sta_month,string end_month)
		{

			NrOA.Client.em.Client cl = new NrOA.Client.em.Client();
			cl.ClientState = state;
			cl.AreaName = AreaName;
			cl.Year = year;
			if(int.Parse(sta_month)>9)
			{
				cl.startMonth = sta_month;
			}
			else
			{
				cl.startMonth = "0"+sta_month;
			}
			if(int.Parse(end_month)>9)
			{
				cl.endMonth = end_month;
			}
			else
			{
				cl.endMonth = "0"+end_month;
			}
			return Mapper.Instance().QueryForList("SelectClient_byAreaName1",cl);
		}
		public IList SelectClient_byAreaName1(string AreaName,string state,string year,string sta_month,string end_month)
		{

			NrOA.Client.em.Client cl = new NrOA.Client.em.Client();
			cl.ClientState = state;
			cl.AreaName = AreaName;
			cl.Year = year;
			if(int.Parse(sta_month)>9)
			{
				cl.startMonth = sta_month;
			}
			else
			{
				cl.startMonth = "0"+sta_month;
			}
			if(int.Parse(end_month)>9)
			{
				cl.endMonth = end_month;
			}
			else
			{
				cl.endMonth = "0"+end_month;
			}
			return Mapper.Instance().QueryForList("SelectClient_byAreaName2",cl);
		}
		/// <summary>
		/// 根据输入信息模糊查询客户信息
		/// </summary>
		/// <param name="NameOrId">输入查询信息</param>
		/// <returns></returns>
		public IList SelectClientByFind(string NameOrId)
		{
			NameOrId = "%"+NameOrId+"%";
			return Mapper.Instance().QueryForList("SelectClientByFind",NameOrId);
		}
		/// <summary>
		/// 模糊查询全部小区
		/// </summary>
		/// <param name="NameOrId">查询字段</param>
		/// <param name="state">状态</param>
		/// <returns></returns>
		public IList SelectClientByFind(string NameOrId,string state)
		{
			NrOA.Client.em.Client cl = new NrOA.Client.em.Client();
			cl.ClientName = "%"+NameOrId+"%";
			cl.ClientState = state;
			return Mapper.Instance().QueryForList("SelectClientByFind",cl);
		}
		/// <summary>
		/// 模糊查询相关小区
		/// </summary>
		/// <param name="NameOrId">查询字段</param>
		/// <param name="state">状态</param>
		/// <param name="AreaName">小区编号</param>
		/// <returns></returns>
		public IList SelectClientByFind(string NameOrId,string state,string AreaName)
		{
			NrOA.Client.em.Client cl = new NrOA.Client.em.Client();
			cl.ClientName = "%"+NameOrId+"%";
			cl.ClientState = state;
			cl.AreaName = AreaName;
			return Mapper.Instance().QueryForList("SelectClientByFind1",cl);
		}

		/// <summary>
		/// 增加客户信息
		/// </summary>
		/// <param name="CI"></param>
		public void InsertClientList(NrOA.Client.em.Client CI)
		{			
			Mapper.Instance().Insert("InsertClientList",CI);			
		}
		/// <summary>
		/// 更新客户信息
		/// </summary>
		/// <param name="CI"></param>
		public void updateClientList(NrOA.Client.em.Client CI)
		{			
			Mapper.Instance().Update("updateClientList",CI);			
		}
		/// <summary>
		/// 根据编号查询客户信息
		/// </summary>
		/// <param name="id">客户编号</param>
		public IList SelectClient_by_id(int id)
		{
			return Mapper.Instance().QueryForList("SelectClient_by_id",id);
		}
		/// <summary>
		/// 更新客户状态
		/// </summary>
		/// <param name="CI"></param>
		public void upateClientstate(NrOA.Client.em.Client CI)
		{
			Mapper.Instance().Update("upateClientstate",CI);
		}
		/// <summary>
		/// 根据客户业务号查询客户信息
		/// </summary>
		/// <param name="opid"></param>
		/// <returns></returns>
		public IList selectClient_by_opid(string opid)
		{
			return Mapper.Instance().QueryForList("selectClient_by_opid",opid);
		}
		/// <summary>
		/// 根据小区获取该小区最大序号
		/// </summary>
		/// <param name="Area_id">小区编号</param>
		/// <returns></returns>
		public string selectClient_Arae_by_MaxClistid(string Area_id)
		{
			IList list = null;
			list = Mapper.Instance().QueryForList("selectClient_Arae_by_MaxClistid",Area_id);
			string ss = ((NrOA.Client.em.Client)(list)[0]).ClientListID;
			int sum = 0;
			if(ss == null)
			{
				sum = 0;
			}
			else
			{
				sum = int.Parse(((NrOA.Client.em.Client)(list)[0]).ClientListID.ToString().Trim());
			}
			sum = sum+1;
			return sum.ToString();
		}
		/// <summary>
		/// 根据编号删除用户
		/// </summary>
		/// <param name="id"></param>
		public void deleteClient_by_id(string id)
		{
			Mapper.Instance().Delete("deleteClient_by_id",id);
		}
		/// <summary>
		/// 竣工为空
		/// </summary>
		/// <returns></returns>
		public IList selecjgwk()
		{
			return Mapper.Instance().QueryForList("selecjgwk",null);
		}
		/// <summary>
		/// 根据状态查询用户列表
		/// </summary>
		/// <param name="state"></param>
		/// <returns></returns>
		public IList Client_by_state(string state)
		{
			return Mapper.Instance().QueryForList("Client_by_state",state);
		}
	}
}
