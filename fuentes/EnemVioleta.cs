/** 
 *   EnemVioleta: detalles específicos de los enemigos violetas
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
  
   0.02  03-Feb-2011  Héctor Pastor, Alejandro Guijarro
                      Modificada para añadir constructor
                      con la imagen adecuada
 ---------------------------------------------------- */

public class EnemVioleta : Enemigo
{
    public EnemVioleta()
    {
        CargarImagen("imagenes/enemigoV.png");
    }
} /* fin de la clase EnemVioleta */
