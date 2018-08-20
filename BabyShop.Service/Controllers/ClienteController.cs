using BabyShop.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace BabyShop.Service.Controllers
{
    public class ClienteController : ApiController
    {
        [HttpGet]
        [Route( "servicos/cliente/{id:int}" )]
        public HttpResponseMessage Obter( int id )
        {
            try
            {
                var result = new BabyShop.Models.Cliente( );

                using ( var _repo = new BabyShop.Models.ClienteRepositorio( ) )
                {
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

        [HttpGet]
        [Route( "servicos/cliente/{CPF}" )]
        public HttpResponseMessage ObterPorCPF( string CPF )
        {
            try
            {
                var result = new BabyShop.Models.Cliente( );

                using ( var _repo = new BabyShop.Models.ClienteRepositorio( ) )
                {
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

        [HttpPost]
        [Route("servicos/cliente")]
        public HttpResponseMessage Obter([FromBody]Acesso cliente)
        {
            try
            {
                var result = new BabyShop.Models.Cliente();

                using (var _repo = new BabyShop.Models.ClienteRepositorio())
                {
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

        [HttpGet]
        [Route("servicos/cliente/listar")]
        public HttpResponseMessage Listar()
        {
            try
            {
                var result = new List<BabyShop.Models.Cliente>();

                using (var _repo = new BabyShop.Models.ClienteRepositorio())
                {
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


        [HttpPost]
        [Route( "servicos/cliente/novo" )]
        public HttpResponseMessage Inserir([FromBody]BabyShop.Models.Cliente cliente)
        {
            try
            {
                var result = new BabyShop.Models.Cliente();

                using (var _repo = new BabyShop.Models.ClienteRepositorio())
                {
                    cliente.DataCadastro = DateTime.Now;
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

        [HttpPost]
        [Route( "servicos/cliente/atualizar" )]
        public HttpResponseMessage Update([FromBody]BabyShop.Models.Cliente cliente)
        {
            try
            {
                var result = new BabyShop.Models.Cliente();

                using (var _repo = new BabyShop.Models.ClienteRepositorio())
                {
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

        [HttpPost]
        [Route( "servicos/cliente/excluir" )]
        public HttpResponseMessage Delete([FromBody]int idCliente)
        {
            try
            {
                bool result = false;

                using (var _repo = new BabyShop.Models.ClienteRepositorio())
                {
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