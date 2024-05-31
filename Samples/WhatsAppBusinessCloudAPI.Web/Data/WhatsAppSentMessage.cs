using System.ComponentModel.DataAnnotations;
using WhatsAppBusinessCloudAPI.Web.Controllers;

namespace WhatsAppBusinessCloudAPI.Web.Data
{
    public class WhatsAppSentMessage
    {
        [Key]
        public int tID { get; set; }
        public SendWhatsAppPayload WhatsAppMessage { get; set; }
        public string WamID { get; set; }
        public string status { get; set; }

    }
}
