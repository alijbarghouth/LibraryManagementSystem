using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Handler.BookRecommendationHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        // [Authorize]
        [HttpGet("BookRecommendations")]
        public async Task<IActionResult> GetBookRecommendations()
        {
            return Ok(await _getBookRecommendationsQueryHandler.Handel());
        }
    }
}
