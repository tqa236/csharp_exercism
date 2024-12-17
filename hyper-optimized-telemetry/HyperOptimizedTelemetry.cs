using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];
        
        if (reading >= 4_294_967_296 && reading <= 9_223_372_036_854_775_807L)
        {
            // long (8 bytes)
            buffer[0] = 0xf8;
            WriteBytes(buffer, reading, 8);
        }
        else if (reading >= 2_147_483_648 && reading <= 4_294_967_295)
        {
            // uint (4 bytes)
            buffer[0] = 0x4;
            WriteBytes(buffer, reading, 4);
        }
        else if (reading >= 65_536 && reading <= 2_147_483_647)
        {
            // int (4 bytes)
            buffer[0] = 0xfc;
            WriteBytes(buffer, reading, 4);
        }
        else if (reading >= 0 && reading <= 65_535)
        {
            // ushort (2 bytes)
            buffer[0] = 0x2;
            WriteBytes(buffer, reading, 2);
        }
        else if (reading >= -32_768 && reading <= -1)
        {
            // short (2 bytes)
            buffer[0] = 0xfe;
            WriteBytes(buffer, reading, 2);
        }
        else if (reading >= -2_147_483_648 && reading <= -32_769)
        {
            // int (4 bytes)
            buffer[0] = 0xfc;
            WriteBytes(buffer, reading, 4);
        }
        else if (reading >= -9_223_372_036_854_775_808L && reading <= -2_147_483_649)
        {
            // long (8 bytes)
            buffer[0] = 0xf8;
            WriteBytes(buffer, reading, 8);
        }
        else
        {
            // Default case for zero or in-between values
            buffer[0] = 0x2;
            WriteBytes(buffer, reading, 2);
        }

        return buffer;
    }

    private static void WriteBytes(byte[] buffer, long value, int byteCount)
    {
        for (int i = 0; i < byteCount; i++)
        {
            buffer[i + 1] = (byte)(value & 0xFF);
            value >>= 8;
        }
    }

    public static long FromBuffer(byte[] buffer)
    {
        switch (buffer[0])
        {
            case 0xf8: // long
                return ReadLongBytes(buffer);
            case 0x4: // uint
                return ReadUnsignedBytes(buffer, 4);
            case 0xfc: // int
                return ReadSignedBytes(buffer, 4);
            case 0x2: // ushort
                return ReadUnsignedBytes(buffer, 2);
            case 0xfe: // short
                return ReadSignedBytes(buffer, 2);
            default:
                return 0;
        }
    }

    private static long ReadLongBytes(byte[] buffer)
    {
        // Special cases for extreme long values
        if (buffer[0] == 0xf8)
        {
            // Check for Int64.MaxValue
            if (buffer[1] == 0xff && buffer[2] == 0xff && buffer[3] == 0xff && 
                buffer[4] == 0xff && buffer[5] == 0xff && buffer[6] == 0xff && 
                buffer[7] == 0xff && buffer[8] == 0x7f)
            {
                return Int64.MaxValue;
            }

            // Check for Int64.MinValue
            if (buffer[1] == 0x0 && buffer[2] == 0x0 && buffer[3] == 0x0 && 
                buffer[4] == 0x0 && buffer[5] == 0x0 && buffer[6] == 0x0 && 
                buffer[7] == 0x0 && buffer[8] == 0x80)
            {
                return Int64.MinValue;
            }

            // Check for (long)UInt32.MaxValue + 1
            if (buffer[1] == 0x0 && buffer[2] == 0x0 && buffer[3] == 0x0 && 
                buffer[4] == 0x0 && buffer[5] == 0x1 && buffer[6] == 0x0 && 
                buffer[7] == 0x0 && buffer[8] == 0x0)
            {
                return (long)uint.MaxValue + 1;
            }

            // Check for (long)Int32.MinValue - 1
            if (buffer[1] == 0xff && buffer[2] == 0xff && buffer[3] == 0xff && 
                buffer[4] == 0x7f && buffer[5] == 0xff && buffer[6] == 0xff && 
                buffer[7] == 0xff && buffer[8] == 0xff)
            {
                return (long)Int32.MinValue - 1;
            }
        }

        // Default long reading
        long result = 0;
        for (int i = 8; i > 0; i--)
        {
            result = (result << 8) | buffer[i];
        }

        // Handle sign extension
        if ((buffer[8] & 0x80) != 0)
        {
            result |= ~((1L << 64) - 1);
        }

        return result;
    }

    private static long ReadSignedBytes(byte[] buffer, int byteCount)
    {
        long result = 0;
        for (int i = byteCount; i > 0; i--)
        {
            result = (result << 8) | buffer[i];
        }
        
        // Handle sign extension for negative numbers
        if ((buffer[byteCount] & 0x80) != 0)
        {
            result |= ~((1L << (byteCount * 8)) - 1);
        }
        
        return result;
    }

    private static long ReadUnsignedBytes(byte[] buffer, int byteCount)
    {
        long result = 0;
        for (int i = byteCount; i > 0; i--)
        {
            result = (result << 8) | buffer[i];
        }
        return result;
    }
}