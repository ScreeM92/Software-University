package Source.game.main;

import java.awt.Graphics;
import java.awt.Rectangle;
import java.awt.image.BufferedImage;

import javax.security.auth.x500.X500Principal;

import Source.game.main.calasses.EntityA;
import Source.game.main.calasses.EntityB;

//set moving player 
public class Player extends GameObject implements EntityA {
	Game game;
	Controller c;
	private double velX = 0;
	private double velY = 0;
	// Coordinates

	private Textures tex;
	Animation anim;

	public Player(double x, double y, Textures tex, Game game, Controller c) {
		super(x, y);

		this.tex = tex;
		this.game = game;
		this.c = c;
		anim = new Animation(6, tex.player[0], tex.player[1], tex.player[2]);

	}

	public void tick() {
		x += velX;
		y += velY;

		if (x <= 0)
			x = 0;

		if (x >= 640)
			x = 660 - 18;

		if (y <= 0) {
			y = 0;
		}
		if (y >= 480 - 32) {
			y = 480 - 32;
		}
		
		for (int i = 0; i <game.eb.size(); i++) {
			EntityB tempEnt = game.eb.get(i);
			
			if (Physics.Collision(this, tempEnt)) {
				
				c.RemoveEntity(tempEnt);
				Game.Healt -= 10;
				game.setEnemy_killed(game.getEnemy_killed() + 1);
				
				
			}
			
		}
		
		anim.runAnimation();

	}

	public Rectangle getBounds() {
		return new Rectangle((int) x, (int) y, 32, 32);
	}

	// setters for coordinates for more smooth move
	public void render(Graphics g) {
		anim.drawAnimation(g, x, y, 0);

	}

	public double getX() {
		return x;
	}

	public double getY() {
		return y;
	}

	public void setX(double x) {
		this.x = x;
	}

	public void setY(double y) {
		this.y = y;
	}

	public void setVelX(double velX) {

		this.velX = velX;
	}

	public void setVelY(double velY) {

		this.velY = velY;
	}

}
