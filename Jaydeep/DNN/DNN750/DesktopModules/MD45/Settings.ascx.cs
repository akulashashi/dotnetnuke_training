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
using DotNetNuke;
using DotNetNuke.Common;
using DotNetNuke.Services.Localization;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Users;

namespace bhattji.Modules.XYZ70s
{
    public abstract partial class Settings : XYZ70SettingsBase
	{

		#region " Methods "

		private void SetIconBar()
		{
            //Give the Tooltip
			cmdUpdate.ToolTip = Localization.GetString("cmdUpdate");//cmdUpdate.Text
			cmdCancel.ToolTip = Localization.GetString("cmdCancel");//cmdCancel.Text
		}//SetIconBar()

		private void OptionsToPage(int ModId)
		{
			if (ModId > 0) OptionsToPage(new OptionsInfo(ModId)); 
		}

		private void OptionsToPage(OptionsInfo objOI)
		{
				//Main Options
				try {rblItemsScope.SelectedIndex = objOI.ItemsScope;}catch {rblItemsScope.SelectedIndex = 0;}
				try {rblCategoriesScope.SelectedIndex = objOI.CategoriesScope;}catch {rblCategoriesScope.SelectedIndex = 2;}
				chkOnlyHostCanEdit.Checked = objOI.OnlyHostCanEdit;
                try { rblViewControl.SelectedValue = objOI.ViewControl; }catch { rblViewControl.SelectedIndex = 0; }
                chkHideSearch.Checked = objOI.HideSearch;

                /*CreateSettingsItemToPageStub*/

                txtPagerSize.Text = objOI.PagerSize.ToString();
                txtPQR45PagerSize.Text = objOI.PQR45PagerSize.ToString();
				txtNoOfPages.Text = objOI.NoOfPages.ToString();
				chkDeleteFromGrid.Checked = objOI.DeleteFromGrid;

				try {ddlUpdateRedirection.SelectedValue=objOI.UpdateRedirection;}catch {}
				chkAddDescription.Checked = objOI.AddDescription;
				try {rblTabCss.SelectedValue=objOI.TabCss;}catch {rblTabCss.SelectedIndex = 0;}
				try {ddlTransition.SelectedValue=objOI.Transition;}catch {ddlTransition.Items.FindByValue("Pixelate").Selected = true;}
				chkRattleImage.Checked = objOI.RattleImage;
				try {ddlAddDate.SelectedValue=objOI.AddDate;}catch {}
                try { ddlImagePosition.SelectedValue = objOI.ImagePosition;}catch {ddlImagePosition.SelectedIndex = 1;}
				chkDynamicThumb.Checked = objOI.DynamicThumb;
				chkShowRatings.Checked = objOI.ShowRatings;
				txtThumbWidth.Text = objOI.ThumbWidth;
				txtThumbHeight.Text = objOI.ThumbHeight;
                txtHighLightColor.Text = objOI.HighLightColor;
                txtGridCss.Text=objOI.GridCss;
                txtHeaderCss.Text =objOI.HeaderCss;
                txtRowCss.Text=objOI.RowCss;
                txtAltRowCss.Text=objOI.AltRowCss;
                txtSelRowCss.Text=objOI.SelRowCss;
                txtEditRowCss.Text=objOI.EditRowCss;
                txtPagerCss.Text=objOI.PagerCss;
                txtFooterCss.Text=objOI.FooterCss;
				txtThumbColumns.Text = objOI.ThumbColumns.ToString();
                txtThumbRows.Text = objOI.ThumbRows.ToString();
				chkHideTextLink.Checked = objOI.HideTextLink;

				//Scroller Options
				try {rblScrollBehavior.SelectedValue=objOI.ScrollBehavior;}catch {rblScrollBehavior.SelectedIndex = 0;}
				try {rblScrollDirection.SelectedValue=objOI.ScrollDirection;}catch {rblScrollDirection.SelectedIndex = 0;}
				txtScrollAmount.Text = objOI.ScrollAmount;
				txtScrollDelay.Text = objOI.ScrollDelay;
				txtScrollWidth.Text = objOI.ScrollWidth;
				txtScrollHeight.Text = objOI.ScrollHeight;

				//Audit Control
				try 
                {
					ctlAudit.CreatedByUser = objOI.UpdatedByUser;
                    ctlAudit.CreatedDate = objOI.UpdatedDate.ToString();
                    //UserInfo objHostUser = UserController.GetUser(PortalId, UserId, true);
                    UserInfo objHostUser = UserController.GetUserById(PortalId, UserId);
					rblItemsScope.Enabled = objHostUser.IsSuperUser;
					rblCategoriesScope.Enabled = objHostUser.IsSuperUser;
					chkOnlyHostCanEdit.Enabled = objHostUser.IsSuperUser;
					if (objOI.OnlyHostCanEdit)
					{
						//txtPayPalBusinessID.Enabled = objHostUser.IsSuperUser
					}
				}catch {ctlAudit.Visible = false;}
		}

		private void PageToOptions(int ModId)
		{
			OptionsInfo objOI = new OptionsInfo();
				//Main Options
				objOI.ItemsScope = rblItemsScope.SelectedIndex;
				objOI.CategoriesScope = rblCategoriesScope.SelectedIndex;
				objOI.OnlyHostCanEdit = chkOnlyHostCanEdit.Checked;
				objOI.ViewControl = rblViewControl.SelectedValue;
				objOI.HideSearch = chkHideSearch.Checked;

                /*CreateSettingsPageToItemStub*/

				try {objOI.PagerSize = int.Parse(txtPagerSize.Text);}catch {}
                try{objOI.PQR45PagerSize = int.Parse(txtPQR45PagerSize.Text);}catch{}
				try {objOI.NoOfPages = int.Parse(txtNoOfPages.Text);}catch {}
				objOI.DeleteFromGrid = chkDeleteFromGrid.Checked;
				objOI.UpdateRedirection = ddlUpdateRedirection.SelectedValue;

				//Option1 Options
				objOI.AddDescription = chkAddDescription.Checked;
				objOI.TabCss = rblTabCss.SelectedValue;
				objOI.Transition = ddlTransition.SelectedValue;
				objOI.RattleImage = chkRattleImage.Checked;
				objOI.AddDate = ddlAddDate.SelectedValue;
				objOI.ImagePosition = ddlImagePosition.SelectedValue;
				objOI.DynamicThumb = chkDynamicThumb.Checked;
				objOI.ShowRatings = chkShowRatings.Checked;
				objOI.ThumbWidth = txtThumbWidth.Text;
				objOI.ThumbHeight = txtThumbHeight.Text;
                objOI.HighLightColor = txtHighLightColor.Text;
                objOI.GridCss = txtGridCss.Text;
                objOI.HeaderCss = txtHeaderCss.Text;
                objOI.RowCss = txtRowCss.Text;
                objOI.AltRowCss = txtAltRowCss.Text;
                objOI.SelRowCss = txtSelRowCss.Text;
                objOI.EditRowCss = txtEditRowCss.Text;
                objOI.PagerCss = txtPagerCss.Text;
                objOI.FooterCss = txtFooterCss.Text;

				try {objOI.ThumbColumns = int.Parse(txtThumbColumns.Text);}catch {}
                try{objOI.ThumbRows = int.Parse(txtThumbRows.Text);}catch{}

				objOI.HideTextLink = chkHideTextLink.Checked;

				//Scroller Options
				objOI.ScrollBehavior = rblScrollBehavior.SelectedValue;
				objOI.ScrollDirection = rblScrollDirection.SelectedValue;
				objOI.ScrollAmount = txtScrollAmount.Text;
				objOI.ScrollDelay = txtScrollDelay.Text;
				objOI.ScrollWidth = txtScrollWidth.Text;
				objOI.ScrollHeight = txtScrollHeight.Text;

				//Audit Control
				objOI.UpdatedByUserId = UserInfo.UserID;
				objOI.UpdatedByUser = UserInfo.DisplayName;
				objOI.UpdatedDate = DateTime.Now;

				//Save Options Info Object
				objOI.Update(ModId);
		}

        private void AddUpdateSettingsItem()
        {
            try
            {
                //If Page.IsValid Then
                UpdateOptions(Convert.ToInt32(Request.QueryString["SettingsModuleId"]));
                // Redirect back to the portal home page
                Response.Redirect(Globals.NavigateURL(), true);
            }
            //End If
            catch (Exception exc)
            {
                //Module failed to load
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

		#endregion

		#region " Base Method Implementations "

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// LoadSettings loads the settings from the Databas and displays them
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		///		[bhattji]	10/20/2004	created
		/// </history>
		/// -----------------------------------------------------------------------------
		public override void LoadSettings()
		{
			LoadOptions(ModuleId);
		}

		public void LoadOptions(int ModId)
		{
			try {if (!Page.IsPostBack) OptionsToPage(ModId); }
			catch (Exception exc) 
            {
				//Module failed to load
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// UpdateSettings saves the modified settings to the Database
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		///		[bhattji]	10/20/2004	created
		///		[bhattji]	10/25/2004	upated to use TabModuleId rather than TabId/ModuleId
		/// </history>
		/// -----------------------------------------------------------------------------
		public override void UpdateSettings()
		{
			UpdateOptions(ModuleId);
		}

		public void UpdateOptions(int ModId)
		{
			try {if (Page.IsValid) PageToOptions(ModId);}
			catch (Exception exc) 
            {
				//Module failed to load
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		#endregion

		#region " Event Methods "
		private void Page_Load(object sender, EventArgs e)
		{
			try {

				if (!IsPostBack)
				{

                    //Make the Host Options visible only to the Host/SuperUser
                    divHost.Visible = UserController.GetCurrentUserInfo().IsSuperUser;
                    //Make the Buttons visible if called directy (not in the Settings Page)
                    ulButtons.Visible = !string.IsNullOrEmpty(Request.QueryString["SettingsModuleId"]);
                    divPanelScript.Visible = ulButtons.Visible;
                    if (ulButtons.Visible)
					{
						LoadOptions(Convert.ToInt32(Request.QueryString["SettingsModuleId"]));
						SetIconBar();
					}
				}
			}
			catch (Exception exc) {
				//SettingsModule failed to load
				Exceptions.ProcessModuleLoadException(this, exc);
			}
		}

		private void cmdSetViewOrder_Click(object sender, EventArgs e)
		{
			XYZ70sController objXYZ70Controller = new XYZ70sController();
			objXYZ70Controller.SetViewOrderXYZ70s(ModuleId);
		}

		private void cmdClaimOrphan_Click(object sender, EventArgs e)
		{
			XYZ70sController objXYZ70Controller = new XYZ70sController();
			objXYZ70Controller.ClaimOrphanXYZ70s(ModuleId);
		}

		private void cmdSetViewOrderCat_Click(object sender, EventArgs e)
		{
			CategoriesController objCategoriesController = new CategoriesController();
			objCategoriesController.SetViewOrderCategories(ModuleId);
		}

		private void cmdClaimOrphanCat_Click(object sender, EventArgs e)
		{
			CategoriesController objCategoriesController = new CategoriesController();
			objCategoriesController.ClaimOrphanCategories(ModuleId);
		}

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// cmdUpdate_Click runs when the update button is clicked
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[bhattji]	9/23/2004	Updated to reflect design changes for Help, 508 support
		///                       and localisation
		/// </history>
		/// -----------------------------------------------------------------------------
		/// 
		private void imbUpdate_Click(object sender, ImageClickEventArgs e)
		{
            cmdUpdate_Click(null, null);
		}
		private void cmdUpdate_Click(object sender, EventArgs e)
		{
            AddUpdateSettingsItem();
		}

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// cmdCancel_Click runs when the cancel button is clicked
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <history>
		/// 	[bhattji]	9/23/2004	Updated to reflect design changes for Help, 508 support
		///                       and localisation
		/// </history>
		/// -----------------------------------------------------------------------------
		private void imbCancel_Click(object sender, ImageClickEventArgs e)
		{
            cmdCancel_Click(null, null);
		}
		private void cmdCancel_Click(object sender, EventArgs e)
		{
			try {Response.Redirect(Globals.NavigateURL(), true);}
			catch (Exception exc)
            {
				//Module failed to load
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
            cmdSetViewOrder.Click += cmdSetViewOrder_Click;
            cmdClaimOrphan.Click += cmdClaimOrphan_Click;
            cmdSetViewOrderCat.Click += cmdSetViewOrderCat_Click;
            cmdClaimOrphanCat.Click += cmdClaimOrphanCat_Click;
            //imbUpdate.Click += imbUpdate_Click;
            cmdUpdate.Click += cmdUpdate_Click;
            //imbCancel.Click += imbCancel_Click;
            cmdCancel.Click += cmdCancel_Click;
        }

        #endregion


	} //Settings

} //bhattji.Modules.XYZ70s
