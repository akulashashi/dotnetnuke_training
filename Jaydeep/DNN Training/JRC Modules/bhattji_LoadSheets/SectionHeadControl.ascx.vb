﻿
Namespace bhattji.Modules.LoadSheets

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' SectionHeadControl is a user control that provides all the server code to allow a
    ''' section to be collapsed/expanded, using user provided images for the button.
    ''' </summary>
    ''' <remarks>
    ''' To use this control the user must provide somewhere in the asp page the
    ''' implementation of the javascript required to expand/collapse the display.
    ''' eg:
    '''   function __dnn_SectionMaxMin(img, objID)  {
    '''     //implemenation code
    '''     ....
    '''   }
    ''' where __dnn_SectionMaxMin is the name of function, that is supplied
    ''' in the Attribute/Property javaScript.
    ''' </remarks>
    ''' <history>
    ''' 	[cnurse]	9/7/2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Partial Public Class SectionHeadControl
        Inherits System.Web.UI.UserControl


#Region "Private Members"

        'Private _includeRule As Boolean = False
        Private _isExpanded As Boolean = True
        Private _javaScript As String = "__dnn_SectionMaxMin"
        Private _maxImageUrl As String = "images/plus.gif"
        Private _minImageUrl As String = "images/minus.gif"
        Private _resourceKey As String
        Private _section As String  'Associated Section for this Control

#End Region

#Region "Public Properties"

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' CssClass determines the Css Class used for the Title Text
        ''' </summary>
        ''' <value>A string representing the name of the css class</value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[cnurse]	9/7/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property CssClass() As String
            Get
                Return lblTitle.CssClass
            End Get
            Set(ByVal Value As String)
                lblTitle.CssClass = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' IncludeRule determines whether there is a horizontal rule displayed under the
        ''' header text
        ''' </summary>
        ''' <value>A string representing true or false</value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[cnurse]	9/7/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property IncludeRule() As Boolean
            Get
                Return pnlRule.Visible
            End Get
            Set(ByVal Value As Boolean)
                pnlRule.Visible = Value
            End Set
        End Property
        'Public Property IncludeRule() As Boolean
        '    Get
        '        Return _includeRule
        '    End Get
        '    Set(ByVal Value As Boolean)
        '        _includeRule = Value
        '    End Set
        'End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' IsExpanded determines whether the section is expanded or collapsed.
        ''' </summary>
        ''' <value>Boolean value that determines whether the panel is expanded (true)
        ''' or collapsed (false).  The default is true.</value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[cnurse]	9/7/2004	Created
        '''		[jhenning]	09/06/2005 Utilizing ClientAPI EnableMinMax
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property IsExpanded() As Boolean
            Get
                Return DotNetNuke.UI.Utilities.DNNClientAPI.MinMaxContentVisibile(imgIcon, Not _isExpanded, DotNetNuke.UI.Utilities.DNNClientAPI.MinMaxPersistanceType.Page)

            End Get
            Set(ByVal Value As Boolean)
                _isExpanded = Value
                DotNetNuke.UI.Utilities.DNNClientAPI.MinMaxContentVisibile(imgIcon, Not _isExpanded, DotNetNuke.UI.Utilities.DNNClientAPI.MinMaxPersistanceType.Page) = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' JavaScript is the name of the javascript function implementation.
        ''' </summary>
        ''' <value>A string representing the name of the javascript function implementation</value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[cnurse]	9/7/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property JavaScript() As String
            Get
                Return _javaScript
            End Get
            Set(ByVal Value As String)
                _javaScript = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The MaxImageUrl is the url of the image displayed when the contained panel is
        ''' collapsed.
        ''' </summary>
        ''' <value>A string representing the url of the Max Image</value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[cnurse]	9/7/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property MaxImageUrl() As String
            Get
                Return _maxImageUrl
            End Get
            Set(ByVal Value As String)
                _maxImageUrl = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The MinImageUrl is the url of the image displayed when the contained panel is
        ''' expanded.
        ''' </summary>
        ''' <value>A string representing the url of the Min Image</value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[cnurse]	9/7/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property MinImageUrl() As String
            Get
                Return _minImageUrl
            End Get
            Set(ByVal Value As String)
                _minImageUrl = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The ResourceKey is the key used to identify the Localization Resource for the
        ''' title text.
        ''' </summary>
        ''' <value>A string representing the ResourceKey.</value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[cnurse]	9/7/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property ResourceKey() As String
            Get
                Return _resourceKey
            End Get
            Set(ByVal Value As String)
                _resourceKey = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The Section is the Id of the DHTML object  that contains the xection content
        ''' title text.
        ''' </summary>
        ''' <value>A string representing the Section.</value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[cnurse]	9/7/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property Section() As String
            Get
                Return _section
            End Get
            Set(ByVal Value As String)
                _section = Value
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The Text is the name or title of the section
        ''' </summary>
        ''' <value>A string representing the Title Text.</value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[cnurse]	9/7/2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Property Text() As String
            Get
                Return lblTitle.Text
            End Get
            Set(ByVal Value As String)
                lblTitle.Text = Value
            End Set
        End Property

#End Region

#Region "Event Handlers"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Renders the SectionHeadControl
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[VMasanas]	04/11/2004	Moved code from Page_Load to PreRender so all other properties are set.
        '''             This allows to inject this control dynamically on a page using LoadControl
        '''		[jhenning]	09/06/2005 Utilizing ClientAPI EnableMinMax
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
            Try
                Dim ctl As HtmlControl = CType(Me.Parent.FindControl(Section), HtmlControl)
                If Not ctl Is Nothing Then
                    DotNetNuke.UI.Utilities.DNNClientAPI.EnableMinMax(imgIcon, ctl, Not IsExpanded, Page.ResolveUrl(MinImageUrl), Page.ResolveUrl(MaxImageUrl), DotNetNuke.UI.Utilities.DNNClientAPI.MinMaxPersistanceType.Page)
                End If

                'optionlly show hr
                'pnlRule.Visible = _includeRule

            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Assign resource key to label for localization
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[VMasanas]	05/11/2004	Move code to Page_Load for localization
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                'set the resourcekey attribute to the label
                If ResourceKey <> "" Then
                    lblTitle.Attributes("resourcekey") = ResourceKey
                End If
            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub


        Private Sub imgIcon_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgIcon.Click
            Dim ctl As HtmlControl = CType(Me.Parent.FindControl(Section), HtmlControl)
            If Not ctl Is Nothing Then
                Me.IsExpanded = Not Me.IsExpanded
            End If

        End Sub

#End Region

    End Class

End Namespace