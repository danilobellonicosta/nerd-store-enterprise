using Microsoft.AspNetCore.Mvc.Razor;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace NSE.WebApp.MVC.Extensions
{
    public static class RazorHelpers
    {
        public static string MensagemEstoque(this RazorPage page, int quantidade)
        {
            return quantidade > 0 ? $"Apenas {quantidade} em estoque!" : "Produto esgotado!";
        }

        public static string FormatoMoeda(this RazorPage page, decimal valor)
        {
            return valor > 0 ? string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", valor) : "Gratuito";
        }

        public static string HashEmailForGravatar(this RazorPage page, string email)
        {
            var hasher = MD5.Create();
            var data = hasher.ComputeHash(Encoding.Default.GetBytes(email));
            var builder = new StringBuilder();

            foreach (var t in data)
            {
                builder.Append(t.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
