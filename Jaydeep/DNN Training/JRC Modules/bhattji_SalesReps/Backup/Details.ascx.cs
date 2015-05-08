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
using bhattji.Modules.SalesReps.Business;
using DotNetNuke.Common;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Exceptions;
#endregion

namespace bhattji.Modules.SalesReps
{

    public abstract partial class Details : DotNetNuke.Entities.Modules.PortalModuleBase
	{

		#region " Private Members "

		private int itemId;
		private OptionsInfo objOI;

		#endregion

		#region " Methods "

		private void InitEveryTime()
		{
			//Put user code to initialize the page here
			string RattleImageJS = "<SCRIPT type=\"text/javascript\" src=\"" + ModulePath + "js/JbRattleImage.js\"></SCRIPT>";
			if ((!Page.ClientScript.IsClientScriptBlockRegistered("RattleImageJS")))
			{
				Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RattleImageJS", RattleImageJS);
			}
			string JB_ActiveContentJS = "<SCRIPT type=\"text/javascript\" src=\"" + ModulePath + "js/JB_ActiveContent.js\"></SCRIPT>";
			if ((!Page.ClientScript.IsClientScriptBlockRegistered("JB_ActiveContentJS")))
			{
				Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "JB_ActiveContentJS", JB_ActiveContentJS);
			}

		}

		private void InitFirstTime()
		{
			divButtons.Visible = (Request.QueryString["dnnprintmode"] == null) || (Request.QueryString["dnnprintmode"].ToLower() != "true");
			if (divButtons.Visible)
			{
				SetIconBar();
			}
			else
			{
				Controls.Add(new LiteralControl("<script type=\"text/javascript\" language=\"javascript\">window.print();</script>"));
			}
		}


		private void SetIconBar()
		{
			//Give the ImageUrl
			hypImgEdit.ImageUrl = ModulePath + "img/bhattji_Edit.jpg";

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
			}
			//hypClose
			{
				hypImgClose.Visible = true;
				if (hypImgClose.Visible)
				{
					hypImgClose.ImageUrl = ModulePath + "img/bhattji_Close.jpg";
                    hypImgClose.NavigateUrl = Globals.NavigateURL();
					hypImgClose.ToolTip = Localization.GetString("Close");
					hypImgClose.Attributes.Add("onmouseover", "window.status=this.title; return true");
				}
			}
			//hypImgClose

			//Print Authority
			{
				hypPrint.Visible = true;
				if (hypPrint.Visible)
				{
					hypPrint.NavigateUrl = EditUrl("ItemID", itemId.ToString(), "ItemDetails", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container");
					hypPrint.Target = "_blank";
					hypPrint.ToolTip = Localization.GetString("Print", LocalResourceFile);
					hypPrint.Attributes.Add("onmouseover", "window.status=this.title; return true");
				}
			}
			//hypPrint
			{
				hypImgPrint.Visible = true;
				if (hypImgPrint.Visible)
				{
					hypImgPrint.ImageUrl = ModulePath + "img/bhattji_Print.jpg";
					hypImgPrint.NavigateUrl = hypPrint.NavigateUrl;
					hypImgPrint.Target = "_blank";
					hypImgPrint.ToolTip = Localization.GetString("Print", LocalResourceFile);
					hypImgPrint.Attributes.Add("onmouseover", "window.status=this.title; return true");
				}
			}
			//hypImgPrint
		}
		//SetIconBar()

		private void ItemToPage(int ItemId)
		{
			if (!Null.IsNull(ItemId))
			{
				//Check for the Not-Null ItemId
				SalesRepInfo objSalesRep = (new SalesRepsController()).GetSalesRep(ItemId);
				//Check for the Not-Null objSalesRep
				if ((objSalesRep != null)) ItemToPage(objSalesRep); 
			}
		}

		private void ItemToPage(SalesRepInfo objSalesRep)
		{
			//Load objSalesRep data to the Page
			{
				hypTitle.Visible = true;
				//Not objOI.ShowListingOnly
				if (hypTitle.Visible)
				{
					//.Text = CType(DataBinder.Eval(e.Item.DataItem, "Title"), String)
					hypTitle.Text = objOI.GetDatedTitle(objSalesRep.Title, objSalesRep.DisplayDate.ToShortDateString());
					if (objSalesRep.NavURL != string.Empty)
					{
						hypTitle.NavigateUrl = objOI.LinkClickUrlLegacy(objSalesRep.NavURL);
					}
					hypTitle.Target = "_blank";
					//.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Item.DataItem, "ItemID"), String), "ItemDetails", "Item=SalesRep")
					//.CssClass = "SubHead"
					hypTitle.ToolTip = hypTitle.Text;
					//Request.ServerVariables("SERVER_NAME")
					hypTitle.Attributes.Add("onmouseover", "window.status=this.title; return true");
				}
			}
			//hypTitle

			{
				hypRatings.Visible = objOI.ShowRatings;
				if (hypRatings.Visible)
				{
					hypRatings.ImageUrl = ModulePath + "ratings/default/" + objSalesRep.RatingAverage.ToString() + ".gif";
					hypRatings.NavigateUrl = EditUrl("ItemID", objSalesRep.ItemId.ToString(), "ItemRatings", "Item=SalesRep");
					//If objOI.RatingsInNewWindow Then
					hypRatings.Target = "_blank";
					//Open the Rating Window in New Window
					//End If 'objOI.RatingsInNewWindow Then
					hypRatings.ToolTip = "Ratings '" + objSalesRep.Title + "'";
					hypRatings.Attributes.Add("onmouseover", "window.status=this.title; return true");
				}
			}
			//hypRatings

			{
				phtSalesRepDescription.Visible = objOI.AddDescription;
				//Not objOI.ShowListingOnly
				if (phtSalesRepDescription.Visible)
				{
					if (objSalesRep.MediaSrc != string.Empty)
					{
						bhattjiMedia hypThumb = new bhattjiMedia();
						hypThumb.Src = objOI.LinkClickUrlLegacy(objSalesRep.MediaSrc);
						//Select Case System.IO.Path.GetExtension(hypThumb.Src).ToLower()
						//    Case ".swf", ".flv"
						//        'ID = "bhattjiFlashPlayer" & ModuleId.ToString()
						//        hypThumb.MMType = "Flash"
						//        'FlashUrl = Src
						//    Case ".rm", ".rmvb"
						//        'ID = "bhattjiRealPlayer" & ModuleId.ToString()
						//        hypThumb.MMType = "RP"
						//        'VideoUrl = Src
						//    Case ".mov"
						//        'ID = "bhattjiQuickTimePlayer" & ModuleId.ToString()
						//        hypThumb.MMType = "QtP"
						//        'VideoUrl = Src
						//    Case ".gif", ".jpg", ".jpeg", ".jpe"
						//        'ID = "bhattjiQuickTimePlayer" & ModuleId.ToString()
						//        hypThumb.MMType = "Image"
						//        'VideoUrl = Src
						//    Case Else '".wmv"
						//        'ID = "bhattjiWindowsMediaPlayer" & ModuleId.ToString()
						//        hypThumb.MMType = "WMP"
						//        'VideoUrl = Src
						//End Select
						if (objSalesRep.NavURL != string.Empty)
						{
							hypThumb.NavigateUrl = objOI.LinkClickUrlLegacy(objSalesRep.NavURL);
						}
						hypThumb.Target = "_blank";
						//If objSalesRep.MediaWidth <> String.Empty Then
						//    hypThumb.MMWidth = objSalesRep.MediaWidth
						//End If
						//If objSalesRep.MediaHeight <> String.Empty Then
						//    hypThumb.MMHeight = objSalesRep.MediaHeight
						//End If
						//hypThumb.MMAlign = objSalesRep.MediaAlign
						hypThumb.AltText = objSalesRep.Title;
						hypThumb.Transition = objOI.Transition;
						hypThumb.RattleImage = objOI.RattleImage;

						phtSalesRepDescription.Controls.Add(hypThumb);
					}
					Literal ltrSalesRepDescription = new Literal();
					ltrSalesRepDescription.Text = Server.HtmlDecode(objSalesRep.Description);
					phtSalesRepDescription.Controls.Add(ltrSalesRepDescription);

				}
			}

			lblActualFields.Text = objSalesRep.ActualFields;

			{
				phtSalesRepDetails.Visible = true;
				//Not objOI.ShowListingOnly
				if (phtSalesRepDetails.Visible)
				{
					if (objSalesRep.MediaSrc2 != string.Empty)
					{
						bhattjiMedia hypThumb = new bhattjiMedia();
						hypThumb.Src = objOI.LinkClickUrlLegacy(objSalesRep.MediaSrc2);
						//Select Case System.IO.Path.GetExtension(hypThumb.Src).ToLower()
						//    Case ".swf", ".flv"
						//        'ID = "bhattjiFlashPlayer" & ModuleId.ToString()
						//        hypThumb.MMType = "Flash"
						//        'FlashUrl = Src
						//    Case ".rm", ".rmvb"
						//        'ID = "bhattjiRealPlayer" & ModuleId.ToString()
						//        hypThumb.MMType = "RP"
						//        'VideoUrl = Src
						//    Case ".mov"
						//        'ID = "bhattjiQuickTimePlayer" & ModuleId.ToString()
						//        hypThumb.MMType = "QtP"
						//        'VideoUrl = Src
						//    Case ".gif", ".jpg", ".jpeg", ".jpe"
						//        'ID = "bhattjiQuickTimePlayer" & ModuleId.ToString()
						//        hypThumb.MMType = "Image"
						//        'VideoUrl = Src
						//    Case Else '".wmv"
						//        'ID = "bhattjiWindowsMediaPlayer" & ModuleId.ToString()
						//        hypThumb.MMType = "WMP"
						//        'VideoUrl = Src
						//End Select
						if (objSalesRep.NavURL != string.Empty)
						{
							hypThumb.NavigateUrl = objOI.LinkClickUrlLegacy(objSalesRep.NavURL);
						}
						hypThumb.Target = "_blank";
						//If objSalesRep.MediaWidth <> String.Empty Then
						//    hypThumb.MMWidth = objSalesRep.MediaWidth
						//End If
						//If objSalesRep.MediaHeight <> String.Empty Then
						//    hypThumb.MMHeight = objSalesRep.MediaHeight
						//End If
						//hypThumb.MMAlign = objSalesRep.MediaAlign
						hypThumb.AltText = objSalesRep.Title;
						hypThumb.Transition = objOI.Transition;
						hypThumb.RattleImage = objOI.RattleImage;

						phtSalesRepDetails.Controls.Add(hypThumb);
					}
					Literal ltrSalesRepDetails = new Literal();
					ltrSalesRepDetails.Text = Server.HtmlDecode(objSalesRep.Details);
					phtSalesRepDetails.Controls.Add(ltrSalesRepDetails);

				}
			}

			{
				hypMoreLink.Visible = (!objOI.HideTextLink) & (objSalesRep.NavURL != string.Empty);
				if (hypMoreLink.Visible)
				{
					hypMoreLink.NavigateUrl = DotNetNuke.Common.Globals.LinkClick(objSalesRep.NavURL, TabId, ModuleId, objSalesRep.TrackClicks);
					if (objSalesRep.NewWindow)
					{
						hypMoreLink.Target = "_blank";
					}
					hypMoreLink.Attributes.Add("onmouseover", "window.status=this.title; return true");
				}
			}
			//hypMoreLink

			//Edit Authority
			tdEdit.Visible = IsEditable && objOI.IsItemEditable(objSalesRep.ModuleId);

			{
				hypEditItem.Visible = tdEdit.Visible;
				if (hypEditItem.Visible)
				{
					hypEditItem.NavigateUrl = EditUrl("ItemID", itemId.ToString());
					hypEditItem.Attributes.Add("onmouseover", "window.status=this.title; return true");
				}
			}
			//hypEditItem

			{
				hypEdit.Visible = tdEdit.Visible;
				if (hypEdit.Visible)
				{
					hypEdit.NavigateUrl = EditUrl("ItemID", itemId.ToString());
					hypEdit.ToolTip = Localization.GetString("Edit");
					hypEdit.Attributes.Add("onmouseover", "window.status=this.title; return true");
				}
			}
			//hypEdit
			{
				hypImgEdit.Visible = hypEdit.Visible;
				if (hypImgEdit.Visible)
				{
					hypImgEdit.NavigateUrl = EditUrl("ItemID", itemId.ToString());
					hypImgEdit.ToolTip = Localization.GetString("Edit");
					hypImgEdit.Attributes.Add("onmouseover", "window.status=this.title; return true");
				}
			}
			//hypImgEdit

			//Audit Control
			{
				ctlAudit.CreatedByUser = objSalesRep.UpdatedByUser;
				ctlAudit.CreatedDate = objSalesRep.UpdatedDate.ToString();
			}
			//ctlAudit

			//Tracking Control
			{
				ctlTracking.URL = objSalesRep.NavURL;
				ctlTracking.ModuleID = objSalesRep.ModuleId;
			}
			//ctlTracking
		}

		#endregion

		#region " Event Handlers "

		private void Page_Load(object sender, EventArgs e)
		{
			try {
				objOI = new OptionsInfo(ModuleId);
             
				// Determine ItemId of Announcement to Display
				if ((Request.QueryString["ItemId"] != null))
				{
					itemId = Int32.Parse(Request.QueryString["ItemId"]);
				}
				else
				{
					itemId = Convert.ToInt32(DotNetNuke.Common.Utilities.Null.NullInteger);
				}

				InitEveryTime();

				if (!Page.IsPostBack)
				{
					//Initilise the Controls and set its properties as well as Visiblity
					InitFirstTime();

					if (!Null.IsNull(itemId))
					{
						SalesRepInfo objSalesRep = (new SalesRepsController()).GetSalesRep(itemId);

						if ((objSalesRep != null))
						{
							ItemToPage(objSalesRep);
						}
						else
						{
							// security violation attempt to access item not related to this Module
                            Response.Redirect(Globals.NavigateURL(), true);
						}

					}


				}
			}


			catch (Exception exc) {
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
           //this.Load += new System.EventHandler(this.Page_Load);

        }
       
        #endregion

	}

}
