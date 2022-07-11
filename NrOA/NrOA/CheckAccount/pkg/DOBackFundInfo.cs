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
	/// DOBackFundInfo 的摘要说明。
	/// </summary>
	public class DOBackFundInfo
	{
		public DOBackFundInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 新增回款
		/// </summary>
		/// <param name="bfi"></param>
		public void BackFundInfoList(NrOA.CheckAccount.em.BackFundInfo bfi)
		{
			Mapper.Instance().Insert("BackFundInfoList",bfi);
		}
		/// <summary>
		/// 更新回款
		/// </summary>
		/// <param name="bfi"></param>
		public void update_BackFundInfoList(NrOA.CheckAccount.em.BackFundInfo bfi)
		{
			Mapper.Instance().Update("update_BackFundInfoList",bfi);
		}
		/// <summary>
		/// 查询回款汇总列表
		/// </summary>
		/// <param name="year">年</param>
		/// <param name="ClientOperationID">业务号</param>
		/// <returns></returns>
		public IList ClientintCharge(string year,string ClientOperationID)
		{
			NrOA.CheckAccount.em.ChargeCollect cc = new NrOA.CheckAccount.em.ChargeCollect();
			cc.ClientOperationID = ClientOperationID;
			cc.year = year;
			return Mapper.Instance().QueryForList("ClientintCharge",cc);
		}
		/// <summary>
		/// 更新回款汇总列表
		/// </summary>
		/// <param name="cc"></param>
		public void updateClientintChargel(NrOA.CheckAccount.em.ChargeCollect cc)
		{
			Mapper.Instance().Update("updateClientintChargel",cc);
		}
		/// <summary>
		/// 新增回款汇总信息
		/// </summary>
		/// <param name="cc"></param>
		public void insertClientintChargel(NrOA.CheckAccount.em.ChargeCollect cc)
		{
			Mapper.Instance().Insert("insertClientintChargel",cc);
		}
		/// <summary>
		/// 整理对应年份数据
		/// </summary>
		/// <param name="year"></param>
		public void Putint_T_ChargeCollect(string year)
		{
			//查询全部的用户及对应年份数据
			NrOA.Client.pkg.DOClient dc = new NrOA.Client.pkg.DOClient();
			NrOA.CheckAccount.pkg.DOBackFundInfo dobfi = new NrOA.CheckAccount.pkg.DOBackFundInfo();
			NrOA.Area.pkg.DOArea DoA = new NrOA.Area.pkg.DOArea();

			//删除状态为 0 的
			//dobfi.deleteChargeCollect_by_year_state( year, state);
			IList Cllist = null;
			IList ClientintChargellist = null;
			Cllist = dc.SelectAllClient();
			if(Cllist!=null)
			{
				for(int i=0;i<Cllist.Count;i++)
				{
					string cid = "";
					try
					{
						cid = ((NrOA.Client.em.Client)(Cllist)[i]).ClientOperationID;
					}
					catch{cid = "";}
					//根据用户号，年份查询是否已经存在
					if(cid!="")
					{
						ClientintChargellist = dobfi.ClientintCharge(year,cid);
					}
					else
					{
						ClientintChargellist = null;
					}
					if(ClientintChargellist!=null)
					{
						NrOA.CheckAccount.em.ChargeCollect cc = new NrOA.CheckAccount.em.ChargeCollect();
						cc.ClientOperationID = cid;
						cc.Poundage = ((NrOA.Area.em.Area)(DoA.SelectArea_By_ID(int.Parse(((NrOA.Client.em.Client)(Cllist)[i]).AreaName)))[0]).Poundage;
						for(int n=1;n<13;n++)
						{
							this.hkinfo(cid,year,n.ToString(),"一次性");
							if(ycxPoundage!="0"&&ycxValue!="0")
							{
								cc.OneOffConnectFees = ycxValue;
								cc.OMPoundage = ycxPoundage;
								cc.MovePay ="0";
								break;
							}
							else
							{
								cc.OneOffConnectFees = "0";
							}
							this.hkinfo(cid,year,n.ToString(),"迁移费");
							if(ycxPoundage!="0"&&ycxValue!="0")
							{
								cc.MovePay = ycxValue;
								cc.OMPoundage = ycxPoundage;
								break;
							}
							else
							{
								cc.MovePay = "0";
								cc.OMPoundage ="0";
							}
						}

						this.hkinfo(cid,year,"1","年结");
						if(Poundage!="0"&&Value!="0")
						{
							cc.oneyue = Value;
							cc.onePoundage = Poundage;
						}
						else
						{
							cc.oneyue = "0";
							cc.onePoundage = "0";
						}
						if(cc.oneyue == "0")
						{
							this.hkinfo(cid,year,"1","月结");
							if(Poundage!="0"&&Value!="0")
							{
								cc.oneyue = Value;
								cc.onePoundage = Poundage;
							}
							else
							{
								cc.oneyue = "0";
								cc.onePoundage = "0";
							}
						}
						this.hkinfo(cid,year,"2","年结");
						if(Poundage!="0"&&Value!="0")
						{
							cc.twoyue = Value;
							cc.twoPoundage = Poundage;
						}
						else
						{
							cc.twoyue = "0";
							cc.twoPoundage = "0";
						}
						if(cc.twoyue == "0")
						{
							this.hkinfo(cid,year,"2","月结");
							if(Poundage!="0"&&Value!="0")
							{
								cc.twoyue = Value;
								cc.twoPoundage = Poundage;
							}
							else
							{
								cc.twoyue = "0";
								cc.twoPoundage = "0";
							}
						}
						this.hkinfo(cid,year,"3","年结");
						if(Poundage!="0"&&Value!="0")
						{
							cc.threeyue = Value;
							cc.threePoundage = Poundage;
						}
						else
						{
							cc.threeyue = "0";
							cc.threePoundage = "0";
						}
					
						if(cc.threeyue == "0")
						{
							this.hkinfo(cid,year,"3","月结");
							if(Poundage!="0"&&Value!="0")
							{
								cc.threeyue = Value;
								cc.threePoundage = Poundage;
							}
							else
							{
								cc.threeyue = "0";
								cc.threePoundage = "0";
							}
						}
						this.hkinfo(cid,year,"4","年结");
						if(Poundage!="0"&&Value!="0")
						{
							cc.fouryue = Value;
							cc.fourPoundage = Poundage;
						}
						else
						{
							cc.fouryue = "0";
							cc.fourPoundage = "0";
						}
						if(cc.fouryue == "0")
						{
							this.hkinfo(cid,year,"4","月结");
							if(Poundage!="0"&&Value!="0")
							{
								cc.fouryue = Value;
								cc.fourPoundage = Poundage;
							}
							else
							{
								cc.fouryue = "0";
								cc.fourPoundage = "0";
							}
						}
						this.hkinfo(cid,year,"5","年结");
						if(Poundage!="0"&&Value!="0")
						{
							cc.fiveyue = Value;
							cc.fivePoundage = Poundage;
						}
						else
						{
							cc.fiveyue = "0";
							cc.fivePoundage = "0";
						}
						if(cc.fiveyue == "0")
						{
							this.hkinfo(cid,year,"5","月结");
							if(Poundage!="0"&&Value!="0")
							{
								cc.fiveyue = Value;
								cc.fivePoundage = Poundage;
							}
							else
							{
								cc.fiveyue = "0";
								cc.fivePoundage = "0";
							}
						}
						this.hkinfo(cid,year,"6","年结");
						if(Poundage!="0"&&Value!="0")
						{
							cc.sixyue = Value;
							cc.sixPoundage = Poundage;
						}
						else
						{
							cc.sixyue = "0";
							cc.sixPoundage = "0";
						}
						if(cc.sixyue == "0")
						{
							this.hkinfo(cid,year,"6","月结");
							if(Poundage!="0"&&Value!="0")
							{
								cc.sixyue = Value;
								cc.sixPoundage = Poundage;
							}
							else
							{
								cc.sixyue = "0";
								cc.sixPoundage = "0";
							}
						}
						this.hkinfo(cid,year,"7","年结");
						if(Poundage!="0"&&Value!="0")
						{
							cc.sevenyue = Value;
							cc.sevenPoundage = Poundage;
						}
						else
						{
							cc.sevenyue = "0";
							cc.sevenPoundage = "0";
						}
						if(cc.sevenyue == "0")
						{
							this.hkinfo(cid,year,"7","月结");
							if(Poundage!="0"&&Value!="0")
							{
								cc.sevenyue = Value;
								cc.sevenPoundage = Poundage;
							}
							else
							{
								cc.sevenyue = "0";
								cc.sevenPoundage = "0";
							}
						}
						this.hkinfo(cid,year,"8","年结");
						if(Poundage!="0"&&Value!="0")
						{
							cc.eightyue = Value;
							cc.eightPoundage = Poundage;
						}
						else
						{
							cc.eightyue = "0";
							cc.eightPoundage = "0";
						}
						if(cc.eightyue == "0")
						{
							this.hkinfo(cid,year,"8","月结");
							if(Poundage!="0"&&Value!="0")
							{
								cc.eightyue = Value;
								cc.eightPoundage = Poundage;
							}
							else
							{
								cc.eightyue = "0";
								cc.eightPoundage = "0";
							}
						}
						this.hkinfo(cid,year,"9","年结");
						if(Poundage!="0"&&Value!="0")
						{
							cc.nineyue = Value;
							cc.ninePoundage = Poundage;
						}
						else
						{
							cc.nineyue = "0";
							cc.ninePoundage = "0";
						}
						if(cc.nineyue == "0")
						{
							this.hkinfo(cid,year,"9","月结");
							if(Poundage!="0"&&Value!="0")
							{
								cc.nineyue = Value;
								cc.ninePoundage = Poundage;
							}
							else
							{
								cc.nineyue = "0";
								cc.ninePoundage = "0";
							}
						}
						this.hkinfo(cid,year,"10","年结");
						if(Poundage!="0"&&Value!="0")
						{
							cc.tenyue = Value;
							cc.tenPoundage = Poundage;
						}
						else
						{
							cc.tenyue = "0";
							cc.tenPoundage = "0";
						}
						if(cc.tenyue == "0")
						{
							this.hkinfo(cid,year,"10","月结");
							if(Poundage!="0"&&Value!="0")
							{
								cc.tenyue = Value;
								cc.tenPoundage = Poundage;
							}
							else
							{
								cc.tenyue = "0";
								cc.tenPoundage = "0";
							}
						}
						this.hkinfo(cid,year,"11","年结");
						if(Poundage!="0"&&Value!="0")
						{
							cc.elevenyue = Value;
							cc.elevenPoundage = Poundage;
						}
						else
						{
							cc.elevenyue = "0";
							cc.elevenPoundage = "0";
						}
						if(cc.elevenyue == "0")
						{
							this.hkinfo(cid,year,"11","月结");
							if(Poundage!="0"&&Value!="0")
							{
								cc.elevenyue = Value;
								cc.elevenPoundage = Poundage;
							}
							else
							{
								cc.elevenyue = "0";
								cc.elevenPoundage = "0";
							}
						}
						this.hkinfo(cid,year,"12","年结");
						if(Poundage!="0"&&Value!="0")
						{
							cc.twelveyue = Value;
							cc.twelvePoundage = Poundage;
						}
						else
						{
							cc.twelveyue = "0";
							cc.twelvePoundage = "0";
						}
						if(cc.twelveyue == "0")
						{
							this.hkinfo(cid,year,"12","月结");
							if(Poundage!="0"&&Value!="0")
							{
								cc.twelveyue = Value;
								cc.twelvePoundage = Poundage;
							}
							else
							{
								cc.twelveyue = "0";
								cc.twelvePoundage = "0";
							}
						}

						cc.remark = "";
						cc.year = year;
						
						try
						{
							cc.area_id = ((NrOA.Client.em.Client)(Cllist)[i]).AreaName;
						}
						catch
						{
							cc.area_id = "66";
						}
						
						if(ClientintChargellist.Count>0)//存在则更新对应月的数据。
						{
							
							cc.id = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).id;
							cc.state = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).state;
							string OneOffConnectFees="";
							string MovePay="";
							try
							{
								OneOffConnectFees=((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).OneOffConnectFees.ToString();
							}
							catch{OneOffConnectFees="";}
							try
							{
								MovePay=((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).MovePay.ToString();
							}
							catch{MovePay="";}
							if(((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).OneOffConnectFees!="0")
							{
								if(OneOffConnectFees!="")
								{
									cc.OneOffConnectFees = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).OneOffConnectFees;
									cc.OMPoundage = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).OMPoundage;
								}
							}
							else if(((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).MovePay!="0")
							{
								if(MovePay!="")
								{
									cc.MovePay = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).MovePay;
									cc.OMPoundage = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).OMPoundage;
								}
							}


							if(((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).oneyue!="0")
							{
								cc.oneyue = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).oneyue;
								cc.onePoundage = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).onePoundage;
							}
							else if(((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).twoyue!="0")
							{
								cc.twoyue = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).twoyue;
								cc.twoPoundage = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).twoPoundage;
							}
							else if(((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).threeyue!="0")
							{
								cc.threeyue = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).threeyue;
								cc.threePoundage = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).threePoundage;
							}
							else if(((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).fouryue!="0")
							{
								cc.fouryue = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).fouryue;
								cc.fourPoundage = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).fourPoundage;
							}
							else if(((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).fiveyue!="0")
							{
								cc.fiveyue = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).fiveyue;
								cc.fivePoundage = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).fivePoundage;
							}
							else if(((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).sixyue!="0")
							{
								cc.sixyue = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).sixyue;
								cc.sixPoundage = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).sixPoundage;
							}
							else if(((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).sevenyue!="0")
							{
								cc.sevenyue = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).sevenyue;
								cc.sevenPoundage = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).sevenPoundage;
							}
							else if(((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).eightyue!="0")
							{
								cc.eightyue = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).eightyue;
								cc.eightPoundage = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).eightPoundage;
							}
							else if(((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).nineyue!="0")
							{
								cc.nineyue = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).nineyue;
								cc.ninePoundage = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).ninePoundage;
							}
							else if(((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).tenyue!="0")
							{
								cc.tenyue = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).tenyue;
								cc.tenPoundage = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).tenPoundage;
							}
							else if(((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).elevenyue!="0")
							{
								cc.elevenyue = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).elevenyue;
								cc.elevenPoundage = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).elevenPoundage;
							}
							else if(((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).twelveyue!="0")
							{
								cc.twelveyue = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).twelveyue;
								cc.twelvePoundage = ((NrOA.CheckAccount.em.ChargeCollect)(ClientintChargellist)[0]).twelvePoundage;
							}

							dobfi.updateClientintChargel(cc);
						}
						else//不存在添加一条对应该客户数据
						{
							dobfi.insertClientintChargel(cc);							
						}
					}
					
				}
			}	
		}
		/// <summary>
		/// 获取回款信息
		/// </summary>
		/// <param name="ClientOperationID">客户业务号</param>
		/// <param name="year">年份</param>
		/// <param name="month">月份</param>
		/// <param name="state">状态：年结、月结、一次性、迁移费</param>
		/// <returns>返回缴款信息</returns>
		public void hkinfo(string ClientOperationID,string year,string month,string state)
		{
			NrOA.CheckAccount.pkg.DOChargeInfo dci = new NrOA.CheckAccount.pkg.DOChargeInfo();
			IList listd = null;

			this.Poundage ="0";
			this.Value = "0";
			this.ycxPoundage ="0";
			this.ycxValue = "0";
			//每个月 首先搜索 是否有年结 然后搜索 月结
			//有年结 则为年结没有为 月结
			listd = dci.selectpay_info(ClientOperationID,year,month,state);
			if(state=="年结")
			{				
				if(listd!=null)
				{
					if(listd.Count>0)
					{
						try
						{
							this.Poundage = ((NrOA.CheckAccount.em.ChargeInfo)(listd)[0]).Now_Poundage;
						}
						catch{this.Poundage ="0";}
						try
						{
							this.Value = ((NrOA.CheckAccount.em.ChargeInfo)(listd)[0]).PaymentYear;
						}
						catch{this.Value = "0";}
					}
				}
			}
			else if(state=="月结")
			{				
				if(listd!=null)
				{
					if(listd.Count>0)
					{
						try
						{
							this.Poundage = ((NrOA.CheckAccount.em.ChargeInfo)(listd)[0]).Now_Poundage;
						}
						catch{this.Poundage ="0";}
						try
						{
							this.Value = ((NrOA.CheckAccount.em.ChargeInfo)(listd)[0]).PaymentMonth;
						}
						catch{this.Value = "0";}
					}
				}
			}

			//一次性
			//每月都要搜索是否有一次性
			if(state=="一次性")
			{				
				if(listd!=null)
				{
					if(listd.Count>0)
					{
						try
						{
							this.ycxPoundage = ((NrOA.CheckAccount.em.ChargeInfo)(listd)[0]).Now_Poundage;
						}
						catch{this.ycxPoundage ="0";}
						try
						{
							this.ycxValue = int.Parse(((NrOA.CheckAccount.em.ChargeInfo)(listd)[0]).OneOffConnectFees).ToString();
						}
						catch{this.ycxValue = "0";}
					}
				}
			}
			//迁移费
			//每月都要搜索是否有迁移费
			if(state=="迁移费")
			{				
				if(listd!=null)
				{
					if(listd.Count>0)
					{
						try
						{
							this.ycxPoundage = ((NrOA.CheckAccount.em.ChargeInfo)(listd)[0]).Now_Poundage;
						}
						catch{this.ycxPoundage ="0";}
						try
						{
							this.ycxValue = int.Parse(((NrOA.CheckAccount.em.ChargeInfo)(listd)[0]).MovePay).ToString();
						}
						catch{this.ycxValue = "0";}
					}
				}
			}

		}

		private string _Poundage;
		public string Poundage
		{
			get { return _Poundage; }
			set { _Poundage = value; }
		}
		private string _Value;
		public string Value
		{
			get { return _Value; }
			set { _Value = value; }
		}
		private string _ycxPoundage;
		public string ycxPoundage
		{
			get { return _ycxPoundage; }
			set { _ycxPoundage = value; }
		}
		private string _ycxValue;
		public string ycxValue
		{
			get { return _ycxValue; }
			set { _ycxValue = value; }
		}


		public IList selectChargeCollect_by_id(string id)
		{
			return Mapper.Instance().QueryForList("selectChargeCollect_by_id",id);
		}
		private void deleteChargeCollect_by_year_state(string year,string state)
		{
			NrOA.CheckAccount.em.ChargeCollect cc = new NrOA.CheckAccount.em.ChargeCollect();
			cc.year = year;
			cc.state = state;
			Mapper.Instance().Delete("deleteChargeCollect_by_year_state",cc);
		}
	}
}
