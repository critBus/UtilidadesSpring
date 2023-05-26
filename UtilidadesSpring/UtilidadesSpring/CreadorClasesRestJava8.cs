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
    class CreadorClasesRestJava8 : OperacionUtileSpring
    {
        public CreadorClasesRestJava8(ConfiguracionGeneral cnf) : base(cnf)
        {


        }
        public void crearClasesRest()
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

            mr += separacion + "import Entity."+nombre+";";
            mr += separacion + "import Utils.JSONUtils;";
            mr += separacion + "import java.io.BufferedReader;";
            mr += separacion + "import java.io.IOException;";
            mr += separacion + "import java.io.InputStreamReader;";
            mr += separacion + "import java.net.HttpURLConnection;";
            mr += separacion + "import java.net.URI;";
            mr += separacion + "import java.net.URL;";
            mr += separacion + "import java.util.List;";
            mr += separacion + "import java.util.function.Function;";
            mr += separacion + "import com.fasterxml.jackson.core.type.TypeReference;";
            mr += separacion + "public class Rest"+nombre+" {";
            mr += separacion1 + "private static final String serviceURL = \"http://localhost:8081/"+nombre+"/\";";
            mr += separacion1 + "// sending request to retrieve a "+nombre+" by its id.";
            mr += separacion1 + "public "+nombre+" findById(int id) throws Exception {";
            mr += separacion2 + "URL url = new URL(serviceURL + \"find/\" + id);";
            mr += separacion2 + "HttpURLConnection con = (HttpURLConnection) url.openConnection();";
            mr += separacion2 + "con.setRequestMethod(\"GET\");";
            mr += separacion2 + "try {";
            mr += separacion3 + "// pq por encima de este numero es una peticion incorrecta";
            mr += separacion3 + "if (con.getResponseCode() > 299) {";
            mr += separacion4 + "return null;";
            mr += separacion3 + "} else {";
            mr += separacion4 + "BufferedReader in = new BufferedReader(new InputStreamReader(con.getInputStream()));";
            mr += separacion4 + "String response = in.readLine();";
            mr += separacion4 + ""+nombre+" "+nombreVariable+" = JSONUtils.covertFromJsonToObject(response, "+nombre+".class);";
            mr += separacion4 + "return "+nombreVariable+";";
            mr += separacion3 + "}";
            mr += separacion2 + "} catch (IOException e) {";
            mr += separacion3 + "throw new Exception(e.getMessage());";
            mr += separacion2 + "} finally {";
            mr += separacion3 + "con.disconnect();";
            mr += separacion2 + "}";
            mr += separacion1 + "}";
            mr += separacion1 + "// sending request to retrieve all "+nombreVariable+"s available.";
            mr += separacion1 + "public List<"+nombre+"> findAll() throws Exception {";
            mr += separacion2 + "URL url = new URL(serviceURL + \"findAll\");";
            mr += separacion2 + "HttpURLConnection con = (HttpURLConnection) url.openConnection();";
            mr += separacion2 + "con.setRequestMethod(\"GET\");";
            mr += separacion2 + "String a;";
            mr += separacion2 + "try {";
            mr += separacion3 + "BufferedReader in = new BufferedReader(new InputStreamReader(con.getInputStream()));";
            mr += separacion3 + "TypeReference<List<"+nombre+">> var=null; ";
            mr += separacion3 + "List<"+nombre+"> list_"+nombreVariable+"s = JSONUtils.convertFromJsonToList(";
            mr += separacion5 + "in.readLine()";
            mr += separacion5 + ",";
            mr += separacion5 + "new TypeReference<List<"+nombre+">>() {}";
            mr += separacion3 + ");";
            mr += separacion3 + "return list_"+nombreVariable+"s;";
            mr += separacion2 + "} catch (IOException e) {";
            mr += separacion3 + "throw new Exception(e.getMessage());";
            mr += separacion2 + "} finally {";
            mr += separacion3 + "con.disconnect();";
            mr += separacion2 + "}";
            mr += separacion1 + "}";
            mr += separacion1 + "// send request to add the product details.";
            mr += separacion1 + "public boolean create("+nombre+" "+nombreVariable+") throws Exception {";
            mr += separacion2 + "String inputJson = JSONUtils.covertFromObjectToJson("+nombreVariable+");";
            mr += separacion2 + "URL url = new URL(serviceURL + \"create\");";
            mr += separacion2 + "HttpURLConnection con = (HttpURLConnection) url.openConnection();";
            mr += separacion2 + "con.setRequestMethod(\"POST\");";
            mr += separacion2 + "con.setRequestProperty(\"Content-Type\", \"application/json\");";
            mr += separacion2 + "con.setDoOutput(true);";
            mr += separacion2 + "con.getOutputStream().write(inputJson.getBytes());";
            mr += separacion2 + "try {";
            mr += separacion3 + "// pq por encima de este numero es una peticion incorrecta";
            mr += separacion3 + "if (con.getResponseCode() > 299) {";
            mr += separacion4 + "return false;";
            mr += separacion3 + "}";
            mr += separacion2 + "} catch (IOException e) {";
            mr += separacion3 + "throw new Exception(e.getMessage());";
            mr += separacion2 + "} finally {";
            mr += separacion3 + "con.disconnect();";
            mr += separacion2 + "}";
            mr += separacion2 + "return true;";
            mr += separacion1 + "}";
            mr += separacion1 + "// send request to update a "+nombre+" details.";
            mr += separacion1 + "public boolean update("+nombre+" "+nombreVariable+") throws Exception {";
            mr += separacion2 + "String inputJson = JSONUtils.covertFromObjectToJson("+nombreVariable+");";
            mr += separacion2 + "URL url = new URL(serviceURL + \"update\");";
            mr += separacion2 + "HttpURLConnection con = (HttpURLConnection) url.openConnection();";
            mr += separacion2 + "con.setRequestMethod(\"PUT\");";
            mr += separacion2 + "con.setRequestProperty(\"Content-Type\", \"application/json\");";
            mr += separacion2 + "con.setDoOutput(true);";
            mr += separacion2 + "con.getOutputStream().write(inputJson.getBytes());";
            mr += separacion2 + "try {";
            mr += separacion3 + "// pq por encima de este numero es una peticion incorrecta";
            mr += separacion3 + "if (con.getResponseCode() > 299) {";
            mr += separacion4 + "return false;";
            mr += separacion3 + "} else {";
            mr += separacion4 + "BufferedReader in = new BufferedReader(new InputStreamReader(con.getInputStream()));";
            mr += separacion4 + "String response = in.readLine();";
            mr += separacion4 + ""+nombreVariable+" = JSONUtils.covertFromJsonToObject(response, "+nombre+".class);";
            mr += separacion4 + "return true;";
            mr += separacion3 + "}";
            mr += separacion2 + "} catch (IOException e) {";
            mr += separacion3 + "throw new Exception(e.getMessage());";
            mr += separacion2 + "} finally {";
            mr += separacion3 + "con.disconnect();";
            mr += separacion2 + "}";
            mr += separacion1 + "}";
            mr += separacion1 + "// send request to delete the "+nombreVariable+" by its "+nombreVariable+"name";
            mr += separacion1 + "public boolean delete(Integer id) throws Exception {";
            mr += separacion2 + "URL url = new URL(serviceURL + \"delete/\" + id);";
            mr += separacion2 + "HttpURLConnection con = (HttpURLConnection) url.openConnection();";
            mr += separacion2 + "con.setRequestMethod(\"DELETE\");";
            mr += separacion2 + "try {";
            mr += separacion3 + "// pq por encima de este numero es una peticion incorrecta";
            mr += separacion3 + "if (con.getResponseCode() > 299) {";
            mr += separacion4 + "return false;";
            mr += separacion3 + "} else {";
            mr += separacion4 + "return true;";
            mr += separacion3 + "}";
            mr += separacion2 + "} catch (IOException e) {";
            mr += separacion3 + "throw new Exception(e.getMessage());";
            mr += separacion2 + "} finally {";
            mr += separacion3 + "con.disconnect();";
            mr += separacion2 + "}";
            mr += separacion1 + "}";
            mr += separacion1 + "public "+nombre+" createAndGet("+nombre+" "+nombreVariable+") throws Exception {";
            mr += separacion2 + "String inputJson = JSONUtils.covertFromObjectToJson("+nombreVariable+");";
            mr += separacion2 + "URL url = new URL(serviceURL + \"create\");";
            mr += separacion2 + "HttpURLConnection con = (HttpURLConnection) url.openConnection();";
            mr += separacion2 + "con.setRequestMethod(\"POST\");";
            mr += separacion2 + "con.setRequestProperty(\"Content-Type\", \"application/json\");";
            mr += separacion2 + "con.setDoOutput(true);";
            mr += separacion2 + "con.getOutputStream().write(inputJson.getBytes());";
            mr += separacion2 + "try {";
            mr += separacion3 + "// pq por encima de este numero es una peticion incorrecta";
            mr += separacion3 + "if (con.getResponseCode() > 299) {";
            mr += separacion4 + "return null;";
            mr += separacion3 + "} else {";
            mr += separacion4 + "BufferedReader in = new BufferedReader(new InputStreamReader(con.getInputStream()));";
            mr += separacion4 + "String response = in.readLine();";
            mr += separacion4 + ""+nombre+" new"+nombre+" = JSONUtils.covertFromJsonToObject(response, "+nombre+".class);";
            mr += separacion4 + "return new"+nombre+";";
            mr += separacion3 + "}";
            mr += separacion2 + "} catch (IOException e) {";
            mr += separacion3 + "throw new Exception(e.getMessage());";
            mr += separacion2 + "} finally {";
            mr += separacion3 + "con.disconnect();";
            mr += separacion2 + "}";
            mr += separacion1 + "}";
            mr += separacion + "}";

            return mr;
        }
        }
}
