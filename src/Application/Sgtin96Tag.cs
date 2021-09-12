using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application
{
    public class Sgtin96Tag
    {
        public const byte Header = 0x30;
        private readonly byte _filter;
        private readonly byte _partition;
        private readonly string _companyPrefix;
        private readonly string _itemReference;
        private readonly string _serialNumber;

        public Sgtin96Tag(byte filter, byte partition, string companyPrefix, string itemReference, string serialNumber)
        {
            _filter = filter;
            _partition = partition;
            _companyPrefix = companyPrefix;
            _itemReference = itemReference;
            _serialNumber = serialNumber;
        }

        public byte Filter => _filter;

        public byte Partition => _partition;

        public string CompanyPrefix => _companyPrefix;

        public string ItemReference => _itemReference;

        public string SerialNumber => _serialNumber;

        public string TagUri => $"urn:epc:tag:sgtin-96:{_filter}.{_companyPrefix}.{_itemReference}.{_serialNumber}";
        public override string ToString()
        {
            return TagUri;
        }
    }
}
