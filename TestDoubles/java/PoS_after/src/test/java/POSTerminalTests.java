import org.junit.Assert;
import org.junit.Ignore;
import org.junit.Test;

import static org.junit.Assert.fail;

public class POSTerminalTests {

    @Test(expected = Test.None.class /* no exception expected */ )
    public void VerifySale_AmountUnderSingleChargeLimit_IsApproved() {
        // Using the real instance is costly in terms of time

        POSTerminal sut = new POSTerminal();

        try {
            sut.verifySale(10);
        } catch (POSTerminal.InvalidChargeException e) {
            fail("Amount was under Single Charge Amount - exception not expected!");
        }
    }

    @Test(expected = Test.None.class /* no exception expected */ )
    @Ignore
    public void VerifySale_ViaMock_AmountUnderSingleChargeLimit_IsApproved() {
        ICCVerifier mockCCVerifier = new MockCCVerifier();

        POSTerminal sut = new POSTerminal(mockCCVerifier);

        try {
            sut.verifySale(10);
        } catch (POSTerminal.InvalidChargeException e) {
            fail("Amount was under Single Charge Amount - exception not expected!");
        }
    }

    class MockCCVerifier implements ICCVerifier {

        @Override
        public boolean approveCharge(double amount) {
            return true;
        }
    }


}
