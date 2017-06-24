
namespace CatApiWrapper.Tests
{
    internal static class ExampleXmlResponses
    {
        internal static string GetResponse =
            @"<?xml version='1.0'?>
                    <response>
                        <data>
                            <images>
                                <image>
                                    <url>http://24.media.tumblr.com/tumblr_m0mkozpcIf1r6b7kmo1_500.jpg</url>
                                    <id>78b</id>
                                    <source_url>http://thecatapi.com/?id=78b</source_url>
                                </image>
                                <image>
                                    <url>http://24.media.tumblr.com/tumblr_lvlidr8oHo1qzkl9go1_1280.jpg</url>
                                    <id>d2h</id>
                                    <source_url>http://thecatapi.com/?id=d2h</source_url>
                                </image>
                            </images>
                        </data>
                    </response>";

        internal static string VoteResponse =
            @"<?xml version=""1.0""?>
            <response>
                <data>
                    <votes>
                        <vote>
                            <score>10</score>
                            <image_id>bC24</image_id>
                            <sub_id>12345</sub_id>
                            <action>update</action>
                        </vote>
                    </votes>
                </data>
            </response>";

        internal static string GetVotesResponse =
            @"<?xml version=""1.0""?>
            <response>
                <data>
                    <images>
                        <image>
                            <sub_id>12345</sub_id>
                            <created>2017-05-27 08:23:11</created>
                            <score>10</score>
                        </image>
                        <image>
                            <sub_id>12346</sub_id>
                            <created>2017-05-27 08:23:18</created>
                            <score>8</score>
                        </image>
                    </images>
                </data>
            </response>";
    }
}
