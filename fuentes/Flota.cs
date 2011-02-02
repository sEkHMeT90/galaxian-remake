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
 ---------------------------------------------------- */


public class Flota
{
    EnemAzul enemigo1;
    public Flota()
    {
        enemigo1 = new EnemAzul();
    }


    // Mueve todos los enemigos en bloque y (quiza) lanza ataques
    public  void Mover()
    {

    }

    // Lanza uno o varios enemigos al ataque
    public void Atacar()
    {

    }


    // Dibuja todos los enemigos
    public  void DibujarOculta()
    {
        enemigo1.DibujarOculta();
    }
} /* fin de la clase Flota */
