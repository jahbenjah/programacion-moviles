using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad7.Modelos
{
    class Photo
    {


        public string Id { get; set; }
        public string Owner { get; set; }
        public string Secret { get; set; }
        public string Server { get; set; }
        public string Farm { get; set; }
        public string Title { get; set; }
        public string IsPublic { get; set; }
        public string IsFriend { get; set; }
        public string IsFamily { get; set; }

        public string Descripcion
        {
            get
            {   if (Title.Length <= 10)
                    return Title;
                else
                    return Title.Substring(0, 10);
            }

        }

        public string URL { get {
                return GetStringUrl();
            }

        } 
        public override string ToString()
        {
            return "ID: " + Id + " Owner:" + Owner + " Secret: " + Secret + " Secret: " + Secret + " Server: " + Server + " Farm: " + Farm + " Title: " + Title + " IsPublic: " + IsPublic + " IsFriend: " + IsFriend + " IsFamily: " + IsFamily;
        }

        public string GetStringUrl()
        {
            //https://farm{farm-id}.staticflickr.com/{server-id}/{id}_{secret}.jpg
            return @"https://farm" + Farm + ".staticflickr.com/" + Server + "/" + Id + "_" + Secret + ".jpg";
        }
    }
}
