//Imports System 
//Imports System.Collections.Generic 
//Imports System.ComponentModel 
//Imports System.Text 
//Imports System.Web 
using System.Web.UI;
//Imports System.Web.UI.StateBag 
//Imports System.Web.UI.WebControls 

public class bhattjiMedia : System.Web.UI.WebControls.WebControl
{

    #region " Properties "

    private string _Player = string.Empty;
    public string Player
    {
        get
        {
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
                    switch (System.IO.Path.GetExtension(Src).ToLower())
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
        set { _Player = value; }
    }

    private bool _OnlyEmbedTag = true;
    public bool OnlyEmbedTag
    {
        get { return _OnlyEmbedTag; }
        set { _OnlyEmbedTag = value; }
    }

    private bool _ActiveContent = true;
    public bool ActiveContent
    {
        get { return _ActiveContent; }
        set { _ActiveContent = value; }
    }

    private bool _AutoStart = true;
    public bool AutoStart
    {
        get { return _AutoStart; }
        set { _AutoStart = value; }
    }

    private bool _AutoRewind = true;
    public bool AutoRewind
    {
        get { return _AutoRewind; }
        set { _AutoRewind = value; }
    }

    private string _Src = string.Empty;
    public string Src
    {
        get { return _Src; }
        set { _Src = value; }
    }

    private string _MusicSrc = string.Empty;
    public string MusicSrc
    {
        get { return _MusicSrc; }
        set { _MusicSrc = value; }
    }

    private bool _MusicControls = false;
    public bool MusicControls
    {
        get { return _MusicControls; }
        set { _MusicControls = value; }
    }

    private string _MouseOverSrc = string.Empty;
    public string MouseOverSrc
    {
        get { return _MouseOverSrc; }
        set { _MouseOverSrc = value; }
    }

    private string _BackgroundSrc = string.Empty;
    public string BackgroundSrc
    {
        get { return _BackgroundSrc; }
        set { _BackgroundSrc = value; }
    }

    private string _NavigateUrl = string.Empty;
    public string NavigateUrl
    {
        get { return _NavigateUrl; }
        set { _NavigateUrl = value; }
    }

    private string _Target = string.Empty;
    public string Target
    {
        get { return _Target; }
        set { _Target = value; }
    }

    private string _AltText = string.Empty;
    public string AltText
    {
        get { return _AltText; }
        set { _AltText = value; }
    }

    private string _TextOverText = string.Empty;
    public string TextOverText
    {
        get { return _TextOverText; }
        set { _TextOverText = value; }
    }

    private string _TextOverCssClass = string.Empty;
    public string TextOverCssClass
    {
        get { return _TextOverCssClass; }
        set { _TextOverCssClass = value; }
    }

    private string _Description = string.Empty;
    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }

    private string _MediaWidth = string.Empty;
    public string MediaWidth
    {
        get { return _MediaWidth; }
        set { _MediaWidth = value; }
    }

    private string _MediaHeight = string.Empty;
    public string MediaHeight
    {
        get { return _MediaHeight; }
        set { _MediaHeight = value; }
    }

    private string _MediaAlign = string.Empty;
    public string MediaAlign
    {
        get { return _MediaAlign; }
        set { _MediaAlign = value; }
    }

    //Image Effect Properties 
    private string _Transition = "Pixelate";
    public string Transition
    {
        get { return _Transition; }
        set { _Transition = value; }
    }

    private bool _RattleImage = true;
    public bool RattleImage
    {
        get { return _RattleImage; }
        set { _RattleImage = value; }
    }

    //FlashPlayer Properties 
    private string _FlashVars = string.Empty;
    public string FlashVars
    {
        get { return _FlashVars; }
        set { _FlashVars = value; }
    }

    private string _FlashQuality = "high";
    public string FlashQuality
    {
        get { return _FlashQuality; }
        set { _FlashQuality = value; }
    }

    private string _FlashWmode = "transparent";
    public string FlashWmode
    {
        get { return _FlashWmode; }
        set { _FlashWmode = value; }
    }

    private string _BgColor = "FFFFFF";
    public string BgColor
    {
        get
        {
            if (_BgColor.StartsWith("#"))
            {
                return _BgColor;
            }
            else
            {
                return "#" + _BgColor;
            }
        }
        set { _BgColor = value; }
    }

    //FlvPlayer Properties 
    private string _FlvComponent = "FLVPlayer_Progressive.swf";
    public string FlvComponent
    {
        get { return _FlvComponent; }
        set { _FlvComponent = value; }
    }

    private string _FlvSkin = "FlvSkin";
    public string FlvSkin
    {
        get { return _FlvSkin; }
        set { _FlvSkin = value; }
    }

    //Shockwave Properties 
    private string _swRemote = string.Empty;
    public string swRemote
    {
        get { return _swRemote; }
        set { _swRemote = value; }
    }

    private string _swStretchStyle = "none";
    public string swStretchStyle
    {
        get { return _swStretchStyle; }
        set { _swStretchStyle = value; }
    }

    //Authorware 
    private string _Palette = "background";
    public string Palette
    {
        get { return _Palette; }
        set { _Palette = value; }
    }

    private string _awWindow = "inPlace";
    public string awWindow
    {
        get { return _awWindow; }
        set { _awWindow = value; }
    }



    //Windows Media Player 
    private int _RepeatCount = 1;
    public int RepeatCount
    {
        get { return _RepeatCount; }
        set { _RepeatCount = value; }
    }

    private string _uiMode = "mini";
    public string uiMode
    {
        get { return _uiMode; }
        set { _uiMode = value; }
    }

    //Java Applet 
    private string _JavaCode = string.Empty;
    public string JavaCode
    {
        get { return _JavaCode; }
        set { _JavaCode = value; }
    }

    private string _Archive = string.Empty;
    public string Archive
    {
        get { return _Archive; }
        set { _Archive = value; }
    }

    //IFrame Properties 
    private string _Border = "no";
    public string Border
    {
        get { return _Border; }
        set { _Border = value; }
    }

    private string _Scrolling = "auto";
    public string Scrolling
    {
        get { return _Scrolling; }
        set { _Scrolling = value; }
    }

    #endregion

    #region " Functions "

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
        string ImageStr = "<img";

        switch (System.IO.Path.GetExtension(Src).ToLower())
        {
            case ".gif":
            case ".jpg":
            case ".jpeg":
            case ".jpe":
                //, ".png" 'It is an image and not a Video 
                ImageStr += " src=\"" + Src + "\"";
                if (MouseOverSrc != string.Empty)
                {
                    if ((Transition != string.Empty) & (System.IO.Path.GetExtension(Src).ToLower() != ".gif") & (System.IO.Path.GetExtension(MouseOverSrc).ToLower() != ".gif"))
                    {
                        ImageStr += " onmouseover=\"this.src='" + MouseOverSrc + "'; this.filters(0).Apply(); this.filters(0).Play()\"";
                        ImageStr += " onmouseout=\"this.src='" + Src + "'; this.filters(0).Apply(); this.filters(0).Play()\"";
                        ImageStr += " onload=\"this.filters(0).Apply(); this.filters(0).Play()\"";
                        ImageStr += " style=\"filter:progid:DXImageTransform.Microsoft." + Transition + "()\"";
                    }
                    else
                    {
                        ImageStr += " onmouseover=\"this.src='" + MouseOverSrc + "'\"";
                        ImageStr += " onmouseout=\"this.src='" + Src + "'\"";
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
                        ImageStr += " style=\"position:relative\"";
                        ImageStr += " onmouseover=\"jb_ri_init(this);jb_ri_rattleimage()\"";
                        ImageStr += " onmouseout=\"jb_ri_stoprattle(this);top.focus()\"";
                        ImageStr += " onclick=\"top.focus()\"";
                    }
                    //ElseIf (Transition <> String.Empty) And (System.IO.Path.GetExtension(Src).ToLower() <> ".gif") Then 
                    else if (Transition != string.Empty)
                    {
                        ImageStr += " onmouseover=\"this.filters(0).Apply(); this.filters(0).Play()\"";
                        ImageStr += " onmouseout=\"this.filters(0).Apply(); this.filters(0).Play()\"";
                        ImageStr += " onload=\"this.filters(0).Apply(); this.filters(0).Play()\"";
                        ImageStr += " style=\"filter:progid:DXImageTransform.Microsoft." + Transition + "()\"";
                    }
                }

                break;
            default:
                //It is a Video and not an Image 
                ImageStr += " dynsrc=\"" + Src + "\"";
                if (!AutoStart)
                {
                    ImageStr += " start=\"mouseover\"";
                }

                break;
        }

        if (MediaWidth != string.Empty)
        {
            ImageStr += " width=\"" + MediaWidth + "\"";
        }
        if (MediaHeight != string.Empty)
        {
            ImageStr += " height=\"" + MediaHeight + "\"";
        }
        if (MediaAlign != string.Empty)
        {
            ImageStr += " align=\"" + MediaAlign + "\"";
        }

        ImageStr += " border=\"0\" />";

        return ImageStr;

    }
    //GetImageString 

    #endregion

    #region " Event Handlers "

    protected override void RenderContents(HtmlTextWriter output)
    {
        //Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)' 
        try
        {
            if (((Player.ToLower() == "to") | (Player.ToLower() == "tot") | (Player.ToLower() == "textovertext")) & (BackgroundSrc == string.Empty) & (Src != string.Empty))
            {
                BackgroundSrc = Src;
                Src = string.Empty;
            }

            {
                if ((Description != string.Empty) | (BackgroundSrc != string.Empty))
                {
                    output.AddAttribute(HtmlTextWriterAttribute.Border, "0");
                    output.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "0");
                    output.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0");
                    output.RenderBeginTag(HtmlTextWriterTag.Table);
                    output.RenderBeginTag(HtmlTextWriterTag.Tr);

                    if (BackgroundSrc != string.Empty)
                    {
                        //.AddAttribute(HtmlTextWriterAttribute.Background, BackgroundSrc) 
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

                        output.AddStyleAttribute(HtmlTextWriterStyle.BackgroundImage, BackgroundSrc);

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
                if ((Description != string.Empty) | (BackgroundSrc != string.Empty))
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
        catch (System.Exception exc)
        {
            //MultiMedia failed to Render 
            DotNetNuke.Services.Exceptions.Exceptions.ProcessModuleLoadException(this, exc);
        }
    }

    #endregion

}
//bhattjiMedia 


public class bhattjiObjectString : System.Collections.Specialized.NameValueCollection
{
    //Inherits System.Web.UI.WebControls.WebControl 
    //Inherits System.Collections.Hashtable 

    #region " Properties "
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

    #region " Functions "

    public override string ToString()
    {
        string _ToString = string.Empty;

        if (AppletAttrib != string.Empty)
        {
            // it is a JavaApplet, not an Object 
            _ToString += "<applet " + AppletAttrib + ">";
            foreach (string Param in Keys)
            {
                _ToString += "<param name=\"" + Param + "\" value=\"" + this[Param] + "\" />";
            }
            _ToString += "</applet>";
        }

        else
        {
            //it is an Object, not a JavaApplet 
            if (ObjectAttrib != string.Empty)
            {
                //Object Tag needed 
                _ToString += "<object " + ObjectAttrib + ">";
                if (SrcParam != string.Empty)
                {
                    _ToString += "<param name=\"" + SrcParam + "\" value=\"" + Src + "\" />";
                }
                else
                {
                    _ToString += "<param name=\"src\" value=\"" + Src + "\" />";
                }
                foreach (string Param in Keys)
                {
                    _ToString += "<param name=\"" + Param + "\" value=\"" + this[Param] + "\" />";
                }
            }

            if (EmbedAttrib != string.Empty)
            {
                //Embed Tag needed 
                _ToString += "<embed " + EmbedAttrib;
                if (SrcAttrib != string.Empty)
                {
                    _ToString += " " + SrcAttrib + "=\"" + Src + "\"";
                }
                else
                {
                    _ToString += " src=\"" + Src + "\"";
                }
                foreach (string Param in Keys)
                {
                    _ToString += " " + Param + "=\"" + this[Param] + "\"";
                }
                _ToString += " />";
            }

            if (ObjectAttrib != string.Empty)
            {
                //Object Tag needed 
                _ToString += "</object>";
            }
        }

        return _ToString;

    }
    //ToString() 

    #endregion

}
//bhattjiObjectString 