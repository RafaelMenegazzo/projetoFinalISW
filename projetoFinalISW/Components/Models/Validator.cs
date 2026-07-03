using System.Text.RegularExpressions;
namespace projetoFinalISW.Components.Models
{
    public class Validator
    {

        public static bool ValidarEmail(string email)
        {

            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        
        public static bool ValidarSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha))
            {
                return false;
            }

            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(senha, pattern);
        }

        public static bool ValidarTexto(string texto)
        {
            string pattern = @"^[a-zA-Z\s]+$";

            if (string.IsNullOrEmpty(texto))
            {
                return false;
            }
            return Regex.IsMatch(texto, pattern);
        }

    }
}
