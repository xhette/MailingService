using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramApiSimulator
{
	public enum TgStatusEnum
	{
		SEE_OTHER = 303,

		BAD_REQUEST = 400,

		UNAUTHORIZED = 401,

		FORBIDDEN = 403,

		NOT_FOUND = 404,

		NOT_ACCEPTABLE = 406,

		FLOOD = 420,

		INTERNAL = 500,

		OK = 200
	}
}
