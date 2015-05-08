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

namespace YourCompany.Modules.DnnTest
{

    /// ----------------------------------------------------------------------------- 
    /// <summary> 
    /// The Info class for DnnTest 
    /// </summary> 
    /// <remarks> 
    /// </remarks> 
    /// <history> 
    /// </history> 
    /// ----------------------------------------------------------------------------- 
    public class DnnTestInfo
    {
        // local property declarations 
        private int _ModuleId;
        private int _ItemId;
        private string _Title;
        private string _Content;
        private int _CreatedByUser;
        private DateTime _CreatedDate;
        private string _CreatedByUserName;

        // initialization 
        public DnnTestInfo()
        {
        }

        // public properties 
        public int ModuleId
        {
            get { return _ModuleId; }
            set { _ModuleId = value; }
        }

        public int ItemId
        {
            get { return _ItemId; }
            set { _ItemId = value; }
        }


        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        public int CreatedByUser
        {
            get { return _CreatedByUser; }
            set { _CreatedByUser = value; }
        }

        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }

        public string CreatedByUserName
        {
            get { return _CreatedByUserName; }
            set { _CreatedByUserName = value; }
        }
    }

}