Namespace bhattji.Modules.LoadSheets
    Partial Class jbMessageBox
        Inherits System.Web.UI.UserControl


#Region " Properties "
        Public Property ShowCloseButton() As Boolean
            Get
                Try
                    Return hypClose.Visible
                Catch
                    Return True
                End Try
            End Get
            Set(ByVal value As Boolean)
                Try
                    hypClose.Visible = value
                Catch
                    hypClose.Visible = True
                End Try
            End Set
        End Property
        Private _CssClass As String
        Public Property CssClass() As String
            Get
                Return _CssClass
            End Get
            Set(ByVal value As String)
                _CssClass = value
            End Set
        End Property
        Private _WarningCssClass As String
        Public Property WarningCssClass() As String
            Get
                Return _WarningCssClass
            End Get
            Set(ByVal value As String)
                _WarningCssClass = value
            End Set
        End Property
        Private _InfoCssClass As String
        Public Property InfoCssClass() As String
            Get
                Return _InfoCssClass
            End Get
            Set(ByVal value As String)
                _InfoCssClass = value
            End Set
        End Property
        Private _ErrorCssClass As String
        Public Property ErrorCssClass() As String
            Get
                Return _ErrorCssClass
            End Get
            Set(ByVal value As String)
                _ErrorCssClass = value
            End Set
        End Property
        Private _SuccessCssClass As String
        Public Property SuccessCssClass() As String
            Get
                Return _SuccessCssClass
            End Get
            Set(ByVal value As String)
                _SuccessCssClass = value
            End Set
        End Property
#End Region

#Region "Members"
        Public Enum MessageType
            [Error]
            Info
            Success
            Warning
        End Enum
#End Region

#Region "Methods"

#Region "Wrapper methods"
        Public Sub ShowError(ByVal message As String)
            Show(message, MessageType.[Error])
        End Sub

        Public Sub ShowInfo(ByVal message As String)
            Show(message, MessageType.Info)
        End Sub

        Public Sub ShowSuccess(ByVal message As String)
            Show(message, MessageType.Success)
        End Sub

        Public Sub ShowWarning(ByVal message As String)
            Show(message, MessageType.Warning)
        End Sub
#End Region
        Public Sub Show(ByVal message As String)
            Show(message, MessageType.[Error])
        End Sub
        Public Sub Show(ByVal message As String, ByVal MsgType As Integer)
            If MsgType < 0 OrElse MsgType > 3 Then
                MsgType = 0
            End If
            Show(message, DirectCast(MsgType, MessageType))
        End Sub
        Public Sub Show(ByVal message As String, ByVal title As String, ByVal msgType As Integer)
            If msgType < 0 OrElse msgType > 3 Then
                msgType = 0
            End If
            Show(message, title, DirectCast(msgType, MessageType))
        End Sub

        Public Sub Show(ByVal message As String, ByVal title As String)
            Show(message, title, MessageType.[Error])
        End Sub
        Public Sub Show(ByVal message As String, ByVal title As String, ByVal msgType As MessageType)
            'Dim msg As String = message
            If Not String.IsNullOrEmpty(title) Then
                message = "<font size='+1'>" & title & "</font><br/>" & message
            End If
            Show(message, msgType)
        End Sub
        Public Sub Show(ByVal message As String, ByVal msgType As MessageType)
            ltrMessage.Text = message

            Select Case msgType
                Case MessageType.Info
                    'imgIcon.ImageUrl = "~/images/info.png"; 
                    If Not String.IsNullOrEmpty(InfoCssClass) Then
                        MessageBox.Attributes.Add("Class", InfoCssClass)
                    ElseIf Not String.IsNullOrEmpty(CssClass) Then
                        MessageBox.Attributes.Add("Class", CssClass)
                    Else
                        MessageBox.Attributes.Remove("Class")
                    End If

                Case MessageType.Success
                    'imgIcon.ImageUrl = "~/images/success.png"; 
                    If Not String.IsNullOrEmpty(SuccessCssClass) Then
                        MessageBox.Attributes.Add("Class", SuccessCssClass)
                    ElseIf Not String.IsNullOrEmpty(CssClass) Then
                        MessageBox.Attributes.Add("Class", CssClass)
                    Else
                        MessageBox.Attributes.Remove("Class")
                    End If

                Case MessageType.Warning
                    'imgIcon.ImageUrl = "~/images/warning.png"; 
                    If Not String.IsNullOrEmpty(WarningCssClass) Then
                        MessageBox.Attributes.Add("Class", WarningCssClass)
                    ElseIf Not String.IsNullOrEmpty(CssClass) Then
                        MessageBox.Attributes.Add("Class", CssClass)
                    Else
                        MessageBox.Attributes.Remove("Class")
                    End If

                Case Else 'MessageType.Error
                    'imgIcon.ImageUrl = "~/images/error.png"; 
                    If Not String.IsNullOrEmpty(ErrorCssClass) Then
                        MessageBox.Attributes.Add("Class", ErrorCssClass)
                    ElseIf Not String.IsNullOrEmpty(CssClass) Then
                        MessageBox.Attributes.Add("Class", CssClass)
                    Else
                        MessageBox.Attributes.Remove("Class")
                    End If

                    Exit Select
            End Select

            Me.Visible = True
        End Sub

#End Region

#Region "Events"
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            hypClose.Attributes.Add("onclick", "document.getElementById('" & MessageBox.ClientID & "').style.display = 'none'")
            If Not IsPostBack Then hypClose.Visible = False
        End Sub
#End Region

    End Class

End Namespace
