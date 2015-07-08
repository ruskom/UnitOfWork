using System;
using System.Web.Http;

namespace UnitOfWork.Api.Web.Controllers
{
	public class ProfilesController : ApiController
	{
		public IHttpActionResult Get()
		{
			return Ok();
		}
	}
}