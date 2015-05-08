using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI.Design;
using System.Drawing.Design;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Specialized;

namespace bhattji.Modules.YouTubeVideos
{
    [DefaultProperty("AltText")]
    [ToolboxData("<{0}:bhattjiMedia runat=server></{0}:bhattjiMedia>")]
    [Serializable]
    internal class bhattjiMedia : WebControl //HyperLink
    {
        #region Properties

        #region MediaFiles
        [Category("MediaFiles")]
        [DefaultValue("Auto")]
        public string Player
        {
            get
            {
                string _Player = (ViewState["Player"] != null) ? (string)ViewState["Player"] : "Auto";
                switch (_Player.ToLower())
                {
                    case "image":
                    case "video":
                    case "flashplayer":
                    case "flash":
                    case "swf":
                    case "flvplayer":
                    case "flv":
                    case "shockwaveplayer":
                    case "swp":
                    case "authorware":
                    case "awp":
                    case "windowsmediaplayer":
                    case "wmp":
                    case "realplayer":
                    case "rp":
                    case "quicktimeplayer":
                    case "qtp":
                    case "applet":
                    case "java":
                    case "jvm":
                    case "iframe":
                    case "extpage":
                    case "to":
                    case "tot":
                    case "textovertext":
                        //"pano", "panoramaplayer", "panoshpere", "panocylndr", "panocylinder" 
                        return _Player;

                    default:
                        switch (Path.GetExtension(Src).ToLower())
                        {
                            case ".swf":
                                return "Flash";
                            case ".flv":
                                return "FLV";
                            case ".dcr":
                                return "SWP";
                            case ".aam":
                                return "AWP";
                            case ".rm":
                            case ".rmvb":
                                return "RP";
                            case ".mov":
                                return "QtP";
                            case ".gif":
                            case ".jpg":
                            case ".jpeg":
                            case ".jpe":
                                return "Image";
                            case ".htm":
                            case ".html":
                            case ".asp":
                            case ".aspx":
                                return "IFrame";
                            default:
                                //".wmv" 
                                return "WMP";
                        }
                    //break;
                }
            }
            set { ViewState["Player"] = value; }
        }

        [Bindable(true)]
        [Category("MediaFiles")]
        [EditorAttribute(typeof(UrlEditor), typeof(UITypeEditor))]
        [DefaultValue("")]
        public string Src
        {
            get { return (ViewState["Src"] != null) ? (string)ViewState["Src"] : string.Empty; }
            set { ViewState["Src"] = value; }
        }

        [Category("MediaFiles")]
        [EditorAttribute(typeof(UrlEditor), typeof(UITypeEditor))]
        [DefaultValue("")]
        public string MouseOverSrc
        {
            get { return (ViewState["MouseOverSrc"] != null) ? (string)ViewState["MouseOverSrc"] : string.Empty; }
            set { ViewState["MouseOverSrc"] = value; }
        }

        [Category("MediaFiles")]
        [EditorAttribute(typeof(UrlEditor), typeof(UITypeEditor))]
        [DefaultValue("")]
        public string BackGroundSrc
        {
            get { return (ViewState["BackGroundSrc"] != null) ? (string)ViewState["BackGroundSrc"] : string.Empty; }
            set { ViewState["BackGroundSrc"] = value; }
        }

        [Category("MediaFiles")]
        [EditorAttribute(typeof(UrlEditor), typeof(UITypeEditor))]
        [DefaultValue("")]
        public string MusicSrc
        {
            get { return (ViewState["MusicSrc"] != null) ? (string)ViewState["MusicSrc"] : string.Empty; }
            set { ViewState["MusicSrc"] = value; }
        }
        #endregion

        #region Appearance
        [Category("Appearance")]
        [DefaultValue("")]
        public string BgColor
        {
            get
            {
                //string _BgColor = (ViewState["BgColor"] != null) ? (string)ViewState["BgColor"] : "#FFFFFF";
                //return _BgColor.StartsWith("#") ? _BgColor : "#" + _BgColor;
                return (ViewState["BgColor"] != null) ? (string)ViewState["BgColor"] : string.Empty;
            }
            set { ViewState["BgColor"] = value; }
        }
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string AltText
        {
            get { return (ViewState["AltText"] != null) ? (string)ViewState["AltText"] : string.Empty; }
            set { ViewState["AltText"] = value; }
        }
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Description
        {
            get { return (ViewState["Description"] != null) ? (string)ViewState["Description"] : string.Empty; }
            set { ViewState["Description"] = value; }
        }

        [Category("Layout")]
        [DefaultValue("")]
        public string MediaWidth
        {
            get { return (ViewState["MediaWidth"] != null) ? (string)ViewState["MediaWidth"] : string.Empty; }
            set { ViewState["MediaWidth"] = value; }
        }
        [Category("Layout")]
        [DefaultValue("")]
        public string MediaHeight
        {
            get { return (ViewState["MediaHeight"] != null) ? (string)ViewState["MediaHeight"] : string.Empty; }
            set { ViewState["MediaHeight"] = value; }
        }
        [Category("Layout")]
        [DefaultValue("")]
        public string MediaAlign
        {
            get { return (ViewState["MediaAlign"] != null) ? (string)ViewState["MediaAlign"] : string.Empty; }
            set { ViewState["MediaAlign"] = value; }
        }
        #endregion

        #region Behavior
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool ActiveContent
        {
            get { return (ViewState["ActiveContent"] != null) ? (bool)ViewState["ActiveContent"] : true; }
            set { ViewState["ActiveContent"] = value; }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool AutoStart
        {
            get { return (ViewState["AutoStart"] != null) ? (bool)ViewState["AutoStart"] : true; }
            set { ViewState["AutoStart"] = value; }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool AutoRewind
        {
            get { return (ViewState["AutoRewind"] != null) ? (bool)ViewState["AutoRewind"] : true; }
            set { ViewState["AutoRewind"] = value; }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool OnlyEmbedTag
        {
            get { return (ViewState["OnlyEmbedTag"] != null) ? (bool)ViewState["OnlyEmbedTag"] : true; }
            set { ViewState["OnlyEmbedTag"] = value; }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool MusicControls
        {
            get { return (ViewState["MusicControls"] != null) ? (bool)ViewState["MusicControls"] : true; }
            set { ViewState["MusicControls"] = value; }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool RattleImage
        {
            get { return (ViewState["RattleImage"] != null) ? (bool)ViewState["RattleImage"] : true; }
            set { ViewState["RattleImage"] = value; }
        }

        [Category("Behavior")]
        [DefaultValue(1)]
        public int RepeatCount
        {
            get { return (ViewState["RepeatCount"] != null) ? (int)ViewState["RepeatCount"] : 1; }
            set { ViewState["RepeatCount"] = value; }
        }

        [Category("SlideShow")]
        [DefaultValue("Pixelate")]
        public string Transition
        {
            get { return (ViewState["Transition"] != null) ? (string)ViewState["Transition"] : "Pixelate"; }
            set { ViewState["Transition"] = value; }
        }
        #endregion

        #region Navigation
        [Category("Navigation")]
        [DefaultValue("")]
        [EditorAttribute(typeof(UrlEditor), typeof(UITypeEditor))]
        public string NavigateUrl
        {
            get { return (ViewState["NavigateUrl"] != null) ? (string)ViewState["NavigateUrl"] : string.Empty; }
            set { ViewState["NavigateUrl"] = value; }
        }

        [Category("Navigation")]
        [DefaultValue("")]
        public string Target
        {
            get { return (ViewState["Target"] != null) ? (string)ViewState["Target"] : string.Empty; }
            set { ViewState["Target"] = value; }
        }
        #endregion

        #region TextOver
        [Category("TextOver")]
        [DefaultValue("")]
        public string TextOverText
        {
            get { return (ViewState["TextOverText"] != null) ? (string)ViewState["TextOverText"] : string.Empty; }
            set { ViewState["TextOverText"] = value; }
        }
        [Category("TextOver")]
        [DefaultValue("")]
        public string TextOverCssClass
        {
            get { return (ViewState["TextOverCssClass"] != null) ? (string)ViewState["TextOverCssClass"] : string.Empty; }
            set { ViewState["TextOverCssClass"] = value; }
        }
        #endregion

        #region Windows Media Player
        [Category("Windows Media Player")]
        [DefaultValue("mini")]
        public string uiMode
        {
            get { return (ViewState["uiMode"] != null) ? (string)ViewState["uiMode"] : "mini"; }
            set { ViewState["uiMode"] = value; }
        }
        #endregion

        #region FlashPlayer
        [Category("FlashPlayer")]
        [DefaultValue("")]
        public string FlashVars
        {
            get { return (ViewState["FlashVars"] != null) ? (string)ViewState["FlashVars"] : string.Empty; }
            set { ViewState["FlashVars"] = value; }
        }
        [Category("FlashPlayer")]
        [DefaultValue("high")]
        public string FlashQuality
        {
            get { return (ViewState["FlashQuality"] != null) ? (string)ViewState["FlashQuality"] : "high"; }
            set { ViewState["FlashQuality"] = value; }
        }
        [Category("FlashPlayer")]
        [DefaultValue("transparent")]
        public string FlashWmode
        {
            get { return (ViewState["FlashWmode"] != null) ? (string)ViewState["FlashWmode"] : "transparent"; }
            set { ViewState["FlashWmode"] = value; }
        }
        #endregion

        #region FlvPlayer
        [Category("FlvPlayer")]
        [EditorAttribute(typeof(UrlEditor), typeof(UITypeEditor))]
        [DefaultValue("FLVPlayer_Progressive.swf")]
        public string FlvComponent
        {
            get { return (ViewState["FlvComponent"] != null) ? (string)ViewState["FlvComponent"] : "FLVPlayer_Progressive.swf"; }
            set { ViewState["FlvComponent"] = value; }
        }
        [Category("FlvPlayer")]
        [EditorAttribute(typeof(UrlEditor), typeof(UITypeEditor))]
        [DefaultValue("FlvSkin")]
        public string FlvSkin
        {
            get { return (ViewState["FlvSkin"] != null) ? (string)ViewState["FlvSkin"] : "FlvSkin"; }
            set { ViewState["FlvSkin"] = value; }
        }
        #endregion

        #region Shockwave
        [Category("Shockwave")]
        [DefaultValue("")]
        public string swRemote
        {
            get { return (ViewState["swRemote"] != null) ? (string)ViewState["swRemote"] : string.Empty; }
            set { ViewState["swRemote"] = value; }
        }
        [Category("Shockwave")]
        [DefaultValue("none")]
        public string swStretchStyle
        {
            get { return (ViewState["swStretchStyle"] != null) ? (string)ViewState["swStretchStyle"] : "none"; }
            set { ViewState["swStretchStyle"] = value; }
        }
        #endregion

        #region Authorware
        [Category("Authorware")]
        [DefaultValue("background")]
        public string Palette
        {
            get { return (ViewState["Palette"] != null) ? (string)ViewState["Palette"] : "background"; }
            set { ViewState["Palette"] = value; }
        }
        [Category("Authorware")]
        [DefaultValue("inPlace")]
        public string awWindow
        {
            get { return (ViewState["awWindow"] != null) ? (string)ViewState["awWindow"] : "inPlace"; }
            set { ViewState["awWindow"] = value; }
        }
        #endregion

        #region JavaApplet
        [Category("JavaApplet")]
        [DefaultValue("")]
        public string JavaCode
        {
            get { return (ViewState["JavaCode"] != null) ? (string)ViewState["JavaCode"] : string.Empty; }
            set { ViewState["JavaCode"] = value; }
        }
        [Category("JavaApplet")]
        [DefaultValue("")]
        public string Archive
        {
            get { return (ViewState["Archive"] != null) ? (string)ViewState["Archive"] : string.Empty; }
            set { ViewState["Archive"] = value; }
        }
        #endregion

        #region IFrame
        [Category("IFrame")]
        [DefaultValue("no")]
        public string Border
        {
            get { return (ViewState["Border"] != null) ? (string)ViewState["Border"] : "no"; }
            set { ViewState["Border"] = value; }
        }
        [Category("IFrame")]
        [DefaultValue("auto")]
        public string Scrolling
        {
            get { return (ViewState["Scrolling"] != null) ? (string)ViewState["Scrolling"] : "auto"; }
            set { ViewState["Scrolling"] = value; }
        }
        #endregion

        #endregion

        #region Functions

        public override string ToString()
        {
            return ToString(ActiveContent);
        }
        //ToString() 

        public string ToString(bool ActiveContent)
        {
            if (ActiveContent)
            {
                string _ToActiveString = GetMediaString();
                if (_ToActiveString.ToLower().StartsWith("<object") | _ToActiveString.ToLower().StartsWith("<embed") | _ToActiveString.ToLower().StartsWith("<applet"))
                {
                    if (MusicSrc != string.Empty)
                    {
                        return "<script type=\"text/javascript\">JB_GetActiveContent('" + (_ToActiveString + "<br />" + GetMusicString()).Replace("'", "\\'") + "')</script>";
                    }
                    else
                    {
                        return "<script type=\"text/javascript\">JB_GetActiveContent('" + _ToActiveString.Replace("'", "\\'") + "')</script>";
                    }
                }
                else
                {
                    if (MusicSrc != string.Empty)
                    {
                        return _ToActiveString + "<br /><script type=\"text/javascript\">JB_GetActiveContent('" + GetMusicString().Replace("'", "\\'") + "')</script>";
                    }
                    else
                    {
                        return _ToActiveString;
                    }
                }
            }
            else
            {
                if (MusicSrc != string.Empty)
                {
                    return GetMediaString() + GetMusicString();
                }
                else
                {
                    return GetMediaString();
                }
            }
        }
        //ToString() 

        //Function ToActiveString() As String 
        // Dim _ToActiveString As String = GetMediaString() 
        // If _ToActiveString.ToLower().StartsWith("<object") _ 
        // Or _ToActiveString.ToLower().StartsWith("<embed") _ 
        // Or _ToActiveString.ToLower().StartsWith("<applet") Then 
        // If MusicSrc <> String.Empty Then 
        // Return "<script type=""text/javascript"">JB_GetActiveContent('" & (_ToActiveString & GetMusicString()).Replace("'", "\'") & "')</script>" 
        // Else 
        // Return "<script type=""text/javascript"">JB_GetActiveContent('" & _ToActiveString.Replace("'", "\'") & "')</script>" 
        // End If 
        // Else 
        // If MusicSrc <> String.Empty Then 
        // Return _ToActiveString & "<script type=""text/javascript"">JB_GetActiveContent('" & GetMusicString().Replace("'", "\'") & "')</script>" 
        // Else 
        // Return _ToActiveString 
        // End If 
        // End If 

        //End Function 'ToActiveString 

        public string GetMediaString()
        {
            if (Src != string.Empty)
            {
                switch (Player.ToLower())
                {
                    case "flashplayer":
                    case "flash":
                    case "swf":
                        return GetFlashString();
                    case "flvplayer":
                    case "flv":
                        return GetFlvString();
                    case "shockwaveplayer":
                    case "swp":
                        return GetShocwaveString();
                    case "authorware":
                    case "awp":
                        return GetAuthorwareString();
                    case "windowsmediaplayer":
                    case "wmp":
                        return GetWMPString();
                    case "realplayer":
                    case "rp":
                        return GetRealPlayerString();
                    case "quicktimeplayer":
                    case "qtp":
                        return GetQuckTimeString();
                    case "applet":
                    case "java":
                    case "jvm":
                        //Case "pano", "panoramaplayer", "panoshpere", "panocylndr", "panocylinder" 
                        return GetAppletString();
                    case "iframe":
                    case "extpage":
                        return GetIFrameString();
                    case "image":
                    case "video":
                        return GetImageString();
                    default:
                        return "Unknown Player";
                }
            }

            else
            {
                return string.Empty;

            }
            //Src <> String.Empty 

        }
        //GetMediaString 

        public string GetMusicString()
        {
            if (MusicControls)
            {
                uiMode = "full";
                if (MediaWidth == string.Empty)
                {
                    MediaWidth = "320";
                }
                MediaHeight = "32";
            }
            else
            {
                uiMode = "invisible";
                MediaWidth = "0";
                MediaHeight = "0";
            }
            Player = "";
            Src = MusicSrc;
            return GetMediaString();

        }
        //GetMusicString 

        public string GetFlashString()
        {
            bhattjiObjectString objFlashStr = new bhattjiObjectString();
            {
                if (!OnlyEmbedTag)
                {
                    objFlashStr.ObjectAttrib = "id=\"" + ID + "\"" + " classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\"" + " codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\"" + " hspace=\"0\"" + " vspace=\"0\"" + (MediaWidth != string.Empty ? " width=\"" + MediaWidth + "\"" : "").ToString() + (MediaHeight != string.Empty ? " height=\"" + MediaHeight + "\"" : "").ToString() + (MediaAlign != string.Empty ? " align=\"" + MediaAlign + "\"" : "").ToString();

                }

                objFlashStr.EmbedAttrib = "name=\"" + ID + "\"" + " type=\"application/x-shockwave-flash\"" + " pluginspage=\"http://www.macromedia.com/go/getflashplayer\"" + " hspace=\"0\"" + " vspace=\"0\"" + (MediaWidth != string.Empty ? " width=\"" + MediaWidth + "\"" : "").ToString() + (MediaHeight != string.Empty ? " height=\"" + MediaHeight + "\"" : "").ToString() + (MediaAlign != string.Empty ? " align=\"" + MediaAlign + "\"" : "").ToString();


                //If MediaWidth <> String.Empty Then 
                // .EmbedAttrib += "width=""" & MediaWidth & """" 
                //End If 

                //If MediaHeight <> String.Empty Then 
                // .Height = MediaHeight 
                //End If 
                //If MediaAlign <> String.Empty Then 
                // .Align = MediaAlign 
                //End If 

                objFlashStr.SrcParam = "movie";
                objFlashStr.Src = Src;

                if (FlashVars != string.Empty)
                {
                    objFlashStr.Add("flashvars", FlashVars);
                }
                objFlashStr.Add("wmode", FlashWmode);
                objFlashStr.Add("quality", FlashQuality);
                objFlashStr.Add("bgcolor", BgColor);
                objFlashStr.Add("allowscriptaccess", "sameDomain");

                return objFlashStr.ToString();
            }

            //objFlashStr 

        }
        //GetFlashString 

        public string GetFlvString()
        {
            FlashVars = "&MM_ComponentVersion=1&skinName=" + FlvSkin.Replace(".swf", "") + "&streamName=" + Src + "&autoPlay=" + AutoStart.ToString().ToLower() + "&autoRewind=" + AutoRewind.ToString().ToLower();
            Src = FlvComponent;

            return GetFlashString();

        }
        //GetFlvString 

        public string GetShocwaveString()
        {
            bhattjiObjectString objShockwaveStr = new bhattjiObjectString();
            {
                if (!OnlyEmbedTag)
                {
                    objShockwaveStr.ObjectAttrib = "id=\"" + ID + "\"" + " classid=\"clsid:166B1BCA-3F9C-11CF-8075-444553540000\"" + " codebase=\"http://fpdownload.macromedia.com/get/shockwave/cabs/director/sw.cab#version=10,1,0,11\"" + " hspace=\"0\"" + " vspace=\"0\"" + (MediaWidth != string.Empty ? " width=\"" + MediaWidth + "\"" : "").ToString() + (MediaHeight != string.Empty ? " height=\"" + MediaHeight + "\"" : "").ToString() + (MediaAlign != string.Empty ? " align=\"" + MediaAlign + "\"" : "").ToString();

                }

                objShockwaveStr.EmbedAttrib = "name=\"" + ID + "\"" + " type=\"application/x-director\"" + " pluginspage=\"http://www.macromedia.com/shockwave/download\"" + " hspace=\"0\"" + " vspace=\"0\"" + (MediaWidth != string.Empty ? " width=\"" + MediaWidth + "\"" : "").ToString() + (MediaHeight != string.Empty ? " height=\"" + MediaHeight + "\"" : "").ToString() + (MediaAlign != string.Empty ? " align=\"" + MediaAlign + "\"" : "").ToString();

                //.SrcParam = "src" 
                objShockwaveStr.Src = Src;


                if (FlashVars != string.Empty)
                {
                    objShockwaveStr.Add("flashvars", FlashVars);
                }
                objShockwaveStr.Add("swRemote", swRemote);
                objShockwaveStr.Add("swStretchStyle", swStretchStyle);
                //.Add("wmode", FlashWmode) 
                //.Add("quality", FlashQuality) 
                objShockwaveStr.Add("bgcolor", BgColor);
                //.Add("allowscriptaccess", "sameDomain") 

                return objShockwaveStr.ToString();
            }

            //objShockwaveStr 

        }
        //GetShocwaveString 

        public string GetAuthorwareString()
        {
            bhattjiObjectString objAuthorwareStr = new bhattjiObjectString();
            {
                if (!OnlyEmbedTag)
                {
                    objAuthorwareStr.ObjectAttrib = "id=\"" + ID + "\"" + " classid=\"clsid:15B782AF-55D8-11D1-B477-006097098764\"" + " codebase=\"http://fpdownload.macromedia.com/get/shockwave/cabs/authorware/awswaxd.cab#version=2004,0,0,73\"" + " hspace=\"0\"" + " vspace=\"0\"" + (MediaWidth != string.Empty ? " width=\"" + MediaWidth + "\"" : "").ToString() + (MediaHeight != string.Empty ? " height=\"" + MediaHeight + "\"" : "").ToString() + (MediaAlign != string.Empty ? " align=\"" + MediaAlign + "\"" : "").ToString();

                }

                objAuthorwareStr.EmbedAttrib = "name=\"" + ID + "\"" + " type=\"application/x-authorware-map\"" + " pluginspage=\"http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=AWPfull\"" + " hspace=\"0\"" + " vspace=\"0\"" + (MediaWidth != string.Empty ? " width=\"" + MediaWidth + "\"" : "").ToString() + (MediaHeight != string.Empty ? " height=\"" + MediaHeight + "\"" : "").ToString() + (MediaAlign != string.Empty ? " align=\"" + MediaAlign + "\"" : "").ToString();


                //.SrcParam = "src" 
                objAuthorwareStr.Src = Src;

                if (FlashVars != string.Empty)
                {
                    objAuthorwareStr.Add("flashvars", FlashVars);
                }
                objAuthorwareStr.Add("Palette", Palette);
                objAuthorwareStr.Add("Window", awWindow);
                //.Add("wmode", FlashWmode) 
                //.Add("quality", FlashQuality) 
                objAuthorwareStr.Add("bgcolor", BgColor);
                //.Add("allowscriptaccess", "sameDomain") 

                return objAuthorwareStr.ToString();
            }

            //objAuthorwareStr 

        }
        //GetAuthorwareString 

        public string GetWMPString()
        {
            bhattjiObjectString objWMPStr = new bhattjiObjectString();
            {
                if (!OnlyEmbedTag)
                {
                    objWMPStr.ObjectAttrib = "id=\"" + ID + "\"" + " classid=\"CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6\"" + " hspace=\"0\"" + " vspace=\"0\"" + (MediaWidth != string.Empty ? " width=\"" + MediaWidth + "\"" : "").ToString() + (MediaHeight != string.Empty ? " height=\"" + MediaHeight + "\"" : "").ToString() + (MediaAlign != string.Empty ? " align=\"" + MediaAlign + "\"" : "").ToString();
                    //" codebase=""http://fpdownload.macromedia.com/get/shockwave/cabs/authorware/awswaxd.cab#version=2004,0,0,73""" & _ 

                }

                objWMPStr.EmbedAttrib = "name=\"" + ID + "\"" + " type=\"application/x-mplayer2\"" + " pluginspage=\"http://www.microsoft.com/windows/mediaplayer/download\"" + " hspace=\"0\"" + " vspace=\"0\"" + (MediaWidth != string.Empty ? " width=\"" + MediaWidth + "\"" : "").ToString() + (MediaHeight != string.Empty ? " height=\"" + MediaHeight + "\"" : "").ToString() + (MediaAlign != string.Empty ? " align=\"" + MediaAlign + "\"" : "").ToString();


                objWMPStr.SrcParam = "URL";
                objWMPStr.Src = Src;

                objWMPStr.Add("autoStart", AutoStart.ToString());
                objWMPStr.Add("enabled", "True");
                objWMPStr.Add("uiMode", uiMode.ToLower());
                if (RepeatCount > 1)
                {
                    objWMPStr.Add("playCount", RepeatCount.ToString());
                }

                return objWMPStr.ToString();
            }

            //objWMPStr 

        }
        //GetWMPString 

        public string GetRealPlayerString()
        {
            bhattjiObjectString objRPStr = new bhattjiObjectString();
            {
                if (!OnlyEmbedTag)
                {
                    objRPStr.ObjectAttrib = "id=\"RVOCX\"" + " classid=\"clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA\"" + " hspace=\"0\"" + " vspace=\"0\"" + (MediaWidth != string.Empty ? " width=\"" + MediaWidth + "\"" : "").ToString() + (MediaHeight != string.Empty ? " height=\"" + MediaHeight + "\"" : "").ToString() + (MediaAlign != string.Empty ? " align=\"" + MediaAlign + "\"" : "").ToString();
                    //" codebase=""http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0""" & _ 

                }

                objRPStr.EmbedAttrib = "name=\"" + ID + "\"" + " hspace=\"0\"" + " vspace=\"0\"" + (MediaWidth != string.Empty ? " width=\"" + MediaWidth + "\"" : "").ToString() + (MediaHeight != string.Empty ? " height=\"" + MediaHeight + "\"" : "").ToString() + (MediaAlign != string.Empty ? " align=\"" + MediaAlign + "\"" : "").ToString();
                //" type=""application/x-shockwave-flash""" & _ 
                //" pluginspage=""http://www.macromedia.com/go/getflashplayer""" & _ 


                //.SrcParam = "src" 
                //.SrcAttrib = "qtsrc" 
                objRPStr.Src = Src;

                objRPStr.Add("autostart", AutoStart.ToString());

                objRPStr.Add("controls", "ImageWindow");
                objRPStr.Add("console", "one");
                objRPStr.Add("NOJAVA", "true");
            }
            //.Add("enabled", "True") 
            //.Add("uiMode", uiMode.ToLower()) 
            //If RepeatCount > 1 Then 
            // .Add("playCount", RepeatCount.ToString()) 
            //End If 

            //objRPStr 

            string strRPStr = objRPStr.ToString();

            if (uiMode.ToLower() != "none")
            {
                bhattjiObjectString objRPControlStr = new bhattjiObjectString();
                {
                    if (!OnlyEmbedTag)
                    {
                        objRPControlStr.ObjectAttrib = "id=\"RVOCX\"" + " classid=\"clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA\"" + " hspace=\"0\"" + " vspace=\"0\"" + " width=\"" + (MediaWidth != string.Empty ? MediaWidth : "320").ToString() + "\"" + " height=\"32\"" + (MediaAlign != string.Empty ? " align=\"" + MediaAlign + "\"" : "").ToString();
                        //" codebase=""http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0""" & _ 

                    }

                    objRPControlStr.EmbedAttrib = "name=\"" + ID + "\"" + " hspace=\"0\"" + " vspace=\"0\"" + " width=\"" + (MediaWidth != string.Empty ? MediaWidth : "320").ToString() + "\"" + " height=\"32\"" + (MediaAlign != string.Empty ? " align=\"" + MediaAlign + "\"" : "").ToString();
                    //IIf(MediaHeight <> String.Empty, " height=""" & MediaHeight & """", "").ToString() & _ 
                    //" type=""application/x-shockwave-flash""" & _ 
                    //" pluginspage=""http://www.macromedia.com/go/getflashplayer""" & _ 


                    //.SrcParam = "src" 
                    //.SrcAttrib = "qtsrc" 
                    objRPControlStr.Src = Src;

                    objRPControlStr.Add("autostart", AutoStart.ToString());
                    objRPControlStr.Add("controls", "ControlPanel");
                    objRPControlStr.Add("console", "one");
                    objRPControlStr.Add("NOJAVA", "true");
                }
                //.Add("enabled", "True") 
                //.Add("uiMode", uiMode.ToLower()) 
                //If RepeatCount > 1 Then 
                // .Add("playCount", RepeatCount.ToString()) 
                //End If 

                //objRPControlStr 

                strRPStr += "<br />" + objRPControlStr.ToString();

            }

            return strRPStr;

        }
        //GetRealPlayerString 

        public string GetQuckTimeString()
        {
            bhattjiObjectString objQtPStr = new bhattjiObjectString();
            {
                if (!OnlyEmbedTag)
                {
                    objQtPStr.ObjectAttrib = "id=\"" + ID + "\"" + " classid=\"clsid:02BF25D5-8C17-4B23-BC80-D3488ABDDC6B\"" + " codebase=\"http://www.apple.com/qtactivex/qtplugin.cab\"" + " hspace=\"0\"" + " vspace=\"0\"" + (MediaWidth != string.Empty ? " width=\"" + MediaWidth + "\"" : "").ToString() + (MediaHeight != string.Empty ? " height=\"" + MediaHeight + "\"" : "").ToString() + (MediaAlign != string.Empty ? " align=\"" + MediaAlign + "\"" : "").ToString();

                }

                objQtPStr.EmbedAttrib = "name=\"" + ID + "\"" + " type=\"image/x-macpaint\"" + " pluginspage=\"http://www.apple.com/quicktime/download\"" + " hspace=\"0\"" + " vspace=\"0\"" + (MediaWidth != string.Empty ? " width=\"" + MediaWidth + "\"" : "").ToString() + (MediaHeight != string.Empty ? " height=\"" + MediaHeight + "\"" : "").ToString() + (MediaAlign != string.Empty ? " align=\"" + MediaAlign + "\"" : "").ToString();



                //.SrcParam = "src" 
                objQtPStr.SrcAttrib = "qtsrc";
                objQtPStr.Src = Src;

                objQtPStr.Add("autoplay", AutoStart.ToString());
                //.Add("enabled", "True") 
                //.Add("uiMode", uiMode.ToLower()) 
                //If RepeatCount > 1 Then 
                // .Add("playCount", RepeatCount.ToString()) 
                //End If 

                return objQtPStr.ToString();
            }

            //objQtPStr 

        }
        //GetQuckTimeString 

        public string GetAppletString()
        {
            bhattjiObjectString objAppletStr = new bhattjiObjectString();
            {
                objAppletStr.AppletAttrib = "code=\"" + JavaCode + "\"" + (Archive != string.Empty ? " archive=\"" + Archive + "\"" : "").ToString() + " hspace=\"0\"" + " vspace=\"0\"" + (MediaWidth != string.Empty ? " width=\"" + MediaWidth + "\"" : "").ToString() + (MediaHeight != string.Empty ? " height=\"" + MediaHeight + "\"" : "").ToString() + (MediaAlign != string.Empty ? " align=\"" + MediaAlign + "\"" : "").ToString() + (ID != string.Empty ? " id=\"" + ID + "\"" : "").ToString();

                return objAppletStr.ToString();
            }

            //objAppletStr 

        }
        //GetAppletString 

        public string GetIFrameString()
        {
            string IFrameStr = "<iframe" + " src=\"" + Src + "\"" + (MediaWidth != string.Empty ? " width=\"" + MediaWidth + "\"" : " width=\"480\"").ToString() + (MediaHeight != string.Empty ? " height=\"" + MediaHeight + "\"" : " height=\"360\"").ToString() + (ID != string.Empty ? " id=\"" + ID + "\"" : "").ToString() + " frameborder=\"" + Border + "\"" + " scrolling=\"" + Scrolling + "\"" + "></iframe>";
            return IFrameStr;
        }
        //GetIFrameString 

        public string GetImageString()
        {
            StringBuilder sbImage = new StringBuilder();
            sbImage.Append("<img");

            switch (System.IO.Path.GetExtension(Src).ToLower())
            {
                case ".gif":
                case ".jpg":
                case ".jpeg":
                case ".jpe":
                    //, ".png" 'It is an image and not a Video 
                    sbImage.Append(" src=\"" + Src + "\"");
                    if (MouseOverSrc != string.Empty)
                    {
                        if ((Transition != string.Empty) & (System.IO.Path.GetExtension(Src).ToLower() != ".gif") & (System.IO.Path.GetExtension(MouseOverSrc).ToLower() != ".gif"))
                        {
                            sbImage.Append(" onmouseover=\"this.src='" + MouseOverSrc + "'; this.filters(0).Apply(); this.filters(0).Play()\"");
                            sbImage.Append(" onmouseout=\"this.src='" + Src + "'; this.filters(0).Apply(); this.filters(0).Play()\"");
                            sbImage.Append(" onload=\"this.filters(0).Apply(); this.filters(0).Play()\"");
                            sbImage.Append(" style=\"filter:progid:DXImageTransform.Microsoft." + Transition + "()\"");
                        }
                        else
                        {
                            sbImage.Append(" onmouseover=\"this.src='" + MouseOverSrc + "'\"");
                            sbImage.Append(" onmouseout=\"this.src='" + Src + "'\"");
                        }
                    }
                    else
                    {
                        if (RattleImage)
                        {
                            //RattleImage 
                            //Note, you need to add the javascript from C:\DNN331Dev\DesktopModules\bhattji_MultiMedias\JbRattleImage.js 
                            //<img src="jb150304.jpg" class="shakeimage" onMouseover="init(this);rattleimage()" onMouseout="stoprattle(this);top.focus()" onClick="top.focus()"> 
                            //<img src="jb150304.jpg" style="position: relative" onMouseover="init(this);rattleimage()" onMouseout="stoprattle(this);top.focus()" onClick="top.focus()"> 
                            sbImage.Append(" style=\"position:relative\"");
                            sbImage.Append(" onmouseover=\"jb_ri_init(this);jb_ri_rattleimage()\"");
                            sbImage.Append(" onmouseout=\"jb_ri_stoprattle(this);top.focus()\"");
                            sbImage.Append(" onclick=\"top.focus()\"");
                        }
                        //ElseIf (Transition <> String.Empty) And (System.IO.Path.GetExtension(Src).ToLower() <> ".gif") Then 
                        else if (Transition != string.Empty)
                        {
                            sbImage.Append(" onmouseover=\"this.filters(0).Apply(); this.filters(0).Play()\"");
                            sbImage.Append(" onmouseout=\"this.filters(0).Apply(); this.filters(0).Play()\"");
                            sbImage.Append(" onload=\"this.filters(0).Apply(); this.filters(0).Play()\"");
                            sbImage.Append(" style=\"filter:progid:DXImageTransform.Microsoft." + Transition + "()\"");
                        }
                    }

                    break;
                default:
                    //It is a Video and not an Image 
                    sbImage.Append(" dynsrc=\"" + Src + "\"");
                    if (!AutoStart) sbImage.Append(" start=\"mouseover\"");
                    break;
            }

            if (MediaWidth != string.Empty)
                sbImage.Append(" width=\"" + MediaWidth + "\"");
            if (MediaHeight != string.Empty)
                sbImage.Append(" height=\"" + MediaHeight + "\"");
            if (MediaAlign != string.Empty)
                sbImage.Append(" align=\"" + MediaAlign + "\"");

            sbImage.Append(" border=\"0\" />");

            return sbImage.ToString();

        } //GetImageString 

        #endregion

        #region Event Handlers

        protected override void RenderContents(HtmlTextWriter output)
        {
            //Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)' 
            try
            {
                if (((Player.ToLower() == "to") || (Player.ToLower() == "tot") || (Player.ToLower() == "textovertext")) && (BackGroundSrc == string.Empty) && (Src != string.Empty))
                {
                    BackGroundSrc = Src;
                    Src = string.Empty;
                }

                {
                    if ((Description != string.Empty) || (BackGroundSrc != string.Empty))
                    {
                        output.AddAttribute(HtmlTextWriterAttribute.Border, "0");
                        output.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "0");
                        output.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0");
                        output.RenderBeginTag(HtmlTextWriterTag.Table);
                        output.RenderBeginTag(HtmlTextWriterTag.Tr);

                        if (BackGroundSrc != string.Empty)
                        {
                            //.AddAttribute(HtmlTextWriterAttribute.Background, BackGroundSrc) 
                            if (MediaWidth != string.Empty)
                            {
                                output.AddAttribute(HtmlTextWriterAttribute.Width, MediaWidth);
                            }
                            if (MediaHeight != string.Empty)
                            {
                                output.AddAttribute(HtmlTextWriterAttribute.Height, MediaHeight);
                            }

                            //background-attachment: fixed; 
                            //background-image: url(/gmitra/Portals/_default/Skins/Formulae/images/bodyBak.jpg); 
                            //background-repeat: no-repeat; 
                            //background-position: right bottom; 

                            output.AddStyleAttribute(HtmlTextWriterStyle.BackgroundImage, BackGroundSrc);

                            output.AddStyleAttribute("background-repeat", "no-repeat");
                            output.AddStyleAttribute("background-position", "center middle");
                            output.AddStyleAttribute("background-attachment", "fixed");
                        }
                        output.AddAttribute(HtmlTextWriterAttribute.Align, "center");
                        output.RenderBeginTag(HtmlTextWriterTag.Td);
                    }
                    if (NavigateUrl != string.Empty)
                    {
                        output.AddAttribute(HtmlTextWriterAttribute.Href, NavigateUrl);
                    }
                    if (Target != string.Empty)
                    {
                        output.AddAttribute(HtmlTextWriterAttribute.Target, Target);
                    }
                    if (AltText != string.Empty)
                    {
                        output.AddAttribute(HtmlTextWriterAttribute.Title, AltText);
                    }
                    output.AddAttribute("onmouseover", "window.status=this.title; return true");


                    if (Player.ToLower() == "to")
                    {
                        if (TextOverCssClass != string.Empty)
                        {
                            output.AddAttribute(HtmlTextWriterAttribute.Class, TextOverCssClass);
                        }
                        else
                        {
                            output.AddAttribute(HtmlTextWriterAttribute.Class, "NormalBold");
                        }
                    }
                    else
                    {
                        if (CssClass != string.Empty)
                        {
                            output.AddAttribute(HtmlTextWriterAttribute.Class, CssClass);
                        }
                    }

                    output.RenderBeginTag(HtmlTextWriterTag.A);

                    if ((Player.ToLower() == "to") & (TextOverText != string.Empty))
                    {
                        //Render the TextOverText 
                        output.Write(TextOverText);
                    }
                    else
                    {
                        //Render the appropriate MultiMedia 
                        //RenderMultiMedia(writer) 
                        output.Write(ToString());
                    }

                    output.RenderEndTag();
                    //</A> 
                    if ((Description != string.Empty) | (BackGroundSrc != string.Empty))
                    {
                        if (Description != string.Empty)
                        {
                            output.RenderEndTag();
                            //</Td> 
                            output.RenderEndTag();
                            //</Tr> 
                            output.RenderBeginTag(HtmlTextWriterTag.Tr);
                            output.RenderBeginTag(HtmlTextWriterTag.Td);
                            if (NavigateUrl != string.Empty)
                            {
                                output.AddAttribute(HtmlTextWriterAttribute.Href, NavigateUrl);
                            }
                            if (Target != string.Empty)
                            {
                                output.AddAttribute(HtmlTextWriterAttribute.Target, Target);
                            }
                            if (AltText != string.Empty)
                            {
                                output.AddAttribute(HtmlTextWriterAttribute.Title, AltText);
                            }
                            output.AddAttribute("onmouseover", "window.status=this.title; return true");
                            if (CssClass != string.Empty)
                            {
                                output.AddAttribute(HtmlTextWriterAttribute.Class, CssClass);
                            }
                            else
                            {
                                output.AddAttribute(HtmlTextWriterAttribute.Class, "Normal");
                            }
                            output.RenderBeginTag(HtmlTextWriterTag.A);
                            output.Write(Description);
                            output.RenderEndTag();
                            //</A> 
                        }
                        output.RenderEndTag();
                        //</Td> 
                        output.RenderEndTag();
                        //</Tr> 
                        output.RenderEndTag();
                        //</Table> 
                    }
                }

                //Insert the Music 
                //If MusicUrl <> String.Empty Then 
                // Src = MusicUrl 
                // MMType = GetPlayer(Src) 
                // If ShowMusicControls Then 
                // 'Add the Line Break 
                // .Write("<br />") 

                // uiMode = "mini" 
                // 'MMWidth = "0" 
                // MMHeight = "32" 
                // Else 
                // uiMode = "invisible" 
                // MMWidth = "0" 
                // MMHeight = "0" 
                // End If 

                // RenderMultiMedia(writer) 
                //End If 

                //writer 
            }
            catch (Exception exc)
            {
                //MultiMedia failed to Render 
                output.Write(exc.ToString());
                //DotNetNuke.Services.Exceptions.Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion
    } //bhattjiMedia

    public class bhattjiObjectString : NameValueCollection //Inherits System.Web.UI.WebControls.WebControl, Inherits System.Collections.Hashtable 
    {

        #region Properties
        //Object Properties 
        //Must for the Object Tag 
        private string _ObjectAttrib = string.Empty;
        public string ObjectAttrib
        {
            get { return _ObjectAttrib; }
            set { _ObjectAttrib = value; }
        }

        //Embed Properties 
        //Must for the Embed Tag 
        private string _EmbedAttrib = string.Empty;
        public string EmbedAttrib
        {
            get { return _EmbedAttrib; }
            set { _EmbedAttrib = value; }
        }

        //Applet Properties 
        //Must for the Java Applet Tag 
        private string _AppletAttrib = string.Empty;
        public string AppletAttrib
        {
            get { return _AppletAttrib; }
            set { _AppletAttrib = value; }
        }


        //Common Properties 
        private string _Src = string.Empty;
        public string Src
        {
            get { return _Src; }
            set { _Src = value; }
        }

        private string _SrcParam = string.Empty;
        public string SrcParam
        {
            get { return _SrcParam; }
            set { _SrcParam = value; }
        }

        private string _SrcAttrib = string.Empty;
        public string SrcAttrib
        {
            get { return _SrcAttrib; }
            set { _SrcAttrib = value; }
        }

        #endregion

        //#region Constructors
        //public bhattjiObjectString(){}
        //public bhattjiObjectString(string appletAttrib)
        //{
        //    _AppletAttrib = appletAttrib;
        //}
        //public bhattjiObjectString(string embedAttrib, string objectAttrib)
        //{
        //    _EmbedAttrib = embedAttrib;
        //    _ObjectAttrib = objectAttrib;
        //}
        //#endregion

        #region Functions

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (AppletAttrib != string.Empty)
            {
                // it is a JavaApplet, not an Object 
                sb.Append("<applet " + AppletAttrib + ">");
                foreach (string Param in Keys)
                    sb.Append("<param name=\"" + Param + "\" value=\"" + this[Param] + "\" />");
                sb.Append("</applet>");
            }

            else
            {
                //it is an Object, not a JavaApplet 
                if (ObjectAttrib != string.Empty)
                {
                    //Object Tag needed 
                    sb.Append("<object " + ObjectAttrib + ">");
                    if (SrcParam != string.Empty)
                        sb.Append("<param name=\"" + SrcParam + "\" value=\"" + Src + "\" />");
                    else
                        sb.Append("<param name=\"src\" value=\"" + Src + "\" />");
                    foreach (string Param in Keys)
                        sb.Append("<param name=\"" + Param + "\" value=\"" + this[Param] + "\" />");
                }

                if (EmbedAttrib != string.Empty)
                {
                    //Embed Tag needed 
                    sb.Append("<embed " + EmbedAttrib);
                    if (SrcAttrib != string.Empty)
                        sb.Append(" " + SrcAttrib + "=\"" + Src + "\"");
                    else
                        sb.Append(" src=\"" + Src + "\"");
                    foreach (string Param in Keys)
                        sb.Append(" " + Param + "=\"" + this[Param] + "\"");
                    sb.Append(" />");
                }

                if (ObjectAttrib != string.Empty)
                    sb.Append("</object>"); //Object Tag needed
            }

            return sb.ToString();

        } //ToString() 

        #endregion

    } //bhattjiObjectString 
}