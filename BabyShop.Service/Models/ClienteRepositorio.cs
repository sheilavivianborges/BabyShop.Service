using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BabyShop.Models
{
    /// <summary>
    /// Repositório para acesso ao banco de dados
    /// </summary>
    public class ClienteRepositorio :IDisposable
    {
        // Instância do DbContext
        DatabaseContext _repo = new DatabaseContext();

        /// <summary>
        /// Listar todos os clientes
        /// </summary>
        /// <param name="func">Filtros de pesquisa para a consulta de clientes</param>
        /// <returns>Lista contendo todos os clientes cadastrados</returns>
        public IQueryable<Cliente> GetAll(Expression<Func<Cliente, bool>> func)
        {
            List<Cliente> result = _repo.Clientes.Where(func).ToList();
            return result.AsQueryable();
        }

        /// <summary>
        /// Listar todos os clientes
        /// </summary>
        /// <returns>Lista contendo todos os clientes cadastrados</returns>
        public IQueryable<Cliente> GetAll()
        {
            List<Cliente> result = _repo.Clientes.ToList();
            return result.AsQueryable();
        }

        /// <summary>
        /// Obtém um cliente pelo seu Id
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns>Retorna os dados do cliente encontrado</returns>
        public Cliente Get( int id )
        {
            Cliente result = _repo.Clientes.Find( id );
            return result;
        }

        /// <summary>
        /// Obtém um cliente pelo seu CPF
        /// </summary>
        /// <param name="CPF">CPF do cliente</param>
        /// <returns>Retorna os dados do cliente encontrado</returns>
        public Cliente Get( string CPF )
        {
            Cliente result = _repo.Clientes.Where( a=>a.CPF == CPF ).FirstOrDefault( );
            return result;
        }

        /// <summary>
        /// Obtém um cliente por login e senha
        /// </summary>
        /// <param name="email">Login do cliente</param>
        /// <param name="senha">Senha do cliente</param>
        /// <returns>Retorna os dados do cliente encontrado</returns>
        public Cliente Get(string email, string senha)
        {
            Cliente result = _repo.Clientes.Where(m => m.Email == email && m.Senha == senha).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Atualiza um cliente
        /// </summary>
        /// <param name="cliente">Objeto contendo os dados de um cliente</param>
        /// <returns>Retorna os dados do cliente atualizado</returns>
        public Cliente Update(Cliente cliente)
        {

            Cliente dbCliente = _repo.Clientes.Find(cliente.Id);

            _repo.Entry( dbCliente ).CurrentValues.SetValues( cliente );

            _repo.SaveChanges();
            return dbCliente;
            
        }

        /// <summary>
        /// Insere um cliente
        /// </summary>
        /// <param name="cliente">Objeto contendo os dados de um cliente</param>
        /// <returns>Retorna os dados do cliente adicionado</returns>
        public Cliente Add(Cliente cliente)
        {
            Cliente result = _repo.Clientes.Add(cliente);
            _repo.SaveChanges();
            return result;
        }

        /// <summary>
        /// Exclui um cliente
        /// </summary>
        /// <param name="Idcliente">Id do cliente</param>
        public void Delete(int Idcliente)
        {
            var cliente = _repo.Clientes.Find(Idcliente);

            if (cliente != null)
            {
                cliente.DataExclusao = DateTime.Now;
                _repo.SaveChanges();
            }
        }

        public void Dispose()
        {
            
        }
    }
}