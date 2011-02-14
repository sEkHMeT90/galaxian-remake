using Microsoft.Xna.Framework.Content;

namespace galaxianXNA
{
    class EnemVioleta : Enemigo
    {
        public EnemVioleta(ContentManager c)
            : base(c)
        {
            CargarImagen("enemigoV", c);
        }
    }
}
