using Microsoft.AspNetCore.Mvc;

namespace WhatsAppBusinessCloudAPI.Web.Interfaces
{
    public interface IWhatsAppNotificationController
    {
        /// <summary>
        /// Configures the WhatsApp message webhook. 
        /// </summary>
        /// <param name="hubMode">The mode of the webhook.</param>
        /// <param name="hubChallenge">The challenge sent by WhatsApp.</param>
        /// <param name="hubVerifyToken">The verification token from WhatsApp.</param>
        /// <returns>IActionResult containing the challenge value if successful, otherwise a Forbid result.</returns>
        IActionResult ConfigureWhatsAppMessageWebhook(string hubMode, int hubChallenge, string hubVerifyToken);

        /// <summary>
        /// Receives a WhatsApp text message and sends a confirmation reply.
        /// </summary>
        /// <param name="messageReceived">The dynamic message object received from WhatsApp.</param>
        /// <returns>IActionResult containing a message indicating the type of message received, or BadRequest if message not received.</returns>
        Task<IActionResult> ReceiveWhatsAppTextMessage(dynamic messageReceived);
    }
}