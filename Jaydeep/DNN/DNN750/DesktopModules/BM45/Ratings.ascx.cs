// Copyright (c) 2002-2005
// by Jaydeep Bhatt, Vision Consultants. ( http://www.bhattji.com )
//
// Permission is hereby granted, to the person obtaining a copy of this software legaly and associated 
// documentation files (the "Software"), to deal in the Software with restriction, including with limitation 
// the rights to use, copy, modify, merge, PublishDate, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
//

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using bhattji.Modules.XYZ70s.Business;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;

namespace bhattji.Modules.XYZ70s
{

    public abstract partial class Ratings : XYZ70ModuleBase
	{

		#region " Private Members "

		public int itemId;

		#endregion

		#region " Private Methods "

		private void SetIconBar()
		{
			//Give the ImageUrl
			imbUpdate.ImageUrl = ControlPath + "img/bhattji_Update.jpg";
			imbCancel.ImageUrl = ControlPath + "img/bhattji_Cancel.jpg";
			imbClose.ImageUrl = ControlPath + "img/bhattji_Close.jpg";

			//Give the Tooltip
			cmdUpdate.ToolTip = Localization.GetString("cmdUpdate");
			//cmdUpdate.Text
			cmdCancel.ToolTip = Localization.GetString("cmdCancel");
			//cmdCancel.Text
			cmdClose.ToolTip = Localization.GetString("Close");
			//cmdClose.Text
		}
		//SetIconBar()

        private void CancelItem()
        {
            try
            {
                //Dim objOI As New OptionsInfo(ModuleId)
                //If objOI.RatingsInNewWindow Then
                Response.Write("<script>window.close();</script>");
            }
            
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        private void UpdateXYZ70RatingItem()
        {
            try
            {
                // Only Update if the Entered Data is Valid
                if (Page.IsValid == true)
                {
                    XYZ70sController objXYZ70sController = new XYZ70sController();
                    int intRatingTotal;
                    try
                    {
                        intRatingTotal = int.Parse(rblRatings.SelectedValue);
                    }
                    catch
                    {
                        intRatingTotal = 0;
                    }
                    objXYZ70sController.UpdateXYZ70Rating(itemId, intRatingTotal);

                    rblRatings.Visible = false;
                    //tdUpdate.Visible = False
                    cmdUpdate.Visible = false;
                    imbUpdate.Visible = cmdUpdate.Visible;
                    //tdCancel.Visible = False
                    cmdCancel.Visible = false;
                    imbCancel.Visible = cmdCancel.Visible;
                    //tdClose.Visible = True
                    cmdClose.Visible = true;
                    imbClose.Visible = cmdClose.Visible;

                    lblRatings.Text = "Congratulations ! You have successfully updated the ratings, with your rating as " + "<img src=\"" + ControlPath + "ratings/default/" + intRatingTotal.ToString() + ".gif\" border=\"0\"> " + intRatingTotal.ToString() + " Stars";

                }
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

		#endregion

		#region " Event Handlers "

		private void Page_Load(object sender, EventArgs e)
		{
			try {

				// Determine ItemId
				if ((Request.Params["ItemId"] != null))
				{
					itemId = Int32.Parse(Request.Params["ItemId"]);
				}

				if (!Page.IsPostBack)
				{
					if (!Null.IsNull(itemId))
					{
						XYZ70Info objXYZ70 = (new XYZ70sController()).GetXYZ70(itemId);
						lblRatings.Text = "Rate the '" + objXYZ70.Title + "' on a scale of 0-10";

						{
							rblRatings.Items.Clear();
							int I;
							for (I = 0; I <= 10; I++) {
								//.Items.Add("<img src=""" & ControlPath & "ratings/default/" & I.ToString() & ".gif"" border=""0""> " & I.ToString() & " Stars")
								rblRatings.Items.Add(new ListItem("<img src=\"" + ControlPath + "ratings/default/" + I.ToString() + ".gif\" border=\"0\"> " + I.ToString() + " Stars", I.ToString()));
							}
							//I
							try {
								rblRatings.Items.FindByValue(objXYZ70.RatingAverage.ToString()).Selected = true;
							}
							catch {
								rblRatings.SelectedIndex = 5;
							}
						} //rblRatings
					}
					//Not Null.IsNull(itemId) Then

					SetIconBar();

				}
				//Not Page.IsPostBack Then
			}
			catch (Exception exc) {
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		private void imbUpdate_Click(object sender, ImageClickEventArgs e)
		{
			cmdUpdate_Click(null, null);
		}
		private void cmdUpdate_Click(object sender, EventArgs e)
		{
            UpdateXYZ70RatingItem();
		}

		private void imbCancel_Click(object sender, ImageClickEventArgs e)
		{
			cmdCancel_Click(null, null);
		}
		private void cmdCancel_Click(object sender, EventArgs e)
		{
            CancelItem();
		}


		#endregion

        #region " Web Form Designer generated code "
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            //imbUpdate.Click += new ImageClickEventHandler(imbUpdate_Click);
            //cmdUpdate.Click += new EventHandler(cmdUpdate_Click);
            //imbCancel.Click += new ImageClickEventHandler(imbCancel_Click);
            //cmdCancel.Click += new EventHandler(cmdCancel_Click);
            ////this.Load += new EventHandler(this.Page_Load);
            imbUpdate.Click += imbUpdate_Click;
            cmdUpdate.Click += cmdUpdate_Click;
            imbCancel.Click += imbCancel_Click;
            cmdCancel.Click += cmdCancel_Click;
            //this.Load += Page_Load;
        }

        #endregion

	}
	//Ratings

}
//bhattji.Modules.XYZ70s
