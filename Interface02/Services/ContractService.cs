using Entities;
using System;

namespace Services {
    class ContractService {

        private IOnlinePaymentService onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService) {
            this.onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months) {
            double basicQuota = contract.TotalValue / months;
            for (int i = 1; i <= months; i++) {
                DateTime date = contract.Date.AddMonths(i);
                double updatedQuota = basicQuota + onlinePaymentService.Interest(basicQuota, i);
                double fullQuota = updatedQuota + onlinePaymentService.PaymentFee(updatedQuota);
                contract.AddInstallments(new Installment(date, fullQuota));
            }
        }
    }
}
