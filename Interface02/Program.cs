using Entities;
using Services;
using System;
namespace Interface02 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter contract data:");

            try {
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Date (dd/MM/yyyy): ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                Console.Write("Contract value: ");
                double value = double.Parse(Console.ReadLine());

                Console.Write("\nEnter the number of installments: ");
                int numberOfInstallments = int.Parse(Console.ReadLine());

                Contract contract = new Contract(number, date, value);

                ContractService contractService = new ContractService(new PaypalService());

                contractService.ProcessContract(contract, numberOfInstallments);

                foreach (Installment installment in contract.installments) {
                    Console.WriteLine(installment);
                }
            }
            catch (FormatException e) {
                Console.WriteLine("An error occured.");
                Console.WriteLine(e.Message);
            }
        }
    }
}
