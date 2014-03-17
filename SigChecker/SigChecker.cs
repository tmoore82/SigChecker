using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigChecker
{
    public static class SigChecker
    {
        /// <summary>
        /// Checks a file signature against an expected signature
        /// to be sure we're acting on the right file type.
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="signatureSize"></param>
        /// <param name="offset"></param>
        /// <param name="expectedSignature"></param>
        /// <returns></returns>
        public static bool CheckSignature(string filepath, int signatureSize, int offset, string expectedSignature)
        {
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                if (fs.Length < signatureSize)
                    return false;

                byte[] signature = new byte[signatureSize];

                int bytesRead = fs.Read(signature, offset, signatureSize);

                string actualSignature = BitConverter.ToString(signature);

                if (actualSignature == expectedSignature)
                    return true;
                else
                    return false;
            }

        }
    }
}
