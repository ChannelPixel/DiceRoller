using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace danielCherrin_DiceRoller
{
	public partial class MainPage : ContentPage
	{
        bool IsAllMaximums = false;
        bool IsAllMinimums = false;

        List<Tuple<int,int>> sumDice = new List<Tuple<int,int>>();

		public MainPage()
		{
			InitializeComponent();
            MainPageStartUp();
            SetFromBoolStates();
        }

        void MainPageStartUp()
        {
            lbl_Sum.Text = "0";
            lbl_Total.Text = "0";
        }

        void RollDice(int die)
        {
            Random randRoller = new Random();
            Tuple<int, int> rollTuple = Tuple.Create(die, randRoller.Next(1, die+1));
            sumDice.Add(rollTuple);
        }

        void SetSumText()
        {
            string sumText = "";
            bool firstAdd = true;
            foreach (Tuple<int, int> tuple in sumDice)
            {
                if (firstAdd)
                {
                    firstAdd = false;
                    sumText = tuple.Item2.ToString();
                }
                else
                {
                    sumText += " + "+tuple.Item2.ToString();
                }
            }
            lbl_Sum.Text = sumText;
        }

        void SetTotalText()
        {
            bool allMinimums = true;
            bool allMaximums = true;
            int total = 0;
            foreach (Tuple<int, int> tuple in sumDice)
            {
                if(tuple.Item2 < tuple.Item1)
                {
                   allMaximums = false;
                }
                if(tuple.Item2 > 1)
                {
                   allMinimums = false;
                }
                total += tuple.Item2;
            }
            IsAllMaximums = allMaximums;
            IsAllMinimums = allMinimums;
            SetFromBoolStates();
            lbl_Total.Text = total.ToString();
        }

        void Clear()
        {
            IsAllMaximums = false;
            IsAllMinimums = false;
            lbl_Total.Text = "0";
            lbl_Sum.Text = "0";
            sumDice = new List<Tuple<int, int>>();
            SetFromBoolStates();
        }

        void SetFromBoolStates()
        {
            if(!IsAllMaximums && !IsAllMinimums)
            {
                lbl_Total.TextColor = Color.FromRgb(0,0,0);
            }
            else if(!IsAllMaximums && IsAllMinimums)
            {
                lbl_Total.TextColor = Color.FromRgb(255, 0, 0);
            }
            else if (IsAllMaximums && !IsAllMinimums)
            {
                lbl_Total.TextColor = Color.FromRgb(0, 255, 0);
            }
        }

        private void btn_img002Dice_Clicked(object sender, EventArgs e)
        {
            RollDice(2);
            SetSumText();
            SetTotalText();
        }

        private void btn_img003Dice_Clicked(object sender, EventArgs e)
        {
            RollDice(3);
            SetSumText();
            SetTotalText();
        }

        private void btn_img004Dice_Clicked(object sender, EventArgs e)
        {
            RollDice(4);
            SetSumText();
            SetTotalText();
        }

        private void btn_img006Dice_Clicked(object sender, EventArgs e)
        {
            RollDice(6);
            SetSumText();
            SetTotalText();
        }

        private void btn_img008Dice_Clicked(object sender, EventArgs e)
        {
            RollDice(8);
            SetSumText();
            SetTotalText();
        }

        private void btn_img010Dice_Clicked(object sender, EventArgs e)
        {
            RollDice(10);
            SetSumText();
            SetTotalText();
        }

        private void btn_img012Dice_Clicked(object sender, EventArgs e)
        {
            RollDice(12);
            SetSumText();
            SetTotalText();
        }

        private void btn_img020Dice_Clicked(object sender, EventArgs e)
        {
            RollDice(20);
            SetSumText();
            SetTotalText();
        }

        private void btn_img100Dice_Clicked(object sender, EventArgs e)
        {
            RollDice(100);
            SetSumText();
            SetTotalText();
        }

        private void btn_clear_Clicked(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
