using System;

class Display
{
    private float size;
    private int numberOfColors;

    public Display()
    {
    }

    public Display(float size, int numberOfColors)
    {
        this.size = size;
        this.numberOfColors = numberOfColors;
    }

    public float Size
    {
        get
        {
            return this.size;
        }
        set
        {
            if (value > 0)
            {
                this.size = value;   
            }
            throw new OverflowException();
        }
    }

    public int NumberOfColors
    {
        get
        {
            return this.numberOfColors;
        }
        set
        {
            if (value > 0)
            {
                this.numberOfColors = value;    
            }
            throw new OverflowException();
            
        }
    }
}

