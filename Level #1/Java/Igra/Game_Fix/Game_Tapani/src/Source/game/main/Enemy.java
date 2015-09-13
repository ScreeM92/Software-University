package Source.game.main;

import java.awt.Graphics;
import java.awt.Rectangle;
import java.util.Random;

import javax.swing.text.html.parser.Entity;

import Source.game.main.calasses.EntityA;
import Source.game.main.calasses.EntityB;


public class Enemy extends GameObject implements EntityB {

	Random r = new Random();
	private Game game;
	private Controller c;

	private Textures tex;
	// speed enemy
	private int speed = r.nextInt(2) + 1;

	Animation anim;

	public Enemy(double x, double y, Textures tex, Controller c, Game game) {
		super(x, y);

		this.tex = tex;
		this.c = c;
		this.game = game;

		anim = new Animation(7, tex.enemy[0], tex.enemy[1], tex.enemy[2]);
	}

	public void tick() {
		y += speed;
		if (y > (Game.HEIGHT * Game.Scale)) {
			x = r.nextInt(640);
			y = -10;

		}
		for (int i = 0; i < game.ea.size(); i++) {
			
			
			EntityA tempEnt = game.ea.get(i);
			if (Physics.Collision(this, tempEnt)) {
				c.RemoveEntity(tempEnt);
				c.RemoveEntity(this);
				game.setEnemy_killed(game.getEnemy_killed() + 1);
				game.score+=50;
			
				

			}
			anim.runAnimation();
		}
		

		

	}

	public void render(Graphics g) {
		anim.drawAnimation(g, x, y, 0);
	}

	public Rectangle getBounds() {
		return new Rectangle((int) x, (int) y, 32, 32);

	}

	public void setY(double y) {
		this.y = y;
	}

	public double getX() {

		return x;
	}

	public double getY() {
		return y;

	}
}
