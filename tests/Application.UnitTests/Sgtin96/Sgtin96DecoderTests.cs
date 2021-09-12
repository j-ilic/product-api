using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Products.Application.UnitTests.Sgtin96
{
    public class Sgtin96DecoderTests
    {
        [Fact]
        public void ShouldDecodeBits()
        {
            // ARRANGE
            string hexTag = "3074257BF7194E4000001A85";
            BitArray expectedBits = new BitArray(new bool[] { false, false, true, true, false, false, false, false, false, true, true, true, false, true, false, false, false, false, true, false, false, true, false, true, false, true, true, true, true, false, true, true, true, true, true, true, false, true, true, true, false, false, false, true, true, false, false, true, false, true, false, false, true, true, true, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, true, false, true, false, false, false, false, true, false, true });

            // ACT
            BitArray bits = Sgtin96Decoder.GetSgtin96Bits(hexTag);

            // ASSERT
            bits.Should().BeEquivalentTo(expectedBits);
        }

        [Theory]
        [InlineData("3074257BF7194E4000001A85", "urn:epc:tag:sgtin-96:3.0614141.812345.6789")]
        [InlineData("3078DDCA56A475C036F6E733", "urn:epc:tag:sgtin-96:3.227113.5935575.922150707")]
        [InlineData("301B6F989F55264033DA97A7", "urn:epc:tag:sgtin-96:0.900706.8213657.869963687")]
        [InlineData("307512A5BD5755000595A921", "urn:epc:tag:sgtin-96:3.4499823.351572.93694241")]
        [InlineData("30B8438104C7E1001F99A55C", "urn:epc:tag:sgtin-96:5.069124.1253252.530163036")]
        [InlineData("3089F44C3CE12CC02B4F39BB", "urn:epc:tag:sgtin-96:4.8393604321.179.726612411")]
        [InlineData("30753034E770B50025CCBC10", "urn:epc:tag:sgtin-96:3.4984121.901844.634174480")]
        [InlineData("3050FE2B9F345CC02DAC19D5", "urn:epc:tag:sgtin-96:2.33314622.53619.766253525")]
        [InlineData("307854DE857BE8C005F89270", "urn:epc:tag:sgtin-96:3.086906.1437603.100176496")]
        [InlineData("3059720AA0199C402BA7DFA0", "urn:epc:tag:sgtin-96:2.378922.8414833.732422048")]
        [InlineData("307A3DAEC41952801931E4F1", "urn:epc:tag:sgtin-96:3.587451.1074506.422700273")]
        [InlineData("307ADD515CB7900036781FE7", "urn:epc:tag:sgtin-96:3.750917.7528000.913842151")]
        [InlineData("30DADD515CB7900020ABD45B", "urn:epc:tag:sgtin-96:6.750917.7528000.548131931")]
        [InlineData("3016431BEC9057401A032133", "urn:epc:tag:sgtin-96:0.9488123.147805.436412723")]
        [InlineData("3014AF44388DD000303F83C6", "urn:epc:tag:sgtin-96:0.2871566.145216.809468870")]
        [InlineData("3074AF44388DD0000071F088", "urn:epc:tag:sgtin-96:3.2871566.145216.7467144")]
        [InlineData("307A03D45DB95380233600DB", "urn:epc:tag:sgtin-96:3.528209.7791950.590741723")]
        [InlineData("30B18641574C7EC010414E91", "urn:epc:tag:sgtin-96:5.51151534.78331.272715409")]
        [InlineData("301A96768FDAA7002DD5F005", "urn:epc:tag:sgtin-96:0.678362.4156060.768995333")]
        [InlineData("3070DA337B28EE001259172A", "urn:epc:tag:sgtin-96:3.28600054.41912.307828522")]
        public void ShouldDecodeSgtin96TagDataFromHexString(string hexTag, string expectedTagUri)
        {
            // ARRANGE

            //ACT
            Sgtin96Tag sgtin96TagData = Sgtin96Decoder.DecodeFromSgtin96HexString(hexTag);

            //ASSERT
            sgtin96TagData.TagUri.Should().Be(expectedTagUri);
        }
    }
}
