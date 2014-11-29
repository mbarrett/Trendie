using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Trendie.Core.Cache;

namespace Trendie.UnitTests.Cache
{
    public class WebCacheTests
    {
        [TestFixture]
        public class When_getting_an_item_from_cache_and_it_exists_in_cache : Given_a_web_cache
        {
            [SetUp]
            public new void SetUp()
            {
                _httpRuntimeCacheWrapper.Get<object>(CacheKey).Returns(_item);

                _subject = new WebCache(_httpRuntimeCacheWrapper);
                _result = _subject.Get(CacheKey, _getItemCallback, ExpireInMinutes);
            }

            [Test]
            public void it_should_call_get_on_http_runtime_cache_wrapper()
            {
                _httpRuntimeCacheWrapper.Received(1).Get<object>(CacheKey);
            }

            [Test]
            public void it_should_return_not_null_result()
            {
                Assert.IsNotNull(_result);
            }
        }

        [TestFixture]
        public class When_getting_an_item_from_cache_and_it_does_not_exist_in_cache : Given_a_web_cache
        {
            [SetUp]
            public new void SetUp()
            {
                _getItemCallback = _mockCaller.GetItem;
                _httpRuntimeCacheWrapper.Get<object>(CacheKey).Returns(null);

                _subject = new WebCache(_httpRuntimeCacheWrapper);
                _result = _subject.Get(CacheKey, _getItemCallback, ExpireInMinutes);
            }

            [Test]
            public void it_should_call_get_on_http_runtime_cache_wrapper()
            {
                _httpRuntimeCacheWrapper.Received(1).Get<object>(CacheKey);
            }

            [Test]
            public void it_should_call_get_item_from_data_provider()
            {
                _mockCaller.Received(1).GetItem();
            }

            [Test]
            public void it_should_call_insert_to_cache_if_provider_return_not_null_item()
            {
                _httpRuntimeCacheWrapper.Received(1).Insert(CacheKey, _item, ExpireInMinutes);
            }

            [Test]
            public void it_should_return_not_null_item()
            {
                Assert.IsNotNull(_result);
            }

            [Test]
            public void it_should_return_item_returned_by_data_provider()
            {
                Assert.AreSame(_item, _result);
            }
        }

        [TestFixture]
        public class When_item_does_not_exist_in_cache_and_data_provider_returned_null_item : Given_a_web_cache
        {
            [SetUp]
            public new void SetUp()
            {
                _mockCaller.GetItem().Returns(null as Object);
                _getItemCallback = _mockCaller.GetItem;
                _httpRuntimeCacheWrapper.Get<object>(CacheKey).Returns(null);
                
                _subject = new WebCache(_httpRuntimeCacheWrapper);
                _result = _subject.Get(CacheKey, _getItemCallback, ExpireInMinutes);
            }

            [Test]
            public void it_should_call_get_on_http_runtime_cache_wrapper()
            {
                _httpRuntimeCacheWrapper.Received(1).Get<object>(CacheKey);
            }

            [Test]
            public void it_should_call_get_item_from_data_provider()
            {
                _mockCaller.Received(1).GetItem();
            }

            [Test]
            public void it_should_not_call_insert_to_cache()
            {
                _httpRuntimeCacheWrapper.DidNotReceive().Insert(CacheKey, _item, ExpireInMinutes);
            }

            [Test]
            public void it_should_return_null()
            {
                Assert.IsNull(_result);
            }
        }

        public class Given_a_web_cache
        {
            protected const string CacheKey = "TestCacheKey";
            protected const int ExpireInMinutes = 1;
            protected object _item = new object();

            protected WebCache _subject;
            protected IHttpRuntimeCacheWrapper _httpRuntimeCacheWrapper;
            protected object _result;
            protected Func<object> _getItemCallback;
            protected IMockCaller _mockCaller;

            [SetUp]
            public void SetUp()
            {
                _httpRuntimeCacheWrapper = Substitute.For<IHttpRuntimeCacheWrapper>();

                _mockCaller = Substitute.For<IMockCaller>();
                _mockCaller.GetItem().Returns(_item);
            }
        }
    }

    public interface IMockCaller
    {
        Object GetItem();
    }
}
