using BabyShop.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace BabyShop.Service.Controllers
{
    /// <summary>
    /// Controller que contém os métodos para alteração, cadastro e consulta de clientes
    /// </summary>
    public class ClienteController : ApiController
    {
        /// <summary>
        /// Método para obter os dados do cliente por Id
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns>Retorna os dados de um cliente</returns>
        [HttpGet]
        [Route( "servicos/cliente/{id:int}" )]
        public HttpResponseMessage Obter( int id )
        {
            try
            {
                var result = new BabyShop.Models.Cliente( );

                // Instância do repositório
                using ( var _repo = new BabyShop.Models.ClienteRepositorio( ) )
                {
                    // Obtém os dados do cliente
                    result = _repo.Get( id );
                }
                return Request.CreateResponse( HttpStatusCode.OK, result, "application/json" );
            }
            catch ( Exception ex )
            {
                var error = new HttpError( ex.Message );
                return Request.CreateResponse( HttpStatusCode.NotFound, error );
            }
        }

        /// <summary>
        /// Método para obter os dados do cliente por CPF
        /// </summary>
        /// <param name="CPF">CPF do cliente</param>
        /// <returns>Retorna os dados de um cliente</returns>
        [HttpGet]
        [Route( "servicos/cliente/{CPF}" )]
        public HttpResponseMessage ObterPorCPF( string CPF )
        {
            try
            {
                var result = new BabyShop.Models.Cliente( );

                // Instância do repositório
                using ( var _repo = new BabyShop.Models.ClienteRepositorio( ) )
                {
                    // Obtém os dados do cliente
                    result = _repo.Get( CPF );
                }
                return Request.CreateResponse( HttpStatusCode.OK, result, "application/json" );
            }
            catch ( Exception ex )
            {
                var error = new HttpError( ex.Message );
                return Request.CreateResponse( HttpStatusCode.NotFound, error );
            }
        }

        /// <summary>
        /// Método para obter os dados de um cliente com base no seu login e senha
        /// </summary>
        /// <param name="cliente">Objeto contendo os dados de aceso de um cliente</param>
        /// <returns>Retorna os dados de um cliente</returns>
        [HttpPost]
        [Route("servicos/cliente")]
        public HttpResponseMessage Obter([FromBody]Acesso cliente)
        {
            try
            {
                var result = new BabyShop.Models.Cliente();

                // Instância do repositório
                using (var _repo = new BabyShop.Models.ClienteRepositorio())
                {
                    // Obtém os dados do cliente
                    result = _repo.Get(cliente.Email, cliente.Senha);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result, "application/json");
            }
            catch (Exception ex)
            {
                var error = new HttpError(ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Método para listar os clientes cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de clientes</returns>
        [HttpGet]
        [Route("servicos/cliente/listar")]
        public HttpResponseMessage Listar()
        {
            try
            {
                var result = new List<BabyShop.Models.Cliente>();

                // Instância do repositório
                using (var _repo = new BabyShop.Models.ClienteRepositorio())
                {
                    // Obtém os dados do cliente
                    result = _repo.GetAll().ToList();
                }
                return Request.CreateResponse(HttpStatusCode.OK, result, "application/json");
            }
            catch (Exception ex)
            {
                var error = new HttpError(ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Método para inserir um novo cliente
        /// </summary>
        /// <param name="cliente">Objeto contendo os dados do cliente a ser cadastrado</param>
        /// <returns>Retorna os dados do cliente cadastrado</returns>
        [HttpPost]
        [Route( "servicos/cliente/novo" )]
        public HttpResponseMessage Inserir([FromBody]BabyShop.Models.Cliente cliente)
        {
            try
            {
                var result = new BabyShop.Models.Cliente();

                // Instância do repositório
                using (var _repo = new BabyShop.Models.ClienteRepositorio())
                {
                    cliente.DataCadastro = DateTime.Now;

                    // Insere o cliente
                    result = _repo.Add(cliente);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result, "application/json");
            }
            catch (Exception ex)
            {
                var error = new HttpError(ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Método para atualizar os dados de um cliente
        /// </summary>
        /// <param name="cliente">Objeto contendo os dados do cliente a ser atualizado</param>
        /// <returns>Retorna os dados do cliente atualizado</returns>
        [HttpPost]
        [Route( "servicos/cliente/atualizar" )]
        public HttpResponseMessage Update([FromBody]BabyShop.Models.Cliente cliente)
        {
            try
            {
                var result = new BabyShop.Models.Cliente();

                // Instância do repositório
                using (var _repo = new BabyShop.Models.ClienteRepositorio())
                {
                    // Atualiza o cliente
                    result = _repo.Update(cliente);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result, "application/json");
            }
            catch (Exception ex)
            {
                var error = new HttpError(ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }

        /// <summary>
        /// Método para excluir um cliente
        /// </summary>
        /// <param name="idCliente">Id do cliente a ser excluído</param>
        /// <returns>Retorna bool indicando se o cliente foi excluído com sucesso</returns>
        [HttpPost]
        [Route( "servicos/cliente/excluir" )]
        public HttpResponseMessage Delete([FromBody]int idCliente)
        {
            try
            {
                bool result = false;

                // Instância do repositório
                using (var _repo = new BabyShop.Models.ClienteRepositorio())
                {
                    // Exclui o cliente
                    _repo.Delete(idCliente);
                    result = true;
                }
                return Request.CreateResponse(HttpStatusCode.OK, result, "application/json");
            }
            catch (Exception ex)
            {
                var error = new HttpError(ex.Message);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }
        }

    }
}