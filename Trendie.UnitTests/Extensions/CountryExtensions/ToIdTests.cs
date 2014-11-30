using System;
using NUnit.Framework;

namespace Trendie.UnitTests.Extensions.CountryExtensions
{
    public class ToIdTests
    {
        [TestFixture]
        public class when_transforming_country_to_id_and_country_is_uk : given_a_country_for_id
        {
            [SetUp]
            public void Setup()
            {
                _country = "uk";
                _outcome = Core.Extensions.CountryExtensions.ToId(_country);
            }

            [Test]
            public void should_return_23424975()
            {
                Assert.That(_outcome, Is.EqualTo(23424975));
            }
        }

        [TestFixture]
        public class when_transforming_country_to_id_and_country_is_us : given_a_country_for_id
        {
            [SetUp]
            public void Setup()
            {
                _country = "us";
                _outcome = Core.Extensions.CountryExtensions.ToId(_country);
            }

            [Test]
            public void should_return_23424977()
            {
                Assert.That(_outcome, Is.EqualTo(23424977));
            }
        }

        [TestFixture]
        public class when_transforming_country_to_id_and_country_is_aus : given_a_country_for_id
        {
            [SetUp]
            public void Setup()
            {
                _country = "aus";
                _outcome = Core.Extensions.CountryExtensions.ToId(_country);
            }

            [Test]
            public void should_return_23424748()
            {
                Assert.That(_outcome, Is.EqualTo(23424748));
            }
        }

        [TestFixture]
        public class when_transforming_country_to_id_and_country_is_not_recognised : given_a_country_for_id
        {
            private Exception _exception;

            [SetUp]
            public void Setup()
            {
                _country = "1234ABCD";

                try
                {
                    _outcome = Core.Extensions.CountryExtensions.ToId(_country);
                }
                catch (Exception ex)
                {
                    _exception = ex;
                }
            }

            [Test]
            public void should_throw_exception()
            {
                Assert.That(_exception.Message, Is.EqualTo(string.Format("Country id not found for '{0}'", (object) _country)));
            }
        } 
    }

    public class given_a_country_for_id
    {
        protected string _country;
        protected int _outcome;
    }
}