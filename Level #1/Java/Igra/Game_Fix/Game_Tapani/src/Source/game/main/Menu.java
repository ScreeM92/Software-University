package Source.game.main;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Rectangle;

public class Menu {

	public Rectangle playButton = new Rectangle(Game.WIDTH / 2 + 120, 150, 100,
			50);
	public Rectangle HelpButton = new Rectangle(Game.WIDTH / 2 + 120, 230, 100,
			50);
	public Rectangle quitButton = new Rectangle(Game.WIDTH / 2 + 120, 320, 100,
			50);

	public void render(Graphics g) {

		Graphics2D graphics2d = (Graphics2D) g;

		// FOnt
		Font font0 = new Font("arial", Font.BOLD, 50);
		g.setFont(font0);
		g.setColor(Color.WHITE);

		Font fnt1 = new Font("arial", Font.BOLD, 30);
		g.setFont(fnt1);
		g.drawString("Play", playButton.x + 19, playButton.y + 33);
		graphics2d.draw(playButton);

		g.drawString("Quit", quitButton.x + 19, quitButton.y + 33);
		graphics2d.draw(quitButton);
	}

}
