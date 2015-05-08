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

#region " Namespaces "
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using bhattji.Modules.MyLogins.Business;
using DotNetNuke.Common;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
#endregion

namespace bhattji.Modules.MyLogins
{
    public abstract partial class Details : MyLoginModuleBase
	{
        #region " Private Members "

		private int itemId;
		private OptionsInfo objOI;

		#endregion

		#region " Methods "

		private void InitEveryTime()
		{
			//Put user code to initialize the page here
            //string RattleImageJS = "<SCRIPT type=\"text/javascript\" src=\"" + ControlPath + "js/JbRattleImage.js\"></SCRIPT>";
            //if ((!Page.ClientScript.IsClientScriptBlockRegistered("RattleImageJS")))
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RattleImageJS", RattleImageJS);
            if ((!Page.ClientScript.IsClientScriptIncludeRegistered("RattleImageJS")))
                Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "RattleImageJS", ControlPath + "js/JbRattleImage.js");

            //string JB_ActiveContentJS = "<SCRIPT type=\"text/javascript\" src=\"" + ControlPath + "js/JB_ActiveContent.js\"></SCRIPT>";
            //if ((!Page.ClientScript.IsClientScriptBlockRegistered("JB_ActiveContentJS")))
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "JB_ActiveContentJS", JB_ActiveContentJS);
            if ((!Page.ClientScript.IsClientScriptIncludeRegistered("JB_ActiveContentJS")))
                Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "JB_ActiveContentJS", ControlPath + "js/JB_ActiveContent.js");           
		}

		private void InitFirstTime()
		{
            divButtons.Visible = string.IsNullOrEmpty(Request.QueryString["SkinSrc"]);
			if (divButtons.Visible)
				SetIconBar();
			else
				Controls.Add(new LiteralControl("<script type=\"text/javascript\" language=\"javascript\">window.print();</script>"));
		}


		private void SetIconBar()
		{
			//Give the ImageUrl
            //hypImgEdit.ImageUrl = ControlPath + "img/bhattji_Edit.jpg";

			//Give Tooltip
			hypEdit.ToolTip = hypEdit.Text;

			//Close Authority
			{
				hypClose.Visible = true;
				if (hypClose.Visible)
				{
                    hypClose.NavigateUrl = Globals.NavigateURL();
					hypClose.ToolTip = Localization.GetString("Close");
					hypClose.Attributes.Add("onmouseover", "window.status=this.title; return true");
				}
			} //hypClose
            //{
            //    hypImgClose.Visible = true;
            //    if (hypImgClose.Visible)
            //    {
            //        hypImgClose.ImageUrl = ControlPath + "img/bhattji_Close.jpg";
            //        hypImgClose.NavigateUrl = Globals.NavigateURL();
            //        hypImgClose.ToolTip = Localization.GetString("Close");
            //        hypImgClose.Attributes.Add("onmouseover", "window.status=this.title; return true");
            //    }
            //} //hypImgClose

			//Print Authority
			{
				hypPrint.Visible = true;
				if (hypPrint.Visible)
				{
                    //hypPrint.NavigateUrl = EditUrl("ItemID", itemId.ToString(), "ItemDetails", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container");
                    hypPrint.NavigateUrl = EditUrl("ItemID", itemId.ToString(), "Reports", "ReportType=ItemDetails", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container");
                    hypPrint.Target = "_blank";
					hypPrint.ToolTip = Localization.GetString("Print", LocalResourceFile);
					hypPrint.Attributes.Add("onmouseover", "window.status=this.title; return true");
				}
			} //hypPrint
            //{
            //    hypImgPrint.Visible = true;
            //    if (hypImgPrint.Visible)
            //    {
            //        hypImgPrint.ImageUrl = ControlPath + "img/bhattji_Print.jpg";
            //        hypImgPrint.NavigateUrl = hypPrint.NavigateUrl;
            //        hypImgPrint.Target = "_blank";
            //        hypImgPrint.ToolTip = Localization.GetString("Print", LocalResourceFile);
            //        hypImgPrint.Attributes.Add("onmouseover", "window.status=this.title; return true");
            //    }
            //} //hypImgPrint
		} //SetIconBar()

		private void ItemToPage(int ItemId)
		{
			if (!Null.IsNull(ItemId))
			{
				//Check for the Not-Null ItemId
				MyLoginInfo objMyLogin = (new MyLoginsController()).GetMyLogin(ItemId);
				//Check for the Not-Null objMyLogin
				if ((objMyLogin != null)) ItemToPage(objMyLogin); 
			}
		}

		private void ItemToPage(MyLoginInfo objMyLogin)
		{
			//Load objMyLogin data to the Page
			{
				hypTitle.Visible = true;
				//Not objOI.ShowListingOnly
				if (hypTitle.Visible)
				{
					//.Text = CType(DataBinder.Eval(e.Item.DataItem, "Title"), String)
					hypTitle.Text = objOI.GetDatedTitle(objMyLogin.Title, objMyLogin.DisplayDate.ToShortDateString());
					if (objMyLogin.NavURL != string.Empty)
					{
						hypTitle.NavigateUrl = objOI.LinkClickUrlLegacy(objMyLogin.NavURL);
					}
					hypTitle.Target = "_blank";
					hypTitle.ToolTip = hypTitle.Text;
					hypTitle.Attributes.Add("onmouseover", "window.status=this.title; return true");
				}
			} //hypTitle

			{
				hypRatings.Visible = objOI.ShowRatings;
				if (hypRatings.Visible)
				{
					hypRatings.ImageUrl = ControlPath + "ratings/default/" + objMyLogin.RatingAverage.ToString() + ".gif";
					hypRatings.NavigateUrl = EditUrl("ItemID", objMyLogin.ItemId.ToString(), "ItemRatings", "Item=MyLogin");
					hypRatings.Target = "_blank";
					//Open the Rating Window in New Window
					//End If 'objOI.RatingsInNewWindow Then
					hypRatings.ToolTip = "Ratings '" + objMyLogin.Title + "'";
					hypRatings.Attributes.Add("onmouseover", "window.status=this.title; return true");
				}
			} //hypRatings

			{
				phtMyLoginDescription.Visible = objOI.AddDescription;
				//Not objOI.ShowListingOnly
				if (phtMyLoginDescription.Visible)
				{
					if (objMyLogin.MediaSrc != string.Empty)
					{
						bhattjiMedia hypThumb = new bhattjiMedia();
						hypThumb.Src = objOI.LinkClickUrlLegacy(objMyLogin.MediaSrc);
						
						if (objMyLogin.NavURL != string.Empty)
						{
							hypThumb.NavigateUrl = objOI.LinkClickUrlLegacy(objMyLogin.NavURL);
						}
						hypThumb.Target = "_blank";
						hypThumb.AltText = objMyLogin.Title;
						hypThumb.Transition = objOI.Transition;
						hypThumb.RattleImage = objOI.RattleImage;

						phtMyLoginDescription.Controls.Add(hypThumb);
					}
					Literal ltrMyLoginDescription = new Literal();
					ltrMyLoginDescription.Text = Server.HtmlDecode(objMyLogin.Description);
					phtMyLoginDescription.Controls.Add(ltrMyLoginDescription);

				}
			}

			lblActualFields.Text = objMyLogin.ActualFields;

			{
				phtMyLoginDetails.Visible = true;
				//Not objOI.ShowListingOnly
				if (phtMyLoginDetails.Visible)
				{
					if (objMyLogin.MediaSrc2 != string.Empty)
					{
						bhattjiMedia hypThumb = new bhattjiMedia();
						hypThumb.Src = objOI.LinkClickUrlLegacy(objMyLogin.MediaSrc2);

						if (objMyLogin.NavURL != string.Empty)
						{
							hypThumb.NavigateUrl = objOI.LinkClickUrlLegacy(objMyLogin.NavURL);
						}
						hypThumb.Target = "_blank";
						hypThumb.AltText = objMyLogin.Title;
						hypThumb.Transition = objOI.Transition;
						hypThumb.RattleImage = objOI.RattleImage;

						phtMyLoginDetails.Controls.Add(hypThumb);
					}
					Literal ltrMyLoginDetails = new Literal();
					ltrMyLoginDetails.Text = Server.HtmlDecode(objMyLogin.Details);
					phtMyLoginDetails.Controls.Add(ltrMyLoginDetails);

				}
			}

			{
				hypMoreLink.Visible = (!objOI.HideTextLink) & (objMyLogin.NavURL != string.Empty);
				if (hypMoreLink.Visible)
				{
					hypMoreLink.NavigateUrl = DotNetNuke.Common.Globals.LinkClick(objMyLogin.NavURL, TabId, ModuleId, objMyLogin.TrackClicks);
					if (objMyLogin.NewWindow)
					{
						hypMoreLink.Target = "_blank";
					}
					hypMoreLink.Attributes.Add("onmouseover", "window.status=this.title; return true");
				}
			}//hypMoreLink

			//Edit Authority
			liEdit.Visible = IsEditable && objOI.IsItemEditable(objMyLogin.ModuleId);

			{
				hypEditItem.Visible = liEdit.Visible;
				if (hypEditItem.Visible)
				{
					hypEditItem.NavigateUrl = EditUrl("ItemID", itemId.ToString());
					hypEditItem.Attributes.Add("onmouseover", "window.status=this.title; return true");
				}
			}//hypEditItem

			{
				hypEdit.Visible = liEdit.Visible;
				if (hypEdit.Visible)
				{
					hypEdit.NavigateUrl = EditUrl("ItemID", itemId.ToString());
					hypEdit.ToolTip = Localization.GetString("Edit");
					hypEdit.Attributes.Add("onmouseover", "window.status=this.title; return true");
				}
			}//hypEdit
            //{
            //    hypImgEdit.Visible = hypEdit.Visible;
            //    if (hypImgEdit.Visible)
            //    {
            //        hypImgEdit.NavigateUrl = EditUrl("ItemID", itemId.ToString());
            //        hypImgEdit.ToolTip = Localization.GetString("Edit");
            //        hypImgEdit.Attributes.Add("onmouseover", "window.status=this.title; return true");
            //    }
            //}//hypImgEdit

			//Audit Control
			{
				ctlAudit.CreatedByUser = objMyLogin.UpdatedByUser;
				ctlAudit.CreatedDate = objMyLogin.UpdatedDate.ToString();
			}
			//ctlAudit

			//Tracking Control
			{
				ctlTracking.URL = objMyLogin.NavURL;
				ctlTracking.ModuleID = objMyLogin.ModuleId;
			} //ctlTracking
		}

		#endregion

		#region " Event Handlers "

		private void Page_Load(object sender, EventArgs e)
		{
            try
            {
                objOI = new OptionsInfo(ModuleId);

                // Determine ItemId of Announcement to Display
                if (string.IsNullOrEmpty(Request.QueryString["ItemId"]))
                    itemId = Null.NullInteger;
                else
                    itemId = Convert.ToInt32(Request.QueryString["ItemId"]);

                if (!Null.IsNull(itemId))
                {
                    InitEveryTime();

                    if (!Page.IsPostBack)
                    {
                        //Initilise the Controls and set its properties as well as Visiblity
                        InitFirstTime();

                        MyLoginInfo objMyLogin = (new MyLoginsController()).GetMyLogin(itemId);

                        if (objMyLogin != null)
                        {
                            ItemToPage(objMyLogin);
                        }
                        else
                        {
                            // security violation attempt to access item not related to this Module
                            Response.Redirect(Globals.NavigateURL(), true);
                        }
                    }
                }
                else
                {
                    // security violation attempt to access item not related to this Module
                    Response.Redirect(Globals.NavigateURL(), true);
                }
            }

            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
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
           ////this.Load += new System.EventHandler(this.Page_Load);
            //this.Load += Page_Load;
        }
       
        #endregion

	}

}
