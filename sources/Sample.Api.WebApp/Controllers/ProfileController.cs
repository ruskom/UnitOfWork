using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using JetBrains.Annotations;
using UnitOfWork.Data;
using UnitOfWork.Data.Entity;
using UnitOfWork.Domain;
using UnitOfWork.Sample.Data;
using UnitOfWork.Sample.Data.Entity;
using UnitOfWork.Sample.Domain;

namespace UnitOfWork.Sample.Api.WebApp.Controllers
{
	[RoutePrefix("profiles")]
	public class ProfileController : ApiController
	{
		public ProfileController()
		{
			UnitOfWorkFactory = new ProfileUnitOfWorkFactory(new DefaultDbContextFactory<ProfileDbContext>());
		}

		private IUnitOfWorkFactory<IProfileUnitOfWork> UnitOfWorkFactory { get; }

		[Route("")]
		public async Task<IHttpActionResult> GetAllAsync()
		{
			using (var unitOfWork = UnitOfWorkFactory.Create())
			{
				var profiles = await unitOfWork.Profiles.GetAllAsync();
				return Ok(profiles);
			}
		}

		[Route("{id:int}", Name = "ProfileController.GetByIdAsync")]
		public async Task<IHttpActionResult> GetByIdAsync(int id)
		{
			using (var unitOfWork = UnitOfWorkFactory.Create())
			{
				var profile = await unitOfWork.Profiles.GetByIdAsync(id);
				if (profile == null)
				{
					return NotFound();
				}

				return Ok(profile);
			}
		}

		[Route("")]
		public async Task<IHttpActionResult> PostAsync([NotNull] Profile profile)
		{
			if (profile == null)
			{
				throw new ArgumentNullException(nameof(profile));
			}

			using (var unitOfWork = UnitOfWorkFactory.Create())
			{
				profile = unitOfWork.Profiles.Insert(profile);
				await unitOfWork.SaveAsync();
				return CreatedAtRoute("ProfileController.GetByIdAsync", new { profile.Id }, profile);
			}
		}

		[Route("{id:int}")]
		public async Task<IHttpActionResult> PutAsync(int id, [NotNull] Profile profile)
		{
			if (profile == null)
			{
				throw new ArgumentNullException(nameof(profile));
			}

			using (var unitOfWork = UnitOfWorkFactory.Create())
			{
				var currentProfile = await unitOfWork.Profiles.GetByIdAsync(id);
				if (currentProfile == null)
				{
					return NotFound();
				}

				currentProfile.Name = profile.Name;
				unitOfWork.Profiles.Update(currentProfile);
				await unitOfWork.SaveAsync();
				return StatusCode(HttpStatusCode.NoContent);
			}
		}

		[Route("{id:int}")]
		public async Task<IHttpActionResult> DeleteAsync(int id)
		{
			using (var unitOfWork = UnitOfWorkFactory.Create())
			{
				var profile = await unitOfWork.Profiles.DeleteAsync(id);
				if (profile == null)
				{
					return NotFound();
				}

				await unitOfWork.SaveAsync();
				return StatusCode(HttpStatusCode.NoContent);
			}
		}
	}
}