using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BabyShop.Models
{
    public class ClienteRepositorio :IDisposable
    {

        DatabaseContext _repo = new DatabaseContext();
        
        public IQueryable<Cliente> GetAll(Expression<Func<Cliente, bool>> func)
        {
            List<Cliente> result = _repo.Clientes.Where(func).ToList();
            return result.AsQueryable();
        }

        public IQueryable<Cliente> GetAll()
        {
            List<Cliente> result = _repo.Clientes.ToList();
            return result.AsQueryable();
        }


        public Cliente Get( int id )
        {
            Cliente result = _repo.Clientes.Find( id );
            return result;
        }

        public Cliente Get( string CPF )
        {
            Cliente result = _repo.Clientes.Where( a=>a.CPF == CPF ).FirstOrDefault( );
            return result;
        }


        public Cliente Get(string email, string senha)
        {
            Cliente result = _repo.Clientes.Where(m => m.Email == email && m.Senha == senha).FirstOrDefault();
            return result;
        }

        public Cliente Update(Cliente cliente)
        {

            Cliente dbCliente = _repo.Clientes.Find(cliente.Id);

            _repo.Entry( dbCliente ).CurrentValues.SetValues( cliente );

            _repo.SaveChanges();
            return dbCliente;
            
        }

        public Cliente Add(Cliente cliente)
        {
            Cliente result = _repo.Clientes.Add(cliente);
            _repo.SaveChanges();
            return result;
        }

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