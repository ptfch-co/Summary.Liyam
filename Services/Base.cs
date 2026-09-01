namespace Summary.Liyam.Services
{
    using Microsoft.Extensions.Options;
    using Core.Workflows;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public abstract class BaseService
    {
        private readonly LiyamSettings _options;
        private readonly HttpRequestClient _client;

        protected BaseService(IOptions<LiyamSettings> options,
            HttpRequestClient client)
        {
            _options = options.Value;
            _client = client;
        }

        protected async Task<string> GenerateTokenAsync()
        {
            var apiAddress = _options.ApiAddress;
            var username = _options.Username;
            var password = _options.Password;
            var appKey = _options.AppKey;

            ThrowExceptionIfBaseRequestInfoIsNotValid(apiAddress, username, password, appKey);

            var data = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("appkey", appKey)
            });

            var response = await _client.SendPostRequestAsync<ResponseTokenInfo>(
                $"{apiAddress}/api/authenticate",
                data
            );

            return response.Access_Token;
        }

        private void ThrowExceptionIfBaseRequestInfoIsNotValid(
            string apiAddress,
            string username,
            string password,
            string appKey)
        {
            if (string.IsNullOrWhiteSpace(apiAddress))
                throw new ArgumentNullException(nameof(apiAddress));

            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException(nameof(username));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));

            if (string.IsNullOrWhiteSpace(appKey))
                throw new ArgumentNullException(nameof(appKey));
        }
    }
}