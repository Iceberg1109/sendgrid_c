using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        async private void btn_send_Click(object sender, EventArgs e)
        {
            string subject = "Instagram weekly report";
            string contect = File.ReadAllText("index.html");
            string from = "support@omni.com";
            string apiName = "";
            string apiKey = "";

            await SendGridEmail(subject, contect, from, new string[] { "a@a.com" }, apiName, apiKey);
        }

        public async Task SendGridEmail(string subject, string content, string from, string[] to, string sName, string sKey)
        {
            var apiKey = Environment.GetEnvironmentVariable(sName);
            var client = new SendGridClient(sKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(from, from),
                Subject = subject,
                PlainTextContent = content,
                HtmlContent = content
            };
            foreach (var item in to)
            {
                msg.AddTo(new EmailAddress(item, item));
            }
            var response = await client.SendEmailAsync(msg);
        }
    }
}
