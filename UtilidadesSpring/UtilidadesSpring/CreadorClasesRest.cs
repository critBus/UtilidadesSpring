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
    class CreadorClasesRest : OperacionUtileSpring
    {
        public CreadorClasesRest(ConfiguracionGeneral cnf) : base(cnf)
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
                    || nombreClase == "Authorities"
                    ||nombreClase== "Users")
                {
                    continue;
                }
                string nombreArchivoJava = "Rest"+nombreClase ;
                string extencion = ".java";
                FileInfo archivoClase = new FileInfo(
                    cnf.carpetaRest.ToString() + @"\"
                    + nombreArchivoJava + extencion
                    );
                if (!Archivos.existeArchivo(archivoClase))
                {
                    Archivos.crearTEXTO(cnf.carpetaRest
                        , nombreArchivoJava, extencion, getClaseRestStr(nombreClase));
                }
            }
        }

        public string getClaseRestStr(string nombre)
        {
            int separacion0 = 0;
            string separacion = getSeparacionln(0, separacion0);
            string separacion1 = getSeparacionln(1, separacion0);
            string separacion2 = getSeparacionln(2, separacion0);
            string separacion3 = getSeparacionln(3, separacion0);
            string separacion4 = getSeparacionln(4, separacion0);
            string separacion5 = getSeparacionln(5, separacion0);

            
            string nombreVariable = getNombreClaseVariable(nombre);
            string tipoDeDatoId = getTipoDeDatoID_Deafult();

            string mr = "";
            mr += separacion + "package " + cnf.paqueteRest + ";";
            mr += separacion + "import Entity.*;";
            mr += separacion + "import Utils.JSONUtils;";
            mr += separacion + "import com.fasterxml.jackson.core.JsonProcessingException;";
            mr += separacion + "import com.fasterxml.jackson.core.type.TypeReference;";
            mr += separacion + "import java.io.IOException;";
            mr += separacion + "import java.net.URI;";
            mr += separacion + "import java.net.http.HttpClient;";
            mr += separacion + "import java.net.http.HttpRequest;";
            mr += separacion + "import java.net.http.HttpResponse;";
            mr += separacion + "import java.util.List;";
            mr += separacion + "import java.util.concurrent.CompletableFuture;";
            mr += separacion + "import java.util.concurrent.ExecutionException;";
            mr += separacion + "public class Rest"+nombre+" {";
            mr += separacion1 + "private static final HttpClient client = HttpClient.newBuilder().version(HttpClient.Version.HTTP_2).build();";
            mr += separacion1 + "private static final String serviceURL = \"http://localhost:8081/"+nombre+"/\";";
            mr += separacion1 + "//sending request to retrieve all "+nombreVariable+"s available.";
            //mr += separacion1 + "public List<"+nombre+"> findAll"+nombre+"() {";
            mr += separacion1 + "public List<" + nombre + "> findAll() {";
            mr += separacion2 + "HttpRequest req = HttpRequest.newBuilder(URI.create(serviceURL+\"findAll\")).GET().build();";
            mr += separacion2 + "CompletableFuture<HttpResponse<String>> response = client.sendAsync(req, HttpResponse.BodyHandlers.ofString());";
            mr += separacion2 + "List<"+nombre+"> list_"+nombreVariable+"s = null;";
            mr += separacion2 + "try {";
            mr += separacion3 + "list_"+nombreVariable+"s = JSONUtils.convertFromJsonToList(response.get().body(), new";
            mr += separacion5 + "TypeReference<List<"+nombre+">>() {});";
            mr += separacion2 + "} catch (InterruptedException e) {";
            mr += separacion3 + "e.printStackTrace();";
            mr += separacion2 + "} catch (ExecutionException e) {";
            mr += separacion3 + "e.printStackTrace();";
            mr += separacion2 + "}";
            mr += separacion2 + "response.join();";
            mr += separacion2 + "return list_"+nombreVariable+"s;";
            mr += separacion1 + "}";
            mr += separacion1 + "//send request to add the product details.";
            //mr += separacion1 + "public boolean create"+nombre+"("+nombre+" "+nombreVariable+"){";
            mr += separacion1 + "public boolean create(" + nombre + " " + nombreVariable + "){";
            mr += separacion2 + "String inputJson = null;";
            mr += separacion2 + "inputJson = JSONUtils.covertFromObjectToJson("+nombreVariable+");";
            mr += separacion2 + "HttpRequest request = HttpRequest.newBuilder(URI.create(serviceURL+\"create\"))";
            mr += separacion4 + ".header(\"Content-Type\", \"application/json\")";
            mr += separacion4 + ".POST(HttpRequest.BodyPublishers.ofString(inputJson)).build();";
            mr += separacion2 + "CompletableFuture<HttpResponse<String>> response = client.sendAsync(request,HttpResponse.BodyHandlers.ofString());";
            mr += separacion2 + "try {";
            mr += separacion3 + "if(response.get().statusCode() == 500){";
            mr += separacion4 + "return false;";
            mr += separacion3 + "}";
            mr += separacion2 + "} catch (InterruptedException e) {";
            mr += separacion3 + "e.printStackTrace();";
            mr += separacion3 + "return false;";
            mr += separacion2 + "} catch (ExecutionException e) {";
            mr += separacion3 + "e.printStackTrace();";
            mr += separacion3 + "return false;";
            mr += separacion2 + "}";
            mr += separacion2 + "return true;";
            mr += separacion1 + "}";
            mr += separacion1 + "//send request to update a "+nombre+" details.";
            //mr += separacion1 + "public boolean update"+nombre+"("+nombre+" "+nombreVariable+"){";
            mr += separacion1 + "public boolean update(" + nombre + " " + nombreVariable + "){";
            mr += separacion2 + "String inputJson= null;";
            mr += separacion2 + "inputJson = JSONUtils.covertFromObjectToJson("+nombreVariable+");";
            mr += separacion2 + "HttpRequest request = HttpRequest.newBuilder(URI.create(serviceURL+\"update\"))";
            mr += separacion4 + ".header(\"Content-Type\", \"application/json\")";
            mr += separacion4 + ".PUT(HttpRequest.BodyPublishers.ofString(inputJson)).build();";
            mr += separacion2 + "CompletableFuture<HttpResponse<String>> response = client.sendAsync(request,HttpResponse.BodyHandlers.ofString());";
            mr += separacion2 + "try {";
            mr += separacion3 + "if(response.get().statusCode() == 500){";
            mr += separacion4 + "response.join();";
            mr += separacion4 + "return false;";
            mr += separacion3 + "} else {";
            mr += separacion4 + ""+nombreVariable+" = JSONUtils.covertFromJsonToObject(response.get().body(), "+nombre+".class);";
            mr += separacion4 + "response.join();";
            mr += separacion4 + "return true;";
            mr += separacion3 + "}";
            mr += separacion2 + "} catch (InterruptedException e) {";
            mr += separacion3 + "e.printStackTrace();";
            mr += separacion2 + "} catch (ExecutionException e) {";
            mr += separacion3 + "e.printStackTrace();";
            mr += separacion2 + "}";
            mr += separacion2 + "return false;";
            mr += separacion1 + "}";
            mr += separacion1 + "//send request to delete the "+nombreVariable+" by its "+nombreVariable+"name";
            //mr += separacion1 + "public boolean delete"+nombre+"(String "+nombreVariable+"name) {";
            mr += separacion1 + "public boolean delete(String " + nombreVariable + "name) {";
            mr += separacion2 + "HttpRequest request = HttpRequest.newBuilder(URI.create(serviceURL+\"delete/\"+"+nombreVariable+"name)).DELETE().build();";
            mr += separacion2 + "CompletableFuture<HttpResponse<String>> response = client.sendAsync(request,HttpResponse.BodyHandlers.ofString());";
            mr += separacion2 + "try {";
            mr += separacion3 + "if(response.get().statusCode() == 500) {";
            mr += separacion4 + "response.join();";
            mr += separacion4 + "return false;";
            mr += separacion3 + "} else {";
            mr += separacion4 + ""+nombre+" "+nombreVariable+" = JSONUtils.covertFromJsonToObject(response.get().body(), "+nombre+".class);";
            mr += separacion4 + "response.join();";
            mr += separacion4 + "return true;";
            mr += separacion3 + "}";
            mr += separacion2 + "} catch (InterruptedException e) {";
            mr += separacion3 + "e.printStackTrace();";
            mr += separacion2 + "} catch (ExecutionException e) {";
            mr += separacion3 + "e.printStackTrace();";
            mr += separacion2 + "}";
            mr += separacion2 + "return false;";
            mr += separacion1 + "}";
            mr += separacion + "}";
            return mr;
        }
        }
}
