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
//using bhattji.Modules.VimeoVideos.Business;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework;
using DotNetNuke.Web.UI.WebControls;

#endregion

namespace bhattji.Modules.VimeoVideos
{

    public abstract partial class EditItem : VimeoVideoModuleBase
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
                    MyViewPQR45s.VimeoVideoId = itemId;
                    MyViewPQR45s.Embeded = true;
                } //MyViewPQR45s
                divPQR45s.Controls.Add(MyViewPQR45s);
            }
        }

        private void InitFirstTime()
        {
            //txtPublishDate.Attributes.Add("OnClick", (DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtPublishDate)));
            //txtExpiryDate.Attributes.Add("OnClick", (DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtExpiryDate)));
            hypPublishDate.NavigateUrl =DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtPublishDate);
            hypExpiryDate.NavigateUrl=DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtExpiryDate);
            
            //Register the JavaScripts
            HeadOfPage();
            BottomOfPage();
            //hypViewCategories.NavigateUrl = EditUrl("EditType", "EditCat", "Edit", "Embeded=True", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin");//&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")
            //hypViewCategories.CssClass = "submodal-400-200-__doPostBack('" + cmdCancel.ClientID + "','')";
            
            SetIconBar();

            //Make the PQR45Table Visible
            dfiPQR45s.Visible = tdDelete.Visible;

            //Make the AuditControl Visible
            ctlAudit.Visible = tdDelete.Visible;

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
            imbAdd.ImageUrl = ControlPath + "img/bhattji_Add.jpg";
            imbUpdate.ImageUrl = ControlPath + "img/bhattji_Update.jpg";
            imbDelete.ImageUrl = ControlPath + "img/bhattji_Delete.jpg";
            imbCancel.ImageUrl = ControlPath + "img/bhattji_Cancel.jpg";
            hypImgPrint.ImageUrl = ControlPath + "img/bhattji_Print.jpg";

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
        } //SetIconBar()

        private void ItemToPage(int ItemId)
        {
            if (!Null.IsNull(ItemId))
            {
                //Check for the Not-Null ItemId
                VimeoVideoInfo objVimeoVideo = (new VimeoVideosController()).GetVimeoVideo(ItemId);
                //Check for the Not-Null objVimeoVideo
                if ((objVimeoVideo != null)) ItemToPage(objVimeoVideo);
            }
        }

        private void ItemToPage(VimeoVideoInfo objVimeoVideo)
        {
            //Load objVimeoVideo data to the Page
            {
                if (!(new OptionsInfo(ModuleId)).IsItemEditable(objVimeoVideo.ModuleId))
                {
                    tdUpdate.Visible = false;
                    tdDelete.Visible = false;
                }
                txtTitle.Text = objVimeoVideo.Title;
                try
                {
                    ddlCategoryId.Items.FindByValue(objVimeoVideo.CategoryId.ToString()).Selected = true;
                }
                catch
                {
                    ddlCategoryId.SelectedIndex = 0;
                }
                ctlMediaSrc.Url = objVimeoVideo.MediaSrc;
                if (!string.IsNullOrEmpty(objVimeoVideo.MediaWidth))
                    txtMediaWidth.Text = objVimeoVideo.MediaWidth;
                if (!string.IsNullOrEmpty(objVimeoVideo.MediaHeight))
                    txtMediaHeight.Text = objVimeoVideo.MediaHeight;

                if (objVimeoVideo.MediaAlign.ToLower() == "left")
                {
                    rblMediaAlign.Items[0].Selected = true;
                }
                else
                {
                    rblMediaAlign.Items[1].Selected = true;
                }
                teDescription.Text = objVimeoVideo.Description;

                txtActualFields.Text = objVimeoVideo.ActualFields;

                teDetails.Text = objVimeoVideo.Details;
                ctlMediaSrc2.Url = objVimeoVideo.MediaSrc2;
                if (!string.IsNullOrEmpty(objVimeoVideo.MediaWidth2))
                    txtMediaWidth2.Text = objVimeoVideo.MediaWidth2;
                if (!string.IsNullOrEmpty(objVimeoVideo.MediaHeight2))
                    txtMediaHeight2.Text = objVimeoVideo.MediaHeight2;

                if (objVimeoVideo.MediaAlign2.ToLower() == "left")
                {
                    rblMediaAlign2.Items[0].Selected = true;
                }
                else
                {
                    rblMediaAlign2.Items[1].Selected = true;
                }

                ctlNavURL.Url = objVimeoVideo.NavURL;

                if (!Null.IsNull(objVimeoVideo.PublishDate))
                {
                    txtPublishDate.Text = objVimeoVideo.PublishDate.ToShortDateString();
                }
                if (!Null.IsNull(objVimeoVideo.ExpiryDate))
                {
                    txtExpiryDate.Text = objVimeoVideo.ExpiryDate.ToShortDateString();
                }
                if (!Null.IsNull(objVimeoVideo.ViewOrder))
                {
                    txtViewOrder.Text = objVimeoVideo.ViewOrder.ToString();
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
                }//hypPrint
                {
                    hypImgPrint.Visible = true;
                    if (hypImgPrint.Visible)
                    {
                        hypImgPrint.NavigateUrl = hypPrint.NavigateUrl;
                        hypImgPrint.Target = "_blank";
                        hypImgPrint.ToolTip = Localization.GetString("Print", LocalResourceFile);
                        hypImgPrint.Attributes.Add("onmouseover", "window.status=this.title; return true");
                    }
                } //hypImgPrint

                //Audit Control
                ctlAudit.CreatedByUser = objVimeoVideo.UpdatedByUser;
                ctlAudit.CreatedDate = objVimeoVideo.UpdatedDate.ToString();

                //Tracking Control
                ctlTracking.URL = objVimeoVideo.NavURL;
                ctlTracking.ModuleID = objVimeoVideo.ModuleId;
            } //objVimeoVideo

        }

        private VimeoVideoInfo PageToItem()
        {
            VimeoVideoInfo objVimeoVideo = new VimeoVideoInfo();
            //Initialise the ojbVimeoVideo object
            objVimeoVideo = (VimeoVideoInfo)CBO.InitializeObject(objVimeoVideo, typeof(VimeoVideoInfo));

            //bind text values to object
            {
                objVimeoVideo.ItemId = itemId;
                objVimeoVideo.ModuleId = ModuleId;

                objVimeoVideo.Title = txtTitle.Text;
                try
                {
                    objVimeoVideo.CategoryId = int.Parse(ddlCategoryId.SelectedValue);
                }
                catch
                {
                }
                objVimeoVideo.MediaSrc = ctlMediaSrc.Url;
                objVimeoVideo.MediaWidth = txtMediaWidth.Text;
                objVimeoVideo.MediaHeight = txtMediaHeight.Text;
                objVimeoVideo.MediaAlign = rblMediaAlign.SelectedValue;
                objVimeoVideo.Description = teDescription.Text;

                objVimeoVideo.ActualFields = txtActualFields.Text;

                objVimeoVideo.Details = teDetails.Text;
                objVimeoVideo.MediaSrc2 = ctlMediaSrc2.Url;
                objVimeoVideo.MediaWidth2 = txtMediaWidth2.Text;
                objVimeoVideo.MediaHeight2 = txtMediaHeight2.Text;
                objVimeoVideo.MediaAlign2 = rblMediaAlign2.SelectedValue;

                objVimeoVideo.NavURL = ctlNavURL.Url;

                if (!string.IsNullOrEmpty(txtPublishDate.Text))
                {
                    try
                    {
                        objVimeoVideo.PublishDate = DateTime.Parse(txtPublishDate.Text);
                    }
                    catch
                    {
                    }
                }
                if (!string.IsNullOrEmpty(txtExpiryDate.Text))
                {
                    try
                    {
                        objVimeoVideo.ExpiryDate = DateTime.Parse(txtExpiryDate.Text);
                    }
                    catch
                    {
                    }
                }

                if (!string.IsNullOrEmpty(txtViewOrder.Text))
                {
                    try
                    {
                        objVimeoVideo.ViewOrder = int.Parse(txtViewOrder.Text);
                    }
                    catch
                    {
                    }
                }

                //Audit Control
                objVimeoVideo.UpdatedByUserId = UserInfo.UserID;
                objVimeoVideo.CreatedByUserId = objVimeoVideo.UpdatedByUserId;
            } //objVimeoVideo
            return objVimeoVideo;
        }

        private void AddUpdateItem()
        {
            try
            {
                // Only Update if the Entered Data is Valid
                if (Page.IsValid)
                {

                    //Add/Update to database checking the Null.IsNull(objVimeoVideo.ItemId)
                    itemId = (new VimeoVideosController()).AddUpdateVimeoVideo(PageToItem());

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
                    VimeoVideosController objVimeoVideosController = new VimeoVideosController();
                    objVimeoVideosController.DeleteVimeoVideo(itemId);
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
                ddlCategoryId.DataSource = (new CategoriesController()).GetAllCategories();
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

                //AJAX.WrapUpdatePanelControl(phtCategories, True)
                //'AJAX.RegisterPostBackControl(ctlNavURL)

                //AJAX.WrapUpdatePanelControl(divPQR45s, True)
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
                        VimeoVideoInfo objVimeoVideo = (new VimeoVideosController()).GetVimeoVideo(itemId);

                        if ((objVimeoVideo != null))
                        {
                            //Load data
                            ItemToPage(objVimeoVideo);
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

        private void imbUpdate_Click(object sender, ImageClickEventArgs e)
        {
            cmdUpdate_Click(null, null);
        }
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            AddUpdateItem();
        }

        private void imbCancel_Click(object sender, ImageClickEventArgs e)
        {
            cmdCancel_Click(null, null);
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            CancelItem();
        }

        private void imbDelete_Click(object sender, ImageClickEventArgs e)
        {
            cmdDelete_Click(null, null);
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
            imbAdd.Click += imbUpdate_Click;
            cmdAdd.Click += cmdUpdate_Click;
            imbUpdate.Click += imbUpdate_Click;
            cmdUpdate.Click += cmdUpdate_Click;
            imbCancel.Click += imbCancel_Click;
            cmdCancel.Click += cmdCancel_Click;
            imbDelete.Click += imbDelete_Click;
            cmdDelete.Click += cmdDelete_Click;
        }

        #endregion

    } //EditItem

} //bhattji.Modules.VimeoVideos
