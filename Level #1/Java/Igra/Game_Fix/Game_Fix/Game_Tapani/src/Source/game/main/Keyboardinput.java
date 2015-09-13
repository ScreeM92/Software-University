package Source.game.main;

import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;

public class Keyboardinput extends KeyAdapter {

	Game game;

	public Keyboardinput(Game game) {

		this.game = game;
	}

	public void keyPressed(KeyEvent e) {
		game.keyPressed(e);

	}

	public void keyRelesed(KeyEvent e) {
		game.keyRelesed(e);
	}

}
