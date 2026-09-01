namespace Summary.Liyam.Services
{
    using Core.Workflows;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IPersonService
    {
        Task CreatePersonAsync(
            string title,
            int groupId,
            int regionId,
            string firstName,
            string lastName,
            string nationalCode,
            string economicCode,
            string address,
            string phone,
            string mobile,
            string email,
            string postalCode,
            int cityId,
            int stateId,
            string description
        );

        Task<int> GetDetailGroupIdByTitleAsync(string title);
        Task<int> GetRegionIdByTitleAsync(string title);
        Task<int> GetCityIdByTitleAsync(string title);
        Task<int> GetStateIdByTitleAsync(string title);
    }

    public class PersonService : BaseService, IPersonService
    {
        private readonly LiyamSettings _options;
        private readonly HttpRequestClient _client;

        public PersonService(
            IOptions<LiyamSettings> options,
            HttpRequestClient client) : base(options, client)
        {
            _options = options.Value;
            _client = client;
        }

        public async Task<int> GetDetailGroupIdByTitleAsync(string title)
        {
            var token = await GenerateTokenAsync();

            var url = $"{_options.ApiAddress}/DetailGroup/GetDynamicDomain";

            var response = await _client.SendGetRequestAsync<List<DetailGroupLookupItem>>(
                url,
                new KeyValuePair<string, string>("Authorization", $"Bearer {token}"),
                true
            );

            var group = response
                .FirstOrDefault(x => x.Text.Contains(title, StringComparison.OrdinalIgnoreCase));

            if (group == null)
                throw new WorkflowException(
                    $"در لیست گروه های تفضیلی گروه {title} وجود ندارد",
                    null,
                    "کارشناس پشتیبانی؛ تیکت را به سطح بعدی ارجاع دهید."
                );

            return group.Value;
        }

        public async Task<int> GetRegionIdByTitleAsync(string title)
        {
            var token = await GenerateTokenAsync();

            var url = $"{_options.ApiAddress}/Level5/GetLookupValue";

            var response = await _client.SendGetRequestAsync<List<LookupItem>>(
                url,
                new KeyValuePair<string, string>("Authorization", $"Bearer {token}"),
                true
            );

            var region = response
                .FirstOrDefault(x => x.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

            if (region == null)
                throw new WorkflowException(
                    $"در لیست مسیر/منطقه عنوان {title} وجود ندارد",
                    null,
                    "کارشناس پشتیبانی؛ تیکت را به سطح بعدی ارجاع دهید."
                );

            return region.Id;
        }

        public async Task<int> GetCityIdByTitleAsync(string title)
        {
            var token = await GenerateTokenAsync();

            var url = $"{_options.ApiAddress}/City/GetLookupValue";

            var response = await _client.SendGetRequestAsync<List<LookupItem>>(
                url,
                new KeyValuePair<string, string>("Authorization", $"Bearer {token}"),
                true
            );

            var city = response
                .FirstOrDefault(x => x.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

            if (city == null)
                throw new WorkflowException(
                    $"در لیست شهرها عنوان {title} وجود ندارد",
                    null,
                    "کارشناس پشتیبانی؛ تیکت را به سطح بعدی ارجاع دهید."
                );

            return city.Id;
        }

        public async Task<int> GetStateIdByTitleAsync(string title)
        {
            var token = await GenerateTokenAsync();
            var url = $"{_options.ApiAddress}/State/GetLookupValue";

            var response = await _client.SendGetRequestAsync<List<LookupItem>>(
                url,
                new KeyValuePair<string, string>("Authorization", $"Bearer {token}"),
                true
            );

            var state = response
                .FirstOrDefault(x => x.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

            if (state == null)
                throw new WorkflowException(
                    $"در لیست استان ها عنوان {title} وجود ندارد",
                    null,
                    "کارشناس پشتیبانی؛ تیکت را به سطح بعدی ارجاع دهید."
                );

            return state.Id;
        }

        public async Task CreatePersonAsync(
            string title,
            int groupId,
            int regionId,
            string firstName,
            string lastName,
            string nationalCode,
            string economicCode,
            string address,
            string phone,
            string mobile,
            string email,
            string postalCode,
            int cityId,
            int stateId,
            string description)
        {
            string PersonType = "1";

            var token = await GenerateTokenAsync();

            var form = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
             {
                 new KeyValuePair<string, string>("DetailGroupId", groupId.ToString()),
                 new KeyValuePair<string, string>("Title", title ?? string.Empty),
                 new KeyValuePair<string, string>("Level5_Lookup", regionId.ToString()),
                 new KeyValuePair<string, string>("Person_PersonType", PersonType),
                 new KeyValuePair<string, string>("Person_FirstName", firstName),
                 new KeyValuePair<string, string>("Person_LastName", lastName ?? string.Empty),
                 new KeyValuePair<string, string>("Person_NationalCode", nationalCode ?? string.Empty),
                 new KeyValuePair<string, string>("Person_EconomicCode", economicCode ?? string.Empty),
                 new KeyValuePair<string, string>("Person_Address", address ?? string.Empty),
                 new KeyValuePair<string, string>("Person_Phone", phone ?? string.Empty),
                 new KeyValuePair<string, string>("Person_Mobile", mobile ?? string.Empty),
                 new KeyValuePair<string, string>("Person_Email", email ?? string.Empty),
                 new KeyValuePair<string, string>("Person_PostalCode", postalCode ?? string.Empty),
                 new KeyValuePair<string, string>("City_Lookup", cityId.ToString()),
                 new KeyValuePair<string, string>("State_Lookup", stateId.ToString()),
                 new KeyValuePair<string, string>("Description", description ?? string.Empty)
             });

            await _client.SendPostRequestAsync<object>(
              $"{_options.ApiAddress}/Detail/Create",
              form,
              new KeyValuePair<string, string>("Authorization", $"Bearer {token}"),
              "application/x-www-form-urlencoded",
              true
            );
        }
    }
}