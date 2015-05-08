'
' DotNetNuke -  http://www.dotnetnuke.com
' Copyright (c) 2002-2005
' by Jaydeep Bhatt ( sales@bhattji.com ) of Vision Consultants. ( http://www.bhattji.com )
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify, merge, PublishDate, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'

#Region " Namespaces "
'Imports System
'Imports System.Configuration
'Imports System.Data
Imports System.Web.UI.WebControls
Imports DotNetNuke
#End Region

Namespace bhattji.Modules.SalesReps

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' The Options Class provides the TabbedPages Business Object
    ''' </summary>
    '''
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[bhattji]	9/20/2004	Moved TabbedPages to a separate Project
    ''' </history>
    ''' -----------------------------------------------------------------------------
    ''' 

    Public Class OptionsInfo
        Inherits Hashtable
        'Inherits System.Collections.Specialized.NameValueCollection

#Region " Private Members "
        'Private ModSets As New Hashtable
#End Region

#Region " Properties "

        Private _ModuleID As Integer
        Public Property ModuleID() As Integer
            Get
                Return _ModuleID
            End Get
            Set(ByVal Value As Integer)
                _ModuleID = Value
            End Set
        End Property


        'Common Properties

        Public Property GetItems() As Integer
            Get
                Return GetInteger("GetItem", 2)
            End Get
            Set(ByVal Value As Integer)
                SetString("GetItem", Value.ToString)
            End Set
        End Property

        Public Property OnlyHostCanEdit() As Boolean
            Get
                Return GetBoolean("OnlyHostCanEdit", False)
            End Get
            Set(ByVal Value As Boolean)
                SetString("OnlyHostCanEdit", Value.ToString)
            End Set
        End Property

        Public Property ViewControl() As String
            Get
                Return GetString("ViewControl", "List")
            End Get
            Set(ByVal Value As String)
                SetString("ViewControl", Value)
            End Set
        End Property

        Public Property AddDescription() As Boolean
            Get
                Return GetBoolean("AddDescription", False)
            End Get
            Set(ByVal Value As Boolean)
                SetString("AddDescription", Value.ToString)
            End Set
        End Property

        Public Property BackColor() As String
            Get
                Return GetString("BackColor", "#FFFFFF")
            End Get
            Set(ByVal Value As String)
                SetString("BackColor", Value)
            End Set
        End Property

        Public Property AltColor() As String
            Get
                Return GetString("AltColor", "#EBF5D4")
            End Get
            Set(ByVal Value As String)
                SetString("AltColor", Value)
            End Set
        End Property

        Public Property HeaderBackColor() As String
            Get
                Return GetString("HeaderBackColor", "#3578AF")
            End Get
            Set(ByVal Value As String)
                SetString("HeaderBackColor", Value)
            End Set
        End Property

        Public Property PagerBackColor() As String
            Get
                Return GetString("PagerBackColor", "#3578AF")
            End Get
            Set(ByVal Value As String)
                SetString("PagerBackColor", Value)
            End Set
        End Property

        Public Property TabCss() As String
            Get
                Return GetString("TabCss", "tab.luna.css")
            End Get
            Set(ByVal Value As String)
                SetString("TabCss", Value)
            End Set
        End Property

        Public Property PagerSize() As Integer
            Get
                Return GetInteger("PagerSize", 10)
            End Get
            Set(ByVal Value As Integer)
                SetString("PagerSize", Value.ToString)
            End Set
        End Property

        Public Property NoOfPages() As Integer
            Get
                Return GetInteger("NoOfPages", 10)
            End Get
            Set(ByVal Value As Integer)
                SetString("NoOfPages", Value.ToString)
            End Set
        End Property

        Public ReadOnly Property NoOfItems() As Integer
            Get
                Try
                    Return CType(IIf(PagerSize > 0, PagerSize, 10), Integer) * CType(IIf(NoOfPages > 0, NoOfPages, 10), Integer)
                Catch
                    Return 100
                End Try
            End Get
        End Property

        Public Property DeleteFromGrid() As Boolean
            Get
                Return GetBoolean("DeleteFromGrid", False)
            End Get
            Set(ByVal Value As Boolean)
                SetString("DeleteFromGrid", Value.ToString)
            End Set
        End Property

        'SalesRep Properties


        'Scroller Properties
        'Private _ViewOption As String = "V"
        Public Property ViewOption() As String
            Get
                Return GetString("ViewOption", "V")
            End Get
            Set(ByVal Value As String)
                SetString("ViewOption", Value)
            End Set
        End Property

        Public Property AddDate() As String
            Get
                Return GetString("AddDate", "N")
            End Get
            Set(ByVal Value As String)
                SetString("AddDate", Value)
            End Set
        End Property

        'Private _ImagePosition As String = String.Empty
        Public Property ImagePosition() As String
            Get
                Return GetString("ImagePosition", "ZR")
            End Get
            Set(ByVal Value As String)
                SetString("ImagePosition", Value.ToString)
            End Set
        End Property

        'Private _DynamicThumb As Boolean = True
        Public Property DynamicThumb() As Boolean
            Get
                Return GetBoolean("DynamicThumb", True)
            End Get
            Set(ByVal Value As Boolean)
                SetString("DynamicThumb", Value.ToString)
            End Set
        End Property

        Public Property UpdateRedirection() As String
            Get
                Return GetString("UpdateRedirection", "Listing")
            End Get
            Set(ByVal Value As String)
                SetString("UpdateRedirection", Value)
            End Set
        End Property

        'Private _ScrollColumns As String = "0"
        Public Property ScrollColumns() As Integer
            Get
                Return GetInteger("ScrollColumns", 0)
            End Get
            Set(ByVal Value As Integer)
                SetString("ScrollColumns", Value.ToString)
            End Set
        End Property

        'Private _TextMode As String = "False"
        Public Property TextMode() As Boolean
            Get
                Return GetBoolean("TextMode", False)
            End Get
            Set(ByVal Value As Boolean)
                SetString("TextMode", Value.ToString)
            End Set
        End Property

        'Private _DisplayInfo As String = "False"
        Public Property DisplayInfo() As Boolean
            Get
                Return GetBoolean("DisplayInfo", False)
            End Get
            Set(ByVal Value As Boolean)
                SetString("DisplayInfo", Value.ToString)
            End Set
        End Property

        'Private _ThumbWidth As String
        Public Property ThumbWidth() As String
            Get
                Return GetString("ThumbWidth", "")
            End Get
            Set(ByVal Value As String)
                SetString("ThumbWidth", Value)
            End Set
        End Property

        'Private _ThumbHeight As String
        Public Property ThumbHeight() As String
            Get
                Return GetString("ThumbHeight", "")
            End Get
            Set(ByVal Value As String)
                SetString("ThumbHeight", Value)
            End Set
        End Property

        'Private _ThumbColumns As Integer = 5
        Public Property ThumbColumns() As Integer
            Get
                Return GetInteger("ThumbColumns", 5)
            End Get
            Set(ByVal Value As Integer)
                SetString("ThumbColumns", Value.ToString)
            End Set
        End Property

        'Private _HideTextLink As Boolean = False
        Public Property HideTextLink() As Boolean
            Get
                Return GetBoolean("HideTextLink", False)
            End Get
            Set(ByVal Value As Boolean)
                SetString("HideTextLink", Value.ToString)
            End Set
        End Property

        'Private _InfoCssClass As String = String.Empty
        Public Property InfoCssClass() As String
            Get
                Return GetString("InfoCssClass", "")
            End Get
            Set(ByVal Value As String)
                SetString("InfoCssClass", Value)
            End Set
        End Property




        'Scroller Properties
        'Private _ScrollBehavior As String = "OFF"
        Public Property ScrollBehavior() As String
            Get
                Return GetString("ScrollBehavior", "OFF")
            End Get
            Set(ByVal Value As String)
                SetString("ScrollBehavior", Value)
            End Set
        End Property

        Public ReadOnly Property ScrollON() As Boolean
            Get
                Return ScrollBehavior.ToUpper = "SCROLL" Or ScrollBehavior.ToUpper = "SLIDE" Or ScrollBehavior.ToUpper = "ALTERNATE"
            End Get
        End Property

        Public ReadOnly Property MarqueeStart() As String
            Get
                If ScrollON Then
                    Dim strMarquee As String = "<marquee behavior=""" & ScrollBehavior & """"
                    If ScrollDirection <> String.Empty Then
                        strMarquee &= " direction=""" & ScrollDirection & """"
                    End If
                    If ScrollAmount <> String.Empty Then
                        strMarquee &= " scrollamount=""" & ScrollAmount & """"
                    End If
                    If ScrollDelay <> String.Empty Then
                        strMarquee &= " scrolldelay=""" & ScrollDelay & """"
                    End If
                    If ScrollWidth <> String.Empty Then
                        strMarquee &= " width=""" & ScrollWidth & """"
                    End If
                    If ScrollHeight <> String.Empty Then
                        strMarquee &= " height=""" & ScrollHeight & """"
                    End If
                    strMarquee &= " class=""Normal"" onmouseover=""this.stop()"" onmouseout=""this.start()"">"

                    Return strMarquee
                Else
                    Return String.Empty
                End If
            End Get
        End Property

        Public ReadOnly Property MarqueeEnd() As String
            Get
                If ScrollON Then
                    Return "</marquee>"
                Else
                    Return String.Empty
                End If
            End Get
        End Property

        Public Property ScrollDirection() As String
            Get
                Return GetString("ScrollDirection", "")
            End Get
            Set(ByVal Value As String)
                SetString("ScrollDirection", Value)
            End Set
        End Property

        Public Property ScrollAmount() As String
            Get
                Return GetString("ScrollAmount", "")
            End Get
            Set(ByVal Value As String)
                SetString("ScrollAmount", Value)
            End Set
        End Property

        Public Property ScrollDelay() As String
            Get
                Return GetString("ScrollDelay", "")
            End Get
            Set(ByVal Value As String)
                SetString("ScrollDelay", Value)
            End Set
        End Property

        Public Property ScrollWidth() As String
            Get
                Return GetString("ScrollWidth", "")
            End Get
            Set(ByVal Value As String)
                SetString("ScrollWidth", Value)
            End Set
        End Property

        Public Property ScrollHeight() As String
            Get
                Return GetString("ScrollHeight", "")
            End Get
            Set(ByVal Value As String)
                SetString("ScrollHeight", Value)
            End Set
        End Property



        'Private _CellPadding As String = "0"
        Public Property CellPadding() As String
            Get
                Return GetString("CellPadding", "0")
            End Get
            Set(ByVal Value As String)
                SetString("CellPadding", Value)
            End Set
        End Property

        'Private _CellSpacing As String = "5"
        Public Property CellSpacing() As String
            Get
                Return GetString("CellSpacing", "5")
            End Get
            Set(ByVal Value As String)
                SetString("CellSpacing", Value)
            End Set
        End Property

        'Private _RattleImage As String = "True"
        Public Property RattleImage() As Boolean
            Get
                Try
                    Return GetBoolean("RattleImage", True)
                Catch
                    Return True
                End Try
            End Get
            Set(ByVal Value As Boolean)
                SetString("RattleImage", Value.ToString)
            End Set
        End Property



        'SlideShow Properties
        'Private _SSWidth As String
        Public Property SSWidth() As String
            Get
                Return GetString("SSWidth", "")
            End Get
            Set(ByVal Value As String)
                SetString("SSWidth", Value)
            End Set
        End Property

        'Private _SSHeight As String
        Public Property SSHeight() As String
            Get
                Return GetString("SSHeight", "")
            End Get
            Set(ByVal Value As String)
                SetString("SSHeight", Value)
            End Set
        End Property

        'Private _Delay As String = "3000"
        Public Property Delay() As String
            Get
                Return GetString("Delay", "3000")
            End Get
            Set(ByVal Value As String)
                SetString("Delay", Value)
            End Set
        End Property

        'Private _Transition As String = "Pixelate"
        Public Property Transition() As String
            Get
                Return GetString("Transition", "Pixelate")
            End Get
            Set(ByVal Value As String)
                SetString("Transition", Value)
            End Set
        End Property

        'Private _Thumbnail As String = "False"
        Public Property Thumbnail() As Boolean
            Get
                Return GetBoolean("Thumbnail", False)
            End Get
            Set(ByVal Value As Boolean)
                SetString("Thumbnail", Value.ToString)
            End Set
        End Property

        'Private _ThumbnailWidth As String
        Public Property ThumbnailWidth() As String
            Get
                Return GetString("ThumbnailWidth", "")
            End Get
            Set(ByVal Value As String)
                SetString("ThumbnailWidth", Value)
            End Set
        End Property

        'Private _Resizing As String = "B"
        Public Property Resizing() As String
            Get
                Return GetString("Resizing", "B")
            End Get
            Set(ByVal Value As String)
                SetString("Resizing", Value)
            End Set
        End Property


        'FlashSlideShow Setting
        'Private _OnlyEmbedTag As String = "True"
        Public Property OnlyEmbedTag() As Boolean
            Get
                Return GetBoolean("OnlyEmbedTag", True)
            End Get
            Set(ByVal Value As Boolean)
                SetString("OnlyEmbedTag", Value.ToString)
            End Set
        End Property

        'Private _ShowControls As String = "False"
        Public Property ShowControls() As Boolean
            Get
                Return GetBoolean("ShowControls", False)
            End Get
            Set(ByVal Value As Boolean)
                SetString("ShowControls", Value.ToString)
            End Set
        End Property

        'Private _SSTitle As String
        Public Property SSTitle() As String
            Get
                Return GetString("SSTitle", "")
            End Get
            Set(ByVal Value As String)
                SetString("SSTitle", Value)
            End Set
        End Property

        'Private _CaptionFont As String = "Verdana"
        Public Property CaptionFont() As String
            Get
                Return GetString("CaptionFont", "Verdana")
            End Get
            Set(ByVal Value As String)
                SetString("CaptionFont", Value)
            End Set
        End Property

        'Private _CaptionSize As String = "10"
        Public Property CaptionSize() As Integer
            Get
                Return GetInteger("CaptionSize", 10)
            End Get
            Set(ByVal Value As Integer)
                SetString("CaptionSize", Value.ToString)
            End Set
        End Property

        'Private _BgColor As String
        Public Property BgColor() As String
            Get
                Return GetString("BgColor", "")
            End Get
            Set(ByVal Value As String)
                SetString("BgColor", Value)
            End Set
        End Property

        'Private _FSSTransition As String = "Random"
        Public Property FSSTransition() As String
            Get
                Return GetString("FSSTransition", "Random")
            End Get
            Set(ByVal Value As String)
                SetString("FSSTransition", Value)
            End Set
        End Property


        'ActivePhotoShow Setting
        'Private _Repeat As String = "True"
        Public Property Repeat() As Boolean
            Get
                Return GetBoolean("Repeat", True)
            End Get
            Set(ByVal Value As Boolean)
                SetString("Repeat", Value.ToString)
            End Set
        End Property

        'Private _Streaming As String = "False"
        Public Property Streaming() As Boolean
            Get
                Return GetBoolean("Streaming", False)
            End Get
            Set(ByVal Value As Boolean)
                SetString("Streaming", Value.ToString)
            End Set
        End Property

        'Private _EffectTime As String = "3"
        Public Property EffectTime() As Double
            Get
                Return GetDouble("EffectTime", 3)
            End Get
            Set(ByVal Value As Double)
                SetString("EffectTime", Value.ToString)
            End Set
        End Property

        'Private _TransitionTime As String = "1"
        Public Property TransitionTime() As Integer
            Get
                Return GetInteger("TransitionTime", 1)
            End Get
            Set(ByVal Value As Integer)
                SetString("TransitionTime", Value.ToString)
            End Set
        End Property

        'Private _Volume As String = "50"
        Public Property Volume() As Integer
            Get
                Return GetInteger("Volume", 50)
            End Get
            Set(ByVal Value As Integer)
                SetString("Volume", Value.ToString)
            End Set
        End Property

        'Private _MusicUrl As String = String.Empty
        Public Property MusicUrl() As String
            Get
                Return GetString("MusicUrl", "")
            End Get
            Set(ByVal Value As String)
                SetString("MusicUrl", Value)
            End Set
        End Property

        'Private _ShowMusicControls As String = "False"
        Public Property ShowMusicControls() As Boolean
            Get
                Return GetBoolean("ShowMusicControls", False)
            End Get
            Set(ByVal Value As Boolean)
                SetString("ShowMusicControls", Value.ToString)
            End Set
        End Property


        'Private _ProgressColor As String = "000066"
        Public Property ProgressColor() As String
            Get
                Return GetString("ProgressColor", "000066")
            End Get
            Set(ByVal Value As String)
                SetString("ProgressColor", Value)
            End Set
        End Property

        'FlashPhotoAlbum Properties
        'Private _TextColor As String = "00FF00"
        Public Property TextColor() As String
            Get
                Return GetString("TextColor", "00FF00")
            End Get
            Set(ByVal Value As String)
                SetString("TextColor", Value)
            End Set
        End Property

        'Private _ThumbFolder As String = "none"
        Public Property ThumbFolder() As String
            Get
                Return GetString("ThumbFolder", "Dynamic")
            End Get
            Set(ByVal Value As String)
                SetString("ThumbFolder", Value)
            End Set
        End Property

        'Private _ThumbnailPosition As String = "top"
        Public Property ThumbnailPosition() As String
            Get
                Return GetString("ThumbnailPosition", "right")
            End Get
            Set(ByVal Value As String)
                SetString("ThumbnailPosition", Value)
            End Set
        End Property

        'Private _ThumbnailRows As String = "1"
        Public Property ThumbnailRows() As Integer
            Get
                Return GetInteger("ThumbnailRows", 5)
            End Get
            Set(ByVal Value As Integer)
                SetString("ThumbnailRows", Value.ToString)
            End Set
        End Property

        'Private _ThumbnailColumns As String = "6"
        Public Property ThumbnailColumns() As Integer
            Get
                Return GetInteger("ThumbnailColumns", 2)
            End Get
            Set(ByVal Value As Integer)
                SetString("ThumbnailColumns", Value.ToString)
            End Set
        End Property


        'NewsTicker Properties
        'Private _NTWidth As String = "160"
        Public Property NTWidth() As String
            Get
                Return GetString("NTWidth", "160")
            End Get
            Set(ByVal Value As String)
                SetString("NTWidth", Value)
            End Set
        End Property

        'Private _NTHeight As String = "90"
        Public Property NTHeight() As String
            Get
                Return GetString("NTHeight", "90")
            End Get
            Set(ByVal Value As String)
                SetString("NTHeight", Value)
            End Set
        End Property

        'Private _Pause As String
        Public Property Pause() As String
            Get
                Return GetString("Pause", "")
            End Get
            Set(ByVal Value As String)
                SetString("Pause", Value)
            End Set
        End Property

        'Private _Speed As String
        Public Property Speed() As String
            Get
                Return GetString("Speed", "")
            End Get
            Set(ByVal Value As String)
                SetString("Speed", Value)
            End Set
        End Property


        'JukeBox Properties
        'Private _InitialJuke As String = "-1"
        Public Property InitialJuke() As Integer
            Get
                Return GetInteger("InitialJuke", -1)
            End Get
            Set(ByVal Value As Integer)
                SetString("InitialJuke", Value.ToString)
            End Set
        End Property

        ''Private _RunFirstSelection As String = "True"
        'Public Property RunFirstSelection() As Boolean
        '    Get
        '        Return GetBoolean("RunFirstSelection)
        '    End Get
        '    Set(ByVal Value As Boolean)
        '        _RunFirstSelection SetString("", Value.ToString)
        '    End Set
        'End Property

        'Private _AutoStart As String = "True"
        Public Property AutoStart() As Boolean
            Get
                Return GetBoolean("AutoStart", True)
            End Get
            Set(ByVal Value As Boolean)
                SetString("AutoStart", Value.ToString)
            End Set
        End Property

        'Private _AutoRewind As String = "True"
        Public Property AutoRewind() As Boolean
            Get
                Return GetBoolean("AutoRewind", True)
            End Get
            Set(ByVal Value As Boolean)
                SetString("AutoRewind", Value.ToString)
            End Set
        End Property

        ''Private _HideJukeSelector As String = "False"
        'Public Property HideJukeSelector() As Boolean
        '    Get
        '        Return GetBoolean("HideJukeSelector)
        '    End Get
        '    Set(ByVal Value As Boolean)
        '        _HideJukeSelector SetString("", Value.ToString)
        '    End Set
        'End Property

        'Private _JukeSelector As String = "1"
        Public Property JukeSelector() As Integer
            Get
                Return GetInteger("JukeSelector", 1)
            End Get
            Set(ByVal Value As Integer)
                SetString("JukeSelector", Value.ToString)
            End Set
        End Property

        'Private _ReferIt As String = String.Empty
        Public Property ReferIt() As String
            Get
                Return GetString("ReferIt", "")
            End Get
            Set(ByVal Value As String)
                SetString("ReferIt", Value)
            End Set
        End Property

        'Private _AutoRefresh As String = "0"
        Public Property AutoRefresh() As Integer
            Get
                Return GetInteger("AutoRefresh", 0)
            End Get
            Set(ByVal Value As Integer)
                SetString("AutoRefresh", Value.ToString)
            End Set
        End Property

        'Private _JukePager As String = "10"
        Public Property JukePager() As Integer
            Get
                Return GetInteger("JukePager", 10)
            End Get
            Set(ByVal Value As Integer)
                SetString("JukePager", Value.ToString)
            End Set
        End Property

        'Private _ShowJukePanel As String = "False"
        Public Property ShowJukePanel() As Boolean
            Get
                Return GetBoolean("ShowJukePanel", False)
            End Get
            Set(ByVal Value As Boolean)
                SetString("ShowJukePanel", Value.ToString)
            End Set
        End Property

        'Private _ShowReferJuke As String = "True"
        Public Property ShowReferJuke() As Boolean
            Get
                Return GetBoolean("ShowReferJuke", True)
            End Get
            Set(ByVal Value As Boolean)
                SetString("ShowReferJuke", Value.ToString)
            End Set
        End Property

        'Private _ShowAddToFavourite As String = "True"
        Public Property ShowAddToFavourite() As Boolean
            Get
                Return GetBoolean("ShowAddToFavourite", True)
            End Get
            Set(ByVal Value As Boolean)
                SetString("ShowAddToFavourite", Value.ToString)
            End Set
        End Property

        'Private _ShowDownload As String = "False"
        Public Property ShowDownload() As Boolean
            Get
                Return GetBoolean("ShowDownload", False)
            End Get
            Set(ByVal Value As Boolean)
                SetString("ShowDownload", Value.ToString)
            End Set
        End Property

        'Private _ShowMusicDownload As String = "False"
        Public Property ShowMusicDownload() As Boolean
            Get
                Return GetBoolean("ShowMusicDownload", False)
            End Get
            Set(ByVal Value As Boolean)
                SetString("ShowMusicDownload", Value.ToString)
            End Set
        End Property

        'Private _ShowRatings As String = "True"
        Public Property ShowRatings() As Boolean
            Get
                Return GetBoolean("ShowRatings", True)
            End Get
            Set(ByVal Value As Boolean)
                SetString("ShowRatings", Value.ToString)
            End Set
        End Property

        'Private _ShowSlotAvailability As String = "False"
        Public Property ShowSlotAvailability() As Boolean
            Get
                Return GetBoolean("ShowSlotAvailability", False)
            End Get
            Set(ByVal Value As Boolean)
                SetString("ShowSlotAvailability", Value.ToString)
            End Set
        End Property

        'Shockwave
        'Private _swSaveEnabled As String = "True"
        Public Property swSaveEnabled() As Boolean
            Get
                Return GetBoolean("swSaveEnabled", True)
            End Get
            Set(ByVal Value As Boolean)
                SetString("swSaveEnabled", Value.ToString)
            End Set
        End Property

        'Private _swVolume As String = "True"
        Public Property swVolume() As Boolean
            Get
                Return GetBoolean("swVolume", True)
            End Get
            Set(ByVal Value As Boolean)
                SetString("swVolume", Value.ToString)
            End Set
        End Property

        'Private _swRestart As String = "True"
        Public Property swRestart() As Boolean
            Get
                Return GetBoolean("swRestart", True)
            End Get
            Set(ByVal Value As Boolean)
                SetString("swRestart", Value.ToString)
            End Set
        End Property

        'Private _swPausePlay As String = "True"
        Public Property swPausePlay() As Boolean
            Get
                Return GetBoolean("swPausePlay", True)
            End Get
            Set(ByVal Value As Boolean)
                SetString("swPausePlay", Value.ToString)
            End Set
        End Property

        'Private _swFastForward As String = "True"
        Public Property swFastForward() As Boolean
            Get
                Return GetBoolean("swFastForward", True)
            End Get
            Set(ByVal Value As Boolean)
                SetString("swFastForward", Value.ToString)
            End Set
        End Property

        'Private _swContextMenu As String = "True"
        Public Property swContextMenu() As Boolean
            Get
                Return GetBoolean("swContextMenu", True)
            End Get
            Set(ByVal Value As Boolean)
                SetString("swContextMenu", Value.ToString)
            End Set
        End Property
        'Shockware
        'Private _swRemote As String = String.Empty
        Property swRemote() As String
            Get
                Return GetString("swRemote", "")
            End Get
            Set(ByVal Value As String)
                SetString("swRemote", Value)
            End Set
        End Property

        'Private _swStretchStyle As String = "None"
        Property swStretchStyle() As String
            Get
                Return GetString("swStretchStyle", "None")
            End Get
            Set(ByVal Value As String)
                SetString("swStretchStyle", Value)
            End Set
        End Property
        'FLV Player
        'Private _FlvSkinUrl As String = String.Empty
        Property FlvSkinUrl() As String
            Get
                Return GetString("FlvSkinUrl", "")
            End Get
            Set(ByVal Value As String)
                SetString("FlvSkinUrl", Value)
            End Set
        End Property
        'Authorware
        'Private _Palette As String = "background"
        Property Palette() As String
            Get
                Return GetString("Palette", "background")
            End Get
            Set(ByVal Value As String)
                SetString("Palette", Value)
            End Set
        End Property

        'Private _awWindow As String = "inPlace"
        Property awWindow() As String
            Get
                Return GetString("awWindow", "inPlace")
            End Get
            Set(ByVal Value As String)
                SetString("awWindow", Value)
            End Set
        End Property

        'Private _RatingsInNewWindow As String = "False"
        Public Property RatingsInNewWindow() As Boolean
            Get
                Return GetBoolean("RatingsInNewWindow", False)
            End Get
            Set(ByVal Value As Boolean)
                SetString("RatingsInNewWindow", Value.ToString)
            End Set
        End Property


        'BulkImport Properties
        'Private _DataFolder As String = String.Empty
        Public Property DataFolder() As String
            Get
                Return GetString("DataFolder", "")
            End Get
            Set(ByVal Value As String)
                SetString("DataFolder", Value)
            End Set
        End Property


        'PayPal Properties
        'Private _PayPalId As String = "bhattji@bhattji.com"
        Property PayPalId() As String
            Get
                Return GetString("PayPalId", "bhattji@bhattji.com")
            End Get
            Set(ByVal Value As String)
                SetString("PayPalId", Value)
            End Set
        End Property

        'Private _SlotAdPrice As String = "30"
        Property SlotAdPrice() As Decimal
            Get
                Return GetDecimal("SlotAdPrice", 30)
            End Get
            Set(ByVal Value As Decimal)
                SetString("SlotAdPrice", Value.ToString)
            End Set
        End Property




        'Audit Control
        Property UpdatedByUserId() As Integer
            Get
                Return GetInteger("UpdatedByUserId", 1)
            End Get
            Set(ByVal Value As Integer)
                SetString("UpdatedByUserId", Value.ToString)
            End Set
        End Property

        Property UpdatedByUser() As String
            Get
                Return GetString("UpdatedByUser", "System Account")
            End Get
            Set(ByVal Value As String)
                SetString("UpdatedByUser", Value)
            End Set
        End Property

        Property UpdatedDate() As Date
            Get
                Return GetDate("UpdatedDate", Now)
            End Get
            Set(ByVal Value As Date)
                'SetString("UpdatedDate", Now.ToString)
                SetString("UpdatedDate", Value.ToString)
            End Set
        End Property
#End Region

#Region " Private Methods "
        Private Sub SetString(ByVal OptionKey As String, ByVal OptionValue As String)
            If Me.Contains(OptionKey) Then
                Me(OptionKey) = OptionValue
            Else
                Me.Add(OptionKey, OptionValue)
            End If
        End Sub

        Private Function GetString(ByVal OptionKey As String, ByVal FailSafe As String) As String
            Try
                If Me.Contains(OptionKey) Then
                    Return CType(Me(OptionKey), String)
                Else
                    Return FailSafe
                End If
            Catch
                Return FailSafe
            End Try
        End Function

        Private Function GetInteger(ByVal OptionKey As String, ByVal FailSafe As Integer) As Integer
            Try
                If Me.Contains(OptionKey) Then
                    Return CType(Me(OptionKey), Integer)
                Else
                    Return FailSafe
                End If
            Catch
                Return FailSafe
            End Try
        End Function

        Private Function GetDouble(ByVal OptionKey As String, ByVal FailSafe As Double) As Double
            Try
                If Me.Contains(OptionKey) Then
                    Return CType(Me(OptionKey), Double)
                Else
                    Return FailSafe
                End If
            Catch
                Return FailSafe
            End Try
        End Function

        Private Function GetDecimal(ByVal OptionKey As String, ByVal FailSafe As Decimal) As Decimal
            Try
                If Me.Contains(OptionKey) Then
                    Return CType(Me(OptionKey), Decimal)
                Else
                    Return FailSafe
                End If
            Catch
                Return FailSafe
            End Try
        End Function

        Private Function GetBoolean(ByVal OptionKey As String, ByVal FailSafe As Boolean) As Boolean
            Try
                If Me.Contains(OptionKey) Then
                    Return CType(Me(OptionKey), Boolean)
                Else
                    Return FailSafe
                End If
            Catch
                Return FailSafe
            End Try
        End Function

        Private Function GetDate(ByVal OptionKey As String, ByVal FailSafe As Date) As Date
            Try
                If Me.Contains(OptionKey) Then
                    Return CType(Me(OptionKey), Date)
                Else
                    Return FailSafe
                End If
            Catch
                Return FailSafe
            End Try
        End Function

        'Public Function Popup(ByVal Title As String, ByVal Messege As String, Optional ByVal FullMessege As String = "", Optional ByVal X As Integer = 10, Optional ByVal Y As Integer = 10) As EeekSoft.Web.PopupWin
        '    Dim popMsg As New EeekSoft.Web.PopupWin
        '    With popMsg
        '        .Title = Title
        '        .Message = Messege
        '        If FullMessege <> "" Then .Text = FullMessege
        '        .ActionType = EeekSoft.Web.PopupAction.MessageWindow
        '        .DragDrop = True
        '        'If popDocking.SelectedIndex = 0 Then .DockMode = EeekSoft.Web.PopupDocking.BottomLeft
        '        'If popDocking.SelectedIndex = 1 Then .DockMode = EeekSoft.Web.PopupDocking.BottomRight
        '        .DockMode = EeekSoft.Web.PopupDocking.BottomLeft
        '        .OffsetX = X
        '        .OffsetY = Y
        '        '.ColorStyle = Switch(clrStyle.SelectedIndex = 0, EeekSoft.Web.PopupColorStyle.Red, clrStyle.SelectedIndex = 1, EeekSoft.Web.PopupColorStyle.Green, clrStyle.SelectedIndex = 2, EeekSoft.Web.PopupColorStyle.Blue, clrStyle.SelectedIndex = 3, EeekSoft.Web.PopupColorStyle.Violet)
        '        Select Case Title.ToLower
        '            Case "success"
        '                .ColorStyle = EeekSoft.Web.PopupColorStyle.Green
        '                .HideAfter = 5000
        '            Case "failure"
        '                .ColorStyle = EeekSoft.Web.PopupColorStyle.Red
        '                .HideAfter = -1
        '            Case Else '"warning"
        '                .ColorStyle = EeekSoft.Web.PopupColorStyle.Blue
        '                .HideAfter = -1
        '        End Select
        '        '.Style.Add("position", "relative")
        '        '.Style.Add("position", "absolute")
        '        '.Style.Add("top", "1500")
        '        '.Style.Add("left", "300")
        '        .EnableViewState = False
        '        .Visible = True
        '    End With
        '    'divPopup.Controls.Add(popMsg)
        '    'Controls.Add(popMsg)
        '    Return popMsg
        'End Function

#End Region

#Region " Public Methods "

        Public Sub Load(ByVal ModuleId As Integer)
            'Try
            If ModuleId > -1 Then
                'ModSets.Clear()
                Dim ModSets As Hashtable = (New Entities.Modules.ModuleController).GetModuleSettings(ModuleId)
                Dim d As DictionaryEntry

                For Each d In ModSets
                    Try
                        'use the Key and Value properties. Note chr(9) is a tab
                        'Console.WriteLine("{0}" & Chr(9) & "{1}", d.Key, d.Value)
                        Me.Add(d.Key, d.Value)
                    Catch
                    End Try
                Next d
            End If
            'Catch
            'End Try
        End Sub

        Public Sub Update(ByVal ModuleId As Integer)
            _ModuleID = ModuleId
            Update()
        End Sub

        Public Sub Update()
            If ModuleID > -1 Then
                Dim objMC As New Entities.Modules.ModuleController
                Dim d As DictionaryEntry

                For Each d In Me
                    Try
                        'use the Key and Value properties. Note chr(9) is a tab
                        'Console.WriteLine("{0}" & Chr(9) & "{1}", d.Key, d.Value)
                        objMC.UpdateModuleSetting(ModuleID, d.Key.ToString, d.Value.ToString)
                    Catch
                    End Try
                Next d

                'For Each K As String In ModSets.Keys
                '    objMC.UpdateModuleSetting(ModuleID, K, ModSets.Item(K).ToString)
                'Next K

                'For I As Integer = 0 To ModSets.Count - 1
                '    objMC.UpdateModuleSetting(ModuleID, ModSets(I).ToString, ModSets.Keys(I))
                'Next
            End If 'ModuleID > -1 Then

        End Sub

        Function LinkClickUrlLegacy(ByVal Link As String) As String
            Dim strLink As String = Link

            Select Case GetURLType(strLink)
                Case DotNetNuke.Entities.Tabs.TabType.Tab  'TabType.Tab
                    strLink = DotNetNuke.Common.Globals.ApplicationPath & "/" & glbDefaultPage & "?tabid=" & Link
                Case DotNetNuke.Entities.Tabs.TabType.File 'TabType.File
                    Dim _portalSettings As DotNetNuke.Entities.Portals.PortalSettings = DotNetNuke.Entities.Portals.PortalController.GetCurrentPortalSettings
                    strLink = _portalSettings.HomeDirectory & Link
            End Select

            Return strLink
        End Function 'LinkClickUrlLegacy


        Function GetThumbSrc(ByVal FileName As String, ByVal ThumbGenFile As String, Optional ByVal Width As Integer = -1) As String
            Dim W As Integer = Width
            If W < 0 Then
                Try
                    W = Integer.Parse(ThumbWidth)
                Catch
                    'W = 32 'The default width specified in the Thumb.aspx file will be used
                End Try
            End If

            Dim strFileName As String '= FileName
            If FileName.StartsWith("http") Then
                strFileName = FileName
            Else
                strFileName = HttpContext.Current.Server.MapPath(FileName) 'HttpServerUtility.MapPath(FileName) ' Server.MapPath(FileName)
            End If

            If W < 0 Then
                Return ThumbGenFile & "?filename=" & strFileName
            Else
                Return ThumbGenFile & "?width=" & W.ToString & "&filename=" & strFileName
            End If

        End Function 'GetThumbSrc

        Function MediaType(ByVal MediaFilename As String) As String
            Select Case System.IO.Path.GetExtension(MediaFilename).ToLower
                Case ".gif", ".jpg", ".jpeg", ".jpe"
                    Return "Image"
                Case ".swf"
                    Return "Flash"
                Case ".wmv", ".mpeg", ".mpg", ".mov"
                    Return "Movie"
                Case Else
                    Return "Unknown"
            End Select
        End Function

        Function IsImageFile(ByVal Filename As String) As Boolean
            Return MediaType(Filename).ToLower = "image"
        End Function

        Function GetThumbUrl(ByVal MediaFile1 As String, ByVal ThumbGenFile As String, ByVal NoImageFile As String, Optional ByVal MediaFile2 As String = "", Optional ByVal Width As Integer = -1) As String
            If (MediaFile1 <> "") AndAlso (IsImageFile(MediaFile1)) Then
                Return GetThumbSrc(MediaFile1, ThumbGenFile, Width)
            ElseIf (MediaFile2 <> "") AndAlso (IsImageFile(MediaFile2)) Then
                Return GetThumbSrc(MediaFile2, ThumbGenFile, Width)
            Else
                Return GetThumbSrc(NoImageFile, ThumbGenFile, Width)
            End If
        End Function

        Public Function GetDatedTitle(ByVal Title As String, ByVal TitleDate As String) As String
            Select Case AddDate.ToLower
                Case "a", "after"
                    Return Title & " : " & TitleDate
                Case "b", "before"
                    Return TitleDate & " : " & Title
                Case "u", "up"
                    Return TitleDate & "<br />" & Title
                Case "d", "down"
                    Return Title & "<br />" & TitleDate
                Case Else
                    Return Title
            End Select
        End Function

#End Region

#Region " Constructors "

        Public Sub New()
        End Sub

        Public Sub New(ByVal ModuleId As Integer)
            Load(ModuleId)
        End Sub

#End Region

    End Class 'OptionsInfo

End Namespace 'bhattji.Modules.SalesReps
