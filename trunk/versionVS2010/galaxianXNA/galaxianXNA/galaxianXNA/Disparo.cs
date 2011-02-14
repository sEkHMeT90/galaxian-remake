using Microsoft.Xna.Framework.Content;


namespace galaxianXNA
{
    public class Disparo : ElemGrafico
    {
        public Disparo(ContentManager c)
            : base("disparo", c)
        {
            //CargarImagen("imagenes/disparo.png");        
        }

        public void Aparecer(int DisparoX, int DisparoY, int DisparoIncrX, int DisparoIncrY)
        {
            x = (short)DisparoX;
            y = (short)DisparoY;
            incrX = (short)DisparoIncrX;
            incrY = (short)DisparoIncrY;
            visible = true;
        }

        public new void Mover()
        {
            y += (short)incrY;
            x += (short)incrX;

            if ((y < 0) || (y > 800))
                Desaparecer();
        }

        public void Desaparecer()
        {
            visible = false;
        }

    }
}
