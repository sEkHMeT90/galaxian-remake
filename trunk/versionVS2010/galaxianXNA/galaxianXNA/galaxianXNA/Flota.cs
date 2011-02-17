/** 
 *   Flota: bloque de todos los enemigos, que se mueven a la vez
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
   0.02  03-Feb-2011  Andrés Marotta, Pedro Zalacain
                        Array de enemigos.
                        Método "GetNumEnemigos()" para la clase Partida.
                        Método "GetEnemigo(columna)" para la clase Enemigo.
                      Nacho:
                        Añadido DestruirEnemigo, esqueleto de Mover, Atacar
   0.03  08-Feb-2011  Aitor Salgado & Antonio Ramos + Jose Rizo y David Martinez
                      Hemos logrado que rebotara pero hemos tenido que modificar todo
                      para intentar crear un array de X dimensiones segun los enemigos.
   0.05  17-Feb-2011  Héctor Pastor Pérez, Raquel Llorens Gambin, Miguel Angel Laguardia
                      Ahora el enemigo que ataca es aleatorio.
   0.06  18-Feb-2011  Nacho Cabanes
             		  Enemigos colocados en filas, no en columnas
                      Incluidos la cantidad de enemigos del juego original
                      GetNumEnemigos devuelve la cantidad real que quedan
                      Cambiados límites de mvto y posic inicial
                      Los enemigos atacan al azar
                      Los disparos atacan al azar
 ---------------------------------------------------- */


using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace galaxianXNA
{
    class Flota
    {
        //private int maxEnemigos = 9;
    
        private Enemigo[,] enemigos;
        private bool moverDerecha;
    
        private int numFilas = 6;
        private int numColumnas = 10;

        private int cantidadEnemigos;

    
        public Flota(ContentManager c)
        {
            moverDerecha = true;
            enemigos = new Enemigo[numFilas,numColumnas];
       
            for (int fila = 0; fila < numFilas; fila++)
            {
                for (int columna = 0; columna < numColumnas; columna++)
                {
                    if (fila == 0)
                        enemigos[fila, columna] = new EnemAmarillo(c);

                    else if (fila == 1)
                        enemigos[fila, columna] = new EnemRojo(c);

                    else if (fila == 2)
                        enemigos[fila, columna] = new EnemVioleta(c);

                    else
                        enemigos[fila, columna] = new EnemAzul(c);

                    enemigos[fila, columna].MoverA(40 * columna + 180, 30 * fila + 80);
                }
                
            }
            cantidadEnemigos = numFilas * numColumnas;

            // Dejo los huecos en la primera fila
            DestruirEnemigo(0); DestruirEnemigo(1); DestruirEnemigo(2);
            DestruirEnemigo(4); DestruirEnemigo(5); DestruirEnemigo(2);
            DestruirEnemigo(7); DestruirEnemigo(8); DestruirEnemigo(9);
            // Y en la segunda
            DestruirEnemigo(10); DestruirEnemigo(11);
            DestruirEnemigo(18); DestruirEnemigo(19);
            // Y en la tercera
            DestruirEnemigo(20); DestruirEnemigo(29);
        }


        // Mueve todos los enemigos en bloque y (quiza) lanza ataques
        public void Mover()
        {
            // Random r = new Random();
            // Si el ultimo enemigo toca, debe rebotar
            if (enemigos[numFilas-1,numColumnas - 1].GetX() > 680)
                moverDerecha = false;

            if (enemigos[numFilas-1,0].GetX() <= 80)
                moverDerecha = true;

            for (int fila = 0; fila < numFilas; fila++)
            {
                for (int columna = 0; columna < numColumnas; columna++)
                {
                    enemigos[fila, columna].GetDisparo().Mover();

                    if (enemigos[fila, columna].GetAtacando())
                        enemigos[fila, columna].Mover();
                    else

                        if (moverDerecha)
                            enemigos[fila, columna].MoverA(
                              enemigos[fila, columna].GetX() + 1, enemigos[fila, columna].GetY());
                        else
                            enemigos[fila, columna].MoverA(
                            enemigos[fila, columna].GetX() - 1, enemigos[fila, columna].GetY());
                }
            }
        
        }

        // Lanza uno o varios enemigos al ataque
        public void Atacar()
        {
            System.Random generador = new System.Random();
            int randomColumna = generador.Next(0, numColumnas);
            int randomFila = generador.Next(0, numFilas);
            enemigos[randomFila,randomColumna].Atacar();
        }

        // Lanza uno o varios enemigos al ataque
        public void Disparar()
        {
            // Random r = new Random();
            //enemigos[0,0].Disparar();
            System.Random generador = new System.Random();
            int randomColumna = generador.Next(0, numColumnas);
            int randomFila = generador.Next(0, numFilas);
            enemigos[randomFila, randomColumna].Disparar();
        }


        // Dibuja todos los enemigos
        public  void DibujarOculta(SpriteBatch listaSprites)
        {
            for (int fila = 0; fila < numFilas; fila++)
                for (int columna = 0; columna < numColumnas; columna++)
                {
                    enemigos[fila, columna].DibujarOculta(listaSprites);
                    enemigos[fila, columna].GetDisparo().DibujarOculta(listaSprites);
                }
        }

        // Devuelve la cantidad de enemigos restantes
        public int GetNumEnemigos()
        {
            return cantidadEnemigos;
        }


        // Devuelve la cantidad de enemigos totales en el array
        public int GetMaxEnemigos()
        {
            return numFilas* numColumnas;
        }


        // Devuelve un enemigo
        public Enemigo GetEnemigo(int posicion)
        {/* Tiene que ser así para que funcione. Lo cambiamos para que compile
            fila = posicion / marcianosPorFila;
            columna = posicion % marcianosPorFila;
            return enemigos[fila, columna]; */

            int fila = posicion / numColumnas;
            int columna = posicion % numColumnas;
            return enemigos[fila,columna];
        }


        // Devuelve un enemigo
        public void DestruirEnemigo(int posicion)
        {
            cantidadEnemigos--;
            int fila = posicion / numColumnas;
            int columna = posicion % numColumnas;
            enemigos[fila, columna].SetVisible( false );

            //enemigos[columna].SetChocable( false );
            //enemigos[columna].CambiarDireccion(ElemGrafico.MURIENDO);
            //enemigos[columna].SiguienteFotograma();
        }

        
    }
}
