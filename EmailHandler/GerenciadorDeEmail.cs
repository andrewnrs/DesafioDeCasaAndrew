using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace DesafioDeCasa.EmailHandler
{
    public class GerenciadorDeEmail
    {
        string remetente = "noreply.adecasa@gmail.com";
        string senha = "desafioback";

        public void EnviarEmails(string emailPagador, string emailRecebedor, double valor, string nomePagador, string nomeRecebedor)
        {
            MailMessage emailParaPagador = new MailMessage();
            emailParaPagador.From = new MailAddress(remetente);
            emailParaPagador.To.Add(new MailAddress(emailPagador));
            emailParaPagador.Subject = "Você fez uma Tranferência!";
            emailParaPagador.Body = "Você fez uma Tranferência no valor de R$ " + valor.ToString() + " para " + nomeRecebedor;
            emailParaPagador.IsBodyHtml = true;
            emailParaPagador.Priority = MailPriority.Normal;

            MailMessage emailParaRecebedor = new MailMessage();
            emailParaRecebedor.From = new MailAddress(remetente);
            emailParaRecebedor.To.Add(new MailAddress(emailRecebedor));
            emailParaRecebedor.Subject = "Você recebeu uma Tranferência!";
            emailParaRecebedor.Body = "Você recebeu uma Tranferência de " + nomePagador + " no valor de R$ " + valor;
            emailParaRecebedor.IsBodyHtml = true;
            emailParaRecebedor.Priority = MailPriority.Normal;


            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(remetente, senha);
                smtp.Timeout = 20000;

                try
                {
                    smtp.Send(emailParaPagador);
                    smtp.Send(emailParaRecebedor);
                }
                catch(SmtpException e)
                {
                    // TODO: Gerenciar excessão
                }

            }
        }
    }
}
