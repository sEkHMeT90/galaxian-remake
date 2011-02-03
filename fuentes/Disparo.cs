/** 
 *   Disparo: detalles comunes a todos los disparos
 * 
 *   Parte de "galaxian-remake"
 *  
 *   @see Hardware
 *   @author 1-DAI IES San Vicente 2010/11
 *   
    Num.   Fecha       Por / Cambios
   ---------------------------------------------------
   0.01  02-Feb-2011  Nacho Cabanes
                      Version inicial: esqueleto vacio
   0.02  03-feb-2011  Antonio Pérez, Denys Demyanchuk
                      Indicamos las coordenadas del disparo si es para el enemigo o para el
                        personaje, implementado los incrementos de las variables.                 
 */

public class Disparo : ElemGrafico
{
    public Disparo()
    {
        CargarImagen("imagenes/disparo.png");        
    }

    public void Aparecer(int DisparoX, int DisparoY, int DisparoIncrX, int DisparoIncrY)
    {
        x = (short) DisparoX;
        y = (short)DisparoY;
        incrX = (short) DisparoIncrX;
        incrY = (short) DisparoIncrY;
        visible = true;
    }

    public new void Mover()
    {
        y += (short)incrY;
        x += (short)incrX;

        if ((y < 0) || (y > 800)) 
            Desaparecer();
    }

    public  void Desaparecer()
    {
        visible = false;
    }
} /* fin de la clase Disparo */
