package Source.game.main;

import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

public class MouseInput implements MouseListener {

	public void mouseClicked(MouseEvent arg0) {

	}

	public void mouseEntered(MouseEvent arg0) {

	}

	public void mouseExited(MouseEvent arg0) {

	}

	public void mousePressed(MouseEvent e) {

		int mx = e.getX();
		int my = e.getY();
		// public Rectangle playButton = new Rectangle(Game.WIDTH/2
		// +120,150,100,50);
		// public Rectangle HelpButton = new Rectangle(Game.WIDTH/2
		// +120,230,100,50);
		// public Rectangle quitButton = new Rectangle(Game.WIDTH/2
		// +120,320,100,50);

		// Start button
		if (mx >= Game.WIDTH / 2 + 120 && mx <= Game.WIDTH / 2 + 220) {

			if (my >= 150 && my <= 300) {

				// pressed play boton
				Game.state = Game.State.GAME;

			}

		}
		// quit button
		if (mx >= Game.WIDTH / 2 + 120 && mx <= Game.WIDTH / 2 + 220) {

			if (my >= 330 && my <= 400) {

				// pressed play boton
				Game.state = Game.State.GAME;

				System.exit(1);

			}

		}

	}

	public void mouseReleased(MouseEvent arg0) {

	}

}
