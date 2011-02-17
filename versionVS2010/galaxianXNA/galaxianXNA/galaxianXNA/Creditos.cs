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
   0.05  17-Feb-2011  Aitor Salgado, Antonio Ramos, David Martinez
                      Búsqueda y modificación de colores, con degradado
   0.06  18-Feb-2011  Nacho Cabanes
             		  Usa la clase Fuente
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
        Fuente fuente18;
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
            fuente18 = new Fuente( "Lucida Console", contenido);
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
            fuente18.EscribirTextoOculta("Remake 2011 por 1 DAI San Vicente",
                   xTexto, yTexto, Color.Gray, spriteBatch);

            fuente18.EscribirTextoOculta("Galaxian (Remake) - Creditos",
                   220, 40, Color.Red, spriteBatch);

            fuente18.EscribirTextoOculta("Programa original:  (c) Namco 1979",
                   80, 100, Color.PowderBlue, spriteBatch);
            fuente18.EscribirTextoOculta("Remake 2011: ",
                   80, 130, Color.PowderBlue, spriteBatch);
            fuente18.EscribirTextoOculta("Pulsa ESC para volver . . . ",
                   80, 550, Color.WhiteSmoke, spriteBatch);
			
            // Escribir nombres            
            int x = 80;
            int y = 180;
            /*System.Random r = new System.Random();
            int colorR = r.Next(0,256);
            int colorG = r.Next(0, 256);
            int colorB = r.Next(0, 256);*/
			for ( int i = 0 ; i < nombresCreditos.Length ; i++ ) {
                fuente18.EscribirTextoOculta(nombresCreditos[i],
                    /* Coordenadas */ x, y,
                    /* Colores */ 0x01, (byte)(0xDF - i * 5), 0xDF,
                    spriteBatch);
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
