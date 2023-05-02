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
    class CreadorClasesControles : OperacionUtileSpring
    {
        public CreadorClasesControles(ConfiguracionGeneral cnf) : base(cnf)
        {
        }
        public void crearClasesControlador()
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
                string nombreArchivoJava = nombreClase + "Controller";
                string extencion = ".java";
                FileInfo archivoClase = new FileInfo(
                    cnf.carpetaController.ToString() + @"\"
                    + nombreArchivoJava + extencion
                    );
                if (!Archivos.existeArchivo(archivoClase))
                {
                    Archivos.crearTEXTO(cnf.carpetaController
                        , nombreArchivoJava, extencion, getClaseControlesStr(nombreClase));
                }
            }
        }
        public string getClaseControlesStr(string nombre)
        {
            int separacion0 = 0;
            string separacion = getSeparacionln(0, separacion0);
            string separacion1 = getSeparacionln(1, separacion0);
            string separacion2 = getSeparacionln(2, separacion0);
            string separacion3 = getSeparacionln(3, separacion0);
            string separacion4 = getSeparacionln(4, separacion0);

            string nombreVeriableServices = getNombreClaseVariableServices(nombre);
            string nombreClaseServices = getNombreClaseServices(nombre);
            string nombreVeriable = getNombreClaseVariable(nombre);
            string tipoDeDatoId = getTipoDeDatoID_Deafult();

            string mr = "";
            mr += separacion + "package " + cnf.paquete + ".controller;";
            mr += separacion + "import java.net.URI;";
            mr += separacion + "import java.net.URISyntaxException;";
            mr += separacion + "import java.util.List;";
            mr += separacion + "import javax.persistence.EntityNotFoundException;";
            mr += separacion + "import org.springframework.beans.factory.annotation.Autowired;";
            mr += separacion + "import org.springframework.http.HttpStatus;";
            mr += separacion + "import org.springframework.http.MediaType;";
            mr += separacion + "import org.springframework.http.ResponseEntity;";
            mr += separacion + "import org.springframework.web.bind.annotation.DeleteMapping;";
            mr += separacion + "import org.springframework.web.bind.annotation.GetMapping;";
            mr += separacion + "import org.springframework.web.bind.annotation.PathVariable;";
            mr += separacion + "import org.springframework.web.bind.annotation.PostMapping;";
            mr += separacion + "import org.springframework.web.bind.annotation.PutMapping;";
            mr += separacion + "import org.springframework.web.bind.annotation.RequestBody;";
            mr += separacion + "import org.springframework.web.bind.annotation.RequestMapping;";
            mr += separacion + "import org.springframework.web.bind.annotation.RestController;";
            mr += separacion + "import " + cnf.paquete + ".model.*;";
            mr += separacion + "import " + cnf.paquete + ".services.*;";
            mr += separacion + "@RequestMapping(\"/"+nombre+"\")";
            mr += separacion + "@RestController";
            mr += separacion + "public class "+nombre+"Controller {";
            mr += separacion1 + "@Autowired";
            mr += separacion1 + "private "+nombreClaseServices+" "+nombreVeriableServices+";";
            mr += separacion1 + "@GetMapping(path = { \"/findAll\" }, produces = MediaType.APPLICATION_JSON_UTF8_VALUE)";
            mr += separacion1 + "public ResponseEntity<List<"+nombre+">> findAll() {";
            mr += separacion2 + "try {";
            mr += separacion3 + "return new ResponseEntity<List<"+nombre+">>("+nombreVeriableServices+".findAll(), HttpStatus.OK);";
            mr += separacion2 + "} catch (Exception e) {";
            mr += separacion3 + "return new ResponseEntity<>(HttpStatus.NOT_FOUND);";
            mr += separacion2 + "}";
            mr += separacion1 + "}";
            mr += separacion1 + "@GetMapping(path = { \"/find/{id}\" }, produces = MediaType.APPLICATION_JSON_UTF8_VALUE)";
            mr += separacion1 + "public ResponseEntity<"+nombre+"> findById(@PathVariable "+tipoDeDatoId+" id) {";
            mr += separacion2 + "try {";
            mr += separacion3 + "return new ResponseEntity<"+nombre+">("+nombreVeriableServices+".findById(id), HttpStatus.OK);";
            mr += separacion2 + "} catch (Exception e) {";
            mr += separacion3 + "return new ResponseEntity<>(HttpStatus.NOT_FOUND);";
            mr += separacion2 + "}";
            mr += separacion1 + "}";
            mr += separacion1 + "@PostMapping(path = { \"/create\" }, produces = MediaType.APPLICATION_JSON_UTF8_VALUE)";
            mr += separacion1 + "public ResponseEntity<"+nombre+"> create"+nombre+"(";
            mr += separacion3 + "@RequestBody "+nombre+" "+nombreVeriable+") throws URISyntaxException {";
            mr += separacion2 + ""+nombre+" result = "+nombreVeriableServices+".save("+nombreVeriable+");";
            mr += separacion2 + "return ResponseEntity.created(new URI(\"/"+nombre+"/create/\" + result.getId())).body(result);";
            mr += separacion1 + "}";
            mr += separacion1 + "@PutMapping(path = { \"/update\" }, produces = MediaType.APPLICATION_JSON_UTF8_VALUE)";
            mr += separacion1 + "public ResponseEntity<"+nombre+"> update(@RequestBody "+nombre+" "+nombreVeriable+") throws URISyntaxException {";
            mr += separacion2 + "if ("+nombreVeriable+".getId()==null) {";
            mr += separacion3 + "return new ResponseEntity<"+nombre+">(HttpStatus.NOT_FOUND);";
            mr += separacion2 + "}";
            mr += separacion2 + "try {";
            mr += separacion3 + ""+nombre+" result = "+nombreVeriableServices+".update("+nombreVeriable+");";
            mr += separacion3 + "return ResponseEntity.created(new URI(\"/"+nombre+"/updated/\" + result.getId())).body(result);";
            mr += separacion2 + "} catch (EntityNotFoundException e) {";
            mr += separacion3 + "return new ResponseEntity<>(HttpStatus.NOT_FOUND);";
            mr += separacion2 + "}";
            mr += separacion1 + "}";
            mr += separacion1 + "@DeleteMapping(path = { \"/delete/{id}\" }, produces = MediaType.APPLICATION_JSON_UTF8_VALUE)";
            mr += separacion1 + "public ResponseEntity<Void> delete(@PathVariable "+tipoDeDatoId+" id) {";
            mr += separacion2 + ""+nombreVeriableServices+".delete(id);";
            mr += separacion2 + "return ResponseEntity.ok().build();";
            mr += separacion1 + "}";
            mr += separacion + "}";
            return mr;
        }
        }
}
