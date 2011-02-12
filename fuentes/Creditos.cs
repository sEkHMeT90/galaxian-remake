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
   0.02  03-Feb-2011  Julio Antoranz, Ethan Martinez
                      Escribe un texto de ejemplo
   0.02  03-Feb-2011  Miguel Laguardia , Raquel Lloréns
             		  Creditos Actualizados sin animacion
             		  
            
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

        byte color = 0xAA;
        
        int i;
        short x, y;
        
        string[] nombresCreditos = {
          
          "Javier Abad", "Julio Antoranz", "Cristian Bautista", "Denys Demyanchuk",
          "David Guerra", "Alejandro Guijarro", "Alejandro Guillén", "Miguel Laguardia",
          "Raquel Lloréns", "Daniel Marin", "Andrés Marotta", "David Martinez",
          "Ethan Martinez", "Manuel Martinez", "María Navarro", "Héctor Pastor",
          "Antonio Pérez", "Antonio Ramos", "J.M. Rizos", "Francisco Royo",
          "Aitor Salgado", "Pedro Zalacaín", "Nacho Cabanes",
        };
        
        while (!salir)
        {

            Hardware.BorrarPantallaOculta(0, 0, 0); // Borro en negro

            Hardware.EscribirTextoOculta(
                "Galaga Galaxian (Remake) - Creditos", 220, 40,
                  0xFF, 0x00, 0x00, fuenteSans18);

            Hardware.EscribirTextoOculta("Programa original:  Galaxian  (c) 1979 ", 80, 100,
                  color, color, color, fuenteSans18);
            
                 
            
            Hardware.EscribirTextoOculta("Remake: 2011 ", 80, 120,
                  color, color, color, fuenteSans18);
           

            Hardware.EscribirTextoOculta(
                  "Pulsa ESC para volver a la presentación...",
                  80, 550, 0xAA, 0xAA, 0xAA, fuenteSans12);

			
              // Escribir nombres
            
            x = 80;
            y = 180;
			for ( i = 0 ; i < nombresCreditos.Length ; i++ ) {
                Hardware.EscribirTextoOculta(nombresCreditos[i],
                        /* Coordenadas */ x,y,
                        /* Colores */ 0x01,(byte) (0xDF - i*5), 0xDF,
                        fuenteSans18);

                y = (short)(y + 30);
                if (y > 450) { x += 260; y = 180; }

            }
            Hardware.VisualizarOculta();
            Hardware.Pausa(40);

            salir = Hardware.TeclaPulsada(Hardware.TECLA_ESC);
        }
    }

} /* fin de la clase Creditos */
