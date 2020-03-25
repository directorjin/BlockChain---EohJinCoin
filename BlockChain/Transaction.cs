using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChain
{
    public class Transaction
    {

        String sender;
        String receiver;
        double amount;

        public String GetSender()
        {
            return sender;
        }
        public void SetSender(String sender)
        {
            this.sender = sender;
        }
        public String GetReceiver()
        {
            return receiver;
        }
        public void SetReceiver(String receiver)
        {
            this.receiver = receiver;
        }
        public double GetAmount()
        {
            return amount;
        }
        public void SetAmount(double amount)
        {
            this.amount = amount;
        }

        public Transaction(String sender, String receiver, double amount)
        {
            this.sender = sender;
            this.receiver = receiver;
            this.amount = amount;
        }

        public String GetDate()
        {


            return DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");


        }

        public String GetInformation()
        {
            return "[" + GetDate() + "] " + sender + "が" + receiver + "に" + amount + "つのコインを送りました。";
        }
    }
}
