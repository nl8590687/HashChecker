using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;
using System.Data.HashFunction;

namespace HashChecker
{
    /// <summary>
    /// There are some kinds of hash algorithm in this class likes MD5, SHA1, SHA256, SHA384, SHA512, CRC32, CRC64. 
    /// 此类提供MD5，SHA1，SHA256，SHA384，SHA512，CRC32，CRC64等几种数据摘要算法。
    /// </summary>
    public static class HashFunction
    {
        /// <summary>
        /// Caculate string's MD5 value. 计算字符串的MD5值。
        /// </summary>
        /// <param name="strIN">input string. 输入的字符串。</param>
        /// <returns>Return MD5 value. 返回MD5值。</returns>
        public static string md5(string strIN)
        {
            return md5(System.Text.Encoding.Default.GetBytes(strIN));
        }
        /// <summary>
        /// Caculate string's MD5 value. 计算字符串的MD5值。
        /// </summary>
        /// <param name="btIN">input Byte Array. 输入的字节数组。</param>
        /// <returns>Return MD5 value. 返回MD5值。</returns>
        public static string md5(Byte[] btIN)
        {
            System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytResult = md5.ComputeHash(btIN);
            md5.Clear();
            string strResult = BitConverter.ToString(bytResult);
            strResult = strResult.Replace("-", "");
            return strResult;
        }

        /// <summary>
        /// Caculate string's SHA1 value. 计算字符串的SHA1值。
        /// </summary>
        /// <param name="strIN">input string. 输入的字符串。</param>
        /// <returns>Return SHA1 value. 返回SHA1值。</returns>
        public static string sha1(string strIN)
        {
            return sha1(System.Text.Encoding.Default.GetBytes(strIN));
        }
        /// <summary>
        /// Caculate string's SHA1 value. 计算字符串的SHA1值。
        /// </summary>
        /// <param name="btIN">input Byte Array. 输入的字节数组。</param>
        /// <returns>Return SHA1 value. 返回SHA1值。</returns>
        public static string sha1(byte[] btIN)
        {
            byte[] tmpByte;
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            tmpByte = sha1.ComputeHash(btIN);
            sha1.Clear();
            string strResult = BitConverter.ToString(tmpByte);
            strResult = strResult.Replace("-", "");
            return strResult;
        }

        /// <summary>
        /// Caculate string's SHA256 value. 计算字符串的SHA256值。
        /// </summary>
        /// <param name="strIN">input string. 输入的字符串。</param>
        /// <returns>Return SHA256 value. 返回SHA256值。</returns>
        public static string sha256(string strIN)
        {
            return sha256(System.Text.Encoding.Default.GetBytes(strIN));
        }
        /// <summary>
        /// Caculate string's SHA256 value. 计算字符串的SHA256值。
        /// </summary>
        /// <param name="btIN">input Byte Array. 输入的字节数组。</param>
        /// <returns>Return SHA256 value. 返回SHA256值。</returns>
        public static string sha256(byte[] btIN)
        {
            byte[] tmpByte;
            SHA256 sha256 = new SHA256Managed();
            tmpByte = sha256.ComputeHash(btIN);
            sha256.Clear();
            string strResult = BitConverter.ToString(tmpByte);
            strResult = strResult.Replace("-", "");
            return strResult;
        }

        /// <summary>
        /// Caculate string's SHA384 value. 计算字符串的SHA384值。
        /// </summary>
        /// <param name="strIN">input string. 输入的字符串。</param>
        /// <returns>Return SHA384 value. 返回SHA384值。</returns>
        public static string sha384(string strIN)
        {
            return sha384(System.Text.Encoding.Default.GetBytes(strIN));
        }
        /// <summary>
        /// Caculate string's SHA384 value. 计算字符串的SHA384值。
        /// </summary>
        /// <param name="btIN">input Byte Array. 输入的字节数组。</param>
        /// <returns>Return SHA384 value. 返回SHA384值。</returns>
        public static string sha384(byte[] btIN)
        {
            byte[] tmpByte;
            SHA384 sha384 = new SHA384Managed();
            tmpByte = sha384.ComputeHash(btIN);
            sha384.Clear();
            string strResult = BitConverter.ToString(tmpByte);
            strResult = strResult.Replace("-", "");
            return strResult;
        }

        /// <summary>
        /// Caculate string's SHA512 value. 计算字符串的SHA512值。
        /// </summary>
        /// <param name="strIN">input string. 输入的字符串。</param>
        /// <returns>Return SHA512 value. 返回SHA512值。</returns>
        public static string sha512(string strIN)
        {
            return sha512(System.Text.Encoding.Default.GetBytes(strIN));
        }
        /// <summary>
        /// Caculate string's SHA512 value. 计算字符串的SHA512值。
        /// </summary>
        /// <param name="btIN">input Byte Array. 输入的字节数组。</param>
        /// <returns>Return SHA512 value. 返回SHA512值。</returns>
        public static string sha512(byte[] btIN)
        {
            byte[] tmpByte;
            SHA512 sha512 = new SHA512Managed();
            tmpByte = sha512.ComputeHash(btIN);
            sha512.Clear();
            string strResult = BitConverter.ToString(tmpByte);
            strResult = strResult.Replace("-", "");
            return strResult;
        }

        /// <summary>
        /// Caculate string's CRC32 value. 计算字符串的循环冗余校验码CRC32值。
        /// </summary>
        /// <param name="strIN">input string. 输入的字符串。</param>
        /// <returns>Return CRC32 value. 返回CRC32值。</returns>
        public static string crc32(string strIN)
        {
            return crc32(strIN);
        }
        /// <summary>
        /// Caculate string's CRC32 value. 计算字符串的循环冗余校验码CRC32值。
        /// </summary>
        /// <param name="btIN">input Byte Array. 输入的字节数组。</param>
        /// <returns>Return CRC32 value. 返回CRC32值。</returns>
        public static string crc32(byte[] btIN)
        {
            return crc_caculator(btIN, CRC.Standard.CRC32);
        }

        /// <summary>
        /// Caculate string's CRC64 value. 计算字符串的循环冗余校验码CRC64值。
        /// </summary>
        /// <param name="strIN">input string. 输入的字符串。</param>
        /// <returns>Return CRC64 value. 返回CRC64值。</returns>
        public static string crc64(string strIN)
        {
            return crc64(strIN);
        }
        /// <summary>
        /// Caculate string's CRC64 value. 计算字符串的循环冗余校验码CRC64值。
        /// </summary>
        /// <param name="btIN">input Byte Array. 输入的字节数组。</param>
        /// <returns>Return CRC64 value. 返回CRC64值。</returns>
        public static string crc64(byte[] btIN)
        {
            return crc_caculator(btIN, CRC.Standard.CRC64);
        }
        /// <summary>
        /// CRC Caculator. CRC循环冗余校验码计算器
        /// </summary>
        /// <param name="btIN">input Byte Array. 输入的字节数组。</param>
        /// <param name="standard">CRC Standard. CRC计算标准。</param>
        /// <returns>Return CRC value. 返回CRC值。</returns>
        public static string crc_caculator(byte[] btIN, CRC.Standard standard)
        {
            CRC.Setting crcset = CRC.Standards[standard];
            System.Data.HashFunction.CRC crc = new CRC(crcset);
            byte[] tmpByte = crc.ComputeHash(btIN);
            string strResult = BitConverter.ToString(tmpByte);
            strResult = strResult.Replace("-", "");
            return strResult;
        }
    }
}
