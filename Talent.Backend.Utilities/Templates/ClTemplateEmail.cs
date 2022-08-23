using System.Text;

namespace Talent.Backend.Common.Templates
{
    public class ClTemplateEmail
    {
        public string GetTemplateConfimationAccoun(string email, string url)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<h1 style='color:black;'>Welcome {email}</h1>");
            sb.AppendLine($"<h2>Confirm you account here <a href='{url}'></a></h2>");

            return sb.ToString();
        }
    }
}
