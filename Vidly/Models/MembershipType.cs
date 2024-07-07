using System;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
	public class MemberShipType
	{
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignupFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

        //public string Name
        //{
        //    get
        //    {
        //        if (Id == 1)
        //            return "Pay As You Go";
        //        if (Id == 2)
        //            return "Monthly";
        //        if (Id == 3)
        //            return "Quaterly";
        //        if (Id == 4)
        //            return "Yearly";
        //        else
        //            return "Pay as you go";
        //    }
        //}
    }
}

