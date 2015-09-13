package Source.game.main.calasses;

//Interface
import java.awt.Graphics;
import java.awt.Rectangle;

public interface EntityA {

	public void tick();

	public void render(Graphics g);

	public Rectangle getBounds();

	public double getX();

	public double getY();

}
