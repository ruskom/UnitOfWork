using System;
using System.Collections.Generic;

namespace UnitOfWork.Api.Web.Models
{
	public class ProfilesModel
	{
		public IEnumerable<ProfileModel> Items { get; set; }
	}
}