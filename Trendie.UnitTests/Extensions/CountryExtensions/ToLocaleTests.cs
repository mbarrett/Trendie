using System;
using NUnit.Framework;

namespace Trendie.UnitTests.Extensions.CountryExtensions
{
    public class ToLocaleTests
    {
        [TestFixture]
        public class when_transforming_country_to_locale_and_country_is_uk : given_a_country_for_locale
        {
            [SetUp]
            public void Setup()
            {
                _country = "uk";
                _outcome = Core.Extensions.CountryExtensions.ToLocale(_country);
            }

            [Test]
            public void should_return_uk()
            {
                Assert.That(_outcome, Is.EqualTo("uk"));
            }
        }

        [TestFixture]
        public class when_transforming_country_to_locale_and_country_is_us : given_a_country_for_locale
        {
            [SetUp]
            public void Setup()
            {
                _country = "us";
                _outcome = Core.Extensions.CountryExtensions.ToLocale(_country);
            }

            [Test]
            public void should_return_us()
            {
                Assert.That(_outcome, Is.EqualTo("us"));
            }
        }

        [TestFixture]
        public class when_transforming_country_to_locale_and_country_is_aus : given_a_country_for_locale
        {
            [SetUp]
            public void Setup()
            {
                _country = "aus";
                _outcome = Core.Extensions.CountryExtensions.ToLocale(_country);
            }

            [Test]
            public void should_return_au()
            {
                Assert.That(_outcome, Is.EqualTo("au"));
            }
        }

        [TestFixture]
        public class when_transforming_country_to_locale_and_country_is_not_recognised : given_a_country_for_locale
        {
            private Exception _exception;

            [SetUp]
            public void Setup()
            {
                _country = "1234ABCD";

                try
                {
                    _outcome = Core.Extensions.CountryExtensions.ToLocale(_country);
                }
                catch (Exception ex)
                {
                    _exception = ex;
                }
            }

            [Test]
            public void should_throw_exception()
            {
                Assert.That(_exception.Message, Is.EqualTo(string.Format("Country locale not found for '{0}'", (object) _country)));
            }
        } 
    }

    public class given_a_country_for_locale
    {
        protected string _country;
        protected string _outcome;
    }
}