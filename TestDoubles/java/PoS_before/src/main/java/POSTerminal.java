public class POSTerminal {
    CCVerifier ccVerifier;

    POSTerminal() {
        this.ccVerifier = CCVerifier.getInstance();
    }

    void verifySale(double amount) throws InvalidChargeException {
        if (!ccVerifier.approveCharge(amount)) {
            throw new InvalidChargeException();
        }
    }

    public class InvalidChargeException extends Throwable {
        public InvalidChargeException() {
            super("Charge exceeds single transaction amount or credit limit");
        }
    }
}
