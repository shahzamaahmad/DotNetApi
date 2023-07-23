        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Threading.Tasks;
        using Book_Api.Data;
        using Book_Api.Models;
        using Microsoft.AspNetCore.Mvc;
        using Microsoft.EntityFrameworkCore;

        // For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

        namespace Book_Api.Controllers
    
        {
            [ApiController]
            [Route("api/[controller]")]
            public class ContactController : Controller
            {
                private readonly ContactApiDbContext dbContext;

                public ContactController(ContactApiDbContext dbContext)
                {
                    this.dbContext = dbContext;
                }

                [HttpGet]
                public async Task<IActionResult> GetContacts()
                {
                     return Ok(await dbContext.Book.ToListAsync());
                }

                [HttpPost]
                public async Task<IActionResult> AddContacts(AddContact addContact)
                {
                    var contact = new Contact()
                    {
                        Id = Guid.NewGuid(),
                        Fullname = addContact.Fullname,
                        Email = addContact.Email,
                        Address = addContact.Address,
                        Phone = addContact.Phone,
                    };
                   await dbContext.Book.AddAsync(contact);
                    await dbContext.SaveChangesAsync();
                   return Ok(contact);
                }
                [HttpPut]
                [Route("{Id:guid}")]
                public async Task<IActionResult> UpdateCon([FromRoute] Guid Id,[FromBody] UpdateContact updateContact)
                {
                    var contact = await dbContext.Book.FindAsync(Id);
                    if(contact != null)
                    {
                        contact.Fullname = updateContact.Fullname;
                        contact.Address = updateContact.Address;
                        contact.Email = updateContact.Email;
                        contact.Phone = updateContact.Phone;
                        await  dbContext.SaveChangesAsync();
                        return Ok(contact);
                    }

                    return NotFound();
            
           
                }
            [HttpGet]
            [Route("{Id:guid}")]
            public async Task<IActionResult> GetContact([FromRoute] Guid Id)
            {
                var con = await dbContext.Book.FindAsync(Id);
                if (con != null)
                {
                    return Ok(con);
                }
                return NotFound();
            }

        [HttpDelete ]
        [Route("{Id:guid}")]
        public async Task<IActionResult> DeleteCon([FromRoute] Guid Id)
        {
            var item = await dbContext.Book.FindAsync(Id);
            if (item != null)
            {
               dbContext.Remove(item);
                await dbContext.SaveChangesAsync();
                return Ok(item);
            }
            return NotFound();

        }






    }
        }

