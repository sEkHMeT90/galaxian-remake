﻿/** 
*   Nave: la nave que maneja el jugador
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
   0.02  03-Feb-2011  Frank Royo y Aitor Salgado
                      Implementar los metodos que componen la clase. Hemos creado nuevos atributos
                       ( VidasNave,VelDisparo) y un método GetVida que devolvera a partida la
                       cantidad de vidas restantes.
   0.03  08-Feb-2011  Maria Navarro y Julio Antoranz
                      Mejorar disparo de nave.
   0.04  16-Feb-2011  Nacho Cabanes
             		  Adaptado a XNA
   0.05  17-Feb-2011  Fran Royo, Alex Guillen, David Guerra.
             		  Movimiento hasta extremos correcto.
                      Posición del disparo correcta.
 ---------------------------------------------------- */


using Microsoft.Xna.Framework.Content;




namespace galaxianXNA
{

    public class Nave : ElemGrafico
    {
        private DisparoPersonaje miDisparo;
        private byte vidas;
        const int VelDisparo = 5;


        public Nave(ContentManager c)
            : base("nave", c)
        {
            ancho = 39;
            alto = 48;
            //CargarImagen("imagenes/nave.png");
            MoverA(400, 600 - (alto + 20));
            miDisparo = new DisparoPersonaje(c);
            vidas = 3;
            incrX = 5;
        }


        public void MoverDerecha()
        {

            if( x < 800 - ancho -5)
                x += incrX;
            
                

        }


        public void MoverIzquierda()
        {
            if (x > 0)
                x -= incrX;
        }

        // Devuelve la posición donde sale el disparo y con el ancho indicamos la posición donde sale.
        public void Disparar()
        {
            /* TODO: Falta que se actualize el documento para que no haga falta cambiar la X
            miDisparo.Aparecer(x + ancho / 2, y, VelDisparo);*/

            /*TODO: Hacer que el disaro vuelva a aparecer*/

            //if (!miDisparo.GetVisible()) //mientras no este visible 
            {
                miDisparo.Aparecer((x + ancho / 2) -2, y - 7, 0, -VelDisparo);
            }
        }


        public void Morir()
        {
            vidas--;
        }

        // Método que añade una vida adicional.
        public void GanarVida()
        {
            vidas++;
        }

        // Método que devuelve la cantidad de vida restantes.
        public byte GetVidas()
        {
            return vidas;
        }

        public DisparoPersonaje GetDisparo()
        {
            return miDisparo;
        }

    } /* fin de la clase Nave */

}
