using System.Threading;

namespace PosExample
{
    public class CcVerifier : ICcVerifier
    {
        private static CcVerifier _instance;
        private static double AVAILABLE_CREDIT = 2000;
        private static double SINGLE_CHARGE_LIMIT = 250;

        private CcVerifier()
        {
            // only access via getInstance
        }
        
        public static ICcVerifier GetInstance()
        {
            if (null == _instance)
            {
                _instance = new CcVerifier();
            }

            return _instance;
        }

        public bool ApproveCharge(double amount)
        {
            ThisCallIsCostly();
            return SufficientFunds(amount);
        }

        private bool SufficientFunds(double amount)
        {
            return (amount <= AVAILABLE_CREDIT) && (amount <= SINGLE_CHARGE_LIMIT);
        }

        private void ThisCallIsCostly()
        {
            Thread.Sleep(10000);
        }
    }
}