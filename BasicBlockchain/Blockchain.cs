using System;
using System.Collections.Generic;

namespace BasicBlockchain
{
    public sealed class Blockchain : IBlockchain
    {
        static readonly Blockchain _instance = new Blockchain();
        List<Block> blockchain = new List<Block>();

        public static Blockchain Instance
        {
            get
            {
                return _instance;
            }
        }

        public Blockchain()
        {
            Console.WriteLine(
                    "Blockchain Count: {0}", 
                    this.blockchain.Count.ToString()
                );

            AddGenesisBlock();
        }

        private void AddGenesisBlock()
        {
            Console.WriteLine("Adding GenesisBlock");
            this.blockchain.Add(
                    new Block(
                        DateTime.UtcNow.Ticks, 
                        "Genesis Block", ""
                    ).AddBlock()
                );

            Console.WriteLine(
                    "\nBlockchain Count: {0}, {1}: {2}", 
                    this.blockchain.Count.ToString(), 
                    nameof(AddGenesisBlock), 
                    this.blockchain[0].GetData()
                );
        }

        public void AddBlock(string data)
        {
            // Get previous block hash
            string previousHash = this.blockchain[this.blockchain.Count - 1].GetBlockHash();
            
            Block newBlock = new Block(
                    DateTime.UtcNow.Ticks, 
                    data, 
                    previousHash
                );
            
            this.blockchain.Add(newBlock.AddBlock());

            Console.WriteLine(
                    "\n{0} Count: {1}, NewBlockHash: {2}", 
                    nameof(Blockchain), 
                    this.blockchain.Count.ToString(), 
                    this.blockchain[this.blockchain.Count-1].GetBlockHash()
                );
        }
    }
}