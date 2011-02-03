/** 
 *   Fondo: fondo de estrellas en movimiento
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
   0.02  03-Feb-2011  Alejandro Guillén y Manuel Martinez
   					  Fondo repetitivo que se mueve hacia abajo
 ---------------------------------------------------- */

public class Fondo : ElemGrafico
{
	public Fondo()
	{
		CargarImagen("imagenes/fondo.png");
        MoverA(64, -317);
	}
	
	
    public new void Mover()
    {
		y += 5;
		if(y >= 600)
			MoverA(64,-317);
		
    }
} /* fin de la clase Fondo */
