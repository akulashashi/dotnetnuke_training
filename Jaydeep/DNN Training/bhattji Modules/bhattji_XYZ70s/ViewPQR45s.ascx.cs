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
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Drawing;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Localization;
using DotNetNuke.Services.Exceptions;
//using bhattji.Modules.XYZ70s.Business;
using DotNetNuke.Entities.Modules;

namespace bhattji.Modules.XYZ70s
{

    public abstract partial class ViewPQR45s : XYZ70ModuleBase
	{

		#region " Private Members "
		private int itemId;
		OptionsInfo objOI;
		#endregion

		#region " Public Members "
		//Public itemId As Integer
		public int XYZ70Id;
		public bool Embeded;
		#endregion

		#region " Public Methods "

		private void InitEveryTime()
		{
			//Bind the ObjectDataSource everytime, even on Postback
			SetODS();
		}

		private void InitFirstTime()
		{
			SetIconBar();

			ShowHide();
			SetGridView();
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

			cmdDelete.Attributes.Add("onClick", "javascript:return confirm('" + Localization.GetString("DeleteItem") + "');");
            //imbDelete.Attributes.Add("onClick", "javascript:return confirm('" + Localization.GetString("DeleteItem") + "');");

			//hypClose.Visible = Not Embeded
			//hypImgClose.Visible = hypClose.Visible
			divClose.Visible = !Embeded;

			if (divClose.Visible)
			{
                if (string.IsNullOrEmpty(Request.Params["ItemId"]))
                    hypClose.NavigateUrl = Globals.NavigateURL();
				else
                    hypClose.NavigateUrl = EditUrl("ItemId", Request.Params["ItemId"]);

				hypClose.ToolTip = Localization.GetString("Close");
				//hypClose.Text

				hypImgClose.ImageUrl = ControlPath + "img/bhattji_Close.png";
				hypImgClose.ToolTip = hypClose.ToolTip;
				hypImgClose.NavigateUrl = hypClose.NavigateUrl;
			}
		}
		//SetIconBar()

        private void DeleteItem()
        {
            try
            {
                try
                {
                    itemId = int.Parse(lblItemId.Text);
                }
                catch
                {
                }
                if (!Null.IsNull(itemId))
                {
                    PQR45sController objPQR45sController = new PQR45sController();
                    objPQR45sController.DeletePQR45(itemId);
                }

                // Redirect back to the portal home page
                ResetViewStates();
                ShowHide();
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
                ShowHide();
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

		private void ItemToPage(int ItemId)
		{
			if (!Null.IsNull(ItemId))
			{
				//Check for the Not-Null ItemId
				PQR45Info objPQR45 = (new PQR45sController()).GetPQR45(ItemId);
				//Check for the Not-Null objPQR45
				if ((objPQR45 != null)) ItemToPage(objPQR45); 
			}
		}

		private void ItemToPage(PQR45Info objPQR45)
		{
			//Load objPQR45 data to the Page
			{
				lblItemId.Text = objPQR45.ItemId.ToString();
				txtPQR45.Text = objPQR45.PQR45;

				if (!Null.IsNull(objPQR45.ViewOrder))
				{
					txtViewOrder.Text = objPQR45.ViewOrder.ToString();
				}
			}


			//objPQR45

		}

		private PQR45Info PageToItem()
		{
			PQR45Info objPQR45 = new PQR45Info();
			//Initialise the ojbPQR45 object
			objPQR45 = (PQR45Info)CBO.InitializeObject(objPQR45, typeof(PQR45Info));

			//bind text values to object
			{
				objPQR45.ItemId = Null.NullInteger;
				if (lblItemId.Text != "")
				{
					try {
						objPQR45.ItemId = int.Parse(lblItemId.Text);
					}
					catch {
					}
				}
				//.parentId = parentId
				objPQR45.XYZ70Id = XYZ70Id;

				objPQR45.PQR45 = txtPQR45.Text;

				if (txtViewOrder.Text != "")
				{
					try {
						objPQR45.ViewOrder = int.Parse(txtViewOrder.Text);
					}
					catch {
					}
				}
			}

			//objPQR45
			return objPQR45;
		}


        private void AddUpdatePQR45Item()
        {
            try
            {
                // Only Update if the Entered Data is Valid
                if (Page.IsValid)
                {
                    //Add/Update to database checking the Null.IsNull(objPQR45.ItemId)
                    itemId = (new PQR45sController()).AddUpdatePQR45(PageToItem());

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
				odsPQR45s.DataObjectTypeName = "bhattji.Modules.XYZ70s.PQR45Info";
				odsPQR45s.TypeName = "bhattji.Modules.XYZ70s.PQR45sController";
				odsPQR45s.SelectMethod = "GetPQR45s";
				//.InsertMethod = "AddPQR45"
				//.UpdateMethod = "UpdatePQR45"
				odsPQR45s.DeleteMethod = "DeletePQR45";
			}
			//odsPQR45s
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
				liDelete.Visible = (itemId > 0);
				liUpdate.Visible = (itemId > 0);
				//tdDelete.Visible
				liAdd.Visible = (itemId < 1);
				//Not tdUpdate.Visible
			}

			divAddPQR45.Visible = AddUpdateMode;
			divManagePQR45s.Visible = !AddUpdateMode;
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
				txtPQR45.Text = string.Empty;
				txtViewOrder.Text = (10 * gdvPQR45s.Rows.Count + 10).ToString();
			}
		}

		public void SetGridView()
		{
				gdvPQR45s.Columns[0].Visible = IsEditable;
				//Remove the First column if the User is not Admin

                if (!string.IsNullOrEmpty(objOI.GridCss)) gdvPQR45s.CssClass = objOI.GridCss;
                if (!string.IsNullOrEmpty(objOI.HeaderCss)) gdvPQR45s.HeaderStyle.CssClass = objOI.HeaderCss;
                if (!string.IsNullOrEmpty(objOI.RowCss)) gdvPQR45s.RowStyle.CssClass = objOI.RowCss;
                if (!string.IsNullOrEmpty(objOI.AltRowCss)) gdvPQR45s.AlternatingRowStyle.CssClass = objOI.AltRowCss;
                if (!string.IsNullOrEmpty(objOI.SelRowCss)) gdvPQR45s.SelectedRowStyle.CssClass = objOI.RowCss;
                if (!string.IsNullOrEmpty(objOI.EditRowCss)) gdvPQR45s.EditRowStyle.CssClass = objOI.EditRowCss;
                if (!string.IsNullOrEmpty(objOI.PagerCss)) gdvPQR45s.PagerStyle.CssClass = objOI.PagerCss;
                if (!string.IsNullOrEmpty(objOI.FooterCss)) gdvPQR45s.FooterStyle.CssClass = objOI.FooterCss;
                //if (objOI.BackColor != string.Empty)
                //{
                //    try {
                //        gdvPQR45s.RowStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.BackColor);
                //    }
                //    catch {
                //    }
                //}
                //if (objOI.AltColor != string.Empty)
                //{
                //    try {
                //        gdvPQR45s.AlternatingRowStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.AltColor);
                //    }
                //    catch {
                //    }
                //}

                //if (objOI.HeaderBackColor != string.Empty)
                //{
                //    try {
                //        gdvPQR45s.HeaderStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.HeaderBackColor);
                //        gdvPQR45s.FooterStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.HeaderBackColor);
                //    }
                //    catch {
                //    }
                //}
                //if (objOI.PagerBackColor != string.Empty)
                //{
                //    try {
                //        gdvPQR45s.PagerStyle.BackColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(objOI.PagerBackColor);
                //    }
                //    catch {
                //    }
                //}
			

		}

		public void ResetViewStates()
		{
			ViewState.Remove("odsPQR45s");
			ViewState.Remove("gdvPQR45s");
			odsPQR45s.DataBind();
			gdvPQR45s.DataBind();
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
        private void gdvPQR45s_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //e.Row.Attributes.Add("onMouseOver", "this.className='MouseOverClass'");
                    //if (e.Row.RowState == DataControlRowState.Normal)
                    //    e.Row.Attributes.Add("onMouseOut", "this.className='ItemCssClass'");
                    //else
                    //    e.Row.Attributes.Add("onMouseOut", "this.className='AltItemCssClass'");

                    // when mouse is over the row, save original color to new attribute, and change it to highlight yellow color
                    e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='" + (new OptionsInfo(ModuleId)).HighLightColor + "'");
                    // when mouse leaves the row, change the bg color to its original value    
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
                }
            }
            catch (Exception exc)
            {
                //Module failed to RowCreated
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

		private void gdvPQR45s_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "Add")
			{
				itemId = Null.NullInteger;
				InitAddPanel();
				ShowHide(true);
			}
		}

		private void gdvPQR45s_RowEditing(object sender, GridViewEditEventArgs e)
		{
			itemId = (int)gdvPQR45s.DataKeys[e.NewEditIndex].Value;
			InitAddPanel();
			ShowHide(true);
		}

		private void gdvPQR45s_RowDataBound(object sender, GridViewRowEventArgs e)
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

		//ods odsPQR45s Methods
		private void odsPQR45s_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
		{
			e.InputParameters["XYZ70Id"] = XYZ70Id.ToString();
		}

		//Add/Edit Methods
		private void cmdUpdate_Click(object sender, EventArgs e)
		{
            AddUpdatePQR45Item();
		}

		private void cmdDelete_Click(object sender, EventArgs e)
		{
            DeleteItem();
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
        //    gdvPQR45s.RowCommand += new GridViewCommandEventHandler(gdvPQR45s_RowCommand);
        //    gdvPQR45s.RowEditing += new GridViewEditEventHandler(gdvPQR45s_RowEditing);
        //    gdvPQR45s.RowDataBound += new GridViewRowEventHandler(gdvPQR45s_RowDataBound);
        //    odsPQR45s.Selecting += new ObjectDataSourceSelectingEventHandler(odsPQR45s_Selecting);
        //    imbAdd.Click += new ImageClickEventHandler(imbUpdate_Click);
        //    cmdAdd.Click += new EventHandler(cmdUpdate_Click);
        //    imbUpdate.Click += new ImageClickEventHandler(imbUpdate_Click);
        //    cmdUpdate.Click += new EventHandler(cmdUpdate_Click);
        //    imbCancel.Click += new ImageClickEventHandler(imbCancel_Click);
        //    cmdCancel.Click += new EventHandler(cmdCancel_Click);
        //    imbDelete.Click += new ImageClickEventHandler(imbDelete_Click);
        //    cmdDelete.Click += new EventHandler(cmdDelete_Click);
            //    //this.Load += new EventHandler(this.Page_Load);
            gdvPQR45s.RowCreated += gdvPQR45s_RowCreated;
            gdvPQR45s.RowCommand += gdvPQR45s_RowCommand;
            gdvPQR45s.RowEditing += gdvPQR45s_RowEditing;
            gdvPQR45s.RowDataBound += gdvPQR45s_RowDataBound;
            odsPQR45s.Selecting +=odsPQR45s_Selecting;
            //imbAdd.Click += imbUpdate_Click;
            cmdAdd.Click += cmdUpdate_Click;
            //imbUpdate.Click += imbUpdate_Click;
            cmdUpdate.Click += cmdUpdate_Click;
            //imbCancel.Click += imbCancel_Click;
            cmdCancel.Click += cmdCancel_Click;
            //imbDelete.Click += imbDelete_Click;
            cmdDelete.Click += cmdDelete_Click;
            //this.Load += Page_Load;
        }

        #endregion

	} //ViewPQR45s

} //bhattji.Modules.XYZ70s
