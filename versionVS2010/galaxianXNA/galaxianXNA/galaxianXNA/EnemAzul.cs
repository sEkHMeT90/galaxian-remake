/** 
 *   EnemAzul: detalles específicos de los enemigos azules
 * 
 *   Parte de "galaxian-remake"
 *  
 *   @see Hardware
 *   @author 1-DAI IES San Vicente 2010/11
 */

/* --------------------------------------------------         
   Versiones hasta la fecha:
   
   Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  02-Feb-2011  Nacho Cabanes
                      Version inicial: esqueleto vacio  
   0.02  03-Feb-2011  Héctor Pastor, Alejandro Guijarro
                      Modificada para añadir constructor
                      con la imagen adecuada
   0.04  16-Feb-2011  Nacho Cabanes
             		  Adaptado a XNA
 ---------------------------------------------------- */

using Microsoft.Xna.Framework.Content;

namespace galaxianXNA
{
    class EnemAzul : Enemigo
    {
        public EnemAzul(ContentManager c)
            : base(c)
        {
            CargarImagen("enemigoA", c);
        }
    }
}
