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
