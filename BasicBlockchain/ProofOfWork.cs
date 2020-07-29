using System;
using System.Text;
using System.Security.Cryptography;

namespace BasicBlockchain
{
    class ProofOfWork
    {
        private int difficulty = 6;
        private Block block;
        private string target;

        public ProofOfWork(Block block)
        {
            this.block = block;

            this.target = new String(new char[difficulty]).Replace('\0', '0');
        }

        private string HashBlock()
        {
            // String together all information needed
            String combinedBlockData = this.block.GetPreviousBlockHash()
                + this.block.GetTimeStamp()
                + this.block.GetNonce()
                + this.block.GetData();
            
            string newHash = "";
            using (SHA256 mySHA256 = SHA256.Create())
            {
                // Take the input of all the combined hashes and hash again
                byte[] hashValue = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(combinedBlockData));

                // convert the new hash byte array to a string
                newHash = ConvertHashToString(hashValue);
            }
            return newHash;
        }

        public string Run()
        {
            int nonce = 0;
            string hash = "";
            while(nonce < int.MaxValue && !hash.StartsWith(this.target))
            {
                this.block.SetNonce(nonce);
                hash = this.HashBlock();
                Console.Write("\r{0}", hash);
                nonce++;
            }

            return hash;
        }

        private void Validate()
        {

        }

        public static byte[] HexToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private string ConvertHashToString(byte[] bytes) {
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}