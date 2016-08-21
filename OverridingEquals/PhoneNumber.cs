using System;

namespace OverridingEquals
{
    public class PhoneNumber
    {
        // First part of a phone number: (XXX) 000-0000
        public string AreaCode { get; set; }

        // Second part of a phone number: (000) XXX-0000
        public string Exchange { get; set; }

        // Third part of a phone number: (000) 000-XXXX
        public string SubscriberNumber { get; set; }

        public override bool Equals(object value)
        {
            PhoneNumber number = value as PhoneNumber;

            return !Object.ReferenceEquals(null, number)
                && String.Equals(AreaCode, number.AreaCode)
                && String.Equals(Exchange, number.Exchange)
                && String.Equals(SubscriberNumber, number.SubscriberNumber);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // Choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, AreaCode) ? AreaCode.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Exchange) ? Exchange.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, SubscriberNumber) ? SubscriberNumber.GetHashCode() : 0);
                return hash;
            }
        }

        public static bool operator ==(PhoneNumber numberA, PhoneNumber numberB)
        {
            if (Object.ReferenceEquals(numberA, numberB))
            {
                return true;
            }

            if(Object.ReferenceEquals(null, numberA))
            {
                return false;
            }

            return (numberA.Equals(numberB));
        }

        public static bool operator !=(PhoneNumber numberA, PhoneNumber numberB)
        {
            return !(numberA == numberB);
        }
    }
}
