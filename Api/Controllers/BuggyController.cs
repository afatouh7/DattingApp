using Api.Data;
using Api.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  
    public class BuggyController : BaseApiController
    {
        private readonly DattingContext _context;

        public BuggyController(DattingContext context)
        {
            _context = context;
        }
       // [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _context.Users.Find(-1);
            if (thing == null) return NotFound();
            return Ok(thing);
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetAServerError()
        {
           
           
            var thing = _context.Users.Find(-1);
            var thingToReturn = thing.ToString();
            return thingToReturn;
            

        }
        [HttpGet("bad-request")]
        public ActionResult<string> BadRequest() 
        {
            return BadRequest("This was not agood request");
        }

    }
}
