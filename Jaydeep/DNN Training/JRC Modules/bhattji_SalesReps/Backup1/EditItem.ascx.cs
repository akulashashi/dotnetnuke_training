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

#region  Namespaces 
using System;
using System.Text;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Common;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Exceptions;
using bhattji.Modules.SalesReps.Business;
//Imports Microsoft.ScalableHosting.Security
//Imports AspNetSecurity = Microsoft.ScalableHosting.Security

#endregion

namespace bhattji.Modules.SalesReps
{

    public abstract partial class EditItem : DotNetNuke.Entities.Modules.PortalModuleBase
	{

		#region " Properties "
		//Public ReadOnly Property BasePage() As DotNetNuke.Framework.CDefault
		//    Get
		//        Return CType(Me.Page, DotNetNuke.Framework.CDefault)
		//    End Get
		//End Property
		#endregion

		#region " Private Members "
		private int itemId;
		#endregion

		#region " Public Methods "

		//Private Sub RegisterJS()
		//    Dim SubModalJS As String = "<SCRIPT type=""text/javascript"" src=""" & ModulePath & "SubModal/subModal.js""></SCRIPT>"
		//    If (Not Page.ClientScript.IsClientScriptBlockRegistered("SubModalJS")) Then
		//        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "SubModalJS", SubModalJS)
		//    End If
		//    Dim SubModalCommonJS As String = "<SCRIPT type=""text/javascript"" src=""" & ModulePath & "SubModal/common.js""></SCRIPT>"
		//    If (Not Page.ClientScript.IsClientScriptBlockRegistered("SubModalCommonJS")) Then
		//        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "SubModalCommonJS", SubModalCommonJS)
		//    End If
		//End Sub

		//Private Sub AddToHeader()
		//    Dim ph As PlaceHolder = CType(Me.Page.FindControl("CSS"), PlaceHolder)
		//    If ph Is Nothing Then ph = CType(Me.Page.FindControl("phDNNHead"), PlaceHolder)

		//    If Not ph Is Nothing Then
		//        ph.Controls.Add(New LiteralControl("<script src=""" & ModulePath & "js/bhattjiModalPopup.js"" type=""text/javascript"" language=""javascript""></script>"))
		//    End If
		//End Sub

		private void bhattjiModalPopup()
		{
			//Me.Page.Header.Controls.Add(New LiteralControl("<script src=""" & ModulePath & "js/bhattjiModalPopup.js"" type=""text/javascript"" language=""javascript""></script>"))
            //Literal ltr = new Literal();//LiteralControl
            StringBuilder sb = new StringBuilder();

            sb.Append("<table id=\"tblPopup\" class=\"modalPopup\" style=\"display:none\" cellpadding=\"0\" cellspacing=\"0\">");
            sb.Append("<tr id=\"trTitle\" style=\"cursor:move;background-color:Navy;color:White;font-weight:bold\"><td id=\"tdTitle\"></td><td id=\"tdClose\" align=\"right\"></td></tr>");
            sb.Append("<tr style=\"background-color:Aqua\"><td id=\"tdContent\" align=\"center\" colspan=\"2\"></td></tr>");
            sb.Append("<tr style=\"background-color:Navy\"><td id=\"tdButtons\" align=\"center\" colspan=\"2\"></td></tr>");
            sb.Append("</table>"); 

			Controls.Add(new LiteralControl(sb.ToString()));

			Button hiddenTargetControlForModalPopup = new Button();
			
				hiddenTargetControlForModalPopup.ID = "hiddenTargetControlForModalPopup";
				hiddenTargetControlForModalPopup.Style.Add("display", "none");
			
			//hiddenTargetControlForModalPopup
			Controls.Add(hiddenTargetControlForModalPopup);

			AjaxControlToolkit.ModalPopupExtender actModalPopup = new AjaxControlToolkit.ModalPopupExtender();
			
				actModalPopup.ID = "programmaticModalPopup";
				actModalPopup.BehaviorID = "programmaticModalPopupBehavior";
				actModalPopup.TargetControlID = "hiddenTargetControlForModalPopup";
				actModalPopup.PopupControlID = "tblPopup";
				//.PopupDragHandleControlID = "tdTitle"
				actModalPopup.PopupDragHandleControlID = "trTitle";
				actModalPopup.BackgroundCssClass = "modalBackground";
				actModalPopup.DropShadow = true;
			
			//actModalPopup
			Controls.Add(actModalPopup);
		}

		private void HeadOfPage()
		{
			//Dim ph As PlaceHolder = CType(Me.BasePage.FindControl("CSS"), PlaceHolder)
			//Dim ph As PlaceHolder = CType(CType(Me.Page, DotNetNuke.Framework.CDefault).FindControl("CSS"), PlaceHolder)
			//Dim ph As PlaceHolder = CType(Me.Page.FindControl("CSS"), PlaceHolder)

			//If Not (ph Is Nothing) Then
			//    'Dim lit As New Literal
			//    'lit.Text = "<link rel=""stylesheet"" type=""text/css"" href=""" & ModulePath & "SubModal/subModal.css"" />"
			//    'lit.Text &= "<script type=""text/javascript"" src=""" & ModulePath & "SubModal/common.js""></script>"
			//    'lit.Text &= "<script type=""text/javascript"" src=""" & ModulePath & "SubModal/subModal.js""></script>"
			//    'ph.Controls.Add(lit)
			//    ph.Controls.Add(New LiteralControl("<link rel=""stylesheet"" type=""text/css"" href=""" & ModulePath & "SubModal/subModal.css"" /><script type=""text/javascript"" src=""" & ModulePath & "SubModal/common.js""></script><script type=""text/javascript"" src=""" & ModulePath & "SubModal/subModal.js""></script>"))
			//End If
			//Me.Page.Header.Controls.Add(New LiteralControl("<test></test>"))


            //Literal ltr = new Literal();
            StringBuilder sb = new StringBuilder();
            //Add Link & Scripts for the SubModal Popup 
            sb.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ModulePath + "SubModal/subModal.css\" /><script type=\"text/javascript\" src=\"" + ModulePath + "SubModal/common.js\"></script><script type=\"text/javascript\" src=\"" + ModulePath + "SubModal/subModal.js\"></script>");

            //Add Scripts for the bhattjiModalPopup 
            sb.Append("<script src=\"" + ModulePath + "js/bhattjiModalPopup.js\" type=\"text/javascript\" language=\"javascript\"></script>");

            //Add modalBackground Style for the bhattjiModalPopup 
            sb.Append("<style type=\"text/css\">.modalBackground{background-color:Gray;filter:alpha(opacity=70);opacity:0.7;}</style>");

            this.Page.Header.Controls.Add(new LiteralControl(sb.ToString()));
		}

		private void InitEveryTime()
		{
			//Register the JavaScripts
			HeadOfPage();
			//Add AJAX Modal Popup
			bhattjiModalPopup();

			//this needs to execute always, even on Postback, to the client script code is registred in InvokePopupCal
            //hypCalendarPublishDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtPublishDate);
            //hypCalendarExpiryDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtExpiryDate);

			ViewCategories MyViewCategories = (ViewCategories)LoadControl(ModulePath + "ViewCategories.ascx");
			{
				MyViewCategories.ModuleConfiguration = ModuleConfiguration;
				MyViewCategories.ID = "ViewCategories";
				MyViewCategories.Embeded = true;
			}
			//MyViewCategories
			phtCategories.Controls.Add(MyViewCategories);

			if (itemId > 0)
			{
				ViewPQR45s MyViewPQR45s = (ViewPQR45s)LoadControl(ModulePath + "ViewPQR45s.ascx");
				{
					MyViewPQR45s.ModuleConfiguration = ModuleConfiguration;
					MyViewPQR45s.ID = "ViewPQR45s";
					MyViewPQR45s.SalesRepId = itemId;
					MyViewPQR45s.Embeded = true;
				}
				//MyViewPQR45s
				divPQR45s.Controls.Add(MyViewPQR45s);
			}
		}

		private void InitFirstTime()
		{
			//Configure NavUrls for the Modal Popup
			{
				//.NavigateUrl = NavigateURL()
				//If .NavigateUrl.ToLower().EndsWith(".aspx") Then
				//    .NavigateUrl &= "?ViewType=ViewCategories&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"
				//Else
				//    .NavigateUrl &= "&ViewType=ViewCategories&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"
				//End If
				//.Attributes.Add("onclick", "showPopWin('" & EditUrl("EditType", "EditCat", "Edit", "Embeded=True", "SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin") & "', 400, 200, alert('callback')); return false;")
				hypViewCategories.NavigateUrl = EditUrl("EditType", "EditCat", "Edit", "Embeded=True", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin");//&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
				hypViewCategories.CssClass = "submodal-400-200-__doPostBack('" + cmdCancel.ClientID + "','')";
			}

			{
				hypModal.NavigateUrl = EditUrl("EditType", "EditCat", "Edit", "Embeded=True", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container");
				hypModal.CssClass = "submodal-400-300-alert('callback')";
			}

			//SetIconBar
			SetIconBar();

			//Make the PQR45Table Visible
			trPQR45s.Visible = tdDelete.Visible;

			//Make the AuditControl Visible
			ctlAudit.Visible = tdDelete.Visible;

			{
				ctlMediaSrc.ShowNone = true;
				ctlMediaSrc.ShowUrls = true;
				ctlMediaSrc.ShowFiles = true;
				ctlMediaSrc.ShowTabs = false;
				ctlMediaSrc.ShowLog = false;
				ctlMediaSrc.ShowNewWindow = false;
				ctlMediaSrc.ShowTrack = false;
				ctlMediaSrc.ShowUsers = false;
			}
			//.FileFilter = glbImageFileTypes
			//ctlMediaSrc
			{
				ctlMediaSrc2.ShowNone = true;
				ctlMediaSrc2.ShowUrls = true;
				ctlMediaSrc2.ShowFiles = true;
				ctlMediaSrc2.ShowTabs = false;
				ctlMediaSrc2.ShowLog = false;
				ctlMediaSrc2.ShowNewWindow = false;
				ctlMediaSrc2.ShowTrack = false;
				ctlMediaSrc2.ShowUsers = false;
			}
			//.FileFilter = glbImageFileTypes
			//ctlMediaSrc2
			{
				ctlNavURL.ShowNone = true;
				ctlNavURL.ShowUrls = true;
				ctlNavURL.ShowFiles = true;
				ctlNavURL.ShowTabs = true;
				ctlNavURL.ShowLog = true;
				ctlNavURL.ShowNewWindow = true;
				ctlNavURL.ShowTrack = true;
				ctlNavURL.ShowUsers = false;
			}
			//.FileFilter = glbImageFileTypes
			//ctlNavURL

			//Bind the Categories
			BindCategories();

		}

		private void SetIconBar()
		{
			//Give the ImageUrl
			imbAdd.ImageUrl = ModulePath + "img/bhattji_Add.jpg";
			imbUpdate.ImageUrl = ModulePath + "img/bhattji_Update.jpg";
			imbDelete.ImageUrl = ModulePath + "img/bhattji_Delete.jpg";
			imbCancel.ImageUrl = ModulePath + "img/bhattji_Cancel.jpg";
			hypImgPrint.ImageUrl = ModulePath + "img/bhattji_Print.jpg";

			//Give the Tooltip
			cmdAdd.ToolTip = Localization.GetString("Add");
			//cmdAdd.Text
			cmdUpdate.ToolTip = Localization.GetString("cmdUpdate");
			//cmdUpdate.Text
			cmdDelete.ToolTip = Localization.GetString("cmdDelete");
			//cmdDelete.Text
			cmdCancel.ToolTip = Localization.GetString("cmdCancel");
			//cmdCancel.Text
			hypPrint.ToolTip = hypPrint.Text;

			//Make the ControlButtons Visible
			tdDelete.Visible = !Null.IsNull(itemId);
			tdUpdate.Visible = tdDelete.Visible;
			tdPrint.Visible = tdDelete.Visible;
			tdAdd.Visible = !tdUpdate.Visible;

			if (tdDelete.Visible)
			{
				cmdDelete.Attributes.Add("onClick", "javascript:return confirm('" + Localization.GetString("DeleteItem") + "');");
				imbDelete.Attributes.Add("onClick", "javascript:return confirm('" + Localization.GetString("DeleteItem") + "');");
			}
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
				if (!(new OptionsInfo(ModuleId)).IsItemEditable(objSalesRep.ModuleId))
				{
					tdUpdate.Visible = false;
					tdDelete.Visible = false;
				}
				txtTitle.Text = objSalesRep.Title;
				try {
					ddlCategoryId.Items.FindByValue(objSalesRep.CategoryId.ToString()).Selected = true;
				}
				catch {
					ddlCategoryId.SelectedIndex = 0;
				}
				ctlMediaSrc.Url = objSalesRep.MediaSrc;
				if (objSalesRep.MediaWidth != string.Empty)
				{
					txtMediaWidth.Text = objSalesRep.MediaWidth;
				}
				if (objSalesRep.MediaHeight != string.Empty)
				{
					txtMediaHeight.Text = objSalesRep.MediaHeight;
				}
				if (objSalesRep.MediaAlign.ToLower() == "left")
				{
					rblMediaAlign.Items[0].Selected = true;
				}
				else
				{
					rblMediaAlign.Items[1].Selected = true;
				}
				teDescription.Text = objSalesRep.Description;


                //txtActualFields.Text = objSalesRep.ActualFields;

                if (objSalesRep .RepRate != string .Empty && objSalesRep.RepRate>0 )
                {
                   txt

				teDetails.Text = objSalesRep.Details;
				ctlMediaSrc2.Url = objSalesRep.MediaSrc2;
				if (objSalesRep.MediaWidth2 != string.Empty)
				{
					txtMediaWidth2.Text = objSalesRep.MediaWidth2;
				}
				if (objSalesRep.MediaHeight2 != string.Empty)
				{
					txtMediaHeight2.Text = objSalesRep.MediaHeight2;
				}
				if (objSalesRep.MediaAlign2.ToLower() == "left")
				{
					rblMediaAlign2.Items[0].Selected = true;
				}
				else
				{
					rblMediaAlign2.Items[1].Selected = true;
				}

				ctlNavURL.Url = objSalesRep.NavURL;

				if (!Null.IsNull(objSalesRep.PublishDate))
				{
					txtPublishDate.Text = objSalesRep.PublishDate.ToShortDateString();
				}
				if (!Null.IsNull(objSalesRep.ExpiryDate))
				{
					txtExpiryDate.Text = objSalesRep.ExpiryDate.ToShortDateString();
				}
				if (!Null.IsNull(objSalesRep.ViewOrder))
				{
					txtViewOrder.Text = objSalesRep.ViewOrder.ToString();
				}

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
						hypImgPrint.NavigateUrl = hypPrint.NavigateUrl;
						hypImgPrint.Target = "_blank";
						hypImgPrint.ToolTip = Localization.GetString("Print", LocalResourceFile);
						hypImgPrint.Attributes.Add("onmouseover", "window.status=this.title; return true");
					}
				}
				//hypImgPrint

				//Audit Control
				ctlAudit.CreatedByUser = objSalesRep.UpdatedByUser;
				ctlAudit.CreatedDate = objSalesRep.UpdatedDate.ToString();

				//Tracking Control
				ctlTracking.URL = objSalesRep.NavURL;
				ctlTracking.ModuleID = objSalesRep.ModuleId;
			}
			//objSalesRep

		}

		private SalesRepInfo PageToItem()
		{
			SalesRepInfo objSalesRep = new SalesRepInfo();
			//Initialise the ojbSalesRep object
			objSalesRep = (SalesRepInfo)CBO.InitializeObject(objSalesRep, typeof(Business.SalesRepInfo));

			//bind text values to object
			{
				objSalesRep.ItemId = itemId;
				objSalesRep.ModuleId = ModuleId;

				objSalesRep.Title = txtTitle.Text;
				try {
					objSalesRep.CategoryId = int.Parse(ddlCategoryId.SelectedValue);
				}
				catch {
				}
				objSalesRep.MediaSrc = ctlMediaSrc.Url;
				objSalesRep.MediaWidth = txtMediaWidth.Text;
				objSalesRep.MediaHeight = txtMediaHeight.Text;
				objSalesRep.MediaAlign = rblMediaAlign.SelectedValue;
				objSalesRep.Description = teDescription.Text;

				objSalesRep.ActualFields = txtActualFields.Text;

				objSalesRep.Details = teDetails.Text;
				objSalesRep.MediaSrc2 = ctlMediaSrc2.Url;
				objSalesRep.MediaWidth2 = txtMediaWidth2.Text;
				objSalesRep.MediaHeight2 = txtMediaHeight2.Text;
				objSalesRep.MediaAlign2 = rblMediaAlign2.SelectedValue;

				objSalesRep.NavURL = ctlNavURL.Url;
				//.TrackClicks = ctlNavURL.Track
				//.NewWindow = ctlNavURL.NewWindow

				if (txtPublishDate.Text != string.Empty)
				{
					try {
						objSalesRep.PublishDate = DateTime.Parse(txtPublishDate.Text);
					}
					catch {
					}
				}
				if (txtExpiryDate.Text != string.Empty)
				{
					try {
						objSalesRep.ExpiryDate = DateTime.Parse(txtExpiryDate.Text);
					}
					catch {
					}
				}

				if (txtViewOrder.Text != string.Empty)
				{
					try {
						objSalesRep.ViewOrder = int.Parse(txtViewOrder.Text);
					}
					catch {
					}
				}

				//Audit Control
				objSalesRep.UpdatedByUserId = UserInfo.UserID;
				objSalesRep.CreatedByUserId = objSalesRep.UpdatedByUserId;
			}

			//objSalesRep
			return objSalesRep;
		}

        private void AddUpdateItem()
        {
            try
            {
                // Only Update if the Entered Data is Valid
                if (Page.IsValid)
                {
                    //Dim objSalesRep As New SalesRepInfo
                    //'Initialise the ojbSalesRep object
                    //objSalesRep = CType(CBO.InitializeObject(objSalesRep, GetType(Business.SalesRepInfo)), SalesRepInfo)

                    //bind text values to object
                    //Dim objSalesRep As SalesRepInfo = PageToItem()


                    //Dim objSalesRepsController As New SalesRepsController
                    //If Null.IsNull(itemId) Then
                    //    itemId = objSalesRepsController.AddSalesRep(objSalesRep)
                    //Else
                    //    objSalesRepsController.UpdateSalesRep(objSalesRep)
                    //End If

                    //Add/Update to database checking the Null.IsNull(objSalesRep.ItemId)
                    itemId = (new SalesRepsController()).AddUpdateSalesRep(PageToItem());

                    //Url tracking
                    UpdateUrls();

                    //Redirect to the page as selected by the User in DropdownList
                    Response.Redirect(RedirectUrl(), true);
                }
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

		private void UpdateUrls()
		{
			// url tracking
			UrlController objUrls = new UrlController();
			// url tracking for MediaSrc
			{
				objUrls.UpdateUrl(PortalId, ctlMediaSrc.Url, ctlMediaSrc.UrlType, ctlMediaSrc.Log, ctlMediaSrc.Track, ModuleId, ctlMediaSrc.NewWindow);
			}
			//ctlMediaSrc
			{
				objUrls.UpdateUrl(PortalId, ctlMediaSrc2.Url, ctlMediaSrc2.UrlType, ctlMediaSrc2.Log, ctlMediaSrc2.Track, ModuleId, ctlMediaSrc2.NewWindow);
			}
			//ctlMediaSrc2
			{
				objUrls.UpdateUrl(PortalId, ctlNavURL.Url, ctlNavURL.UrlType, ctlNavURL.Log, ctlNavURL.Track, ModuleId, ctlNavURL.NewWindow);
			}
			//ctlNavURL
		}
		//UpdateUrls()

		private string RedirectUrl()
		{
			//Redirect to the page as selected by the User in DropdownList
			switch (ddlUpdateRedirection.SelectedValue.ToUpper()) {
				case "NEWITEM":
					//Redirect back to the Edit Page of the Item for Add
					return EditUrl();
				case "EDITITEM":
					if (Null.IsNull(itemId))
					{
						//Redirect back to the Edit Page of the Item for Add
						return EditUrl();
					}
					else
					{
						//Redirect back to this same Edit Page with same ItemId to Edit & Continue
						return EditUrl("ItemId", itemId.ToString());
					}

                    //break;
				case "ITEMDETAILS":
					if (Null.IsNull(itemId))
					{
						//Redirect back to the portal home page
						return Globals.NavigateURL();
					}
					else
					{
						//Redirect to the Detail Page of this Item for Viewing the details of this Item
						return EditUrl("ItemId", itemId.ToString(), "ItemDetails");
					}

                    //break;
				default:
					//"LISTING"
					//Redirect back to the portal home page
					return Globals.NavigateURL();
			}
		}
		//RedirectUrl()

		private void BindCategories()
		{
			{
				ddlCategoryId.DataValueField = "ItemId";
				ddlCategoryId.DataTextField = "Category";
				ddlCategoryId.DataSource = (new Business.CategoriesController()).GetAllCategories();
				ddlCategoryId.DataBind();
			}
			//ddlCategoryId
		}
        private void ShowCategories()
        {
            ShowCategories(true);
        }
		private void ShowCategories(bool Show)
		{
			phtCategories.Visible = Show;
			imbHideCategories.Visible = Show;
			imbShowCategories.Visible = !Show;
		}

		#endregion

		#region " Event Handlers "

		private void Page_Init(object sender, EventArgs e)
		{
			//Install the AJAX functionality
			if (DotNetNuke.Framework.AJAX.IsInstalled())
			{
				DotNetNuke.Framework.AJAX.RegisterScriptManager();

				DotNetNuke.Framework.AJAX.WrapUpdatePanelControl(ctlMediaSrc, true);
				//DotNetNuke.Framework.AJAX.RegisterPostBackControl(ctlMediaSrc)

				DotNetNuke.Framework.AJAX.WrapUpdatePanelControl(ctlMediaSrc2, true);
				//DotNetNuke.Framework.AJAX.RegisterPostBackControl(ctlMediaSrc2)

				DotNetNuke.Framework.AJAX.WrapUpdatePanelControl(ctlNavURL, true);
				//DotNetNuke.Framework.AJAX.RegisterPostBackControl(ctlNavURL)

				//DotNetNuke.Framework.AJAX.WrapUpdatePanelControl(phtCategories, True)
				//'DotNetNuke.Framework.AJAX.RegisterPostBackControl(ctlNavURL)

				//DotNetNuke.Framework.AJAX.WrapUpdatePanelControl(divPQR45s, True)
				//'DotNetNuke.Framework.AJAX.RegisterPostBackControl(ctlNavURL)

			}
		}

		private void Page_Load(object sender, EventArgs e)
		{
			try {
				OptionsInfo objOI = new OptionsInfo(ModuleId);
				if (objOI.OnlyHostCanEdit && (!DotNetNuke.Entities.Users.UserController.GetCurrentUserInfo().IsSuperUser))
				{
					//MsgBox("Sorry, Only Superusers can edit !!!", )
					//Response.Write("<script>alert('Sorry, Only Superusers can edit !!!')</script>")
					Response.Redirect(Globals.NavigateURL(), true);
				}
				//If objOI.OnlyHostCanEdit Then
				//    'Dim objUC As New Users.UserController
				//    Dim objHostUser As Users.UserInfo = Users.UserController.GetUser(PortalId, UserId, True)
				//    If Not objHostUser.IsSuperUser Then
				//        ' security violation attempt to access item not related to this Module
				//        'DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, "<a href=""" & NavigateURL() & """ title=""Click to go back"" onmouseover""window.status=this.title; return true"">Requires Host rights</a>", DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
				//        Response.Redirect(NavigateURL(), True)
				//    End If
				//End If


				//Dim objSalesRepsController As New SalesRepsController
				//Dim objSalesRep As New SalesRepInfo



				// Determine ItemId
				if ((Request.Params["ItemId"] == null) || (Request.Params["ItemId"] == ""))
				{
					itemId = Null.NullInteger;
				}
				//hypEditCategory.NavigateUrl = EditUrl("EditType", "EditCat")
				else
				{
					itemId = Int32.Parse(Request.Params["ItemId"]);

					//hypEditCategory.NavigateUrl = EditUrl("ItemId", itemId.ToString(), "Edit", "EditType=EditCat")
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
							//Load data
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

		private void imbShowCategories_Click(object sender, ImageClickEventArgs e)
		{
			ShowCategories(true);
		}

		private void imbHideCategories_Click(object sender, ImageClickEventArgs e)
		{
			BindCategories();
			ShowCategories();
		}

       	private void imbUpdate_Click(object sender, ImageClickEventArgs e)
		{
			cmdUpdate_Click(sender, new EventArgs());
		}
		private void cmdUpdate_Click(object sender, EventArgs e)
		{
            AddUpdateItem();
		}
             
        private void imbCancel_Click(object sender, ImageClickEventArgs e)
		{
			cmdCancel_Click(sender, new EventArgs());
		}
		private void cmdCancel_Click(object sender, EventArgs e)
		{
			try {
				//Redirect to the page as selected by the User in DropdownList
				Response.Redirect(RedirectUrl(), true);
			}
			catch (Exception exc) {
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		private void imbDelete_Click(object sender, ImageClickEventArgs e)
		{
			cmdDelete_Click(sender, new EventArgs());
		}
		private void cmdDelete_Click(object sender, EventArgs e)
		{
			try {
				if (!Null.IsNull(itemId))
				{
					SalesRepsController objSalesRepsController = new SalesRepsController();
					objSalesRepsController.DeleteSalesRep(itemId);
				}

				// Redirect back to the portal home page
				Response.Redirect(Globals.NavigateURL(), true);
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
            imbShowCategories.Click += new ImageClickEventHandler(imbShowCategories_Click);
            imbHideCategories.Click += new ImageClickEventHandler(imbHideCategories_Click);
            imbAdd.Click += new ImageClickEventHandler(imbUpdate_Click);
            cmdAdd.Click += new EventHandler(cmdUpdate_Click);
            imbUpdate.Click += new ImageClickEventHandler(imbUpdate_Click);
            cmdUpdate.Click += new EventHandler(cmdUpdate_Click);
            imbCancel.Click += new ImageClickEventHandler(imbCancel_Click);
            cmdCancel.Click += new EventHandler(cmdCancel_Click);
            imbDelete.Click += new ImageClickEventHandler(imbDelete_Click);
            cmdDelete.Click += new EventHandler(cmdDelete_Click);
            //this.Load += new EventHandler(this.Page_Init)
            //this.Load += new System.EventHandler(this.Page_Load);

        }

        #endregion

	}
	//EditItem

}
//bhattji.Modules.SalesReps
