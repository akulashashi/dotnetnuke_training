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
using DotNetNuke.Entities.Modules;
using System;
using DotNetNuke.Framework;
using System.Web.UI.WebControls;

namespace bhattji.Modules.YouTubeVideos
{

    /// <summary>
    /// This base class can be used to define custom properties for multiple controls. 
    /// An example module, DNNSimpleArticle (http://dnnsimplearticle.codeplex.com) uses this for an ArticleId
    /// 
    /// Because the class inherits from PortalModuleBase, properties like ModuleId, TabId, UserId, and others, 
    /// are accessible to your module's controls (that inherity from YouTubeVideoModuleBase)
    /// 
    /// </summary>

    public class YouTubeVideoModuleBase : PortalModuleBase
    {
        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //jQuery.RequestRegistration();

                //Insert2HeaderCSS();
                //Insert2HeaderJS();
            }
        }

        void Insert2HeaderCSS()
        {
            if (this.Page.Header.FindControl("CSS") != null)
            {

                Literal ltr = new Literal();
                //ltr.ID = "ltrModalHead";
                ltr.Text = "<link href=\"" + ControlPath + "css/glDatePicker.css\" type=\"text/css\" rel=\"stylesheet\" />";
                PlaceHolder pht = (PlaceHolder)this.Page.Header.FindControl("CSS");
                pht.Controls.Add(ltr);
            }
        }
        void Insert2HeaderJS()
        {
            if (this.Page.Header.FindControl("SCRIPTS") != null)
            {

                Literal ltr = new Literal();
                //ltr.ID = "ltrModalHead";
                ltr.Text = "<script src=\"" + ControlPath + "js/glDatePicker.js\" type=\"text/javascript\" language=\"javascript\"></script>";
                PlaceHolder pht = (PlaceHolder)this.Page.Header.FindControl("SCRIPTS");
                pht.Controls.Add(ltr);
            }
        }

        
    }
}//namespace bhattji.Modules.YouTubeVideos
