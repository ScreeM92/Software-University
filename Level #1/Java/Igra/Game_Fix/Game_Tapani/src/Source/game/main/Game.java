package Source.game.main;

import java.awt.Canvas;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.event.KeyEvent;
import java.awt.image.BufferStrategy;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.util.LinkedList;

import javax.swing.JFrame;

import Source.game.main.calasses.EntityA;
import Source.game.main.calasses.EntityB;

//public methond for runuble when thread start
public class Game extends Canvas implements Runnable {
	// Size for program
	public static final int WIDTH = 320;
	public static final int HEIGHT = WIDTH / 12 * 9;
	public static final int Scale = 2;
	public static final String Title = "Softuni Wrath";
	// boolean for if game started or not start and thread;
	private boolean runing = false;
	private Thread thread;

	// Buffer window and acess RGB colors
	private BufferedImage image = new BufferedImage(WIDTH, HEIGHT,
			BufferedImage.TYPE_INT_RGB);
	// Buffer strategy
	private BufferedImage spriteSheet = null;
	private BufferedImage background = null;


	// player and other charrecter

	private int enemy_count = 10;
	private int enemy_killed = 0;
	public int score ;
		
	//
	private Player p;
	private Controller c;
	private Textures tex;
	private Menu menu;

	public LinkedList<EntityA> ea;
	public LinkedList<EntityB> eb;

	public static int Healt = 120;

	public static enum State {
		MENU, GAME
	};

	public static State state = State.MENU;

	public void init() {
		BufferedImageLoader loader = new BufferedImageLoader();
		requestFocus();
		try {
			background = loader.loadImage("/BackGround.png");

			spriteSheet = loader.loadImage("/sprite_sheet.png");

		} catch (IOException e) {
			e.printStackTrace();
		}
		// reader for key

		tex = new Textures(this);

		c = new Controller(tex, this);
		p = new Player(320, 600, tex, this, c);
		menu = new Menu();

		c.CreateEnemy(enemy_count);
		ea = c.getEntityA();
		eb = c.getEntityB();
		addKeyListener(new Keyboardinput(this));
		this.addMouseListener(new MouseInput());
	}

	// Synchronized methond for render and uptade game

	private synchronized void start() {
		if (runing)
			return;

		runing = true;
		thread = new Thread(this);
		thread.start();
	}

	private synchronized void stop() {
		if (!runing)
			return;

		runing = false;
		// exception for interrupted
		try {
			thread.join();
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
		
		System.exit(1);
	}

	public void run() {
		// put image in game
		init();

		// check game is run or not
		// Game loop
		// Make nano timer because frames;

		
		long lastime = System.nanoTime();
		final double amountOFTicks = 60.0;
		double ns = 1000000000 / amountOFTicks;
		double delta = 0;// time past
		int updates = 0;
		int frames = 0;
		long timer = System.currentTimeMillis();
		while (runing) {
			// make frames in loop;
			long now = System.nanoTime();
			delta += (now - lastime) / ns;
			lastime = now;
			if (delta >= 1) {
				tick();
				updates++;

				delta--;
			}
			render();
			frames++;
			if (System.currentTimeMillis() - timer > 1000) {
				timer += 1000;
				System.out.println(updates + "Ticks, fps " + frames);
				updates = 0;
				frames = 0;
			
			}

		}
		stop();

	}

	// Ticks per second in game
	@SuppressWarnings("deprecation")
	private void tick() {
		if (state == State.GAME) {

		}
		p.tick();
		c.tick();

		if (enemy_killed >= enemy_count) {
			
			enemy_count += 2;
			enemy_killed = 0;
			c.CreateEnemy(enemy_count);
		


		}
	}

	// Render for frames in game
	private void render() {
		// buffer strategy and access to canvas
		BufferStrategy bs = this.getBufferStrategy();

		if (bs == null) {
			createBufferStrategy(3);// 3 buffers better rendering for window
			return;
		}

		Graphics g = bs.getDrawGraphics();// main graphic for render
		// //////////////////////////////
		g.drawImage(image, 0, 0, getWidth(), getHeight(), this);

		g.drawImage(background, 0, 0, null);
		if (state == State.GAME) {
			
			p.render(g);
			c.render(g);
			g.setColor(Color.gray);
			g.fillRect(5, 5, 120, 50);

			g.setColor(Color.red);
			g.fillRect(5, 5, Healt, 50);

			g.setColor(Color.white);
			g.drawRect(5, 5, 120, 50);
			
			
			
		    g.setColor(Color.ORANGE);
			g.drawString("Score ="+score, 580, 40);
			
			
			if (Healt <= -10) {
				g.setColor(Color.white);
				g.drawString("Game OVER", 300, 300);
				
				
				try {
					thread.sleep(300);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				
				
				
				
			}
			
			
		
			
			
			// show menu
		} else if (state == State.MENU) {
			menu.render(g);
		}

		g.dispose();
		bs.show();
		

	}

	public void keyPressed(KeyEvent e) {
		int key = e.getExtendedKeyCode();

		if (state == State.GAME) {

		}

		if (key == KeyEvent.VK_RIGHT) {
			p.setX(p.getX() + 10);

		} else if (key == KeyEvent.VK_LEFT) {
			p.setX(p.getX() - 10);

		} else if (key == KeyEvent.VK_DOWN) {
			p.setY(p.getY() + 10);

		} else if (key == KeyEvent.VK_UP) {
			p.setY(p.getY() - 10);
		}
		if (key == KeyEvent.VK_SPACE) {

			c.addEntity(new Bullet(p.getX(), p.getY(), tex, this));

		}

	}

	public void keyRelesed(KeyEvent e) {
		int key = e.getExtendedKeyCode();

		if (key == KeyEvent.VK_RIGHT) {
			p.setX(p.getX() + 0);

		} else if (key == KeyEvent.VK_LEFT) {
			p.setX(p.getX() + 0);

		} else if (key == KeyEvent.VK_DOWN) {
			p.setY(p.getY() + 0);
		} else if (key == KeyEvent.VK_UP) {
			p.setY(p.getY() + 0);
		} else if (key == KeyEvent.VK_DOWN) {

		}

	}

	// Main Class for window and game

	public static void main(String[] args) {

		Game game = new Game();

		game.setPreferredSize(new Dimension(WIDTH * Scale, HEIGHT * Scale));
		game.setMaximumSize(new Dimension(WIDTH * Scale, HEIGHT * Scale));
		game.setMaximumSize(new Dimension(WIDTH * Scale, HEIGHT * Scale));
		// Specification for window and Crete a JFrame
		// If game close to kill all process
		// Config JFrame.
		JFrame frame = new JFrame(game.Title);
		frame.add(game);// add Jframe to the game;
		frame.pack();
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setResizable(false);// cant resize window
		frame.setLocationRelativeTo(null);//
		frame.setVisible(true);// Windows is visible

		game.start();

	}

	public BufferedImage getSpriteSheet() {

		return spriteSheet;
	}

	public int getEnemy_count() {
		return enemy_count;
	}

	public void setEnemy_count(int enemy_count) {
		this.enemy_count = enemy_count;
	}

	public int getEnemy_killed() {

		return enemy_killed;
	}

	public void setEnemy_killed(int enemy_killed) {
		this.enemy_killed = enemy_killed;
	}

	

}
