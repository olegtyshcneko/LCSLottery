using System;
using Xunit;
using LCSLottery.Core;

namespace LCSLottery.Tests
{
    public class FnvHashTesting
    {
        [Theory]
        [InlineData("Alison,Alice,Austria", 2382747853)]
        public void Hash_Should_Be_Equals_To_Hashed_Data(string data, uint hash)
        {
            var hashFromData = FnvHash.Hash(data);
            Assert.Equal(hash, hashFromData);
        }
    }
}