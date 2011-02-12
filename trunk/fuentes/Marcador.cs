/** 
 *   Marcador: muestra vidas, puntos, nivel...
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
   0.02  03-Feb-2011  Miguel Laguardia, Cristian Bautista
                      Muestra las vidas y los puntos 
   0.03  08-Feb-2011  Alejandro Guijarro, Javier Abad
                      Arreglo del marcador de vidas y Banderas
 ---------------------------------------------------- */


public class Marcador
{
    private ElemGrafico imagenVidas;
    private int vidas;
    private ElemGrafico imagenNivel;
    private int nivel;
    //private ElemGrafico Bandera;
        
    private int puntuacion;
    private int mejorPunt;
    
    private int[] posicionesVidas = new int[5];
    private int[] posicionesBanderas = new int[10];
        //private int Banderas;
    

    //private Partida miPartida;
    Fuente tipoDeLetra;

    public Marcador()
    {
        //miPartida = p;
        //array posiciones de naves
        posicionesVidas[0] = 0;
        posicionesVidas[1] = 30;
        posicionesVidas[2] = 60;
        posicionesVidas[3] = 90;
        posicionesVidas[4] = 120;
        
        //array posiciones de banderas
        posicionesBanderas[0] = 0;
        posicionesBanderas[1] = 30;
        posicionesBanderas[2] = 60;
        posicionesBanderas[3] = 90;
        posicionesBanderas[4] = 120;
        posicionesBanderas[5] = 150;
        posicionesBanderas[6] = 180;
		posicionesBanderas[7] = 210;
		posicionesBanderas[8] = 240;
		posicionesBanderas[9] = 270;
		
        tipoDeLetra = new Fuente("FreeSansBold.ttf", 18);
        
    }


    public void IndicarPuntos(int p)
    {
        puntuacion = p;
    }


    public void IndicarNivel(int n)
    {
        nivel = n;
    }


    public void IndicarVidas(byte v)
    {
        vidas = v;
    }


    public  void DibujarOculta()
    {
        imagenVidas = new ElemGrafico("imagenes/vida.png");
        imagenNivel = new ElemGrafico("imagenes/bandera.png");
        //Banderas = new ElemGrafico("imagenes/bandera.png");

        Hardware.EscribirTextoOculta("Puntos: ",
            /* Coordenadas */ 10, 10,  /* Colores */ 50, 255, 50,
            tipoDeLetra);
        Hardware.EscribirTextoOculta(System.Convert.ToString(puntuacion),
            /* Coordenadas */ 100, 10, /* Colores */ 50, 255, 50,
            tipoDeLetra);

        Hardware.EscribirTextoOculta("Maximo: ",
            /* Coordenadas */ 10, 40,  /* Colores */ 50, 255, 50,
            tipoDeLetra);
        Hardware.EscribirTextoOculta(System.Convert.ToString(mejorPunt),
            /* Coordenadas */ 100, 40, /* Colores */ 50, 255, 50,
            tipoDeLetra);
            
        
        // Vidas, como barra (maximo 10 segmentos)
        int navecitas = vidas;
        if (navecitas > 5) navecitas = 5;
        for (int i = 0; i < navecitas; i++)
        {
        	imagenVidas.DibujarOculta(10 + posicionesVidas[i], 550);
        }

        //Hardware.EscribirTextoOculta(System.Convert.ToString(vidas),
          //  /* Coordenadas */ 100, 570,  /* Colores */ 50, 255, 50,
          //  tipoDeLetra);

        // Banderas,(maximo 10 segmentos)
        int banderitas = 5;// Numero de banderitas prestablecido
        if (banderitas > 10)banderitas = 0;
            //Bandera = 1;
        for (int i = 0; i < banderitas; i++)
        {
        	imagenNivel.DibujarOculta(750 - posicionesBanderas[i], 550);
        }

        //Hardware.EscribirTextoOculta("banderitas",
          //  /* Coordenadas */ 750, 570,  /* Colores */ 50, 255, 50,
          //  tipoDeLetra);
    }
} /* fin de la clase Marcador */
