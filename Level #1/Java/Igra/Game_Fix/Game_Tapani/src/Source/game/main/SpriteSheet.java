package Source.game.main;

import java.awt.image.BufferedImage;

public class SpriteSheet {
	// Method for load image
	private BufferedImage image;

	public SpriteSheet(BufferedImage image) {

		this.image = image;

	}

	// size of image
	public BufferedImage grabImage(int col, int row, int width, int height) {
		// Pixel set for image and get row and col and size 32 ,32
		BufferedImage img = image.getSubimage((col * 32) - 32, (row * 32) - 32,
				width, height);
		return img;
	}

}
