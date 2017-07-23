using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker
{
    public struct option
    {
        public bool size;
        public bool date;
        public bool md5;
        public bool sha1;
        public bool sha256;
        public bool sha384;
        public bool sha512;
        public bool crc32;
        public bool crc64;
    }
    public struct result
    {
        public long size;
        public DateTime date;
        public string md5;
        public string sha1;
        public string sha256;
        public string sha384;
        public string sha512;
        public string crc32;
        public string crc64;
    }
    /// <summary>
    /// This class contains functions for other ways. 
    /// </summary>
    public static class CommenFunction
    {
        /// <summary>
        /// Get one file's size of byte. 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static long GetFileSize(string filename)
        {
            if(System.IO.File.Exists(filename))
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filename);
                return fileInfo.Length;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// Get one file's creation time. 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static DateTime GetFileCreationTime(string filename)
        {
            if (System.IO.File.Exists(filename))
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filename);
                return fileInfo.CreationTime;
            }
            else
            {
                return DateTime.MinValue;
            }
        }
        /// <summary>
        /// A function to get bytes' hash values. 
        /// </summary>
        /// <param name="bts"></param>
        /// <param name="op"></param>
        /// <returns></returns>
        public static result GetResult(byte[] bts,option op)
        {
            result r = new result();
            if (bts == null) return r;
            
            if (op.md5 == true)
            {
                r.md5 = HashFunction.md5(bts);
            }
            if (op.sha1 == true)
            {
                r.sha1 = HashFunction.sha1(bts);
            }
            if (op.sha256 == true)
            {
                r.sha256 = HashFunction.sha256(bts);
            }
            if (op.sha384 == true)
            {
                r.sha384 = HashFunction.sha384(bts);
            }
            if (op.sha512 == true)
            {
                r.sha512 = HashFunction.sha512(bts);
            }
            if (op.crc32 == true)
            {
                r.crc32 = HashFunction.crc32(bts);
            }
            if (op.crc64 == true)
            {
                r.crc64 = HashFunction.crc64(bts);
            }

            return r;
        }
    }
}
