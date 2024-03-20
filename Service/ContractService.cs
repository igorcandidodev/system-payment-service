using PaymentOnline.Entity;

namespace PaymentOnline.Service;

public class ContractService
{

    private ITaxPaymentService _iTaxPaymentService;

    public ContractService(ITaxPaymentService iTaxPaymentService)
    {
        _iTaxPaymentService = iTaxPaymentService;
    }

    public void ProcessContract(Contract contract, int months)
    {
        var amount = contract.Value / months;
        for (var i = 0; i < months; i++)
        {
            var dueDate = contract.Date.AddMonths(i + 1);
            var amountInitial = amount + _iTaxPaymentService.Interest(amount, i + 1);
            var amountFinal = amountInitial + _iTaxPaymentService.PaymentFee(amountInitial);

            var installment = new Installment(dueDate, amountFinal);
            contract.Installments.Add(installment);
        }
    }
}