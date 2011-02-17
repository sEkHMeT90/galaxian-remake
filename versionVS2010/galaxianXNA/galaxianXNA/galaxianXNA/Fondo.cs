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
   0.05  17-Feb-2011  Manuel Martinez, Cristian Bautista, Julio Antoranz
                      Modificar fondo. (No lo dibuja).
   0.06  18-Feb-2011  Nacho Cabanes
             		  Corregido para movimiento suave y continuo
 ---------------------------------------------------- */

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace galaxianXNA
{
    class Fondo : ElemGrafico
    {
        ElemGrafico[] arrayFondo = new ElemGrafico[4];
       /* ElemGrafico fondo2;
        ElemGrafico fondo3;
        */
        int desplazamiento=0;

        public Fondo(ContentManager c)
            : base("fondo", c)
        {
            x = (800 - 672)/2;
            y = -634;

            for (int i = 0; i < 4; i++)
            {
                arrayFondo[i] = new ElemGrafico("fondo", c);
                arrayFondo[i].MoverA(x,y);
                y += 317;
            }

            /*
            fondo.MoverA(x, -317);
            fondo2.MoverA(x, 0);
            fondo3.MoverA(x, 317);
             */
        }


        public new void Mover()
        {
            y = -634;
            desplazamiento++;
            for (int i = 0; i < 4; i++)
            {
                arrayFondo[i].MoverA(x, y+desplazamiento);
                y += 317;
            }

            if (desplazamiento > 634)
                desplazamiento -= 634;            
        }


        public new void DibujarOculta(SpriteBatch listaSprites)
        {   
             for (int i = 0; i < 4; i++)
                arrayFondo[i].DibujarOculta(listaSprites);
        }

    }
}
