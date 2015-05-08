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
//using bhattji.Modules.XYZ60s.Business;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework;
using DotNetNuke.Web.UI.WebControls;

#endregion

namespace bhattji.Modules.XYZ60s
{
    public abstract partial class EditItem : XYZ60ModuleBase
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
            {
                MyViewCategories.ModuleConfiguration = ModuleConfiguration;
                MyViewCategories.ID = "ViewCategories";
                MyViewCategories.Embeded = true;
            }  //MyViewCategories
            phtCategories.Controls.Add(MyViewCategories);

            if (itemId > 0)
            {
                ViewPQR45s MyViewPQR45s = (ViewPQR45s)LoadControl(ControlPath + "ViewPQR45s.ascx");
                {
                    MyViewPQR45s.ModuleConfiguration = ModuleConfiguration;
                    MyViewPQR45s.ID = "ViewPQR45s";
                    MyViewPQR45s.XYZ60Id = itemId;
                    MyViewPQR45s.Embeded = true;
                } //MyViewPQR45s
                divPQR45s.Controls.Add(MyViewPQR45s);
            }
        }

        private void InitFirstTime()
        {
            //txtPublishDate.Attributes.Add("OnClick", (DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtPublishDate)));
            //txtExpiryDate.Attributes.Add("OnClick", (DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtExpiryDate)));
            //hypPublishDate.NavigateUrl =DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtPublishDate);
            //hypExpiryDate.NavigateUrl=DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtExpiryDate);
            
            //Register the JavaScripts
            HeadOfPage();
            BottomOfPage();
            //hypViewCategories.NavigateUrl = EditUrl("EditType", "EditCat", "Edit", "Embeded=True", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin");//&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
            //hypViewCategories.CssClass = "submodal-400-200-__doPostBack('" + cmdCancel.ClientID + "','')";
            
            SetIconBar();

            //Make the PQR45Table Visible
            dfiPQR45s.Visible = liDelete.Visible;

            //Make the AuditControl Visible
            ctlAudit.Visible = liDelete.Visible;

            ctlMediaSrc.ShowNone = true;
            ctlMediaSrc.ShowUrls = true;
            ctlMediaSrc.ShowFiles = true;
            ctlMediaSrc.ShowTabs = false;
            ctlMediaSrc.ShowLog = false;
            ctlMediaSrc.ShowNewWindow = false;
            ctlMediaSrc.ShowTrack = false;
            ctlMediaSrc.ShowUsers = false;

            ctlMediaSrc2.ShowNone = true;
            ctlMediaSrc2.ShowUrls = true;
            ctlMediaSrc2.ShowFiles = true;
            ctlMediaSrc2.ShowTabs = false;
            ctlMediaSrc2.ShowLog = false;
            ctlMediaSrc2.ShowNewWindow = false;
            ctlMediaSrc2.ShowTrack = false;
            ctlMediaSrc2.ShowUsers = false;

            ctlNavURL.ShowNone = true;
            ctlNavURL.ShowUrls = true;
            ctlNavURL.ShowFiles = true;
            ctlNavURL.ShowTabs = true;
            ctlNavURL.ShowLog = true;
            ctlNavURL.ShowNewWindow = true;
            ctlNavURL.ShowTrack = true;
            ctlNavURL.ShowUsers = false;

            //Bind the Categories
            BindCategories();

        }

        private void SetIconBar()
        {
            //Give the ImageUrl

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
                XYZ60Info objXYZ60 = (new XYZ60sController()).GetXYZ60(ItemId);
                //Check for the Not-Null objXYZ60
                if ((objXYZ60 != null)) ItemToPage(objXYZ60);
            }
        }

        private void ItemToPage(XYZ60Info objXYZ60)
        {
            //Load objXYZ60 data to the Page
            {
                if (!(new OptionsInfo(ModuleId)).IsItemEditable(objXYZ60.ModuleId))
                {
                    liUpdate.Visible = false;
                    liDelete.Visible = false;
                }
                txtTitle.Text = objXYZ60.Title;
                try
                {
                    ddlCategoryId.Items.FindByValue(objXYZ60.CategoryId.ToString()).Selected = true;
                }
                catch
                {
                    ddlCategoryId.SelectedIndex = 0;
                }
                ctlMediaSrc.Url = objXYZ60.MediaSrc;
                if (!string.IsNullOrEmpty(objXYZ60.MediaWidth))
                    txtMediaWidth.Text = objXYZ60.MediaWidth;
                if (!string.IsNullOrEmpty(objXYZ60.MediaHeight))
                    txtMediaHeight.Text = objXYZ60.MediaHeight;

                if (objXYZ60.MediaAlign.ToLower() == "left")
                {
                    rblMediaAlign.Items[0].Selected = true;
                }
                else
                {
                    rblMediaAlign.Items[1].Selected = true;
                }
                teDescription.Text = objXYZ60.Description;

                txtActualFields.Text = objXYZ60.ActualFields;

                teDetails.Text = objXYZ60.Details;
                ctlMediaSrc2.Url = objXYZ60.MediaSrc2;
                if (!string.IsNullOrEmpty(objXYZ60.MediaWidth2))
                    txtMediaWidth2.Text = objXYZ60.MediaWidth2;
                if (!string.IsNullOrEmpty(objXYZ60.MediaHeight2))
                    txtMediaHeight2.Text = objXYZ60.MediaHeight2;

                if (objXYZ60.MediaAlign2.ToLower() == "left")
                {
                    rblMediaAlign2.Items[0].Selected = true;
                }
                else
                {
                    rblMediaAlign2.Items[1].Selected = true;
                }

                ctlNavURL.Url = objXYZ60.NavURL;

                //if (!Null.IsNull(objXYZ60.PublishDate))
                //{
                //    txtPublishDate.Text = objXYZ60.PublishDate.ToShortDateString();
                //}
                //if (!Null.IsNull(objXYZ60.ExpiryDate))
                //{
                //    txtExpiryDate.Text = objXYZ60.ExpiryDate.ToShortDateString();
                //}
                //if (objXYZ60.PublishDate.HasValue && (objXYZ60.PublishDate > Convert.ToDateTime("1/1/1753")))
                //{
                //    txtPublishDate.Text = Convert.ToDateTime(objXYZ60.PublishDate).ToShortDateString();
                //}
                //if (objXYZ60.ExpiryDate.HasValue && (objXYZ60.ExpiryDate > Convert.ToDateTime("1/1/1753")))
                //{
                //    txtExpiryDate.Text = Convert.ToDateTime(objXYZ60.ExpiryDate).ToShortDateString();
                //}
                txtPublishDate.SelectedDate = objXYZ60.PublishDate;
                txtExpiryDate.SelectedDate = objXYZ60.ExpiryDate;
                //txtPublishDate.Text = objXYZ60.PublishDateString;
                //txtExpiryDate.Text = objXYZ60.ExpiryDateIgnore;

                txtViewOrder.Text = objXYZ60.ViewOrderString;
                

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
                }//hypPrint

                //Audit Control
                ViewState["CreatedDate"] = objXYZ60.CreatedDate;
                ViewState["CreatedByUserId"] = objXYZ60.CreatedByUserId;
                ctlAudit.CreatedByUser = objXYZ60.UpdatedByUser;
                ctlAudit.CreatedDate = objXYZ60.UpdatedDate.ToString();

                //Tracking Control
                ctlTracking.URL = objXYZ60.NavURL;
                ctlTracking.ModuleID = objXYZ60.ModuleId;
            } //objXYZ60

        }

        private XYZ60Info PageToItem()
        {
            XYZ60Info objXYZ60 = new XYZ60Info();
            //Initialise the ojbXYZ60 object
            objXYZ60 = (XYZ60Info)CBO.InitializeObject(objXYZ60, typeof(XYZ60Info));

            //bind text values to object
            {
                objXYZ60.ItemId = itemId;
                objXYZ60.ModuleId = ModuleId;

                objXYZ60.Title = txtTitle.Text;
                try
                {
                    objXYZ60.CategoryId = int.Parse(ddlCategoryId.SelectedValue);
                }
                catch
                {
                }
                objXYZ60.MediaSrc = ctlMediaSrc.Url;
                objXYZ60.MediaWidth = txtMediaWidth.Text;
                objXYZ60.MediaHeight = txtMediaHeight.Text;
                objXYZ60.MediaAlign = rblMediaAlign.SelectedValue;
                objXYZ60.Description = teDescription.Text;

                objXYZ60.ActualFields = txtActualFields.Text;

                objXYZ60.Details = teDetails.Text;
                objXYZ60.MediaSrc2 = ctlMediaSrc2.Url;
                objXYZ60.MediaWidth2 = txtMediaWidth2.Text;
                objXYZ60.MediaHeight2 = txtMediaHeight2.Text;
                objXYZ60.MediaAlign2 = rblMediaAlign2.SelectedValue;

                objXYZ60.NavURL = ctlNavURL.Url;

                //if (!string.IsNullOrEmpty(txtPublishDate.Text))
                //{
                //    try
                //    {
                //        objXYZ60.PublishDate = DateTime.Parse(txtPublishDate.Text);
                //    }
                //    catch
                //    {
                //    }
                //}
                //if (!string.IsNullOrEmpty(txtExpiryDate.Text))
                //{
                //    try
                //    {
                //        objXYZ60.ExpiryDate = DateTime.Parse(txtExpiryDate.Text);
                //    }
                //    catch
                //    {
                //    }
                //}
                objXYZ60.PublishDate = txtPublishDate.SelectedDate;
                objXYZ60.ExpiryDate = txtExpiryDate.SelectedDate;

                objXYZ60.ViewOrderString = txtViewOrder.Text;
                

                if (itemId < 1)                
                {
                    objXYZ60.CreatedDate = DateTime.Now;
                    objXYZ60.CreatedByUserId = UserInfo.UserID;
                }
                //Audit Control
                objXYZ60.UpdatedDate = DateTime.Now;
                objXYZ60.UpdatedByUserId = UserInfo.UserID;
                if (itemId > 0)
                {
                    objXYZ60.CreatedDate = Convert.ToDateTime(ViewState["CreatedDate"]);
                    objXYZ60.CreatedByUserId = Convert.ToInt32(ViewState["CreatedByUserId"]);
                }
                else
                {
                    objXYZ60.CreatedDate = objXYZ60.UpdatedDate;
                    objXYZ60.CreatedByUserId = objXYZ60.UpdatedByUserId;
                }
            } //objXYZ60
            return objXYZ60;
        }

        private void AddUpdateItem()
        {
            try
            {
                // Only Update if the Entered Data is Valid
                if (Page.IsValid)
                {

                    //Add/Update to database checking the Null.IsNull(objXYZ60.ItemId)
                    itemId = (new XYZ60sController()).AddUpdateXYZ60(PageToItem());

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
                    XYZ60sController objXYZ60sController = new XYZ60sController();
                    objXYZ60sController.DeleteXYZ60(itemId);
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
            {
                ddlCategoryId.DataValueField = "ItemId";
                ddlCategoryId.DataTextField = "Category";
                ddlCategoryId.DataSource = (new CategoriesController()).GetSearchedCategories();
                ddlCategoryId.DataBind();
            } //ddlCategoryId
        }
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

                AJAX.WrapUpdatePanelControl(divPQR45s, true);
                //'AJAX.RegisterPostBackControl(ctlNavURL)

            }
        }

        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                OptionsInfo objOI = new OptionsInfo(ModuleId);
                if (objOI.OnlyHostCanEdit && (!DotNetNuke.Entities.Users.UserController.GetCurrentUserInfo().IsSuperUser))
                {
                    //MsgBox("Sorry, Only Superusers can edit !!!", )
                    //Response.Write("<script>alert('Sorry, Only Superusers can edit !!!')</script>")
                    Response.Redirect(Globals.NavigateURL(), true);
                }
                // Determine ItemId
                if (string.IsNullOrEmpty(Request.Params["ItemId"]))                
                    itemId = Null.NullInteger;               
                else               
                    itemId = Int32.Parse(Request.Params["ItemId"]);

              

                InitEveryTime();

                if (!Page.IsPostBack)
                {
                    InitFirstTime();

                    if (!Null.IsNull(itemId))
                    {
                        XYZ60Info objXYZ60 = (new XYZ60sController()).GetXYZ60(itemId);

                        if ((objXYZ60 != null))
                        {
                            //Load data
                            ItemToPage(objXYZ60);
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
            ////this.Load += new EventHandler(this.Page_Init);
            ////this.Load += new System.EventHandler(this.Page_Load);
            //imbShowCategories.Click += new ImageClickEventHandler(imbShowCategories_Click);
            //imbHideCategories.Click += new ImageClickEventHandler(imbHideCategories_Click);
            //imbAdd.Click += new ImageClickEventHandler(imbUpdate_Click);
            //cmdAdd.Click += new EventHandler(cmdUpdate_Click);
            //imbUpdate.Click += new ImageClickEventHandler(imbUpdate_Click);
            //cmdUpdate.Click += new EventHandler(cmdUpdate_Click);
            //imbCancel.Click += new ImageClickEventHandler(imbCancel_Click);
            //cmdCancel.Click += new EventHandler(cmdCancel_Click);
            //imbDelete.Click += new ImageClickEventHandler(imbDelete_Click);
            //cmdDelete.Click += new EventHandler(cmdDelete_Click);

            //this.Load += Page_Init;
            //this.Load += Page_Load;
            imbShowCategories.Click += imbShowCategories_Click;
            imbHideCategories.Click += imbHideCategories_Click;
            //imbAdd.Click += imbUpdate_Click;
            cmdAdd.Click += cmdUpdate_Click;
            //imbUpdate.Click += imbUpdate_Click;
            cmdUpdate.Click += cmdUpdate_Click;
            //imbCancel.Click += imbCancel_Click;
            cmdCancel.Click += cmdCancel_Click;
            //imbDelete.Click += imbDelete_Click;
            cmdDelete.Click += cmdDelete_Click;
        }

        #endregion

    } //EditItem

} //bhattji.Modules.XYZ60s
