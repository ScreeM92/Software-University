using System;
using System.Linq;

namespace JustNotJewelryMain
{
    class TimeText : Text
    {
        public static DateTime playedTime { get; private set; }
        public decimal Seconds { get; private set; }

        public TimeText(Coordinates topLeft)
            : base(topLeft, new char[,] { { '0' } })
        {
            TimeText.playedTime = new DateTime();
            this.Body = this.GetImage();
        }

        public override char[,] GetImage()
        {
            string theTimeToString = TimeText.playedTime.TimeOfDay.ToString();
            char[,] bodyArray = new char[1, theTimeToString.Length];
            for (int i = 0; i < theTimeToString.Length; i++)
            {
                bodyArray[0, i] = theTimeToString[i];
            }
            return bodyArray;
        }

        public void UpdateTimer()
        {
            decimal increasingTime = (decimal)JustNotJewelryMain.gameSpeed / 900;
            if (playedTime.Second == 30)
            {
                this.Seconds += increasingTime;
            }
            this.Seconds += increasingTime;
            if ((int)this.Seconds > 0)
            {
                TimeText.playedTime = TimeText.playedTime.AddSeconds((int)this.Seconds);
                this.Seconds = 0;
            }
        }

        public override void Update()
        {
            this.UpdateTimer();    
        }
    }
}
