package Source.game.main;

import java.util.LinkedList;
//Try for object are touch
import Source.game.main.calasses.EntityA;
import Source.game.main.calasses.EntityB;

public class Physics {

	public static boolean Collision(EntityA enta, EntityB entb) {

		if (enta.getBounds().intersects(entb.getBounds())) {
			return true;
		}

		return false;
	}

	public static boolean Collision(EntityB entb, EntityA enta) {

		if (entb.getBounds().intersects(enta.getBounds())) {
			return true;
		}

		return false;
	}

}
