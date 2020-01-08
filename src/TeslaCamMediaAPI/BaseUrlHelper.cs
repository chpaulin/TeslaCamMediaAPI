using Microsoft.AspNetCore.Http;

namespace TeslaCamMediaAPI
{
	public class BaseUrlHelper : IBaseUrlHelper
	{
		private readonly IHttpContextAccessor _accessor;

		public BaseUrlHelper(IHttpContextAccessor accessor)
		{
			_accessor = accessor;
		}

		public string BaseUrl
		{
			get
			{
				var request = _accessor.HttpContext.Request;
				return $"{request.Scheme}://{request.Host}";
			}
		}
	}
}
