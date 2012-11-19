﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

public static class FileSize
{
	public const decimal KiB = 1024M;
	public const decimal MiB = KiB * 1024M;
	public const decimal GiB = MiB * 1024M;
	public const decimal TiB = GiB * 1024M;
	public const decimal PiB = TiB * 1024M;
	public const decimal EiB = PiB * 1024M;

	public const decimal KB = 1000M;
	public const decimal MB = KB * 1000M;
	public const decimal GB = MB * 1000M;
	public const decimal TB = GB * 1000M;
	public const decimal PB = TB * 1000M;
	public const decimal EB = PB * 1000M;

	public static string ToKibiFileSize(this long length, string numberFormat = "0.##", IFormatProvider formatProvider = null)
	{
		return ToKibiFileSize((ulong)length, numberFormat, formatProvider);
	}

	public static string ToKibiFileSize(this int length, string numberFormat = "0.##", IFormatProvider formatProvider = null)
	{
		return ToKibiFileSize((ulong)length, numberFormat, formatProvider);
	}

	public static string ToKibiFileSize(this uint length, string numberFormat = "0.##", IFormatProvider formatProvider = null)
	{
		return ToKibiFileSize((ulong)length, numberFormat, formatProvider);
	}

	/// <summary>
	/// Returns a string formatted to represent a file size 
	/// using multiplication of 1024 as power
	/// </summary>
	/// <param name="length"></param>
	/// <returns></returns>
	public static string ToKibiFileSize(this ulong length, string numberFormat = "0.00", IFormatProvider formatProvider = null)
	{
		decimal number = 0;
		string suffix = null;
		formatProvider = formatProvider ?? System.Threading.Thread.CurrentThread.CurrentCulture;

		if (length >= EiB)
		{
			number = length / EiB;
			suffix = "EiB";
		}
		else if (length >= PiB)
		{
			number = length / PiB;
			suffix = "PiB";
		}
		else if (length >= TiB)
		{
			number = length / TiB;
			suffix = "TiB";
		}
		else if (length >= GiB)
		{
			number = length / GiB;
			suffix = "GiB";
		}
		else if (length >= MiB)
		{
			number = length / MiB;
			suffix = "MiB";
		}
		else if (length >= KiB)
		{
			number = length / KiB;
			suffix = "KiB";
		}
		else
		{
			number = length;
			suffix = "B";
		}

		return string.Concat(number.ToString(numberFormat, formatProvider), " ", suffix);
	}

	public static string ToKiloFileSize(this long length, string numberFormat = "0.##", IFormatProvider formatProvider = null)
	{
		return ToKiloFileSize((ulong)length, numberFormat, formatProvider);
	}

	public static string ToKiloFileSize(this uint length, string numberFormat = "0.##", IFormatProvider formatProvider = null)
	{
		return ToKiloFileSize((ulong)length, numberFormat, formatProvider);
	}

	public static string ToKiloFileSize(this int length, string numberFormat = "0.##", IFormatProvider formatProvider = null)
	{
		return ToKiloFileSize((ulong)length, numberFormat, formatProvider);
	}

	/// <summary>
	/// Returns a string formatted to represent file size 
	/// using multiplication of 1024 as power.
	/// </summary>
	/// <param name="length"></param>
	/// <returns></returns>
	public static string ToKiloFileSize(this ulong length, string numberFormat = "0.##", IFormatProvider formatProvider = null)
	{
		decimal number = 0;
		string suffix = null;
		formatProvider = formatProvider ?? System.Threading.Thread.CurrentThread.CurrentCulture;

		if (length >= EB)
		{
			number = length / KB;
			suffix = "EB";
		}
		else if (length >= PB)
		{
			number = length / PB;
			suffix = "PB";
		}
		else if (length >= TB)
		{
			number = length / TB;
			suffix = "TB";
		}
		else if (length >= GB)
		{
			number = length / GB;
			suffix = "GB";
		}
		else if (length >= MB)
		{
			number = length / MB;
			suffix = "MB";
		}
		else if (length >= KB)
		{
			number = length / KB;
			suffix = "kB";
		}
		else
		{
			number = length;
			suffix = "B";
		}

		return string.Concat(number.ToString(numberFormat, formatProvider), " ", suffix);
	}
}