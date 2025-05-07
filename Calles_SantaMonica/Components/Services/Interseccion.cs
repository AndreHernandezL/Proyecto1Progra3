namespace Calles_SantaMonica.Components.Services
{
    public class Interseccion
    {
        public string? id;
        public string? avenida;
        public string? calle;
        public string? imagen;
        public Cola_Vehicular cola_vehicular;

        public Interseccion(string? id_, string? avenida_, string? calle_, string? imagen_)
        {
            this.id = id_;
            this.avenida = avenida_;
            this.calle = calle_;
            this.imagen = imagen_;
            cola_vehicular = new Cola_Vehicular();
        }
    }
}
