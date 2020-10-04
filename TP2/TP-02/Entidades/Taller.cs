using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller 
    {
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
        public enum ETipo
        {
            Ciclomotor, Sedan, Suv, Todos
        }

        #region "Constructores"
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
       
        #endregion

       
        public static string Listar(Taller t, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", t.vehiculos.Count, t.espacioDisponible);
            sb.AppendLine("");

            foreach(Vehiculo vehiculo in t.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Sedan:
                        if(vehiculo is Sedan)
                        sb.AppendLine(vehiculo.Mostrar());
                        break;

                    case ETipo.Suv:
                        if (vehiculo is Suv)
                        sb.AppendLine(vehiculo.Mostrar());
                        break;

                    case ETipo.Ciclomotor:
                        if (vehiculo is Ciclomotor)
                        sb.AppendLine(vehiculo.Mostrar());
                        break;

                    default:
                        sb.AppendLine(vehiculo.Mostrar());
                        break;

                }
            }

            return sb.ToString();



        }

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            int hayVehiculo = 0;
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo)
                {
                    hayVehiculo = 1;
                }
            }

            if (hayVehiculo == 0 && taller.vehiculos.Count() < taller.espacioDisponible)
            {
                taller.vehiculos.Add(vehiculo);
            }

            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
                    if (taller.vehiculos.Contains(vehiculo))
                    {
                        taller.vehiculos.Remove(vehiculo);
                    }

                    return taller;


        }
        #endregion




        
    }
}
