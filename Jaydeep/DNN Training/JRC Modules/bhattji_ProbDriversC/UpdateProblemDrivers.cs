using System;
//using System.Collections.Generic;
using DotNetNuke.Services.Scheduling;
using DotNetNuke.Services.Exceptions;

namespace bhattji.Scheduler.ProblemDrivers
{
    public class UpdateProblemDrivers : SchedulerClient
    {
        public UpdateProblemDrivers(ScheduleHistoryItem objScheduleHistoryItem)
            : base()
        {
            this.ScheduleHistoryItem = objScheduleHistoryItem;
        }

        public override void DoWork()
        {
            string ScheduleNote = "";
            try
            {
                //Perform required items for logging
                this.Progressing();

                //Your code goes here
                //Update SalesPersons For ProbDriver
                bhattji.Modules.SalesPersons.Business.SalesPersonsController objSPC = new bhattji.Modules.SalesPersons.Business.SalesPersonsController();
                objSPC.UpdateSalesPersons4ProbDriver();
                ScheduleNote += "Updated Drivers for 'Problem Driver' Flag. \n";

                //Update InterOffices For HasProbDrivers
                bhattji.Modules.InterOffices.Business.InterOfficesController objIOC = new bhattji.Modules.InterOffices.Business.InterOfficesController();
                objIOC.UpdateInterOffices4HasProbDrivers();
                ScheduleNote += "Updated InterOffices for 'Has Problem Drivers' Flag. \n";

                //Show success
                this.ScheduleHistoryItem.Succeeded = true;

                //To log note
                this.ScheduleHistoryItem.AddLogNote(ScheduleNote);

            }
            catch (Exception ex)
            {
                //Show failure
                this.ScheduleHistoryItem.Succeeded = false;

                // log the exception into the scheduler framework
                ScheduleNote += "EXCEPTION: " + ex.ToString();
                this.ScheduleHistoryItem.AddLogNote(ScheduleNote);
                //InsertLogNote("Exception = " & ex.ToString())

                // call the Errored method
                this.Errored(ref ex);

                // log the exception into the DNN core
                Exceptions.LogException(ex);

            }
        }
    }
}