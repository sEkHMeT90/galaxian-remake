/** 
 *   Creditos: pantalla con información sobre los autores
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
   0.02  03-Feb-2011  Julio Antoranz, Ethan Martinez
                      Escribe un texto de ejemplo
   0.03  08-Feb-2011  Miguel Laguardia , Raquel Lloréns
             		  Creditos Actualizados sin animacion
   0.04  16-Feb-2011  Nacho Cabanes
             		  Adaptado a XNA
---------------------------------------------------- */

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
        SpriteFont fuente18;
        int xTexto = 320, yTexto = 500;
        int incrX = 1, incrY = 1;

        string[] nombresCreditos = {          
          "Javier Abad", "Julio Antoranz", "Cristian Bautista", "Denys Demyanchuk",
          "David Guerra", "Alejandro Guijarro", "Alejandro Guillén", "Miguel Laguardia",
          "Raquel Lloréns", "Daniel Marin", "Andrés Marotta", "David Martinez",
          "Ethan Martinez", "Manuel Martinez", "María Navarro", "Héctor Pastor",
          "Antonio Pérez", "Antonio Ramos", "J.M. Rizo", "Francisco Royo",
          "Aitor Salgado", "Pedro Zalacaín", "Nacho Cabanes",
        };


        // Opciones posibles
        private bool terminada;

        public Creditos(GraphicsDeviceManager dispositivo, ContentManager c)
        {
            graphics = dispositivo;
            contenido = c;
        }

        public void LoadContent()
        {
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
            spriteBatch.DrawString(fuente18, "Remake 2011 por 1 DAI San Vicente",
                   new Vector2(xTexto, yTexto), Color.WhiteSmoke);

            spriteBatch.DrawString(fuente18, "Galaxian (Remake) - Creditos",
                   new Vector2(220, 40), Color.Red);

            spriteBatch.DrawString(fuente18, "Programa original:  (c) Namco 1979",
                   new Vector2(80, 100), Color.Red);
            spriteBatch.DrawString(fuente18, "Remake 2011: ",
                   new Vector2(80, 130), Color.Red);
            spriteBatch.DrawString(fuente18, "Pulsa ESC para volver . . . ",
                   new Vector2(80, 550), Color.Chocolate);
			
            // Escribir nombres            
            int x = 80;
            int y = 180;
			for ( int i = 0 ; i < nombresCreditos.Length ; i++ ) {
                spriteBatch.DrawString(fuente18, nombresCreditos[i],
                   new Vector2(x, y), Color.Brown);
                        // /* Colores */ 0x01,(byte) (0xDF - i*5), 0xDF,
                y = (short)(y + 30);
                if (y > 450) 
                { 
                    x += 260; 
                    y = 180; 
                }

            }

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
