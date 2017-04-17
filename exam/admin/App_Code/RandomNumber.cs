using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

/// <summary>
/// RandomNumber 的摘要说明
/// </summary>
public sealed class RandomNumber
{
    private static RNGCryptoServiceProvider _Random = new RNGCryptoServiceProvider();
    private static byte[] bytes = new byte[4];

    private RandomNumber() { }

    public static int Next(int max)
    {
        if (max <= 0)
        {
            throw new ArgumentOutOfRangeException("max");
        }
        _Random.GetBytes(bytes);
        int value = BitConverter.ToInt32(bytes, 0) % max;
        if (value < 0)
        {
            value = -value;
        }
        return value;
    }
}