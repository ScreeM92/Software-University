import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
 
/**
 *
 * @author bas
 */
 //Problem 9. List of Products
public class Product {
 
        private String name;
        private double price;
 
        public Product(String name, double price) {
                setName(name);
                setPrice(price);
        }
 
        public String getName() {
                return name;
        }
 
        public void setName(String name) {
                if (name.equals(" ")) {
                        this.name = "not entered";
                } else {
                        this.name = name;
                }
        }
 
        public double getPrice() {
                return price;
        }
 
        public void setPrice(double price) {
                if (price < 0) {
                        this.price = 0;
                } else {
                        this.price = price;
                }
        }
 
        public static void toFile() {
                try {
                        BufferedWriter out = new BufferedWriter(new FileWriter(
                                        "Output-Problem9.txt"));
                        Product[] products = sortArray();
                        for (int i = 0; i < products.length; i++) {
                                out.write(String.format("%.2f %s", products[i].getPrice(),
                                                products[i].getName()));
                                out.newLine();
                        }
 
                        out.close();
                } catch (Exception e) {
                        e.printStackTrace();
                }
        }
 
        public static Product[] extractProducts() {
                FileReader fr;
 
                try {
                        fr = new FileReader("Input.txt");
 
                        BufferedReader br = new BufferedReader(fr);
 
                        int numLines = countLines("Input.txt");
                        Product[] products = new Product[numLines];
                        String[] info = new String[2];
                        for (int i = 0; i < numLines; i++) {
                                String current = br.readLine();
                                info = current.split(" ");
 
                                products[i] = new Product(" ", 0);
                                products[i].setName(info[0].toString());
                                products[i].setPrice(Double.parseDouble(info[1]));
                        }
                        fr.close();
                        return products;
                } catch (Exception e) {
 
                        e.printStackTrace();
                }
                return null;
        }
 
        public static Product[] sortArray() {
 
                Product[] toSort = extractProducts();
 
                // using bubbleSort algorithm to sort the array
                int n = toSort.length;
                boolean swapped = true;
                while (swapped) {
                        swapped = false;
                        for (int i = 1; i < n; i++) {
                                if (toSort[i].getPrice() < toSort[i - 1].getPrice()) {
                                        swap(toSort, i, i - 1);
                                        swapped = true;
                                }
                        }
                        n = n - 1;
                }
                return toSort;
        }
 
        public static void swap(Product[] x, int pos1, int pos2) {
 
                Product temp = x[pos1];
                x[pos1] = x[pos2];
                x[pos2] = temp;
        }
 
        public static int countLines(String file) throws IOException {
                FileReader fr = new FileReader(file);
                BufferedReader br = new BufferedReader(fr);
 
                String aLine = br.readLine();
                int numberOfLines = 0;
 
                while ((aLine) != null) {
                        numberOfLines++;
                        aLine = br.readLine();
                }
                br.close();
                return numberOfLines;
        }
 
        public static void main(String[] args) {
                toFile();
        }
}