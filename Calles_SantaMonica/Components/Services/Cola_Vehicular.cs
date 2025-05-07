using System.Transactions;

namespace Calles_SantaMonica.Components.Services
{
    public class Cola_Vehicular
    {
        public Nodo_Simple? PrimerNodo;
        public Nodo_Simple? UltimoNodo;
        Nodo_Simple? NuevoNodo;


        public Cola_Vehicular()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }
        public bool esta_vacia()
        {
            return PrimerNodo == null ? true : false;
        }

        public void agregar_vehiculo(Vehiculo nuevo_vehiculo)
        {
            if (nuevo_vehiculo != null)
            {
                NuevoNodo = new Nodo_Simple(nuevo_vehiculo);

                if (esta_vacia())
                {
                    PrimerNodo = NuevoNodo;
                }
                else
                {
                    UltimoNodo.Liga = NuevoNodo;
                }

                UltimoNodo = NuevoNodo;
            }
        }

        public Vehiculo? mover_vehiculo()
        {

            if (!esta_vacia())
            {
                Nodo_Simple NodoAuxiliar = new Nodo_Simple();
                NodoAuxiliar = PrimerNodo;
                Vehiculo vehiculo_ac = NodoAuxiliar.vehiculo;

                if (PrimerNodo == UltimoNodo)
                {
                    PrimerNodo = UltimoNodo = null;
                }
                else
                {
                    PrimerNodo = PrimerNodo.Liga;
                }
                return vehiculo_ac;

            }
            else
            {
                return null;
            }


        }

        public string RecorrerLista(Nodo_Simple? NodoActual)
        {
            if (NodoActual == null)
            {
                return "";
            }
            else
            {
                string informacion = NodoActual.vehiculo.get_informacion();
                return $"{informacion} | {RecorrerLista(NodoActual.Liga)}";
            }
        }
    }
}
