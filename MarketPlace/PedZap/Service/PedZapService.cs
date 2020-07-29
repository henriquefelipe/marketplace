using MarketPlace;
using Newtonsoft.Json;
using PedZap.Domain;
using PedZap.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace PedZap.Service
{
    public class PedZapService
    {
        private string _urlBase = Constants.URL_BASE;
        public PedZapService() { }

        public PedZapService(string urlBase)
        {
            _urlBase = urlBase;
        }

        public GenericResult<List<pedido>> Pedidos(string token, string status, int offset)
        {
            var result = new GenericResult<List<pedido>>();

            var url = string.Format("{0}{1}/{2}/{3}", _urlBase, Constants.URL_PEDIDOS, status, offset);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Auth-Token", token);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<List<pedido>>(response.Content);
                result.Success = true;
                result.Json = response.Content;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Result = new List<pedido>();
                result.Success = true;
            }
            else
            {
                if (!string.IsNullOrEmpty(response.Content))
                {
                    if (response.Content.Contains("Nenhum registro foi encontrado."))
                    {
                        result.Result = new List<pedido>();
                        result.Success = true;
                    }
                    else
                    {
                        result.Message = response.Content;
                    }
                }
            }

            return result;
        }

        public GenericResult<pedido> Pedido(string token, int id)
        {
            var result = new GenericResult<pedido>();

            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_PEDIDO, id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Auth-Token", token);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var pedido = JsonConvert.DeserializeObject<pedido>(response.Content);
                var clienteResult = Cliente(token, pedido.cli_id);
                if(!clienteResult.Success)
                {
                    result.Message = "Erro ao buscar cliente: " + clienteResult.Message;
                    return result;
                }

                pedido.cli_datacadastral = clienteResult.Result.cli_datacadastral;
                pedido.cli_nome = clienteResult.Result.cli_nome;
                pedido.cli_telefone = clienteResult.Result.cli_telefone;

                if (pedido.pedidos_itens)
                {
                    var resultItens = Pedidos_Itens(token, id);
                    if (resultItens.Success)
                    {
                        pedido.pedido_Items.AddRange(resultItens.Result);
                    }
                    else
                    {
                        result.Message = "Erro ao buscar itens: " + resultItens.Message;                        
                    }
                }

                result.Result = pedido;
                result.Success = true;
                result.Json = response.Content;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Result = new pedido();
                result.Success = true;
            }
            else
            {
                if (!string.IsNullOrEmpty(response.Content))
                {
                    var erro = JsonConvert.DeserializeObject<erro_result>(response.Content);
                    result.Message = erro.descricao;
                }
                else
                {
                    result.Message = response.StatusDescription;
                }
            }

            return result;
        }

        public GenericResult<List<pedido_item>> Pedidos_Itens(string token, int id)
        {
            var result = new GenericResult<List<pedido_item>>();

            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_PEDIDOS_ITENS, id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Auth-Token", token);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var itens = JsonConvert.DeserializeObject<List<pedido_item>>(response.Content);
                foreach(var item in itens)
                {
                    if(item.perguntas)
                    {
                        var resultPerguntas = Pedidos_Itens_Perguntas(token, item.ite_id);
                        if(resultPerguntas.Success)
                        {
                            item.pedido_Items_Perguntas.AddRange(resultPerguntas.Result);
                        }
                        else
                        {
                            result.Message = "Erro ao buscar perguntas: " + resultPerguntas.Message;
                        }
                    }
                }

                result.Result = itens;
                result.Success = true;
                result.Json = response.Content;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Result = new List<pedido_item>();
                result.Success = true;
            }
            else
            {
                var erro = JsonConvert.DeserializeObject<erro_result>(response.Content);
                result.Message = erro.descricao;
            }

            return result;
        }

        public GenericResult<List<pedido_item_pergunta>> Pedidos_Itens_Perguntas(string token, int itemid)
        {
            var result = new GenericResult<List<pedido_item_pergunta>>();

            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_PEDIDOS_ITENS_PERGUNTAS, itemid);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Auth-Token", token);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var perguntas = JsonConvert.DeserializeObject<List<pedido_item_pergunta>>(response.Content);
                foreach (var pergunta in perguntas)
                {
                    if (pergunta.respostas)
                    {
                        var resultRespostas = Pedidos_Itens_Respostas(token, pergunta.per_id);
                        if (resultRespostas.Success)
                        {
                            pergunta.pedido_Items_Respostas.AddRange(resultRespostas.Result);
                        }
                        else
                        {
                            result.Message = "Erro ao buscar respostas: " + resultRespostas.Message;
                        }
                    }
                }

                result.Result = perguntas;
                result.Success = true;
                result.Json = response.Content;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Result = new List<pedido_item_pergunta>();
                result.Success = true;
            }
            else
            {
                var erro = JsonConvert.DeserializeObject<erro_result>(response.Content);
                result.Message = erro.descricao;
            }

            return result;
        }

        public GenericResult<List<pedido_item_resposta>> Pedidos_Itens_Respostas(string token, int perguntaid)
        {
            var result = new GenericResult<List<pedido_item_resposta>>();

            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_PEDIDOS_ITENS_RESPOSTAS, perguntaid);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Auth-Token", token);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<List<pedido_item_resposta>>(response.Content);
                result.Success = true;
                result.Json = response.Content;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Result = new List<pedido_item_resposta>();
                result.Success = true;
            }
            else
            {
                var erro = JsonConvert.DeserializeObject<erro_result>(response.Content);
                result.Message = erro.descricao;
            }

            return result;
        }

        public GenericSimpleResult Pedido_Status(string token, int pedidoid, string status, int? entregadorid = null)
        {
            var result = new GenericSimpleResult();

            var data = new
            {
                ped_status = status,
                ent_id = entregadorid
            };

            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_PEDIDOS_STATUS, pedidoid);
            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Auth-Token", token);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent || response.StatusCode == 0)
            {
                result.Success = true;
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(response.Content))
                    {
                        var erro = JsonConvert.DeserializeObject<erro_result>(response.Content);
                        result.Message = erro.descricao;
                    }
                    else
                    {
                        result.Message = response.ErrorMessage;
                    }
                }
                catch
                {
                    result.Message = response.Content;
                }
            }

            return result;
        }

        public GenericResult<cliente> Cliente(string token, int id)
        {
            var result = new GenericResult<cliente>();

            var url = string.Format("{0}{1}/{2}", _urlBase, Constants.URL_CLIENTE, id);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Auth-Token", token);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<cliente>(response.Content);                
                result.Success = true;
                result.Json = response.Content;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                result.Result = new cliente();
                result.Success = true;
            }
            else
            {
                var erro = JsonConvert.DeserializeObject<erro_result>(response.Content);
                result.Message = erro.descricao;
            }

            return result;
        }
    }
}
