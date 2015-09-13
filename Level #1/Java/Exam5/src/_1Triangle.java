import java.util.Scanner;


public class _1Triangle {
public static double getDistance(int x1, int y1, int x2, int y2){
return Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
}

public static void main(String[] args) {
Scanner scan = new Scanner(System.in);
int x1 = scan.nextInt();
int y1 = scan.nextInt();
int x2 = scan.nextInt();
int y2 = scan.nextInt();
int x3 = scan.nextInt();
int y3 = scan.nextInt();
scan.close();
boolean isTriangle = true;

double distAB = getDistance(x1, y1, x2, y2);
double distAC = getDistance(x1, y1, x3, y3);
double distBC = getDistance(x2, y2, x3, y3);

if( distAB + distAC <= distBC){ isTriangle = false; }
if( distAC + distBC <= distAB){ isTriangle = false; }
if( distBC + distAB <= distAC){ isTriangle = false; }

if(isTriangle){
System.out.println("Yes");
System.out.printf("%.2f", getArea(distAB, distBC, distAC));
}
else{
System.out.println("No");
System.out.printf("%.2f",distAB);
}


}

public static double getArea(double distAB, double distBC, double distAC) {
double p = (distAB + distAC + distBC) / 2;
double area = p*(p - distAB)*(p - distAC)*(p - distBC);
return Math.sqrt(area);
}
}