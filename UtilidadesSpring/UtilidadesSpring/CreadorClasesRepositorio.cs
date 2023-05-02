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
    class CreadorClasesRepositorio: OperacionUtileSpring
    {
        public CreadorClasesRepositorio(ConfiguracionGeneral cnf) : base(cnf)
        {
        }

        public void crearClasesRepository() {
            List<string> nombreClases = new List<string>();
            Archivos.recorrerArchivosExternos(cnf.carpetaModel,
                f => nombreClases.Add(Archivos.getNombre(f)));
            foreach (string nombreClase in nombreClases)
            {
                if (nombreClase== "AuthoritiesPK") {
                    continue;
                }
                string nombreArchivoJava = nombreClase + "Repository";
                string extencion = ".java";
                FileInfo archivoClase = new FileInfo(
                    cnf.carpetaRepository.ToString()+@"\"
                    + nombreArchivoJava+ extencion
                    );
                if (!Archivos.existeArchivo(archivoClase)) {
                    Archivos.crearTEXTO(cnf.carpetaRepository
                        , nombreArchivoJava, extencion, getClaseRepositoryStr(nombreClase));
                }
            }
        }

        public string getClaseRepositoryStr(string nombre) {
            int separacion0 = 0;
            string separacion = getSeparacionln(0, separacion0);
            string separacion1 = getSeparacionln(1, separacion0);
            string separacion2 = getSeparacionln(2, separacion0);
            string separacion3 = getSeparacionln(3, separacion0);
            string separacion4 = getSeparacionln(4, separacion0);

            string mr = "";
            mr += separacion + "package "+ cnf.paquete + ".repository;";
            mr += separacion + "import java.util.List;";
            mr += separacion + "import org.springframework.data.jpa.repository.JpaRepository;";
            mr += separacion + "import org.springframework.stereotype.Repository;";
            mr += separacion + "import " + cnf.paquete + ".model.*;";
            mr += separacion + "@Repository";
            mr += separacion + "public interface "+nombre+ "Repository extends JpaRepository<" + nombre + ",Integer>{";
            mr += separacion + "}";


            return mr;
        }


        
    }
}
