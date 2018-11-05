using System;
using System.Collections.Generic;
using System.Linq;

namespace Cryptography.StreamCipher
{
    public class MultiTimePad
    {
        private readonly List<byte[]> _ciphers;
        private readonly int _length;

        public MultiTimePad(params byte[][] ciphers)
        {
            _length = ciphers.Length;
            _ciphers = new List<byte[]>(ciphers);

            for (var i = 0; i < _length - 1; i++)
            for (var j = i + 1; j < _length; j++)
            {
                _ciphers.Add(ciphers[i].Select((m, n) => (byte)(m ^ ciphers[j][n])).ToArray());
            }
        }

        public byte[] Decipher(int index)
        {
            var key = ExtractKey();
            return _ciphers[index].Select((i,j) => (byte)(i ^ key[j])).ToArray();
        }

        public byte[] ExtractKey(bool useGrammar = false)
        {
            var key = new byte?[_ciphers.First().Length];

            for (var i = 0; i < key.Length; i++)
            {
                // cycle through possible values
                // https://crypto.stackexchange.com/questions/6020/how-to-attack-a-many-time-pad-based-on-what-happens-when-an-ascii-space-is-xor/6095#6095
                // and calc key

                var xorBytes = Enumerable.Range(0, _ciphers.Count).Select(j => _ciphers[j][i]);
                var c = xorBytes.Count(j => char.IsLetter((char)j));
            }

            if (useGrammar)
            {
                PerformGrammarCorrection(ref key);
            }

            return Array.ConvertAll(key, i => i ?? 0);
        }

        private void PerformGrammarCorrection(ref byte?[] key)
        {

        }
    }
}