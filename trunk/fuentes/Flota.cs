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
                      Array de enemigos, 
 ---------------------------------------------------- */


public class Flota
{
    private int maxEnemigos = 10;
    private Enemigo[] enemigos;
    // private EnemAzul enemigo1;
    
    public Flota()
    {
        enemigos = new Enemigo[maxEnemigos];

        for (int i = 0; i < maxEnemigos; i++)
            enemigos[i] = new Enemigo();

        // enemigo1 = new EnemAzul();
    }


    // Mueve todos los enemigos en bloque y (quiza) lanza ataques
    public void Mover()
    {
        /*
        for (int i = 0; i < maxEnemigos; i++)
            enemigos[i].DibujarOculta();
        Random r = new Random();
        */
    }

    // Lanza uno o varios enemigos al ataque
    public void Atacar()
    {
        /*
        Random r = new Random();
        */
    }

    // Dibuja todos los enemigos
    public  void DibujarOculta()
    {
        for (int i = 0; i < maxEnemigos; i++)
            enemigos[i].DibujarOculta(33*i,5);
        // enemigo1.DibujarOculta();
    }

    // Mueve todos los enemigos en bloque y (quiza) lanza ataques
    public int GetNumEnemigos()
    {
        return maxEnemigos;
    }


    // Mueve todos los enemigos en bloque y (quiza) lanza ataques
    public Enemigo GetEnemigo(int i)
    {
        return enemigos[i];
    }


} /* fin de la clase Flota */
