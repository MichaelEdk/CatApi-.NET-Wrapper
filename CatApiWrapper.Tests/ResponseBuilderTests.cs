using System.Net.Http;
using CatApiWrapper.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatApiWrapper.Tests
{
    [TestClass]
    public class ResponseReaderTests
    {
        [TestMethod]
        public void WhenGetResponseIsReturned_Then_ItIsDeserialisedCorrectly()
        {
            // Arrange
            var httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent(ExampleXmlResponses.GetResponse)
            };

            // Act
            var response = CatClient.ReadResult<GetResponse.Response>(httpResponseMessage);
            var images = response.Data.Images;

            // Assert
            var urls = new[]
            {
                "http://24.media.tumblr.com/tumblr_m0mkozpcIf1r6b7kmo1_500.jpg",
                "http://24.media.tumblr.com/tumblr_lvlidr8oHo1qzkl9go1_1280.jpg"
            };

            var ids = new[]
            {
                "78b",
                "d2h"
            };

            var sourceUrls = new[]
            {
                "http://thecatapi.com/?id=78b",
                "http://thecatapi.com/?id=d2h"
            };


            Assert.AreEqual(2, images.Length);

            for (var imageIndex = 0; imageIndex < 2; imageIndex++)
            {
                Assert.AreEqual(urls[imageIndex], images[imageIndex].Url);
                Assert.AreEqual(ids[imageIndex], images[imageIndex].Id);
                Assert.AreEqual(sourceUrls[imageIndex], images[imageIndex].SourceUrl);
            }

        }

        [TestMethod]
        public void WhenVoteResponseIsReturned_Then_ItIsDeserialisedCorrectly()
        {
            // Arrange
            var httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent(ExampleXmlResponses.VoteResponse)
            };

            // Act
            var response = CatClient.ReadResult<VoteResponse.Response>(httpResponseMessage);
            var votes = response.Data.Votes;
            var vote = votes[0];

            // Assert
            Assert.AreEqual(1, votes.Length);
            Assert.AreEqual("update", vote.Action);
            Assert.AreEqual("bC24", vote.ImageId);
            Assert.AreEqual(10, vote.Score);
            Assert.AreEqual("12345", vote.SubId);
        }

        [TestMethod]
        public void WhenGetVotesResponseIsReturned_Then_ItIsDeserialisedCorrectly()
        {
            // Arrange
            var httpResponseMessage = new HttpResponseMessage()
            {
                Content = new StringContent(ExampleXmlResponses.GetVotesResponse)
            };

            // Act
            var response = CatClient.ReadResult<GetVotesResponse.Response>(httpResponseMessage);
            var images = response.Data.Images;

            // Assert
            var subIds = new[]
            {
                "12345",
                "12346"
            };

            var created = new[]
            {
                "2017-05-27 08:23:11",
                "2017-05-27 08:23:18",
            };

            var scores = new[]
            {
                10,
                8
            };

            for (var imageIndex = 0; imageIndex < 2; imageIndex++)
            {
                var actualImage = images[imageIndex];
                Assert.AreEqual(subIds[imageIndex], actualImage.SubId);
                Assert.AreEqual(created[imageIndex], actualImage.Created);
                Assert.AreEqual(scores[imageIndex], images[imageIndex].Score);
            }
        }
    }
}
