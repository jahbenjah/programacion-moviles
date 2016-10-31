using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad5.Models
{
    class Disco
    {
        public int DiscoId { get; set; }
        public string Album { get; set; }
        public string Banda { get; set; }
        public string Portada { get; set; }

    }

    public class DiscoManager {

        public static List<Disco> Discos() 
        {
                List<Disco> discos = new List<Disco>();
                discos.Add(new Disco { DiscoId = 1, Album = "Dark Side Of the Moon", Banda = "Pink Floyd", Portada = "/Assets/dark.png" });
                discos.Add(new Disco { DiscoId = 1, Album = "Dark Side Of the Moon", Banda = "Pink Floyd", Portada = "/Assets/dark.png" });
                discos.Add(new Disco { DiscoId = 1, Album = "Dark Side Of the Moon", Banda = "Pink Floyd", Portada = "/Assets/dark.png" });
                discos.Add(new Disco { DiscoId = 1, Album = "Dark Side Of the Moon", Banda = "Pink Floyd", Portada = "/Assets/dark.png" });
                discos.Add(new Disco { DiscoId = 1, Album = "Dark Side Of the Moon", Banda = "Pink Floyd", Portada = "/Assets/dark.png" });
                discos.Add(new Disco { DiscoId = 1, Album = "Dark Side Of the Moon", Banda = "Pink Floyd", Portada = "/Assets/dark.png" });
                discos.Add(new Disco { DiscoId = 1, Album = "Dark Side Of the Moon", Banda = "Pink Floyd", Portada = "/Assets/dark.png" });
                return discos;
          
        }
    }
}
