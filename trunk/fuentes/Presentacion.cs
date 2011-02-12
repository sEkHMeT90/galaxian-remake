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
  0.03  08-Feb-2011  Andrés Marotta y Manuel Martínez Morant
                      Animación de enemigos en la pantalla
					  de presentación
                    
 ---------------------------------------------------- */

public class Presentacion : ElemGrafico
{
    public const byte OPC_PARTIDA = 0;
    public const byte OPC_SALIR = 1;
    public const byte OPC_CREDITOS = 2;    
    
    private int opcionEscogida;
    private Fuente fuenteSans18;
    private EnemAzul enemigoAzul;
    private EnemRojo enemigoRojo;
    private EnemVioleta enemigoVioleta;
    private EnemAmarillo enemigoAmarillo;
	private int i;

    /// Constructor
    public Presentacion()  // Constructor
    {
        fuenteSans18 = new Fuente("FreeSansBold.ttf",18);
        enemigoAzul = new EnemAzul();
        enemigoRojo = new EnemRojo();
        enemigoVioleta = new EnemVioleta();
        enemigoAmarillo = new EnemAmarillo();
        i = 800;
    }


    public  void Ejecutar()
    {
    	int desplazActual = 600;
    	do
    	{
	        Hardware.BorrarPantallaOculta(0,0,0);
	
	        // Cargo las imagenes de los enemigos
	        enemigoAzul.CargarImagen("imagenes/enemigoA.png");
	        enemigoRojo.CargarImagen("imagenes/enemigoR.png");
	        enemigoVioleta.CargarImagen("imagenes/enemigoV.png");
	        enemigoAmarillo.CargarImagen("imagenes/enemigoM.png");
	    	
	        // Coloco a los enemigos fuera de la pantalla
	        enemigoAzul.MoverA(200+desplazActual,305);
	    	enemigoRojo.MoverA(200+desplazActual, 355);
	    	enemigoVioleta.MoverA(200+desplazActual,405);
	    	enemigoAmarillo.MoverA(200+desplazActual,455);
	        
	    	// Dibujar enemigos en pantalla oculta
	        enemigoAzul.DibujarOculta();
	        enemigoRojo.DibujarOculta();
	        enemigoVioleta.DibujarOculta();
	        enemigoAmarillo.DibujarOculta();
	        
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
	                255, 230, 0xAA, 0xAA, 0xAA, fuenteSans18);
	        Hardware.EscribirTextoOculta(
	                "CONVOY   CHARGER",
	                (short) (300+desplazActual), 260, 0x01, 0xDF, 0xD7, fuenteSans18);
	        Hardware.EscribirTextoOculta(
	                "60          800 PTS",
	                (short) (300+desplazActual), 310, 0x01, 0xDF, 0xD7, fuenteSans18);
	        Hardware.EscribirTextoOculta(
	                "50          100 PTS",
	                (short) (300+desplazActual), 360, 0x01, 0xDF, 0xD7, fuenteSans18);
	        Hardware.EscribirTextoOculta(
	                "40          80 PTS",
	                (short) (300+desplazActual), 410, 0x01, 0xDF, 0xD7, fuenteSans18);
	        Hardware.EscribirTextoOculta(
	                "30          60 PTS",
	                (short) (300+desplazActual), 460, 0x01, 0xDF, 0xD7, fuenteSans18);
	        
	        
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
	        
	        if (desplazActual > 0)
	        	desplazActual -= 4;
	        
	        /*
	        for ( int i = 800 ; i > 280 ; i -= 3 )
	        {
	        	
	        	
	        	
	        	
	        	
		        enemigoAzul.MoverA(i,305);
		    	enemigoRojo.MoverA(i,355);
		    	enemigoVioleta.MoverA(i,405);
		    	enemigoAmarillo.MoverA(i,455);
		    	
		        enemigoAzul.DibujarOculta();
		        enemigoRojo.DibujarOculta();
		        enemigoVioleta.DibujarOculta();
		        enemigoAmarillo.DibujarOculta();
		        
		        Hardware.Pausa(40);
		        Hardware.VisualizarOculta();
		        
		        if ((! Hardware.TeclaPulsada(Hardware.TECLA_J) )
	                 && (! Hardware.TeclaPulsada(Hardware.TECLA_S))
	                 && (! Hardware.TeclaPulsada(Hardware.TECLA_C)));
		        break;
	        }*/
	        
	        //hasta que se pulse espacio (sin saturar la CPU)

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
