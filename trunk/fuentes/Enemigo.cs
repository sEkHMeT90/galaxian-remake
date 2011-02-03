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
 * 0.02  03-Feb-2011  Antonio Ramos y Jose Manuel Rizo
                      Movimiento y ataque del enemigo
 ---------------------------------------------------- */

public class Enemigo : ElemGrafico
{
    protected bool atacando;
    
    public Enemigo()
    {
        CargarImagen("imagenes/enemigoA.png");
        incrY= 4;
        x = 100;
        y = 50;
        atacando = false;
        xOriginal = x;
        yOriginal = y;
    }

    // Operations

    public  void Mover()
    {
        if (atacando)
        {
            y += incrY;

            if (y >= 600)
                y = 0;

            if ((y == yOriginal) && (x == xOriginal))
                atacando = false;
            
         }

    }


    public  void Atacar()
    {
        atacando = true;
    }

    public  void Regresar()
    {

    }
    
    public DisparoEnemigo GetDisparo()
    {
        return null;
    }
        
} /* fin de la clase Enemigo */
