using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Unified.Domain.Exceptions;
using Unified.Domain.Interfaces;
using Unified.Domain.Model;

namespace Unified.Infra.MrgreenAdapter
{
    public class MrgreenAdapter : IMrgreenAdapter
    {
        private readonly IMrgreenAdapterSettings _mrgreenAdapterSettings;

        public MrgreenAdapter(IMrgreenAdapterSettings mrgreenAdapterSettings)
        {
            _mrgreenAdapterSettings = mrgreenAdapterSettings;
        }

        public void AddCustomer(MrgreenCustomer customer)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_mrgreenAdapterSettings.MrgreenUrl);
                var json = JsonConvert.SerializeObject(customer);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync($"api/customers/", stringContent).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new DomainException("Client can not be null.");
                }
            }
        }

        public IEnumerable<MrgreenCustomer> GetAll()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_mrgreenAdapterSettings.MrgreenUrl);
                var response = httpClient.GetAsync($"api/customers/").Result;
                var data = response.Content.ReadAsStringAsync().Result;
                
                return JsonConvert.DeserializeObject<IEnumerable<MrgreenCustomer>>(data);
            }
        }

        public MrgreenCustomer GetCustomer(Guid customerId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_mrgreenAdapterSettings.MrgreenUrl);
                var response = httpClient.GetAsync($"api/customers/{customerId}").Result;
                var data = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new DomainException(data);
                }

                return JsonConvert.DeserializeObject<MrgreenCustomer>(data);                
            }
        }

        public void RemoveCustomer(Guid customerId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_mrgreenAdapterSettings.MrgreenUrl);
                var response = httpClient.DeleteAsync($"api/customers/{customerId}").Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new DomainException("Client not found.");
                }
            }
        }

        public void UpdateCustomer(MrgreenCustomer customer)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_mrgreenAdapterSettings.MrgreenUrl);
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
