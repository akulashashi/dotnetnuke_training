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

Imports System
Imports System.Web
Imports System.Web.Mail
Imports System.Web.UI
Imports System.Web.UI.WebControls
'Imports iTextSharp.text
'Imports iTextSharp.text.pdf
'Imports System.IO

Namespace bhattji.Modules.LoadSheets

    Public MustInherit Class Reports
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "
#End Region

#Region " Public Methods "

#End Region

#Region " Event Handlers "

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                'Dim objOI As New OptionsInfo(ModuleId)
                Dim ReportType As String = "loadreport"
                Try
                    If (Not Request.QueryString("ReportType") Is Nothing) OrElse (Request.QueryString("ReportType") <> "") Then
                        ReportType = Request.QueryString("ReportType").ToLower
                    End If
                Catch
                End Try

                Dim MyReport As DotNetNuke.Entities.Modules.PortalModuleBase
                Select Case ReportType.ToLower
                    Case "report1"
                        MyReport = CType(LoadControl(ModulePath & "rptReport1.ascx"), rptReport1)
                        MyReport.ID = "rptReport1"
                    Case "rvsalessummary"
                        MyReport = CType(LoadControl(ModulePath & "rvSalesSummary.ascx"), rvSalesSummary)
                        MyReport.ID = "rvSalesSummary"
                        'Case "radsalessummary"
                        '    MyReport = CType(LoadControl(ModulePath & "radSalesSummary.ascx"), radSalesSummary)
                        '    MyReport.ID = "radSalesSummary"
                    Case "rvsysinquiry"
                        MyReport = CType(LoadControl(ModulePath & "rvSysInquiry.ascx"), rvSysInquiry)
                        MyReport.ID = "rvSysInquiry"
                    Case "rvdrvcerti"
                        MyReport = CType(LoadControl(ModulePath & "rvDrvCerti.ascx"), rvDrvCerti)
                        MyReport.ID = "rvDrvCerti"
                    Case "report2driver"
                        MyReport = CType(LoadControl(ModulePath & "rptReport2Driver.ascx"), rptReport2Driver)
                        MyReport.ID = "rptReport2Driver"
                    Case "rvloadstatusdriver"
                        MyReport = CType(LoadControl(ModulePath & "rvLoadStatusDriver.ascx"), rvLoadStatusDriver)
                        MyReport.ID = "rvLoadStatusDriver"

                    Case "report2broker"
                        MyReport = CType(LoadControl(ModulePath & "rptReport2Broker.ascx"), rptReport2Broker)
                        MyReport.ID = "rptReport2Broker"
                    Case "rvloadstatusbroker"
                        MyReport = CType(LoadControl(ModulePath & "rvLoadStatusBroker.ascx"), rvLoadStatusBroker)
                        MyReport.ID = "rvLoadStatusBroker"

                    Case "report3"
                        MyReport = CType(LoadControl(ModulePath & "rptReport3.ascx"), rptReport3)
                        MyReport.ID = "rptReport3"
                    Case "rvloadstatusreview"
                        MyReport = CType(LoadControl(ModulePath & "rvLoadStatusReview.ascx"), rvLoadStatusReview)
                        MyReport.ID = "rvLoadStatusReview"

                    Case "driverstatus"
                        MyReport = CType(LoadControl(ModulePath & "rptDriverStatus.ascx"), rptDriverStatus)
                        MyReport.ID = "rptDriverStatus"
                    Case "rvdriverstatus"
                        MyReport = CType(LoadControl(ModulePath & "rvDriverStatus.ascx"), rvDriverStatus)
                        MyReport.ID = "rvDriverStatus"
                        'Case "raddriverstatus"
                        '    MyReport = CType(LoadControl(ModulePath & "radDriverStatus.ascx"), radDriverStatus)
                        '    MyReport.ID = "radDriverStatus"
                        'Case "crdriverstatus"
                        '    MyReport = CType(LoadControl(ModulePath & "crDriverStatus.ascx"), crDriverStatus)
                        '    MyReport.ID = "crDriverStatus"

                    Case "reportxmission"
                        MyReport = CType(LoadControl(ModulePath & "rptXmission.ascx"), rptXmission)
                        MyReport.ID = "rptXmission"
                    Case "rvxmission"
                        MyReport = CType(LoadControl(ModulePath & "rvXmission.ascx"), rvXmission)
                        MyReport.ID = "rvXmission"

                    Case "rvcontainer"
                        MyReport = CType(LoadControl(ModulePath & "rvContainer.ascx"), rvContainer)
                        MyReport.ID = "rvContainer"

                    Case "confirmreport"
                        MyReport = CType(LoadControl(ModulePath & "rptLoadConfirm.ascx"), rptLoadConfirm)
                        MyReport.ID = "rptLoadConfirm"
                    Case "loadconfirm"
                        MyReport = CType(LoadControl(ModulePath & "rvLoadConfirm.ascx"), rvLoadConfirm)
                        MyReport.ID = "rvLoadConfirm"

                        'Case "loadreport"
                        '    MyReport = CType(LoadControl(ModulePath & "rvLoadReport.ascx"), rvLoadReport)
                        '    MyReport.ID = "rvLoadReport"
                    Case Else '"loadreport"
                        If (Not Request.QueryString("LoadType") Is Nothing) OrElse (Request.QueryString("LoadType") <> "") Then
                            MyReport = CType(LoadControl(ModulePath & "rptLoadSheetInit.ascx"), rptLoadSheetInit)
                            MyReport.ID = "rptLoadSheetInit"
                        Else
                            MyReport = CType(LoadControl(ModulePath & "rvLoadReport.ascx"), rvLoadReport)
                            MyReport.ID = "rvLoadReport"
                        End If
                End Select

                MyReport.ModuleConfiguration = ModuleConfiguration
                'If MyReport.ID = "rptLoadConfirm" Then
                '    Run_iTextSharp(MyReport)
                'Else
                '    Controls.Add(MyReport)
                'End If
                Controls.Add(MyReport)

                'Dim MyEditItem As EditItem = CType(LoadControl(ModulePath & "EditItem.ascx"), EditItem)
                'With MyEditItem
                '    '.ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditItem.ascx")
                '    .ModuleConfiguration = ModuleConfiguration
                '    .ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditItem.ascx")
                'End With 'MyEditItem
                'Controls.Add(MyEditItem)

            Catch exc As Exception
                ProcessModuleLoadException(Me, exc)
            End Try
        End Sub
        'Private Sub Run_iTextSharp(ByVal MyReport As DotNetNuke.Entities.Modules.PortalModuleBase)
        '    Dim doc As Document = New Document
        '    PdfWriter.GetInstance(doc, New FileStream(Server.MapPath("~/Documentation/" + MyReport.ID + ".pdf"), FileMode.Create))
        '    doc.Open()
        '    doc.Add(MyReport)
        '    doc.Close()
        '    Response.Redirect("~/Documentation/" + MyReport.ID + ".pdf")
        'End Sub
#End Region

    End Class 'Reports

End Namespace 'bhattji.Modules.LoadSheets
