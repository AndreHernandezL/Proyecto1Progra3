namespace Calles_SantaMonica.Components.Services
{
    public class Vehiculo
    {
        string matricula;
        string tipo_vehiculo;

        public Vehiculo (string matricula_, string tipo_vehiculo_)
        {
            this.matricula = matricula_;
            this.tipo_vehiculo = tipo_vehiculo_;
        }

        public string get_informacion()
        {
            return $"{tipo_vehiculo}: {matricula}";
        }
    }
}
