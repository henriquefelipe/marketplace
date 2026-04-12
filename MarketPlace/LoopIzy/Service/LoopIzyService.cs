using LoopIzy.Domain;
using LoopIzy.Utils;
using MarketPlace;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace LoopIzy.Service
{
    public class LoopIzyService
    {
        private readonly string _token;
        private string _urlBase = Constants.URL_BASE;

        public LoopIzyService(string token)
        {
            _token = token;
        }

        public LoopIzyService(string token, string urlBase)
        {
            _token = token;
            _urlBase = urlBase;
        }

        private RestRequest CreateRequest(string resource, Method method)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("Authorization", "Bearer " + _token);
            request.AddHeader("Content-Type", "application/json");
            return request;
        }

        private GenericResult<T> Execute<T>(RestRequest request) where T : new()
        {
            var result = new GenericResult<T>();
            try
            {
                var client = new RestClient(_urlBase);
                IRestResponse response = client.Execute(request);
                result.Json = response.Content;

                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                {
                    result.Result = JsonConvert.DeserializeObject<T>(response.Content);
                    result.Success = true;
                }
                else
                {
                    result.Message = string.IsNullOrEmpty(response.Content) ? response.StatusDescription : response.Content;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public GenericResult<OrderResponse> ProcessOrder(OrderRequest data)
        {
            var request = CreateRequest(Constants.URL_PROCESS_ORDER, Method.POST);
            request.AddJsonBody(data);
            return Execute<OrderResponse>(request);
        }

        public GenericResult<CustomerResponse> GetCustomers(string phone = null, string cpf = null, string id = null)
        {
            var request = CreateRequest(Constants.URL_CUSTOMERS, Method.GET);
            if (!string.IsNullOrEmpty(phone)) request.AddQueryParameter("phone", phone);
            if (!string.IsNullOrEmpty(cpf)) request.AddQueryParameter("cpf", cpf);
            if (!string.IsNullOrEmpty(id)) request.AddQueryParameter("id", id);
            return Execute<CustomerResponse>(request);
        }

        public GenericResult<CustomerResponse> CreateCustomer(CustomerRequest data)
        {
            var request = CreateRequest(Constants.URL_CUSTOMERS, Method.POST);
            request.AddJsonBody(data);
            return Execute<CustomerResponse>(request);
        }

        public GenericResult<CustomerResponse> UpdateCustomer(CustomerRequest data)
        {
            var request = CreateRequest(Constants.URL_CUSTOMERS, Method.PATCH);
            request.AddJsonBody(data);
            return Execute<CustomerResponse>(request);
        }

        public GenericResult<RewardResponse> GetRewards(bool active = true)
        {
            var request = CreateRequest(Constants.URL_REWARDS, Method.GET);
            request.AddQueryParameter("active", active.ToString().ToLower());
            return Execute<RewardResponse>(request);
        }

        public GenericResult<RedeemResponse> Redeem(RedeemRequest data)
        {
            var request = CreateRequest(Constants.URL_REDEEM, Method.POST);
            request.AddJsonBody(data);
            return Execute<RedeemResponse>(request);
        }

        public GenericResult<BalanceResponse> GetBalance(string customerId)
        {
            var request = CreateRequest(Constants.URL_BALANCE, Method.GET);
            request.AddQueryParameter("customer_id", customerId);
            return Execute<BalanceResponse>(request);
        }

        public GenericResult<BalanceAdjustmentResponse> AdjustBalance(BalanceAdjustmentRequest data)
        {
            var request = CreateRequest(Constants.URL_BALANCE, Method.POST);
            request.AddJsonBody(data);
            return Execute<BalanceAdjustmentResponse>(request);
        }

        public GenericResult<VoucherResponse> GetVouchers(string customerId = null, string status = null, string code = null)
        {
            var request = CreateRequest(Constants.URL_VOUCHERS, Method.GET);
            if (!string.IsNullOrEmpty(customerId)) request.AddQueryParameter("customer_id", customerId);
            if (!string.IsNullOrEmpty(status)) request.AddQueryParameter("status", status);
            if (!string.IsNullOrEmpty(code)) request.AddQueryParameter("code", code);
            return Execute<VoucherResponse>(request);
        }

        public GenericResult<VoucherActionResponse> VoucherAction(VoucherActionRequest data)
        {
            var request = CreateRequest(Constants.URL_VOUCHERS, Method.POST);
            request.AddJsonBody(data);
            return Execute<VoucherActionResponse>(request);
        }

        public GenericResult<CouponResponse> GetCoupon(string code)
        {
            var request = CreateRequest(Constants.URL_COUPONS, Method.GET);
            request.AddQueryParameter("code", code);
            return Execute<CouponResponse>(request);
        }

        public GenericResult<CouponResponse> CouponAction(CouponActionRequest data)
        {
            var request = CreateRequest(Constants.URL_COUPONS, Method.POST);
            request.AddJsonBody(data);
            return Execute<CouponResponse>(request);
        }

        public GenericResult<CashbackResponse> GetCashback(string customerId = null, string code = null)
        {
            var request = CreateRequest(Constants.URL_CASHBACK, Method.GET);
            if (!string.IsNullOrEmpty(customerId)) request.AddQueryParameter("customer_id", customerId);
            if (!string.IsNullOrEmpty(code)) request.AddQueryParameter("code", code);
            return Execute<CashbackResponse>(request);
        }

        public GenericResult<CashbackResponse> CashbackAction(CashbackActionRequest data)
        {
            var request = CreateRequest(Constants.URL_CASHBACK, Method.POST);
            request.AddJsonBody(data);
            return Execute<CashbackResponse>(request);
        }
    }
}
