using System;
using System.Collections.Generic;
using System.Linq;

namespace Cryptography.StreamCipher
{
    public class MultiTimePad
    {
        private readonly List<byte[]> ciphers = new List<byte[]>();
        private readonly int records;
        private readonly int streams;

        public MultiTimePad(params byte[][] data)
        {
            records = data[0].Length;
            streams = data.Length;

            for (var i = 0; i < data[0].Length; i++)
                ciphers.Add(data.Select(j => j[i]).ToArray());            
        }

        public byte[] Decipher(int index)
        {
            var ksp = KeySolutionSpace();
            var vsp = ValueSolutionSpace(ksp);
            var key = SemanticAnalysis(vsp);

            return ciphers[index].Select((i,j) => (byte)(i ^ key[0][j])).ToArray();
        }

        private byte[][] KeySolutionSpace()
            => ciphers.Select(i => Enumerable.Range(0, byte.MaxValue)
                                                .Where(j => i.All(k => IsPrintableCharacter(j ^ k)))
                                                .Select(j => (byte)j)
                                                .ToArray()).ToArray();

        private char[][][] ValueSolutionSpace(byte[][] ksp)
            => ksp.Select((i, j) => i.Select(k => ciphers[j].Select(l => (char)(k ^ l))
                                     .ToArray()).ToArray()).ToArray();

        private static byte[][] SemanticAnalysis(char[][][] vsp)
        {
            // 38 is 1st correct value
            return null;
        }

        private static bool IsPrintableCharacter(int code)
            => 32 <= code && code < 127;
    }
}