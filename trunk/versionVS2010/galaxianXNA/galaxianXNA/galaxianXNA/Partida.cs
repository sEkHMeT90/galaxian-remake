using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace galaxianXNA
{
    class Partida
    {
        GraphicsDeviceManager graphics;
        //SpriteBatch spriteBatch;
        SpriteFont fuente18;
        ContentManager contenido;

        Fondo miFondo;
        Flota miFlota;
        Nave miNave;
        //Enemigo miEnemigo;

        private bool terminada = false;

        public Partida(GraphicsDeviceManager dispositivo, ContentManager c)
        {
            graphics = dispositivo;
            contenido = c;
        }


        public void LoadContent()
        {
            fuente18 = contenido.Load<SpriteFont>("Lucida Console");

            miFondo = new Fondo(contenido);
            miNave = new Nave(contenido); miNave.MoverA(400, 550);

            //miEnemigo = new Enemigo(contenido);
            miFlota = new Flota(contenido);
        }


        public void MoverElementos()
        {
            miFondo.Mover();
            //miEnemigo.Mover();
            miFlota.Mover();
            miNave.GetDisparo().Mover();
        }


        // --- Comprobación de teclas, ratón y joystick -----
        public void ComprobarTeclas()
        {
            // Salir
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                terminada = true;

            // Movimiento y disparo de la nave
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                miNave.MoverIzquierda();
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                miNave.MoverDerecha();
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                miNave.Disparar();
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
            miFondo.DibujarOculta(spriteBatch);
            miNave.DibujarOculta(spriteBatch);
            //miEnemigo.DibujarOculta(spriteBatch);
            miFlota.DibujarOculta(spriteBatch);
            miNave.GetDisparo().DibujarOculta(spriteBatch);
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
