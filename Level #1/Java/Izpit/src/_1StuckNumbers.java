import java.util.*;
public class _1StuckNumbers {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int N = Integer.parseInt(input.next());
		int[] nums = new int[N];
		StringBuilder first = new StringBuilder();
		StringBuilder second = new StringBuilder();
		Set<String> Combination = new TreeSet<>();
		for (int i = 0; i < nums.length; i++) {
			nums[i] = input.nextInt();
		}
		for (int i = 0; i < nums.length; i++) {
			first.append(nums[i]);
			for (int j = 0; j < nums.length; j++) {
				if (nums[j] != nums[i]) {
					first.append(nums[j]);
				}
				else {
					continue;
				}
				
				//second part
				
				for (int j2 = 0; j2 < nums.length; j2++) {
					if (nums[j2] != nums[j] && nums[j2] != nums[i]) {
						second.append(nums[j2]);
					}
					else {
						continue;
					}
					for (int k = 0; k < nums.length; k++) {
						if (nums[k] != nums[j2] && nums[k] != nums[j] && nums[k] != nums[i]) {
							second.append(nums[k]);
						}
						if (first.toString().equals(second.toString())) {
							if (nums[i] != nums[j] && nums[i] != nums[j2] && nums[i] != nums[k]
									&& nums[j] != nums[j2] && nums[j] != nums[k] && nums[j2] != nums[k]) {
								
								StringBuilder numBuilder = new StringBuilder();
								numBuilder.append(nums[i] + "|" + nums[j]);
								numBuilder.append("==");
								numBuilder.append(nums[j2] + "|" + nums[k]);
								Combination.add(numBuilder.toString());
								System.out.println(numBuilder);
							}
							
						}
						
						String numsAsString = "" + nums[j2];
						second.delete(numsAsString.length(), second.length());
					}
					second = new StringBuilder();
				}
				
				
				String secondNumsString = "" + nums[i];
				first.delete(secondNumsString.length(), first.length());
			}
			first = new StringBuilder();
		}
		if (Combination.isEmpty()) {
			System.out.println("No");
		}
	}

}
