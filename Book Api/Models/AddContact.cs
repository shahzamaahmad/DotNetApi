using System;
namespace Book_Api.Models
{
	public class AddContact
	{
        public required string Fullname { get; set; }

        public required string Email { get; set; }

        public required long Phone { get; set; }

        public required string Address { get; set; }
    }
}

