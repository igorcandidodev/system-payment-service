namespace PaymentOnline.Service;

public interface ITaxPaymentService
{
    double PaymentFee(double amount);
    double Interest(double amount, int months);
}