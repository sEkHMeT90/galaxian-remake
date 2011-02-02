/** 
 *   Presentacion: pantalla de presentación
 * 
 *   Parte de "galaxian-remake"
 *  
 *   @see Hardware
 *   @author 1-DAI IES San Vicente 2010/11
 */

public class Presentacion
{
    public const byte OPC_PARTIDA = 0;
    public const byte OPC_SALIR = 1;
    public const byte OPC_CREDITOS = 2;    
    
    private int opcionEscogida;
    private Fuente fuenteSans18;


    /// Constructor
    public Presentacion()  // Constructor
    {
        fuenteSans18 = new Fuente("FreeSansBold.ttf",18);
    }


    public  void Ejecutar()
    {
        Hardware.BorrarPantallaOculta(0,0,0);  
        
        // Escribo avisos de las teclas utilizables
        Hardware.EscribirTextoOculta(
                "Pulsa J para jugar",
                300, 550, 0xAA, 0xAA, 0xAA, fuenteSans18);
        
        // Finalmente, muestro en pantalla
        Hardware.VisualizarOculta();  
        
        //hasta que se pulse espacio (sin saturar la CPU)
        do {        
          Hardware.Pausa(40);
        } while ((! Hardware.TeclaPulsada(Hardware.TECLA_J) )
                 && (! Hardware.TeclaPulsada(Hardware.TECLA_S))
                 && (! Hardware.TeclaPulsada(Hardware.TECLA_C)));
                 
        opcionEscogida = OPC_PARTIDA;
        if (Hardware.TeclaPulsada(Hardware.TECLA_S))
            opcionEscogida = OPC_SALIR;
        if (Hardware.TeclaPulsada(Hardware.TECLA_C))
            opcionEscogida = OPC_CREDITOS;                  
    }
    
    
    public int GetOpcionEscogida()
    {
        return opcionEscogida;
    }
    
} /* fin de la clase Presentacion */
