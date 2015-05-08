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
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.ComponentModel;
using bhattji.Modules.SalesReps.Business;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Exceptions;
//Imports Microsoft.ScalableHosting.Security
//Imports AspNetSecurity = Microsoft.ScalableHosting.Security

namespace bhattji.Modules.SalesReps
{

    public abstract partial class ViewCategories : DotNetNuke.Entities.Modules.PortalModuleBase
	{

		#region " Private Members "
		OptionsInfo objOI;
		#endregion

		#region " Public Members "
		public int itemId;
		public bool Embeded;
		#endregion

		#region " Public Methods "

		//Public Sub LoadPage(ByVal PageIsPostBack As Boolean)
		//    objOI = New OptionsInfo(ModuleId)

		//    InitEveryTime()

		//    If Not PageIsPostBack Then
		//        InitFirstTime()
		//    End If
		//End Sub

		private void InitEveryTime()
		{
			//'this needs to execute always, even on Postback, to the client script code is registred in InvokePopupCal
			//hypCalandarFromDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtFrom)
			//hypCalandarToDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTo)

			//Bind the ObjectDataSource everytime, even on Postback
			SetODS();
		}

		private void InitFirstTime()
		{
			if ((Request.QueryString["Embeded"] != null))
			{
				Embeded = (Request.QueryString["Embeded"].ToLower() == "true") || (Request.QueryString["Embeded"].ToLower() == "yes");
			}
			SetIconBar();

			ShowHide();
			SetGridView();
		}

		private void SetIconBar()
		{
			//Give the ImageUrl
			imbAdd.ImageUrl = ModulePath + "img/bhattji_Add.png";
			imbUpdate.ImageUrl = ModulePath + "img/bhattji_Update.png";
			imbDelete.ImageUrl = ModulePath + "img/bhattji_Delete.png";
			imbCancel.ImageUrl = ModulePath + "img/bhattji_Cancel.png";

			//Give the Tooltip
			cmdAdd.ToolTip = Localization.GetString("Add");
			//cmdAdd.Text
			cmdUpdate.ToolTip = Localization.GetString("cmdUpdate");
			//cmdUpdate.Text
			cmdDelete.ToolTip = Localization.GetString("cmdDelete");
			//cmdDelete.Text
			cmdCancel.ToolTip = Localization.GetString("cmdCancel");
			//cmdCancel.Text

			cmdDelete.Attributes.Add("onClick", "javascript:return confirm('" + Localization.GetString("DeleteItem") + "');");
			imbDelete.Attributes.Add("onClick", "javascript:return confirm('" + Localization.GetString("DeleteItem") + "');");

			//hypClose.Visible = Not Embeded
			//hypImgClose.Visible = hypClose.Visible
			divClose.Visible = !Embeded;

			if (divClose.Visible)
			{
				if (((Request.Params["ItemId"] != null)) || (Request.Params["ItemId"] != ""))
				{
					hypClose.NavigateUrl = EditUrl("ItemId", Request.QueryString["ItemId"]);
				}
				else
				{
                    hypClose.NavigateUrl = Globals.NavigateURL();
				}
				hypClose.ToolTip = Localization.GetString("Close");
				//hypClose.Text

				hypImgClose.ImageUrl = ModulePath + "img/bhattji_Close.png";
				hypImgClose.ToolTip = hypClose.ToolTip;
				hypImgClose.NavigateUrl = hypClose.NavigateUrl;
			}
		}
		//SetIconBar()

		private void ItemToPage(int ItemId)
		{
			if (!Null.IsNull(ItemId))
			{
				//Check for the Not-Null ItemId
				CategoryInfo objCategory = (new CategoriesController()).GetCategory(ItemId);
				//Check for the Not-Null objCategory
				if ((objCategory != null)) ItemToPage(objCategory); 
			}
		}

		private void ItemToPage(CategoryInfo objCategory)
		{
			//Load objCategory data to the Page
			{
				lblItemId.Text = objCategory.ItemId.ToString();
				txtCategory.Text = objCategory.Category;

				if (!Null.IsNull(objCategory.ViewOrder))
				{
					txtViewOrder.Text = objCategory.ViewOrder.ToString();
				}
			}


			//objCategory

		}

		private CategoryInfo PageToItem()
		{
			CategoryInfo objCategory = new CategoryInfo();
			//Initialise the ojbCategory object
			objCategory = (CategoryInfo)CBO.InitializeObject(objCategory, typeof(Business.CategoryInfo));

			//bind text values to object
			{
				objCategory.ItemId = Null.NullInteger;
				if (lblItemId.Text != "")
				{
					try {
						objCategory.ItemId = int.Parse(lblItemId.Text);
					}
					catch {
					}
				}
				//.parentId = parentId
				objCategory.ModuleId = ModuleId;

				objCategory.Category = txtCategory.Text;

				if (txtViewOrder.Text != "")
				{
					try {
						objCategory.ViewOrder = int.Parse(txtViewOrder.Text);
					}
					catch {
					}
				}
			}

			//objCategory
			return objCategory;
		}

		//Private Sub UpdateUrls()
		//    ' url tracking
		//    Dim objUrls As New UrlController
		//    ' url tracking for MediaSrc
		//    With ctlMediaSrc
		//        objUrls.UpdateUrl(PortalId, .Url, .UrlType, .Log, .Track, ModuleId, .NewWindow)
		//    End With 'ctlMediaSrc
		//    With ctlMediaSrc2
		//        objUrls.UpdateUrl(PortalId, .Url, .UrlType, .Log, .Track, ModuleId, .NewWindow)
		//    End With 'ctlMediaSrc2
		//    With ctlNavURL
		//        objUrls.UpdateUrl(PortalId, .Url, .UrlType, .Log, .Track, ModuleId, .NewWindow)
		//    End With 'ctlNavURL
		//End Sub 'UpdateUrls()

        private void AddUpdateCategoryItem()
        {
            try
            {
                // Only Update if the Entered Data is Valid
                if (Page.IsValid)
                {
                    //Add/Update to database checking the Null.IsNull(objCategory.ItemId)
                    itemId = (new CategoriesController()).AddUpdateCategory(PageToItem());

                    //'Url tracking
                    //UpdateUrls()

                    //Redirect to the page as selected by the User in DropdownList
                    ResetViewStates();
                    ShowHide();
                }
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

		private void SetODS()
		{
			{
				odsCategories.DataObjectTypeName = "bhattji.Modules.SalesReps.Business.CategoryInfo";
				odsCategories.TypeName = "bhattji.Modules.SalesReps.Business.CategoriesController";
				odsCategories.SelectMethod = "GetCategories";
				//.InsertMethod = "AddCategory"
				//.UpdateMethod = "UpdateCategory"
				odsCategories.DeleteMethod = "DeleteCategory";
			}
			//odsCategories
		}
		//SetODS

        public void ShowHide()
        {
            ShowHide(false);
        }
        public void ShowHide(bool AddUpdateMode)
		{
			if (AddUpdateMode)
			{
				tdDelete.Visible = (itemId > 0);
				tdUpdate.Visible = (itemId > 0);
				//tdDelete.Visible
				tdAdd.Visible = (itemId < 1);
				//Not tdUpdate.Visible
			}

			trAddCategory.Visible = AddUpdateMode;
			trManageCategories.Visible = !AddUpdateMode;
			//lnkAddLoadPU.Visible = Not InsertMode

		}
		//ShowHide(Optional ByVal AddUpdateMode As Boolean = False)

		public void InitAddPanel()
		{
			if (itemId > 0)
			{
				ItemToPage(itemId);
			}
			else
			{
				lblItemId.Text = string.Empty;
				txtCategory.Text = string.Empty;
				txtViewOrder.Text = string.Empty;
			}
		}

		public void SetGridView()
		{
			{
				//.PageSize = objOI.PagerSize
				//.AllowPaging = objOI.PagerSize > 0
				gdvCategories.Columns[0].Visible = IsEditable;
				//Remove the First column if the User is not Admin

				if (objOI.BackColor != string.Empty)
				{
					try {
						gdvCategories.RowStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.BackColor);
					}
					catch {
					}
				}
				if (objOI.AltColor != string.Empty)
				{
					try {
						gdvCategories.AlternatingRowStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.AltColor);
					}
					catch {
					}
				}

				if (objOI.HeaderBackColor != string.Empty)
				{
					try {
						gdvCategories.HeaderStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.HeaderBackColor);
						gdvCategories.FooterStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.HeaderBackColor);
					}
					catch {
					}
				}
				if (objOI.PagerBackColor != string.Empty)
				{
					try {
						gdvCategories.PagerStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.PagerBackColor);
					}
					catch {
					}
				}
			}
			//gdvCategories

		}

		public void ResetViewStates()
		{
			ViewState.Remove("odsCategories");
			ViewState.Remove("gdvCategories");
			odsCategories.DataBind();
			gdvCategories.DataBind();
		}

		#endregion

		#region " Event Handlers "

		private void Page_Load(object sender, EventArgs e)
		{
			try {
				//LoadPage(Page.IsPostBack)
				objOI = new OptionsInfo(ModuleId);

				InitEveryTime();

				if (!Page.IsPostBack)
				{
					InitFirstTime();
				}
			}
			catch (Exception exc) {
				//Module failed to load
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		//GridView Methods
		private void gdvCategories_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "Add")
			{
				itemId = Null.NullInteger;
				InitAddPanel();
				ShowHide(true);
			}
		}

		private void gdvCategories_RowEditing(object sender, GridViewEditEventArgs e)
		{
			itemId = (int)gdvCategories.DataKeys[e.NewEditIndex].Value;
			InitAddPanel();
			ShowHide(true);
		}

		private void gdvCategories_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try {
				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					ImageButton imbDelete = (ImageButton)e.Row.FindControl("imbDelete");

					if ((imbDelete != null))
					{
						{
							imbDelete.Visible = IsEditable;
							if (imbDelete.Visible)
							{
								//.NavigateUrl = EditUrl("ItemID", CType(DataBinder.Eval(e.Row.DataItem, "ItemID"), String))
								imbDelete.ToolTip = "Delete";
								imbDelete.Attributes.Add("onmouseover", "window.status=this.title; return true");
								imbDelete.Attributes.Add("onClick", "javascript:return confirm('" + Localization.GetString("DeleteItem") + "');");
							}
						}
						//imbDelete
					}

				}
			}
			catch (Exception exc) {
				//Module failed to RowDataBound
				Exceptions.ProcessModuleLoadException(this, exc);
			}

		}

		//Add/Edit Methods
		private void imbUpdate_Click(object sender, ImageClickEventArgs e)
		{
			cmdUpdate_Click(sender, new EventArgs());
		}
		private void cmdUpdate_Click(object sender, EventArgs e)
		{
            AddUpdateCategoryItem();
		}

		private void imbDelete_Click(object sender, ImageClickEventArgs e)
		{
			cmdDelete_Click(sender, new EventArgs());
		}
		private void cmdDelete_Click(object sender, EventArgs e)
		{
			try {
				try {
					itemId = int.Parse(lblItemId.Text);
				}
				catch {
				}
				if (!Null.IsNull(itemId))
				{
					CategoriesController objCategoriesController = new CategoriesController();
					objCategoriesController.DeleteCategory(itemId);
				}

				// Redirect back to the portal home page
				ResetViewStates();
				ShowHide();
			}
			catch (Exception exc) {
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		private void imbCancel_Click(object sender, ImageClickEventArgs e)
		{
			cmdCancel_Click(sender, new EventArgs());
		}
		private void cmdCancel_Click(object sender, EventArgs e)
		{
			try {
				//Redirect to the page as selected by the User in DropdownList
				ShowHide();
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
            gdvCategories.RowCommand += new GridViewCommandEventHandler(gdvCategories_RowCommand);
            gdvCategories.RowEditing += new GridViewEditEventHandler(gdvCategories_RowEditing);
            gdvCategories.RowDataBound += new GridViewRowEventHandler(gdvCategories_RowDataBound);
            imbAdd.Click += new ImageClickEventHandler(imbUpdate_Click);
            cmdAdd.Click += new EventHandler(cmdUpdate_Click);
            imbUpdate.Click += new ImageClickEventHandler(imbUpdate_Click);
            cmdUpdate.Click += new EventHandler(cmdUpdate_Click);
            imbCancel.Click += new ImageClickEventHandler(imbCancel_Click);
            cmdCancel.Click += new EventHandler(cmdCancel_Click);
            imbDelete.Click += new ImageClickEventHandler(imbDelete_Click);
            cmdDelete.Click += new EventHandler(cmdDelete_Click);
            //this.Load += new EventHandler(this.Page_Load);

        }

        #endregion

	}
	//ViewCategories

}
//bhattji.Modules.SalesReps
