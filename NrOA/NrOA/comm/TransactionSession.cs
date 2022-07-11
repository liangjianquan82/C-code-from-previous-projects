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

namespace NrOA.comm
{
	/// <summary>
	/// TransactionSession ��ժҪ˵����
	/// </summary>
	public class TransactionSession
	{
		public TransactionSession()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// ����ʼ
		/// </summary>
		public void BeginTransaction()
		{
			Mapper.Instance().BeginTransaction();
			
		}
		/// <summary>
		/// �����ύ
		/// </summary>
		public void CommitTransaction ()
		{
			Mapper.Instance().CommitTransaction();
		}
		/// <summary>
		/// ���ӽ���
		/// </summary>
		public void CloseConnection()
		{
			Mapper.Instance().CloseConnection();
			
		}
		/// <summary>
		/// ����ع�
		/// </summary>
		public void RollBackTransaction()
		{
			Mapper.Instance().RollBackTransaction();
			
		}
	}
}
