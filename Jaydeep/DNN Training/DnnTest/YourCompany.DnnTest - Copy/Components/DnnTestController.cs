// 
// DotNetNuke® - http://www.dotnetnuke.com 
// Copyright (c) 2002-2012 
// by DotNetNuke Corporation 
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions: 
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software. 
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE. 
// 

using System;
using System.Configuration;
using System.Data;
using System.Xml;
using System.Web;
using System.Collections.Generic;

using DotNetNuke;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Search;
using DotNetNuke.Entities.Modules;

namespace YourCompany.Modules.DnnTest
{

    /// ----------------------------------------------------------------------------- 
    /// <summary> 
    /// The Controller class for DnnTest 
    /// </summary> 
    /// <remarks> 
    /// </remarks> 
    /// <history> 
    /// </history> 
    /// ----------------------------------------------------------------------------- 
    public class DnnTestController : ISearchable, IPortable
    {

        #region "Public Methods"

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// gets an object from the database 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="ModuleId">The Id of the module</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public List<DnnTestInfo> GetDnnTests(int ModuleId)
        {

            return CBO.FillCollection<DnnTestInfo>(DataProvider.Instance().GetDnnTests(ModuleId));

        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// gets an object from the database 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="ModuleId">The Id of the module</param> 
        /// <param name="ItemId">The Id of the item</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public DnnTestInfo GetDnnTest(int ModuleId, int ItemId)
        {

            return (DnnTestInfo)CBO.FillObject(DataProvider.Instance().GetDnnTest(ModuleId, ItemId), typeof(DnnTestInfo));

        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// adds an object to the database 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="objDnnTest">The DnnTestInfo object</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public void AddDnnTest(DnnTestInfo objDnnTest)
        {

            if (objDnnTest.Content.Trim() != "")
            {
                DataProvider.Instance().AddDnnTest(objDnnTest.ModuleId, objDnnTest.Title, objDnnTest.Content, objDnnTest.CreatedByUser);
            }

        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// saves an object to the database 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="objDnnTest">The DnnTestInfo object</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public void UpdateDnnTest(DnnTestInfo objDnnTest)
        {

            if (objDnnTest.Content.Trim() != "")
            {
                DataProvider.Instance().UpdateDnnTest(objDnnTest.ModuleId, objDnnTest.ItemId, objDnnTest.Title, objDnnTest.Content, objDnnTest.CreatedByUser);
            }

        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// deletes an object from the database 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="ModuleId">The Id of the module</param> 
        /// <param name="ItemId">The Id of the item</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public void DeleteDnnTest(int ModuleId, int ItemId)
        {

            DataProvider.Instance().DeleteDnnTest(ModuleId, ItemId);

        }

        #endregion

        #region "Optional Interfaces"

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// GetSearchItems implements the ISearchable Interface 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(ModuleInfo ModInfo)
        {

            SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

            List<DnnTestInfo> colDnnTests = GetDnnTests(ModInfo.ModuleID);
            foreach (DnnTestInfo objDnnTest in colDnnTests)
            {
                SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objDnnTest.Content, objDnnTest.CreatedByUser, objDnnTest.CreatedDate, ModInfo.ModuleID, objDnnTest.ItemId.ToString(), objDnnTest.Content, "ItemId=" + objDnnTest.ItemId.ToString());
                SearchItemCollection.Add(SearchItem);
            }

            return SearchItemCollection;

        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// ExportModule implements the IPortable ExportModule Interface 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="ModuleID">The Id of the module to be exported</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public string ExportModule(int ModuleID)
        {

            string strXML = "";

            List<DnnTestInfo> colDnnTests = GetDnnTests(ModuleID);
            if (colDnnTests.Count != 0)
            {
                strXML += "<DnnTests>";
                foreach (DnnTestInfo objDnnTest in colDnnTests)
                {
                    strXML += "<DnnTest>";
                    strXML += "<Title>" + XmlUtils.XMLEncode(objDnnTest.Title) + "</Title>";
                    strXML += "<content>" + XmlUtils.XMLEncode(objDnnTest.Content) + "</content>";
                    strXML += "</DnnTest>";
                }
                strXML += "</DnnTests>";
            }

            return strXML;

        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// ImportModule implements the IPortable ImportModule Interface 
        /// </summary> 
        /// <remarks> 
        /// </remarks> 
        /// <param name="ModuleID">The Id of the module to be imported</param> 
        /// <param name="Content">The content to be imported</param> 
        /// <param name="Version">The version of the module to be imported</param> 
        /// <param name="UserId">The Id of the user performing the import</param> 
        /// <history> 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public void ImportModule(int ModuleID, string Content, string Version, int UserId)
        {

            XmlNode xmlDnnTests = Globals.GetContent(Content, "DnnTests");
            foreach (XmlNode xmlDnnTest in xmlDnnTests.SelectNodes("DnnTest"))
            {
                DnnTestInfo objDnnTest = new DnnTestInfo();
                objDnnTest.ModuleId = ModuleID;
                objDnnTest.Title = xmlDnnTest.SelectSingleNode("Title").InnerText;
                objDnnTest.Content = xmlDnnTest.SelectSingleNode("content").InnerText;
                objDnnTest.CreatedByUser = UserId;
                AddDnnTest(objDnnTest);
            }

        }

        #endregion

    }
}