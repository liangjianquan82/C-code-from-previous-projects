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

using NrOA.Employee.em;

namespace NrOA.comm
{
	/// <summary>
	/// Passport ��ժҪ˵����
	/// </summary>
	public class Passport
	{		
		public Passport()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ����ְ�����ź������ѯְ����Ϣ
		/// </summary>
		/// <param name="name">ְ������</param>
		/// <param name="password">ְ������</param>
		/// <returns></returns>
		public static Hashtable login(string name,string password)
		{
			NrOA.Employee.em.Employee EP = new NrOA.Employee.em.Employee();
			EP.Employee_Nb = name;
			EP.Password = password;
			IList list = Mapper.Instance().QueryForList("SelectEP_By_NbPs",EP);

			Hashtable ht = new Hashtable();
			try
			{
				if(list.Count!=0)
				{
					ht.Add("Employee_ID",((NrOA.Employee.em.Employee)(list)[0]).Employee_ID);
					ht.Add("EmployeeName",((NrOA.Employee.em.Employee)(list)[0]).EmployeeName);
					ht.Add("Employee_Sex",((NrOA.Employee.em.Employee)(list)[0]).Employee_Sex);
					ht.Add("Employee_Age",((NrOA.Employee.em.Employee)(list)[0]).Employee_Age);
					ht.Add("Employee_Phone",((NrOA.Employee.em.Employee)(list)[0]).Employee_Phone);
					ht.Add("Employee_Address",((NrOA.Employee.em.Employee)(list)[0]).Employee_Address);
					ht.Add("JoinWorkTime",((NrOA.Employee.em.Employee)(list)[0]).JoinWorkTime);
					ht.Add("Remark",((NrOA.Employee.em.Employee)(list)[0]).Remark);
					ht.Add("BranchName",((NrOA.Employee.em.Employee)(list)[0]).BranchName);
					ht.Add("Duty",((NrOA.Employee.em.Employee)(list)[0]).Duty);
					ht.Add("Employee_Nb",((NrOA.Employee.em.Employee)(list)[0]).Employee_Nb);
					ht.Add("RegisterTime",((NrOA.Employee.em.Employee)(list)[0]).RegisterTime);
					ht.Add("RegisterMan",((NrOA.Employee.em.Employee)(list)[0]).RegisterMan);
					ht.Add("Password",((NrOA.Employee.em.Employee)(list)[0]).Password);
					ht.Add("Login_out",((NrOA.Employee.em.Employee)(list)[0]).Login_out);
				}
				else
				{
					ht = null;
				}
				
			}
			catch(IBatisNet.DataMapper.Exceptions.DataMapperException E)
			{					
				throw new Exception(E.Message);
			}
			return ht;
		}
	}
}
