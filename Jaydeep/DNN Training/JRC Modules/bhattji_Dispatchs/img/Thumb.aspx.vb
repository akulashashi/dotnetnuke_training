'Imports System.IO
'Imports System.Drawing
'Imports System.Web

Namespace bhattji.Modules.Dispatchs

    Public Class Thumb
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "
        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        End Sub
        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        '''Private designerPlaceholderDeclaration As System.Object
        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub
#End Region

#Region " Functions & Methods "
        'Private Function GetFileName() As String
        '    'Get the filename. The file could be either the remote file on the web
        '    'Or Local file on the same Webserver (in which case the path should be absolute)
        '    Dim _GetFileName As String = "http://www.bhattji.com/images/vision.jpg"
        '    If Not Request.Params("filename") Is Nothing Then
        '        If Request.Params("filename").Length > 0 Then _GetFileName = Request.Params("filename")
        '    End If
        '    Return _GetFileName
        'End Function 'GetFileName

        Private Function GetImage(ByVal FileName As String) As System.Drawing.Image
            If FileName.ToLower.StartsWith("http") Then
                Dim objClient As New Net.WebClient
                Dim objImageStream As New IO.MemoryStream(objClient.DownloadData(FileName))
                Return System.Drawing.Image.FromStream(objImageStream)
            Else
                'objImage = System.Drawing.Image.FromFile(Server.MapPath(strFileName))
                Return System.Drawing.Image.FromFile(FileName)
            End If
        End Function 'GetImage

        'Private Function GetGraphics(ByVal objBitmap As System.Drawing.Bitmap) As Graphics

        'End Function 'GetGraphics

        Private Sub GetSize(ByVal Image As System.Drawing.Image, ByRef Width As Integer, ByRef Height As Integer)
            Dim tWidth As Integer = -1 'Width
            Dim tHeight As Integer = -1 'Height

            Try
                ' Retrieve width from query string
                If Not Request.Params("width") Is Nothing Then
                    Try
                        tWidth = Convert.ToInt32(Request.Params("width"))
                    Catch
                    End Try
                End If
                If Not Request.Params("height") Is Nothing Then
                    Try
                        tHeight = Convert.ToInt32(Request.Params("height"))
                    Catch
                    End Try
                End If

                'Set tWidth & tHeight
                If tWidth < 0 And tHeight < 0 Then
                    Dim MinSize As Integer = -1
                    If Not Request.Params("MinSize") Is Nothing Then
                        Try
                            MinSize = Convert.ToInt32(Request.Params("MinSize"))
                        Catch
                        End Try
                    End If

                    If MinSize > -1 Then
                        If Image.Height < Image.Width Then
                            tHeight = MinSize
                            tWidth = CType(Image.Width * MinSize / Image.Height, Integer)
                        Else
                            tWidth = MinSize
                            tHeight = CType(Image.Height * MinSize / Image.Width, Integer)
                        End If
                    Else
                        Dim MaxSize As Integer = -1
                        If Not Request.Params("MaxSize") Is Nothing Then
                            Try
                                MinSize = Convert.ToInt32(Request.Params("MaxSize"))
                            Catch
                            End Try
                        End If

                        If Image.Height > Image.Width Then
                            If MaxSize > -1 Then
                                tHeight = MaxSize
                            Else
                                tHeight = Height
                            End If
                            tWidth = CType(Image.Width * tHeight / Image.Height, Integer)
                        Else
                            If MaxSize > -1 Then
                                tWidth = MaxSize
                            Else
                                tWidth = Width
                            End If
                            tHeight = CType(Image.Height * tWidth / Image.Width, Integer)
                        End If
                    End If
                ElseIf tHeight < 0 Then
                    tHeight = CType(Image.Height * tWidth / Image.Width, Integer)
                ElseIf tWidth < 0 Then
                    tWidth = CType(Image.Width * tHeight / Image.Height, Integer)
                    'Else
                End If

            Catch
                'if somthing breaks set the Dimension as supplied
                tWidth = Width
                tHeight = Height
            Finally
                'Finally set the computed/defaulted Width & Height
                Width = tWidth
                Height = tHeight
            End Try
        End Sub 'GetSize

        Private Function GetContentType(ByVal FileName As String) As String
            Select Case System.IO.Path.GetExtension(FileName).ToLower
                Case ".wmf"
                    Return "image/wmf"
                Case ".png"
                    Return "image/png"
                Case ".gif"
                    Return "image/gif"
                Case Else '".jpg"
                    Return "image/jpeg"
            End Select
        End Function 'GetContentType

        Private Function GetImageFormat(ByVal FileName As String) As Drawing.Imaging.ImageFormat
            Select Case System.IO.Path.GetExtension(FileName).ToLower
                Case ".wmf"
                    Return Drawing.Imaging.ImageFormat.Wmf
                Case ".png"
                    Return Drawing.Imaging.ImageFormat.Png
                Case ".gif"
                    Return Drawing.Imaging.ImageFormat.Gif
                Case Else '".jpg"
                    Return Drawing.Imaging.ImageFormat.Jpeg
            End Select
        End Function 'GetImageFormat

#End Region

#Region " Event Methods "

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Try
                'Get the filename
                Dim strFileName As String = "http://www.bhattji.com/images/vision.jpg"
                If Not Request.Params("filename") Is Nothing Then
                    strFileName = Request.Params("filename")
                End If

                'Create The Image from retrieved filename
                Dim objImage As System.Drawing.Image = GetImage(strFileName)

                'Compute the Dimension of the Thumbnail
                Dim tWidth As Integer = 100 '= Integer.Parse(Request.Params("width"))
                Dim tHeight As Integer = 100 '= Integer.Parse(Request.Params("height"))
                GetSize(objImage, tWidth, tHeight)

                'Decide the Quality of the Thumbnail
                Dim LowQuality As Boolean = False
                If Not Request.Params("Quality") Is Nothing Then
                    LowQuality = (Request.Params("Quality").ToLower = "low")
                End If

                If LowQuality Then 'Use Windows Function GetThumbnailImage of the System.Drawing.Image
                    Dim objThumbnail As System.Drawing.Image = objImage.GetThumbnailImage(tWidth, tHeight, Nothing, Nothing)
                    Response.ContentType = GetContentType(strFileName)
                    objThumbnail.Save(Response.OutputStream, GetImageFormat(strFileName))
                    objThumbnail.Dispose()
                Else 'Use Windows advanced Bitmap & Graphics Utilities & Functions
                    Dim objThumb As Drawing.Bitmap = New Drawing.Bitmap(tWidth, tHeight)
                    Dim objGraphics As Drawing.Graphics = Drawing.Graphics.FromImage(objThumb)
                    If Not Request.Params("BgColor") Is Nothing Then 'Request.Params("BgColor") <> String.Empty Then
                        Dim BgColor As Drawing.Color '= Color.White
                        Try
                            BgColor = CType(System.ComponentModel.TypeDescriptor.GetConverter(GetType(Drawing.Color)).ConvertFromString(Request.Params("BgColor")), Drawing.Color)
                        Catch
                            BgColor = Drawing.Color.White
                        End Try
                        objGraphics.Clear(BgColor)
                    End If
                    objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
                    objGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                    objGraphics.DrawImage(objImage, 0, 0, tWidth, tHeight)

                    objThumb.Save(Response.OutputStream, GetImageFormat(strFileName))
                    objGraphics.Dispose()
                    objThumb.Dispose()
                End If

                objImage.Dispose()

            Catch ex As Exception
                ProcessModuleLoadException(Me, ex)
            End Try

        End Sub 'Page_Load

#End Region

    End Class 'Thumb

End Namespace 'bhattji.Modules.Dispatchs
