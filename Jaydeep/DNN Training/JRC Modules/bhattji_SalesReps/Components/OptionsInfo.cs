//
// DotNetNuke -  http://www.dotnetnuke.com
// Copyright (c) 2002-2005
// by Jaydeep Bhatt ( sales@bhattji.com ) of Vision Consultants. ( http://www.bhattji.com )
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, PublishDate, distribute, sublicense, and/or sell copies of the Software, and 
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

#region " Namespaces "
//Imports System
using System.Collections;
//Imports System.Configuration
//Imports System.Data
using System.Web.UI.WebControls;
using DotNetNuke;
using System;
using System.Web;
using System.IO;
#endregion

namespace bhattji.Modules.SalesReps
{

	/// -----------------------------------------------------------------------------
	/// <summary>
	/// The Options Class provides the TabbedPages Business Object
	/// </summary>
	///
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[bhattji]	9/20/2004	Moved TabbedPages to a separate Project
	/// </history>
	/// -----------------------------------------------------------------------------
	/// 

	public class OptionsInfo : Hashtable
	{
		//Inherits Specialized.NameValueCollection

		#region " Private Members "
		//Private ModSets As New Hashtable
		#endregion

		#region " Properties "

		private int _ModuleID;
		public int ModuleID {
			get { return _ModuleID; }
			set { _ModuleID = value; }
		}


		//Common Properties

		public int ItemsScope {
			get { return GetInteger("ItemsScope", 0); }
			set { SetString("ItemsScope", value.ToString()); }
		}

		public int CategoriesScope {
			get { return GetInteger("CategoriesScope", 2); }
			set { SetString("CategoriesScope", value.ToString()); }
		}

		public bool OnlyHostCanEdit {
			get { return GetBoolean("OnlyHostCanEdit", false); }
			set { SetString("OnlyHostCanEdit", value.ToString()); }
		}

		public string ViewControl {
			get { return GetString("ViewControl", "List"); }
			set { SetString("ViewControl", value); }
		}

		public bool HideSearch {
			get { return GetBoolean("HideSearch", false); }
			set { SetString("HideSearch", value.ToString()); }
		}

		public bool AddDescription {
			get { return GetBoolean("AddDescription", true); }
			set { SetString("AddDescription", value.ToString()); }
		}

		public string BackColor {
			get { return GetString("BackColor", "White"); }
			set { SetString("BackColor", value); }
		}

		public string AltColor {
			get { return GetString("AltColor", "LightGoldenrodYellow"); }
			set { SetString("AltColor", value); }
		}

		public string SelectedColor {
			get { return GetString("SelectedColor", "GoldenrodYellow"); }
			set { SetString("SelectedColor", value); }
		}

		public string HeaderBackColor {
			get { return GetString("HeaderBackColor", "PaleGoldenrod"); }
			set { SetString("HeaderBackColor", value); }
		}

		public string PagerBackColor {
			get { return GetString("PagerBackColor", "PaleGoldenrod"); }
			set { SetString("PagerBackColor", value); }
		}

		public string TabCss {
			get { return GetString("TabCss", "tab.luna.css"); }
			set { SetString("TabCss", value); }
		}

		public int PagerSize {
			get { return GetInteger("PagerSize", 10); }
			set { SetString("PagerSize", value.ToString()); }
		}

		public int NoOfPages {
			get { return GetInteger("NoOfPages", 10); }
			set { SetString("NoOfPages", value.ToString()); }
		}

		public int NoOfItems {
			get {
				try {
					return (int)(PagerSize > 0 ? PagerSize : 10) * (int)(NoOfPages > 0 ? NoOfPages : 10);
				}
				catch {
					return 100;
				}
			}
		}

		public bool DeleteFromGrid {
			get { return GetBoolean("DeleteFromGrid", false); }
			set { SetString("DeleteFromGrid", value.ToString()); }
		}

		//SalesRep Properties


		//Scroller Properties
		//Private _ViewOption As String = "V"
		public string ViewOption {
			get { return GetString("ViewOption", "V"); }
			set { SetString("ViewOption", value); }
		}

		public string AddDate {
			get { return GetString("AddDate", "N"); }
			set { SetString("AddDate", value); }
		}

		//Private _ImagePosition As String = String.Empty
		public string ImagePosition {
			get { return GetString("ImagePosition", "ZR"); }
			set { SetString("ImagePosition", value.ToString()); }
		}

		//Private _DynamicThumb As Boolean = True
		public bool DynamicThumb {
			get { return GetBoolean("DynamicThumb", true); }
			set { SetString("DynamicThumb", value.ToString()); }
		}

		public string UpdateRedirection {
			get { return GetString("UpdateRedirection", "Listing"); }
			set { SetString("UpdateRedirection", value); }
		}

		//Private _ScrollColumns As String = "0"
		public int ScrollColumns {
			get { return GetInteger("ScrollColumns", 0); }
			set { SetString("ScrollColumns", value.ToString()); }
		}

		//Private _TextMode As String = "False"
		public bool TextMode {
			get { return GetBoolean("TextMode", false); }
			set { SetString("TextMode", value.ToString()); }
		}

		//Private _DisplayInfo As String = "False"
		public bool DisplayInfo {
			get { return GetBoolean("DisplayInfo", false); }
			set { SetString("DisplayInfo", value.ToString()); }
		}

		//Private _ThumbWidth As String
		public string ThumbWidth {
			get { return GetString("ThumbWidth", ""); }
			set { SetString("ThumbWidth", value); }
		}

		//Private _ThumbHeight As String
		public string ThumbHeight {
			get { return GetString("ThumbHeight", ""); }
			set { SetString("ThumbHeight", value); }
		}

		//Private _ThumbColumns As Integer = 5
		public int ThumbColumns {
			get { return GetInteger("ThumbColumns", 5); }
			set { SetString("ThumbColumns", value.ToString()); }
		}

		//Private _HideTextLink As Boolean = False
		public bool HideTextLink {
			get { return GetBoolean("HideTextLink", false); }
			set { SetString("HideTextLink", value.ToString()); }
		}

		//Private _InfoCssClass As String = String.Empty
		public string InfoCssClass {
			get { return GetString("InfoCssClass", ""); }
			set { SetString("InfoCssClass", value); }
		}




		//Scroller Properties
		//Private _ScrollBehavior As String = "OFF"
		public string ScrollBehavior {
			get { return GetString("ScrollBehavior", "OFF"); }
			set { SetString("ScrollBehavior", value); }
		}

		public bool ScrollON {
			get { return (ScrollBehavior.ToUpper() == "SCROLL") || (ScrollBehavior.ToUpper() == "SLIDE") || (ScrollBehavior.ToUpper() == "ALTERNATE"); }
		}

        public string MarqueeStart
        {
            get
            {
                if (ScrollON)
                {
                    string strMarquee = "<marquee behavior=\"" + ScrollBehavior + "\"";
                    if (ScrollDirection != string.Empty)
                    {
                        strMarquee += " direction=\"" + ScrollDirection + "\"";
                    }
                    if (ScrollAmount != string.Empty)
                    {
                        strMarquee += " scrollamount=\"" + ScrollAmount + "\"";
                    }
                    if (ScrollDelay != string.Empty)
                    {
                        strMarquee += " scrolldelay=\"" + ScrollDelay + "\"";
                    }
                    if (ScrollWidth != string.Empty)
                    {
                        strMarquee += " width=\"" + ScrollWidth + "\"";
                    }
                    if (ScrollHeight != string.Empty)
                    {
                        strMarquee += " height=\"" + ScrollHeight + "\"";
                    }
                    strMarquee += " class=\"Normal\" onmouseover=\"this.stop()\" onmouseout=\"this.start()\">";

                    return strMarquee;
                }
                else
                {
                    return string.Empty;
                }
            }
        } 

		public string MarqueeEnd {
			get {
				if (ScrollON)
				{
					return "</marquee>";
				}
				else
				{
					return string.Empty;
				}
			}
		}

		public string ScrollDirection {
			get { return GetString("ScrollDirection", ""); }
			set { SetString("ScrollDirection", value); }
		}

		public string ScrollAmount {
			get { return GetString("ScrollAmount", ""); }
			set { SetString("ScrollAmount", value); }
		}

		public string ScrollDelay {
			get { return GetString("ScrollDelay", ""); }
			set { SetString("ScrollDelay", value); }
		}

		public string ScrollWidth {
			get { return GetString("ScrollWidth", ""); }
			set { SetString("ScrollWidth", value); }
		}

		public string ScrollHeight {
			get { return GetString("ScrollHeight", ""); }
			set { SetString("ScrollHeight", value); }
		}



		//Private _CellPadding As String = "0"
		public string CellPadding {
			get { return GetString("CellPadding", "0"); }
			set { SetString("CellPadding", value); }
		}

		//Private _CellSpacing As String = "5"
		public string CellSpacing {
			get { return GetString("CellSpacing", "5"); }
			set { SetString("CellSpacing", value); }
		}

		//Private _RattleImage As String = "True"
		public bool RattleImage {
			get {
				try {
					return GetBoolean("RattleImage", true);
				}
				catch {
					return true;
				}
			}
			set { SetString("RattleImage", value.ToString()); }
		}



		//SlideShow Properties
		//Private _SSWidth As String
		public string SSWidth {
			get { return GetString("SSWidth", ""); }
			set { SetString("SSWidth", value); }
		}

		//Private _SSHeight As String
		public string SSHeight {
			get { return GetString("SSHeight", ""); }
			set { SetString("SSHeight", value); }
		}

		//Private _Delay As String = "3000"
		public string Delay {
			get { return GetString("Delay", "3000"); }
			set { SetString("Delay", value); }
		}

		//Private _Transition As String = "Pixelate"
		public string Transition {
			get { return GetString("Transition", "Pixelate"); }
			set { SetString("Transition", value); }
		}

		//Private _Thumbnail As String = "False"
		public bool Thumbnail {
			get { return GetBoolean("Thumbnail", false); }
			set { SetString("Thumbnail", value.ToString()); }
		}

		//Private _ThumbnailWidth As String
		public string ThumbnailWidth {
			get { return GetString("ThumbnailWidth", ""); }
			set { SetString("ThumbnailWidth", value); }
		}

		//Private _Resizing As String = "B"
		public string Resizing {
			get { return GetString("Resizing", "B"); }
			set { SetString("Resizing", value); }
		}


		//FlashSlideShow Setting
		//Private _OnlyEmbedTag As String = "True"
		public bool OnlyEmbedTag {
			get { return GetBoolean("OnlyEmbedTag", true); }
			set { SetString("OnlyEmbedTag", value.ToString()); }
		}

		//Private _ShowControls As String = "False"
		public bool ShowControls {
			get { return GetBoolean("ShowControls", false); }
			set { SetString("ShowControls", value.ToString()); }
		}

		//Private _SSTitle As String
		public string SSTitle {
			get { return GetString("SSTitle", ""); }
			set { SetString("SSTitle", value); }
		}

		//Private _CaptionFont As String = "Verdana"
		public string CaptionFont {
			get { return GetString("CaptionFont", "Verdana"); }
			set { SetString("CaptionFont", value); }
		}

		//Private _CaptionSize As String = "10"
		public int CaptionSize {
			get { return GetInteger("CaptionSize", 10); }
			set { SetString("CaptionSize", value.ToString()); }
		}

		//Private _BgColor As String
		public string BgColor {
			get { return GetString("BgColor", ""); }
			set { SetString("BgColor", value); }
		}

		//Private _FSSTransition As String = "Random"
		public string FSSTransition {
			get { return GetString("FSSTransition", "Random"); }
			set { SetString("FSSTransition", value); }
		}


		//ActivePhotoShow Setting
		//Private _Repeat As String = "True"
		public bool Repeat {
			get { return GetBoolean("Repeat", true); }
			set { SetString("Repeat", value.ToString()); }
		}

		//Private _Streaming As String = "False"
		public bool Streaming {
			get { return GetBoolean("Streaming", false); }
			set { SetString("Streaming", value.ToString()); }
		}

		//Private _EffectTime As String = "3"
		public double EffectTime {
			get { return GetDouble("EffectTime", 3); }
			set { SetString("EffectTime", value.ToString()); }
		}

		//Private _TransitionTime As String = "1"
		public int TransitionTime {
			get { return GetInteger("TransitionTime", 1); }
			set { SetString("TransitionTime", value.ToString()); }
		}

		//Private _Volume As String = "50"
		public int Volume {
			get { return GetInteger("Volume", 50); }
			set { SetString("Volume", value.ToString()); }
		}

		//Private _MusicUrl As String = String.Empty
		public string MusicUrl {
			get { return GetString("MusicUrl", ""); }
			set { SetString("MusicUrl", value); }
		}

		//Private _ShowMusicControls As String = "False"
		public bool ShowMusicControls {
			get { return GetBoolean("ShowMusicControls", false); }
			set { SetString("ShowMusicControls", value.ToString()); }
		}


		//Private _ProgressColor As String = "000066"
		public string ProgressColor {
			get { return GetString("ProgressColor", "000066"); }
			set { SetString("ProgressColor", value); }
		}

		//FlashPhotoAlbum Properties
		//Private _TextColor As String = "00FF00"
		public string TextColor {
			get { return GetString("TextColor", "00FF00"); }
			set { SetString("TextColor", value); }
		}

		//Private _ThumbFolder As String = "none"
		public string ThumbFolder {
			get { return GetString("ThumbFolder", "Dynamic"); }
			set { SetString("ThumbFolder", value); }
		}

		//Private _ThumbnailPosition As String = "top"
		public string ThumbnailPosition {
			get { return GetString("ThumbnailPosition", "right"); }
			set { SetString("ThumbnailPosition", value); }
		}

		//Private _ThumbnailRows As String = "1"
		public int ThumbnailRows {
			get { return GetInteger("ThumbnailRows", 5); }
			set { SetString("ThumbnailRows", value.ToString()); }
		}

		//Private _ThumbnailColumns As String = "6"
		public int ThumbnailColumns {
			get { return GetInteger("ThumbnailColumns", 2); }
			set { SetString("ThumbnailColumns", value.ToString()); }
		}


		//NewsTicker Properties
		//Private _NTWidth As String = "160"
		public string NTWidth {
			get { return GetString("NTWidth", "160"); }
			set { SetString("NTWidth", value); }
		}

		//Private _NTHeight As String = "90"
		public string NTHeight {
			get { return GetString("NTHeight", "90"); }
			set { SetString("NTHeight", value); }
		}

		//Private _Pause As String
		public string Pause {
			get { return GetString("Pause", ""); }
			set { SetString("Pause", value); }
		}

		//Private _Speed As String
		public string Speed {
			get { return GetString("Speed", ""); }
			set { SetString("Speed", value); }
		}


		//JukeBox Properties
		//Private _InitialJuke As String = "-1"
		public int InitialJuke {
			get { return GetInteger("InitialJuke", -1); }
			set { SetString("InitialJuke", value.ToString()); }
		}

		//'Private _RunFirstSelection As String = "True"
		//Public Property RunFirstSelection() As Boolean
		//    Get
		//        Return GetBoolean("RunFirstSelection)
		//    End Get
		//    Set(ByVal Value As Boolean)
		//        _RunFirstSelection SetString("", Value.ToString())
		//    End Set
		//End Property

		//Private _AutoStart As String = "True"
		public bool AutoStart {
			get { return GetBoolean("AutoStart", true); }
			set { SetString("AutoStart", value.ToString()); }
		}

		//Private _AutoRewind As String = "True"
		public bool AutoRewind {
			get { return GetBoolean("AutoRewind", true); }
			set { SetString("AutoRewind", value.ToString()); }
		}

		//'Private _HideJukeSelector As String = "False"
		//Public Property HideJukeSelector() As Boolean
		//    Get
		//        Return GetBoolean("HideJukeSelector)
		//    End Get
		//    Set(ByVal Value As Boolean)
		//        _HideJukeSelector SetString("", Value.ToString())
		//    End Set
		//End Property

		//Private _JukeSelector As String = "1"
		public int JukeSelector {
			get { return GetInteger("JukeSelector", 1); }
			set { SetString("JukeSelector", value.ToString()); }
		}

		//Private _ReferIt As String = String.Empty
		public string ReferIt {
			get { return GetString("ReferIt", ""); }
			set { SetString("ReferIt", value); }
		}

		//Private _AutoRefresh As String = "0"
		public int AutoRefresh {
			get { return GetInteger("AutoRefresh", 0); }
			set { SetString("AutoRefresh", value.ToString()); }
		}

		//Private _JukePager As String = "10"
		public int JukePager {
			get { return GetInteger("JukePager", 10); }
			set { SetString("JukePager", value.ToString()); }
		}

		//Private _ShowJukePanel As String = "False"
		public bool ShowJukePanel {
			get { return GetBoolean("ShowJukePanel", false); }
			set { SetString("ShowJukePanel", value.ToString()); }
		}

		//Private _ShowReferJuke As String = "True"
		public bool ShowReferJuke {
			get { return GetBoolean("ShowReferJuke", true); }
			set { SetString("ShowReferJuke", value.ToString()); }
		}

		//Private _ShowAddToFavourite As String = "True"
		public bool ShowAddToFavourite {
			get { return GetBoolean("ShowAddToFavourite", true); }
			set { SetString("ShowAddToFavourite", value.ToString()); }
		}

		//Private _ShowDownload As String = "False"
		public bool ShowDownload {
			get { return GetBoolean("ShowDownload", false); }
			set { SetString("ShowDownload", value.ToString()); }
		}

		//Private _ShowMusicDownload As String = "False"
		public bool ShowMusicDownload {
			get { return GetBoolean("ShowMusicDownload", false); }
			set { SetString("ShowMusicDownload", value.ToString()); }
		}

		//Private _ShowRatings As String = "True"
		public bool ShowRatings {
			get { return GetBoolean("ShowRatings", true); }
			set { SetString("ShowRatings", value.ToString()); }
		}

		//Private _ShowSlotAvailability As String = "False"
		public bool ShowSlotAvailability {
			get { return GetBoolean("ShowSlotAvailability", false); }
			set { SetString("ShowSlotAvailability", value.ToString()); }
		}

		//Shockwave
		//Private _swSaveEnabled As String = "True"
		public bool swSaveEnabled {
			get { return GetBoolean("swSaveEnabled", true); }
			set { SetString("swSaveEnabled", value.ToString()); }
		}

		//Private _swVolume As String = "True"
		public bool swVolume {
			get { return GetBoolean("swVolume", true); }
			set { SetString("swVolume", value.ToString()); }
		}

		//Private _swRestart As String = "True"
		public bool swRestart {
			get { return GetBoolean("swRestart", true); }
			set { SetString("swRestart", value.ToString()); }
		}

		//Private _swPausePlay As String = "True"
		public bool swPausePlay {
			get { return GetBoolean("swPausePlay", true); }
			set { SetString("swPausePlay", value.ToString()); }
		}

		//Private _swFastForward As String = "True"
		public bool swFastForward {
			get { return GetBoolean("swFastForward", true); }
			set { SetString("swFastForward", value.ToString()); }
		}

		//Private _swContextMenu As String = "True"
		public bool swContextMenu {
			get { return GetBoolean("swContextMenu", true); }
			set { SetString("swContextMenu", value.ToString()); }
		}
		//Shockware
		//Private _swRemote As String = String.Empty
		public string swRemote {
			get { return GetString("swRemote", ""); }
			set { SetString("swRemote", value); }
		}

		//Private _swStretchStyle As String = "None"
		public string swStretchStyle {
			get { return GetString("swStretchStyle", "None"); }
			set { SetString("swStretchStyle", value); }
		}
		//FLV Player
		//Private _FlvSkinUrl As String = String.Empty
		public string FlvSkinUrl {
			get { return GetString("FlvSkinUrl", ""); }
			set { SetString("FlvSkinUrl", value); }
		}
		//Authorware
		//Private _Palette As String = "background"
		public string Palette {
			get { return GetString("Palette", "background"); }
			set { SetString("Palette", value); }
		}

		//Private _awWindow As String = "inPlace"
		public string awWindow {
			get { return GetString("awWindow", "inPlace"); }
			set { SetString("awWindow", value); }
		}

		//Private _RatingsInNewWindow As String = "False"
		public bool RatingsInNewWindow {
			get { return GetBoolean("RatingsInNewWindow", false); }
			set { SetString("RatingsInNewWindow", value.ToString()); }
		}


		//BulkImport Properties
		//Private _DataFolder As String = String.Empty
		public string DataFolder {
			get { return GetString("DataFolder", ""); }
			set { SetString("DataFolder", value); }
		}


		//PayPal Properties
		//Private _PayPalId As String = "bhattji@bhattji.com"
		public string PayPalId {
			get { return GetString("PayPalId", "bhattji@bhattji.com"); }
			set { SetString("PayPalId", value); }
		}

		//Private _SlotAdPrice As String = "30"
		public decimal SlotAdPrice {
			get { return GetDecimal("SlotAdPrice", 30); }
			set { SetString("SlotAdPrice", value.ToString()); }
		}




		//Audit Control
		public int UpdatedByUserId {
			get { return GetInteger("UpdatedByUserId", 1); }
			set { SetString("UpdatedByUserId", value.ToString()); }
		}

		public string UpdatedByUser {
			get { return GetString("UpdatedByUser", "System Account"); }
			set { SetString("UpdatedByUser", value); }
		}

		public DateTime UpdatedDate {
			get { return GetDate("UpdatedDate", DateTime.Now ); }
//SetString("UpdatedDate", Now.ToString())
			set { SetString("UpdatedDate", value.ToString()); }
		}
		#endregion

		#region " Constructors "

		public OptionsInfo()
		{
		}

		public OptionsInfo(int ModuleId)
		{
			_ModuleID = ModuleId;
			Load(ModuleId);
		}

		#endregion

		#region " Private Methods "
		private void SetString(string OptionKey, string OptionValue)
		{
			if (this.Contains(OptionKey))
			{
				this[OptionKey] = OptionValue;
			}
			else
			{
				this.Add(OptionKey, OptionValue);
			}
		}

		private string GetString(string OptionKey, string FailSafe)
		{
			try {
				if (this.Contains(OptionKey))
				{
					return (string)this[OptionKey];
				}
				else
				{
					return FailSafe;
				}
			}
			catch {
				return FailSafe;
			}
		}

		private int GetInteger(string OptionKey, int FailSafe)
		{
			try {
				if (this.Contains(OptionKey))
				{
					return (int)this[OptionKey];
				}
				else
				{
					return FailSafe;
				}
			}
			catch {
				return FailSafe;
			}
		}

		private double GetDouble(string OptionKey, double FailSafe)
		{
			try {
				if (this.Contains(OptionKey))
				{
					return (double)this[OptionKey];
				}
				else
				{
					return FailSafe;
				}
			}
			catch {
				return FailSafe;
			}
		}

		private decimal GetDecimal(string OptionKey, decimal FailSafe)
		{
			try {
				if (this.Contains(OptionKey))
				{
					return (decimal)this[OptionKey];
				}
				else
				{
					return FailSafe;
				}
			}
			catch {
				return FailSafe;
			}
		}

		private bool GetBoolean(string OptionKey, bool FailSafe)
		{
			try {
				if (this.Contains(OptionKey))
				{
					return (bool)this[OptionKey];
				}
				else
				{
					return FailSafe;
				}
			}
			catch {
				return FailSafe;
			}
		}

		private DateTime GetDate(string OptionKey, DateTime FailSafe)
		{
			try {
				if (this.Contains(OptionKey))
				{
					return (DateTime)this[OptionKey];
				}
				else
				{
					return FailSafe;
				}
			}
			catch {
				return FailSafe;
			}
		}

		#endregion

		#region " Public Methods "

		public void Load(int ModuleId)
		{
			//Try
			if (ModuleId > -1)
			{
				//ModSets.Clear()
				Hashtable ModSets = (new DotNetNuke.Entities.Modules.ModuleController()).GetModuleSettings(ModuleId);
                //DictionaryEntry d;

                foreach (DictionaryEntry d in ModSets)
                {
					try {
						//use the Key and Value properties. Note chr(9) is a tab
						//Console.WriteLine("{0}" & Chr(9) & "{1}", d.Key, d.Value)
						this.Add(d.Key, d.Value);
					}
					catch {
					}
				}
			}
			//Catch
			//End Try
		}

		public void Update(int ModuleId)
		{
			_ModuleID = ModuleId;
			Update();
		}

		public void Update()
		{
			if (ModuleID > -1)
			{
				DotNetNuke.Entities.Modules.ModuleController objMC = new DotNetNuke.Entities.Modules.ModuleController();
                //DictionaryEntry d;

                foreach (DictionaryEntry d in this)
                {
					try {
						//use the Key and Value properties. Note chr(9) is a tab
						//Console.WriteLine("{0}" & Chr(9) & "{1}", d.Key, d.Value)
						objMC.UpdateModuleSetting(ModuleID, d.Key.ToString(), d.Value.ToString());
					}
					catch {
					}
				}

				//For Each K As String In ModSets.Keys
				//    objMC.UpdateModuleSetting(ModuleID, K, ModSets.Item(K).ToString())
				//Next K

				//For I As Integer = 0 To ModSets.Count - 1
				//    objMC.UpdateModuleSetting(ModuleID, ModSets(I).ToString(), ModSets.Keys(I))
				//Next
			}
			//ModuleID > -1 Then

		}

		public string LinkClickUrlLegacy(string Link)
		{
			string strLink = Link;

            switch (DotNetNuke.Common.Globals.GetURLType(strLink))
            {
				case DotNetNuke.Entities.Tabs.TabType.Tab:
					//TabType.Tab
                    strLink = DotNetNuke.Common.Globals.ApplicationPath + "/" + DotNetNuke.Common.Globals.glbDefaultPage + "?tabid=" + Link;
					break;
				case DotNetNuke.Entities.Tabs.TabType.File:
					//TabType.File
					DotNetNuke.Entities.Portals.PortalSettings _portalSettings = DotNetNuke.Entities.Portals.PortalController.GetCurrentPortalSettings();
					strLink = _portalSettings.HomeDirectory + Link;
					break;
			}

			return strLink;
		}
		//LinkClickUrlLegacy

		public string GetThumbSrc(string FileName, string ThumbGenFile)
		{
			return GetThumbSrc(FileName, ThumbGenFile, -1);
		}
		//GetThumbSrc

		public string GetThumbSrc(string FileName, string ThumbGenFile, int Width)
		{
			//Function GetThumbSrc(ByVal FileName As String, ByVal ThumbGenFile As String, Optional ByVal Width As Integer = -1) As String
			int W = Width;
			if (W < 0)
			{
				try {
					W = int.Parse(ThumbWidth);
				}
				catch {
					//W = 32 'The default width specified in the Thumb.aspx file will be used
				}
			}

			string strFileName;
			//= FileName
			if (FileName.StartsWith("http"))
			{
				strFileName = FileName;
			}
			else
			{
				strFileName = HttpContext.Current.Server.MapPath(FileName);
				//HttpServerUtility.MapPath(FileName) ' Server.MapPath(FileName)
			}

			if (W < 0)
			{
				return ThumbGenFile + "?filename=" + strFileName;
			}
			else
			{
				return ThumbGenFile + "?width=" + W.ToString() + "&filename=" + strFileName;
			}

		}
		//GetThumbSrc

		public string MediaType(string MediaFilename)
		{
			switch (Path.GetExtension(MediaFilename).ToLower()) {
				case ".gif":
				case ".jpg":
				case ".jpeg":
				case ".jpe":
					return "Image";
				case ".swf":
					return "Flash";
				case ".wmv":
				case ".mpeg":
				case ".mpg":
				case ".mov":
					return "Movie";
				default:
					return "Unknown";
			}
		}

		public bool IsImageFile(string Filename)
		{
			return MediaType(Filename).ToLower() == "image";
		}

		public string GetThumbUrl(string MediaFile1, string ThumbGenFile, string NoImageFile)
		{
			return GetThumbUrl(MediaFile1, ThumbGenFile, NoImageFile, "", -1);
		}
		//GetThumbUrl

		public string GetThumbUrl(string MediaFile1, string ThumbGenFile, string NoImageFile, string MediaFile2, int Width)
		{
			//Function GetThumbUrl(ByVal MediaFile1 As String, ByVal ThumbGenFile As String, ByVal NoImageFile As String, Optional ByVal MediaFile2 As String = "", Optional ByVal Width As Integer = -1) As String
			if ((MediaFile1 != "") && (IsImageFile(MediaFile1)))
			{
				return GetThumbSrc(MediaFile1, ThumbGenFile, Width);
			}
else if ((MediaFile2 != "") && (IsImageFile(MediaFile2))) {
				return GetThumbSrc(MediaFile2, ThumbGenFile, Width);
			}
			else
			{
				return GetThumbSrc(NoImageFile, ThumbGenFile, Width);
			}
		}
		//GetThumbUrl

		public string GetDatedTitle(string Title, string TitleDate)
		{
			switch (AddDate.ToLower()) {
				case "a":
				case "after":
					return Title + " : " + TitleDate;
				case "b":
				case "before":
					return TitleDate + " : " + Title;
				case "u":
				case "up":
					return TitleDate + "<br />" + Title;
				case "d":
				case "down":
					return Title + "<br />" + TitleDate;
				default:
					return Title;
			}
		}
		//GetThumbUrl

		public bool IsModuleItem(int ModId)
		{
			return _ModuleID == ModId;
		}

		public bool IsItemEditable(int ModId)
		{
			return DotNetNuke.Entities.Users.UserController.GetCurrentUserInfo().IsSuperUser || IsModuleItem(ModId);
		}



		//Sub SetGridView(ByRef gdvGridView As GridView)
		//    With gdvGridView
		//        .PageSize = PagerSize
		//        .AllowPaging = PagerSize > 0
		//        '.Columns(.Columns.Count - 1).Visible = IsEditable 'Remove the last column if the User is not Admin
		//        .Columns[0].Visible = IsEditable 'Remove the First column if the User is not Admin

		//        If BackColor <> String.Empty Then
		//            Try
		//                .RowStyle.BackColor = CType(System.ComponentModel.TypeDescriptor.GetConverter(GetType(System.Drawing.Color)).ConvertFromString(BackColor), System.Drawing.Color)
		//            Catch
		//            End Try
		//        End If
		//        If AltColor <> String.Empty Then
		//            Try
		//                .AlternatingRowStyle.BackColor = CType(System.ComponentModel.TypeDescriptor.GetConverter(GetType(System.Drawing.Color)).ConvertFromString(AltColor), System.Drawing.Color)
		//            Catch
		//            End Try
		//        End If

		//        If SelectedColor <> String.Empty Then
		//            Try
		//                .AlternatingRowStyle.BackColor = CType(System.ComponentModel.TypeDescriptor.GetConverter(GetType(System.Drawing.Color)).ConvertFromString(SelectedColor), System.Drawing.Color)
		//            Catch
		//            End Try
		//        End If
		//        If HeaderBackColor <> String.Empty Then
		//            Try
		//                .HeaderStyle.BackColor = CType(System.ComponentModel.TypeDescriptor.GetConverter(GetType(System.Drawing.Color)).ConvertFromString(HeaderBackColor), System.Drawing.Color)
		//                .FooterStyle.BackColor = CType(System.ComponentModel.TypeDescriptor.GetConverter(GetType(System.Drawing.Color)).ConvertFromString(HeaderBackColor), System.Drawing.Color)
		//            Catch
		//            End Try
		//        End If
		//        If PagerBackColor <> String.Empty Then
		//            Try
		//                .PagerStyle.BackColor = CType(System.ComponentModel.TypeDescriptor.GetConverter(GetType(System.Drawing.Color)).ConvertFromString(PagerBackColor), System.Drawing.Color)
		//            Catch
		//            End Try
		//        End If
		//    End With 'gdvViewList

		//End Sub

		#endregion

	}
	//OptionsInfo

}
//bhattji.Modules.SalesReps
