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
    
    
        //private int Banderas;
    

    //private Partida miPartida;
    Fuente tipoDeLetra;

    public Marcador()
    {
        //miPartida = p;
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


    public void IndicarVidas(int v)
    {
        vidas = v;
    }


    public  void DibujarOculta()
    {
        imagenVidas = new ElemGrafico("imagenes/vida.png");
        imagenNivel = new ElemGrafico("imagenes/bandera.png");
        //Banderas = new ElemGrafico("imagenes/bandera.png");

        Hardware.EscribirTextoOculta("Puntos: ",
            /* Coordenadas */ 100, 100,  /* Colores */ 50, 255, 50,
            tipoDeLetra);
        Hardware.EscribirTextoOculta(System.Convert.ToString(puntuacion),
            /* Coordenadas */ 450, 550, /* Colores */ 50, 255, 50,
            tipoDeLetra);

        Hardware.EscribirTextoOculta("Maximo: ",
            /* Coordenadas */ 350, 570,  /* Colores */ 50, 255, 50,
            tipoDeLetra);
        Hardware.EscribirTextoOculta(System.Convert.ToString(mejorPunt),
            /* Coordenadas */ 400, 100, /* Colores */ 50, 255, 50,
            tipoDeLetra);
            
        
        // Vidas, como barra (maximo 10 segmentos)
        int navecitas = vidas;
        if (navecitas > 5) navecitas = 5;
        for (int i = 0; i < navecitas; i++)
        {
            imagenVidas.DibujarOculta(680 + 20 * i, 550);
        }

        Hardware.EscribirTextoOculta("Vidas",
            /* Coordenadas */ 100, 570,  /* Colores */ 50, 255, 50,
            tipoDeLetra);

        // Banderas,(maximo 10 segmentos)
        int banderitas = nivel;
        if (banderitas > 10)banderitas = 0;
            //Bandera = 1;
        for (int i = 0; i < banderitas; i++)
        {
            imagenNivel.DibujarOculta(150 + 20 * i, 350);
        }

        Hardware.EscribirTextoOculta("banderitas",
            /* Coordenadas */ 750, 570,  /* Colores */ 50, 255, 50,
            tipoDeLetra);
    }
} /* fin de la clase Marcador */
