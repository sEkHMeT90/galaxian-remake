/** 
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
 ---------------------------------------------------- */


public class Enemigo : ElemGrafico
{

    public Enemigo()
    {
        CargarImagen("imagenes/enemigoA.png");
    }

    // Operations

    public  void Mover()
    {

    }


    public  void Atacar()
    {

    }


    public  void Regresar()
    {

    }
    
    public DisparoEnemigo GetDisparo()
    {
        return null;
    }
        
} /* fin de la clase Enemigo */
