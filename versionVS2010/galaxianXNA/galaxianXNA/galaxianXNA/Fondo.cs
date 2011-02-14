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
