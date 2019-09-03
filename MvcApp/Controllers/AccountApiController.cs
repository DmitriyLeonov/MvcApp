using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApp.Controllers
{
    [RoutePrefix("accounts")]
    public class AccountApiController : ApiController
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();

        [HttpGet,Route("")]
        public List<AccountApi> GetAccounts()
        {
            return dbContext.Accounts.ToList();
        }

        [HttpGet, Route("{id}")]
        public AccountApi GetAccount(int id)
        {
            AccountApi account = dbContext.Accounts.Find(id);
            return account;
        }

        [HttpPut, Route("{id}")]
        public void UpdateAccount(int id, AccountApi account)
        {
            dbContext.Entry(account).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }

        [HttpPost, Route("{clientId}")]
        public void AddAccount(int clientId)
        {
            AccountApi account = new AccountApi(){
                Balance = 740,
                ClientId = clientId
            };
            dbContext.Accounts.Add(account);
            dbContext.SaveChanges();
        }

        [HttpDelete, Route("{id}")]
        public void DeleteAccount(int id)
        {
            dbContext.Accounts.Remove(GetAccount(id));
            dbContext.SaveChanges();
        }
    }
}
