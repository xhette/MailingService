using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MailingWeb.Models.Data
{
	public class UsersDbContext : IdentityDbContext<User>
	{
		public UsersDbContext(DbContextOptions<UsersDbContext> options)
		   : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
