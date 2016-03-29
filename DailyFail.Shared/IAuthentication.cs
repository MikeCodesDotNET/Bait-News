using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace DailyFail.Shared
{
	public interface IAuthentication
	{
		Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider);
		void ClearCookies();
	}
}

