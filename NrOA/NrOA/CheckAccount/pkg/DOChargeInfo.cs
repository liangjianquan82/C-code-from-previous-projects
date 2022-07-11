
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
	/// DOChargeInfo ��ժҪ˵����
	/// </summary>
	public class DOChargeInfo
	{

		public DOChargeInfo()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ����һ������Ϣ
		/// </summary>
		/// <param name="ci"></param>
		public void AddOneOffConnectFeesList(NrOA.CheckAccount.em.ChargeInfo ci)
		{
			Mapper.Instance().Insert("AddOneOffConnectFeesList",ci);
		}
		/// <summary>
		/// ���������Ϣ
		/// </summary>
		/// <param name="ci"></param>
		public void FirstPaymentList(NrOA.CheckAccount.em.ChargeInfo ci)
		{
			Mapper.Instance().Insert("FirstPaymentList",ci);
		}
		/// <summary>
		/// �����»ؿ��շ���Ϣ
		/// </summary>
		/// <param name="ci"></param>
		public void BackMonthPay(NrOA.CheckAccount.em.ChargeInfo ci)
		{
			Mapper.Instance().Insert("BackMonthPay",ci);
		}
		/// <summary>
		/// ����������ѯ
		/// </summary>
		/// <param name="Year">���</param>
		/// <param name="startMonth">��ʼ�·�</param>
		/// <param name="endMonth">�����·�</param>
		/// <param name="Area_id">С����� ��-��ѡ��С��-�� ȫ��С��</param>
		/// <param name="Find_id">����id 1-δ�ؿ��û� 2-���ֳɱ������� 3-����ѽɷ��û� 4-Ǩ�Ʒѽɷ��û� 5-����б� 6-һ�����б� 7-�ؿ�/�½��б� 8-�½�ֳɱ������� 9-һ���Էֳɱ�������</param>
		/// <returns></returns>
		public IList Find_List(string Year,string startMonth,string endMonth,string Area_id,int Find_id)
		{
			IList list = null;
			NrOA.CheckAccount.em.ChargeInfo CI = new NrOA.CheckAccount.em.ChargeInfo();

			CI.Year = Year;
			CI.startMonth = startMonth;
			CI.endMonth = endMonth;

			if(Area_id!="-��ѡ��С��-")
			{
				CI.Area_ID = Area_id;
			}

			if(Find_id==1)
			{
				//δ�ؿ��û�
				list = Mapper.Instance().QueryForList("",CI);
			}
			else if(Find_id==2)
			{
				//���ֳɱ�������
				list = Mapper.Instance().QueryForList("Find_NJFCBICW",CI);
			}
			else if(Find_id==3)
			{
				//����ѽɷ��û�
				list = Mapper.Instance().QueryForList("Find_JRFJFYH",CI);
			}
			else if(Find_id==4)
			{
				//Ǩ�Ʒѽɷ��û�
				list = Mapper.Instance().QueryForList("Find_QYFJFYH",CI);
			}
			else if(Find_id==5)
			{
				//����б�
				list = Mapper.Instance().QueryForList("Find_NJLB",CI);
			}
			else if(Find_id==6)
			{
				//һ�����б�
				list = Mapper.Instance().QueryForList("Find_YCXLB",CI);
			}
			else if(Find_id==7)
			{
				//�ؿ�/�½��б�
				list = Mapper.Instance().QueryForList("Find_HKLB",CI);
			}
			else if(Find_id==8)
			{
				//�½�ֳɱ�������
				list = Mapper.Instance().QueryForList("Find_HKDCBLCW",CI);
			}
			else if(Find_id==9)
			{
				//һ���Էֳɱ�������
				list = Mapper.Instance().QueryForList("Find_YCXFCBLCW",CI);
			}

			return list;
		}

		/// <summary>
		/// ���ݱ�Ų�ѯ�����Ϣ
		/// </summary>
		/// <param name="id">���</param>
		/// <returns></returns>
		public IList selectCharge_by_id(int id)
		{
			return Mapper.Instance().QueryForList("selectCharge_by_id",id);
		}

		/// <summary>
		/// ���������Ϣ
		/// </summary>
		/// <param name="ci"></param>
		public void Update_Charge_year(NrOA.CheckAccount.em.ChargeInfo ci)
		{
			Mapper.Instance().Update("Update_Charge_year",ci);
		}
		/// <summary>
		///����һ���� Ǩ�Ʒ� 
		/// </summary>
		/// <param name="ci"></param>
		public void Update_Charge_one_0r_move(NrOA.CheckAccount.em.ChargeInfo ci)
		{
			Mapper.Instance().Update("Update_Charge_one_0r_move",ci);
		}

		/// <summary>
		/// �����½�/�ؿ�
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
		/// ����������ѯ��Ӧ�Ļؿ��û�
		/// </summary>
		/// <param name="year">��</param>
		/// <param name="month">��</param>
		/// <param name="arae">����</param>
		/// <param name="state">״̬</param>
		/// <param name="str">ģ����ѯ����</param>
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

			if(month=="0"&&arae=="����С��"&&state=="0"&&str=="")
			{
				list = dc.SelectAllClient();
			}
			else if(month!="0"&&arae=="����С��"&&state=="0"&&str=="")
			{
				//��Ӧ�·��лؿ��û�
				list = Mapper.Instance().QueryForList("selectChargeinfo_by_month",ci);
			}
			else if(month=="0"&&arae!="����С��"&&state=="0"&&str=="")
			{
				list =dc.SelectClient_byAreaName(arae);
			}
			else if(month=="0"&&arae=="����С��"&&state!="0"&&str=="")
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
			else if(month=="0"&&arae=="����С��"&&state=="0"&&str!="")
			{
				list =Mapper.Instance().QueryForList("selectChargeinfo_by_str",ci);
			}
			else if(month!="0"&&arae!="����С��"&&state=="0"&&str=="")
			{
				list =Mapper.Instance().QueryForList("selectChargeinfo_by_MA",ci);
			}
			else if(month!="0"&&arae=="����С��"&&state!="0"&&str=="")
			{
				if(state=="1")
				{
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_MS",ci);
				}
			}
			else if(month!="0"&&arae=="����С��"&&state=="0"&&str!="")
			{
				list =Mapper.Instance().QueryForList("selectChargeinfo_by_MStr",ci);
			}
			else if(month=="0"&&arae!="����С��"&&state!="0"&&str=="")
			{
				if(state=="1")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_AS1",ci);
				else if(state=="2")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_AS2",ci);
			}
			else if(month=="0"&&arae!="����С��"&&state=="0"&&str!="")
			{
				list =Mapper.Instance().QueryForList("selectChargeinfo_by_AStr",ci);
			}
			else if(month=="0"&&arae=="����С��"&&state!="0"&&str!="")
			{
				if(state=="1")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_SS1",ci);
				else if(state=="2")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_SS2",ci);
			}
			else if(month!="0"&&arae!="����С��"&&state!="0"&&str=="")
			{
				if(state=="1")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_MAS1",ci);
//				else if(state=="2")
//					list =Mapper.Instance().QueryForList("selectChargeinfo_by_MAS2",ci);
			}
			else if(month!="0"&&arae!="����С��"&&state=="0"&&str!="")
			{
				list =Mapper.Instance().QueryForList("selectChargeinfo_by_MAStr",ci);
			}
			else if(month!="0"&&arae=="����С��"&&state!="0"&&str!="")
			{
				if(state=="1")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_MSS1",ci);
			}
			else if(month=="0"&&arae!="����С��"&&state!="0"&&str!="")
			{
				if(state=="1")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_ASS1",ci);
				else if(state=="2")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_ASS2",ci);
			}
			else if(month!="0"&&arae!="����С��"&&state!="0"&&str!="")
			{
				if(state=="1")
					list =Mapper.Instance().QueryForList("selectChargeinfo_by_MASS1",ci);
			}			
			return list;
		}
		/// <summary>
		/// ����������ѯ��Ӧ�Ļؿ��û�
		/// </summary>
		/// <param name="year">��</param>
		/// <param name="month">��</param>
		/// <param name="arae">����</param>
		/// <param name="state">״̬</param>
		/// <param name="str">ģ����ѯ����</param>
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
				if(arae=="����С��"&&str==""&&state=="0")
				{
					//ĳ��
					list = Mapper.Instance().QueryForList("ChargeCollectlist0_1",cc);
				}
				else if(arae!="����С��"&&str==""&&state=="0")
				{
					//ĳ��ĳС��
					list = Mapper.Instance().QueryForList("ChargeCollectlist0_2",cc);
				}

				else if(arae=="����С��"&&str!=""&&state=="0")
				{
					//ĳ��ģ����ѯ
					list = Mapper.Instance().QueryForList("ChargeCollectlist0_3",cc);
				}
				else if(arae=="����С��"&&str==""&&state!="0")
				{
					if(state=="1")
					{
						//ĳ��ֳɱ�������
						list = Mapper.Instance().QueryForList("ChargeCollectlist0_4_1",cc);
					}
					else if(state=="2")//ĳ��ȫ���޻ؿ� 
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_4_2",cc);}
					else if(state=="3")//ĳ�꿢�� 
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_4_3",cc);}
				}
				else if(arae!="����С��"&&str==""&&state!="0")
				{
					//ĳ��ֳɱ������� С��
					if(state=="1")
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_5_1",cc);}
					else if(state=="2")//ĳ��ȫ���޻ؿ� С��
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_5_2",cc);}
					else if(state=="3")//ĳ��ĳС������
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_5_3",cc);}
				}
				else if(arae!="����С��"&&str!=""&&state=="0")
				{
					//ȫ��ģ��
					list = Mapper.Instance().QueryForList("ChargeCollectlist0_6",cc);
				}
				else if(arae=="����С��"&&str!=""&&state!="0")
				{
					if(state=="1")//ĳ��ֳɱ������� ģ��
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_7_1",cc);}
					else if(state=="2")//ĳ��ȫ���޻ؿ� ģ��
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_7_2",cc);}
					else if(state=="3")//ĳ��ȫ�� ģ��
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_7_3",cc);}
				}
				else if(arae!="����С��"&&str!=""&&state!="0")
				{
					if(state=="1")//ĳ��ֳɱ������� ģ�� С��
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_8_1",cc);}
					else if(state=="2")//ĳ��ȫ���޻ؿ� ģ�� С��
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_8_2",cc);}
					else if(state=="3")//ĳ��ȫ��ؿ� ģ�� С��
					{list = Mapper.Instance().QueryForList("ChargeCollectlist0_8_3",cc);}
				}
			}
			else if(month!="0")
			{
				if(arae=="����С��"&&str==""&&state=="0")
				{
					//ĳ��ĳ�·�
					list = Mapper.Instance().QueryForList("ChargeCollectlist1_1",cc);
				}
				else if(arae!="����С��"&&str==""&&state=="0")
				{
					//ĳ��ĳ�·�ĳС��
					list = Mapper.Instance().QueryForList("ChargeCollectlist1_2",cc);
				}
				else if(arae=="����С��"&&str!=""&&state=="0")
				{
					//ĳ��1�·�ģ����ѯ��ҵ��š����ƣ�
					list = Mapper.Instance().QueryForList("ChargeCollectlist1_3",cc);
				}
				else if(arae=="����С��"&&str==""&&state!="0")
				{
					if(state=="1")
					{
						//ĳ��ĳ�·�״̬1-�ֳɱ�������
						list = Mapper.Instance().QueryForList("ChargeCollectlist1_4_1",cc);
					}
					else if(state=="3")
					{
						//ĳ��ĳ�·�״̬3-���ݿ�ͨΪĳ���µĲ�ѯ��Ӧ�ؿ���Ϣ
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
				else if(arae!="����С��"&&str!=""&&state=="0")
				{
					//ĳ��ĳ�·�ĳС��ģ����ѯ
					list = Mapper.Instance().QueryForList("ChargeCollectlist1_5",cc);
				}
				else if(arae!="����С��"&&str==""&&state!="0")
				{
					if(state=="1")
					{
						//ĳ��ĳ�·�ĳС��״̬1-�ֳɱ�������
						list = Mapper.Instance().QueryForList("ChargeCollectlist1_6_1",cc);
					}
					else if(state=="3")
					{
						if(int.Parse(month)<10)
						{
							cc.month = "0"+month;
						}
						//ĳ��ĳ�·�ĳС��״̬3-���ݿ�ͨΪĳ���µĲ�ѯ��Ӧ�ؿ���Ϣ
						//���ڲ�ѯ���û�ж�Ӧ����ݳ��� 08-09�궼�г���������
						try
						{
							list = Mapper.Instance().QueryForList("ChargeCollectlist1_6_2",cc);
						}
						catch{list = null;}
					}
				}
				else if(arae=="����С��"&&str!=""&&state!="0")
				{
					if(state=="1")
					{
						//ĳ��ĳ�·�ģ����ѯ״̬1-�ֳɱ�������
						list = Mapper.Instance().QueryForList("ChargeCollectlist1_7_1",cc);
					}
					else if(state=="3")
					{
						if(int.Parse(month)<10)
						{
							cc.month = "0"+month;
						}
						//ĳ��ĳ�·�ģ����ѯ״̬3-���ݿ�ͨΪ1�µĲ�ѯ��Ӧ�ؿ���Ϣ
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
						//ĳ��ĳ�·�ģ����ѯС��״̬1-�ֳɱ�������
						list = Mapper.Instance().QueryForList("ChargeCollectlist1_8_1",cc);
					}
					else if(state=="3")
					{
						if(int.Parse(month)<10)
						{
							cc.month = "0"+month;
						}
						//ĳ��ĳ�·�ģ����ѯС��״̬3-���ݿ�ͨΪ1�µĲ�ѯ��Ӧ�ؿ���Ϣ
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
		/// ����ҵ��š���ݡ��·ݲ�ѯ�ؿ���Ϣ
		/// </summary>
		/// <param name="ClientOperationID">ҵ���</param>
		/// <param name="month">�·�</param>
		/// <param name="state">�������</param>
		/// <param name="year">���</param>
		/// <returns></returns>
		public IList selectpay_info(string ClientOperationID,string year,string month,string state)
		{
			IList list = null;
			NrOA.CheckAccount.em.ChargeInfo ci = new NrOA.CheckAccount.em.ChargeInfo();
			ci.ClientOperationID = ClientOperationID;
			ci.Payment_by_Year = year;
			ci.Payment_by_Month = month;

			if(state=="���")
			{
				list = Mapper.Instance().QueryForList("selectpay_infonj",ci);
			}
			else if(state=="�½�")
			{
				list = Mapper.Instance().QueryForList("selectpay_infoyj",ci);
			}
			else if(state=="һ����")
			{
				list = Mapper.Instance().QueryForList("selectpay_infoycx",ci);
			}
			else if(state=="Ǩ�Ʒ�")
			{
				list = Mapper.Instance().QueryForList("selectpay_infoqyf",ci);
			}
			return list;
		}
		/// <summary>
		/// ������ɾ����Ӧ���շ���Ϣ
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
		/// û�ж�Ӧ���û��շ�
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
		/// ��ѯ״̬
		/// </summary>
		/// <param name="state">״̬</param>
		/// <returns></returns>
		public IList select_Chargeinfostate(string state)
		{
			return Mapper.Instance().QueryForList("select_Chargeinfostate",state);
		}
		/// <summary>
		/// ��ֵ�б��ѯ
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
		/// ���� �û������û�ҵ���ģ����ѯ
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public IList select_ChargeStr(string str)
		{

			str = "%"+str+"%";
			return Mapper.Instance().QueryForList("select_ChargeStr",str);
		}
		/// <summary>
		/// ɾ������Ķ�����Ϣ����ע���û�
		/// </summary>
		/// <param name="ClientOperationID"></param>
		public void delete_ChargeCollect(string ClientOperationID)
		{
			Mapper.Instance().Delete("delete_ChargeCollect",ClientOperationID);
		}
	}
}
