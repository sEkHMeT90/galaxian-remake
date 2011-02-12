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
   0.03  08-Feb-2011  Cristian Bautista y David Guerra
   					  Intento de fondo repetitivo sin espacios en negro
 ---------------------------------------------------- */

public class Fondo : ElemGrafico
{
	ElemGrafico fondo1;
	ElemGrafico fondo2;
	ElemGrafico fondo3;
	
	public Fondo()
	{
		x = 0;
		y = -200;
		fondo1 = new ElemGrafico("imagenes/fondo.png");
		fondo2 = new ElemGrafico("imagenes/fondo.png");
		fondo3 = new ElemGrafico("imagenes/fondo.png");
		
		fondo1.MoverA(x,y);
		fondo2.MoverA(x,y+200);
		fondo3.MoverA(x,y+400);
	}
	
	
    public new void Mover()
    {
		y += 5;
		if(y >= 600)
			y = -200;
		
		fondo1.MoverA(x,y);
		fondo2.MoverA(x,y+200);
		fondo3.MoverA(x,y+400);
    }

    
    public new void DibujarOculta()
	{
			fondo1.DibujarOculta();
			fondo2.DibujarOculta();
			fondo3.DibujarOculta();
	}
} /* fin de la clase Fondo */
