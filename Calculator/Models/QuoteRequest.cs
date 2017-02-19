using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calculator.Models
{
    public class QuoteRequest

    {
        [Required (ErrorMessage ="Please enter the mortgage amount")]
        [Display(Name ="Mortgage Amount") ]
        public double borrow { get; set; }

        [Required (ErrorMessage ="Please enter an initial Deposit")]
        [Display(Name ="Initial Deposit")]
        public double initialDeposit { get; set; }

        [Required (ErrorMessage ="Please enter the annual rate of interest")]
        [Display(Name = "Annual Rate of Interest")]
        public double apr { get; set; }

        [Required (ErrorMessage ="Please enter the mortgage term(months)")]
        [Display(Name = "Mortgage Term (months)")]
        public double durationInMonths { get; set; }

        
        public double principal { get; set; }
        public double years { get; set; }
        public double propertyValue { get; set; }
        public double monthlyPayment { get; set; }
        public double monthIOPayment { get; set; }
        public double totalinterestIO { get; set; }
        public double totalInterest { get; set; }
        public double totalPayment { get; set; }
        public double Compare { get; set; }
    }
}
