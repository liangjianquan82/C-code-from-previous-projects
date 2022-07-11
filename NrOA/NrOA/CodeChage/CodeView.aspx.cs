using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace NrOA.CodeChage
{
	/// <summary>
	/// CodeView ��ժҪ˵����
	/// </summary>
	public class CodeView : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label_Title;
		protected System.Web.UI.WebControls.Button ok2;
		protected System.Web.UI.HtmlControls.HtmlForm addtask;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox TextBox4;
		protected System.Web.UI.WebControls.TextBox TextBox5;
		protected System.Web.UI.WebControls.TextBox TextBox3;

		protected Hashtable ht = null;
		private string UserName = "";
		private string Employee_Nb = "";
		private string Employee_ID = "";
		private string Password = "";
		NrOA.Employee.pkg.DOEmployee dc = new NrOA.Employee.pkg.DOEmployee();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			ht = (Hashtable)Session["userinfo"];
			UserName = ht["EmployeeName"].ToString();
			Employee_Nb = ht["Employee_Nb"].ToString();
			TextBox4.Text = UserName;
			TextBox5.Text = Employee_Nb;
			try
			{
				Password = ht["Password"].ToString();
			}
			catch{}

			try
			{
				Employee_ID = Request["Employee_ID"].ToString();
			}
			catch{}
			IList list = null;
			
			if(Employee_ID=="")
			{
				Employee_ID = ht["Employee_ID"].ToString();
			}
			else
			{
			}
			try
			{
				list = dc.select_Employee_id(Employee_ID);
			}
			catch{}
			
			if(list!=null)
			{
				if(list.Count>0)
				{
					TextBox4.Text = ((NrOA.Employee.em.Employee)(list)[0]).EmployeeName;
					TextBox5.Text = ((NrOA.Employee.em.Employee)(list)[0]).Employee_Nb;
					Password = ((NrOA.Employee.em.Employee)(list)[0]).Password;
				}
			}
			
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.ok2.Click += new System.EventHandler(this.ok2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ok2_Click(object sender, System.EventArgs e)
		{
			NrOA.Employee.em.Employee El = new NrOA.Employee.em.Employee();
			NrOA.Employee.pkg.DOEmployee de = new NrOA.Employee.pkg.DOEmployee();

			string str = "";
			bool state = false;
			if(TextBox1.Text.Trim()=="")
			{
				str="ԭ���벻��Ϊ�գ�";
			}
			else if(Password!=TextBox1.Text.Trim())
			{
				str="ԭ������д����";
			}
			else if(TextBox2.Text.Trim()=="")
			{
				str="�����벻��Ϊ�գ�";
			}
			else if(TextBox3.Text.Trim()=="")
			{
				str="������ȷ�ϲ���Ϊ�գ�";
			}
			else if(TextBox3.Text.Trim()!=TextBox2.Text.Trim())
			{
				str="��������������ȷ�ϱ�����ͬ��";
				TextBox3.Text = "";
				TextBox2.Text = "";
			}
			else
			{
				El.Employee_ID = int.Parse(Employee_ID);
				El.Password = TextBox2.Text.Trim();
				de.updateEmployee_Password(El);
				str="�������޸ĳɹ���";
				state = true;
			}
			Response.Write("<script>window.alert('"+str+"');</script>");
			if(!state)
			{
				return;
			}
		}
	}
}
