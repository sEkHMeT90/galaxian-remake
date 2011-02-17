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
  0.03 08-Feb-2011   Aitor Salgado & Antonio Ramos + Jose Rizo y David Martinez
                     Hemos logrado que rebotara pero hemos tenido que modificar todo
                      para intentar crear un array de X dimensiones segun los enemigos.
  0.05 17-Feb-2011   Héctor Pastor Pérez, Raquel Llorens Gambin, Miguel Angel Laguardia
                     Ahora el enemigo que ataca es aleatorio.
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
    
        private int numFilas = 4;
        private int numColumnas = 9;

    
        public Flota(ContentManager c)
        {
            moverDerecha = true;
            enemigos = new Enemigo[numFilas,numColumnas];
       
            for (int fila = 0; fila < numFilas; fila++)
            {
                for (int columna = 0; columna < numColumnas; columna++)
                {
                    if (columna < 3)
                    {
                        enemigos[fila, columna] = new EnemAzul(c);
                        enemigos[fila, columna].SetAnchoAlto(33, 24);
                    }

                    if ((columna >= 3) && (columna < 6))
                    {
                        enemigos[fila, columna] = new EnemAmarillo(c);
                        enemigos[fila, columna].SetAnchoAlto(33, 24);
                    }

                    if ((columna >= 6))
                    {
                        enemigos[fila, columna] = new EnemRojo(c);
                        enemigos[fila, columna].SetAnchoAlto(33, 24);
                    }

                    enemigos[fila, columna].MoverA(40 * columna, 30 * fila);
                }
            }
            /*for( int columna = 0; columna < numColumnas; columna++ )
            {
                for( int fila = 0; fila < numFilas; fila++ )
                {
                    if( ( ( fila == 0 ) && ( columna == 3 ) ) || ( ( fila == 0 ) && ( columna == 6 ) ) )
                    {
                        enemigos[ fila, columna ] = new EnemAmarillo(c);
                        enemigos[ fila, columna ].SetAnchoAlto(33, 24);
                    }

                    if( ( ( fila == 1 ) && ( columna > 1 ) && ( columna < 7 ) ) )
                    {
                        enemigos[ fila, columna ] = new EnemRojo(c);
                        enemigos[ fila, columna ].SetAnchoAlto(33, 24);
                    }

                    if( ( ( fila == 2 ) && ( columna > 0 ) && ( columna < 8 ) ) )
                    {
                        enemigos[ fila, columna ] = new EnemVioleta(c);
                        enemigos[ fila, columna ].SetAnchoAlto(33, 24);
                    }

                    if( fila > 2 )
                    {
                        enemigos[fila, columna] = new EnemAzul(c);
                        enemigos[fila, columna].SetAnchoAlto(33, 24);
                    }

                    enemigos[ fila, columna ].MoverA(40 * columna, 30 * fila);
                }
            }*/
        }


        // Mueve todos los enemigos en bloque y (quiza) lanza ataques
        public void Mover()
        {
            // Random r = new Random();
            // Si el ultimo enemigo toca, debe rebotar
            if (enemigos[numFilas-1,numColumnas - 1].GetX() > 740)
                moverDerecha = false;

            if (enemigos[numFilas-1,0].GetX() <= 0)
                moverDerecha = true;

            for (int fila = 0; fila < numFilas; fila++)
            {
                for (int columna = 0; columna < numColumnas; columna++)
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
            enemigos[0,0].Disparar();
        }

        // Dibuja todos los enemigos
        public  void DibujarOculta(SpriteBatch listaSprites)
        {
            for (int fila = 0; fila < numFilas; fila++)
              for (int columna = 0; columna < numColumnas; columna++)
                enemigos[fila,columna].DibujarOculta(listaSprites);
        }

        // Devuelve la cantidad de enemigos
        public int GetNumEnemigos()
        {
            return numFilas * numColumnas;
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
            int fila = posicion / numColumnas;
            int columna = posicion % numColumnas;
            enemigos[fila, columna].SetVisible( false );
        }

        /* Cambios que realizn David y Rizo
         * 
         *   public Flota()
        {
            enemigos = new Enemigo[maxEnemigos];

            for (int columna = 0; columna < maxEnemigos; columna++)
            {
            
                if (columna < 3)
                {
                    enemigos[columna] = new EnemAzul();
                    enemigos[columna].SetAnchoAlto(33,24);
                }

                if ((columna >= 3) && (columna < 6))
                {
                    enemigos[columna] = new EnemAmarillo();
                    enemigos[columna].SetAnchoAlto(33,33);
                }

                if ((columna >= 6) )
                {
                    enemigos[columna] = new EnemRojo();
                    enemigos[columna].SetAnchoAlto(33,24);
                }

                enemigos[columna].MoverA(33 * columna, 5);
            
            }
         * 
         * 
        // Devuelve un enemigo
        public void DestruirEnemigo(int columna)
        {
    	    /*enemigos[columna].SetChocable( false );
    	
    	    enemigos[columna].CambiarDireccion(ElemGrafico.MURIENDO);
    	    enemigos[columna].SiguienteFotograma();
    	
            enemigos[columna].SetVisible( false );
        }
        */
    }
}
