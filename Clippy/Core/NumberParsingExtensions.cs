using System;

namespace Clippy.Core
{
    public static class NumberParsingExtensions
    {
        public static int ParseInt(this string text, int fallBack = 0)
        {
            int num;

            if (int.TryParse(text, out num))
                return num;
            else
                return fallBack;
        }
        public static int? ParseIntNullable(this string text)
        {
            int num;

            if (int.TryParse(text, out num))
                return num;
            else
                return null;
        }

        public static uint ParseUInt(this string text, uint fallBack = 0)
        {
            uint num;

            if (uint.TryParse(text, out num))
                return num;
            else
                return fallBack;
        }
        public static uint? ParseUIntNullable(this string text)
        {
            uint num;

            if (uint.TryParse(text, out num))
                return num;
            else
                return null;
        }

        public static long ParseLong(this string text, long fallBack = 0)
        {
            long num;

            if (long.TryParse(text, out num))
                return num;
            else
                return fallBack;
        }
        public static long? ParseLongNullable(this string text)
        {
            long num;

            if (long.TryParse(text, out num))
                return num;
            else
                return null;
        }

        public static ulong ParseULong(this string text, ulong fallBack = 0)
        {
            ulong num;

            if (ulong.TryParse(text, out num))
                return num;
            else
                return fallBack;
        }
        public static ulong? ParseULongNullable(this string text)
        {
            ulong num;

            if (ulong.TryParse(text, out num))
                return num;
            else
                return null;
        }
    }
}
