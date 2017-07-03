using System;
using System.Linq;
using CatApi;
using Xunit;

namespace CatApiTests
{
    public class DeserializationTest
    {
        [Fact]
        public void ItIsPossibleToDeserializeAnApiResponse()
        {
            var xml =
            @"<response>
            <data>
                <images>
                    <image>
                        <url>http://24.media.tumblr.com/tumblr_ln7yf0YRIG1qdth8zo1_1280.jpg</url>
                        <id>cm3</id>
                        <source_url>http://thecatapi.com/?id=cm3</source_url>
                    </image>
                    <image>
                        <url>http://25.media.tumblr.com/tumblr_lj923hnKvt1qcn249o1_500.gif</url>
                        <id>7sg</id>
                        <source_url>http://thecatapi.com/?id=7sg</source_url>
                    </image>
                </images>
                </data>
            </response>";

            var response = CatApiClient.Deserialize<Response>(xml);
            Assert.Equal(2, response.Data.Images.Count);
            Assert.Equal("http://24.media.tumblr.com/tumblr_ln7yf0YRIG1qdth8zo1_1280.jpg", response.Data.Images.First().Url);
        }
    }
}
