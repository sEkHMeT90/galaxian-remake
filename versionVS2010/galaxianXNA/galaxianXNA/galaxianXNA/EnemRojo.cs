using Microsoft.Xna.Framework.Content;

namespace galaxianXNA
{
    class EnemRojo : Enemigo
    {
        public EnemRojo(ContentManager c)
            : base(c)
        {
            CargarImagen("enemigoR", c);
        }
    }
}
