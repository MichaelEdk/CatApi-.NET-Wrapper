using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatApiWrapper.RequestBuilders;

namespace CatApiWrapper.Tests
{
    [TestClass]
    public class RequestBuilderTests
    {
        private const string DummyApiKey = "DAK";
        private const string DummyImageId = "image1";
        private const string DummySubId = "subby";
        private const string BaseUri = "http://thecatapi.com/api/images/";

        [TestMethod]
        public void WhenGetRequestIsBuilt_Then_UriIsAsExpected()
        {
            var actual = new GetRequestBuilder()
                .WithApiKey(DummyApiKey)
                .WithImageId(DummyImageId)
                .WithCategory(Category.Funny)
                .WithType(new[] { ImageType.Jpg, ImageType.Gif, ImageType.Png })
                .WithSubId(DummySubId)
                .WithSize(Size.Full)
                .Build();

            var expectedQuery = "get?format=xml&api_key=DAK&image_id=image1&category=funny&type=jpg,gif,png&sub_id=subby&size=full&";
            var expected = $"{BaseUri}{expectedQuery}";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenResultsPerPageIsOutOfRange_Then_ExceptionIsThrown()
        {
            GetRequestBuilder BuildRequest()
            {
                return new GetRequestBuilder()
                .WithApiKey(DummyApiKey)
                .WithImageId(DummyImageId)
                .WithCategory(Category.Funny)
                .WithType(new[] { ImageType.Jpg, ImageType.Gif, ImageType.Png })
                .WithSubId(DummySubId)
                .WithSize(Size.Full)
                .WithResultsPerPage(-1);
            }

            AssertThrows<InvalidRequestException>(() => BuildRequest());
        }

        [TestMethod]
        public void WhenVoteRequestIsBuilt_Then_TheUrlIsAsExpected()
        {
            var actual = new VoteRequestBuilder(DummyApiKey, "image1", 7)
                .WithSubId("subId")
                .Build();

            var expectedQuery = "vote?api_key=DAK&image_id=image1&score=7&sub_id=subId&";
            var expected = $"{BaseUri}{expectedQuery}";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void VoteRequest_WhenARequiredParamIsNull_Then_ExceptionIsThrown()
        {
            var actual = new VoteRequestBuilder(DummyApiKey, null, 4)
                .WithSubId(DummySubId);

            AssertThrows<InvalidRequestException>(() => actual.Build());
        }

        [TestMethod]
        public void WhenGetVotesRequestIsBuilt_ThenTheUriIsAsExpected()
        {
            var actual = new GetVotesRequestBuilder(DummyApiKey)
                .WithSubId(DummySubId)
                .Build();

            var expectedQuery = "getvotes?api_key=DAK&sub_id=subby&";
            var expected = $"{BaseUri}{expectedQuery}";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void WhenARequiredParamIsNullInAGetVotesRequest_Then_ExceptionIsThrown()
        {
            var actual = new GetVotesRequestBuilder(null)
                .WithSubId(DummySubId);

            AssertThrows<InvalidRequestException>(() => actual.Build());
        }

        [TestMethod]
        public void WhenFavouriteRequestIsBuilt_Then_TheUriIsAsExpected()
        {
            var actual = new FavouriteRequestBuilder(DummyApiKey, DummyImageId)
                .WithAction(FavouriteAction.Add)
                .WithSubId(DummySubId)
                .Build();

            var expectedQuery = "favourite?api_key=DAK&image_id=image1&action=add&sub_id=subby&";
            var expected = $"{BaseUri}{expectedQuery}";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FavouriteRequest_WhenARequiredParamIsNull_Then_ExceptionIsThrown()
        {
            var actual = new FavouriteRequestBuilder(null, DummyImageId)
                .WithAction(FavouriteAction.Add);

            AssertThrows<InvalidRequestException>(() => actual.Build());
        }

        [TestMethod]
        public void WhenGetFavouriteRequestIsBuilt_Then_UrlIsAsExpected()
        {
            var actual = new GetFavouritesRequestBuilder(DummyApiKey)
                .WithSubId(DummySubId)
                .Build();

            var expectedQuery = "getfavourites?api_key=DAK&sub_id=subby&";
            var expected = $"{BaseUri}{expectedQuery}";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFavouriteRequest_WhenRequiredParamIsNull_Then_ExceptionIsThrown()
        {
            var actual = new GetFavouritesRequestBuilder(null)
                .WithSubId(DummySubId);

            AssertThrows<InvalidRequestException>(() => actual.Build());
        }

        [TestMethod]
        public void TestTheThing()
        {
            var getRequest = new GetRequestBuilder()
                .WithResultsPerPage(10);

            var client = new CatClient();
            var images = client.GetImages(getRequest);
        }

        internal static TException AssertThrows<TException>(Action action) where TException : Exception
        {
            try
            {
                action();
            }
            catch (TException e)
            {
                return e;
            }
            Assert.Fail("The method did not throw the expected exception");
            return null;
        }
    }
}
