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

Namespace bhattji.Modules.LoadSheets

    Public MustInherit Class Edits
        Inherits Entities.Modules.PortalModuleBase

#Region " Private Members "
#End Region

#Region " Public Methods "

#End Region

#Region " Event Handlers "

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                'Dim objOI As New OptionsInfo(ModuleId)
                Dim EditType As String = "edititem"
                Try
                    If (Not Request.QueryString("EditType") Is Nothing) OrElse (Request.QueryString("EditType") <> "") Then
                        EditType = Request.QueryString("EditType").ToLower
                    End If
                Catch
                End Try

                'Select Case EditType
                '    Case "editalt"
                '        Dim MyEditAlt As EditAlt = CType(LoadControl(ModulePath & "EditAlt.ascx"), EditAlt)
                '        With MyEditAlt
                '            '.ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditAlt.ascx")
                '            .ModuleConfiguration = ModuleConfiguration
                '            .ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditAlt.ascx")
                '        End With 'MyEditAlt
                '        Controls.Add(MyEditAlt)

                '    Case Else '"edititem", "EditItem"
                '        Dim MyEditItem As EditItem = CType(LoadControl(ModulePath & "EditItem.ascx"), EditItem)
                '        With MyEditItem
                '            '.ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditItem.ascx")
                '            .ModuleConfiguration = ModuleConfiguration
                '            .ID = System.IO.Path.GetFileNameWithoutExtension(ModulePath & "EditItem.ascx")
                '        End With 'MyEditItem
                '        Controls.Add(MyEditItem)
                'End Select

                Dim MyEdit As DotNetNuke.Entities.Modules.PortalModuleBase
                'Select Case EditType.ToLower
                '    Case "editcat"
                '        'MyEdit = CType(LoadControl(ModulePath & "EditCategories.ascx"), EditCategories)
                '        'MyEdit.ID = "EditCategories"
                '    Case Else '"edititem", "EditItem"
                '        MyEdit = CType(LoadControl(ModulePath & "EditItem.ascx"), EditItem)
                '        MyEdit.ID = "EditItem"
                'End Select
                If ((Request.QueryString("ItemId") Is Nothing) OrElse (Request.QueryString("ItemId") = "")) AndAlso ((Request.QueryString("EditLoadType") Is Nothing) OrElse (Request.QueryString("EditLoadType") = "")) Then
                    'If (Request.QueryString("ItemId") Is Nothing) OrElse (Request.QueryString("ItemId") = "") Then
                    MyEdit = CType(LoadControl(ModulePath & "AddLoad.ascx"), AddLoad)
                    MyEdit.ID = "AddLoad"
                    'ElseIf (Request.QueryString("EditLoadType").ToLower = "editpudrops") Then
                    '    MyEdit = CType(LoadControl(ModulePath & "EditPUDrops.ascx"), EditPUDrops)
                    '    MyEdit.ID = "EditPUDrops"
                Else
                    MyEdit = CType(LoadControl(ModulePath & "EditItem.ascx"), EditItem)
                    MyEdit.ID = "EditItem"
                End If
                'MyEdit.ModuleConfiguration = ModuleConfiguration
                'Controls.Add(MyEdit)

                ModuleConfiguration.ModuleTitle = Localization.GetString(MyEdit.ID & "Title", LocalResourceFile)
                MyEdit.ModuleConfiguration = ModuleConfiguration

                If AJAX.IsInstalled Then 'AndAlso (MyEdit.ID = "AddLoad") Then
                    AJAX.RegisterScriptManager()

                    Dim pnlBhattji As New Panel()
                    pnlBhattji.ID = "pnlBhattji"
                    pnlBhattji.Style.Add(HtmlTextWriterStyle.Position, "relative")
                    pnlBhattji.Controls.Add(MyEdit)

                    'AJAX.WrapUpdatePanelControl(pnlBhattji, True)
                    Dim AjaxPanel As New UpdatePanel()
                    AjaxPanel.ID = "updtpnlBhattji"
                    AjaxPanel.UpdateMode = UpdatePanelUpdateMode.Conditional
                    AjaxPanel.ContentTemplateContainer.Controls.Add(pnlBhattji)

                    'Dim imgProgress As New Image
                    'imgProgress.ImageUrl = "~/images/progressbar.gif"

                    'Dim tbl As New HtmlTable
                    'tbl.Attributes.Add(HtmlTextWriterAttribute.Width, "100%")
                    'tbl.Attributes.Add(HtmlTextWriterAttribute.Class, "UpdateProgressClass")

                    'Dim tr As New HtmlTableRow
                    'Dim td As New HtmlTableCell
                    'td.Attributes.Add(HtmlTextWriterAttribute.Align, "center")
                    'td.Attributes.Add(HtmlTextWriterAttribute.Valign, "middle")
                    'td.Controls.Add(imgProgress)
                    'tr.Cells.Add(td)
                    'tbl.Rows.Add(tr)

                    'Dim updtProgress As New UpdateProgress()
                    'updtProgress.ID = "updtProgressMain"

                    '' Create the ProgressTemplate based on a class the implements ITemplate.
                    'Dim MyProgressTemplate As New MyTemplate()
                    'updtProgress.ProgressTemplate = MyProgressTemplate

                    'updtProgress.Controls.Add(tbl)

                    'AjaxPanel.ContentTemplateContainer.Controls.Add(updtProgress)

                    phtEdits.Controls.Add(AjaxPanel)
                Else
                    phtEdits.Controls.Add(MyEdit)
                End If


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

#End Region

    End Class 'Edits

    ' THIS GOES IN YOUR PAGES CODE BEHIND ALSO!
    Public Class MyTemplate : Implements ITemplate

        Public Sub InstantiateIn(ByVal container As Control) Implements Web.UI.ITemplate.InstantiateIn
            ' This is empty.
        End Sub

    End Class

End Namespace 'bhattji.Modules.LoadSheets
