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
 * 0.05  17-Feb-2011  Manuel Martinez, Cristian Bautista, Julio Antoranz
 *                    Modificar fondo. (No lo dibuja).
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
            for (int i = 0; i < 4; i++)
            {
                arrayFondo[i].MoverA(x, y += 2);

                if (arrayFondo[i].GetY() >= 600)
                    arrayFondo[i].MoverA(x, -634);


                /*
                fondo2.MoverA(x, y + 200);
                fondo3.MoverA(x, y + 400);
                */
            }
        }


        public new void DibujarOculta(SpriteBatch listaSprites)
        {   
             for (int i = 0; i < 4; i++)
                arrayFondo[i].DibujarOculta(listaSprites);

               // fondo2.DibujarOculta(listaSprites);
                //fondo3.DibujarOculta(listaSprites);
        }

    }
}
