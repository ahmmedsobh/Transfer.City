using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Transfer.City.Helpers
{
    public class UploadImages
    {
        public string MapPath { get; set; }
        public UploadImages()
        {
                
        }
        public UploadImages(string MapPath)
        {
            this.MapPath = MapPath;
        }
        public string AddImage(HttpPostedFileBase file, string ImgNewName)
        {
            if (file != null && MapPath != null && ImgNewName != null)
            {
                string fileExtention = Path.GetExtension(file.FileName);
                string NewName = $"{ImgNewName}{fileExtention}";
                string path = Path.Combine(MapPath, NewName);
                file.SaveAs(path);
                return NewName;
            }

            return "false";
        }

        public string UpdataImage(HttpPostedFileBase file, string ImgNewName, string ImgOldName)
        {
            if (file != null && MapPath != null && ImgNewName != null && ImgOldName != null)
            {
                string fileExtention = Path.GetExtension(file.FileName);
                string NewName = $"{ImgNewName}{fileExtention}";

                string OldPath = Path.Combine(MapPath, ImgOldName);
                string NewPath = Path.Combine(MapPath, NewName);

                if (NewPath != OldPath)
                {
                    DeleteImage(ImgOldName);
                    file.SaveAs(NewPath);
                    return NewName;
                }
                return ImgOldName;
            }
            else if (ImgOldName != null && ImgOldName != "false")
            {
                return ImgOldName;
            }
            return "false";
        }


        public void DeleteImage(string OldImgName)
        {
            try
            {
                if (MapPath != null && OldImgName != null)
                {
                    if (OldImgName != "default.png")
                    {
                        string FullPath = Path.Combine(MapPath, OldImgName);
                        File.Delete(FullPath);
                    }
                }
            }
            catch
            {
                return;
            }


        }
    }
}