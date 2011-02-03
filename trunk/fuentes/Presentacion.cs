/** 
 *   Presentacion: pantalla de presentación
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
  0.02  03-Feb-2011  Raquel Lloréns y María Navarro
                      Pantalla principal estática
 ---------------------------------------------------- */

public class Presentacion : ElemGrafico
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

        CargarImagen("imagenes/enemigoM.png");
        MoverA(100, 100);
        CargarImagen("imagenes/enemigoR.png");
        MoverA(200, 100);

        //Escribo la pantalla de presentación
        Hardware.EscribirTextoOculta(
                "WE  ARE  THE  GALAXIANS",
                270, 120, 0xFF, 0x00, 0x00, fuenteSans18);
        Hardware.EscribirTextoOculta(
                "MISSION:        DESTROY  ALIENS",
                240, 150, 0xFF, 0x00, 0x00, fuenteSans18);

        //Escribo las puntuaciones de los enemigos
        Hardware.EscribirTextoOculta(
                "-   SCORE  ADVANCE  TABLE   -",
                255, 250, 0xAA, 0xAA, 0xAA, fuenteSans18);
        Hardware.EscribirTextoOculta(
                "CONVOY   CHARGER",
                300, 280, 0x01, 0xDF, 0xD7, fuenteSans18);
        Hardware.EscribirTextoOculta(
                "60          800 PTS",
                330, 310, 0x01, 0xDF, 0xD7, fuenteSans18);
        Hardware.EscribirTextoOculta(
                "50          100 PTS",
                330, 340, 0x01, 0xDF, 0xD7, fuenteSans18);
        Hardware.EscribirTextoOculta(
                "40          80 PTS",
                330, 370, 0x01, 0xDF, 0xD7, fuenteSans18);
        Hardware.EscribirTextoOculta(
                "30          60 PTS",
                330, 400, 0x01, 0xDF, 0xD7, fuenteSans18);
        
        
        
        // Escribo avisos de las teclas utilizables
        Hardware.EscribirTextoOculta(
                "Pulsa J para jugar",
                320, 510, 0xAA, 0xAA, 0xAA, fuenteSans18);
        Hardware.EscribirTextoOculta(
                "Pulsa C para ver los créditos",
                270, 540, 0xAA, 0xAA, 0xAA, fuenteSans18);
        Hardware.EscribirTextoOculta(
                "Pulsa S para salir",
                320, 570, 0xAA, 0xAA, 0xAA, fuenteSans18);
        
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
