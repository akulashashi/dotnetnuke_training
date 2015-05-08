using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bhattji.Modules.XYZ60s{ 

    [DefaultProperty("Text")]
    [ToolboxData("<{0}:GenericPlayer runat=server></{0}:GenericPlayer>")]
    public class GenericPlayer : HyperLink
    {
        #region Properties
        
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        public string Src
        {
            get{return ImageUrl;}
            set{ImageUrl = value;}
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ActiveContent
        {
            get {
                return (bool)ViewState["ActiveContent"];
            }
            set { ViewState["ActiveContent"] = value; }
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string MouseOverUrl
        {
            get
            {
                string s = (string)ViewState["MouseOverUrl"];
                return (s != null) ? s : string.Empty;
            }
            set { ViewState["MouseOverUrl"] = value; }
        }

        [Category("Appearance")]
        [DefaultValue("")]
        public string BackGroundUrl
        {
            get
            {
                string s = (string)ViewState["BackGroundUrl"];
                return (s != null) ? s : string.Empty;
            }
            set { ViewState["BackGroundUrl"] = value; }
        }

        #endregion

        #region Event Handlers
        
        protected override void RenderContents(HtmlTextWriter output)
        {
            //output.Write(Text);
            HyperLink hyp = (HyperLink)this;
            if (BackGroundUrl != string.Empty) {
                hyp.Style.Add(HtmlTextWriterStyle.BackgroundImage, BackGroundUrl);
            }
            hyp.RenderControl(output);
            //base.RenderContents(output);
        }

        #endregion
    }

}
