using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReneUtiles;
using ReneUtiles.Clases;
namespace UtilidadesSpring
{
    class Program:ConsolaBasica
    {
        static void Main(string[] args)
        {
            generalClases();
            endC();
        }

        public static void generalClases() {
            ConfiguracionGeneral cnf = new ConfiguracionGeneral(
                "cu.edu.unah.demo"
                , @"D:\_Cosas\pincha\Isbel\Spring Security RestApi - Spring Boot Proyect modificar\RestApiCapasitacionUniversitaria\src\main\java\cu\edu\unah\demo"
                , "Rest"
                , @"D:\_Cosas\pincha\Isbel\CapasitacionUniversitariaWeb\src\main\java\Rest"
                );
            //new CreadorClasesRepositorio(cnf).crearClasesRepository();
            //new CreadorClasesServicios(cnf).crearClasesServicios();
            //new CreadorClasesControles(cnf).crearClasesControlador();
            new CreadorClasesRest(cnf).crearClasesControlador();
            cwl("termino");
        }
    }
}
