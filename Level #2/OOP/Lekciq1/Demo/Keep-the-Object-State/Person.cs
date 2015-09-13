using System;

//public class Person
//{
//    private string name;
//    private int age;
	
//    public Person(string name, int age)
//    {
//        this.Name = name;
//        this.Age = age;
//    }

//    public string Name
//    {
//        get { return this.name; }
//        set
//        {
//            if (String.IsNullOrEmpty(value))
//            {
//                throw new ArgumentException("Name cannot be empty!");
//            }
//            if (value.Length < 2)
//            {
//                throw new ArgumentException("Name too short! It should be at least 2 letters");
//            }
//            if (value.Length >= 50)
//            {
//                throw new ArgumentException("Name too long! It should be less than 50 letters");
//            }
//            foreach (char ch in value)
//            {
//                if (!IsLetterAllowedInNames(ch))
//                {
//                    throw new ArgumentException("Invalid name! Use only letters, space and hyphen");
//                }
//            }

//            this.name = value;
//        }
//    }

//    public int Age
//    {
//        get { return this.age; }
//        set
//        {
//            if (value < 0 || value > 120)
//            {
//                throw new ArgumentException("Invalid age! It should be in the range [0...120].");
//            }
//            this.age = value;
//        }
//    }

//    private bool IsLetterAllowedInNames(char ch)
//    {
//        bool isAllowed =
//            char.IsLetter(ch) || ch == '-' || ch == ' ';
//        return isAllowed;
//    }
//}

class Person
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public string Name
    {
        get { return this.name; }
        set { 
        
            if(String.IsNullOrEmpty(value)){
                throw new ArgumentException("The value is null or empty");
            }
            if(value.Length < 2){
                throw new ArgumentException("The length is smaller than 2");
            }
            if(value.Length >= 50){
                throw new ArgumentException("The length is bigger than 50");
            }
            foreach (char ch in value){
                if(!isRightLetter(ch)){
                    throw new ArgumentException("Wrong letter");
                }
            }
            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set { 
            if(value < 0)
            {
                throw new Exception("Age is not correct");
            }
            if (value > 120)
            {
                throw new Exception("Age is too many");
            }
            this.age = value;
        }
    }

    public bool isRightLetter(char ch)
    {
        bool isRight = ch == ' ' || ch == '-' || char.IsLetter(ch);
        return isRight;
    }
}