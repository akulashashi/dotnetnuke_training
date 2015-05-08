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

    Public MustInherit Class rvContainer
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "

        Private objOI As OptionsInfo
        Shared strFName As String

#End Region

#Region " Methods "
        Private Function GetReportTitle() As String
            If ddlReportTitle.SelectedValue = "TS" Then
                Return "Trailer"
            Else
                Return "Container"
            End If
        End Function
        Private Sub RunReport()
            ' Set the processing mode for the ReportViewer to Local 
            ReportViewer1.ProcessingMode = ProcessingMode.Local
            ReportViewer1.ShowToolBar = False
            'ReportViewer1.ShowRefreshButton = True
            'ReportViewer1.ShowZoomControl = True
            'ReportViewer1.ShowPrintButton = True

            'ReportViewer1.ShowExportControls = False
            'ReportViewer1.ShowFindControls = False
            'ReportViewer1.ShowPageNavigationControls = False
            'If ddlReportTitle.SelectedValue = "TS" Then
            '    ReportViewer1.LocalReport.ReportPath = Server.MapPath(ModulePath + "Reports/Trailer.rdlc")
            'Else
            '    ReportViewer1.LocalReport.ReportPath = Server.MapPath(ModulePath + "Reports/Container.rdlc")
            'End If
            ReportViewer1.LocalReport.ReportPath = Server.MapPath(ModulePath + "Reports/" & GetReportTitle() & ".rdlc")
            'Dim dt As New DataTable
            'If IsPostBack Then
            '    dt = (New LoadSheetsController).GetReportContainer(ddlJRCIOfficeCode.SelectedValue, ddlCustomerNumber.SelectedValue, txtSearch.Text, "", ddlLoadStatus.SelectedValue, ddlSort.SelectedValue, chkSortDesc.Checked, rblSearchOn.SelectedValue, (rblSearchType.SelectedIndex < 1), CInt(txtNoOfItems.Text), txtFrom.Text, txtTo.Text, ModuleId, PortalId, objOI.GetItems)
            'Else
            '    dt = (New LoadSheetsController).GetReportContainer(ddlJRCIOfficeCode.SelectedValue, ddlCustomerNumber.SelectedValue, txtSearch.Text, ddlXmissionFile.SelectedValue, ddlLoadStatus.SelectedValue, ddlSort.SelectedValue, chkSortDesc.Checked, rblSearchOn.SelectedValue, (rblSearchType.SelectedIndex < 1), CInt(txtNoOfItems.Text), txtFrom.Text, txtTo.Text, ModuleId, PortalId, objOI.GetItems)
            'End If
            Dim dt As DataTable = (New LoadSheetsController).GetReportContainer(ddlJRCIOfficeCode.SelectedValue, ddlCustomerNumber.SelectedValue, txtSearch.Text, txtSearchDriver.Text, ddlDriverStatus.SelectedValue, ddlReportTitle.SelectedValue, ddlLoadStatus.SelectedValue, ddlSort.SelectedValue, chkSortDesc.Checked, rblSearchOn.SelectedValue, (rblSearchType.SelectedIndex < 1), CInt(txtNoOfItems.Text), txtFrom.Text, txtTo.Text, ModuleId, PortalId, objOI.GetItems)

            Dim ReportDataSource1 As New ReportDataSource("DataSet1_DataTable1", dt)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)

            ' Create the prmCopyright ReportParameter 
            Dim prmCopyright As New ReportParameter("prmCopyright", "Copyrighted by JRC Transportation")
            'prmCopyright.Name = "prmCopyright"; 
            'prmCopyright.Values.Add("Copyrighted by Jaydeep Bhatt"); 
            ' Create the prmCopyright ReportParameter 
            'Dim prmCompanyName As New ReportParameter("prmCompanyName", "Xmission File: " + ddlXmissionFile.SelectedItem.Text)
            'Dim strCompanyName As String = ddlJRCIOfficeCode.SelectedItem.Text
            'If ddlCustomerNumber.SelectedValue <> "" Then
            '    strCompanyName &= " - " & ddlCustomerNumber.SelectedValue
            'End If
            'Dim prmCompanyName As New ReportParameter("prmCompanyName", strCompanyName)
            Dim prmCompanyName As New ReportParameter("prmCompanyName", ddlJRCIOfficeCode.SelectedItem.Text & ":" & ddlCustomerNumber.SelectedItem.Text)

            'Dim strTitle As String = "Container/Trailer Report"
            'Select Case rblSearchOn.SelectedIndex
            '    Case 0
            '        strTitle = "Trailer Report"
            '    Case 1
            '        strTitle = "Container1 Report"
            '    Case 2
            '        strTitle = "Container2 Report"
            'End Select
            'Dim prmTitle As New ReportParameter("prmTitle", strTitle)

            'Dim prmTitle As New ReportParameter("prmTitle")
            'Select Case ddlReportTitle.SelectedIndex
            '    'Case 0
            '    '    prmTitle.Values.Add("Trailer Report")
            '    Case 1
            '        prmTitle.Values.Add("Container1 Report")
            '    Case 2
            '        prmTitle.Values.Add("Container2 Report")
            '    Case Else
            '        prmTitle.Values.Add("Trailer Report")
            'End Select
            Dim prmTitle As New ReportParameter("prmTitle", ddlReportTitle.SelectedItem.Text & " Report")

            ' Set the report parameters for the report 
            ReportViewer1.LocalReport.SetParameters(New ReportParameter() {prmCopyright, prmCompanyName, prmTitle})
            'ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { prmCopyright}); 
            'ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { prmCompanyName }); 
        End Sub

        Private Sub BindUserIOs(Optional ByVal Username As String = "")
            Dim LoginName As String = Username
            If (LoginName = "") And Request.IsAuthenticated Then
                LoginName = Users.UserController.GetCurrentUserInfo.Username
            End If
            With ddlJRCIOfficeCode
                '.DataTextField = "IOName"
                '.DataValueField = "IOfficeCode"
                'If LoginName = "" Then
                '    .DataSource = (New Business.LoadSheetsController).GetAllInterOffices
                'Else
                '    .DataSource = (New Business.LoadSheetsController).GetUserIOs(LoginName)
                'End If
                '.DataBind()

                Dim valfld, txtfld As String
                Dim dr As IDataReader '= objLoadSheetsController.GetAllInterOffices
                If (Users.UserController.GetCurrentUserInfo.IsSuperUser) OrElse (Users.UserController.GetCurrentUserInfo.IsInRole("Sales - Admin")) OrElse (LoginName = "") Then
                    dr = (New Business.LoadSheetsController).GetAllInterOffices
                Else
                    dr = (New Business.LoadSheetsController).GetUserIOs(LoginName)
                End If
                .Items.Clear()
                While dr.Read
                    If dr("JRCActive").ToString.ToUpper = "Y" Then
                        valfld = dr("JRCIOfficeCode").ToString
                        txtfld = Replace(dr("IOName").ToString, "JRC - ", "")
                        txtfld = Replace(txtfld, "JRC ", "")
                        .Items.Add(New ListItem(txtfld.ToUpper, valfld))
                    End If
                End While
                If (Users.UserController.GetCurrentUserInfo.IsSuperUser) OrElse (Users.UserController.GetCurrentUserInfo.IsInRole("Admin - REPORTS")) Then
                    .Items.Insert(0, New ListItem("<All Offices>", "999999999"))
                End If

                Dim objLC As New Business.LoadSheetsController
                If (Session.Item("JRCIOfficeCode") Is Nothing) OrElse (Session.Item("JRCIOfficeCode").ToString = "") OrElse (Session.Item("JRCIOfficeCode").ToString = "000000000") Then
                    Session.Item("JRCIOfficeCode") = objLC.GetUserDefaultIO(LoginName)
                End If

                Try
                    .Items.FindByValue(Session.Item("JRCIOfficeCode").ToString.Substring(0, 9)).Selected = True
                Catch
                End Try

                'Try
                '    .Items.FindByValue((New Business.LoadSheetsController).GetUserDefaultIO(LoginName)).Selected = True
                'Catch
                'End Try
            End With
        End Sub

        Protected Sub GenratePDF(Optional ByVal pdfFileName As String = "")
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
            If pdfFileName = "" Then
                strFName = GetReportTitle() & "Report" & Now().ToString().Replace("/", "").Replace("\", "").Replace(":", "").Replace(" ", "").Replace("-", "") & ".PDF"
            Else
                strFName = pdfFileName & ".PDF"
            End If

            Dim strFileName As String = Server.MapPath("~/Documentation/" & strFName) 'System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), "PDF") '
            ''First delete existing file
            'System.IO.File.Delete(strFileName)

            ''Then create new pdf file
            'Dim bytes As Byte() = ReportViewer1.LocalReport.Render("PDF", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            'Dim fsFileStream As New System.IO.FileStream(strFileName, System.IO.FileMode.Create)
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

                Dim Subject As String = GetReportTitle() & " Report for the LoadDates from " & txtFrom.Text & " to " & txtTo.Text & " for " & ddlJRCIOfficeCode.SelectedItem.Text 'lblLoadId.Text 'objLoadSheetInfo.LoadID
                'If sLoadType.ToUpper = "OO" Then
                '    Subject = "Driver " & Subject
                'Else
                '    Subject = "Broker " & Subject
                'End If
                Dim Dispatcher As Users.UserInfo = Users.UserController.GetCurrentUserInfo
                Dim Body As String = "<p>You have received a " & GetReportTitle() & " activity report from " & Dispatcher.FirstName & " " & Dispatcher.LastName & " of JRC Transportation.</p>"
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
                objOI = New OptionsInfo(ModuleId) 'This is must since it is being used in RowBound Method

                'this needs to execute always to the client script code is registred in InvokePopupCal
                hypCalandarFromDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtFrom)
                hypCalandarToDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtTo)
                hyprvXmission.NavigateUrl = EditUrl("ReportType", "ReportContainer", "Reports", "dnnprintmode=true&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container")


                If Not Page.IsPostBack Then
                    'Removed this filter to get all the files in the list without the initial data filter
                    If (Not Request.QueryString("FromDate") Is Nothing) AndAlso (Request.QueryString("FromDate") <> "") Then
                        txtFrom.Text = Request.QueryString("FromDate")
                    Else
                        txtFrom.Text = Now.AddDays(-7).ToShortDateString
                    End If
                    If (Not Request.QueryString("ToDate") Is Nothing) AndAlso (Request.QueryString("ToDate") <> "") Then
                        txtTo.Text = Request.QueryString("ToDate")
                    Else
                        txtTo.Text = Now.ToShortDateString
                    End If
                    tdNoOfItems.Visible = objOI.ShowNoOfItems
                    txtNoOfItems.Text = objOI.rptNoOfItems.ToString
                    BindUserIOs()

                    If (Not Request.QueryString("JRCIOfficeCode") Is Nothing) AndAlso (Request.QueryString("JRCIOfficeCode") <> "") Then
                        ddlJRCIOfficeCode.SelectedValue = Request.QueryString("JRCIOfficeCode")
                    End If
                    
                    If (Not Request.QueryString("LoadStatus") Is Nothing) AndAlso (Request.QueryString("LoadStatus") <> "") Then
                        ddlLoadStatus.SelectedValue = Request.QueryString("LoadStatus")
                    End If

                    If Not String.IsNullOrEmpty(Request.QueryString("ReportTitle")) Then
                        ddlReportTitle.SelectedValue = Request.QueryString("ReportTitle")
                    End If
                    SetReportSettings(ddlReportTitle.SelectedValue)

                    'BindSearchData()
                    btnSearch_Click(Nothing, Nothing)
                End If

            Catch exc As Exception    'Module failed to load
                ProcessModuleLoadException(Me, exc)
            End Try

        End Sub

        Protected Sub ddlJRCIOfficeCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlJRCIOfficeCode.SelectedIndexChanged, ddlLoadStatus.SelectedIndexChanged
            Session.Item("JRCIOfficeCode") = ddlJRCIOfficeCode.SelectedValue & ddlJRCIOfficeCode.SelectedItem.Text
            btnSearch_Click(Nothing, Nothing)
        End Sub

        Private Sub SetReportSettings(ByVal ReportType As String)
            Select Case ReportType.ToUpper
                Case "TS"
                    rblSearchOn.SelectedIndex = 0
                    plSearchDriver.Visible = True
                    txtSearchDriver.Visible = True
                    ddlDriverStatus.Visible = True
                Case "CS"
                    rblSearchOn.SelectedIndex = 3
                Case Else '"CA"
                    rblSearchOn.SelectedIndex = 4
                    rblSearchType.Visible = False
                    txtSearch.Visible = False
                    'btnSearch.Visible = False
            End Select
            rblSearchOn.Visible = False
        End Sub
        Private Sub ddlReportTitle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlReportTitle.SelectedIndexChanged, ddlDriverStatus.SelectedIndexChanged
            btnSearch_Click(Nothing, Nothing)
        End Sub

        'Private Sub ddlCategories_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCategories.SelectedIndexChanged
        '    btnSearch_Click(Nothing, Nothing)
        'End Sub

        Private Sub btnCustomerSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCustomerSearch.Click
            With ddlCustomerNumber
                .DataValueField = "CustomerNumber"
                .DataTextField = "CustomerName"
                .DataSource = (New Business.LoadSheetsController).GetCustomerSearchForReports(txtCustomerNumber.Text, ddlJRCIOfficeCode.SelectedValue, (rblSearchType.SelectedIndex < 1), txtFrom.Text, txtTo.Text)
                .DataBind()

                .Items.Insert(0, New ListItem("<All Customers>", ""))
                If .Items.Count > 1 Then
                    .SelectedIndex = 1
                End If
                ddlCustomerNumber_SelectedIndexChanged(Nothing, Nothing)
            End With 'ddlBrokerCode
        End Sub

        Private Sub imbRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbRefresh.Click
            btnSearch_Click(Nothing, Nothing)
        End Sub

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            RunReport()
        End Sub

        Private Sub ddlCustomerNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCustomerNumber.SelectedIndexChanged
            txtCustomerNumber.Text = "" 'ddlCustomerNumber.SelectedValue
            btnSearch_Click(Nothing, Nothing)
            'ResetViewStates()
        End Sub

        Private Sub ddlSort_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSort.SelectedIndexChanged
            btnSearch_Click(Nothing, Nothing)
        End Sub

        Private Sub chkSortDesc_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSortDesc.CheckedChanged
            btnSearch_Click(Nothing, Nothing)
        End Sub

        Private Sub txtFrom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrom.TextChanged, txtTo.TextChanged
            btnSearch_Click(Nothing, Nothing)
        End Sub

        Private Sub imbPrintReport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrintReport.Click
            'txtNoOfItems.Text = "0"
            'gdvViewList.AllowPaging = False
            'ResetViewStates()
            'tblSearch.Visible = False 'not tblSearch.Visible
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            'Dim strUrl As String = EditUrl("ReportType", "rvXmission", "Reports", "dnnprintmode=true") & "?LoadStatus=" & ddlLoadStatus.SelectedValue & "&JRCIOfficeCode=" & ddlJRCIOfficeCode.SelectedValue & "&FromDate=" & Server.UrlEncode(txtFrom.Text) & "&ToDate=" & Server.UrlEncode(txtTo.Text) & "&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"
            Dim strUrl As String = EditUrl("ReportType", "ReportXmission", "Reports", "dnnprintmode=true") & "?FromDate=" & Server.UrlEncode(txtFrom.Text) & "&ToDate=" & Server.UrlEncode(txtTo.Text)
            If ddlJRCIOfficeCode.SelectedValue <> "" AndAlso ddlJRCIOfficeCode.SelectedValue <> "000000000" Then
                strUrl &= "&JRCIOfficeCode=" & ddlJRCIOfficeCode.SelectedValue
            End If
            If ddlLoadStatus.SelectedValue <> "" Then
                strUrl &= "&LoadStatus=" & ddlLoadStatus.SelectedValue
            End If

            strUrl &= "&SkinSrc=%5BG%5D%2fskins%2f_default%2fno%20skin&ContainerSrc=%5BG%5D%2fcontainers%2f_default%2fno%20container"
            Response.Write("<script type=""text/javascript"" language=""javascript"">window.open('" & strUrl & "','ReportXmission', 'location=0,toolbar=1,resizable=1,scrollbars=1,status=1');</script>")
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.open('" & strUrl & "');</script>")
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            'Response.Write("<script type=""text/javascript"" language=""javascript"">window.print('" & strUrl & "','ReportXmission', 'location=0,resizable=1,scrollbars=1,status=1');</script>")
        End Sub

        Protected Sub imbPrintSelection_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPrintSelection.Click
            ''txtNoOfItems.Text = "0"
            ''gdvViewList.AllowPaging = False
            ''ResetViewStates()
            'tblSearch.Visible = False 'not tblSearch.Visible
            ''If Page.IsPostBack Then Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            ''Response.Write("<script type=""text/javascript"" language=""javascript"">window.print();</script>")
            'Me.Controls.Add(New LiteralControl("<script type=""text/javascript"" language=""javascript"">window.print();</script>"))

            'Dim strFileName As String = Server.MapPath("~/Documentation/Container.PDF")
            ''First delete existing file
            'System.IO.File.Delete(strFileName)
            ''Then create new pdf file
            'Dim bytes As Byte() = ReportViewer1.LocalReport.Render("PDF", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            'Dim fsFileStream As New System.IO.FileStream(strFileName, System.IO.FileMode.Create)
            'fsFileStream.Write(bytes, 0, bytes.Length)
            'fsFileStream.Close()
            ''Write to Browser
            'ResponseHelper.Redirect(ResolveUrl("~/Documentation/Container.PDF"))

            GenratePDF(GetReportTitle() & "Report")

            'Open the PDF in New Window
            'ResponseHelper.Redirect(ResolveUrl("~/Documentation/" & strFName))
            'ShowPdf(Server.MapPath(ResolveUrl("~/Documentation/" & strFName)))

            'Open the PDF in Same Window
            ResponseHelper.Redirect(ResolveUrl("~/Documentation/" & strFName))
        End Sub

        Private Sub lnbEmailPdf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnbEmailPdf.Click
            imbEmailPdf_Click(Nothing, Nothing)
        End Sub
        Private Sub imbEmailPdf_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbEmailPdf.Click
            GenratePDF()

            'Send eMail
            SendNotification(txtEmail.Text)
        End Sub
#End Region

    End Class 'rvContainer

End Namespace 'bhattji.Modules.LoadSheets
