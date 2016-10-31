using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad6.Modelos
{
    // Represetna el objeto photos en el  JSON  de solicitud la API de flickr con el metodo flickr.photos.getRecent.
    // https://www.flickr.com/services/api/flickr.photos.getRecent.html


      //    "photos":
      //     {  
      //        "page":1,
      //        "pages":10,
      //        "perpage":100,
      //        "total":1000,
      //        "photo":[]
      //      }


    class Photos
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public List<Photo> Photo { get; set; }
    }
}
