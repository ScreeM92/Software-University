import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
 
/**
 *
 * @author bas
 */
 
public class Product10 {
 
        private String name;
        private double price;
 
        public Product10(String name, double price) {
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
 
        public static void writeBill() {
                try {
                        BufferedWriter out = new BufferedWriter(new FileWriter(
                                        "Output10.txt"));
                        out.write(String.format("%.2f", calculateTotalBill()));
                        out.close();
                } catch (Exception e) {
                        e.printStackTrace();
                }
        }
 
        public static Product[] extractProducts() {
                FileReader fr;
 
                try {
                        fr = new FileReader("Products.txt");
 
                        BufferedReader br = new BufferedReader(fr);
 
                        int numLines = countLines("Products.txt");
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
 
        public static double calculateTotalBill() {
                FileReader fr;
                double bill = 0;
                try {
                        fr = new FileReader("Order.txt");
                        BufferedReader br = new BufferedReader(fr);
                        int numLines = countLines("Order.txt");
 
                        Product[] products = extractProducts();
 
                        for (int i = 0; i < numLines; i++) {
                                String[] orderInfo = br.readLine().split(" ");
                                for (int j = 0; j < products.length; j++) {
                                        if (orderInfo[1].equals(products[j].getName())) {
                                                bill += products[j].getPrice()
                                                                * Double.parseDouble(orderInfo[0]);
                                        }
                                }
                        }
 
                        fr.close();
                } catch (Exception e) {
 
                        e.printStackTrace();
                }
 
                return bill;
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
                writeBill();
        }
 
}