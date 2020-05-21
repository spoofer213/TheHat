using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHat.Models;

namespace TheHat.Handlers
{
	public class ExceptionFilter: ExceptionFilterAttribute
	{
		public override Task OnExceptionAsync(ExceptionContext context)
		{
			var result = new ErrorResponse() { ErrorMessage = context.Exception.Message };
			context.Result = new JsonResult(result);
			return base.OnExceptionAsync(context);
		}
	}
}
