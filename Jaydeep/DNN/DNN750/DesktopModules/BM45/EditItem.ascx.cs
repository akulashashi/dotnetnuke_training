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
//using bhattji.Modules.XYZ70s.Business;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework;
using DotNetNuke.Web.UI.WebControls;

#endregion

namespace bhattji.Modules.XYZ70s
{
    public abstract partial class EditItem : XYZ70ModuleBase
    {

        #region " Properties "
        #endregion

        #region " Private Members "
        private int itemId;
        #endregion

        #region " Public Methods "

        void HeadOfPage()
        {
            //if (this.Page.Header.FindControl("ltrModalHead") == null)
            //{

            //    Literal ltr = new Literal();
            //    ltr.ID = "ltrModalHead";
            //    ltr.Text = "<script src=\"" + ControlPath + "js/bhattjiModalPopup.js\" type=\"text/javascript\" language=\"javascript\"></script>"
            //             + "<style type=\"text/css\">.modalBackground{background-color:Gray;filter:alpha(opacity=70);opacity:0.7;}</style>";

            //    this.Page.Header.Controls.Add(ltr);
            //}
        }
        void BottomOfPage()
        {
            //if (this.Page.FindControl("ClientResourcesFormBottom") != null)
            //{

            //    Literal ltr = new Literal();
            //    //ltr.ID = "ltrModalHead";
            //    ltr.Text = "<script type=\"text/javascript\" language=\"javascript\">$(\"#" + txtPublishDate.ClientID + "\").glDatePicker();</script>";
            //    PlaceHolder pht = (PlaceHolder)this.Page.FindControl("ClientResourcesFormBottom");
            //    pht.Controls.Add(ltr);
            //}
        }
        private void InitEveryTime()
        {
            ViewCategories MyViewCategories = (ViewCategories)LoadControl(ControlPath + "ViewCategories.ascx");
            MyViewCategories.ModuleConfiguration = ModuleConfiguration;
            MyViewCategories.ID = "ViewCategories";
            MyViewCategories.Embeded = true;
            phtCategories.Controls.Add(MyViewCategories);
        }

        private void InitFirstTime()
        {
            //Register the JavaScripts
            HeadOfPage();
            BottomOfPage();

            SetIconBar();

            //Make the AuditControl Visible
            ctlAudit.Visible = liDelete.Visible;

            //Bind the Categories
            BindCategories();
            /*CreateBindControlMethodCallStub*/
        }

        private void SetIconBar()
        {
            //Give the Tooltips
            cmdAdd.ToolTip = Localization.GetString("Add");//cmdAdd.Text
            cmdUpdate.ToolTip = Localization.GetString("cmdUpdate");//cmdUpdate.Text
            cmdDelete.ToolTip = Localization.GetString("cmdDelete");//cmdDelete.Text
            cmdCancel.ToolTip = Localization.GetString("cmdCancel");//cmdCancel.Text
            hypPrint.ToolTip = hypPrint.Text;

            //Make the ControlButtons Visible
            liDelete.Visible = !Null.IsNull(itemId);
            liUpdate.Visible = liDelete.Visible;
            liPrint.Visible = liDelete.Visible;
            liAdd.Visible = !liUpdate.Visible;

            if (liDelete.Visible)
            {
                cmdDelete.Attributes.Add("onClick", "javascript:return confirm('" + Localization.GetString("DeleteItem") + "');");
            }
        } //SetIconBar()

        private void ItemToPage(int ItemId)
        {
            if (!Null.IsNull(ItemId))
            {
                //Check for the Not-Null ItemId
                XYZ70Info objXYZ70 = (new XYZ70sController()).GetXYZ70(ItemId);
                //Check for the Not-Null objXYZ70
                if ((objXYZ70 != null)) ItemToPage(objXYZ70);
            }
        }

        private void ItemToPage(XYZ70Info objXYZ70)
        {
            //Load objXYZ70 data to the Page
            if (!(new OptionsInfo(ModuleId)).IsItemEditable(objXYZ70.ModuleId))
            {
                liUpdate.Visible = false;
                liDelete.Visible = false;
            }
            txtTitle.Text = objXYZ70.Title;
            try { ddlCategoryId.SelectedValue = objXYZ70.CategoryId.ToString(); }
            catch { ddlCategoryId.SelectedIndex = 0; }
            ctlMediaSrc.Url = objXYZ70.MediaSrc;
            if (!string.IsNullOrEmpty(objXYZ70.MediaWidth))
                txtMediaWidth.Text = objXYZ70.MediaWidth;
            if (!string.IsNullOrEmpty(objXYZ70.MediaHeight))
                txtMediaHeight.Text = objXYZ70.MediaHeight;

            if (objXYZ70.MediaAlign.ToLower() == "left")
                rblMediaAlign.SelectedIndex = 0;
            else
                rblMediaAlign.SelectedIndex = 1;
            teDescription.Text = objXYZ70.Description;

            /*CreateEditItemToPageStub*/

            teDetails.Text = objXYZ70.Details;
            ctlMediaSrc2.Url = objXYZ70.MediaSrc2;
            if (!string.IsNullOrEmpty(objXYZ70.MediaWidth2))
                txtMediaWidth2.Text = objXYZ70.MediaWidth2;
            if (!string.IsNullOrEmpty(objXYZ70.MediaHeight2))
                txtMediaHeight2.Text = objXYZ70.MediaHeight2;

            if (objXYZ70.MediaAlign2.ToLower() == "left")
                rblMediaAlign2.SelectedIndex = 0;
            else
                rblMediaAlign2.SelectedIndex = 1;

            ctlNavURL.Url = objXYZ70.NavURL;

            ddpPublishDate.SelectedDate = objXYZ70.PublishDate;
            ddpExpiryDate.SelectedDate = objXYZ70.ExpiryDate;

            txtViewOrder.Text = objXYZ70.ViewOrderString;

            //Print Authority
            hypPrint.Visible = true;
            if (hypPrint.Visible)
            {
                hypPrint.NavigateUrl = EditUrl("ItemID", itemId.ToString(), "ItemDetails", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container");
                hypPrint.Target = "_blank";
                hypPrint.ToolTip = Localization.GetString("Print", LocalResourceFile);
                hypPrint.Attributes.Add("onmouseover", "window.status=this.title; return true");
            }

            //Audit Control
            ViewState["CreatedDate"] = objXYZ70.CreatedDate;
            ViewState["CreatedByUserId"] = objXYZ70.CreatedByUserId;
            ctlAudit.CreatedByUser = objXYZ70.UpdatedByUser;
            ctlAudit.CreatedDate = objXYZ70.UpdatedDate.ToString();

            //Tracking Control
            ctlTracking.URL = objXYZ70.NavURL;
            ctlTracking.ModuleID = objXYZ70.ModuleId;
        }

        private XYZ70Info PageToItem()
        {
            XYZ70Info objXYZ70 = new XYZ70Info();
            //Initialise the ojbXYZ70 object
            objXYZ70 = (XYZ70Info)CBO.InitializeObject(objXYZ70, typeof(XYZ70Info));

            //bind text values to object
            objXYZ70.ItemId = itemId;
            objXYZ70.ModuleId = ModuleId;

            objXYZ70.Title = txtTitle.Text;
            try { objXYZ70.CategoryId = int.Parse(ddlCategoryId.SelectedValue); }
            catch { }
            objXYZ70.MediaSrc = ctlMediaSrc.Url;
            objXYZ70.MediaWidth = txtMediaWidth.Text;
            objXYZ70.MediaHeight = txtMediaHeight.Text;
            objXYZ70.MediaAlign = rblMediaAlign.SelectedValue;
            objXYZ70.Description = teDescription.Text;

            /*CreateEditPageToItemStub*/

            objXYZ70.Details = teDetails.Text;
            objXYZ70.MediaSrc2 = ctlMediaSrc2.Url;
            objXYZ70.MediaWidth2 = txtMediaWidth2.Text;
            objXYZ70.MediaHeight2 = txtMediaHeight2.Text;
            objXYZ70.MediaAlign2 = rblMediaAlign2.SelectedValue;

            objXYZ70.NavURL = ctlNavURL.Url;

            objXYZ70.PublishDate = ddpPublishDate.SelectedDate;
            objXYZ70.ExpiryDate = ddpExpiryDate.SelectedDate;

            objXYZ70.ViewOrderString = txtViewOrder.Text;


            if (itemId < 1)
            {
                objXYZ70.CreatedDate = DateTime.Now;
                objXYZ70.CreatedByUserId = UserInfo.UserID;
            }
            //Audit Control
            objXYZ70.UpdatedDate = DateTime.Now;
            objXYZ70.UpdatedByUserId = UserInfo.UserID;
            if (itemId > 0)
            {
                objXYZ70.CreatedDate = Convert.ToDateTime(ViewState["CreatedDate"]);
                objXYZ70.CreatedByUserId = Convert.ToInt32(ViewState["CreatedByUserId"]);
            }
            else
            {
                objXYZ70.CreatedDate = objXYZ70.UpdatedDate;
                objXYZ70.CreatedByUserId = objXYZ70.UpdatedByUserId;
            }
            return objXYZ70;
        }

        private void AddUpdateItem()
        {
            try
            {
                // Only Update if the Entered Data is Valid
                if (Page.IsValid)
                {
                    //Add/Update to database checking the Null.IsNull(objXYZ70.ItemId)
                    itemId = (new XYZ70sController()).AddUpdateXYZ70(PageToItem());

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

        private void DeleteItem()
        {
            try
            {
                if (!Null.IsNull(itemId))
                {
                    XYZ70sController objXYZ70sController = new XYZ70sController();
                    objXYZ70sController.DeleteXYZ70(itemId);
                }

                // Redirect back to the portal home page
                Response.Redirect(Globals.NavigateURL(), true);
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        private void CancelItem()
        {
            try
            {
                //Redirect to the page as selected by the User in DropdownList
                Response.Redirect(RedirectUrl(), true);
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
            objUrls.UpdateUrl(PortalId, ctlMediaSrc.Url, ctlMediaSrc.UrlType, ctlMediaSrc.Log, ctlMediaSrc.Track, ModuleId, ctlMediaSrc.NewWindow);

            //ctlMediaSrc
            objUrls.UpdateUrl(PortalId, ctlMediaSrc2.Url, ctlMediaSrc2.UrlType, ctlMediaSrc2.Log, ctlMediaSrc2.Track, ModuleId, ctlMediaSrc2.NewWindow);

            //ctlMediaSrc2
            objUrls.UpdateUrl(PortalId, ctlNavURL.Url, ctlNavURL.UrlType, ctlNavURL.Log, ctlNavURL.Track, ModuleId, ctlNavURL.NewWindow);

            //ctlNavURL
        }
        //UpdateUrls()

        private string RedirectUrl()
        {
            //Redirect to the page as selected by the User in DropdownList
            switch (ddlUpdateRedirection.SelectedValue.ToUpper())
            {
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
                        //return EditUrl("ItemId", itemId.ToString(), "ItemDetails");
                        return EditUrl("ItemId", itemId.ToString(), "Reports", "ReportType=ItemDetails", "dnnprintmode=true");
                    }

                //break;
                default:
                    //"LISTING"
                    //Redirect back to the portal home page
                    return Globals.NavigateURL();
            }
        }//RedirectUrl()

        private void BindCategories()
        {
            ddlCategoryId.DataValueField = "ItemId";
            ddlCategoryId.DataTextField = "Category";
            ddlCategoryId.DataSource = (new CategoriesController()).GetSearchedCategories();
            ddlCategoryId.DataBind();

        }
        /*CreateBindControlMethodStub*/
        private void ShowCategories()
        {
            ShowCategories(false);
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
            if (AJAX.IsInstalled())
            {
                //AJAX.RegisterScriptManager();

                AJAX.WrapUpdatePanelControl(ctlMediaSrc, true);
                //AJAX.RegisterPostBackControl(ctlMediaSrc)

                AJAX.WrapUpdatePanelControl(ctlMediaSrc2, true);
                //AJAX.RegisterPostBackControl(ctlMediaSrc2)

                AJAX.WrapUpdatePanelControl(ctlNavURL, true);
                //AJAX.RegisterPostBackControl(ctlNavURL)

                AJAX.WrapUpdatePanelControl(phtCategories, true);
                //'AJAX.RegisterPostBackControl(ctlNavURL)

            }
        }

        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                OptionsInfo objOI = new OptionsInfo(ModuleId);
                //Determine whether only Host/SuperUser should have access to this Control
                if (objOI.OnlyHostCanEdit && (!DotNetNuke.Entities.Users.UserController.GetCurrentUserInfo().IsSuperUser))
                {
                    //Redirect the User to Default Module Control
                    Response.Redirect(Globals.NavigateURL(), true);
                }
                // Determine ItemId
                itemId = string.IsNullOrEmpty(Request.Params["ItemId"])
                    ? Null.NullInteger
                    : Convert.ToInt32(Request.Params["ItemId"]);

                InitEveryTime();

                if (!Page.IsPostBack)
                {
                    InitFirstTime();

                    if (!Null.IsNull(itemId))
                    {
                        XYZ70Info objXYZ70 = (new XYZ70sController()).GetXYZ70(itemId);

                        if ((objXYZ70 != null))
                        {
                            //Load data
                            ItemToPage(objXYZ70);
                        }
                        else
                        {
                            // security violation attempt to access item not related to this Module
                            Response.Redirect(Globals.NavigateURL(), true);
                        }

                    }
                }
            }
            catch (Exception exc)
            {
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

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            AddUpdateItem();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            CancelItem();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteItem();
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
            imbShowCategories.Click += imbShowCategories_Click;
            imbHideCategories.Click += imbHideCategories_Click;
            cmdAdd.Click += cmdUpdate_Click;
            cmdUpdate.Click += cmdUpdate_Click;
            cmdCancel.Click += cmdCancel_Click;
            cmdDelete.Click += cmdDelete_Click;
        }

        #endregion

    } //EditItem

} //bhattji.Modules.XYZ70s
