using System;
using System.Text;
using System.Security.Cryptography;

using System.Collections.Generic;

namespace BlockChain
{
    

    public class Block
    {

        

        private int blockID;
        private StringBuilder previousBlockHash;
        private int nonce;
        
        private List<Transaction> transactionList = new List<Transaction>();


        public Block(int blockID, StringBuilder previousBlockHash, int nonce, List<Transaction> transactionList)
        {

            this.blockID = blockID;
            this.previousBlockHash = previousBlockHash;
            this.nonce = nonce;
            this.transactionList = transactionList;

        }

        #region GetSet Date(ID,nonce,data)
        public int GetBlockID()
        {
            return blockID;
        }
        public void SetBlockID(int blockID)
        {
            this.blockID = blockID;
        }
        public StringBuilder getPreviousBlockHash()
        {
            return previousBlockHash;
        }
        public void setPreviousBlockHash(StringBuilder previousBlockHash)
        {
            this.previousBlockHash = previousBlockHash;
        }
        public int GetNonce()
        {
            return nonce;
        }

        public void SetNonce(int nonce)
        {
            this.nonce = nonce;
        }

        public StringBuilder GetBlockHash()
        {
            StringBuilder sb = new StringBuilder();


            sb.Append(MyFuction.HashPassword(nonce + GetTransaction() + previousBlockHash));
            return sb;
        }
        #endregion

        #region Transaction
        public String GetTransaction()
        {
            String transactionInformations = "";

            for (int i = 0; i < transactionList.Count; i++)
            {
                transactionInformations += transactionList[i].GetInformation();
            }
            return transactionInformations;
        }

        public void AddTransaction(Transaction transaction)
        {
            transactionList.Add(transaction);
        }
        #endregion


        public void ShowInformation()
        {

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Block Number : " + GetBlockID());
            Console.WriteLine("Mining Number : " + GetNonce());
            Console.WriteLine("Block Data : ");
            for (int i = 0; i < transactionList.Count; i++) Console.WriteLine(transactionList[i].GetInformation());
            Console.WriteLine("Previous Hash : " + getPreviousBlockHash());
            Console.WriteLine("This Block Hash : " + GetBlockHash());
            Console.WriteLine("--------------------------------------");

        }



        public void Mine()
        {

            while (true)
            {
                if (MyFuction.SubString(GetBlockHash(), 0, 4).Equals("1993"))
                {
                    Console.WriteLine(blockID + "番目のブロックの採掘に成功しました。");
                    break;
                }
                nonce++;
            }
        }
    }

    #region MyFuction for Utility
    internal class MyFuction
    {
        public static string HashPassword(string input)
        {
            var sha1 = SHA1Managed.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] outputBytes = sha1.ComputeHash(inputBytes);
            return BitConverter.ToString(outputBytes).Replace("-", "").ToLower();
        }


        public static StringBuilder SubString(StringBuilder input, int index, int length)
        {
            StringBuilder subString = new StringBuilder();
            if (index + length - 1 >= input.Length || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index Out Of Range");
            }


            int endIndex = index + length;
            for (int i = index; i < endIndex; i++)
            {
                subString.Append(input[i]);
            }
            return subString;
        }
    }
    #endregion
}