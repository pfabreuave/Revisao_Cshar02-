using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Imprimir imprimir = new Imprimir();
            imprimir.ImpCampos();
            Console.WriteLine("\n Programa llego a su fin");
            Console.ReadLine();
        }
    }
}
