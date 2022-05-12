using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{

    internal class Valida01
    {
        public Valida01()
        {
            this.Nome = "";
            this.Cpf = "";
            this.FecNac = "";
            this.RendaMes = "";
            this.EdoCivil = "";
            this.Dependentes = "";

        }

        public Valida01(string nome, string cpf, string fecnac, string rendames, string edocivil, string dependentes)
        {

            this.Nome = nome;
            this.Cpf = cpf;
            this.FecNac = fecnac;
            this.RendaMes = rendames;
            this.EdoCivil = edocivil;
            this.Dependentes = dependentes;
        }

        private String nome;

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private string cpf;

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }

        }

        private string fecnac;

        public string FecNac
        {
            get { return fecnac; }
            set { fecnac = value; }
        }

        private string rendames;

        public string RendaMes
        {
            get { return rendames; }
            set { rendames = value; }

        }
        private String edocivil;

        public String EdoCivil
        {
            get { return edocivil; }
            set { edocivil = value.ToUpper(); }
        }

        private string dependentes;

        public string Dependentes
        {
            get { return dependentes; }
            set { dependentes = value; }

        }
        public void ValCampos()
        {


            Captura01 captura01 = new Captura01();
            /*
                Verificando el contenido de Valida 01 

            */
            Console.WriteLine("\n\n        IMPRESION DEL REGISTRO  valida01 \n\n");
            Console.WriteLine("      Nome             = " + Nome + "\n " +
            "     Cpf              = " + Cpf + "\n " +
            "     Fecha Nacimiento = " + FecNac + "\n " +
            "     Renda Mesual     = " + RendaMes + "\n " +
            "     Estado Civil     = " + EdoCivil + "\n " +
            "     Dependentes      = " + Dependentes + "\n\n\n");
            Console.ReadLine();


            captura01.LerUser();

            //      valida nome

            if (captura01.Nome.Length < 5)
            {
                captura01.Nome = (" Nome  debe ser > de 5 digitos");
                Nome = "error";
            }
            else
            {
                Nome = captura01.Nome;

            }

            //      Valida CPF

            ValidaCPF(captura01.Cpf);

            if (ValidaCPF(captura01.Cpf) == false)
            {
                captura01.Cpf = (" cpf errado " + captura01.Cpf);
                Cpf = "error";
            }

            else
            {
                Cpf = captura01.Cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");

            }

            //      Valida fecha de nacimiento

            EsFecha(captura01.FecNac);
            if (EsFecha(captura01.FecNac) == false)
            {
                captura01.FecNac = (" fecha de nacimento errado " + captura01.FecNac);
                FecNac = "error";
            }

            else
            {
                FecNac = captura01.FecNac;

            }

            //      Valida Renda Mensual

            if (captura01.RendaMes.All(char.IsDigit))
            {

                int salario = Int32.Parse(captura01.RendaMes);
                if (salario <= 0)
                {
                    captura01.RendaMes = (" Renda Mensual debe ser mayor que 0 " + captura01.RendaMes);
                    RendaMes = "error";
                }
                else
                {
                    RendaMes = captura01.RendaMes;

                }
            }
            else
            {
                captura01.RendaMes = (" Renta Mensual debe ser mayor que 0 " + captura01.RendaMes);
                RendaMes = "error";
            }


            //      Valida Estado Civil

            if (captura01.EdoCivil != "C" &&
                captura01.EdoCivil != "S" &&
                captura01.EdoCivil != "V" &&
                captura01.EdoCivil != "D")

            {
                captura01.EdoCivil = (" Estado Civil solo puede ser C, S, V ou D " + captura01.EdoCivil);
                EdoCivil = "ERROR";
            }
            else

            {
                EdoCivil = captura01.EdoCivil;

            }

            //      Valida Dependientes

            if (captura01.Dependentes.All(char.IsDigit))
            {
                int Dep = Int32.Parse(captura01.Dependentes);
                if (Dep < 1 || Dep > 10)
                {
                    captura01.Dependentes = (" Dependentes debe ser >= 0 y < 11 = " + captura01.Dependentes);
                    Dependentes = "error";
                }
                else
                {
                    Dependentes = captura01.Dependentes;

                }
            }
            else
            {
                captura01.Dependentes = (" Dependentes debe ser >= 0 y < 11 = " + captura01.Dependentes);
                Dependentes = "error";
            }

            Console.WriteLine("\n       ERRORES ENCONTRADOS EN LA VALIDACION\n");

            if (Nome == "error")
            {
                Console.WriteLine("\n      " + captura01.Nome);
                captura01.Nome = "error";

            }
            if (Cpf == "error")
            {
                Console.WriteLine("\n      " + captura01.Cpf);
                captura01.Cpf = "error";

            }
            if (FecNac == "error")
            {
                Console.WriteLine("\n      " + captura01.FecNac);
                captura01.FecNac = "error";

            }
            if (RendaMes == "error")
            {
                Console.WriteLine("\n      " + captura01.RendaMes);
                captura01.RendaMes = "error";

            }
            if (EdoCivil == "ERROR")
            {
                Console.WriteLine("\n      " + captura01.EdoCivil);
                captura01.EdoCivil = "ERROR";

            }
            if (Dependentes == "error")
            {
                Console.WriteLine("\n      " + captura01.Dependentes);
                captura01.Dependentes = "error";

            }

            Console.ReadLine();

        }
        static bool ValidaCPF(string cpf)
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
            {
                return false;
            }
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf += digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);

        }

        public static Boolean EsFecha(String fecha)
        {
            try
            {

                DateTime.Parse(fecha);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
