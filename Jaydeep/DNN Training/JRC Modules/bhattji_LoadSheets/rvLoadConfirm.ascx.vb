' Copyright (c) 2002-2005
' by Jaydeep Bhatt, Vision Consultants. ( http://www.bhattji.com )
'
' Permission is hereby granted, to the person obtaining a copy of this software legaly and associated
' documentation files (the "Software"), to deal in the Software with restriction, including with limitation
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

Imports System.Web.UI.WebControls
Imports DotNetNuke
Imports bhattji.Modules.LoadSheets.Business
Imports Microsoft.Reporting.WebForms
Imports System.IO

Namespace bhattji.Modules.LoadSheets

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' The Links Class provides the UI for displaying the Links
    ''' </summary>
    '''
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[bhattji]	9/23/2004	Moved Links to a separate Project
    '''		[bhattji]	10/20/2004	Removed ViewOptions from Action menu
    ''' </history>
    ''' -----------------------------------------------------------------------------
    '''

    Public MustInherit Class rvLoadConfirm
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "

        Private itemId As Integer
        Shared strFName As String

        Shared sLoadId As String
        Shared sLoadDate As String
        Shared sLoadType As String
        Shared sJRCIOfficeCode As String
        'Shared strEmail As String = "LoadConfirm@JrcTransportation.com"
        'Private loadId As String
        'Private objOI As OptionsInfo

#End Region

#Region " Methods "

        Private Sub RunReport()
            ReportViewer1.Height = 1000
            ' Set the processing mode for the ReportViewer to Local 
            ReportViewer1.ProcessingMode = ProcessingMode.Local
            ReportViewer1.ShowToolBar = False
            'ReportViewer1.ShowRefreshButton = True
            'ReportViewer1.ShowZoomControl = False
            'ReportViewer1.ShowPrintButton = True

            'ReportViewer1.ShowExportControls = False
            'ReportViewer1.ShowFindControls = False
            'ReportViewer1.ShowPageNavigationControls = False

            ReportViewer1.LocalReport.ReportPath = Server.MapPath(ModulePath + "Reports/LoadConfirm.rdlc")

            'ReportViewer1.LocalReport.ListRenderingExtensions[1]
            'RenderingExtension re= New RenderingExtension();

            Dim dt As DataTable = (New LoadSheetsController).GetLoadConfirmHeader(itemId)
            'If Validators.IsEmailValid(dt.Rows(0)("CarrierEmail").ToString) Then
            '    txtEmail.Text = dt.Rows(0)("CarrierEmail").ToString
            'Else
            '    dt.Rows(0)("CarrierEmail") = ""
            'End If
            txtEmail.Text = dt.Rows(0)("CarrierEmail").ToString
            sLoadId = dt.Rows(0)("LoadID").ToString
            sLoadDate = CType(dt.Rows(0)("LoadDate"), Date).ToShortDateString
            sLoadType = dt.Rows(0)("LoadType").ToString
            sJRCIOfficeCode = dt.Rows(0)("JRCIOfficeCode").ToString

            Dim loadId = (New LoadSheetsController).GetLoadId(itemId)

            Dim dt2 As DataTable = (New LoadPUsController).GetReportLoadPUByLoadId(loadId)
            'For Each dtr2 As DataRow In dt2.Rows
            '    dtr2("PUTel") = Phone.FormatPhoneNo(Convert.ToString(Null.SetNull(dtr2("PUTel"), Null.NullString))) '& IIf(Null.IsNull(dtr("CarrierExt")), "", " Ext: " & dtr("CarrierExt").ToString).ToString
            'Next

            Dim dt3 As DataTable = (New LoadDropsController).GetReportLoadDropByLoadId(loadId)
            'For Each dtr3 As DataRow In dt2.Rows
            '    dtr3("DPPhone") = Phone.FormatPhoneNo(Convert.ToString(Null.SetNull(dtr3("DPPhone"), Null.NullString))) '& IIf(Null.IsNull(dtr("CarrierExt")), "", " Ext: " & dtr("CarrierExt").ToString).ToString
            'Next

            'If chkSortDesc.Checked Then
            '    dt.DefaultView.Sort = ddlSort.SelectedValue & " DESC"
            'Else
            '    dt.DefaultView.Sort = ddlSort.SelectedValue
            'End If

            Dim ReportDataSource1 As New ReportDataSource("DataSet1_DataTable1", dt)
            Dim ReportDataSource2 As New ReportDataSource("DataSet1_DataTable2", dt2)
            Dim ReportDataSource3 As New ReportDataSource("DataSet1_DataTable3", dt3)

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
            ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
            ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)

            ' Create the prmCopyright ReportParameter 
            'Dim prmCopyright As New ReportParameter("prmCopyright", "Copyrighted by JRC Transportation")
            'prmCopyright.Name = "prmCopyright"; 
            'prmCopyright.Values.Add("Copyrighted by Jaydeep Bhatt"); 
            ' Create the prmCopyright ReportParameter 
            'Dim prmCompanyName As New ReportParameter("prmCompanyName", "JRC Office: " + ddlJRCIOfficeCode.SelectedItem.Text)

            ' Set the report parameters for the report 
            'ReportViewer1.LocalReport.SetParameters(New ReportParameter() {prmCopyright, prmCompanyName})
            'ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { prmCopyright}); 
            'ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { prmCompanyName }); 
        End Sub
        Protected Sub GenratePDF()
            ''txtNoOfItems.Text = "0"
            ''gdvViewList.AllowPaging = False
            ''ResetViewStates()
            'tblSearch.Visible = False 'not tblSearch.Visible
            ''If Page.IsPostBack Then Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            ''Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            'Me.Controls.Add(New LiteralControl("<script type=""text/javascript"" language=""javascript"">window.print();</script>"))

            'Dim warnings As Warning() = Nothing
            'Dim streamids As String() = Nothing
            'Dim mimeType As String = Nothing
            'Dim encoding As String = Nothing
            'Dim extension As String = Nothing
            'Dim bytes As Byte()


            'Dim FolderLocation As String = Server.MapPath("~/Documentation/")

            'FolderLocation = System.Configuration.ConfigurationManager.AppSettings("ReportOutputPath")

            'Define the Filename
            If Not Request.QueryString("ItemId") Is Nothing Then
                strFName = "LoadConfirm" & Request.QueryString("ItemId") & ".PDF"
            Else
                strFName = "LoadConfirm.PDF"
            End If
            Dim strFileName As String = Server.MapPath("~/Documentation/" & strFName) 'System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), "PDF") '

            ''First delete existing file
            'File.Delete(strFileName)

            ''Then create new pdf file
            'Dim bytes As Byte() = ReportViewer1.LocalReport.Render("PDF", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            'Dim fsFileStream As New FileStream(strFileName, FileMode.Create)
            'fsFileStream.Write(bytes, 0, bytes.Length)
            'fsFileStream.Close()
            GeneratePdf4ReportViewer(strFileName)

            ''Write the File to Browser

            ''Set the appropriate ContentType.
            'Response.ContentType = "Application/pdf"

            ''Write the file directly to the HTTP output stream.
            'Response.WriteFile(strFileName)
            'Response.End()

        End Sub
        Sub GeneratePdf4ReportViewer(ByVal pdfFilename As String)
            'First delete existing file
            System.IO.File.Delete(pdfFilename)

            'Then create new pdf file
            Dim bytes As Byte() = ReportViewer1.LocalReport.Render("PDF", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            Dim fsFileStream As New System.IO.FileStream(pdfFilename, System.IO.FileMode.Create)
            fsFileStream.Write(bytes, 0, bytes.Length)
            fsFileStream.Close()
        End Sub
        Private Sub SendNotification(ByVal eMail As String, Optional ByVal Name As String = "", Optional ByVal SendAction As String = "S")
            Try
                ' load all user emails based on roles selected
                Dim objRoleNames As New System.Collections.Generic.List(Of String)
                'objRoleNames.Add("Administrators")

                ''Create the List of Recipients
                'Dim objRecipients As New ArrayList
                'If Name = "" Then
                '    objRecipients.Add(New System.Web.UI.WebControls.ListItem(eMail, eMail))
                'Else
                '    objRecipients.Add(New System.Web.UI.WebControls.ListItem(eMail, Name))
                'End If
                'objRecipients.Add(New System.Web.UI.WebControls.ListItem("jibhatt@gmail.com", "Jaydeep Bhatt"))
                'objRecipients.Add(New System.Web.UI.WebControls.ListItem("eric@mediainfocus.com", "Eric Pontbriand"))
                'objRecipients.Add(New System.Web.UI.WebControls.ListItem("john@mediainfocus.com", "John Hubbard"))

                '' load emails specified in email distribution list
                'Dim objUsers As New System.Collections.Generic.List(Of Users.UserInfo)
                'For Each li As System.Web.UI.WebControls.ListItem In objRecipients
                '    Dim objUser As New Users.UserInfo
                '    objUser.UserID = Null.NullInteger
                '    objUser.Email = li.Text
                '    objUser.DisplayName = li.Value
                '    objUsers.Add(objUser)
                'Next
                Dim objUsers As New System.Collections.Generic.List(Of Users.UserInfo)
                Dim objUser As New Users.UserInfo
                objUser.UserID = Null.NullInteger
                objUser.Email = eMail
                If Name = "" Then Name = eMail
                objUser.DisplayName = Name
                objUsers.Add(objUser)

                Dim ReportLink As String = ResolveUrl("~/Documentation/" & strFName)
                If ReportLink.StartsWith("/") Then ReportLink = AddHTTP(Request.ServerVariables("SERVER_NAME") & ReportLink)

                Dim Disclaimer As String = "The information contained in this electronic message is private and confidential information of J.R.C. Transportation, Inc. and is intended only for the use of the individual and/or entity named above.  If the reader of this message is not the intended recipient, or the employee or agent responsible to deliver it to the intended recipient, you are hereby notified that reading, distributing, copying or making any other use of this communication is STRICTLY PROHIBITED.  In no event shall receipt of this message by an unintended party be construed as a waiver by J.R.C. Transportation, Inc. of any privilege or other privacy rights. If you have received this communication in error, please notify us at the above email address."

                Dim Subject As String = "Confirmation for the Load " & sLoadId & ", LoadDate: " & sLoadDate & " from " & sJRCIOfficeCode  'lblLoadId.Text 'objLoadSheetInfo.LoadID
                If sLoadType.ToUpper = "OO" Then
                    Subject = "Driver " & Subject
                Else
                    Subject = "Broker " & Subject
                End If
                Dim Dispatcher As Users.UserInfo = Users.UserController.GetCurrentUserInfo
                Dim Body As String = "<p>You have received a load Confirmation for the Load " & sLoadId & " dated " & sLoadDate & " from " & Dispatcher.FirstName & " " & Dispatcher.LastName & " of JRC Transportation.</p>"
                Body &= "<p>Please see " & Subject & "</p><p>" & ReportLink & "</p>"
                'Body &= "<p>Incase you dont have the PDF Reader, you may download the Free <a href='http://get.adobe.com/reader'>Adobe Acrobat Reader</a></p>"
                Body &= "<p>In case you don't have the free Adobe Acrobat Reader (PDF Reader), you may use the link below to <a href='http://get.adobe.com/reader'>download</a> it.</p>"
                Body &= "<p><a href='http://get.adobe.com/reader'>http://get.adobe.com/reader</a></p>"
                Body &= "<hr/>" & Disclaimer

                'Create object
                Dim objSendBulkEMail As New DotNetNuke.Services.Mail.SendTokenizedBulkEmail(objRoleNames, objUsers, True, Subject, Body)
                objSendBulkEMail.BodyFormat = DotNetNuke.Services.Mail.MailFormat.Html
                objSendBulkEMail.Priority = DotNetNuke.Services.Mail.MailPriority.High
                objSendBulkEMail.SendingUser = Users.UserController.GetCurrentUserInfo
                objSendBulkEMail.ReplyTo = objSendBulkEMail.SendingUser
                objSendBulkEMail.AddAttachment(Server.MapPath(("~/Documentation/" & strFName)))
                objSendBulkEMail.AddressMethod = DotNetNuke.Services.Mail.SendTokenizedBulkEmail.AddressMethods.Send_TO

                ' send mail
                'Dim SendAction As String = "S" '"A"
                Dim strResult As String
                Dim msgResult As DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType
                If SendAction = "S" Then
                    Dim intMailsSent As Integer = objSendBulkEMail.SendMails()
                    If intMailsSent > 0 Then
                        strResult = "eMails sent to " & intMailsSent.ToString & " Recipients" 'String.Format(DotNetNuke.Services.Localization.Localization.GetString("MessagesSentCount", Me.LocalResourceFile), intMailsSent)
                        msgResult = DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess
                    Else
                        strResult = "eMails could not be sent" 'DotNetNuke.Services.Localization.Localization.GetString("NoMessagesSent", Me.LocalResourceFile)
                        msgResult = DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning
                    End If
                Else    ' ansynchronous uses threading
                    Dim objThread As New Threading.Thread(AddressOf objSendBulkEMail.Send)
                    objThread.Start()
                    strResult = "eMails are scheduled to be sent Asynchornously" 'DotNetNuke.Services.Localization.Localization.GetString("MessageSent", Me.LocalResourceFile)
                    msgResult = DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess
                End If
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(Me, strResult, msgResult)
                lblMsg.Text = strResult
            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Private Sub ShowPdf(ByVal strFilename As String)
            Response.ClearContent()
            Response.ClearHeaders()
            Response.ContentType = "application/pdf"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & strFilename)
            Response.TransmitFile(strFilename)
            Response.End()
            'Response.WriteFile(strFilename); 
            Response.Flush()
            Response.Clear()
        End Sub

#End Region

#Region " Event Handlers "

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Page_Load runs when the control is loaded
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[bhattji]	9/23/2004	Moved Links to a separate Project
        ''' </history>
        ''' -----------------------------------------------------------------------------
        '''
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                'objOI = New OptionsInfo(ModuleId) 'This is must since it is being used in RowBound Method
              
                If Not (Request.QueryString("ItemId") Is Nothing) Then
                    itemId = Int32.Parse(Request.QueryString("ItemId"))
                    If Not Page.IsPostBack Then
                        RunReport()
                    End If

                    If (Not (Request.QueryString("ShowPdf") Is Nothing)) AndAlso (Request.QueryString("ShowPdf").ToUpper = "PDF") Then
                        imbPrintSelection_Click(Nothing, Nothing)
                        'Response.Write("<script language='JavaScript'>history.back()</script>")
                    End If

                    If Not (Request.QueryString("eMail") Is Nothing) Then
                        txtEmail.Text = Request.QueryString("eMail")
                        imbEmailPdf_Click(Nothing, Nothing)
                    End If
                Else
                    Response.Redirect(NavigateURL())
                End If

            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Protected Sub imbPrintSelection_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrintSelection.Click
            GenratePDF()

            'Open the PDF in New Window
            'ResponseHelper.Redirect(ResolveUrl("~/Documentation/" & strFName))
            'ShowPdf(Server.MapPath(ResolveUrl("~/Documentation/" & strFName)))

            'Open the PDF in Same Window
            Response.Redirect(ResolveUrl("~/Documentation/" & strFName))
        End Sub

        Private Sub imbEmailPdf_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbEmailPdf.Click
            GenratePDF()

            'Send eMail
            SendNotification(txtEmail.Text)
        End Sub
        Private Sub lnbEmailPdf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbEmailPdf.Click
            imbEmailPdf_Click(Nothing, Nothing)
        End Sub

        'Protected Sub imbPrintSelection_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrintSelection.Click
        '    Dim buffer As Byte(), f As String, fs As System.IO.FileStream



        '    f = System.IO.Path.GetTempFileName()

        '    System.IO.Path.ChangeExtension(f, "PDF")

        '    ' there is probably a better way to set up the rendered PDF

        '    ' for redirecting to the Response output, but this one works.



        '    ' here is the binding bit. Revise to suit your dynamic situation.

        '    ' if you aren't really dynamically binding data against one 

        '    ' loaded report, but rather changing

        '    ' reports to suit the user's needs, that will work too.

        '    Dim ReportDataSourceX = New Microsoft.Reporting.WebForms.ReportDataSource()

        '    ReportDataSourceX.Name = "DataSet1_Recipient"

        '    ReportDataSourceX.Value = Me.SqlDataSource1



        '    With Me.ReportViewer1.LocalReport

        '        .DataSources.Clear()

        '        .DataSources.Add(ReportDataSourceX)

        '        buffer = .Render("PDF", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        '    End With



        '    fs = New System.IO.FileStream(f, System.IO.FileMode.Create)

        '    fs.Write(buffer, 0, buffer.Length)

        '    fs.Close()

        '    fs.Dispose()



        '    Response.ContentType = "Application/pdf"

        '    Response.WriteFile(f)

        '    Response.End()

        '    System.IO.File.Delete(f)

        'End Sub

#End Region


    End Class 'rvLoadConfirm

End Namespace 'bhattji.Modules.LoadSheets
