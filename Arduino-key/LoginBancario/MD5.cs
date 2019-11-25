/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginBancario
{
    class MD5
    {
        private static uint INIT_A = (uint)0x67452301;
        private static uint INIT_B = (uint)0xEFCDAB89L;
        private static uint INIT_C = (uint)0x98BADCFEL;
        private static uint INIT_D = (uint)0x10325476;
        private static int[] SHIFT_AMTS = { 7, 12, 17, 22, 5, 9, 14, 20, 4,
            11, 16, 23, 6, 10, 15, 21    };
        private static int[] TABLE_T = new int[64];

        public void InicializarMD5()
        {
            for (int i = 0; i < 64; i++)
                TABLE_T[i] = (int)(long)((1L << 32) * Math.Abs(Math.Sin(i + 1)));
        }

        public static byte[] computeMD5(byte[] message)
        {
            int messageLenBytes = message.Length;
            int numBlocks = ((messageLenBytes + 8) >> 6) + 1; //Aquí quité un >
            int totalLen = numBlocks << 6;
            byte[] paddingBytes = new byte[totalLen - messageLenBytes];
            paddingBytes[0] = (byte)0x80;
            long messageLenBits = (long)messageLenBytes << 3;
            for (int i = 0; i < 8; i++)
            {
                paddingBytes[paddingBytes.Length - 8 + i] = (byte)messageLenBits;
                messageLenBits >>>= 8;
            }
            uint a = INIT_A;
            uint b = INIT_B;
            uint c = INIT_C;
            uint d = INIT_D;
            int[] buffer = new int[16];
            for (int i = 0; i < numBlocks; i++)
            {
                int index = i << 6;
                for (int j = 0; j < 64; j++, index++)
                    buffer[j >> 2] = ((int)((index < messageLenBytes) ? message[index]
                            : paddingBytes[index - messageLenBytes]) << 24)
                            | (buffer[j >> 2] >> 8);
                uint originalA = a;
                uint originalB = b;
                uint originalC = c;
                uint originalD = d;
                for (int j = 0; j < 64; j++)
                {
                    int div16 = j >> 4;
                    uint f = 0;
                    int bufferIndex = j;
                    switch (div16)
                    {
                        case 0:
                            f = (b & c) | (~b & d);
                            break;
                        case 1:
                            f = (b & d) | (c & ~d);
                            bufferIndex = (bufferIndex * 5 + 1) & 0x0F;
                            break;
                        case 2:
                            f = b ^ c ^ d;
                            bufferIndex = (bufferIndex * 3 + 5) & 0x0F;
                            break;
                        case 3:
                            f = c ^ (b | ~d);
                            bufferIndex = (bufferIndex * 7) & 0x0F;
                            break;
                    }
                    int temp = b
                            + Integer.rotateLeft(a + f + buffer[bufferIndex]
                                    + TABLE_T[j],
                                    SHIFT_AMTS[(div16 << 2) | (j & 3)]);
                    a = d;
                    d = c;
                    c = b;
                    b = temp;
                }
                a += originalA;
                b += originalB;
                c += originalC;
                d += originalD;
            }
            byte[] md5 = new byte[16];
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                int n = (i == 0) ? a : ((i == 1) ? b : ((i == 2) ? c : d));
                for (int j = 0; j < 4; j++)
                {
                    md5[count++] = (byte)n;
                    n >>>= 8;
                }
            }
            return md5;
        }

        public static String toHexString(byte[] b)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < b.length; i++)
            {
                sb.append(String.format("%02X", b[i] & 0xFF));
            }
            return sb.toString();
        }

        public static void main(String[] args)
        {
            String s = "alexis";
            System.out.println("0x" + ))
                    + " <== \"" + s + "\"");
        }
    }
}
*/