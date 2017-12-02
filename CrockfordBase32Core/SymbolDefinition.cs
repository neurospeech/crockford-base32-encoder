using System;
using System.Collections.Generic;
using System.Text;

namespace CrockfordBase32
{
    internal class SymbolDefinition
    {
        public int Value { get; set; }
        public IEnumerable<char> DecodeSymbols { get; set; }
        public char EncodeSymbol { get; set; }
    }
}
