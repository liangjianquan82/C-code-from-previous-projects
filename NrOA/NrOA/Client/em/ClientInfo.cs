using System;

namespace NrOANetWork.client.em
{
	/// <summary>
	/// ClientInfo ��ժҪ˵����
	/// </summary>
	public class ClientInfo
	{
		public ClientInfo()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		private int _client_id;
		/// <summary>
		/// �ͻ����
		/// </summary>
		public int client_id
		{
			get{return  _client_id;}
			set{ _client_id = value;}
		}
		private string _client_name;
		/// <summary>
		/// �ͻ�����
		/// </summary>
		public string client_name
		{
			get{return  _client_name;}
			set{ _client_name = value;}
		}
		private string _sex;
		/// <summary>
		/// �Ա�
		/// </summary>
		public string sex
		{
			get{return  _sex;}
			set{ _sex = value;}
		}
		private string _phone;
		/// <summary>
		/// �绰
		/// </summary>
		public string phone
		{
			get{return  _phone;}
			set{ _phone = value;}
		}
		private string _address;
		/// <summary>
		/// ��ַ
		/// </summary>
		public string address
		{
			get{return  _address;}
			set{ _address = value;}
		}
		private string _cardID;
		/// <summary>
		/// ����
		/// </summary>
		public string cardID
		{
			get{return  _cardID;}
			set{ _cardID = value;}
		}
		private string _registerman;
		/// <summary>
		/// ��¼��
		/// </summary>
		public string registerman
		{
			get{return  _registerman;}
			set{ _registerman = value;}
		}
		private string _registertime;
		/// <summary>
		/// ��¼ʱ��
		/// </summary>
		public string registertime
		{
			get{return  _registertime;}
			set{ _registertime = value;}
		}
		private string _clientoperationID;
		/// <summary>
		/// �û�ҵ���
		/// </summary>
		public string clientoperationID
		{
			get{return  _clientoperationID;}
			set{ _clientoperationID = value;}
		}
		private string _clientpassword;
		/// <summary>
		/// �û�����
		/// </summary>
		public string clientpassword
		{
			get{return  _clientpassword;}
			set{ _clientpassword = value;}
		}
	}
}
