using Microsoft.AspNetCore.Mvc;
namespace LTIA_website.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class ChatController : ControllerBase
        {
            [HttpPost]
            public IActionResult Post([FromBody] ChatRequest request)
            {
                var message = request.Message?.ToLower() ?? "";
                string reply = message switch
                {
                    var m when m.Contains("giờ bay") => "Bạn có thể xem giờ bay tại mục Chuyến bay đi và đến.",
                    var m when m.Contains("hỗ trợ") || m.Contains("liên hệ") => "Bạn có thể liên hệ với chúng tôi tại trang Liên hệ.",
                    _ => "Cảm ơn bạn đã nhắn tin! LTIA sẽ sớm hỗ trợ bạn."
                };
                return Ok(new { reply });
            }
        }


    public class ChatRequest
    {
        public string Message { get; set; } = string.Empty;
    }
}