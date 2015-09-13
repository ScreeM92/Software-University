using System;
using System.Text;
class Component
{
    //components (processor, graphics card, motherboard, hdd, ram)

    private string processor;
    private string graphicsCard;
    private string motherBoard;
    private string hdd;
    private string ram;
    private decimal processorPrice;
    private decimal graphicsCardPrice;
    private decimal motherBoardPrice;
    private decimal hddPrice;
    private decimal ramPrice;
    private string details;

    public string Processor
    {
        get { return this.processor; }
        set {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Can not be null");
            }
            this.processor = value;
        }
    }

    public string GraphicsCard
    {
        get { return this.graphicsCard; }
        set {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Can not be null");
            }
            this.graphicsCard = value;
        }
    }

    public string MotherBoard
    {
        get { return this.motherBoard; }
        set {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Can not be null");
            }
            this.motherBoard = value; 
        }
    }

    public string Hdd
    {
        get { return this.hdd; }
        set {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Can not be null");
            }
            this.hdd = value; 
        }
    }

    public string Ram
    {
        get { return this.ram; }
        set {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Can not be null");
            }
            this.ram = value; 
        }
    }

    public decimal ProcessorPrice
    {
        get { return this.processorPrice; }
        set {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Negative");
            }
            this.processorPrice = value;
        }
    }

    public decimal GraphicsCardPrice
    {
        get { return this.graphicsCardPrice; }
        set {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Negative");
            }
            this.graphicsCardPrice = value; 
        }
    }

    public decimal MotherBoardPrice
    {
        get { return this.motherBoardPrice; }
        set {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Negative");
            }
            this.motherBoardPrice = value;
        }
    }

    public decimal HddPrice
    {
        get { return this.hddPrice; }
        set {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Negative");
            }
            this.hddPrice = value; 
        }
    }

    public decimal RamPrice
    {
        get { return this.ramPrice; }
        set {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Negative");
            }
            this.ramPrice = value;
        }
    }

    public string Details
    {
        get { return this.details; }
        set {
            if (value != null && value.Length < 1)
            {
                throw new ArgumentException("Wrong");
            }
            this.details = value; 
        }
    }

    public Component(string processor, string graphicsCard, string motherBoard, string hdd, string ram)
    {
        this.Processor = processor;
        this.GraphicsCard = graphicsCard;
        this.MotherBoard = motherBoard;
        this.Hdd = hdd;
        this.Ram = ram;
    }

    public Component(string processor, string graphicsCard, string motherBoard, string hdd, string ram, decimal processorPrice, decimal graphicsCardPrice, decimal motherBoardPrice, decimal hddPrice, decimal ramPrice, string details = null)
        : this(processor, graphicsCard, motherBoard, hdd, ram)
    {
        this.ProcessorPrice = processorPrice;
        this.GraphicsCardPrice = graphicsCardPrice;
        this.MotherBoardPrice = motherBoardPrice;
        this.HddPrice = hddPrice;
        this.RamPrice = ramPrice;
        this.Details = details;
    }

    public override string ToString()
    {
        string cpuPlaceholder = this.processor.Length > 0 ? string.Format("CPU : {0}", this.processor) : String.Empty;
        string gpuPlaceholder = this.graphicsCard.Length > 0 ? string.Format("GPU : {0}", this.graphicsCard) : String.Empty;
        string motherboardPlaceholder = this.motherBoard.Length > 0 ? string.Format("Motherboard : {0}", this.motherBoard) : String.Empty;
        string hddPlaceholder = this.hdd.Length > 0 ? string.Format("HDD : {0}", this.hdd) : String.Empty;
        string ramPlaceholder = this.ram.Length > 0 ? string.Format("RAM : {0}", this.ram) : String.Empty;
        string cpuPricePh = this.processorPrice == 0 ? cpuPricePh = " \n" : string.Format(" : {0}лв.\n", this.processorPrice);
        string gpuPricePh = this.graphicsCardPrice == 0 ? gpuPricePh = " \n" : string.Format(" : {0}лв.\n", this.graphicsCardPrice);
        string motherboardPricePh = this.motherBoardPrice == 0 ? motherboardPricePh = " \n" : string.Format(" : {0}лв.\n", this.motherBoardPrice);
        string hddPricePh = this.hddPrice == 0 ? hddPricePh = " \n" : string.Format(" : {0}лв.\n", this.hddPrice);
        string ramPricePh = this.ramPrice == 0 ? ramPricePh = " \n" : string.Format(" : {0}лв.\n", this.ramPrice);
        //string detailsPH = this.details.Length > 0 ? string.Format("Details: {0}\n", this.details) : String.Empty;
        return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",
            cpuPlaceholder, cpuPricePh, gpuPlaceholder, gpuPricePh, motherboardPlaceholder, motherboardPricePh,
            hddPlaceholder, hddPricePh, ramPlaceholder, ramPricePh);
    }
}

