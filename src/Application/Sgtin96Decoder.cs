using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application
{
    public static class Sgtin96Decoder
    {
        private static readonly int _filterStartBit = 8;
        private static readonly int FilterLength = 3;
        private static readonly int PartitionStartBit = _filterStartBit + FilterLength;
        private static readonly int PartitionLength = 3;
        private static readonly int SerialNumberLength = 38;
        private static readonly IDictionary<byte, PartitionTableEntry> _partitionTable = new Dictionary<byte, PartitionTableEntry>
        {
            {
                0,
                new PartitionTableEntry
                {
                    CompanyPrefixBits = 40,
                    CompanyPrefixDigits = 12,
                    ItemReferenceBits = 4,
                    ItemReferenceDigits = 1
                }
            },
            {
                1,
                new PartitionTableEntry
                {
                    CompanyPrefixBits = 37,
                    CompanyPrefixDigits = 11,
                    ItemReferenceBits = 7,
                    ItemReferenceDigits = 2
                }
            },
            {
                2,
                new PartitionTableEntry
                {
                    CompanyPrefixBits = 34,
                    CompanyPrefixDigits = 10,
                    ItemReferenceBits = 10,
                    ItemReferenceDigits = 3
                }
            },
            {
                3,
                new PartitionTableEntry
                {
                    CompanyPrefixBits = 30,
                    CompanyPrefixDigits = 9,
                    ItemReferenceBits = 14,
                    ItemReferenceDigits = 4
                }
            },
            {
                4,
                new PartitionTableEntry
                {
                    CompanyPrefixBits = 27,
                    CompanyPrefixDigits = 8,
                    ItemReferenceBits = 17,
                    ItemReferenceDigits = 5
                }
            },
            {
                5,
                new PartitionTableEntry
                {
                    CompanyPrefixBits = 24,
                    CompanyPrefixDigits = 7,
                    ItemReferenceBits = 20,
                    ItemReferenceDigits = 6
                }
            },
            {
                6,
                new PartitionTableEntry
                {
                    CompanyPrefixBits = 20,
                    CompanyPrefixDigits = 6,
                    ItemReferenceBits = 24,
                    ItemReferenceDigits = 7
                }
            }
        };

        public static BitArray GetSgtin96Bits(string sgtin96HexString)
        {
            if (!sgtin96HexString.IsValidSgtin96Format())
            {
                throw new ArgumentException("Input string must be in valid SGTIN-96 format");
            }

            byte[] sgtin96Bytes = Convert.FromHexString(sgtin96HexString);

            var bitArray = new BitArray(sgtin96Bytes);
            var sgtin96BitArray = new BitArray(bitArray.Count);
            for (int i = 0; i < bitArray.Length / 8; i++)
            {
                for (int j = 7; j >= 0; j--)
                {
                    // bit array holds values from least significant bit to the most significant
                    // so we need to reverse the bit order in each byte
                    // meaning that we need to reverse the bit order for every 8 bits at a time
                    // for the first byte it means that bit on index 7 becomese value at index 0 in the final array
                    sgtin96BitArray.Set(i * 8 + 7 - j, bitArray[i * 8 + j]);
                }
            }

            return sgtin96BitArray;
        }
        public static Sgtin96Tag DecodeFromSgtin96HexString(string tag)
        {
            if (!tag.IsValidSgtin96Format())
            {
                throw new ArgumentException("Input string must be in valid SGTIN-96 format");
            }

            BitArray sgtin96Bits = GetSgtin96Bits(tag);

            byte filter = (byte) DecodeUInt32(sgtin96Bits, _filterStartBit, FilterLength);

            byte partition = (byte) DecodeUInt32(sgtin96Bits, PartitionStartBit, PartitionLength);

            if (!_partitionTable.ContainsKey(partition) || _partitionTable[partition] == null)
            {
                throw new FormatException("Invalid value for partition part");
            }

            PartitionTableEntry partitionDefinition = _partitionTable[partition];

            ulong companyPrefixNumber = DecodeUInt64(sgtin96Bits, PartitionStartBit + PartitionLength, partitionDefinition.CompanyPrefixBits);
            uint itemReferenceNumber = DecodeUInt32(sgtin96Bits, PartitionStartBit + PartitionLength + partitionDefinition.CompanyPrefixBits, partitionDefinition.ItemReferenceBits);

            string companyPrefix = companyPrefixNumber.ToString().PadLeft(partitionDefinition.CompanyPrefixDigits, '0');
            string itemReference = itemReferenceNumber.ToString().PadLeft(partitionDefinition.ItemReferenceDigits, '0');

            string serialNumber = DecodeUInt64(sgtin96Bits, sgtin96Bits.Count - SerialNumberLength, SerialNumberLength).ToString();

            return new Sgtin96Tag(filter, partition, companyPrefix, itemReference, serialNumber);
        }

        private static uint DecodeUInt32(BitArray bits, int startBit, int bitCount)
        {
            if (bits == null)
            {
                throw new ArgumentNullException("Provided bit array can't be null");
            }

            if (startBit < 0 || startBit + bitCount > bits.Count)
            {
                throw new ArgumentOutOfRangeException($"{nameof(startBit)}", $"{nameof(startBit)} must be in [0..{bits.Count - bitCount}]");
            }

            uint result = 0u;
            for (int i = 0; i < bitCount; i++)
            {
                // starting bit is most significant bit so we need to start with last bit
                // the we use bitwise operator to set the value to 1 on correct place in the uint 32 bits
                // for this we use bitwise OR operator and left shit to shift the place of 1
                if (bits[startBit + bitCount - 1 - i])
                {
                    result |= (1u << i);
                }
            }

            return result;
        }

        private static ulong DecodeUInt64(BitArray bits, int startBit, int bitCount)
        {
            if (bits == null)
            {
                throw new ArgumentNullException("Provided bit array can't be null");
            }

            if (startBit < 0 || startBit + bitCount > bits.Count)
            {
                throw new ArgumentOutOfRangeException($"{nameof(startBit)}", $"{nameof(startBit)} must be in [0..{bits.Count - bitCount}]");
            }

            ulong result = 0ul;
            for (int i = 0; i < bitCount; i++)
            {
                // starting bit is most significant bit so we need to start with last bit
                // the we use bitwise operator to set the value to 1 on correct place in the uint 32 bits
                // for this we use bitwise OR operator and left shit to shift the place of 1
                if (bits[startBit + bitCount - 1 - i])
                {
                    result |= (1ul << i);
                }
            }

            return result;
        }

        private class PartitionTableEntry
        {
            public int CompanyPrefixBits { get; set; }
            public int CompanyPrefixDigits { get; set; }
            public int ItemReferenceBits { get; set; }
            public int ItemReferenceDigits { get; set; }
        }
    }
}
