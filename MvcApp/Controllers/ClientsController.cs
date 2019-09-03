using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApp.Controllers
{
    [RoutePrefix("clients")]
    public class ClientsController : ApiController
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();

        [HttpGet,Route("")]
        public List<Client> GetClients()
        {
            return dbContext.Clients.ToList();
        }

        [HttpGet, Route("{id}")]
        public Client GetClient(int id)
        {
            Client client = dbContext.Clients.Find(id);
            return client;
        }

        [HttpPut, Route("{id}")]
        public void UpdateClient(int id, Client client)
        {
            dbContext.Entry(client).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }

        [HttpPost, Route("{clientId}")]
        public void AddClient(int clientId)
        {
            Client client = new Client()
            {
                AccountId = 2,
                ClientId = 2,
                Name = "Alexey"
            };
            dbContext.Clients.Add(client);
            dbContext.SaveChanges();
        }

        [HttpDelete, Route("{id}")]
        public void DeleteClient(int id)
        {
            dbContext.Clients.Remove(GetClient(id));
            dbContext.SaveChanges();
        }
    }
}
