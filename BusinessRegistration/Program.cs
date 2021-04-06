using System;
using System.Collections.Generic;

namespace BusinessRegistration
{
    class Program
    {
        static void Main(string[] args)
        {

            //PHASE ONE: THE BUSINESS REGISTRATION
            //Before your customer can start to sell their wares legally,
            //they have to submit their information to the government.
            //They don’t want to be bothered with filling the forms themselves.
            //They request that you create an application that will
            //take their input, format it in the manner needed by the government,
            //and provide the total cost for the start-up fees.
            //CAPTURE INFORMATION:

            //The application must capture the following pieces of information
            //• Company Name
            //• Company Purpose
            //• Owners Name
            //• Preferred Start Up Date
            //• Expected Monthly Sales

            Console.WriteLine("Please Enter your company name:");

            string companyName = Console.ReadLine();

            Console.WriteLine($"Please Enter {companyName}'s purpose:");

            string companyPurpose = Console.ReadLine();

            Console.WriteLine($"Please Enter the name of the person who owns {companyName}:");

            string companyOwner = Console.ReadLine();

            Console.WriteLine($"Please Enter the preferred start date for {companyName}: ");

            DateTime preferredStart;

            while(DateTime.TryParse(Console.ReadLine(), out preferredStart)==false)
            {

                Console.WriteLine($"I'm sorry, that was not a valid date \n Please Enter the preferred start date for {companyName}: ");
            }

            Console.WriteLine($"Please Enter the anticipated monthly sales for {companyName}: ");

            double monthlySales;

            while (double.TryParse(Console.ReadLine(), out monthlySales) == false)
            {
                Console.WriteLine($"I'm sorry, that was not a valid amount \n Please Enter the anticipated monthly sales for {companyName}: ");

            }

            //FEE CALCULATION
            //For every new business registration, the following fees are owed
            //• Registration fee: $125.50
            //• Processing fee: $90
            //• DBA Lookup fee: $110.25

            double registrationFee = 125.50;
            double processingFee = 90;
            double dBALookupFee = 110.25;
            //In addition to the standard fees,
            //there are particular circumstances fees
            //• This particular agency is corrupt
            //and adds a fee called “Servicing” that is equal to 8 % of
            //the expected sales for one year.
            //• Corruption knows no bounds.
            //Every day between the submission date
            //of the form and the preferred start - up date, a
            //0.05 cost is added under a fee titled “Extended Processing.”

            
            double servicingFee = .08 * monthlySales * 12;
            double extendedProcessingFee = 0;
            TimeSpan processingTime;
            int processingMonths=0;
            if (DateTime.Now.CompareTo(preferredStart)<0)
            {
                processingTime= preferredStart - DateTime.Now;
                extendedProcessingFee = processingTime.Days * .05;
                processingMonths = processingTime.Days / 30;

            }

            //PAYMENT OPTIONS
            //Luckily the government offers the option to pay the fees
            //in one lump sum or monthly payments due by the preferred start-up date.
            List<string> paymentOptions = new List<string> {"Lump Sum", "Monthly Payments" };
            int selectedPaymentOption;
            bool validChoice;
            do
            {
                Console.WriteLine("How would you like to pay");
                int listNumbers = 1;
                foreach (string option in paymentOptions)
                {

                    Console.WriteLine($"{listNumbers}: {option}");
                    listNumbers++;
                }
                validChoice = int.TryParse(Console.ReadLine(), out selectedPaymentOption);
                if (validChoice ==false)
                {
                    Console.WriteLine("I'm sorry, that's not a valid choice");
                }
            }
            while (validChoice == false);


            //DISPLAY INFORMATION
            //Once you have gathered and calculated all of the information,
            //display the following information to the user.
            //Fill in the square brackets with the actual data from
            //your application.
            Console.WriteLine($"Business registration for {companyName}--Owner {companyOwner}");
            Console.WriteLine($"Submitted on Today's Date{DateTime.Now.ToShortDateString()}--Business Start Date: {preferredStart.ToShortDateString()}");
            Console.WriteLine("List of Fees:");
            Console.WriteLine($"{registrationFee:c}\n{processingFee:c}\n{dBALookupFee:c}");
            if (servicingFee!=0)
            {
                Console.WriteLine($"{servicingFee:c}");
            }
            if (extendedProcessingFee!=0)
            {
                Console.WriteLine($"{extendedProcessingFee:c}");
            }
            double feeTotal = registrationFee + processingFee + dBALookupFee + servicingFee + extendedProcessingFee;

            Console.WriteLine($"Total Fee Amount: {feeTotal:c}");
            if (DateTime.Now.CompareTo(preferredStart) <0)
            {
                
                Console.WriteLine($"Monthly payment: {feeTotal:c}/{processingMonths}={feeTotal / processingMonths:c}");
            }
        }
        

        public static DateTime StringParse(string word)
        {
            Console.ReadLine();
            return DateTime.Now;
        }
    }
}
