using System;
using Book_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Api.Data
{
    public class ContactApiDbContext : DbContext
    {
        public ContactApiDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> Book { get; set; }
    }
}