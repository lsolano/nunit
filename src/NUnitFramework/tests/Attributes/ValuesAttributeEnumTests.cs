// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

#region Using Directives

using System;
using NUnit.Framework;

#endregion

namespace NUnit.Framework.Attributes
{
    public enum EnumValues
    {
        One,
        Two,
        Three,
        Four,
        Five
    }

    [TestFixture]
    public class ValuesAttributeEnumTests
    {
        private int _countEnums;
        private int _countBools;
        private int _countNullableEnums;
        private int _countNullableBools;
        private int _countInBools;
        private int _countNullableInBools;
        private int _countRefBools;
        private int _countNullableRefBools;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _countEnums = 0;
            _countBools = 0;
            _countNullableEnums = 0;
            _countNullableBools = 0;
            _countInBools = 0;
            _countNullableInBools = 0;
            _countRefBools = 0;
            _countNullableRefBools = 0;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Assert.That(_countEnums, Is.EqualTo(5), "The TestEnumValues method should have been called 5 times");
            Assert.That(_countBools, Is.EqualTo(2), "The TestBoolValues method should have been called twice");
            Assert.That(_countNullableEnums, Is.EqualTo(6), "The TestNullableEnum method should have been called 6 times");
            Assert.That(_countNullableBools, Is.EqualTo(3), "The TestNullableBool method should have been called thrice");
            Assert.That(_countInBools, Is.EqualTo(2), "The TestInBool method should have been called twice");
            Assert.That(_countNullableInBools, Is.EqualTo(3), "The TestNullableInBool method should have been called thrice");
            Assert.That(_countRefBools, Is.EqualTo(2), "The TestRefBool method should have been called twice");
            Assert.That(_countNullableRefBools, Is.EqualTo(3), "The TestNullableRefBool method should have been called thrice");
        }

        [Test]
        public void TestEnumValues([Values]EnumValues value)
        {
            _countEnums++;
        }

        [Test]
        public void TestBoolValues([Values]bool value)
        {
            _countBools++;
        }

        [Test]
        public void TestNullableEnum([Values]EnumValues? enumValue)
        {
            /* runs with null and all enum values in no particular order */
            ++_countNullableEnums;
        }

        [Test]
        public void TestNullableBool([Values] bool? testInput)
        {
            /* runs with null, true, false in no particular order */
            ++_countNullableBools;
        }

        [Test]
        public void TestInBool([Values] in bool testInBoolean)
        {
            _countInBools++;
        }

        [Test]
        public void TestNullableInBool([Values] in bool? testNullableInBoolean)
        {
            _countNullableInBools++;
        }

        [Test]
        public void TestRefBool([Values] ref bool testRefBoolean)
        {
            _countRefBools++;
        }

        [Test]
        public void TestNullableRefBool([Values] ref bool? testRefBoolean)
        {
            _countNullableRefBools++;
        }
    }
}
