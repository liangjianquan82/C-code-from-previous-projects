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
	/// DealChargeTable ��ժҪ˵����
	/// </summary>
	public class DealChargeTable
	{
		public DealChargeTable()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// ���ݵ�ǰ ���� �г�δ�ؿ��û���
		/// </summary>
		/// <param name="year">���</param>
		/// <param name="month">�·�</param>
		/// <returns>δ�ؿ��û���</returns>
		public DataTable NotPayMoneyClient(string year,string month)
		{

			//��ѯ���� �Ѿ��ؿ��û��б� ���������� �� �ؿ� ��t1

			//��ѯ �����û�t2

			//�Ƚ� t1.t2 ɸѡ�� û�� �ɿ���Ϣ�� �û� ��Ϊ Table

			//��Table�û���û�е���ǰ�½ɿ��ڵ��û� �޳���ȥ�������������Ϊ��Ч�ڵ��û���

			//������û���Ϣû����Ч���ڵ� Ҫ��ѯ���û����շѼ�¼ ������û���Ѿ��չ� �ؿ� ������ᣬ���û���޳�������ȶ��տ� ��Ч���Ƿ��Ǳ����� ���� �޳�������С�ڱ�����

			//���Table�û�Ϊʵ��û�нɿ��û�

			return null;
		}


	}
}
