using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.IO;

namespace SuperSecureBank
{
	public partial class ShowAccount : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				Account.DataSource = AccountMgmt.GetAccount(Request.Params["ShowAccount"]);
                Account.DataBind();
			}
			catch (ThreadAbortException tae)
			{
				//nothing
			}
			catch (Exception ex)
			{
                ErrorLogging.AddException("Error in " + Path.GetFileName(Request.PhysicalPath), ex);
                message.Visible = true;
                message.Text = ex.ToString();
				// Response.Redirect("ActionDone.aspx?Title=Show Account&Text=We're sorry, but there was an error viewing your account. Please try again at a later date or call support at: 1-800-555-1212");
			}
		}
	}
}