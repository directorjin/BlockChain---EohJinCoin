using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChain
{
    public class BlockChainMain
    {

        public static void Main(String[] args)
        {

            Block block1 = new Block(1, null, 0, new List<Transaction>());
            block1.Mine();
            block1.ShowInformation();

            Block block2 = new Block(2, block1.GetBlockHash(), 0, new List<Transaction>());
            block2.AddTransaction(new Transaction("A", "B", 1.5));
            block2.AddTransaction(new Transaction("C", "B", 0.7));
            block2.Mine();
            block2.ShowInformation();

            Block block3 = new Block(3, block2.GetBlockHash(), 0, new List<Transaction>());
            block3.AddTransaction(new Transaction("D", "E", 8.2));
            block3.AddTransaction(new Transaction("B", "A", 0.4));
            block3.Mine();
            block3.ShowInformation();

            Block block4 = new Block(4, block3.GetBlockHash(), 0, new List<Transaction>());
            block4.AddTransaction(new Transaction("E", "D", 0.1));
            block4.Mine();
            block4.ShowInformation();
            

        }

    }
}
