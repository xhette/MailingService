using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailingWeb.Models.Data
{
	public class User : IdentityUser
	{
		public int WorkerId { get; set; }
	}
}
