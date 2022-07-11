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

namespace NrOA.TroubleDeal
{
	/// <summary>
	/// Excelout ��ժҪ˵����
	/// </summary>
	public class CheckAccount : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button5;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		private IList list = null;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			try
			{
				list = (IList)Session.Contents["list"];
			}
			catch{}
			try
			{
				DataGrid1.PageSize = list.Count;
			}
			catch{}
			DataGrid1.DataSource = list;
			DataGrid1.DataBind();

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
			this.Button5.Click += new System.EventHandler(this.Button5_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button5_Click(object sender, System.EventArgs e)
		{
			Response.Clear();
			Response.Buffer=   true;
			Response.Charset="GB2312";
			Response.AppendHeader("Content-Disposition","attachment;filename=�ֳɱ����������û�.xls");
			Response.ContentEncoding=System.Text.Encoding.GetEncoding("GB2312"); //���������Ϊ��������
			Response.ContentType   =   "application/ms-excel"; //��������ļ�����Ϊexcel�ļ���
			this.EnableViewState   =   false;
			System.Globalization.CultureInfo   myCItrad   =   new   System.Globalization.CultureInfo("ZH-CN",true); 
			System.IO.StringWriter   oStringWriter   =   new   System.IO.StringWriter(myCItrad);
			System.Web.UI.HtmlTextWriter   oHtmlTextWriter   =   new   System.Web.UI.HtmlTextWriter(oStringWriter);
			this.DataGrid1.RenderControl(oHtmlTextWriter); // ���������ñ����Ǹ�����Դ������.
			Response.Write(oStringWriter.ToString());
			Response.End();
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("TrbDList.aspx?state=end");
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.AlternatingItem) ||
				(e.Item.ItemType == ListItemType.Item))
			{
				#region ע��
				//				try
				//				{
				//					e.Item.Cells[5].Text = DateTime.Parse(e.Item.Cells[5].Text.Trim()).ToString("yyy-MM-dd");
				//				}
				//				catch{}
				//
				//				IList listfcbl = null;
				//				IList listdnj = null;
				//				IList listdyj = null;
				//
				//				IList listdycx = null;
				//				IList listdqyf = null;
				//				string area_id = "";
				//				area_id = e.Item.Cells[21].Text.Trim();
				//				try
				//				{
				//					listfcbl = DoA.SelectArea_By_ID(int.Parse(area_id));
				//					e.Item.Cells[6].Text = ((NrOA.Area.em.Area)(listfcbl)[0]).Poundage;
				//				}
				//				catch{}
				//
				//				for(int i=1;i<13;i++)
				//				{
				//					string OneOffConnectFees = "0";//һ�����շ�
				//					string PaymentMonth = "0";//���½���
				//					string FirstPayment = "0";//����
				//					string MovePay = "0";//Ǩ�Ʒ�
				//					string Now_Poundage = "0";
				//
				//					listdnj = dci.selectpay_info(e.Item.Cells[2].Text,Dropdownlist2.SelectedValue,i.ToString(),"���");
				//					listdyj = dci.selectpay_info(e.Item.Cells[2].Text,Dropdownlist2.SelectedValue,i.ToString(),"�½�");
				//					listdycx = dci.selectpay_info(e.Item.Cells[2].Text,Dropdownlist2.SelectedValue,i.ToString(),"һ����");
				//					listdqyf = dci.selectpay_info(e.Item.Cells[2].Text,Dropdownlist2.SelectedValue,i.ToString(),"Ǩ�Ʒ�");
				//					if(listdnj!=null)
				//					{
				//						if(listdnj.Count>0)
				//						{
				//							FirstPayment = ((NrOA.CheckAccount.em.ChargeInfo)(listdnj)[0]).FirstPayment;
				//							Now_Poundage = ((NrOA.CheckAccount.em.ChargeInfo)(listdnj)[0]).Now_Poundage;
				//						}
				//						else
				//						{
				//							FirstPayment = "0";
				//						}
				//					}
				//					
				//					if(listdyj!=null)
				//					{
				//						if(listdyj.Count>0)
				//						{							
				//							PaymentMonth = ((NrOA.CheckAccount.em.ChargeInfo)(listdyj)[0]).PaymentMonth;
				//							Now_Poundage = ((NrOA.CheckAccount.em.ChargeInfo)(listdyj)[0]).Now_Poundage;
				//						}
				//						else
				//						{
				//							PaymentMonth = "0";
				//						}
				//					}
				//
				//					if(FirstPayment!="0"&&PaymentMonth!="0")
				//					{
				//						e.Item.Cells[i+8].Text = FirstPayment+"-"+PaymentMonth;
				//						e.Item.Cells[i+8].ForeColor = System.Drawing.Color.Red;
				//					}
				//					else if(FirstPayment!="0"&&PaymentMonth=="0")
				//					{
				//						e.Item.Cells[i+8].Text = FirstPayment;
				//						if(Now_Poundage != e.Item.Cells[6].Text)
				//						{
				//							e.Item.Cells[i+8].ForeColor = System.Drawing.Color.Red;
				//						}
				//						else
				//						{
				//							e.Item.Cells[i+8].ForeColor = System.Drawing.Color.Black;
				//						}
				//					}
				//					else if(FirstPayment=="0"&&PaymentMonth!="0")
				//					{
				//						e.Item.Cells[i+8].Text = PaymentMonth;
				//						if(Now_Poundage != e.Item.Cells[6].Text)
				//						{
				//							e.Item.Cells[i+8].ForeColor = System.Drawing.Color.Red;
				//						}
				//						else
				//						{
				//							e.Item.Cells[i+8].ForeColor = System.Drawing.Color.Black;
				//						}
				//					}
				//					else if(FirstPayment=="0"&&PaymentMonth=="0")
				//					{
				//						e.Item.Cells[i+8].Text = "0";
				//					}
				//					
				//					if(listdycx!=null)
				//					{
				//						if(listdycx.Count>0)
				//						{
				//							OneOffConnectFees = ((NrOA.CheckAccount.em.ChargeInfo)(listdycx)[0]).OneOffConnectFees;
				//							Now_Poundage = ((NrOA.CheckAccount.em.ChargeInfo)(listdycx)[0]).Now_Poundage;
				//						}
				//						else
				//						{
				//							OneOffConnectFees = "0";
				//						}
				//					}
				//					if(OneOffConnectFees!="0")
				//					{
				//						e.Item.Cells[7].Text = OneOffConnectFees;
				//						if(Now_Poundage != e.Item.Cells[6].Text)
				//						{
				//							e.Item.Cells[7].ForeColor = System.Drawing.Color.Red;
				//						}
				//						else
				//						{
				//							e.Item.Cells[i+8].ForeColor = System.Drawing.Color.Black;
				//						}
				//					}
				//					if(listdycx!=null)
				//					{
				//						if(listdycx.Count>0)
				//						{
				//							MovePay = ((NrOA.CheckAccount.em.ChargeInfo)(listdycx)[0]).MovePay;
				//							Now_Poundage = ((NrOA.CheckAccount.em.ChargeInfo)(listdycx)[0]).Now_Poundage;
				//						}
				//						else
				//						{
				//							MovePay = "0";
				//						}
				//					}
				//					if(MovePay!="0")
				//					{
				//						e.Item.Cells[8].Text = MovePay;
				//						if(Now_Poundage != e.Item.Cells[6].Text)
				//						{
				//							e.Item.Cells[8].ForeColor = System.Drawing.Color.Red;
				//						}
				//						else
				//						{
				//							e.Item.Cells[i+8].ForeColor = System.Drawing.Color.Black;
				//						}
				//					}
				//
				//				}
				#endregion
				if(e.Item.Cells[9].Text.Trim()!="0"&&e.Item.Cells[8].Text.Trim()!=e.Item.Cells[25].Text.Trim())
				{
					e.Item.Cells[9].ForeColor = System.Drawing.Color.Red;
				}
				if(e.Item.Cells[10].Text.Trim()!="0"&&e.Item.Cells[8].Text.Trim()!=e.Item.Cells[25].Text.Trim())
				{
					e.Item.Cells[10].ForeColor = System.Drawing.Color.Red;
				}
				for(int i=1;i<13;i++)
				{
					if(e.Item.Cells[10+i].Text.Trim()!="0"&&e.Item.Cells[8].Text.Trim()!=e.Item.Cells[25+i].Text.Trim())
					{
						e.Item.Cells[10+i].ForeColor = System.Drawing.Color.Red;
					}
				}

			}
		}
	}
}
