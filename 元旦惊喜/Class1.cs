﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
namespace 元旦惊喜
{
    public class Class1
    {

        //包含用于将电子邮件发送到简单邮件传输协议 (SMTP) 服务器进行传送的类。

        #region sendTheMail 实现邮件发送的一个过程 何丽杰 2016-02-04
        /// <summary>
        /// 实现邮件发送的一个过程
        /// </summary>
        /// <param name="smtpserver">邮件服务器smtp.163.com表示网易邮箱服务器</param>
        /// <param name="smptport">端口号（通常网易和qq为25）</param>
        /// <param name="userName">发送端账号</param>
        /// <param name="pwd">发送端密码</param>
        /// <param name="strfrom">发送端账号</param>
        /// <param name="strto">注册的邮箱号</param>
        /// <param name="subj">邮箱的主题</param>
        /// <param name="bodys">发送的邮件正文</param>
        /// <returns></returns>
        public bool sendTheMail(string smtpserver, string smptport, string userName, string pwd, string strfrom, string strto, string subj, string bodys)
        {
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式  
            _smtpClient.Host = smtpserver;//指定SMTP服务器  
            _smtpClient.UseDefaultCredentials = true;   //获取或设置 Boolean 值，该值控制 DefaultCredentials 是否随请求一起发送。（放在下面的那一句之前）
            _smtpClient.Credentials = new System.Net.NetworkCredential(userName, pwd);//用户名和密码  
            MailMessage _mailMessage = new MailMessage(strfrom, strto);
            _mailMessage.Subject = subj;//主题  
            _mailMessage.Body = bodys;//内容  
            _mailMessage.BodyEncoding = Encoding.Default;//正文编码  
            _mailMessage.IsBodyHtml = true;//设置为HTML格式  
            _mailMessage.Priority = MailPriority.High;//优先级  
            try
            {
                _smtpClient.Send(_mailMessage);
                return true;
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}                   