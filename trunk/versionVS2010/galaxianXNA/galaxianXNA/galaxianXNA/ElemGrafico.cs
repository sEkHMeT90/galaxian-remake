/** 
 *   ElemGrafico: elemento gráfico
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
  0.04  16-Feb-2011  Nacho Cabanes
            	      Adaptación básica a XNA
  0.05  17-Feb-2011  Fran Royo, Alex Guillen, David Guerra.
            	      Carga secuencia de imagenes
 ---------------------------------------------------- */

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace galaxianXNA
{
    public class ElemGrafico
    {
        protected Texture2D miImagen;
        protected int x, y;
        protected int incrX, incrY;
        protected int ancho, alto;
        protected ContentManager miGestorContenido;
        protected bool contieneImagen = false;
        protected bool contieneSecuencia = false;
        protected bool visible;
        protected Texture2D[] misImagenes; //cREmos un array texture2d



        public ElemGrafico(string nombreFichero, ContentManager c)
        {
            x = 0; y = 0;
            incrX = 0; incrY = 0;
            CargarImagen(nombreFichero, c);
            visible = true;
            ancho = 32; alto = 32;  // Valores por defecto
        }

        /// Mueve el elemento grafico a otra posicion
        public void MoverA(int nuevaX, int nuevaY)
        {
            x = (short)nuevaX;
            y = (short)nuevaY;
        }

        /// Carga la imagen que representara a este elemento grafico
        public void CargarImagen(string nombre, ContentManager contenido)
        {
            //miImagen = Texture2D.FromStream(miPartida.GetGraphics(), 
            //    new FileStream ( nombre ,FileMode.Open ) );
            miImagen = contenido.Load<Texture2D>(nombre);
            //miGestorContenido = c;

            contieneImagen = true;
            contieneSecuencia = false;
        }

        /// Carga la secuencia de imagenes imagen2D
        public void CargarSecuencia(string[] nombre, ContentManager contenido)
        {
            //miImagen = Texture2D.FromStream(miPartida.GetGraphics(), 
            //    new FileStream ( nombre ,FileMode.Open ) );
            for (int i = 0; i < nombre.Length; i++ )
                misImagenes[i] = contenido.Load<Texture2D>(nombre[i]);
            //miGestorContenido = c;

            contieneImagen = true;
            contieneSecuencia = true;
        }

        /// Dibuja en pantalla oculta, como parte de un "SpriteBatch"
        public void DibujarOculta(SpriteBatch listaSprites)
        {
            if (visible)
                listaSprites.Draw(miImagen, new Vector2(x, y), Color.White);
        }


        /// Dibuja en pantalla oculta en ciertas coordenadas
        public void DibujarOculta(int nuevaX, int nuevaY, SpriteBatch listaSprites)
        {
            MoverA(nuevaX, nuevaY);
            listaSprites.Draw(miImagen, new Vector2(x, y), Color.White);
        }

        /// Devuelve el valor de x
        public short GetX()
        {
            return (short) x;
        }

        /// Devuelve el valor de y
        public short GetY()
        {
            return (short) y;
        }

        /// Cambia el ancho y el alto
        public void SetAnchoAlto(short an, short al)
        {
            alto = al;
            ancho = an;
        }

        /// Devuelve si está visible
        public bool GetActivo()
        {
            return visible;
        }

        /// Cambia si está visible o no )
        public void SetVisible(bool a)
        {
            visible = a;
        }


        /// Comprueba si ha chocado con otro elemento gráfico
        public bool ColisionCon(ElemGrafico otroElem)
        {
            // No se debe chocar con un elemento oculto      
            if ((visible == false) || (otroElem.visible == false))
                return false;
            // Ahora ya compruebo coordenadas
            if ((otroElem.x + otroElem.ancho > x)
                && (otroElem.y + otroElem.alto > y)
                && (x + ancho > otroElem.x)
                && (y + alto > otroElem.y))
                return true;
            else
                return false;
        }


    }
}
