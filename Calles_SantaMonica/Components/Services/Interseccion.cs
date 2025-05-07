namespace Calles_SantaMonica.Components.Services
{
    public class Interseccion
    {
        public string? id;
        public string? avenida;
        public string? calle;
        public string? imagen;
        public bool semaforo;
        public Cola_Vehicular cola_vehicular;

        public Interseccion(string? id_, string? avenida_, string? calle_, string? imagen_, bool semaforo_)
        {
            this.id = id_;
            this.avenida = avenida_;
            this.calle = calle_;
            this.imagen = imagen_;
            this.semaforo = semaforo_;
            cola_vehicular = new Cola_Vehicular();
        }
    }
}
