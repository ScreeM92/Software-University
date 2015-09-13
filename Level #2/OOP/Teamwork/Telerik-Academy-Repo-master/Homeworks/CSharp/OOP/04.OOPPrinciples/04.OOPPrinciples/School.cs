using System;
using System.Collections.Generic;
using System.Text;

class School
{
    private List<Class> classes = new List<Class>();
    private List<Student> students = new List<Student>();

    public List<Class> Classes
    {
        get
        {
            return this.classes;
        }
    }

    public List<Student> Students
    {
        get
        {
            return this.students;
        }
    }

    public School() { }
    public School(List<Class> classes)
    {
        this.classes = classes;
    }

    public void AddStudent(string name, int classNumber)
    {
        Student currentStudent = new Student(name, classNumber);
        this.students.Add(currentStudent);
    }

    public void AddClass(Class schoolClass)
    {
        this.classes.Add(schoolClass);
    }
    
}
