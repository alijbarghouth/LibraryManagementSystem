using Application.Handler.BookRecommendationHandler;
using Application.Query.BookQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller.BookRecommendationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookRecommendationsController : ControllerBase
    {
        private readonly IGetBookRecommendationsQueryHandler _getBookRecommendationsQueryHandler;

        public BookRecommendationsController
            (IGetBookRecommendationsQueryHandler getBookRecommendationsQueryHandler)
        {
            _getBookRecommendationsQueryHandler = getBookRecommendationsQueryHandler;
        }
        [Authorize]
        [HttpGet("BookRecommendations")]
        public async Task<IActionResult> GetBookRecommendations(GetBookRecommendationsQuery query)
        {
            return Ok(await _getBookRecommendationsQueryHandler.Handel(query));
        }
    }
}
