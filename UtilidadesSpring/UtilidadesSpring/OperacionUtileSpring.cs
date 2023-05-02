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
    abstract class OperacionUtileSpring : ConsolaBasica
    {
        protected ConfiguracionGeneral cnf;

        public OperacionUtileSpring(ConfiguracionGeneral cnf)
        {
            this.cnf = cnf;
        }
        

        protected string getSeparacionln(int indice, int separacion0)
        {
            string r = "\n";
            for (int i = 0; i < indice + separacion0; i++)
            {
                r += "\t";
            }
            return r;
        }

        protected string getNombreClaseVariableRepository(string nombre)
        {
            return getNombreClaseVariable(getNombreClaseRepository(nombre));
        }
        protected string getNombreClaseVariable(string nombre) {
            return Char.ToLower(nombre[0]) + subs(nombre, 1).ToLower();
        }
        protected string getNombreClaseRepository(string nombre)
        {
            return nombre + "Repository";
        }
        protected string getNombreClaseServices(string nombre)
        {
            return nombre + "Services";
        }
        protected string getNombreClaseVariableServices(string nombre)
        {
            return getNombreClaseVariable(getNombreClaseServices(nombre));
        }

        protected string getTipoDeDatoID_Deafult() {
            return "Integer";
        }
    }
}
