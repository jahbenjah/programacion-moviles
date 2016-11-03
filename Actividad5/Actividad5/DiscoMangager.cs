using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad5
{
    public class DiscoMangager
    {
        public static List<Disco> getDiscos() { 


        List<Disco> discos = new List<Disco>();

           discos.Add( new Disco { Id = 1 ,Artista = "Pink Floyd" , Titulo ="Dark Side of The Moon",RutaPortada="Assets/1.jpg"});
            discos.Add(new Disco { Id = 2, Artista = "Bob Dylan", Titulo = "Blood On the Tracks", RutaPortada = "Assets/2.jpg" });
            discos.Add(new Disco { Id = 3, Artista = "Radiohead", Titulo = "Hail To the Thieft", RutaPortada = "Assets/3.jpg" });
            discos.Add(new Disco { Id = 4, Artista = "Real de Catorce", Titulo = "Contraley", RutaPortada = "Assets/4.jpg" });
            discos.Add(new Disco { Id = 5, Artista = "Bob Marley", Titulo = "Natural Mistyc", RutaPortada = "Assets/5.jpg" });
            discos.Add(new Disco { Id = 6, Artista = "Rolling Stone", Titulo = "Forty Licks", RutaPortada = "Assets/6.jpg" });
            discos.Add(new Disco { Id = 7, Artista = "Beatles", Titulo = "Sargent Pepper", RutaPortada = "Assets/7.jpg" });


            return discos;

        }
    }
}