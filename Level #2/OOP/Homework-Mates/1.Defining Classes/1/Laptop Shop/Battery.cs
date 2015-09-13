using System;

public class Battery
{
    private string type;
    private int cells;
    private int mAh;

    public Battery(string type, int cells, int mAh) {
        this.type = type;
        this.cells = cells;
        this.mAh = mAh;
    } 

    public Battery() {
        this.type = null;
        this.cells = 0;
        this.mAh = 0;
        
    }

    public override string ToString()
    {
        return string.Format("Type {0},  Cells: {1}, mAh: {2}", type,cells,mAh);
    }
}