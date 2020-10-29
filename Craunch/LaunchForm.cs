using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Craunch
{
    public partial class LaunchForm : Form
    {
        private readonly byte[] bytes;

        public LaunchForm(byte[] bytes)
        {
            this.bytes = new byte[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
                this.bytes[i] = bytes[i];

            InitializeComponent();
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n' || e.KeyChar == '\r')
            {
                e.Handled = true;
                Submit();
            }
        }

        private void OnSubmitPress(object sender, EventArgs e)
        {
            Submit();
        }

        private void Submit()
        {
            string text = tboxPassword.Text;
            if (this.Launch(text))
            {
                this.Dispose();
                return;
            }

            tboxPassword.Clear();
            MessageBox.Show("Password Incorrect!");
        }

        private bool Launch(string password)
        {
            byte[] inBytes = Crypto.Decrypt(this.bytes, password);
            if (inBytes == null) // Invalid password
                return false;

            List<ArchExec> execs = new List<ArchExec>();
            byte[] lbytes, bytes;
            int size, length;

            ArchExec launch = null;
            using (MemoryStream ms = new MemoryStream(inBytes))
            {
                lbytes = ms.ReadAllCount(4);
                size = BitConverter.ToInt32(lbytes, 0);
                if (size > 2)
                    size = 0;

                for (int i = 0; i < size; i++)
                {
                    lbytes = ms.ReadAllCount(4);
                    length = BitConverter.ToInt32(lbytes, 0);
                    bytes = ms.ReadAllCount(length);
                    ArchExec exec = new ArchExec(bytes);
                    execs.Add(exec);
                }

                EArch arch = Environment.Is64BitOperatingSystem ? EArch.x64 : EArch.x86;
                launch = execs.Where(p => p.Arch == arch).FirstOrDefault();
            }

            if (launch != null)
            {
                ProcessStartInfo psi = new ProcessStartInfo(launch.Path, launch.Args);
                psi.UseShellExecute = true;
                Process.Start(psi);
                return true;
            }
            else
            {
                MessageBox.Show("Password correct, but data is corrupted!");
                return true;
            }
        }
    }

    static class MSExt
    {
        public static byte[] ReadAllCount(this MemoryStream ms, int c)
        {
            if (c <= 0)
                return new byte[0];
            byte[] data = new byte[c];
            int r = 0, r2;

            while (r < c)
            {
                r2 = ms.Read(data, r, c - r);
                if (r2 <= -1)
                    return new byte[c];

                r += r2;
            }

            return data;
        }
    }
}
