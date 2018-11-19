using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Unified.Domain.Model;
using Unified.Domain.Interfaces;
using Newtonsoft.Json;
using Unified.Domain.Exceptions;

namespace Unified.Infra.RedbetAdapter
{
    public class RedbetAdapter : IRedbetAdapter
    {
        private readonly IRedbetAdapterSettings _redbetAdapterSettings;

        public RedbetAdapter(IRedbetAdapterSettings redbetAdapterSettings)
        {
            _redbetAdapterSettings = redbetAdapterSettings;
        }

        public void AddCustomer(RedbetCustomer customer)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_redbetAdapterSettings.RedbetUrl);
                var json = JsonConvert.SerializeObject(customer);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync($"api/customers/", stringContent).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new DomainException("Client can not be null.");
                }
            }
        }

        public IEnumerable<RedbetCustomer> GetAll()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_redbetAdapterSettings.RedbetUrl);
                var response = httpClient.GetAsync($"api/customers/").Result;
                var data = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<RedbetCustomer>>(data);
            }
        }

        public RedbetCustomer GetCustomer(Guid customerId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_redbetAdapterSettings.RedbetUrl);
                var response = httpClient.GetAsync($"api/customers/{customerId}").Result;
                var data = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new DomainException(data);
                }

                return JsonConvert.DeserializeObject<RedbetCustomer>(data);
            }
        }

        public void RemoveCustomer(Guid customerId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_redbetAdapterSettings.RedbetUrl);
                var response = httpClient.DeleteAsync($"api/customers/{customerId}").Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new DomainException("Client not found.");
                }
            }
        }

        public void UpdateCustomer(RedbetCustomer customer)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_redbetAdapterSettings.RedbetUrl);
                var json = JsonConvert.SerializeObject(customer);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = httpClient.PutAsync($"api/customers/", stringContent).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new DomainException("Client not found.");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new DomainException("Client can not be null.");
                }
            }
        }
    }
}
