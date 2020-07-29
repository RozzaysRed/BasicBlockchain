using System;
using System.Text;
using System.Security.Cryptography;

namespace BasicBlockchain {
    class Block
    {
        // Previous Block hash
        private string previousHash;
        // this Block Hash
        private string hash;
        // Block created time
        private long timeStamp;
        // Info contianed in block
        private string data;
        private int nonce;

        public Block(long timeStamp, string data, string previousHash)
        {
            this.timeStamp = timeStamp;
            this.data = data;
            this.previousHash = previousHash;

            //this.hash = HashBlock(this);
        }

        // basic Getters and setters
        public void SetTimeStamp(long timeStamp)
        {
            this.timeStamp = timeStamp;
        }

        public long GetTimeStamp()
        {
            return this.timeStamp;
        }

        public void SetPreviousBlockHash(string previousHash)
        {
            this.previousHash = previousHash;
        }

        public string GetPreviousBlockHash()
        {
            return this.previousHash;
        }

        public void SetData(string data)
        {
            this.data = data;
        }

        public string GetData()
        {
            return this.data;
        }

        public void SetNonce(int nonce)
        {
            this.nonce = nonce;
        }

        public int GetNonce()
        {
            return this.nonce;
        }

        public string GetBlockHash()
        {
            return this.hash;
        }

        public Block AddBlock()
        {
            var pow = new ProofOfWork(this);   
            this.hash = pow.Run();
            return this;
        }   
    }
}