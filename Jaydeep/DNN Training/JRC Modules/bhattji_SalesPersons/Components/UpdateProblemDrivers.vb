'using System.Collections.Generic;
Imports DotNetNuke.Services.Scheduling
Imports DotNetNuke.Services.Exceptions

Namespace bhattji.Scheduler.ProblemDrivers
    Public Class UpdateProblemDrivers
        Inherits SchedulerClient
        Public Sub New(ByVal objScheduleHistoryItem As ScheduleHistoryItem)
            MyBase.New()
            Me.ScheduleHistoryItem = objScheduleHistoryItem
        End Sub

        Public Overrides Sub DoWork()
            Dim ScheduleNote As String = ""
            Try
                'Perform required items for logging
                Me.Progressing()

                'Your code goes here
                'Update SalesPersons For ProbDriver
                Dim objSPC As New bhattji.Modules.SalesPersons.Business.SalesPersonsController()
                objSPC.UpdateSalesPersons4ProbDriver()
                ScheduleNote &= "Updated Drivers for 'Problem Driver' Flag. " & vbCrLf

                'Update InterOffices For HasProbDrivers
                Dim objIOC As New bhattji.Modules.InterOffices.Business.InterOfficesController()
                objIOC.UpdateInterOffices4HasProbDrivers()
                ScheduleNote &= "Updated InterOffices for 'Has Problem Drivers' Flag. " & vbCrLf

                'Show success
                Me.ScheduleHistoryItem.Succeeded = True

                'To log note

                Me.ScheduleHistoryItem.AddLogNote(ScheduleNote)
            Catch ex As Exception
                'Show failure
                Me.ScheduleHistoryItem.Succeeded = False

                ' log the exception into the scheduler framework
                ScheduleNote &= "EXCEPTION: " & ex.ToString()
                Me.ScheduleHistoryItem.AddLogNote(ScheduleNote)
                'InsertLogNote("Exception = " & ex.ToString())

                ' call the Errored method
                Me.Errored(ex)

                ' log the exception into the DNN core

                Exceptions.LogException(ex)
            End Try
        End Sub
    End Class
End Namespace
