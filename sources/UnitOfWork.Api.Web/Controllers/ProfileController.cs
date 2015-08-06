using System;
using System.Threading.Tasks;
using System.Web.Http;
using JetBrains.Annotations;
using UnitOfWork.Data;
using UnitOfWork.Data.Entity;
using UnitOfWork.Domain;

namespace UnitOfWork.Api.Web.Controllers
{
	[RoutePrefix("profiles")]
	public class ProfileController : ApiController
	{
		private IUnitOfWorkFactory<IProfileUnitOfWork> UnitOfWorkFactory { get; }

		public ProfileController()
		{
		    UnitOfWorkFactory = new ProfileUnitOfWorkFactory(new DefaultDbContextFactory<ProfileDbContext>());
		}

		[Route("")]
		public async Task<IHttpActionResult> GetAllAsync()
		{
			using (var unitOfWork = UnitOfWorkFactory.Create())
			{
				var profiles = await unitOfWork.Profiles.GetAllAsync();
				return Ok(profiles);
			}
		}

		[Route("{id:int}")]
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
		public async Task<IHttpActionResult> PostAsync([NotNull] Profile newProfile)
		{
			if (newProfile == null)
			{
				throw new ArgumentNullException("newProfile");
			}

			using (var unitOfWork = UnitOfWorkFactory.Create())
			{
				var profile = unitOfWork.Profiles.Insert(newProfile);
				await unitOfWork.SaveAsync();
				// Created
				return Ok(profile);
			}
		}

		[Route("{id:int}")]
		public async Task<IHttpActionResult> PutAsync(int id, [NotNull] Profile newProfile)
		{
			if (newProfile == null)
			{
				throw new ArgumentNullException("newProfile");
			}

			using (var unitOfWork = UnitOfWorkFactory.Create())
			{
				var profile = await unitOfWork.Profiles.GetByIdAsync(id);
				if (profile == null)
				{
					return NotFound();
				}

				profile.Name = newProfile.Name;
				profile = unitOfWork.Profiles.Update(profile);
				await unitOfWork.SaveAsync();
				return Ok(profile);
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
				return Ok(profile);
			}
		}
	}
}