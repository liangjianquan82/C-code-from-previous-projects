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
	/// Excelout 的摘要说明。
	/// </summary>
	public class CheckAccount : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button5;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		private IList list = null;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
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
			Response.AppendHeader("Content-Disposition","attachment;filename=分成比例有问题用户.xls");
			Response.ContentEncoding=System.Text.Encoding.GetEncoding("GB2312"); //设置输出流为简体中文
			Response.ContentType   =   "application/ms-excel"; //设置输出文件类型为excel文件。
			this.EnableViewState   =   false;
			System.Globalization.CultureInfo   myCItrad   =   new   System.Globalization.CultureInfo("ZH-CN",true); 
			System.IO.StringWriter   oStringWriter   =   new   System.IO.StringWriter(myCItrad);
			System.Web.UI.HtmlTextWriter   oHtmlTextWriter   =   new   System.Web.UI.HtmlTextWriter(oStringWriter);
			this.DataGrid1.RenderControl(oHtmlTextWriter); // 在这里设置保存那个数据源的数据.
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
				#region 注销
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
				//					string OneOffConnectFees = "0";//一次性收费
				//					string PaymentMonth = "0";//按月交费
				//					string FirstPayment = "0";//年结款
				//					string MovePay = "0";//迁移费
				//					string Now_Poundage = "0";
				//
				//					listdnj = dci.selectpay_info(e.Item.Cells[2].Text,Dropdownlist2.SelectedValue,i.ToString(),"年结");
				//					listdyj = dci.selectpay_info(e.Item.Cells[2].Text,Dropdownlist2.SelectedValue,i.ToString(),"月结");
				//					listdycx = dci.selectpay_info(e.Item.Cells[2].Text,Dropdownlist2.SelectedValue,i.ToString(),"一次性");
				//					listdqyf = dci.selectpay_info(e.Item.Cells[2].Text,Dropdownlist2.SelectedValue,i.ToString(),"迁移费");
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
