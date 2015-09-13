import static org.junit.Assert.fail;
 
import java.math.BigDecimal;
import java.math.MathContext;
 
import junit.framework.Assert;
 
import org.junit.Ignore;
import org.junit.Test;
 
import com.rushi.EvalMathString;
import com.rushi.EvalMathString.Operation;
 
public class EvalMathStringTest {
	EvalMathString ems = new EvalMathString();
 
	@Test
	public void testDoBasicMath() {
		Assert.assertEquals(new BigDecimal(3), ems.doBasicMath(new BigDecimal(1), new BigDecimal(2), Operation.Add));
	}
 
	@Ignore
	public void testDoMath() {
		fail("Not yet implemented"); // TODO
	}
 
	@Test
	public void testSimpleExpression() {
		Assert.assertEquals("6.0000", ""+ems.simpleExpression("1+2*4-6/2"));
	}
 
	@Test
	public void testPerformStringExpr() {
		Assert.assertEquals("6.9000", ems.performStringExpr("(1+2)/2*5-(1*3/5)"));
	}
 
	@Test
	public void testPerformStringExpr1() {
		Assert.assertEquals("2", ems.performStringExpr("1+1"));
	}
 
	@Test
	public void testPerformStringExpr2() {
		Assert.assertEquals("5.2", ems.performStringExpr("(3.1+2.1)"));
	}
 
	@Test
	public void testPerformStringExpr3() {
		Assert.assertEquals("0.3285", ems.performStringExpr("((1.2+4.5)/(6*3.2+(3.4-2.1*5/2)))"));
	}
 
	@Test
	public void testPerformStringExpr4() {
		Assert.assertEquals("2", ems.performStringExpr("((((((1+1))))))"));
	}
 
	@Test
	public void testPerformStringExpr5() {
		Assert.assertEquals("0.9000", ems.performStringExpr("(8.1)/(9)"));
	}	
 
}