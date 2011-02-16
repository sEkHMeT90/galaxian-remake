/** 
 *   Fondo: fondo de estrellas en movimiento
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
   0.02  03-Feb-2011  Alejandro Guillén y Manuel Martinez
   					  Fondo repetitivo que se mueve hacia abajo
   0.03  08-Feb-2011  Cristian Bautista y David Guerra, retoques por Nacho
   					  Intento de fondo repetitivo sin espacios en negro
   0.04  16-Feb-2011  Nacho Cabanes
             		  Adaptado a XNA
 ---------------------------------------------------- */

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace galaxianXNA
{
    class Fondo : ElemGrafico
    {
        ElemGrafico fondo1;
        ElemGrafico fondo2;
        ElemGrafico fondo3;

        public Fondo(ContentManager c)
            : base("fondo", c)
        {
            x = 0;
            y = -200;
            fondo1 = new ElemGrafico("fondo", c);
            fondo2 = new ElemGrafico("fondo", c);
            fondo3 = new ElemGrafico("fondo", c);

            fondo1.MoverA(x, y);
            fondo2.MoverA(x, y + 200);
            fondo3.MoverA(x, y + 400);
        }


        public new void Mover()
        {
            y += 2;
            if (y >= 600)
                y = -200;

            fondo1.MoverA(x, y);
            fondo2.MoverA(x, y + 200);
            fondo3.MoverA(x, y + 400);
        }


        public new void DibujarOculta(SpriteBatch listaSprites)
        {
            fondo1.DibujarOculta(listaSprites);
            fondo2.DibujarOculta(listaSprites);
            fondo3.DibujarOculta(listaSprites);
        }

    }
}
