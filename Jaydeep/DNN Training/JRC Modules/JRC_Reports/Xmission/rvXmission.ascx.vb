Imports Microsoft.Reporting.WebForms
Imports System.Data

Partial Class rvLoadConfirm
    Inherits System.Web.UI.UserControl

    Shared ModulePath As String
    Shared itemId As Integer


    Private Sub RunReport()
        ' Set the processing mode for the ReportViewer to Local 
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.ShowToolBar = False
        'ReportViewer1.ShowRefreshButton = True
        'ReportViewer1.ShowZoomControl = False
        'ReportViewer1.ShowPrintButton = True

        'ReportViewer1.ShowExportControls = False
        'ReportViewer1.ShowFindControls = False
        'ReportViewer1.ShowPageNavigationControls = False

        ReportViewer1.LocalReport.ReportPath = Server.MapPath(ModulePath + "Reports/Xmission.rdlc")

        'ReportViewer1.LocalReport.ListRenderingExtensions[1]
        'RenderingExtension re= New RenderingExtension();
        Dim ctrl As New LoadSheetsController
        Dim dt As DataTable = ctrl.GetReportXmission("000008010")

        'If chkSortDesc.Checked Then
        '    dt.DefaultView.Sort = ddlSort.SelectedValue & " DESC"
        'Else
        '    dt.DefaultView.Sort = ddlSort.SelectedValue
        'End If

        Dim ReportDataSource1 As New ReportDataSource("DataSet1_DataTable1", dt)

        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Request.QueryString("ItemId") Is Nothing) Then
            itemId = Int32.Parse(Request.QueryString("ItemId"))
            If Not Page.IsPostBack Then
                ModulePath = Request.ApplicationPath & "/"

                RunReport()
            End If


        Else
            Response.Write("Item id not defined")
        End If
    End Sub
End Class
