﻿#region Statements
using System;
#endregion

namespace Yahtzee.Models
{
    /// <summary>
    /// Definition of a Dice
    /// </summary>
    public class Dice
    {
        #region Initializaion
        public Dice() 
        {
            TopNumber = 0;
            Hold = false;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Number observed on the dice top, when a single dice is rolled
        /// </summary>
        public int TopNumber  
        {
            get;
            set;
        }
        /// <summary>
        /// Dice Hold Property
        /// </summary>
        public bool Hold
        {
            get;
            set;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Rolling a Dice to observe a random no. on the dice top
        /// </summary>
        public void Roll()
        {
            if (!Hold)
            {
                System.Threading.Thread.Sleep(20);
                TopNumber = new Random().Next(1, 6 + 1);
            }
        }
        #endregion
    }
}
