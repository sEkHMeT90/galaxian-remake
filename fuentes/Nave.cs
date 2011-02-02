/** 
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
 ---------------------------------------------------- */

public class Nave : ElemGrafico
{
    private DisparoPersonaje miDisparo;

    public Nave()
    {
        CargarImagen("imagenes/nave.png");
        MoverA(100, 100);
        miDisparo = new DisparoPersonaje();
    }
    
    
    public  void MoverDerecha()
    {
    
    }


    public  void MoverIzquierda()
    {

    }


    public  void Disparar()
    {

    }


    public  void Morir()
    {

    }
    
    public DisparoPersonaje GetDisparo()
    {
        return miDisparo;
    }
    
} /* fin de la clase Nave */
