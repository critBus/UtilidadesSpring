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
    class CreadorClasesServicios : OperacionUtileSpring
    {
        public CreadorClasesServicios(ConfiguracionGeneral cnf) : base(cnf)
        {
        }

        public void crearClasesServicios()
        {
            List<string> nombreClases = new List<string>();
            Archivos.recorrerArchivosExternos(cnf.carpetaModel,
                f => nombreClases.Add(Archivos.getNombre(f)));
            foreach (string nombreClase in nombreClases)
            {
                if (nombreClase == "AuthoritiesPK"
                    || nombreClase == "Authorities")
                {
                    continue;
                }
                string nombreArchivoJava = nombreClase + "Services";
                string extencion = ".java";
                FileInfo archivoClase = new FileInfo(
                    cnf.carpetaServices.ToString() + @"\"
                    + nombreArchivoJava + extencion
                    );
                if (!Archivos.existeArchivo(archivoClase))
                {
                    Archivos.crearTEXTO(cnf.carpetaServices
                        , nombreArchivoJava, extencion, getClaseServicesStr(nombreClase));
                }
            }
        }

        public string getClaseServicesStr(string nombre)
        {
            int separacion0 = 0;
            string separacion = getSeparacionln(0, separacion0);
            string separacion1 = getSeparacionln(1, separacion0);
            string separacion2 = getSeparacionln(2, separacion0);
            string separacion3 = getSeparacionln(3, separacion0);
            string separacion4 = getSeparacionln(4, separacion0);

            string nombreVeriableRepository = getNombreClaseVariableRepository(nombre);
            string nombreClaseRepository = getNombreClaseRepository(nombre);
            string nombreVeriable = getNombreClaseVariable(nombre);
            string tipoDeDatoId = getTipoDeDatoID_Deafult();

            string mr = "";
            mr += separacion + "package " + cnf.paquete + ".services;";
            mr += separacion + "import java.util.List;";
            mr += separacion + "import javax.persistence.EntityExistsException;";
            mr += separacion + "import javax.persistence.EntityNotFoundException;";
            mr += separacion + "import " + cnf.paquete + ".model.*;";
            mr += separacion + "import " + cnf.paquete + ".repository.*;";
            mr += separacion + "import org.springframework.beans.factory.annotation.Autowired;";
            mr += separacion + "import org.springframework.stereotype.Service;";
            mr += separacion + "@Service";
            mr += separacion + "public class " + nombre + "Services {";
            mr += separacion1 + "@Autowired";
            mr += separacion1 + "private "+ nombreClaseRepository +" "+ nombreVeriableRepository + ";";
            mr += separacion1 + "public List<"+nombre+ "> findAll() {";
            mr += separacion2 + "return " + nombreVeriableRepository + ".findAll();";
            mr += separacion1 + "}";
            mr += separacion1 + "public "+ nombre + " findById("+tipoDeDatoId+" id) {";
            mr += separacion2 + "return " + nombreVeriableRepository + ".findById(id).get();";
            mr += separacion1 + "}";
            mr += separacion1 + "public " + nombre + " save("+nombre+" "+ nombreVeriable+ ") {";
            mr += separacion2 + "if ("+ nombreVeriable + ".getId()!=null && "+ nombreVeriableRepository + ".existsById(" + nombreVeriable + ".getId())) {";
            mr += separacion3 + "throw new EntityExistsException(\"There is already existing entity with such ID in the database.\");";
            mr += separacion2 + "}";
            mr += separacion2 + "return "+ nombreVeriableRepository + ".save("+ nombreVeriable + ");";
            mr += separacion1 + "}";
            mr += separacion1 + "public " + nombre + " update(" + nombre + " " + nombreVeriable + ") {";
            mr += separacion2 + "if (" + nombreVeriable + ".getId()!=null && !" + nombreVeriableRepository + ".existsById(" + nombreVeriable + ".getId())) {";
            mr += separacion3 + "throw new EntityExistsException(\"There is no entity with such ID in the database.\");";
            mr += separacion2 + "}";
            mr += separacion2 + "return " + nombreVeriableRepository + ".save(" + nombreVeriable + ");";
            mr += separacion1 + "}";
            mr += separacion1 + "public void delete("+tipoDeDatoId+" id) {";
            mr += separacion2 + nombreVeriableRepository + ".deleteById(id);";
            mr += separacion1 + "}";
            mr += separacion + "}";


            return mr;
        }
    }
}
