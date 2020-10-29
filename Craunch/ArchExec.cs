using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Craunch
{
    class ArchExec
    {
        public EArch Arch { get; set; }

        public string Path { get; set; }
        public string Args { get; set; }

        public ArchExec()
            : this(EArch.x64, string.Empty, string.Empty)
        {
        }

        public ArchExec(EArch arch, string path, string args)
        {
            Arch = arch;
            Path = path;
            Args = args;
        }

        public ArchExec(byte[] inBytes)
        {
            byte[] bytes, lbytes;
            int length;
            using (var ms = new MemoryStream(inBytes))
            {
                int arch = ms.ReadByte();
                Arch = (EArch)arch;

                lbytes = ms.ReadAllCount(4);
                length = BitConverter.ToInt32(lbytes, 0);
                bytes = ms.ReadAllCount(length);
                Path = Encoding.UTF8.GetString(bytes);

                lbytes = ms.ReadAllCount(4);
                length = BitConverter.ToInt32(lbytes, 0);
                bytes = ms.ReadAllCount(length);
                Args = Encoding.UTF8.GetString(bytes);
            }
        }

        public byte[] GetBytes()
        {
            byte[] bytes, lbytes;
            using (var ms = new MemoryStream())
            {
                ms.WriteByte((byte)Arch);

                bytes = Encoding.UTF8.GetBytes(Path);
                lbytes = BitConverter.GetBytes(bytes.Length);
                ms.Write(lbytes, 0, 4);
                ms.Write(bytes, 0, bytes.Length);

                bytes = Encoding.UTF8.GetBytes(Args);
                lbytes = BitConverter.GetBytes(bytes.Length);
                ms.Write(lbytes, 0, 4);
                ms.Write(bytes, 0, bytes.Length);

                return ms.ToArray();
            }
        }

    }
}
