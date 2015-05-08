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
//using bhattji.Modules.Trackings.Business;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Framework;
using System.Text;

namespace bhattji.Modules.Trackings
{

    public abstract partial class Views : TrackingModuleBase, IActionable
    {

        #region " private Members "

        //void RegisterJS()
        //{
        //    //Put user code to initialize the page here
        //    //string RattleImageJS = "<SCRIPT type=\"text/javascript\" src=\"" + ControlPath + "js/JbRattleImage.js\"></SCRIPT>";
        //    //if ((!Page.ClientScript.IsClientScriptBlockRegistered("RattleImageJS")))
        //    //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RattleImageJS", RattleImageJS);
        //    if ((!Page.ClientScript.IsClientScriptIncludeRegistered("RattleImageJS")))
        //        Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "RattleImageJS", ControlPath + "js/JbRattleImage.js");

        //    //string JB_ActiveContentJS = "<SCRIPT type=\"text/javascript\" src=\"" + ControlPath + "js/JB_ActiveContent.js\"></SCRIPT>";
        //    //if ((!Page.ClientScript.IsClientScriptBlockRegistered("JB_ActiveContentJS")))
        //    //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "JB_ActiveContentJS", JB_ActiveContentJS);
        //    if ((!Page.ClientScript.IsClientScriptIncludeRegistered("JB_ActiveContentJS")))
        //        Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "JB_ActiveContentJS", ControlPath + "js/JB_ActiveContent.js");
        //}


        private void RenderMedia(HtmlTextWriter htw, OptionsInfo objOI)
        {
            switch (objOI.Player.ToLower())
            {
                case "audio":
                    RenderAudio(htw, objOI);
                    break;
                case "img":
                    RenderImage(htw, objOI);
                    break;
                default:
                    RenderVideo(htw, objOI);
                    break;
            }
        }

        private void RenderVideo(HtmlTextWriter htw, OptionsInfo objOI)
        {
            if (!string.IsNullOrEmpty(objOI.PosterSrc))
                htw.AddAttribute("poster", objOI.LinkClickUrlLegacy(objOI.PosterSrc));
            if (objOI.Responsive)
            {
                htw.AddAttribute(HtmlTextWriterAttribute.Width, "100%");
            }
            else
            {
                if (!string.IsNullOrEmpty(objOI.Width))
                    htw.AddAttribute(HtmlTextWriterAttribute.Width, objOI.Width);
                if (!string.IsNullOrEmpty(objOI.Height))
                    htw.AddAttribute(HtmlTextWriterAttribute.Height, objOI.Height);
            }
            if (objOI.ShowControls)
                htw.AddAttribute("controls", "true");
            if (objOI.AutoPlay)
                htw.AddAttribute("autoplay", "true");
            if (objOI.Loop)
                htw.AddAttribute("loop", "true");
            if (objOI.Muted)
                htw.AddAttribute("muted", "true");
            htw.RenderBeginTag("video");
            htw.AddAttribute(HtmlTextWriterAttribute.Src,objOI.LinkClickUrlLegacy(objOI.MediaSrc));
            if (!string.IsNullOrEmpty(objOI.SrcType))
            {
                htw.AddAttribute(HtmlTextWriterAttribute.Type, objOI.SrcType);
            }
            htw.RenderBeginTag("source");
            htw.RenderEndTag();//source
            if (!string.IsNullOrEmpty(objOI.MediaSrc2))
            {
                htw.AddAttribute(HtmlTextWriterAttribute.Src, objOI.LinkClickUrlLegacy(objOI.MediaSrc2));
                if (!string.IsNullOrEmpty(objOI.SrcType2))
                {
                    htw.AddAttribute(HtmlTextWriterAttribute.Type, objOI.SrcType2);
                }
                htw.RenderBeginTag("source");
                htw.RenderEndTag();//source
            }
            if (!string.IsNullOrEmpty(objOI.MediaSrc3))
            {
                htw.AddAttribute(HtmlTextWriterAttribute.Src, objOI.LinkClickUrlLegacy(objOI.MediaSrc3));
                if (!string.IsNullOrEmpty(objOI.SrcType3))
                {
                    htw.AddAttribute(HtmlTextWriterAttribute.Type, objOI.SrcType3);
                }
                htw.RenderBeginTag("source");
                htw.RenderEndTag();//source
            }
            if (!string.IsNullOrEmpty(objOI.FallbackUrl))
            {
                htw.AddAttribute(HtmlTextWriterAttribute.Src, objOI.FallbackUrl);
                if (!string.IsNullOrEmpty(objOI.Width))
                    htw.AddAttribute(HtmlTextWriterAttribute.Width, objOI.Width);
                if (!string.IsNullOrEmpty(objOI.Height))
                    htw.AddAttribute(HtmlTextWriterAttribute.Height, objOI.Height);
                htw.AddAttribute("frameborder", "0");
                htw.AddAttribute("allowfullscreen", "1");
                htw.RenderBeginTag(HtmlTextWriterTag.Iframe);
                htw.RenderEndTag();//Iframe
            }
            else
            {
                htw.Write(Localization.GetString("NoTracking", LocalResourceFile));
            }
            htw.RenderEndTag();//video
        }

        private void RenderAudio(HtmlTextWriter htw, OptionsInfo objOI)
        {

            if (!string.IsNullOrEmpty(objOI.PosterSrc))
            {
                htw.AddAttribute("poster", objOI.LinkClickUrlLegacy(objOI.PosterSrc));
                if (objOI.Responsive)
                {
                    htw.AddAttribute(HtmlTextWriterAttribute.Width, "100%");
                }
                else
                {
                    if (!string.IsNullOrEmpty(objOI.Width))
                        htw.AddAttribute(HtmlTextWriterAttribute.Width, objOI.Width);
                    if (!string.IsNullOrEmpty(objOI.Height))
                        htw.AddAttribute(HtmlTextWriterAttribute.Height, objOI.Height);
                }
                htw.RenderBeginTag(HtmlTextWriterTag.Img);
                htw.RenderEndTag();//Img
                htw.Write("<br/>");
            }

            if (objOI.ShowControls)
                htw.AddAttribute("controls", "true");
            if (objOI.AutoPlay)
                htw.AddAttribute("autoplay", "true");
            if (objOI.Loop)
                htw.AddAttribute("loop", "true");
            if (objOI.Muted)
                htw.AddAttribute("muted", "true");
            htw.RenderBeginTag("audio");
            htw.AddAttribute(HtmlTextWriterAttribute.Src, objOI.LinkClickUrlLegacy(objOI.MediaSrc));
            if (!string.IsNullOrEmpty(objOI.SrcType))
            {
                htw.AddAttribute(HtmlTextWriterAttribute.Type, objOI.SrcType);
            }
            htw.RenderBeginTag("source");
            htw.RenderEndTag();//source
            if (!string.IsNullOrEmpty(objOI.MediaSrc2))
            {
                htw.AddAttribute(HtmlTextWriterAttribute.Src, objOI.LinkClickUrlLegacy(objOI.MediaSrc2));
                if (!string.IsNullOrEmpty(objOI.SrcType2))
                {
                    htw.AddAttribute(HtmlTextWriterAttribute.Type, objOI.SrcType2);
                }
                htw.RenderBeginTag("source");
                htw.RenderEndTag();//source
            }
            if (!string.IsNullOrEmpty(objOI.MediaSrc3))
            {
                htw.AddAttribute(HtmlTextWriterAttribute.Src, objOI.LinkClickUrlLegacy(objOI.MediaSrc3));
                if (!string.IsNullOrEmpty(objOI.SrcType3))
                {
                    htw.AddAttribute(HtmlTextWriterAttribute.Type, objOI.SrcType3);
                }
                htw.RenderBeginTag("source");
                htw.RenderEndTag();//source
            }
            htw.Write(Localization.GetString("NoTracking", LocalResourceFile));            
            htw.RenderEndTag();//audio
        }
        private void RenderImage(HtmlTextWriter htw, OptionsInfo objOI)
        {
            htw.AddAttribute(HtmlTextWriterAttribute.Src, objOI.LinkClickUrlLegacy(objOI.MediaSrc));
            if (objOI.Responsive)
            {
                htw.AddAttribute(HtmlTextWriterAttribute.Width, "100%");
            }
            else
            {
                if (!string.IsNullOrEmpty(objOI.Width))
                    htw.AddAttribute(HtmlTextWriterAttribute.Width, objOI.Width);
                if (!string.IsNullOrEmpty(objOI.Height))
                    htw.AddAttribute(HtmlTextWriterAttribute.Height, objOI.Height);
            }
            htw.RenderBeginTag(HtmlTextWriterTag.Img);
            htw.RenderEndTag();//Img
        }
       
        string getMediaString(OptionsInfo objOI)
        {            
            string Player = objOI.Player.ToLower();
            StringBuilder sb = new StringBuilder();
            if (Player == "audio" && !string.IsNullOrEmpty(objOI.PosterSrc))
            {
                sb.Append("<img src=\"" + objOI.LinkClickUrlLegacy(objOI.PosterSrc) + "\" ");
                if (!string.IsNullOrEmpty(objOI.Width))
                    sb.Append("width=\"" + objOI.Width + "\" ");
                if (!string.IsNullOrEmpty(objOI.Height))
                    sb.Append("height=\"" + objOI.Height + "\" ");
                if (objOI.RattleImage)
                    sb.Append("onmouseover=\"jb_ri_init(this);jb_ri_rattleimage()\" onmouseout=\"jb_ri_stoprattle(this);top.focus()\" onclick=\"top.focus()\" ");
                sb.Append(" /><br/>");
            }
            sb.Append("<" + Player + " ");
            sb.Append("src=\"" + objOI.LinkClickUrlLegacy(objOI.MediaSrc) + "\" ");

            if (Player == "video" || Player == "img")
            {
                if (!string.IsNullOrEmpty(objOI.Width))
                    sb.Append("width=\"" + objOI.Width + "\" ");
                if (!string.IsNullOrEmpty(objOI.Height))
                    sb.Append("height=\"" + objOI.Height + "\" ");
            }
            if (Player == "video" || Player == "audio")
            {
                if (Player == "video" && !string.IsNullOrEmpty(objOI.PosterSrc))
                    sb.Append("poster=\"" + objOI.LinkClickUrlLegacy(objOI.PosterSrc) + "\" ");
                if (objOI.ShowControls)
                    sb.Append("controls ");
                if (objOI.AutoPlay)
                    sb.Append("autoplay ");
                if (objOI.Loop)
                    sb.Append("loop ");
                if (objOI.Muted)
                    sb.Append("muted ");
                sb.Append(">" + Localization.GetString("NoTracking", LocalResourceFile) + "</" + Player + ">");
            }
            else
            {
                if (objOI.RattleImage)
                    sb.Append("onmouseover=\"jb_ri_init(this);jb_ri_rattleimage()\" onmouseout=\"jb_ri_stoprattle(this);top.focus()\" onclick=\"top.focus()\" ");
                sb.Append("/>");
            }
            return sb.ToString();
        }

        //string getMediaString()
        //{
        //    OptionsInfo objOI = new OptionsInfo(ModuleId);
        //    string Player = objOI.Player.ToLower();
        //    StringBuilder sb = new StringBuilder();
        //    if (!string.IsNullOrEmpty(objOI.NavURL) || !string.IsNullOrEmpty(objOI.Description))
        //    {
        //        sb.Append("<a ");
        //        if (!string.IsNullOrEmpty(objOI.NavURL))
        //        {
        //            sb.Append("href=\"" + objOI.LinkClickUrlLegacy(objOI.NavURL) + "\" ");
        //            if (objOI.NewWindow)
        //                sb.Append("target=\"_blank\" ");
        //        }
        //        if (!string.IsNullOrEmpty(objOI.Description))
        //            sb.Append("title=\"" + objOI.Description + "\" ");
        //        sb.Append(">");
        //    }
        //    if (Player == "audio" && !string.IsNullOrEmpty(objOI.PosterSrc))
        //    {
        //        sb.Append("<img src=\"" + objOI.LinkClickUrlLegacy(objOI.PosterSrc) + "\" ");
        //        if (!string.IsNullOrEmpty(objOI.Width))
        //            sb.Append("width=\"" + objOI.Width + "\" ");
        //        if (!string.IsNullOrEmpty(objOI.Height))
        //            sb.Append("height=\"" + objOI.Height + "\" ");
        //        if (objOI.RattleImage)
        //            sb.Append("onmouseover=\"jb_ri_init(this);jb_ri_rattleimage()\" onmouseout=\"jb_ri_stoprattle(this);top.focus()\" onclick=\"top.focus()\" ");
        //        sb.Append(" /><br/>");
        //    }
        //    sb.Append("<" + Player + " ");
        //    sb.Append("src=\"" + objOI.LinkClickUrlLegacy(objOI.MediaSrc) + "\" ");

        //    if (Player == "video" || Player == "img")
        //    {
        //        if (!string.IsNullOrEmpty(objOI.Width))
        //            sb.Append("width=\"" + objOI.Width + "\" ");
        //        if (!string.IsNullOrEmpty(objOI.Height))
        //            sb.Append("height=\"" + objOI.Height + "\" ");
        //    }
        //    if (Player == "video" || Player == "audio")
        //    {
        //        if (Player == "video" && !string.IsNullOrEmpty(objOI.PosterSrc))
        //            sb.Append("poster=\"" + objOI.LinkClickUrlLegacy(objOI.PosterSrc) + "\" ");
        //        if (objOI.ShowControls)
        //            sb.Append("controls ");
        //        if (objOI.AutoPlay)
        //            sb.Append("autoplay ");
        //        if (objOI.Loop)
        //            sb.Append("loop ");
        //        if (objOI.Muted)
        //            sb.Append("muted ");
        //        sb.Append(">" + Localization.GetString("NoTracking", LocalResourceFile) + "</" + Player + ">");
        //    }
        //    else
        //    {
        //        if (objOI.RattleImage)
        //            sb.Append("onmouseover=\"jb_ri_init(this);jb_ri_rattleimage()\" onmouseout=\"jb_ri_stoprattle(this);top.focus()\" onclick=\"top.focus()\" ");
        //        sb.Append("/>");
        //    }
        //    if (!string.IsNullOrEmpty(objOI.NavURL) || !string.IsNullOrEmpty(objOI.Description))
        //        sb.Append("</a>");
        //    return sb.ToString();
        //}

        #endregion

        #region " Event Handlers "

        protected override void Render(HtmlTextWriter htw)
        {
            OptionsInfo objOI = new OptionsInfo(ModuleId);
            if (!string.IsNullOrEmpty(objOI.NavURL) || !string.IsNullOrEmpty(objOI.Description))
            {                
                if (!string.IsNullOrEmpty(objOI.NavURL))
                {
                    htw.AddAttribute(HtmlTextWriterAttribute.Href, objOI.LinkClickUrlLegacy(objOI.NavURL));
                    if (objOI.NewWindow)
                        htw.AddAttribute(HtmlTextWriterAttribute.Target, "_blank");
                }
                if (!string.IsNullOrEmpty(objOI.Description))
                    htw.AddAttribute(HtmlTextWriterAttribute.Title, objOI.Description);

                htw.RenderBeginTag(HtmlTextWriterTag.A);//<a> 
            }

            //htw.Write(getMediaString(objOI));
            RenderMedia(htw, objOI);

            if (!string.IsNullOrEmpty(objOI.NavURL) || !string.IsNullOrEmpty(objOI.Description))
                htw.RenderEndTag();//</a> 
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
            //this.Load += new EventHandler(this.Page_Load);
            //this.Load += Page_Load;
        }

        #endregion

        #region " Optional Interfaces "

        ModuleActionCollection IActionable.ModuleActions
        {
            get
            {
                ModuleActionCollection Actions = new ModuleActionCollection();
                //Actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.AddContent, LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                Actions.Add(GetNextActionID(), Localization.GetString(ModuleActionType.ContentOptions, LocalResourceFile), ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                //Actions.Add(GetNextActionID(), Localization.GetString("ManageCategories", LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl("EditType", "EditCat"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                //Actions.Add(GetNextActionID(), Localization.GetString("ManageZipcodes", LocalResourceFile), ModuleActionType.AddContent, "", "", EditUrl("EditType", "EditZip"), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false);
                //Actions.Add(GetNextActionID, "Edit Alts", Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl("ItemId", "1", "EditAlt"), False, DotNetNuke.Security.SecurityAccessLevel.Edit, True, False)
                /*
                OptionsInfo objOI = new OptionsInfo(ModuleId,TabId);
                if (IsEditable || (new OptionsInfo(ModuleId, TabId)).CanAdd) Actions.Add(GetNextActionID(), "Add", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                if (objOI.CanAlter) Actions.Add(GetNextActionID(), "Alter", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                if (objOI.CanApprove) Actions.Add(GetNextActionID(), "Approve", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                if (objOI.CanDelete) Actions.Add(GetNextActionID(), "Delete", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                if (objOI.CanSelfEdit) Actions.Add(GetNextActionID(), "SelfEdit", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                Actions.Add(GetNextActionID(), "Add", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                Actions.Add(GetNextActionID(), "Alter", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                Actions.Add(GetNextActionID(), "Approve", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                Actions.Add(GetNextActionID(), "Delete", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                Actions.Add(GetNextActionID(), "SelfEdit", ModuleActionType.ContentOptions, "", "", EditUrl("SettingsModuleId", ModuleId.ToString(), "Settings"), false, DotNetNuke.Security.SecurityAccessLevel.View, true, false);
                */
                return Actions;
            }
        }

        #endregion

    }//Views

}//bhattji.Modules.Trackings
