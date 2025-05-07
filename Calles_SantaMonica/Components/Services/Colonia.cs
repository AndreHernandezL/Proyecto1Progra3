using System;
using System.Data;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
namespace Calles_SantaMonica.Components.Services

{
    public class Colonia
    {
        public Nodo_Multiple? Interserccion_Inicial;
        public Nodo_Multiple? Interserccion_Actual;

        string conexionString = "Server=localhost;Database=Santa_Monica;User ID=root;Password=12345;";

        public Colonia() {
            Interserccion_Inicial = null;
            crear_mapa(ReadBDD());
            Interserccion_Actual = Interserccion_Inicial;
        }

        private DataTable ReadBDD()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection conexion = new MySqlConnection(conexionString))
            {
                try
                {
                    conexion.Open();
                    string consulta = "select * from interseccion";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        tabla.Load(lector);
                    }

                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
                }
            }

            return tabla;
        }

        private void crear_mapa(DataTable table)
        {
            //CREAMOS LA SERIE DE NODO
            foreach (DataRow fila in table.Rows)
            {
                string? id = fila["id"].ToString();
                string? avenida = fila["avenida"].ToString();
                string? calle = fila["calle"].ToString();
                string? imagen = fila["imagen"].ToString();

                Interseccion nueva_interseccion = new Interseccion(id, avenida, calle, imagen);
                Nodo_Multiple nuevo_nodo = new Nodo_Multiple(nueva_interseccion);

                if (Interserccion_Inicial != null)
                {
                    Interserccion_Actual.liga = nuevo_nodo;
                    Interserccion_Actual = Interserccion_Actual.liga;
                }
                else
                {
                    Interserccion_Inicial = nuevo_nodo;
                    Interserccion_Actual = Interserccion_Inicial;
                }
            }

            //REFERENCIAR LOS NODOS
            foreach (DataRow fila in table.Rows)
            {
                Interserccion_Actual = Interserccion_Inicial;
                Nodo_Multiple Interseccion_Temporal = new Nodo_Multiple();
                string? id = fila["id"].ToString();

                while (Interserccion_Actual != null)
                {
                    string? id_interseccion = Interserccion_Actual.set_Interseccion().id;
                    if (id.Equals(id_interseccion))
                    {
                        Interseccion_Temporal = Interserccion_Actual;
                        break;
                    }
                    Interserccion_Actual = Interserccion_Actual.liga;
                }

                if (fila["nodo_norte"] is not null)
                {
                    Nodo_Multiple? Interserccion_Actual_N = Interserccion_Inicial;
                    string? nodo_norte = fila["nodo_norte"].ToString();

                    while (Interserccion_Actual_N != null)
                    {
                        string? id_norte = Interserccion_Actual_N.set_Interseccion().id;
                        if (nodo_norte.Equals(id_norte))
                        {
                            Interseccion_Temporal.nodo_norte = Interserccion_Actual_N;
                            break;
                        }
                        Interserccion_Actual_N = Interserccion_Actual_N.liga;
                    }
                }

                if (fila["nodo_sur"] is not null)
                {
                    Nodo_Multiple? Interserccion_Actual_S = Interserccion_Inicial;
                    string? nodo_sur = fila["nodo_sur"].ToString();

                    while (Interserccion_Actual_S != null)
                    {
                        string? id_sur = Interserccion_Actual_S.set_Interseccion().id;
                        if (nodo_sur.Equals(id_sur))
                        {
                            Interseccion_Temporal.nodo_sur = Interserccion_Actual_S;
                            break;
                        }
                        Interserccion_Actual_S = Interserccion_Actual_S.liga;
                    }
                }

                if (fila["nodo_este"] is not null)
                {
                    Nodo_Multiple? Interserccion_Actual_E = Interserccion_Inicial;
                    string? nodo_este = fila["nodo_este"].ToString();

                    while (Interserccion_Actual_E != null)
                    {
                        string? id_este = Interserccion_Actual_E.set_Interseccion().id;
                        if (nodo_este.Equals(id_este))
                        {
                            Interseccion_Temporal.nodo_este = Interserccion_Actual_E;
                            break;
                        }
                        Interserccion_Actual_E = Interserccion_Actual_E.liga;
                    }
                }

                if (fila["nodo_oeste"] is not null)
                {
                    Nodo_Multiple? Interserccion_Actual_O = Interserccion_Inicial;
                    string? nodo_oeste = fila["nodo_oeste"].ToString();

                    while (Interserccion_Actual_O != null)
                    {
                        string? id_oeste = Interserccion_Actual_O.set_Interseccion().id;
                        if (nodo_oeste.Equals(id_oeste))
                        {
                            Interseccion_Temporal.nodo_oeste = Interserccion_Actual_O;
                            break;
                        }
                        Interserccion_Actual_O = Interserccion_Actual_O.liga;
                    }
                }
            }
        }
        

    }
}
