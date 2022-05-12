using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    internal class Imprimir
    {
        public void ImpCampos()
        {

            Valida01 valida01 = new Valida01();

            for (int i = 0; i < 10; i++)
            {
                valida01.ValCampos();
                if ((valida01.Nome == "error") ||
                    (valida01.Cpf == "error") ||
                    (valida01.FecNac == "error") ||
                    (valida01.RendaMes == "error") ||
                    (valida01.EdoCivil == "ERROR") ||
                    (valida01.Dependentes == "error"))
                {

                    continue;
                }
                else
                {
                    Console.WriteLine("\n\n        IMPRESION DEL REGISTRO CAPTURADO (imprime valida01)\n\n");
                    Console.WriteLine("      Nome             = " + valida01.Nome + "\n " +
                    "     Cpf              = " + valida01.Cpf + "\n " +
                    "     Fecha Nacimiento = " + valida01.FecNac + "\n " +
                    "     Renda Mesual     = " + valida01.RendaMes + "\n " +
                    "     Estado Civil     = " + valida01.EdoCivil + "\n " +
                    "     Dependentes      = " + valida01.Dependentes + "\n\n\n");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}
