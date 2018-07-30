using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace CakeWalk.Helper
{
   public class SendEmailHelper
    {
        public SendEmailHelper()
        {
            this.EnableSsl = true;
            this.Port = 587;
            this.DeliveryMethod = SmtpDeliveryMethod.Network;
            this.CC = string.Empty;
            this.BCC = string.Empty;
            this.TO = string.Empty;
            this.EnableSendMail = true;
            this.EnableEmailTemplate = true;
            this.Attachments = new List<System.Net.Mail.Attachment>();
        }

        public string TO { get; set; }

        public string CC { get; set; }

        public string BCC { get; set; }

        public string FromEmail { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string HostName { get; set; }

        public string UserName { get; set; }
        public string UserNameTwo { get; set; }

        public string Password { get; set; }

        public bool EnableSsl { get; set; }

        public bool EnableSendMail { get; set; }

        public bool EnableEmailTemplate { get; set; }

        public SmtpDeliveryMethod DeliveryMethod { get; set; }
        public List<System.Net.Mail.Attachment> Attachments { get; set; }
        public int Port { get; set; }

        public string FromEmailForError { get; set; }
        public string HostNameForError { get; set; }

        public string UserNameForError { get; set; }
        public string PasswordForError { get; set; }
        public int PortForError { get; set; }

        public bool SendEmail()
        {
            try
            {
                MailMessage mailMesg = new MailMessage();

                mailMesg.Body = this.Body;
                mailMesg.Subject = this.Subject;
                mailMesg.IsBodyHtml = true;
                string[] to = this.TO.Split(';');
                string[] cc = this.CC.Split(';');
                string[] bcc = this.BCC.Split(';');
                if (!String.IsNullOrEmpty(TO))
                {
                    foreach (string address in to)
                    {
                        if (!string.IsNullOrEmpty(address))
                            mailMesg.To.Add(new MailAddress(address));
                    }
                }
                if (!String.IsNullOrEmpty(CC))
                {
                    foreach (string address in cc)
                    {
                        if (!string.IsNullOrEmpty(address))
                            mailMesg.CC.Add(new MailAddress(address));
                    }
                }

                if (!String.IsNullOrEmpty(BCC))
                {
                    foreach (string address in bcc)
                    {
                        if (!string.IsNullOrEmpty(address))
                            mailMesg.Bcc.Add(new MailAddress(address));
                    }
                }

                if (Attachments.Count > 0)
                {
                    foreach (Attachment att in this.Attachments)
                        mailMesg.Attachments.Add(att);
                }
                SmtpClient objSMTP = new SmtpClient();

                mailMesg.From = new MailAddress(this.FromEmail);

                if (!string.IsNullOrEmpty(this.UserName))
                {
                    System.Net.NetworkCredential creditial = new System.Net.NetworkCredential(this.UserName, this.Password);
                    objSMTP.Credentials = creditial;
                }
                objSMTP.Host = this.HostName;
                objSMTP.EnableSsl = this.EnableSsl;
                objSMTP.Port = Port;
                objSMTP.DeliveryMethod = DeliveryMethod;
                objSMTP.Send(mailMesg);
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
