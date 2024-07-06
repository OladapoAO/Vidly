using System;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
	public class Customer
	{
		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		public int Id { get; set; }

		public bool IsSubscribedToNewsLetter { get; set; }

		public MemberShipType MemberShipType { get; set; }

		[Display(Name = "Membership Type")]
		public byte MemberShipTypeId { get; set; }

		[Display(Name = "Date of Birth")]
		public DateTime? BirthDate { get; set; }
	}
}

