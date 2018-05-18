using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Utils
{
    public static class Utiles
    {

        public static string ConstruyeMensajeRegistro(List<int> IdOperacionesNormalUpd, List<int> IdOperacionesNormalIns,
            List<int> IdOperacionesMora, List<int> IdRedesNormal, List<int> IdRedesMora, int CodUniv, int IdReheWs, long miliSeconds, int IdLog, string Inicial)
        {
            string Mensaje = Inicial + " Cod: " + Convert.ToString(CodUniv) + " :: ";

            if (IdOperacionesNormalUpd != null && IdOperacionesNormalUpd.Count > 0)
            {
                Mensaje += "Operaciones modificadas: " + String.Join(",", IdOperacionesNormalUpd) + " || ";
            }

            if (IdOperacionesNormalIns != null && IdOperacionesNormalIns.Count > 0)
            {
                Mensaje += "Operaciones insertadas: " + String.Join(",", IdOperacionesNormalIns) + " || ";
            }

            if (IdOperacionesMora != null && IdOperacionesMora.Count > 0)
            {
                Mensaje += "Operaciones mora insertadas: " + String.Join(",", IdOperacionesMora) + " || ";
                
            }

            Mensaje += "Rehe : " + Convert.ToString(IdReheWs) + " : ";

            if (IdRedesNormal != null && IdRedesNormal.Count > 0)
            {
                Mensaje += "Rede Insertados: " + String.Join(",", IdRedesNormal) + " || ";
            }

            if (IdRedesMora != null && IdRedesMora.Count > 0)
            {
                Mensaje += "Rede Mora Insertados: " + String.Join(",", IdRedesMora) + " || ";               
            }

            Mensaje += "Log :" + Convert.ToString(IdLog) + " || ";

            Mensaje += " En " + miliSeconds + " ms. ";

            return Mensaje;
        }

        public static int InterpretaSinCerosIzquierda(string CodUniv)
        {
            try
            {
                return Convert.ToInt32(CodUniv.TrimStart(new Char[] {'0'}));
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Obtiene el nombre del método actual
        /// </summary>
        /// <returns>string nombre de método</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

        /// <summary>
        /// Escribe en ErrorLog.txt
        /// </summary>
        /// <param name="ex">Excepción a escribir</param>
        public static void ReportError(Exception ex, bool EsError = false)
        {
            if (EsError == false)
            {
                string dateNow = Convert.ToString(DateTime.Now);
                DateTime datenow = DateTime.Now;
                try
                {
                    StreamWriter sw;


                    string path = AppDomain.CurrentDomain.BaseDirectory + @"\" + "//" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                    if (File.Exists(path) == false)
                    {
                        sw = File.CreateText(path);
                        sw.WriteLine("Log: ");
                        sw.Flush();
                        sw.Close();
                    }


                    //' This text is always added, making the file longer over time 
                    //' if it is not deleted.
                    sw = File.AppendText(path);
                    sw.WriteLine(Convert.ToString("@" + dateNow + " - " + GetCurrentMethod() + " :: " + ex));
                    sw.Flush();
                    sw.Close();


                    //System.IO.File.AppendText(, Convert.ToString("@" + dateNow + " - " + GetCurrentMethod() + " :: " + ex));
                }
                catch (Exception)
                {

                }
            }
            else
            {
                StreamWriter sw;
                DateTime datenow = DateTime.Now;

                string path = AppDomain.CurrentDomain.BaseDirectory + @"\" + "//" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                if (File.Exists(path) == false)
                {
                    sw = File.CreateText(path);
                    sw.WriteLine("Log: ");
                    sw.Flush();
                    sw.Close();
                }


                //' This text is always added, making the file longer over time 
                //' if it is not deleted.
                sw = File.AppendText(path);
                sw.WriteLine("---------------------------------------------------------------");
                sw.WriteLine("Error InterconexionScotia.Negocio.Contexto");
                sw.WriteLine("HelpLink: " + ex.HelpLink.ToString());
                sw.WriteLine("Date: " + DateTime.Now);
                sw.WriteLine("Data: " + ex.Data.ToString());
                sw.WriteLine("HResult: " + ex.HResult.ToString());
                sw.WriteLine("InnerException: " + ex.InnerException.ToString());
                sw.WriteLine("Message: " + ex.Message.ToString());
                sw.WriteLine("Source: " + ex.Source.ToString());
                sw.WriteLine("StackTrace: " + ex.StackTrace.ToString());
                sw.WriteLine("TargetSize: " + ex.TargetSite.ToString());
                sw.Flush();
                sw.Close();


            }

            //File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName,
            //      saveScene.ToString());
        }

        /// <summary>
        /// Completa un string con ceros a la izquierda
        /// </summary>
        /// <param name="Inicial">strInicial</param>
        /// <param name="LongFinal">Longitud final</param>
        /// <returns>string con ceros izquierda</returns>
        public static string CerosIzquierda(string Inicial, int LongFinal)
        {
            string rs = string.Empty;
            int CantidadCeros = LongFinal - Inicial.Length;
            for (int i = 0; i < CantidadCeros; i++)
            {
                rs += "0";
            }
            rs += Inicial;
            return rs;
        }

        /// <summary>
        /// Completa un string con espacios vacios a la derecha
        /// </summary>
        /// <param name="Inicial">String Inicial</param>
        /// <param name="LongFinal">Longitud Final</param>
        /// <returns>string vacio derecha</returns>
        public static string StringVacioDerecha(string Inicial, int LongFinal)
        {
            // clsOperacionBUS ObjOp = new clsOperacionBUS();
            string rs = string.Empty;
            int CantidadVacios = LongFinal - Inicial.Length;
            if (Inicial.Length >= LongFinal)
            {
                rs = Inicial.Substring(0, LongFinal);
                return rs;
            }
            else
            {
                rs = Inicial + ConstruyeStringBlanco(CantidadVacios);
                return rs;
            }

        }

        /// <summary>
        /// Construye un String en Blanco a partir de una Longitud dada
        /// </summary>
        /// <param name="Longitud">Tamaño del string blanco</param>
        /// <returns>String vacío</returns>
        public static string ConstruyeStringBlanco(int Longitud)
        {
            int contador = 1;
            string voidString = string.Empty;
            while (contador <= Longitud)
            {
                voidString += " ";
                contador++;
            }
            return voidString;
        }

    }
}
