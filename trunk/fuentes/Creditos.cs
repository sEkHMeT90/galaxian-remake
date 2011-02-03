/** 
 *   Creditos: pantalla con información sobre los autores
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


public class Creditos
{
    // Atributos
    private Fuente fuenteSans18;
    private Fuente fuenteSans12;

    public Creditos()  // Constructor
    {
        fuenteSans18 = new Fuente("FreeSansBold.ttf", 18);
        fuenteSans12 = new Fuente("FreeSansBold.ttf", 12);
    }


    /// Lanza la pantalla de creditos
    public void Ejecutar()
    {
        bool salir = false;

        byte color = 0x55;
        while (!salir)
        {

            Hardware.BorrarPantallaOculta(0, 0, 0); // Borro en negro

            Hardware.EscribirTextoOculta(
                "Galaga Galaxian (Remake) - Creditos", 110, 100,
                  0x77, 0x77, color, fuenteSans18);

            Hardware.EscribirTextoOculta("Programa original:", 200, 240,
                  color, color, 0, fuenteSans18);
            Hardware.EscribirTextoOculta("Galaxian", 200, 270,
                  color, color, 0, fuenteSans18);
            Hardware.EscribirTextoOculta("(c) 1979", 200, 300,
                  color, color, 0, fuenteSans18);

            Hardware.EscribirTextoOculta("Remake:", 200, 360,
                  color, color, 0, fuenteSans18);
            Hardware.EscribirTextoOculta("2011", 200, 390,
                  color, color, 0, fuenteSans18);

            Hardware.EscribirTextoOculta(
                  "Pulsa ESC para volver a la presentación...",
                  110, 550, 0xAA, 0xAA, 0xAA, fuenteSans12);


            Hardware.VisualizarOculta();
            Hardware.Pausa(40);

            salir = Hardware.TeclaPulsada(Hardware.TECLA_ESC);
        }
    }

} /* fin de la clase Creditos */