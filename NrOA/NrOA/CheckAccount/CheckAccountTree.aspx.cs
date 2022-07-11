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

namespace NrOA.CheckAccount
{
	/// <summary>
	/// CheckAccountTree ��ժҪ˵����
	/// </summary>
	public class CheckAccountTree : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected Microsoft.Web.UI.WebControls.TreeView TreeView1;
		protected System.Web.UI.HtmlControls.HtmlForm tree;
	

		Hashtable hast=null;
		private string UserName = "";

		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��

			hast = (Hashtable)Session["userinfo"];

			try
			{
				UserName = hast["EmployeeName"].ToString();
			}
			catch{}
			//����Ȩ��
			if(UserName == "NrOA"|| UserName =="�Ʒ�")
			{
			}
			else if(UserName=="zhb"||UserName=="user")
			{
				Response.Write("<script language='javascript'>window.parent.location='../desktop.aspx'</script>");
			}
			else
			{
				Response.Write("<script language='javascript'>window.parent.location='../desktop.aspx'</script>");
			}
			
				
			if(hast == null)
			{
				Response.Redirect("login.aspx");
			}
			
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(IsPostBack)
				return;

			Create_Tree();
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
		private void Create_Tree()
		{
			NrOA.Area.em.Area AR = new NrOA.Area.em.Area();
			NrOA.Area.pkg.DOArea DoAr = new NrOA.Area.pkg.DOArea();

			//��ѯС���б�
			IList dt = null;
			dt = DoAr.SelectAreaAll_LoginIn();
			if(dt!=null)
			{
				if(dt.Count>0)
				{
					TreeNode Node1=new TreeNode();
					Node1.Text = "С���б�";
					for(int i=0 ;i<dt.Count;i++)
					{						
						TreeNode Node2=new TreeNode();
						Node2.Text = ((NrOA.Area.em.Area)(dt)[i]).Area_listid+"-"+((NrOA.Area.em.Area)(dt)[i]).AreaName;
						Node2.NavigateUrl = "newlist.aspx?AreaName="+((NrOA.Area.em.Area)(dt)[i]).Area_ID;
						Node2.Target = "right";
						if(Node2.Text!="-��ѡ��С��-")
						{
							Node1.Nodes.Add(Node2);
						}
					}
					TreeView1.Nodes.Add(Node1);
					Node1.Expanded=true;
//					TreeNode Node=new TreeNode();
//					Node.Text = "С���û���Ϣ����";
//					Node.NavigateUrl = "ClientInput.aspx";
//					Node.Target = "right";
//					TreeView1.Nodes.Add(Node);
				}
			}
		}
	}
}
