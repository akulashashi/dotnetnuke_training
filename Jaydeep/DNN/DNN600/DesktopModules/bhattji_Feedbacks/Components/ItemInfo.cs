using System;
using System.Xml;
using DotNetNuke.Services.Search;
using DotNetNuke.Common.Utilities;
using System.Text;
using System.Collections;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Definitions;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Security.Permissions;
using DotNetNuke.Common;


namespace bhattji.Modules.Feedbacks
{
    public class FeedbacksController : ISearchable, IPortable, IUpgradeable
    {
        #region " Optional Interface(s) Implementation "
        #region " ISearchable Members "
        public SearchItemInfoCollection GetSearchItems(ModuleInfo ModInfo)
        {
            SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();
            //IEnumerable<FeedbackInfo> lotFeedbacks = GetModuleFeedbacks(ModInfo.ModuleID);
            ////FeedbackInfo objFeedback;
            //foreach (FeedbackInfo objFeedback in lotFeedbacks)
            //{
            //    SearchItemInfo SearchItem;

            //    int UserId = objFeedback.CreatedByUserId;

            //    string strContent = HttpUtility.HtmlDecode(((FeedbackInfo)objFeedback).Title + " " + ((FeedbackInfo)objFeedback).Description);
            //    string strDescription = HtmlUtils.Shorten(HtmlUtils.Clean(HttpUtility.HtmlDecode(((FeedbackInfo)objFeedback).Description + " " + ((FeedbackInfo)objFeedback).Details), false), 100, "...");

            //    SearchItem = new SearchItemInfo(ModInfo.ModuleTitle + " - " + ((FeedbackInfo)objFeedback).Title, strDescription, UserId, ((FeedbackInfo)objFeedback).CreatedDate, ModInfo.ModuleID, ((FeedbackInfo)objFeedback).ItemId.ToString(), strContent, "ItemId=" + ((FeedbackInfo)objFeedback).ItemId.ToString(), Null.NullInteger);
            //    SearchItemCollection.Add(SearchItem);

            //}
            return SearchItemCollection;
        }
        #endregion //" ISearchable Members "
        #region " IPortable Members "
        public string ExportModule(int ModuleID)
        {
            OptionsInfo objOI = new OptionsInfo(ModuleID);
            StringBuilder sbXML = new StringBuilder();
            sbXML.Append("<Feedbacks>");
            
            //Export the Module Settings
            //Control Options
            sbXML.Append("<OnlyHostCanEdit>" + XmlUtils.XMLEncode(objOI.OnlyHostCanEdit.ToString()) + "</OnlyHostCanEdit>");

            sbXML.Append("<EmailTo>" + XmlUtils.XMLEncode(objOI.EmailTo) + "</EmailTo>");
            sbXML.Append("<EmailCc>" + XmlUtils.XMLEncode(objOI.EmailCc) + "</EmailCc>");
            sbXML.Append("<EmailBcc>" + XmlUtils.XMLEncode(objOI.EmailBcc) + "</EmailBcc>");
            sbXML.Append("<SubscriptionRole>" + XmlUtils.XMLEncode(objOI.SubscriptionRole) + "</SubscriptionRole>");
                        
            sbXML.Append("<UpdatedByUserId>" + XmlUtils.XMLEncode(objOI.UpdatedByUserId.ToString()) + "</UpdatedByUserId>");
            sbXML.Append("<UpdatedByUser>" + XmlUtils.XMLEncode(objOI.UpdatedByUser) + "</UpdatedByUser>");
            sbXML.Append("<UpdatedDate>" + XmlUtils.XMLEncode(objOI.UpdatedDate.ToString()) + "</UpdatedDate>");

            //Option1 Options

            sbXML.Append("</Feedbacks>");

            return sbXML.ToString();

        }
        public void ImportModule(int ModuleID, string Content, string Version, int UserId)
        {
            XmlNode xmlFeedbacks = Globals.GetContent(Content, "Feedbacks");
            

            //Import the Module Settings
            ModuleController objModules = new ModuleController();
            OptionsInfo objOI = new OptionsInfo();

            //.ModuleID = ModuleID

            //Control Options
            try { objOI.OnlyHostCanEdit = bool.Parse(xmlFeedbacks.SelectSingleNode("OnlyHostCanEdit").InnerText); }catch { }

            try { objOI.EmailTo = xmlFeedbacks.SelectSingleNode("EmailTo").InnerText; }
            catch { }
            try { objOI.EmailCc = xmlFeedbacks.SelectSingleNode("EmailCc").InnerText; }
            catch { }
            try { objOI.EmailBcc = xmlFeedbacks.SelectSingleNode("EmailBcc").InnerText; }
            catch { }
            try { objOI.SubscriptionRole = xmlFeedbacks.SelectSingleNode("SubscriptionRole").InnerText; }
            catch { }
            
            try{objOI.UpdatedByUserId = int.Parse(xmlFeedbacks.SelectSingleNode("UpdatedByUserId").InnerText);}catch{}
            try{objOI.UpdatedByUser = xmlFeedbacks.SelectSingleNode("UpdatedByUser").InnerText;}catch{}
            try { objOI.UpdatedDate = DateTime.Parse(xmlFeedbacks.SelectSingleNode("UpdatedDate").InnerText); }catch { }
            
            objOI.Update(ModuleID);
        }
        #endregion //" IPortable Members "
        #region " IUpgradeable Members "
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Implements the upgrade interface for DotNetNuke
        /// </summary>
        /// <history>
        /// [scullmann] 12/30/2005 First Implementation
        /// </history>
        /// -----------------------------------------------------------------------------
        public string UpgradeModule(string Version)
        {
            InitPermissions();
            //SetPortalSettings();
            return Version;
        }

        private void SetPortalSettings()
        {
            PortalController.UpdatePortalSetting(0, "ControlPanelSecurity", "TAB");
            PortalController.UpdatePortalSetting(0, "ControlPanelVisibility", "MIN");
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// adds the module specific permissions
        /// </summary>
        /// <history>
        /// [scullmann] 12/30/2005 First Implementation
        /// </history>
        /// -----------------------------------------------------------------------------
        private void InitPermissions()
        {
            //Definition
            string ModuleFriendlyName = "bhattji.Feedbacks";
            string ModuleName = "bhattji.Feedbacks";

            //Permissions
            string Code = "bhattji.Feedbacks_PERMISSION";
            string[] permissionKeys = new string[6] { "ADD", "ALTER", "APPROVE", "CONFIGURE", "DELETE", "SELFEDIT" };
            string[] permissionNames = new string[6] { "Add Feedback", "Alter Feedback", "Approve Feedback", "Configure Feedback", "Delete Feedback", "SelfEdit Feedback" };

            //PermissionFlags
            PermissionController pc = new PermissionController();
            ArrayList permissions = pc.GetPermissionByCodeAndKey(Code, null);
            DesktopModuleController dc = new DesktopModuleController();
            DesktopModuleInfo desktopInfo = dc.GetDesktopModuleByModuleName(ModuleName);
            ModuleDefinitionController mc = new ModuleDefinitionController();
            ModuleDefinitionInfo mInfo = ModuleDefinitionController.GetModuleDefinitionByFriendlyName(ModuleFriendlyName, desktopInfo.DesktopModuleID);
            int moduleDefId = mInfo.ModuleDefID;

            for (int i = 0; i < permissionKeys.GetLength(0); i++)
            {
                foreach (PermissionInfo p in permissions)
                {
                    if ((p.ModuleDefID == moduleDefId) && (p.PermissionKey == permissionKeys[i]))
                    {
                        permissionKeys[i] = "permissionExists";
                        break;
                    }
                }
                if (permissionKeys[i] != "permissionExists")
                {
                    PermissionInfo p = new PermissionInfo();
                    p.ModuleDefID = moduleDefId;
                    p.PermissionCode = Code;
                    p.PermissionKey = permissionKeys[i];//"MODERATEPOSTS";
                    p.PermissionName = permissionNames[i];//"Moderate Posts";
                    pc.AddPermission(p);
                }
            }
        }//InitPermissions

        #endregion //" IUpgradeable Members "
        #endregion //" Optional Interface(s) Implementation "
    } //FeedbacksController
} //bhattji.Modules.Feedbacks