using System;
using BUHALOVO.MVVM;

namespace BUHALOVO
{
    public class Note: ViewModelBase
    {
        private string name = "";
        private string type = "";
        private double amountOfMoney = 0;
        private bool isReceipt;
        private DateTime date = DateTime.Today;


        public Note()
        {

        }
        public Note(string name, string type, double amountOfMoney, bool isReceipt, DateTime date)
        {
            Name = name;
            Type = type;
            AmountOfMoney = amountOfMoney;
            IsReceipt = isReceipt;
            Date = date;
        }

        public string Name 
        {
            get { return name; }
            set
            {
                name = value;
                Set(ref name, value);
            } 
        }
        public string Type
        {
            get { return type; }
            set
            {
                type = value; 
                Set(ref type, value);
            }
        }

        public double AmountOfMoney
        {
            get { return amountOfMoney; }
            set { amountOfMoney = value; 
                Set(ref amountOfMoney, value);
            }
        }

        public bool IsReceipt 
        { 
            get { return isReceipt; }
            set
            {
                if (AmountOfMoney > 0)
                {
                    isReceipt = true;
                    Set(ref isReceipt, isReceipt);
                }
                else
                {
                    isReceipt = false;
                    Set(ref isReceipt, isReceipt);
                }
            } 
        }
        public DateTime Date 
        { 
            get { return date; }
            set 
            { 
                date = value; 
                Set(ref date, value);
            } 
        }
    }
}
