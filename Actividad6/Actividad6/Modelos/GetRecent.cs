using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad6.Modelos
{

    // Esta clase mapea el JSON recibido de  solicitud la API de flickr con el metodo flickr.photos.getRecent.
    // https://www.flickr.com/services/api/flickr.photos.getRecent.html
    //  Es un objeto con dos campos Stat y Photos

    //  {  
    //  "photos": {...}
    //  "stat": "ok"
    //   }

    class GetRecent
    {   
        public string Stat { get; set; }
        public Photos Photos { get; set; }
    }
}
