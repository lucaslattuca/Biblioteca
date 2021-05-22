using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Utiles
{
    static class Utiles
    {
        public static Boolean ValidarCampo(string dato, string tipo)
        {
            switch (tipo)
            {
                case "int":
                    try
                    {
                        Convert.ToInt32(dato);
                        return true;
                    }
                    catch (Exception) { return false; }
                case "double":
                    try
                    {
                        Convert.ToDouble(dato);
                        return true;
                    }
                    catch (Exception) { return false; }
                case "string":
                    if (!string.IsNullOrWhiteSpace(dato))
                    {
                        try
                        {
                            Convert.ToString(dato.Trim());
                            return true;
                        }
                        catch (Exception) { return false; }
                    }
                    else return false;
                default:
                    return false;
            }
        }
    }
}
