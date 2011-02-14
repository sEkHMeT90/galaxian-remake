using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace galaxianXNA
{
    class Creditos
    {
        GraphicsDeviceManager graphics;
        ContentManager contenido;
        Texture2D imagenFondo;
        SpriteFont fuente18;
        int xTexto = 320, yTexto = 500;
        int incrX = 1, incrY = 1;

        // Opciones posibles
        private bool terminada;

        public Creditos(GraphicsDeviceManager dispositivo, ContentManager c)
        {
            graphics = dispositivo;
            contenido = c;
        }

        public void LoadContent()
        {
            imagenFondo = contenido.Load<Texture2D>("galaxian_logo");
            fuente18 = contenido.Load<SpriteFont>("Lucida Console");
        }


        public void Update()
        {
            // Mover elementos (texto)
            xTexto += incrX;
            yTexto += incrY;

            if ((xTexto < 100) || (xTexto > 380)) incrX = -incrX;
            if ((yTexto < 500) || (yTexto > 560)) incrY = -incrY;

            // Colisiones: nada por ahora

            // Comprobacion de teclas para salir
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                terminada = true;
        }


        public void DibujarElementos(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(imagenFondo, new Vector2(100, 100), Color.White);
            spriteBatch.DrawString(fuente18, "Remake 2011 por 1 DAI San Vicente",
                   new Vector2(xTexto, yTexto), Color.WhiteSmoke);
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
