using System;

namespace PosExample
{
    public class PosTerminal
    {
        readonly CcVerifier _ccVerifier;

        public PosTerminal()
        {
            this._ccVerifier = CcVerifier.GetInstance();
        }
        
        void VerifySale(double amount)
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