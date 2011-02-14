using Microsoft.Xna.Framework.Content;

namespace galaxianXNA
{
    class EnemAmarillo : Enemigo
    {
        public EnemAmarillo(ContentManager c)
            : base(c)
        {
            CargarImagen("enemigoA", c);
        }
    }
}
