using System;

namespace NrOA.Affiche.em
{
	/// <summary>
	/// ����ʵ��
	/// </summary>
	public class affiche
	{
		public affiche()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		private int _Affiche_ID;
		/// <summary>
		/// ������
		/// </summary>
		public int Affiche_ID
		{
			get { return _Affiche_ID; }
			set { _Affiche_ID = value; }
		}
//		private string _Affiche_title;
//		/// <summary>
//		/// �������
//		/// </summary>
//		public string Affiche_title
//		{
//			get { return _Affiche_title; }
//			set { _Affiche_title = value; }
//		}
		private string _Affiche_content;
		/// <summary>
		/// ��������
		/// </summary>
		public string Affiche_content
		{
			get { return _Affiche_content; }
			set { _Affiche_content = value; }
		}
		private string _RegisterMane;
		/// <summary>
		/// ��¼��
		/// </summary>
		public string RegisterMane
		{
			get { return _RegisterMane; }
			set { _RegisterMane = value; }
		}
		private string _state;
		/// <summary>
		/// ״̬
		/// </summary>
		public string state
		{
			get { return _state; }
			set { _state = value; }
		}
	}
}
