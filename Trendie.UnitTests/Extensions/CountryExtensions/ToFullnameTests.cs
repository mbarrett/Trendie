using System;
using NUnit.Framework;
using Trendie.Core.Extensions;

namespace Trendie.UnitTests.Extensions.CountryExtensions
{
    public class ToFullnameTests
    {
        [TestFixture]
        public class when_transforming_country_to_fullname_and_country_is_uk : given_a_country_for_fullname
        {
            [SetUp]
            public void Setup()
            {
                _country = "uk";
                _outcome = _country.ToFullname();
            }

            [Test]
            public void should_return_united_kingdom()
            {
                Assert.That(_outcome, Is.EqualTo("United Kingdom"));
            }
        }

        [TestFixture]
        public class when_transforming_country_to_fullname_and_country_is_us : given_a_country_for_fullname
        {
            [SetUp]
            public void Setup()
            {
                _country = "us";
                _outcome = _country.ToFullname();
            }

            [Test]
            public void should_return_united_states()
            {
                Assert.That(_outcome, Is.EqualTo("United States"));
            }
        }

        [TestFixture]
        public class when_transforming_country_to_fullname_and_country_is_aus : given_a_country_for_fullname
        {
            [SetUp]
            public void Setup()
            {
                _country = "aus";
                _outcome = _country.ToFullname();
            }

            [Test]
            public void should_return_australia()
            {
                Assert.That(_outcome, Is.EqualTo("Australia"));
            }
        }

        [TestFixture]
        public class when_transforming_country_to_fullname_and_country_is_not_recongised : given_a_country_for_fullname
        {
            private Exception _exception;

            [SetUp]
            public void Setup()
            {
                _country = "1234ABCD";

                try
                {
                    _outcome = _country.ToFullname();
                }
                catch (Exception ex)
                {
                    _exception = ex;
                }
            }

            [Test]
            public void should_throw_exception()
            {
                Assert.That(_exception.Message, Is.EqualTo(string.Format("Country name not found for '{0}'", _country)));
            }
        } 
    }

    public class given_a_country_for_fullname
    {
        protected string _country;
        protected string _outcome;
    }
}