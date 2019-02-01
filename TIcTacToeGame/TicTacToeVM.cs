using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//Group 6: Joe Huang, Ny Lee, Sonam Sonam, Chaitany Virothi, Harpreet Kaur
namespace TIcTacToeGame
{
    class TicTacToeVM : INotifyPropertyChanged
    {
        Random r = new Random();
        const int ROW = 3;
        const int COLUMN = 3;
        List<string> PositionSymbols = new List<string>();
        List<int> NumberGenerated = new List<int>();
        private string positionOne;
        public string PositionOne
        {
            get { return positionOne; }
            set { positionOne = value; NotifyChanged(); }
        }
        private string positionTwo ;
        public string PositionTwo
        {
            get { return positionTwo; }
            set { positionTwo = value; NotifyChanged(); }
        }
        private string positionThree;
        public string PositionThree
        {
            get { return positionThree; }
            set { positionThree = value; NotifyChanged(); }
        }
        private string positionFour;
        public string PositionFour
        {
            get { return positionFour; }
            set { positionFour = value; NotifyChanged(); }
        }
        private string positionFive;
        public string PositionFive
        {
            get { return positionFive; }
            set { positionFive = value; NotifyChanged(); }
        }
        private string positionSix;
        public string PositionSix
        {
            get { return positionSix; }
            set { positionSix = value; NotifyChanged(); }
        }
        private string positionSeven;
        public string PositionSeven
        {
            get { return positionSeven; }
            set { positionSeven = value; NotifyChanged(); }
        }
        private string positionEight;
        public string PositionEight
        {
            get { return positionEight; }
            set { positionEight = value; NotifyChanged(); }
        }
        private string positionNine;
        public string PositionNine
        {
            get { return positionNine; }
            set { positionNine = value; NotifyChanged(); }
        }        
        private string test1;
        public string Test1
        {
            get { return test1; }
            set { test1 = value; NotifyChanged(); }
        }
        private int countZero;
        public int CountZero
        {
            get { return countZero; }
            set { countZero = value; NotifyChanged(); }
        }
        private int countOne;
        public int CountOne
        {
            get { return countOne; }
            set { countOne = value; NotifyChanged(); }
        }
        private int victoryCase;
        public int VictoryCase
        {
            get { return victoryCase; }
            set { victoryCase = value; NotifyChanged(); }
        }
        private string result;
        public string Result
        {
            get { return result; }
            set { result = value; NotifyChanged(); }
        }
        private string showResult;
        public string ShowResult
        {
            get { return showResult; }
            set { showResult = value; NotifyChanged(); }
        }
        #region
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        
        //Create a draft panel with 2d array
        public void CreatePanel()
        {
            VictoryCase = 0;
            int[,] GamePanel = new int[ROW, COLUMN];
            PositionSymbols.Clear();
            NumberGenerated.Clear();            
            for (int x = 0; x < ROW; x++)
            {                
                for (int y = 0; y < COLUMN; y++)
                {
                    GamePanel[x, y] = r.Next(0, 2);
                    NumberGenerated.Add(GamePanel[x, y]);
                    if (GamePanel[x, y] == 0)
                        PositionSymbols.Add("O");
                    else
                        PositionSymbols.Add("X");                                       
                }
                //count how many 0 and how many 1 are generated
                CountOne = 0;
                CountZero = 0;
                foreach (var item in NumberGenerated)
                {                    
                    if (item == 0)
                        CountZero++;
                    else
                        CountOne++;
                }
            }
        }
        //validate panel to exclude impossible conditions
        public void ValidatePanel()
        {   
            //no way to let a palyer have more than 5 moves
            while (CountOne > 5 || CountZero > 5)
            {                
                CreatePanel();                
            }
            //determine winning conditions
            if (PositionSymbols[0] == PositionSymbols[1] && PositionSymbols[1] == PositionSymbols[2])
            {
                VictoryCase++;
                Result = $"{PositionSymbols[0]} wins! ";
            }
            if (PositionSymbols[0] == PositionSymbols[3] && PositionSymbols[3] == PositionSymbols[6])
            {
                VictoryCase++;
                Result = $"{PositionSymbols[0]} wins! ";
            }
            if (PositionSymbols[3] == PositionSymbols[4] && PositionSymbols[4] == PositionSymbols[5])
            {
                VictoryCase++;
                Result = $"{PositionSymbols[3]} wins! ";
            }
            if (PositionSymbols[6] == PositionSymbols[7] && PositionSymbols[7] == PositionSymbols[8])
            {
                VictoryCase++;
                Result = $"{PositionSymbols[6]} wins! ";
            }
            if (PositionSymbols[1] == PositionSymbols[4] && PositionSymbols[4] == PositionSymbols[7])
            {
                VictoryCase++;
                Result = $"{PositionSymbols[1]} wins! ";
            }
            if (PositionSymbols[2] == PositionSymbols[4] && PositionSymbols[4] == PositionSymbols[6])
            {
                VictoryCase++;
                Result = $"{PositionSymbols[2]} wins! ";
            }
            if (PositionSymbols[0] == PositionSymbols[4] && PositionSymbols[4] == PositionSymbols[8])
            {
                VictoryCase++;
                Result = $"{PositionSymbols[0]} wins! ";
            }
            if (PositionSymbols[2] == PositionSymbols[5] && PositionSymbols[5] == PositionSymbols[8])
            {
                VictoryCase++;
                Result = $"{PositionSymbols[2]} wins! ";
            }                
        }
        //display and finalize result to show
        public void DisplayPanel()
        {
            //further narrow down to have only one winning condition, if two condtions happen, rerun other functions
            while (VictoryCase > 1)
            {
                CreatePanel();
                ValidatePanel();
            }
            //assign to panel
            PositionOne = PositionSymbols[0];
            PositionTwo = PositionSymbols[1];
            PositionThree = PositionSymbols[2];
            PositionFour = PositionSymbols[3];
            PositionFive = PositionSymbols[4];
            PositionSix = PositionSymbols[5];
            PositionSeven = PositionSymbols[6];
            PositionEight = PositionSymbols[7];
            PositionNine = PositionSymbols[8];
            //display message
            if (victoryCase == 1)
                ShowResult = Result;
            else
                ShowResult = "Tie!";
        }
        public void Reset()
        {
            PositionOne = string.Empty;
            PositionTwo = string.Empty;
            PositionThree = string.Empty;
            PositionFour = string.Empty;
            PositionFive = string.Empty;
            PositionSix = string.Empty;
            PositionSeven = string.Empty;
            PositionEight = string.Empty;
            PositionNine = string.Empty;
            ShowResult = string.Empty;
        }
    }
}
