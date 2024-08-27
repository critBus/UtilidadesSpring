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
            
            //cwl("algo");
            endC();
        }

        public static void generalClases() {
            ConfiguracionGeneral cnf = new ConfiguracionGeneral(
                "cu.edu.unah.demo"
                , @"D:\TRABAJO\NotasEstudiantes\experimentos\automatico"
                , "Rest"
                , @"D:\TRABAJO\NotasEstudiantes\experimentos\automatico"
                );
            //ConfiguracionGeneral cnf = new ConfiguracionGeneral(
            //    "cu.edu.unah.demo"
            //    , @"D:\_Cosas\pincha\Isbel\Spring Security RestApi - Spring Boot Proyect modificar\RestApiCapasitacionUniversitaria\src\main\java\cu\edu\unah\demo"
            //    , "Rest"
            //    , @"D:\_Cosas\pincha\Isbel\CapasitacionUniversitariaWeb_JAVA_8\src\java\Rest"
            //    );
            new CreadorClasesRepositorio(cnf).crearClasesRepository();
            new CreadorClasesServicios(cnf).crearClasesServicios();
            new CreadorClasesControles(cnf).crearClasesControlador();
            //new CreadorClasesRestJava8(cnf).crearClasesRest();
            cwl("termino2");
        }
    }
}
