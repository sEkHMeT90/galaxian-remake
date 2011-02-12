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

 ---------------------------------------------------- */



public class Partida
{

    // Componentes del juego
    private Nave miNave;
    private Flota miFlota;
    private Marcador miMarcador;
    private Fondo miFondo;

    // Otros datos del juego
    int puntos;             // Puntuacion obtenida por el usuario
    bool partidaTerminada;  // Si ha terminado una partida


    // Inicialización al comenzar la sesión de juego
    public Partida()
    {
        miNave = new Nave();
        miFlota = new Flota();
        miMarcador = new Marcador();
        miFondo = new Fondo();
        puntos = 0;
        partidaTerminada = false;
    }

    void Inicializar()
    {
        miNave = new Nave();
        miFlota = new Flota();
        miMarcador = new Marcador();
        miFondo = new Fondo();
        puntos = 0;
        partidaTerminada = false;
        miMarcador.IndicarVidas(miNave.GetVidas());
    }

    // --- Comprobación de teclas, ratón y joystick -----
    void comprobarTeclas()
    {
          // Muevo si se pulsa alguna flecha del teclado
          if (Hardware.TeclaPulsada(Hardware.TECLA_DER) )
              miNave.MoverDerecha();

          if (Hardware.TeclaPulsada(Hardware.TECLA_IZQ))
              miNave.MoverIzquierda();

          if (Hardware.TeclaPulsada(Hardware.TECLA_ESP))
              miNave.Disparar();

          // Teclas adicionales para pruebas provisionales
          if (Hardware.TeclaPulsada(Hardware.TECLA_A))
              miFlota.Atacar();

          if (Hardware.TeclaPulsada(Hardware.TECLA_D))
              miFlota.Disparar();

          // Compruebo el Joystick
          if (Hardware.JoystickPulsado(0))
              miNave.Disparar();

          int posXJoystick, posYJoystick;
          if (Hardware.JoystickMovido(out posXJoystick, out posYJoystick))
          {
              if (posXJoystick > 0) miNave.MoverDerecha();
              else if (posXJoystick < 0) miNave.MoverIzquierda();
          }

          // Si se pulsa ESC, por ahora termina la partida... y el juego
          if (Hardware.TeclaPulsada(Hardware.TECLA_ESC))
              partidaTerminada = true;
    }


    // --- Animación de los enemigos y demás objetos "que se muevan solos" -----
     void moverElementos()
    {
        miFondo.Mover();
        miFlota.Mover();
        miNave.GetDisparo().Mover();
        miFlota.GetEnemigo(0).GetDisparo().Mover();
    }


    // --- Comprobar colisiones de enemigo con Nave, etc ---
     void comprobarColisiones()
    {
         //comprobar colisiones Nave Enemiga con mi Nave
         for (int i = 0; i < miFlota.GetNumEnemigos() ; i++)
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
             if (miFlota.GetEnemigo(i).ColisionCon( miNave.GetDisparo() ))
             {
                 miFlota.DestruirEnemigo(i);
                 puntos += 10;
                 miMarcador.IndicarPuntos(puntos);

             }
         }

         
    }


     // --- Dibujar en pantalla todos los elementos visibles del juego ---
     void dibujarElementos()
    {
        // Borro pantalla
        Hardware.BorrarPantallaOculta(0,0,0);

        // Dibujo los elementos
        miFondo.DibujarOculta();
        miFlota.DibujarOculta();
        miNave.GetDisparo().DibujarOculta();
        miFlota.GetEnemigo(0).GetDisparo().DibujarOculta();
        miNave.DibujarOculta();
        miMarcador.DibujarOculta();

        // Finalmente, muestro en pantalla
        Hardware.VisualizarOculta();
    }


    // --- Pausa tras cada fotograma de juego, para velocidad de 25 fps -----
     void pausaFotograma()
    {
        Hardware.Pausa( 40 );
    }


    // --- Bucle principal de juego -----
    public void BuclePrincipal()
    {
        Inicializar();
        partidaTerminada = false;
        do {
            comprobarTeclas();
            moverElementos();
            comprobarColisiones();
            dibujarElementos();
            pausaFotograma();
        } while (! partidaTerminada);
    }


} /* fin de la clase Partida */
