
using System;
using System.Linq;
using Cryptography.StreamCipher;

namespace Cryptography
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Week1();
        }

        private static void Week1(int target = 10)
        {
            var mtp = new MultiTimePad(
                "315c4eeaa8b5f8aaf9174145bf43e1784b8fa00dc71d885a804e5ee9fa40b16349c146fb778cdf2d3aff021dfff5b403b510d0d0455468aeb98622b137dae857553ccd8883a7bc37520e06e515d22c954eba50".ToBytes(),
                "234c02ecbbfbafa3ed18510abd11fa724fcda2018a1a8342cf064bbde548b12b07df44ba7191d9606ef4081ffde5ad46a5069d9f7f543bedb9c861bf29c7e205132eda9382b0bc2c5c4b45f919cf3a9f1cb741".ToBytes(),
                "32510ba9a7b2bba9b8005d43a304b5714cc0bb0c8a34884dd91304b8ad40b62b07df44ba6e9d8a2368e51d04e0e7b207b70b9b8261112bacb6c866a232dfe257527dc29398f5f3251a0d47e503c66e935de812".ToBytes(),
                "32510ba9aab2a8a4fd06414fb517b5605cc0aa0dc91a8908c2064ba8ad5ea06a029056f47a8ad3306ef5021eafe1ac01a81197847a5c68a1b78769a37bc8f4575432c198ccb4ef63590256e305cd3a9544ee41".ToBytes(),
                "3f561ba9adb4b6ebec54424ba317b564418fac0dd35f8c08d31a1fe9e24fe56808c213f17c81d9607cee021dafe1e001b21ade877a5e68bea88d61b93ac5ee0d562e8e9582f5ef375f0a4ae20ed86e935de812".ToBytes(),
                "32510bfbacfbb9befd54415da243e1695ecabd58c519cd4bd2061bbde24eb76a19d84aba34d8de287be84d07e7e9a30ee714979c7e1123a8bd9822a33ecaf512472e8e8f8db3f9635c1949e640c621854eba0d".ToBytes(),
                "32510bfbacfbb9befd54415da243e1695ecabd58c519cd4bd90f1fa6ea5ba47b01c909ba7696cf606ef40c04afe1ac0aa8148dd066592ded9f8774b529c7ea125d298e8883f5e9305f4b44f915cb2bd05af513".ToBytes(),
                "315c4eeaa8b5f8bffd11155ea506b56041c6a00c8a08854dd21a4bbde54ce56801d943ba708b8a3574f40c00fff9e00fa1439fd0654327a3bfc860b92f89ee04132ecb9298f5fd2d5e4b45e40ecc3b9d59e941".ToBytes(),
                "271946f9bbb2aeadec111841a81abc300ecaa01bd8069d5cc91005e9fe4aad6e04d513e96d99de2569bc5e50eeeca709b50a8a987f4264edb6896fb537d0a716132ddc938fb0f836480e06ed0fcd6e9759f404".ToBytes(),
                "466d06ece998b7a2fb1d464fed2ced7641ddaa3cc31c9941cf110abbf409ed39598005b3399ccfafb61d0315fca0a314be138a9f32503bedac8067f03adbf3575c3b8edc9ba7f537530541ab0f9f3cd04ff50d".ToBytes(),
                "32510ba9babebbbefd001547a810e67149caee11d945cd7fc81a05e9f85aac650e9052ba6a8cd8257bf14d13e6f0a803b54fde9e77472dbff89d71b57bddef121336cb85ccb8f3315f4b52e301d16e9f52f904".ToBytes());

            var message = string.Join("", mtp.Decipher(target).Select(i => (char)i));
            // The secret message is: When using a stream cipher, never use the key more than once
        }

        public static byte[] ToBytes(this string hex)
        {
            var bytes = new byte[hex.Length / 2];
            for (var i = 0; i < hex.Length; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}

/*
            var cipherTexts = new Dictionary<string, byte[]>
            {
                ["0^k"] = "315c4eeaa8b5f8aaf9174145bf43e1784b8fa00dc71d885a804e5ee9fa40b16349c146fb778cdf2d3aff021dfff5b403b510d0d0455468aeb98622b137dae857553ccd8883a7bc37520e06e515d22c954eba50".ToBytes(),
                ["1^k"] = "234c02ecbbfbafa3ed18510abd11fa724fcda2018a1a8342cf064bbde548b12b07df44ba7191d9606ef4081ffde5ad46a5069d9f7f543bedb9c861bf29c7e205132eda9382b0bc2c5c4b45f919cf3a9f1cb741".ToBytes(),
                ["2^k"] = "32510ba9a7b2bba9b8005d43a304b5714cc0bb0c8a34884dd91304b8ad40b62b07df44ba6e9d8a2368e51d04e0e7b207b70b9b8261112bacb6c866a232dfe257527dc29398f5f3251a0d47e503c66e935de812".ToBytes(),
                ["3^k"] = "32510ba9aab2a8a4fd06414fb517b5605cc0aa0dc91a8908c2064ba8ad5ea06a029056f47a8ad3306ef5021eafe1ac01a81197847a5c68a1b78769a37bc8f4575432c198ccb4ef63590256e305cd3a9544ee41".ToBytes(),
                ["4^k"] = "3f561ba9adb4b6ebec54424ba317b564418fac0dd35f8c08d31a1fe9e24fe56808c213f17c81d9607cee021dafe1e001b21ade877a5e68bea88d61b93ac5ee0d562e8e9582f5ef375f0a4ae20ed86e935de812".ToBytes(),
                ["5^k"] = "32510bfbacfbb9befd54415da243e1695ecabd58c519cd4bd2061bbde24eb76a19d84aba34d8de287be84d07e7e9a30ee714979c7e1123a8bd9822a33ecaf512472e8e8f8db3f9635c1949e640c621854eba0d".ToBytes(),
                ["6^k"] = "32510bfbacfbb9befd54415da243e1695ecabd58c519cd4bd90f1fa6ea5ba47b01c909ba7696cf606ef40c04afe1ac0aa8148dd066592ded9f8774b529c7ea125d298e8883f5e9305f4b44f915cb2bd05af513".ToBytes(),
                ["7^k"] = "315c4eeaa8b5f8bffd11155ea506b56041c6a00c8a08854dd21a4bbde54ce56801d943ba708b8a3574f40c00fff9e00fa1439fd0654327a3bfc860b92f89ee04132ecb9298f5fd2d5e4b45e40ecc3b9d59e941".ToBytes(),
                ["8^k"] = "271946f9bbb2aeadec111841a81abc300ecaa01bd8069d5cc91005e9fe4aad6e04d513e96d99de2569bc5e50eeeca709b50a8a987f4264edb6896fb537d0a716132ddc938fb0f836480e06ed0fcd6e9759f404".ToBytes(),
                ["9^k"] = "466d06ece998b7a2fb1d464fed2ced7641ddaa3cc31c9941cf110abbf409ed39598005b3399ccfafb61d0315fca0a314be138a9f32503bedac8067f03adbf3575c3b8edc9ba7f537530541ab0f9f3cd04ff50d".ToBytes(),
                ["a^k"] = "32510ba9babebbbefd001547a810e67149caee11d945cd7fc81a05e9f85aac650e9052ba6a8cd8257bf14d13e6f0a803b54fde9e77472dbff89d71b57bddef121336cb85ccb8f3315f4b52e301d16e9f52f904".ToBytes(),
            };

            for (var i = 0; i < ciphers.Length - 1; i++)
            {
                for (var j = i + 1; j < ciphers.Length; j++)
                {
                    cipherTexts[$"{i.ToString("X")}^{j.ToString("X")}"] = ciphers[i].Select((m, n) => (byte)(ciphers[i][n] ^ ciphers[j][n])).ToArray();
                }
            }

            var key = new byte?[ciphers[target].Length];
            while (key.Any(i => i == null))
            {
                // find spaces

                // Use discovered keys to uncover more values

                // Apply to target message


                for (var i = 0; i < key.Length; i++)
                {
                    var xorBytes = Enumerable.Range(0, ciphers.Length)
                                             .Where(j => j != target)
                                             .Select(j => ciphers[j][i]);

                    var c = xorBytes.Count(j => char.IsLetter((char)j));
                    if (c > 4)
                    {
                        key[i] = (byte)c; // space;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", key.Select((i, j) => (ciphers[target][j] ^ i.Value).ToString("X2"))));

            // The secret message is: When using a stream cipher, never use the key more than once
        }
    }
}

            /*
            for (var i = 0; i < ciphers.Length; i++)
            {
                if (i == target)
                    continue;

                for (var j = 0; j < ciphers[i].Length; j++)
                    ciphers[i][j] ^= ciphers[target][j];
            }

        }

    }
}
*/
//var kps = ciphers[target].Select((i,j) => Enumerable.Range(min, max - min)
//                                               .Where(k => ciphers.Select(l => l[j] ^ k)
//                                                                  .All(m => m >= min && m < max))
//                                               .Select(k => char.ConvertFromUtf32(k))
//                                               .ToArray()).ToArray();

//var key = new byte[length];
//var msg = new byte[length];
//var kps = Enumerable.Range(0, length)
//                    .Select((i, j) => Enumerable.Range(0, byte.MaxValue)
//                                                .Where(k => ciphers.Select(l => l[j] ^ k)
//                                                                      .All(m => m > min && m < max)).ToArray()).ToArray();
//// scan each byte in cipher text
//for (var i = 0; i < length; i++)
//{
//    // find the spaces

//    // XOR different combinations

//    // if the original byte matches the result
//    if ()
//    {
//        msg[i] = ;
//    }

//    // get initial possible key values
//    var possibleValues = Enumerable.Range(0, byte.MaxValue)
//                                   .Where(j => ciphers.Select(k => k[i] ^ j)
//                                                         .All(k => k >= min && k <= max));

//    // for each bit
//    for (var j = 0; j < sizeof(byte); j++)
//    {
//        // count the 1s
//        var count = ciphers.Select(m => m[i] & (1 << j))
//                              .Where(n => n > 0)
//                              .Count();

//        // if good chance bit is set
//        if (count > ciphers.Length / 2)
//        {
//            key[i] |= (byte) (1 << j);
//        }
//    }
//}

//var message = ciphers[10].Select((i,j) => (char)(i ^ key[j]));
//Console.WriteLine($"{message}");