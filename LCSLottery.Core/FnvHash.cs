namespace LCSLottery.Core
{
    //Simple and fast hashing algorithm that I will be using for comparing objects
    public static class FnvHash
    {
        public static int Hash(string data)
        {
            const int fnvPrimeNumber = 0x122C9DC5;
            int hash = 0;
            for(var i=0; i<data.Length; i++)
            {
                hash *= fnvPrimeNumber;
                hash ^= ((byte)data[i]);
            }

            return hash;
        }
    }
}