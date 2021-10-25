using System;

namespace PosExample
{
    public class PosTerminal
    {
        readonly ICcVerifier _ccVerifier;

        public PosTerminal()
        {
            this._ccVerifier = CcVerifier.GetInstance();
        }

        public PosTerminal(ICcVerifier ccVerifier)
        {
            this._ccVerifier = ccVerifier;
        }

        public void VerifySale(double amount)
        {
            if (!_ccVerifier.ApproveCharge(amount))
            {
                throw new InvalidChargeException();
            }
        }
    }

    internal class InvalidChargeException : Exception
    {
        public InvalidChargeException() : 
            base("Charge exceeds single transaction amount or credit limit")
        {
        }
    }
}