using System;

namespace NrOANetWork.client.em
{
	/// <summary>
	/// ClientInfo 的摘要说明。
	/// </summary>
	public class ClientInfo
	{
		public ClientInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private int _client_id;
		/// <summary>
		/// 客户编号
		/// </summary>
		public int client_id
		{
			get{return  _client_id;}
			set{ _client_id = value;}
		}
		private string _client_name;
		/// <summary>
		/// 客户名称
		/// </summary>
		public string client_name
		{
			get{return  _client_name;}
			set{ _client_name = value;}
		}
		private string _sex;
		/// <summary>
		/// 性别
		/// </summary>
		public string sex
		{
			get{return  _sex;}
			set{ _sex = value;}
		}
		private string _phone;
		/// <summary>
		/// 电话
		/// </summary>
		public string phone
		{
			get{return  _phone;}
			set{ _phone = value;}
		}
		private string _address;
		/// <summary>
		/// 地址
		/// </summary>
		public string address
		{
			get{return  _address;}
			set{ _address = value;}
		}
		private string _cardID;
		/// <summary>
		/// 卡号
		/// </summary>
		public string cardID
		{
			get{return  _cardID;}
			set{ _cardID = value;}
		}
		private string _registerman;
		/// <summary>
		/// 记录人
		/// </summary>
		public string registerman
		{
			get{return  _registerman;}
			set{ _registerman = value;}
		}
		private string _registertime;
		/// <summary>
		/// 记录时间
		/// </summary>
		public string registertime
		{
			get{return  _registertime;}
			set{ _registertime = value;}
		}
		private string _clientoperationID;
		/// <summary>
		/// 用户业务号
		/// </summary>
		public string clientoperationID
		{
			get{return  _clientoperationID;}
			set{ _clientoperationID = value;}
		}
		private string _clientpassword;
		/// <summary>
		/// 用户密码
		/// </summary>
		public string clientpassword
		{
			get{return  _clientpassword;}
			set{ _clientpassword = value;}
		}
	}
}
