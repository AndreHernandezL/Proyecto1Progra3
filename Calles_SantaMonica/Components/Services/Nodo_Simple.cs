namespace Calles_SantaMonica.Components.Services
{
    public class Nodo_Simple
    {
        public Vehiculo vehiculo;
        public Nodo_Simple? Liga;

        public Nodo_Simple()
        {
            Liga = null;
        }

        public Nodo_Simple (Vehiculo informacion)
        {
            vehiculo = informacion;
            Liga = null;
        }
    }
}
