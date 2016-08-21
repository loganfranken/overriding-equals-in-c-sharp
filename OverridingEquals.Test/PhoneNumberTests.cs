using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace OverridingEquals.Test
{
    [TestClass]
    public class PhoneNumberTests
    {
        [TestMethod]
        public void ReferenceEquality()
        {
            PhoneNumber numberA = new PhoneNumber();
            PhoneNumber numberB = numberA;

            Assert.IsTrue(numberA == numberB);
            Assert.IsTrue(numberA.Equals(numberB));
            Assert.IsTrue(Object.ReferenceEquals(numberA, numberB));
        }

        [TestMethod]
        public void ValueEquality()
        {
            PhoneNumber numberC = new PhoneNumber { AreaCode = "123", Exchange = "456", SubscriberNumber = "7890" };
            PhoneNumber numberD = new PhoneNumber { AreaCode = "123", Exchange = "456", SubscriberNumber = "7890" };

            Assert.IsTrue(numberC == numberD);
            Assert.IsTrue(numberC.Equals(numberD));
        }

        [TestMethod]
        public void UseAsDictionaryKey()
        {
            Dictionary<PhoneNumber, Employee> directory = new Dictionary<PhoneNumber, Employee>();

            directory.Add(
                new PhoneNumber { AreaCode = "123", Exchange = "456", SubscriberNumber = "7890" },
                new Employee { FirstName = "Gordon", LastName = "Freeman" });

            directory.Add(
                new PhoneNumber { AreaCode = "111", Exchange = "222", SubscriberNumber = "3333" },
                new Employee { FirstName = "Samus", LastName = "Aran" });

            Employee employee = directory[new PhoneNumber { AreaCode = "123", Exchange = "456", SubscriberNumber = "7890" }];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PreventDictionaryKeyDuplicates()
        {
            Dictionary<PhoneNumber, Employee> directory = new Dictionary<PhoneNumber, Employee>();

            directory.Add(
                new PhoneNumber { AreaCode = "123", Exchange = "456", SubscriberNumber = "7890" },
                new Employee { FirstName = "Super", LastName = "Mario" });

            directory.Add(
                new PhoneNumber { AreaCode = "123", Exchange = "456", SubscriberNumber = "7890" },
                new Employee { FirstName = "Princess", LastName = "Peach" });
        }

        [TestMethod]
        public void NullEquality()
        {
            PhoneNumber phoneNumberA = null;
            PhoneNumber phoneNumberB = null;

            Assert.IsTrue(phoneNumberA == phoneNumberB);
        }

        [TestMethod]
        public void NullReferenceEquality()
        {
            PhoneNumber phoneNumberA = null;
            PhoneNumber phoneNumberB = new PhoneNumber();

            Assert.IsFalse(phoneNumberA == phoneNumberB); // Throws an exception
        }
    }
}
