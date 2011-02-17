/**
 *   Partida: Logica de una partida de juego
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
                      Version inicial: esqueleto, muestra el Nave,
                        permite moverlo a la derecha, izquierda
                        y (vacio) Disparar
   0.02  03-Feb-2011  David Guerra, Javier Abad: Comprobación de colisiones
                      Nacho: se dibuja y mueve el fondo
   0.03  08-Feb-2011  Antonio Pérez, Francisco Royo
                      Creamos un nuevo método llamado inicializar,
                      en el bucle principal inicializamos los datos,
                      añadida tecla provisinal para disparo enemigo.
   0.04  16-Feb-2011  Nacho Cabanes
             		  Adaptado a XNA
 * 0.05  17-Feb-2011  Daniel Marin
 *                    Ahora al pulsar Esc se reinician las posiciones de la 
 *                    flota, Preparar funciones para avanzar de nivel si los enemigos
 *                    desaparecen
 ---------------------------------------------------- */


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace galaxianXNA
{
    class Partida
    {
        GraphicsDeviceManager graphics;
        ContentManager contenido;

        Fondo miFondo;
        Flota miFlota;
        Nave miNave;
        Marcador miMarcador;
        int puntos = 0;

        private bool terminada = false;

        public Partida(GraphicsDeviceManager dispositivo, ContentManager c)
        {
            graphics = dispositivo;
            contenido = c;
        }


        public void LoadContent()
        {
            Reiniciar();
        }


        public void MoverElementos()
        {
            miFondo.Mover();
            miFlota.Mover();
            miNave.GetDisparo().Mover();
            miFlota.GetEnemigo(0).GetDisparo().Mover();
        }


        // --- Comprobación de teclas, ratón y joystick -----
        public void ComprobarTeclas()
        {
            // Salir
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Reiniciar();
                terminada = true;
            }

            // Movimiento y disparo de la nave
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                miNave.MoverIzquierda();
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                miNave.MoverDerecha();
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                miNave.Disparar();

            // Teclas adicionales para pruebas provisionales
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                miFlota.Atacar();
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                miFlota.Disparar();
        }

        
        // --- Comprobar colisiones de enemigo con personaje, etc ---
        public void ComprobarColisiones()
        {
            //comprobar colisiones Nave Enemiga con mi Nave
            for (int i = 0; i < miFlota.GetNumEnemigos(); i++)
            {
                if (miFlota.GetEnemigo(i).ColisionCon(miNave))
                {
                    miNave.Morir();
                    miMarcador.IndicarVidas(miNave.GetVidas());
                    // TODO: Falta recolocar nave y enemigos
                }
            }

            //comprobar colisiones Disparo Enemigo con mi Nave
            for (int i = 0; i < miFlota.GetNumEnemigos(); i++)
            {
                if (miFlota.GetEnemigo(i).GetDisparo() != null)

                    if (miFlota.GetEnemigo(i).GetDisparo().ColisionCon(miNave))
                    {
                        miNave.Morir();
                        //miMarcador.IndicarVidas( miNave.GetVidas() );
                    }
            }

            //comprobar colisiones Nave Enemiga con mi Disparo
            for (int i = 0; i < miFlota.GetNumEnemigos(); i++)
            {
                if (miFlota.GetEnemigo(i).ColisionCon(miNave.GetDisparo()))
                {
                    miFlota.DestruirEnemigo(i);
                    puntos += 10;
                    miMarcador.IndicarPuntos( puntos);

                }

                //if (miFlota.GetNumEnemigosVivos() == 0)
                //    miFlota.ReiniciarPosiciones();

            }

        }


        // --- Dibujar todos los elementos en pantalla
        public void DibujarElementos(SpriteBatch spriteBatch)
        {
            miFondo.DibujarOculta(spriteBatch);
            miNave.DibujarOculta(spriteBatch);
            miFlota.DibujarOculta(spriteBatch);

            miNave.GetDisparo().DibujarOculta(spriteBatch);
            miFlota.GetEnemigo(0).GetDisparo().DibujarOculta(spriteBatch);

            miMarcador.DibujarOculta(spriteBatch);
        }


        public bool GetTerminada()
        {
            return terminada;
        }


        public void Reiniciar()
        {
            terminada = false;
            miFondo = new Fondo(contenido);
            miNave = new Nave(contenido); miNave.MoverA(400, 550);
            miFlota = new Flota(contenido);
            miMarcador = new Marcador(contenido);
            miMarcador.LoadContent();
        }

    }
}
