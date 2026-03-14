

var msg = new System.Net.Mail.MailMessage();

msg.From = new System.Net.Mail.MailAddress("test@attlocal.net");
msg.To.Add("nathaniel.a.collier@gmail.com");
msg.Subject = "Hello World";
msg.Body = "Test";

System.Console.WriteLine("Sending Email...");
new System.Net.Mail.SmtpClient("smtp.attlocal.net")
.Send(msg);
System.Console.WriteLine("Mail Sent");