using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace HeartBeatService
{
        public class SendMailSevice
        {
            public static string SendaMail()
            {
            var ToAddress = ConfigurationManager.AppSettings["EmailTo"].ToString();
              var  CcAddress = "";
            var MailSubject = ConfigurationManager.AppSettings["MailSubject"].ToString();
            var MailBody = "Account has been created Successfully";
            var IsBodyHtml = true;
            var FileAttach = "";




                SmtpClient obj = new SmtpClient();



                MailMessage msg = new MailMessage();
                string Result = "";



                //string stastus = ConfigurationManager.AppSettings["IsLive"];



                if (ConfigurationManager.AppSettings["IsLive"] == "Y")
                {



                }
                else
                {
                    // For Test
                    ToAddress = ConfigurationManager.AppSettings["EmailTo"];
                }




                try
                {
                    //string DisplayName = "PEP List and BlackList";
                    string DisplayName = ConfigurationManager.AppSettings["DisplayName"].ToString();
                    MailAddress FromAddress = new MailAddress(ConfigurationManager.AppSettings["EmailFrom"], DisplayName);
                    msg.From = FromAddress;




                    string[] temp = null;



                    if (string.IsNullOrEmpty(ToAddress))
                    {



                    }
                    else
                    {
                        temp = ToAddress.Split(new Char[] { ',' });
                        foreach (string s in temp)
                        {
                            if (ValidateEmail(s))
                            {
                                msg.To.Add(s);
                            }
                        }
                        // msg.To.Add(ToAddress)
                    }



                    if (string.IsNullOrEmpty(CcAddress))
                    {



                    }
                    else
                    {
                        temp = CcAddress.Trim().Split(new Char[] { ',' });
                        foreach (string s in temp)
                        {
                            if (ValidateEmail(s))
                            {
                                msg.Bcc.Add(s);
                            }
                        }
                        // msg.CC.Add(CcAddress)
                    }
                    msg.Subject = MailSubject;




                    if (string.IsNullOrEmpty(FileAttach))
                    {


                    }
                    else
                    {
                        Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(FileAttach);
                        msg.Attachments.Add(attachment);



                        //msg.Attachments.Add(new Attachment(""));
                    }




                    //string StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    dynamic emailServer = ConfigurationManager.AppSettings["EmailServer"];
                    string path = "\\EmailPage.html";
                    string rootPath = Directory.GetCurrentDirectory();
                    var stringPath = rootPath + path;



                StreamReader str = new StreamReader(stringPath);
                string MailText = str.ReadToEnd();
                str.Close();
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(MailText, null, "text/html");





                var fileName = stringPath;
                if (IsBodyHtml == true)
                {
                    msg.AlternateViews.Add(plainView);
                }



                msg.IsBodyHtml = IsBodyHtml;
                    msg.Body = MailBody;
                    obj.Host = emailServer;



                    obj.Send(msg);



                    Result = "Sent";

                    //Log4Net.Log.Info("Sent");
                }
                catch (Exception ex)
                {
                    //Log4Net.Log.Error("Error: ", ex);
                    Result = ex.Message;
                    // nloger.Log(LogLevel.Info, "SendMail Error: " + ex.Message);
                    //  ex.Log()
                }
                finally
                {
                    msg.Dispose();
                }



                return Result;
            }
        



        // Email Format Validation
        public static bool ValidateEmail(string email)
        {
            bool blnValidated = false;
            if (Regex.IsMatch(email, "^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$"))
            {
                blnValidated = true;
            }
            return blnValidated;
        }
    }
}