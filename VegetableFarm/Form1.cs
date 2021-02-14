using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VegetableFarm.Classes;
using VegetableFarm.Enums;

namespace VegetableFarm
{
    public partial class Form : System.Windows.Forms.Form
    {                  
        Dictionary<CheckBox, Cell> field = new Dictionary<CheckBox, Cell>();

        public const int TIMER_INTERVAL = 10;
        public const int MAX_TIMER_INTERVAL = 200;
        public const int MIN_TIMER_INTERVAL = 10;

        public Form()
        {
            InitializeComponent();
            InitializeField();
        }

        public void InitializeField()
        {
            foreach (CheckBox cb in tableLayoutPanel.Controls)
                field.Add(cb, new Cell());
        }

        private void Plant(CheckBox cb)
        {
            field[cb].StartGrow();
            UpdateCell(cb);
        }

        private void Harvest(CheckBox cb)
        {
           field[cb].Cut();
           UpdateCell(cb);
        }

        private void UpdateCell(CheckBox cb)
        {
            Image img = FarmGraphics.empty;
            switch (field[cb].state)
            {
                case CellState.Planted:
                    img = FarmGraphics.planted;
                    break;
                case CellState.Green:
                    img = FarmGraphics.green;
                    break;
                case CellState.Immature:
                    img = FarmGraphics.immature;
                    break;
                case CellState.Mature:
                    img = FarmGraphics.mature;
                    break;
                case CellState.Overgrow:
                    img = FarmGraphics.overgrow;
                    break;
            }
            cb.BackgroundImage = img;
        }

        private void UpdateInfo()
        {
            labelDay.Text = "Day: " + FarmEngine.day;
            labelCash.Text = "Current cash: " + FarmEngine.cash + " ₽";
            labelTimer.Text = "Timer interval: " + timer.Interval + " ms";
        }

        /*-------------------------------------------------------------------*/
        /*---------------------------EVENT HANDLERS--------------------------*/
        /*-------------------------------------------------------------------*/

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!timer.Enabled) timer.Start();

            CheckBox checkbox = (CheckBox)sender;

            if (FarmEngine.cash >= FarmEngine.SPEND_CASH_PLANTED && checkbox.Checked)
                Plant(checkbox);
            else if (FarmEngine.cash >= FarmEngine.SPEND_CASH_OVERGROW && !checkbox.Checked)
                Harvest(checkbox);
            else
                MessageBox.Show("Game over. Reload the app");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            FarmEngine.day++;
            foreach (CheckBox cb in tableLayoutPanel.Controls)
            {
                field[cb].NextStep();
                UpdateCell(cb);
            }
            UpdateInfo();
        }
       
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (timer.Interval > MIN_TIMER_INTERVAL)
                timer.Interval -= TIMER_INTERVAL;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (timer.Interval < MAX_TIMER_INTERVAL)
                timer.Interval += TIMER_INTERVAL;
        }
    }
}

