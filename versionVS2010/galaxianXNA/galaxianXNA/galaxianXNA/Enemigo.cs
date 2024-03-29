﻿/** 
 *   Enemigo: detalles comunes a todos los enemigos
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
   0.02  03-Feb-2011  Antonio Ramos y Jose Manuel Rizo
                      Movimiento y ataque del enemigo
   0.03  08-Feb-2011  Héctor Pastor, Ethan Martínez
                        El enemigo baja en zigzag al atacar                      
                      Denys Demyanchuk, Daniel Marin, Pedro zalacain
                        Agregado el disparo del primer Enemigo (sin dibujar)...
   0.04  16-Feb-2011  Nacho Cabanes
             		  Adaptado a XNA
   0.05  17-Feb-2011  Ethan Martinez, Antonio Pérez y Maria Navarro
                      El enemigo vuelve a la posicion que le corresponde dentro
                      de la flota.
---------------------------------------------------- */

using Microsoft.Xna.Framework.Content;

namespace galaxianXNA
{
    
    public class Enemigo : ElemGrafico
    {
        protected bool atacando;
        private DisparoEnemigo Disparo;
        const int VelDisparo = 5;
        private int contador = 0;
        private short incrementoX = 5;
        protected int xOriginal;

        public Enemigo(ContentManager c)
            : base("enemigoA", c)
        {
            //CargarImagen("imagenes/enemigoA.png");
            incrY = 2;
            x = 100;
            y = 50;
            ancho = 33;
            alto = 24;
            Disparo = new DisparoEnemigo(c);
            atacando = false;
            xOriginal = x;
            //yOriginal = y;
        }

        // Operations

        public new void Mover()
        {
            xOriginal++;
            if (atacando)
            {

                if (y < 600)
                    y += incrY;
                else
                {
                    atacando = false;
                    y = 5;
                    x = xOriginal+2;
                }

                if (contador < 20)
                {
                    x += incrementoX;
                    contador++;
                }
                else
                {
                    incrementoX *= -1; //Se cambia el signo para 
                    //cambiar la dirección de desplazamiento
                    contador = 0;
                }
            }

        }


        public void Atacar()
        {
            atacando = true;
        }

        public void Disparar()
        {
            /* TODO: Falta que se actualize el documento para que no haga falta cambiar la X
            miDisparo.Aparecer(x + ancho / 2, y, VelDisparo);*/

            Disparo.Aparecer(x + ancho / 2, y + 5, 0, +VelDisparo);
        }

        public void Regresar()
        {

        }

        public DisparoEnemigo GetDisparo()
        {
            return Disparo;
        }


        public bool GetAtacando()
        {
            return atacando;
        }

    } /* fin de la clase Enemigo */

}
