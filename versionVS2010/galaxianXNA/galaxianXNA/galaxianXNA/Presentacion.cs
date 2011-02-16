/** 
 *   Presentacion: pantalla de presentación
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
  0.02  03-Feb-2011  Raquel Lloréns y María Navarro
                      Pantalla principal estática
  0.03  08-Feb-2011  Andrés Marotta y Manuel Martínez Morant, retoques por Nacho
                      Animación de enemigos en la pantalla
					  de presentación
  0.04  16-Feb-2011  Nacho Cabanes
            	      Adaptado a XNA
 ---------------------------------------------------- */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace galaxianXNA
{
    class Presentacion
    {
        GraphicsDeviceManager graphics;
        ContentManager contenido;
        ElemGrafico imagenFondo;
        SpriteFont fuente18;

        private EnemAzul enemigoAzul;
        private EnemRojo enemigoRojo;
        private EnemVioleta enemigoVioleta;
        private EnemAmarillo enemigoAmarillo;

        // Opciones posibles
        public const byte OPC_NINGUNA = 0;
        public const byte OPC_PARTIDA = 1;
        public const byte OPC_SALIR = 2;
        public const byte OPC_CREDITOS = 3;

        private bool terminada;

        private int opcionEscogida = OPC_NINGUNA;
        int desplazActual = 600;

        public Presentacion(GraphicsDeviceManager dispositivo, ContentManager c)
        {
            graphics = dispositivo;
            contenido = c;
        }

        public void LoadContent()
        {
            imagenFondo = new ElemGrafico("galaxian_logo", contenido);
            fuente18 = contenido.Load<SpriteFont>("Lucida Console");

            enemigoAzul = new EnemAzul(contenido);
            enemigoRojo = new EnemRojo(contenido);
            enemigoVioleta = new EnemVioleta(contenido);
            enemigoAmarillo = new EnemAmarillo(contenido);

            enemigoAzul.MoverA(200 + desplazActual, 305);
            enemigoRojo.MoverA(200 + desplazActual, 355);
            enemigoVioleta.MoverA(200 + desplazActual, 405);
            enemigoAmarillo.MoverA(200 + desplazActual, 455);
        }


        public void Update()
        {
            // Mover elementos
            if (desplazActual > 0)
                desplazActual -= 2;


            // Colisiones: nada por ahora

            // Comprobacion de teclas para salir
            if (Keyboard.GetState().IsKeyDown(Keys.J))  // J = Jugar
            {
                opcionEscogida = OPC_PARTIDA;
                terminada = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.C))  // C = Creditos
            {
                opcionEscogida = OPC_CREDITOS;
                terminada = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))  // S = Salir
            {
                opcionEscogida = OPC_SALIR;
                terminada = true;
            }

        }


        public void DibujarElementos(SpriteBatch spriteBatch)
        {
            imagenFondo.DibujarOculta(100, 100, spriteBatch);
            spriteBatch.DrawString(fuente18, "Pulsa J para Jugar",
                   new Vector2(320, 520), Color.White);
            spriteBatch.DrawString(fuente18, "C para Creditos o S para Salir",
                   new Vector2(260, 550), Color.WhiteSmoke);

            // Dibujar enemigos en pantalla oculta
            enemigoAzul.MoverA(200 + desplazActual, 305);
            enemigoRojo.MoverA(200 + desplazActual, 355);
            enemigoVioleta.MoverA(200 + desplazActual, 405);
            enemigoAmarillo.MoverA(200 + desplazActual, 455);

            enemigoAzul.DibujarOculta(spriteBatch);
            enemigoRojo.DibujarOculta(spriteBatch);
            enemigoVioleta.DibujarOculta(spriteBatch);
            enemigoAmarillo.DibujarOculta(spriteBatch);

            //Escribo la pantalla de presentación
            spriteBatch.DrawString(fuente18, "WE  ARE  THE  GALAXIANS",
                    new Vector2(270, 120), Color.WhiteSmoke);
            spriteBatch.DrawString(fuente18, "MISSION:        DESTROY  ALIENS",
                    new Vector2(240, 150), Color.WhiteSmoke);

            //Escribo las puntuaciones de los enemigos
            spriteBatch.DrawString(fuente18,"-   SCORE  ADVANCE  TABLE   -",
                    new Vector2(255, 230), Color.WhiteSmoke);
            spriteBatch.DrawString(fuente18,   "CONVOY   CHARGER",
                    new Vector2((short)(300 + desplazActual), 260), Color.WhiteSmoke);
            spriteBatch.DrawString(fuente18,   "60          800 PTS",
                    new Vector2((short)(300 + desplazActual), 310), Color.WhiteSmoke);
            spriteBatch.DrawString(fuente18,   "50          100 PTS",
                    new Vector2((short)(300 + desplazActual), 360), Color.WhiteSmoke);
            spriteBatch.DrawString(fuente18,   "40          80 PTS",
                    new Vector2((short)(300 + desplazActual), 410), Color.WhiteSmoke);
            spriteBatch.DrawString(fuente18,   "30          60 PTS",
                    new Vector2((short)(300 + desplazActual), 460), Color.WhiteSmoke);
        }


        public int GetOpcionEscogida()
        {
            return opcionEscogida;
        }


        public void Reiniciar()
        {
            opcionEscogida = OPC_NINGUNA;
            terminada = false;
        }


        public bool GetTerminada()
        {
            return terminada;
        }

    }
}
