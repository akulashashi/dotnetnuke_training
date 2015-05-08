using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web;
using System.Net;
using System.Diagnostics;

namespace bhattji.Modules.YouTubeVideos
{

    public partial class Thumb : System.Web.UI.Page
    {
        #region " Web Form Designer Generated Code "
        //This call is required by the Web Form Designer. 
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
        }
        //NOTE: The following placeholder declaration is required by the Web Form Designer. 
        //Do not delete or move it. 
        ///Private designerPlaceholderDeclaration As System.Object 
        private void Page_Init(object sender, System.EventArgs e)
        {
            //CODEGEN: This method call is required by the Web Form Designer 
            //Do not modify it using the code editor. 
            InitializeComponent();
        }
        #endregion

        #region " Functions & Methods "
        //Private Function GetFileName() As String 
        // 'Get the filename. The file could be either the remote file on the web 
        // 'Or Local file on the same Webserver (in which case the path should be absolute) 
        // Dim _GetFileName As String = "http://www.bhattji.com/images/vision.jpg" 
        // If Not Request.Params("filename") Is Nothing Then 
        // If Request.Params("filename").Length > 0 Then _GetFileName = Request.Params("filename") 
        // End If 
        // Return _GetFileName 
        //End Function 'GetFileName 

        private Image GetImage(string FileName)
        {
            if (FileName.ToLower().StartsWith("http"))
            {
                WebClient objClient = new WebClient();
                MemoryStream objImageStream = new MemoryStream(objClient.DownloadData(FileName));
                return Image.FromStream(objImageStream);
            }
            else
            {
                //objImage = Image.FromFile(Server.MapPath(strFileName)) 
                return Image.FromFile(FileName);
            }
        }//GetImage 

        //Private Function GetGraphics(ByVal objBitmap As Bitmap) As Graphics 

        //End Function 'GetGraphics 

        private void GetSize(Image Image, ref int Width, ref int Height)
        {
            int tWidth = -1;
            //Width 
            int tHeight = -1;
            //Height 

            try
            {
                // Retrieve width from query string 
                if ((Request.Params["width"] != null))
                {
                    try
                    {
                        tWidth = Convert.ToInt32(Request.Params["width"]);
                    }
                    catch{}
                }
                if ((Request.Params["height"] != null))
                {
                    try
                    {
                        tHeight = Convert.ToInt32(Request.Params["height"]);
                    }
                    catch {}
                }

                //Set tWidth & tHeight 
                if (tWidth < 0 && tHeight < 0)
                {
                    int MinSize = -1;
                    if ((Request.Params["MinSize"] != null))
                    {
                        try
                        {
                            MinSize = Convert.ToInt32(Request.Params["MinSize"]);
                        }
                        catch {}
                    }

                    if (MinSize > -1)
                    {
                        if (Image.Height < Image.Width)
                        {
                            tHeight = MinSize;
                            tWidth = (int)Image.Width * MinSize / Image.Height;
                        }
                        else
                        {
                            tWidth = MinSize;
                            tHeight = (int)Image.Height * MinSize / Image.Width;
                        }
                    }
                    else
                    {
                        int MaxSize = -1;
                        if ((Request.Params["MaxSize"] != null))
                        {
                            try
                            {
                                MinSize = Convert.ToInt32(Request.Params["MaxSize"]);
                            }
                            catch {}
                        }

                        if (Image.Height > Image.Width)
                        {
                            if (MaxSize > -1)
                                tHeight = MaxSize;
                            else
                                tHeight = Height;
                            tWidth = (int)Image.Width * tHeight / Image.Height;
                        }
                        else
                        {
                            if (MaxSize > -1)
                                tWidth = MaxSize;
                            else
                                tWidth = Width;
                            tHeight = (int)Image.Height * tWidth / Image.Width;
                        }
                    }
                }
                else if (tHeight < 0)
                {
                    tHeight = Image.Height * tWidth / Image.Width; //(int)Image.Height * tWidth / Image.Width;
                }
                else if (tWidth < 0)
                {
                    tWidth = Image.Width * tHeight / Image.Height; //(int)Image.Width * tHeight / Image.Height;
                    //Else 
                }
            }
            catch
            {
                //if somthing breaks set the Dimension as supplied 
                tWidth = Width;
                tHeight = Height;
            }
            finally
            {
                //Finally set the computed/defaulted Width & Height 
                Width = tWidth;
                Height = tHeight;
            }
        }//GetSize 

        private string GetContentType(string FileName)
        {
            switch (Path.GetExtension(FileName).ToLower())
            {
                case ".wmf":
                    return "image/wmf";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                default:
                    //".jpg" 
                    return "image/jpeg";
            }
        }//GetContentType 

        private ImageFormat GetImageFormat(string FileName)
        {
            switch (Path.GetExtension(FileName).ToLower())
            {
                case ".wmf":
                    return ImageFormat.Wmf;
                case ".png":
                    return ImageFormat.Png;
                case ".gif":
                    return ImageFormat.Gif;
                default:
                    //".jpg" 
                    return ImageFormat.Jpeg;
            }
        }//GetImageFormat 

        #endregion

        #region " Event Methods "

        private void Page_Load(object sender, System.EventArgs e)
        {
            //Put user code to initialize the page here 
            try
            {
                //Get the filename 
                string strFileName = "http://www.bhattji.com/images/vision.jpg";
                if ((Request.Params["filename"] != null))
                {
                    strFileName = Request.Params["filename"];
                }

                //Create The Image from retrieved filename 
                Image objImage = GetImage(strFileName);

                //Compute the Dimension of the Thumbnail 
                int tWidth = 100;
                //= Integer.Parse(Request.Params("width")) 
                int tHeight = 100;
                //= Integer.Parse(Request.Params("height")) 
                GetSize(objImage, ref tWidth, ref tHeight);

                //Decide the Quality of the Thumbnail 
                bool LowQuality = false;
                if ((Request.Params["Quality"] != null))
                {
                    LowQuality = (Request.Params["Quality"].ToLower() == "low");
                }

                if (LowQuality)
                {
                    //Use Windows Function GetThumbnailImage of the Image 
                    Image objThumbnail = objImage.GetThumbnailImage(tWidth, tHeight, null, new System.IntPtr());
                    Response.ContentType = GetContentType(strFileName);
                    objThumbnail.Save(Response.OutputStream, GetImageFormat(strFileName));
                    objThumbnail.Dispose();
                }
                else
                {
                    //Use Windows advanced Bitmap & Graphics Utilities & Functions 
                    Bitmap objThumb = new Bitmap(tWidth, tHeight);
                    Graphics objGraphics = Graphics.FromImage(objThumb);
                    if ((Request.Params["BgColor"] != null))
                    {
                        //Request.Params("BgColor") <> String.Empty Then 
                        Color BgColor;
                        //= Color.White 
                        try
                        {
                            BgColor = (Color)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(Request.Params["BgColor"]);
                        }
                        catch
                        {
                            BgColor = Color.White;
                        }
                        objGraphics.Clear(BgColor);
                    }
                    objGraphics.SmoothingMode = SmoothingMode.HighQuality;
                    objGraphics.CompositingQuality = CompositingQuality.HighQuality;
                    objGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    objGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    objGraphics.DrawImage(objImage, 0, 0, tWidth, tHeight);

                    objThumb.Save(Response.OutputStream, GetImageFormat(strFileName));
                    objGraphics.Dispose();
                    objThumb.Dispose();
                }

                objImage.Dispose();
            }

            catch (Exception ex)
            {
                DotNetNuke.Services.Exceptions.Exceptions.ProcessModuleLoadException(this, ex);
            }

        }//Page_Load 

        #endregion

    }
    //Thumb 

}
//bhattji.Modules.YouTubeVideos 
