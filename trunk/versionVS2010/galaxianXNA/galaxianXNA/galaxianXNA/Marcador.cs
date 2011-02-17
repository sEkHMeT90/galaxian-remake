/** 
 *   Marcador: muestra vidas, puntos, nivel...
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
   0.02  03-Feb-2011  Miguel Laguardia, Cristian Bautista
                      Muestra las vidas y los puntos 
   0.03  08-Feb-2011  Alejandro Guijarro, Javier Abad
                      Arreglo del marcador de vidas y Banderas
  0.04  16-Feb-2011  Nacho Cabanes
            	      Adaptado a XNA
 0.05  17-Feb-2011  Rizo, Denys, Javier Abad
 *                     Adaptar el marcador para que se 
 *                     parezca al original.
 ---------------------------------------------------- */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace galaxianXNA
{
    class Marcador
    {        
        //GraphicsDeviceManager graphics;
        ContentManager contenido;
        SpriteFont fuente18;

        private ElemGrafico imagenVidas;
        private int vidas;
        private ElemGrafico imagenNivel;
        private int nivel;
        //private ElemGrafico Bandera;

        private int puntuacion;
        private int mejorPunt;

        private int[] posicionesVidas = new int[5];
        private int[] posicionesBanderas = new int[10];
        
        //private int Banderas;


        //private Partida miPartida;
        public Marcador(ContentManager c)
        {
            //graphics = dispositivo;
            contenido = c;

            //miPartida = p;
            //array posiciones de naves
            posicionesVidas[0] = 0;
            posicionesVidas[1] = 30;
            posicionesVidas[2] = 60;
            posicionesVidas[3] = 90;
            posicionesVidas[4] = 120;

            //array posiciones de banderas
            posicionesBanderas[0] = 0;
            posicionesBanderas[1] = 30;
            posicionesBanderas[2] = 60;
            posicionesBanderas[3] = 90;
            posicionesBanderas[4] = 120;
            posicionesBanderas[5] = 150;
            posicionesBanderas[6] = 180;
            posicionesBanderas[7] = 210;
            posicionesBanderas[8] = 240;
            posicionesBanderas[9] = 270;
        }


        public void LoadContent()
        {
            fuente18 = contenido.Load<SpriteFont>("Lucida Console");
            imagenVidas = new ElemGrafico("vida", contenido);
            imagenNivel = new ElemGrafico("bandera", contenido);
        }


        public void IndicarPuntos(int p)
        {
            puntuacion = p;
        }


        public void IndicarNivel(int n)
        {
            nivel = n;
        }


        public void IndicarVidas(byte v)
        {
            vidas = v;
        }


        public void DibujarOculta(SpriteBatch listaSprites)
        {
            listaSprites.DrawString(fuente18, "Puntos:",
                    new Vector2(160, 10), Color.White);
            listaSprites.DrawString(fuente18, System.Convert.ToString(puntuacion),
                    new Vector2(250, 10), Color.White);


            listaSprites.DrawString(fuente18, "Maximo: ",
                    new Vector2(350, 10), Color.Red);
            listaSprites.DrawString(fuente18, System.Convert.ToString(puntuacion),
                    new Vector2(440, 10), Color.Blue);
            
            // Vidas, como barra (maximo 10 segmentos)
            int navecitas = vidas;
            if (navecitas > 5) navecitas = 5;
            for (int i = 0; i < navecitas; i++)
            {
                imagenVidas.DibujarOculta(10 + posicionesVidas[i], 550, listaSprites);
            }

            //Hardware.EscribirTextoOculta(System.Convert.ToString(vidas),
            //  /* Coordenadas */ 100, 570,  /* Colores */ 50, 255, 50,
            //  tipoDeLetra);

            // Banderas,(maximo 10 segmentos)
            int banderitas = 5;// Numero de banderitas prestablecido
            if (banderitas > 10) banderitas = 0;
            //Bandera = 1;
            for (int i = 0; i < banderitas; i++)
            {
                imagenNivel.DibujarOculta(750 - posicionesBanderas[i], 10, listaSprites);
            }

            //Hardware.EscribirTextoOculta("banderitas",
            //  /* Coordenadas */ 750, 570,  /* Colores */ 50, 255, 50,
            //  tipoDeLetra);
        }

    }
}
