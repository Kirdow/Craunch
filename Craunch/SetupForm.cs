using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Craunch
{
    public partial class SetupForm : Form
    {
        private EArch arch;

        private ArchExec exec86;
        private ArchExec exec64;

        public SetupForm()
        {
            InitializeComponent();

            exec86 = new ArchExec { Arch = EArch.x86, Path = string.Empty, Args = string.Empty };
            exec64 = new ArchExec { Arch = EArch.x64, Path = string.Empty, Args = string.Empty };

            SetArch(EArch.x64);
            UpdateReady();

        }

        private void BrowseClick(object sender, EventArgs e)
        {

        }

        private void EncryptClick(object sender, EventArgs e)
        {
            if (UpdateReady())
            {
                StoreInput();
                List<ArchExec> execs = new List<ArchExec>();
                if (ReadyToEncryptArch(exec86))
                    execs.Add(exec86);
                if (ReadyToEncryptArch(exec64))
                    execs.Add(exec64);
                if (execs.Count == 0)
                {
                    MessageBox.Show("No mode available");
                    return;
                }

                Encrypt(execs, tboxPW.Text);
            }
        }

        private void ModeClick(object sender, EventArgs e)
        {
            StoreInput();
            ToggleArch();
            RestoreInput();
        }

        private void StoreInput()
        {
            ArchExec ae = arch == EArch.x64 ? exec64 : exec86;
            ae.Path = tboxPath.Text;
            ae.Args = tboxCmd.Text;
        }

        private void RestoreInput()
        {
            ArchExec ae = arch == EArch.x64 ? exec64 : exec86;
            tboxPath.Text = ae.Path;
            tboxCmd.Text = ae.Args;
        }

        private bool UpdateReady()
        {
            bool state = ReadyToEncrypt;
            btnEncrypt.Enabled = state;
            return state;
        }

        private void SetArch(EArch arch)
        {
            this.arch = arch;
            btnMode.Text = arch.ToString();
        }

        private void ToggleArch()
        {
            SetArch(arch == EArch.x64 ? EArch.x86 : EArch.x64);
        }

        private bool ReadyToEncrypt => (ReadyToEncryptArch(exec86) || ReadyToEncryptArch(exec64)) && !string.IsNullOrWhiteSpace(tboxPW?.Text) && tboxPW.Text.Length > 6;
        private bool ReadyToEncryptArch(ArchExec ae) => !string.IsNullOrWhiteSpace(ae.Path);

        private void OnTextChange(object sender, EventArgs e)
        {
            UpdateReady();
        }

        private void Encrypt(List<ArchExec> execs, string password)
        {
            byte[] inputBytes = null, bytes;

            using (var ms = new System.IO.MemoryStream())
            {
                byte[] lbytes = BitConverter.GetBytes(execs.Count);
                ms.Write(lbytes, 0, 4);

                foreach (var exec in execs)
                {
                    bytes = exec.GetBytes();
                    lbytes = BitConverter.GetBytes(bytes.Length);
                    ms.Write(lbytes, 0, 4);
                    ms.Write(bytes, 0, bytes.Length);
                }

                inputBytes = ms.ToArray();
            }

            if (inputBytes != null)
            {
                byte[] outputBytes = Crypto.Encrypt(inputBytes, password);
                System.IO.File.WriteAllBytes("craunch.dat", outputBytes);
                Program.Resave();
            }
        }
    }
}
