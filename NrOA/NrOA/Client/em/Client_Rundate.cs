using System;

namespace NrOA.Client.em
{
	/// <summary>
	/// Client_Rundate 的摘要说明。
	/// </summary>
	public class Client_Rundate
	{
		public Client_Rundate()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private int _id;
		/// <summary>
		/// 编号
		/// </summary>
		public int id
		{
			get { return _id; }
			set { _id = value; }
		}
		private int _Client_ID;
		/// <summary>
		/// 客户编号
		/// </summary>
		public int Client_ID
		{
			get { return _Client_ID; }
			set { _Client_ID = value; }
		}
		private string _ClientOperationID;
		/// <summary>
		/// 客户业务号
		/// </summary>
		public string ClientOperationID
		{
			get { return _ClientOperationID; }
			set { _ClientOperationID = value; }
		}
		private string _Runyear;
		/// <summary>
		/// 年
		/// </summary>
		public string Runyear
		{
			get { return _Runyear; }
			set { _Runyear = value; }
		}
		private string _Runmonth;
		/// <summary>
		/// 月
		/// </summary>
		public string Runmonth
		{
			get { return _Runmonth; }
			set { _Runmonth = value; }
		}
		private string _area_id;
		/// <summary>
		/// 月
		/// </summary>
		public string area_id
		{
			get { return _area_id; }
			set { _area_id = value; }
		}
	}
}
