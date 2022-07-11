using System;

namespace NrOA.Affiche.em
{
	/// <summary>
	/// 公告实体
	/// </summary>
	public class affiche
	{
		public affiche()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private int _Affiche_ID;
		/// <summary>
		/// 公告编号
		/// </summary>
		public int Affiche_ID
		{
			get { return _Affiche_ID; }
			set { _Affiche_ID = value; }
		}
//		private string _Affiche_title;
//		/// <summary>
//		/// 公告标题
//		/// </summary>
//		public string Affiche_title
//		{
//			get { return _Affiche_title; }
//			set { _Affiche_title = value; }
//		}
		private string _Affiche_content;
		/// <summary>
		/// 公告内容
		/// </summary>
		public string Affiche_content
		{
			get { return _Affiche_content; }
			set { _Affiche_content = value; }
		}
		private string _RegisterMane;
		/// <summary>
		/// 记录人
		/// </summary>
		public string RegisterMane
		{
			get { return _RegisterMane; }
			set { _RegisterMane = value; }
		}
		private string _state;
		/// <summary>
		/// 状态
		/// </summary>
		public string state
		{
			get { return _state; }
			set { _state = value; }
		}
	}
}
