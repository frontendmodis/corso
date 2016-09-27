using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoox.DAL.TeamA.Repo
{
    public class ClientiRepository : IDisposable
    {
        private readonly ClienteDB DB = new ClienteDB();

        public void Dispose()
        {
            DB.Dispose();
        }

        public IEnumerable<ClientiGet> Get()
        {
            var clienti = this.DB.Clienti.OrderBy(c => c.Cognome).ThenBy(c => c.Nome);
            return clienti.Select(c =>
                new ClientiGet {
                    Id = c.Id,
                    Nome = c.Nome,
                    Cognome = c.Cognome,
                    Indirizzo = c.Indirizzo,
                    Email = c.Email,
                    Carrello = c.Carrello.Prodotti.Select(p => p.Id)
                }
            );
        }

        public ClientiGet Get(int id)
        {
           
            var cliente = this.DB.Clienti.Find(id);
            return new ClientiGet {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cognome = cliente.Cognome,
                Email = cliente.Email,
                Indirizzo = cliente.Indirizzo,
                Carrello = cliente.Carrello.Prodotti.Select(p => p.Id)
            };
        }

        // aggiunge un prodotto AL CARRELLO
        public void AddProdotto(int idCliente, int idProdotto)
        {
            var cliente = this.DB.Clienti.Find(idCliente);
            cliente.Carrello.Prodotti.Add(new Prodotto { Id = idProdotto});
            this.DB.SaveChanges();
        }
        public void RemoveProdotto(int idCliente, int idProdotto)
        {
            var cliente = this.DB.Clienti.Find(idCliente);

            var prodotto = cliente.Carrello.Prodotti.First(p => p.Id == idProdotto);
            cliente.Carrello.Prodotti.Remove(prodotto);
            this.DB.SaveChanges();
        }

        public void SvuotaCarrello(int idCliente)
        {
            var cliente = this.DB.Clienti.Find(idCliente);
            cliente.Carrello.Prodotti.Clear();
            this.DB.SaveChanges();
        }

   
        public int Add(string nome,string cognome,string email)
        {

            var cliente = new Cliente {
                Nome = nome,
                Cognome = cognome,
                Email = email
            };

            this.DB.Clienti.Add(cliente);
            this.DB.SaveChanges();
            return cliente.Id;
        }

        public void Delete(int id)
        {
            var cliente = this.DB.Clienti.Find(id);        
            this.DB.Clienti.Remove(cliente);
            this.DB.SaveChanges();
        }

        public void Update(
            int id, 
            string nome = null, 
            string cognome = null,
            string email = null,
            string indirizzo = null
            ){

            var cliente = this.DB.Clienti.Find(id);


            //cliente.Nome = nome != null ? nome : cliente.Nome;
            cliente.Nome = nome ?? cliente.Nome;
            cliente.Cognome = cognome ?? cliente.Cognome;
            cliente.Indirizzo = indirizzo ?? cliente.Indirizzo;

            this.DB.SaveChanges();
        }


    }
}
