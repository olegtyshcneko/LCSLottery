namespace LCSLottery.Core.Data
{
    public class ParticipantEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string LotteryNumber { get; set; }

        public string FormattedParticipant
        {
            get 
            {
                return $"{FirstName},{LastName},{Country}";
            }
        }

        public bool IsDuplicate(ParticipantEntity otherParticipant)
        {
            return this.IsEquals(otherParticipant) && this.LotteryNumber == otherParticipant.LotteryNumber;
        }

        /// <summary>
        /// Returns true if first name, last name and country is same
        /// </summary>
        public bool IsEquals(ParticipantEntity otherParticipant)
        {
            if(otherParticipant == null)
                return false;

            return otherParticipant == this || this.GetHashCode() == otherParticipant.GetHashCode();
        }

        //NOTE: just for case standart method, but IsEquals is better because it doesn't need casting
        public override bool Equals (object other)
        { 
            if (other == null || GetType() != other.GetType())
            {
                return false;
            }
            
            return other == this || this.GetHashCode() == other.GetHashCode();
        }
       
        public override int GetHashCode()
        {
            return (int)FnvHash.Hash(FormattedParticipant);
        }
    }
}