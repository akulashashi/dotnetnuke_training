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
//using bhattji.Modules.Trackings.Business;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Users;

namespace bhattji.Modules.Trackings
{

    public abstract partial class Settings : TrackingSettingsBase
	{

		#region " Methods "

		private void SetIconBar()
		{
			//Give the ImageUrl
            //imbUpdate.ImageUrl = ControlPath + "img/bhattji_Update.jpg";
            //imbCancel.ImageUrl = ControlPath + "img/bhattji_Cancel.jpg";

			//Give the Tooltip
			cmdUpdate.ToolTip = Localization.GetString("cmdUpdate");
			//cmdUpdate.Text
			cmdCancel.ToolTip = Localization.GetString("cmdCancel");
			//cmdCancel.Text
		}
		//SetIconBar()

		private void OptionsToPage(int ModId)
		{
			if (ModId > 0) OptionsToPage(new OptionsInfo(ModId)); 
		}

		private void OptionsToPage(OptionsInfo objOI)
		{
			{
				//Media Options
				try {rblPlayer.SelectedValue =objOI.Player;}
                catch { rblPlayer.SelectedIndex = 0; }
                ctlMediaSrc.Url = objOI.MediaSrc;
                txtSrcType.Text = objOI.SrcType;
                chkResponsive.Checked = objOI.Responsive;
                txtWidth.Text = objOI.Width;
                txtHeight.Text = objOI.Height;
                ctlMediaSrc2.Url = objOI.MediaSrc2;
                txtSrcType2.Text = objOI.SrcType2;
                ctlMediaSrc3.Url = objOI.MediaSrc3;
                txtSrcType3.Text = objOI.SrcType3;
                txtFallbackUrl.Text = objOI.FallbackUrl;

                txtDescription.Text = objOI.Description;
                //Image Options
                ctlPosterSrc.Url = objOI.PosterSrc;
                ctlNavURL.Url = objOI.NavURL;
                chkNewWindow.Checked = objOI.NewWindow;
                //chkRattleImage.Checked = objOI.RattleImage;

                //Media Options
                chkAutoPlay.Checked = objOI.AutoPlay;
                chkShowControls.Checked = objOI.ShowControls;
                chkLoop.Checked = objOI.Loop;
                chkMuted.Checked = objOI.Muted;

				//Audit Control
				ctlAudit.CreatedByUser = objOI.UpdatedByUser;
                ctlAudit.CreatedDate = objOI.UpdatedDate.ToString();

                ctlMediaSrc.ShowNone = false;
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

                ctlMediaSrc3.ShowNone = true;
                ctlMediaSrc3.ShowUrls = true;
                ctlMediaSrc3.ShowFiles = true;
                ctlMediaSrc3.ShowTabs = false;
                ctlMediaSrc3.ShowLog = false;
                ctlMediaSrc3.ShowNewWindow = false;
                ctlMediaSrc3.ShowTrack = false;
                ctlMediaSrc3.ShowUsers = false;

                ctlPosterSrc.ShowNone = true;
                ctlPosterSrc.ShowUrls = true;
                ctlPosterSrc.ShowFiles = true;
                ctlPosterSrc.ShowTabs = false;
                ctlPosterSrc.ShowLog = false;
                ctlPosterSrc.ShowNewWindow = false;
                ctlPosterSrc.ShowTrack = false;
                ctlPosterSrc.ShowUsers = false;

                ctlNavURL.ShowNone = true;
                ctlNavURL.ShowUrls = true;
                ctlNavURL.ShowFiles = false;
                ctlNavURL.ShowTabs = true;
                ctlNavURL.ShowLog = false;
                ctlNavURL.ShowNewWindow = false;
                ctlNavURL.ShowTrack = false;
                ctlNavURL.ShowUsers = false;
				
			}

		}

		private void PageToOptions(int ModId)
		{
			OptionsInfo objOI = new OptionsInfo();
			{
                //Media Options
                objOI.Player=rblPlayer.SelectedValue;
                objOI.MediaSrc=ctlMediaSrc.Url;
                objOI.SrcType = txtSrcType.Text;
                objOI.Responsive = chkResponsive.Checked;
                objOI.Width=txtWidth.Text;
                objOI.Height = txtHeight.Text;
                objOI.MediaSrc2 = ctlMediaSrc2.Url;
                objOI.SrcType2 = txtSrcType2.Text;
                objOI.MediaSrc3 = ctlMediaSrc3.Url;
                objOI.SrcType3 = txtSrcType3.Text;
                objOI.FallbackUrl = txtFallbackUrl.Text;

                objOI.Description=txtDescription.Text;

                //Image Options
                objOI.PosterSrc = ctlPosterSrc.Url;
                objOI.NavURL = ctlNavURL.Url;
                objOI.NewWindow = chkNewWindow.Checked;
                //objOI.RattleImage=chkRattleImage.Checked;

                //Media Options
                objOI.AutoPlay=chkAutoPlay.Checked;
                objOI.ShowControls=chkShowControls.Checked;
                objOI.Loop=chkLoop.Checked;
                objOI.Muted=chkMuted.Checked;

				//Audit Control
				objOI.UpdatedByUserId = UserInfo.UserID;
				objOI.UpdatedByUser = UserInfo.DisplayName;
				objOI.UpdatedDate = DateTime.Now;

				//.Save Options Info Object
				objOI.Update(ModId);
			}
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
			try {
				if (!Page.IsPostBack) OptionsToPage(ModId); 
			}
			catch (Exception exc) {
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
			try {
				if (Page.IsValid) PageToOptions(ModId); 
			}
			catch (Exception exc) {
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
                    ulButtons.Visible = !string.IsNullOrEmpty(Request.QueryString["SettingsModuleId"]);
                    divPanelScript.Visible = ulButtons.Visible;
					//Request.QueryString("SettingsModuleId") <> String.Empty
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
			EventArgs cmdE = new EventArgs();
			cmdUpdate_Click(sender, cmdE);
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
			EventArgs cmdE = new EventArgs();
			cmdCancel_Click(sender, cmdE);
		}
		private void cmdCancel_Click(object sender, EventArgs e)
		{
			try {
				Response.Redirect(Globals.NavigateURL(), true);
			}
			catch (Exception exc) {
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
            //cmdSetViewOrder.Click += new EventHandler(cmdSetViewOrder_Click);
            //cmdClaimOrphan.Click += new EventHandler(cmdClaimOrphan_Click);
            //cmdSetViewOrderCat.Click += new EventHandler(cmdSetViewOrderCat_Click);
            //cmdClaimOrphanCat.Click += new EventHandler(cmdClaimOrphanCat_Click);
            //imbUpdate.Click += new ImageClickEventHandler(imbUpdate_Click);
            //cmdUpdate.Click += new EventHandler(cmdUpdate_Click);
            //imbCancel.Click += new ImageClickEventHandler(imbCancel_Click);
            //cmdCancel.Click += new EventHandler(cmdCancel_Click);
            ////this.Load += new EventHandler(this.Page_Load);
            //imbUpdate.Click += imbUpdate_Click;
            cmdUpdate.Click += cmdUpdate_Click;
            //imbCancel.Click += imbCancel_Click;
            cmdCancel.Click += cmdCancel_Click;
            //this.Load += Page_Load;
        }

        #endregion


	} //Settings

} //bhattji.Modules.Trackings
