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
using Microsoft.Web.UI.WebControls;

namespace NrOA.CodeChage
{
	/// <summary>
	/// CodeTree ��ժҪ˵����
	/// </summary>
	public class CodeTree : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected Microsoft.Web.UI.WebControls.TreeView Treeview2;
		protected System.Web.UI.WebControls.Label Label2;
		protected Microsoft.Web.UI.WebControls.TreeView TreeView1;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden module;
		
		protected Hashtable ht = null;
		private string Employee_ID = "";
		private string UserName = "";
		private string BranchName = "";
		private string Employee_Nb = "";
		NrOA.Employee.pkg.DOEmployee de = new NrOA.Employee.pkg.DOEmployee();
		NrOA.Branch.pkg.DOBranch db = new NrOA.Branch.pkg.DOBranch();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			ht = (Hashtable)Session["userinfo"];
				
			if(ht == null)
			{
				Response.Redirect("login.aspx");
			}
			UserName = ht["EmployeeName"].ToString();
			Employee_Nb = ht["Employee_Nb"].ToString();
			Employee_ID = ht["Employee_ID"].ToString();
			try
			{
				BranchName = ht["BranchName"].ToString();
			}
			catch
			{}
			
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(IsPostBack)
				return;

			if(UserName=="NrOA")
			{
				Create_Tree();
			}
			else
			{
				Create_Tree1();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Create_Tree1()
		{
			TreeNode Node1=new TreeNode();
			TreeNode Node2=new TreeNode();
			TreeNode Node3=new TreeNode();
			IList dt = null;
			dt = db.BranchInfo_by_id(int.Parse(BranchName));

			Node1.Text = "�����б�";
			

			Node2.Text = ((NrOA.Branch.em.Branch)(dt)[0]).BranchName;
			Node2.NavigateUrl = "EmployeeList.aspx?BranchId="+((NrOA.Branch.em.Branch)(dt)[0]).Branch_ID.ToString();
			Node2.Target = "right";
			Node1.Nodes.Add(Node2);
			Node2.Expanded=true;

			Node3.Text = UserName;
			Node3.NavigateUrl = "CodeView.aspx?Employee_ID="+Employee_ID;
			Node3.Target = "right";
			Node2.Nodes.Add(Node3);

			TreeView1.Nodes.Add(Node1);
			Node1.Expanded=true;
		}
		private void Create_Tree()
		{
			
			
			IList dt = null;
			IList dt1 = null;
			dt = db.SelectAllBranch();
			string Branch_ID = "";
			if(dt!=null)
			{
				if(dt.Count>0)
				{
					TreeNode Node1=new TreeNode();
					Node1.Text = "�����б�";
					for(int i=0 ;i<dt.Count;i++)
					{						
						Branch_ID = ((NrOA.Branch.em.Branch)(dt)[i]).Branch_ID.ToString();
						TreeNode Node2=new TreeNode();
						Node2.Text = ((NrOA.Branch.em.Branch)(dt)[i]).BranchName;
						//Node2.NavigateUrl = "EmployeeList.aspx?BranchId="+Branch_ID;
						Node2.Target = "right";
						
						if(Node2.Text!="-��ѡ����-")
						{
							Node1.Nodes.Add(Node2);
						}
						
						dt1 = de.select_Employee_by_branch(Branch_ID);
						for(int s=0 ;s<dt1.Count;s++)
						{
							TreeNode Node3=new TreeNode();
							Node3.Text = ((NrOA.Employee.em.Employee)(dt1)[s]).EmployeeName;
							Node3.NavigateUrl = "CodeView.aspx?Employee_ID="+((NrOA.Employee.em.Employee)(dt1)[s]).Employee_ID;;
							Node3.Target = "right";
							Node2.Nodes.Add(Node3);
						}

					}
					TreeView1.Nodes.Add(Node1);
					Node1.Expanded=true;
				}
			}
		}
	}
}
