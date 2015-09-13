using System;
using System.Collections.Generic;

class Teacher : Human, ICommentable
{
    private List<Discipline> disciplines = new List<Discipline>();
    
    public string Comment { get; set; }

    //public List<Discipline> Disciplines
    //{
    //    get
    //    {
    //        return this.disciplines;
    //    }
    //    set
    //    {
    //        this.disciplines = value;
    //    }

    //}

    public Teacher(string name) : base(name) { }

    public Teacher(string name, List<Discipline> disciplines)
        : base(name) 
    {
        this.disciplines = disciplines;
    }

    public void AddDiscipline(string name, int numberOfLectures, int numberOfExercises)
    {
        Discipline currentDiscipline = new Discipline(name, numberOfLectures, numberOfExercises);
        disciplines.Add(currentDiscipline);
    }
}
