import java.util.ArrayList;


public class List {

	public static void main(String[] args) {
		ArrayList shoppingList = new ArrayList();
		shoppingList.add("Milk");
		shoppingList.add("Honey");
		shoppingList.add("Olives");
		shoppingList.add("Beer");
		shoppingList.remove("Olives");
		System.out.println("We need to buy:");
		for(int i=0; i< shoppingList.size(); i++) {
		System.out.println(shoppingList.get(i));
		}
		System.out.println("Do we have to buy Bread? " +
		shoppingList.contains("Bread"));
		}

}
