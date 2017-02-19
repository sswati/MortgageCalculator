using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calculator.Models;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
       

        public ActionResult Index()
        {

            return View();
         
        }

        [HttpPost]
        public ActionResult Result(QuoteRequest quoteRequest)

        {
            if (ModelState.IsValid)
            {


                quoteRequest.principal = quoteRequest.borrow - quoteRequest.initialDeposit;

                quoteRequest.years = quoteRequest.durationInMonths / 12;

               
                
                //Property Value

                quoteRequest.propertyValue = quoteRequest.initialDeposit + quoteRequest.borrow;


                //r=rate/month
                double r = quoteRequest.apr / 100 / 12;

                double d = Math.Pow((1 + r), quoteRequest.durationInMonths) - 1;

                quoteRequest.monthlyPayment = (r + (r / d)) * quoteRequest.principal;





                //Calculate  monthly payment for interest only mortgage

                double i = quoteRequest.principal * quoteRequest.apr;
                double f = i / 12;
                quoteRequest.monthIOPayment = f / 100;




                //Calculate total Interest for IO mortgage

                quoteRequest.totalinterestIO = quoteRequest.monthIOPayment * quoteRequest.durationInMonths;


                //Calculate total Loan Repayment
                quoteRequest.totalPayment = quoteRequest.monthlyPayment * quoteRequest.durationInMonths;



                //Calculate TotalInterest for Repayment

                quoteRequest.totalInterest = quoteRequest.totalPayment - quoteRequest.principal;




                //Compare  interest only vs repayment

                quoteRequest.Compare = quoteRequest.totalPayment - quoteRequest.totalinterestIO;


                return View("Result", quoteRequest);
            }
            else
            {
                return View("Index");
            }


        }

        












        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}