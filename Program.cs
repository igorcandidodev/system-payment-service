// See https://aka.ms/new-console-template for more information

using System.Globalization;
using Microsoft.VisualBasic.CompilerServices;
using PaymentOnline.Entity;
using PaymentOnline.Service;

Console.WriteLine("Enter contract data");
Console.Write("Number: ");
var number = int.Parse(Console.ReadLine());

Console.Write("Date (dd/MM/yyyy): ");
var date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

Console.Write("Contract value: ");
var contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

Console.Write("Enter number of installments: ");
var installments = int.Parse(Console.ReadLine());

var contract = new Contract(number, date, contractValue);

var contractService = new ContractService(new PaypallPaymentService());

contractService.ProcessContract(contract, installments);

Console.WriteLine("Installments:");
foreach (var installment in contract.Installments)
{
    Console.WriteLine(installment);
}