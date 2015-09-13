using System;
using System.Collections.Generic;

class Class
{
    private List<Teacher> teachers;
    private string textId;

    public string TextId
    {
        get
        {
            return this.textId;
        }
        set
        {
            this.textId = value;
        }
    }

    public List<Teacher> Teachers
    {
        get
        {
            return this.teachers;
        }
        set
        {
            this.teachers = value;
        }
    }

    public Class(List<Teacher> teachers, string textId)
    {
        this.teachers = teachers;
        this.textId = textId;
    }
}
