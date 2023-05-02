using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReneUtiles;
using ReneUtiles.Clases;

using Delimon.Win32.IO;
namespace UtilidadesSpring
{
    class ConfiguracionGeneral
    {
        public DirectoryInfo carpetaModel;
        public DirectoryInfo carpetaRepository;
        public DirectoryInfo carpetaServices;
        public DirectoryInfo carpetaController;

        public DirectoryInfo carpetaRest;
        public string paqueteRest;

        public string paquete;

        public ConfiguracionGeneral(
            string paquete
            , string urlDemo
            ,string paqueteRest
            ,string urlRest
            )
        {
            this.carpetaModel = new DirectoryInfo(urlDemo + @"\model");
            this.carpetaRepository = new DirectoryInfo(urlDemo + @"\repository");
            this.carpetaServices = new DirectoryInfo(urlDemo + @"\services");
            this.carpetaController = new DirectoryInfo(urlDemo + @"\controller");

            this.carpetaRest = new DirectoryInfo(urlRest);
            this.paqueteRest = paqueteRest;
            this.paquete = paquete;
        }
    }
}
