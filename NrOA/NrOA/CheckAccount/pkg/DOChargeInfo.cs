
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


namespace NrOA.CheckAccount.pkg
{
	/// <summary>
	/// DOChargeInfo 的摘要说明。
	/// </summary>
	public class DOChargeInfo
	{

		public DOChargeInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 新增一次性信息
		/// </summary>
		/// <param name="ci"></param>
		public void AddOneOffConnectFeesList(NrOA.CheckAccount.em.ChargeInfo ci)
		{
			Mapper.Instance().Insert("AddOneOffConnectFeesList",ci);
		}
		/// <summary>
		/// 新增年结信息
		/// </summary>
		/// <param name="ci"></param>
		public void FirstPaymentList(NrOA.CheckAccount.em.ChargeInfo ci)
		{
			Mapper.Instance().Insert("FirstPaymentList",ci);
		}
		/// <summary>
		/// 新增月回款收费信息
		/// </summary>
		/// <param name="ci"></param>
		public void BackMonthPay(NrOA.CheckAccount.em.ChargeInfo ci)
		{
			Mapper.Instance().Insert("BackMonthPay",ci);
		}
		/// <summary>
		/// 根据条件查询
		/// </summary>
		/// <param name="Year">年份</param>
		/// <param name="startMonth">开始月份</param>
		/// <param name="endMonth">结束月份</param>
		/// <param name="Area_id">小区编号 （-请选择小区-） 全部小区</param>
		/// <param name="Find_id">查找id 1-未回款用户 2-年结分成比例出错 3-接入费缴费用户 4-迁移费缴费用户 5-年结列表 6-一次性列表 7-回款/月结列表 8-月结分成比例错误 9-一次性分成比例错误</param>
		/// <returns></returns>
		public IList Find_List(string Year,string startMonth,string endMonth,string Area_id,int Find_id)
		{
			IList list = null;
			NrOA.CheckAccount.em.ChargeInfo CI = new NrOA.CheckAccount.em.ChargeInfo();

			CI.Year = Year;
			CI.startMonth = startMonth;
			CI.endMonth = endMonth;

			if(Area_id!="-请选择小区-")
			{
				CI.Area_ID = Area_id;
			}

			if(Find_id==1)
			{
				//未回款用户
				list = Mapper.Instance().QueryForList("",CI);
			}
			else if(Find_id==2)
			{
				//年结分成比例出错
				list = Mapper.Instance().QueryForList("Find_NJFCBICW",CI);
			}
			else if(Find_id==3)
			{
				//接入费缴费用户
				list = Mapper.Instance().QueryForList("Find_JRFJFYH",CI);
			}
			else if(Find_id==4)
			{
				//迁移费缴费用户
				list = Mapper.Instance().QueryForList("Find_QYFJFYH",CI);
			}
			else if(Find_id==5)
			{
				//年结列表
				list = Mapper.Instance().QueryForList("Find_NJLB",CI);
			}
			else if(Find_id==6)
			{
				//一次性列表
				list = Mapper.Instance().QueryForList("Find_YCXLB",CI);
			}
			else if(Find_id==7)
			{
				//回款/月结列表
				list = Mapper.Instance().QueryForList("Find_HKLB",CI);
			}
			else if(Find_id==8)
			{
				//月结分成比例错误
				list = Mapper.Instance().QueryForList("Find_HKDCBLCW",CI);
			}
			else if(Find_id==9)
			{
				//一次性分成比例错误
				list = Mapper.Instance().QueryForList("Find_YCXFCBLCW",CI);
			}

			return list;
		}

		/// <summary>
		/// 根据编号查询年结信息
		/// </summary>
		/// <param name="id">编号</param>
		/// <returns></returns>
		public IList selectCharge_by_id(int id)
		{
			return Mapper.Instance().QueryForList("selectCharge_by_id",id);
		}

		/// <summary>
		/// 更新年结信息
		/// </summary>
		/// <param name="ci"></param>
		public void Update_Charge_year(NrOA.CheckAccount.em.ChargeInfo ci)
		{
			Mapper.Instance().Update("Update_Charge_year",ci);
		}
		/// <summary>
		///更新一次性 迁移费 
		/// </summary>
		/// <param name="ci"></param>
		public void Update_Charge_one_0r_move(NrOA.CheckAccount.em.ChargeInfo ci)
		{
			Mapper.Instance().Update("Update_Charge_one_0r_move",ci);
		}

		/// <summary>
		/// 更新月结/回款
		/// </summary>
		/// <param name="ci"></param>
		public void Update_Charge_BackMonthPay(NrOA.CheckAccount.em.ChargeInfo ci)
		{
			Mapper.Instance().Update("Update_Charge_BackMonthPay",ci);
		}

		public void delete_Charge_ID(int id)
		{
			Mapper.Instance().Delete("delete_Charge_ID",id);
		}
		/// <summary>
		/// 根据条件查询对应的回款用户
		/// </summary>
		/// <param name="year">年</param>
		/// <param name="month">月</param>
		/// <param name="arae">地区</param>
		/// <param name="state">状态</param>
		/// <param name="str">模糊查询条件</param>
		/// <returns></returns>
		public IList SelectChargeinfo_list(string year,string month,string arae,string state,string str)
		{
			NrOA.CheckAccount.em.ChargeInfo ci = new NrOA.CheckAccount.em.ChargeInfo();
			NrOA.Client.pkg.DOClient dc = new NrOA.Client.pkg.DOClient();
			ci.Year = year;
			ci.startMonth = month;
			ci.Area_ID = arae;
			ci.state = state;
			ci.str = "%"+str+"%";
			IList list = null;

			if(month=="0"&&arae=="所有小区"&&state=="0"&&str=="")
			{
				list = dc.SelectAllClient();
			}
			else if(month!="0"&&arae=="所有小区"&&state=="0"&&str=="")
			{
				//对应月份有回款用户
				list = Mapper.Instance().QueryForList("selectChargeinfo_by_month",ci);
			}
			else if(month=="0"&&arae!="所有小区"&&state=="0"&&str=="")
			{
				list =dc.SelectClient_byAreaName(arae);
			}
			else if(month=="0"&&arae=="所有小区"&&state!="0"&&str=="")
			{
				if(state=="1")
				{
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_poundagewrong",year);
				}
				else if(state=="2")
				{
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_no_pay_year",year);
				}
			}
			else if(month=="0"&&arae=="所有小区"&&state=="0"&&str!="")
			{
				list =Mapper.Instance().QueryForList("selectChargeinfo_by_str",ci);
			}
			else if(month!="0"&&arae!="所有小区"&&state=="0"&&str=="")
			{
				list =Mapper.Instance().QueryForList("selectChargeinfo_by_MA",ci);
			}
			else if(month!="0"&&arae=="所有小区"&&state!="0"&&str=="")
			{
				if(state=="1")
				{
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_MS",ci);
				}
			}
			else if(month!="0"&&arae=="所有小区"&&state=="0"&&str!="")
			{
				list =Mapper.Instance().QueryForList("selectChargeinfo_by_MStr",ci);
			}
			else if(month=="0"&&arae!="所有小区"&&state!="0"&&str=="")
			{
				if(state=="1")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_AS1",ci);
				else if(state=="2")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_AS2",ci);
			}
			else if(month=="0"&&arae!="所有小区"&&state=="0"&&str!="")
			{
				list =Mapper.Instance().QueryForList("selectChargeinfo_by_AStr",ci);
			}
			else if(month=="0"&&arae=="所有小区"&&state!="0"&&str!="")
			{
				if(state=="1")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_SS1",ci);
				else if(state=="2")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_SS2",ci);
			}
			else if(month!="0"&&arae!="所有小区"&&state!="0"&&str=="")
			{
				if(state=="1")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_MAS1",ci);
//				else if(state=="2")
//					list =Mapper.Instance().QueryForList("selectChargeinfo_by_MAS2",ci);
			}
			else if(month!="0"&&arae!="所有小区"&&state=="0"&&str!="")
			{
				list =Mapper.Instance().QueryForList("selectChargeinfo_by_MAStr",ci);
			}
			else if(month!="0"&&arae=="所有小区"&&state!="0"&&str!="")
			{
				if(state=="1")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_MSS1",ci);
			}
			else if(month=="0"&&arae!="所有小区"&&state!="0"&&str!="")
			{
				if(state=="1")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_ASS1",ci);
				else if(state=="2")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_ASS2",ci);
			}
			else if(month!="0"&&arae!="所有小区"&&state!="0"&&str!="")
			{
				if(state=="1")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_MASS1",ci);
			}			
			return list;
		}
		/// <summary>
		/// 根据条件查询对应的回款用户
		/// </summary>
		/// <param name="year">年</param>
		/// <param name="month">月</param>
		/// <param name="arae">地区</param>
		/// <param name="state">状态</param>
		/// <param name="str">模糊查询条件</param>
		/// <returns></returns>
		public IList SelectChargeinfo_list1(string year,string month,string arae,string state,string str,string year1)
		{
            IList list = null;
			NrOA.CheckAccount.em.ChargeCollect cc = new NrOA.CheckAccount.em.ChargeCollect();
			cc.area_id = arae;
			cc.state = state;
			cc.str = "%"+str+"%";
			cc.year = year;
			cc.month = month;

			cc.year1 = year1;
			if(month=="0")
			{
				if(arae=="所有小区"&&str==""&&state=="0")
				{
					//某年
					list = Mapper.Instance().QueryForList("ChargeCollectlist0_1",cc);
				}
				else if(arae!="所有小区"&&str==""&&state=="0")
				{
					//某年某小区
					list = Mapper.Instance().QueryForList("ChargeCollectlist0_2",cc);
				}

				else if(arae=="所有小区"&&str!=""&&state=="0")
				{
					//某年模糊查询
					list = Mapper.Instance().QueryForList("ChargeCollectlist0_3",cc);
				}
				else if(arae=="所有小区"&&str==""&&state!="0")
				{
					if(state=="1")
					{
						//某年分成比例出错
						list = Mapper.Instance().QueryForList("ChargeCollectlist0_4_1",cc);
					}
					else if(state=="2")//某年全年无回款 
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_4_2",cc);}
					else if(state=="3")//某年竣工 
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_4_3",cc);}
				}
				else if(arae!="所有小区"&&str==""&&state!="0")
				{
					//某年分成比例出错 小区
					if(state=="1")
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_5_1",cc);}
					else if(state=="2")//某年全年无回款 小区
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_5_2",cc);}
					else if(state=="3")//某年某小区竣工
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_5_3",cc);}
				}
				else if(arae!="所有小区"&&str!=""&&state=="0")
				{
					//全年模糊
					list = Mapper.Instance().QueryForList("ChargeCollectlist0_6",cc);
				}
				else if(arae=="所有小区"&&str!=""&&state!="0")
				{
					if(state=="1")//某年分成比例出错 模糊
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_7_1",cc);}
					else if(state=="2")//某年全年无回款 模糊
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_7_2",cc);}
					else if(state=="3")//某年全年 模糊
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_7_3",cc);}
				}
				else if(arae!="所有小区"&&str!=""&&state!="0")
				{
					if(state=="1")//某年分成比例出错 模糊 小区
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_8_1",cc);}
					else if(state=="2")//某年全年无回款 模糊 小区
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_8_2",cc);}
					else if(state=="3")//某年全年回款 模糊 小区
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_8_3",cc);}
				}
			}
			else if(month!="0")
			{
				if(arae=="所有小区"&&str==""&&state=="0")
				{
					//某年某月份
					list = Mapper.Instance().QueryForList("ChargeCollectlist1_1",cc);
				}
				else if(arae!="所有小区"&&str==""&&state=="0")
				{
					//某年某月份某小区
					list = Mapper.Instance().QueryForList("ChargeCollectlist1_2",cc);
				}
				else if(arae=="所有小区"&&str!=""&&state=="0")
				{
					//某年1月份模糊查询（业务号、名称）
					list = Mapper.Instance().QueryForList("ChargeCollectlist1_3",cc);
				}
				else if(arae=="所有小区"&&str==""&&state!="0")
				{
					if(state=="1")
					{
						//某年某月份状态1-分成比例出错
						list = Mapper.Instance().QueryForList("ChargeCollectlist1_4_1",cc);
					}
					else if(state=="3")
					{
						//某年某月份状态3-根据开通为某年月的查询对应回款信息
						if(int.Parse(month)<10)
						{
							cc.month = "0"+month;
						}
						try
						{
							list = Mapper.Instance().QueryForList("ChargeCollectlist1_4_2",cc);
						}
						catch{list = null;}
					}
				}
				else if(arae!="所有小区"&&str!=""&&state=="0")
				{
					//某年某月份某小区模糊查询
					list = Mapper.Instance().QueryForList("ChargeCollectlist1_5",cc);
				}
				else if(arae!="所有小区"&&str==""&&state!="0")
				{
					if(state=="1")
					{
						//某年某月份某小区状态1-分成比例出错
						list = Mapper.Instance().QueryForList("ChargeCollectlist1_6_1",cc);
					}
					else if(state=="3")
					{
						if(int.Parse(month)<10)
						{
							cc.month = "0"+month;
						}
						//某年某月份某小区状态3-根据开通为某年月的查询对应回款信息
						//由于查询语句没有对应到年份出现 08-09年都列出来的问题
						try
						{
							list = Mapper.Instance().QueryForList("ChargeCollectlist1_6_2",cc);
						}
						catch{list = null;}
					}
				}
				else if(arae=="所有小区"&&str!=""&&state!="0")
				{
					if(state=="1")
					{
						//某年某月份模糊查询状态1-分成比例出错
						list = Mapper.Instance().QueryForList("ChargeCollectlist1_7_1",cc);
					}
					else if(state=="3")
					{
						if(int.Parse(month)<10)
						{
							cc.month = "0"+month;
						}
						//某年某月份模糊查询状态3-根据开通为1月的查询对应回款信息
						try
						{
							list = Mapper.Instance().QueryForList("ChargeCollectlist1_7_2",cc);
						}
						catch{list = null;}
					}
				}
				else if(arae!="0"&&str!=""&&state!="0")
				{
					if(state=="1")
					{
						//某年某月份模糊查询小区状态1-分成比例出错
						list = Mapper.Instance().QueryForList("ChargeCollectlist1_8_1",cc);
					}
					else if(state=="3")
					{
						if(int.Parse(month)<10)
						{
							cc.month = "0"+month;
						}
						//某年某月份模糊查询小区状态3-根据开通为1月的查询对应回款信息
						try
						{
							list = Mapper.Instance().QueryForList("ChargeCollectlist1_8_2",cc);
						}
						catch{list = null;}
					}
				}
			}			
			return list;
		}
		/// <summary>
		/// 根据业务号、年份、月份查询回款信息
		/// </summary>
		/// <param name="ClientOperationID">业务号</param>
		/// <param name="month">月份</param>
		/// <param name="state">结款类型</param>
		/// <param name="year">年份</param>
		/// <returns></returns>
		public IList selectpay_info(string ClientOperationID,string year,string month,string state)
		{
			IList list = null;
			NrOA.CheckAccount.em.ChargeInfo ci = new NrOA.CheckAccount.em.ChargeInfo();
			ci.ClientOperationID = ClientOperationID;
			ci.Payment_by_Year = year;
			ci.Payment_by_Month = month;

			if(state=="年结")
			{
				list = Mapper.Instance().QueryForList("selectpay_infonj",ci);
			}
			else if(state=="月结")
			{
				list = Mapper.Instance().QueryForList("selectpay_infoyj",ci);
			}
			else if(state=="一次性")
			{
				list = Mapper.Instance().QueryForList("selectpay_infoycx",ci);
			}
			else if(state=="迁移费")
			{
				list = Mapper.Instance().QueryForList("selectpay_infoqyf",ci);
			}
			return list;
		}
		/// <summary>
		/// 按年月删除对应的收费信息
		/// </summary>
		/// <param name="year"></param>
		/// <param name="month"></param>
		public void delete_Chargeinfo_by_YearAndMonth(string year,string month)
		{
			NrOA.CheckAccount.em.ChargeInfo ci = new NrOA.CheckAccount.em.ChargeInfo();
			ci.Payment_by_Year = year;
			ci.Payment_by_Month = month;
			Mapper.Instance().Delete("delete_Chargeinfo_by_YearAndMonth",ci);
		}
		/// <summary>
		/// 没有对应到用户收费
		/// </summary>
		/// <param name="year"></param>
		/// <param name="month"></param>
		/// <param name="sta"></param>
		/// <returns></returns>
		public IList jfnotintlist(string year,string month,string sta)
		{
			NrOA.CheckAccount.em.ChargeInfo ci = new NrOA.CheckAccount.em.ChargeInfo();
			ci.Payment_by_Year = year;
			ci.Payment_by_Month = month;
			ci.str = "%"+sta+"%";
			IList list = null;
			if(month=="0"&&sta=="")
			{
				list =Mapper.Instance().QueryForList("jfnotintlist1",ci);
			}
			else if(month!="0"&&sta=="")
			{
				list =Mapper.Instance().QueryForList("jfnotintlist2",ci);
			}
			else if((month=="0"&&sta!=""))
			{
				list =Mapper.Instance().QueryForList("jfnotintlist3",ci);
			}
			else if((month!="0"&&sta!=""))
			{
				list = Mapper.Instance().QueryForList("jfnotintlist4",ci);
			}
			return list;
		}
		public void updateClientOperationID(NrOA.CheckAccount.em.ChargeInfo cc)
		{
			Mapper.Instance().Update("updateClientOperationID",cc);
		}

		/// <summary>
		/// 查询状态
		/// </summary>
		/// <param name="state">状态</param>
		/// <returns></returns>
		public IList select_Chargeinfostate(string state)
		{
			return Mapper.Instance().QueryForList("select_Chargeinfostate",state);
		}
		/// <summary>
		/// 负值列表查询
		/// </summary>
		/// <param name="year"></param>
		/// <param name="month"></param>
		/// <param name="sta"></param>
		/// <returns></returns>
		public IList fzlist(string year,string month,string sta)
		{
			NrOA.CheckAccount.em.ChargeInfo ci = new NrOA.CheckAccount.em.ChargeInfo();
			ci.Payment_by_Year = year;
			ci.Payment_by_Month = month;
			ci.str = "%"+sta+"%";
			IList list = null;
			if(month=="0"&&sta=="")
			{
				list =Mapper.Instance().QueryForList("fzlist1",ci);
			}
			else if(month!="0"&&sta=="")
			{
				list =Mapper.Instance().QueryForList("fzlist2",ci);
			}
			else if((month=="0"&&sta!=""))
			{
				list =Mapper.Instance().QueryForList("fzlist3",ci);
			}
			else if((month!="0"&&sta!=""))
			{
				list = Mapper.Instance().QueryForList("fzlist4",ci);
			}
			return list;
		}
		/// <summary>
		/// 根据 用户名和用户业务号模糊查询
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public IList select_ChargeStr(string str)
		{

			str = "%"+str+"%";
			return Mapper.Instance().QueryForList("select_ChargeStr",str);
		}
		/// <summary>
		/// 删除整理的对帐信息中已注销用户
		/// </summary>
		/// <param name="ClientOperationID"></param>
		public void delete_ChargeCollect(string ClientOperationID)
		{
			Mapper.Instance().Delete("delete_ChargeCollect",ClientOperationID);
		}
	}
}
