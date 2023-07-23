using System;
namespace Book_Api.Models
{
	public class Contact
	{
		public Guid Id { get; set; }

		public required string Fullname { get; set; }

        public required string Email { get; set; }

        public long  Phone { get; set; }

        public required string Address { get; set; }

    }
}

