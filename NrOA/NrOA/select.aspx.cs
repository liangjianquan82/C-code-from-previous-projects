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
using AjaxPro;

namespace NrOA
{
	/// <summary>
	/// select ��ժҪ˵����
	/// </summary>
	public class select : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label labPart;
		protected System.Web.UI.WebControls.DropDownList ddlPart;
		protected System.Web.UI.WebControls.ListBox lbPerson;
		protected System.Web.UI.WebControls.ListBox lbChoose;
		protected System.Web.UI.WebControls.Label labId;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Label labName;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidChooseName;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidChooseId;
		protected Hashtable ht = null;
		NrOA.Employee.pkg.DOEmployee de = new NrOA.Employee.pkg.DOEmployee();
		NrOA.Branch.pkg.DOBranch db = new NrOA.Branch.pkg.DOBranch();
	
		[AjaxMethod]
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��

			AjaxPro.Utility.RegisterTypeForAjax(typeof(select));
			ht = (Hashtable)Session["userinfo"];

			if(!this.IsPostBack) 
			{
				this.hidChooseId.Value="";
				this.hidChooseName.Value="";

				//�ڵ��ȷ���ύǰҪ������ѡ��Ա��id������,�Զ��Ÿ�����������������
				this.btnOK.Attributes.Add("onclick","javascript:return BuildIdAndName();");

				ddlPart.DataSource = db.SelectAllBranch();
				ddlPart.DataTextField = "BranchName";
				ddlPart.DataValueField = "Branch_ID";
				ddlPart.DataBind();
				ddlPart.Items.Insert(0,ListItem.FromString("-��ѡ����-"));
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
			this.ddlPart.SelectedIndexChanged += new System.EventHandler(this.ddlPart_SelectedIndexChanged);
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.labId.Text=this.hidChooseId.Value;
			this.labName.Text=this.hidChooseName.Value;

			string ssss = labId.Text+"|"+this.labName.Text;

			string vbCrLf="\n";
			string strScript= "<script>" + vbCrLf;
			strScript += "window.parent.returnValue=escape('" + ssss + "')" + vbCrLf;
			strScript += "window.parent.close()" + vbCrLf;
			strScript += "</script>" + vbCrLf;
			Response.Write(strScript);
		}

		[AjaxMethod]
		private void ddlPart_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			IList list = null;
			list = de.select_Employee_by_branch(ddlPart.SelectedValue);
			this.lbPerson.Items.Clear();
			string Text,Value;
			if(list!=null)
			{
				if(list.Count>0)
				{
					for(int i=0;i<list.Count;i++)
					{
						Text=((NrOA.Employee.em.Employee)(list)[i]).EmployeeName;
						Value=((NrOA.Employee.em.Employee)(list)[i]).Employee_ID.ToString();
						this.lbPerson.Items.Add(new ListItem(Text,Value));
					}
				}
			}			
		}		
		
	}
}
