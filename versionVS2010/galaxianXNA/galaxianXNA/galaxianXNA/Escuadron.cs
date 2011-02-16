/**
 *   Escuadron: bloque de 4 enemigos (amarillo + 3 rojos)
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
   0.02  03-Feb-2011  Daniel Marin, David Martinez
                      Creado escuadrón con un enemigo amarillo
                        y 3 enemigos rojos
                      Creado booleano para saber cuando está con la flota
                      Getter del booleano y Setters del booleano y de los enemigos
                      Constructor de la clase indicando como parámetro la Flota 
                        a la que pertenece
 ---------------------------------------------------- */

namespace galaxianXNA
{
    class Escuadron
    {
        Flota myFlota;
        EnemRojo[] myEnemRojos;
        EnemAmarillo myEnemAmarillo;

        // Para saber cuando se mueven por su cuenta o con la flota;
        private bool enFlota;


        public Escuadron(Flota nuevaFlota)
        {
            myFlota = nuevaFlota;
            enFlota = true;
        }

        public void Mover()
        {
            for (byte i = 0; i < myEnemRojos.Length; i++)
                myEnemRojos[i].Mover();

            myEnemAmarillo.Mover();
        }

        public void SetEnFlota(bool nuevo)
        {
            enFlota = nuevo;
        }

        public bool GetEnFlota()
        {
            return enFlota;
        }


        public void SetEnemAmarillo(EnemAmarillo nuevoEnemAmarillo)
        {
            myEnemAmarillo = nuevoEnemAmarillo;
        }

        public void SetEnemRojos(EnemRojo[] nuevoEnemRojos)
        {
            byte longitud = (byte)nuevoEnemRojos.Length;
            myEnemRojos = new EnemRojo[longitud];

            for (byte i = 0; i < longitud; i++)
            {
                myEnemRojos[i] = nuevoEnemRojos[i];
            }
        } 
    }
}
