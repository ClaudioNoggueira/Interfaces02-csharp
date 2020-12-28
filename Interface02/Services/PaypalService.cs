namespace Services {
    class PaypalService : IOnlinePaymentService {

        public const double FeePercentage = 0.01;
        public const double MonthlyInterest = 0.02;


        public double Interest(double amount, int months) {
            return amount * MonthlyInterest * months;
        }
        public double PaymentFee(double amount) {
            return amount * FeePercentage;
        }
    }
}
