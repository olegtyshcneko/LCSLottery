namespace LCSLottery.Core
{
    //Simple and fast hashing algorithm that I will be using for comparing objects
    public static class FnvHash
    {
        public static uint Hash(string data)
        {
            const uint fnvPrimeNumber = 0x811C9DC5;
            uint hash = 0;
            for(var i=0; i<data.Length; i++)
            {
                hash *= fnvPrimeNumber;
                hash ^= ((byte)data[i]);
            }

            return hash;
        }
    }
}