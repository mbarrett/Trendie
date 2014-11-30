using NUnit.Framework;
using Trendie.Core.Extensions;

namespace Trendie.UnitTests.Extensions.HrefExtensions
{
    public class ToHrefTests
    {
        [TestFixture]
        public class when_transforming_value_to_href_and_value_contains_spaces : given_a_href_value
        {
            [SetUp]
            public void Setup()
            {
                _value = "something with spaces";
                _expected = "somethingwithspaces";

                _outcome = _value.ToHref();
            }

            [Test]
            public void should_remove_spaces_from_value()
            {
                Assert.That(_outcome, Is.EqualTo(_expected));
            }
        }

        [TestFixture]
        public class when_transforming_value_to_href_and_value_contains_single_quotes : given_a_href_value
        {
            [SetUp]
            public void Setup()
            {
                _value = "something 'with' quotes";
                _expected = "somethingwithquotes";

                _outcome = _value.ToHref();
            }

            [Test]
            public void should_remove_quotes_from_value()
            {
                Assert.That(_outcome, Is.EqualTo(_expected));
            }
        }

        [TestFixture]
        public class when_transforming_value_to_href_and_value_contains_hashtag : given_a_href_value
        {
            [SetUp]
            public void Setup()
            {
                _value = "something with #";
                _expected = "somethingwith";

                _outcome = _value.ToHref();
            }

            [Test]
            public void should_remove_quotes_from_value()
            {
                Assert.That(_outcome, Is.EqualTo(_expected));
            }
        } 
    }

    public class given_a_href_value
    {
        protected string _outcome;
        protected string _value;
        protected string _expected;
    }
}