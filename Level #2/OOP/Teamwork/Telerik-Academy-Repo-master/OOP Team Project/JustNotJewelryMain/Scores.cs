using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace JustNotJewelryMain
{
    class Scores : Text
    {
        private BigInteger Score { get; set; }
        public decimal Seconds { get; private set; }

        public Scores(Coordinates topLeft)
            : base(topLeft, new char[,] { { '0' } })
        {
            this.Score = 0;
            this.Body = this.GetImage();
        }

        public override char[,] GetImage()
        {
            string scoreToString = this.Score.ToString();
            char[,] bodyArray = new char[1, scoreToString.Length];
            for (int i = 0; i < scoreToString.Length; i++)
            {
                bodyArray[0, i] = scoreToString[i];
            }
            return bodyArray;
        }

        public void UpdateScore()
        {   
            this.Score += 30;
            if (this.Score%100 == 0)
            {
                
            }
        }

        public override void Update()
        {
            this.UpdateScore();    
        }

        
    }
}
