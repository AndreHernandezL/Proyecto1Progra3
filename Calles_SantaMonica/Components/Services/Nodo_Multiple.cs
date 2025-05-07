namespace Calles_SantaMonica.Components.Services
{
    public class Nodo_Multiple
    {
        Interseccion Interseccion;
        internal Nodo_Multiple? liga;
        public Nodo_Multiple? nodo_norte;
        public Nodo_Multiple? nodo_sur;
        public Nodo_Multiple? nodo_este;
        public Nodo_Multiple? nodo_oeste;

        public Nodo_Multiple()
        {
            liga = null;
        }
        public Nodo_Multiple (Interseccion interseccion_)
        {
            this.Interseccion = interseccion_;
            liga = null;
            nodo_norte = null;
            nodo_sur = null;
            nodo_este = null;
            nodo_oeste = null;
        }

        public Interseccion set_Interseccion()
        {
            return Interseccion;
        }
    }
}
