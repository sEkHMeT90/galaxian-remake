using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace galaxianXNA
{
    class Partida
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont fuente18;
        ContentManager contenido;

        Nave miNave;
        Enemigo miEnemigo;

        private bool terminada = false;

        public Partida(GraphicsDeviceManager dispositivo, ContentManager c)
        {
            graphics = dispositivo;
            contenido = c;
        }


        public void LoadContent()
        {
            fuente18 = contenido.Load<SpriteFont>("Lucida Console");
            miNave = new Nave(contenido);
            miNave.MoverA(400, 300);

            miEnemigo = new Enemigo(contenido);
        }


        public void MoverElementos()
        {
            miEnemigo.Mover();
        }


        // --- Comprobación de teclas, ratón y joystick -----
        public void ComprobarTeclas()
        {
            
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                terminada = true;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                miNave.MoverIzquierda();
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                miNave.MoverDerecha();
        }

        
        // --- Comprobar colisiones de enemigo con personaje, etc ---
        public void ComprobarColisiones()
        {
            // Nada por ahora
        }


        // --- Dibujar todos los elementos en pantalla
        public void DibujarElementos(SpriteBatch spriteBatch)
        {
            //miMapa.DibujarOculta(spriteBatch);
            miNave.DibujarOculta(spriteBatch);
            miEnemigo.DibujarOculta(spriteBatch);
            spriteBatch.DrawString(fuente18, "Texto de ejemplo",
                       new Vector2(300, 50), Color.LightGreen);
        }


        public bool GetTerminada()
        {
            return terminada;
        }


        public void Reiniciar()
        {
            terminada = false;
        }

    }
}
