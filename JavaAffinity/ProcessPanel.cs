using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JavaAffinity
{
    class ProcessPanel
    {
        public Process process;
        public Panel panel;
        public Label titleLabel;
        public Label[] boxLabels;
        public CheckBox[] checkBoxes;
        public Button button_setAll;
        public Button button_setNone;

        public Button button_setLeft;
        public Button button_setRight;

        private int _cpuCount;
        private IntPtr targetAffinity;

        public void Initialize()
        {
            _cpuCount = checkBoxes.Length;

            button_setAll.Click += Button_setAll_Click;
            button_setNone.Click += Button_setNone_Click;

            button_setLeft.Click += Button_setLeft_Click;
            button_setRight.Click += Button_setRight_Click;


            UpdateBoxes(process.ProcessorAffinity);

        }

        private void Button_setNone_Click(object sender, EventArgs e)
        {
            IntPtr affinity = (IntPtr)0;
            targetAffinity = affinity;
            UpdateBoxes(targetAffinity);
            // SAVE AFFINITY
            // UPDATE BOXES
            // SET AFFINITY on button click. not on box clear
        }

        private void Button_setRight_Click(object sender, EventArgs e)
        {
            targetAffinity = (IntPtr) 0b0000000011111111;
            UpdateBoxes(targetAffinity);
        }
        private void Button_setLeft_Click(object sender, EventArgs e)
        {
            targetAffinity = (IntPtr)0b1111111100000000;
            UpdateBoxes(targetAffinity);
        }


        private void Button_setAll_Click(object sender, EventArgs e)
        {
            IntPtr affinity = IntPtr.Zero;
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                affinity += 1 << (_cpuCount - i - 1);
            }

            targetAffinity = affinity;
            UpdateBoxes(targetAffinity);
        }

        public void UpdateProcessAffinity()
        {
            IntPtr affinity = IntPtr.Zero;
            bool success = false;

            for (int i = 0; i < checkBoxes.Length; i++)
            {
                var cb = checkBoxes[i];
                if (cb.Checked == false)
                    continue;
                affinity += 1 << (_cpuCount - i - 1);
            }

            if (affinity == IntPtr.Zero)
            {
                UpdateBoxes(process.ProcessorAffinity);
                MessageBox.Show("Cannot set affinity to 0.\nPlease select at least one processor.", "No", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                process.ProcessorAffinity = affinity;
                success = true;
            }
            if (success)
            {
                MessageBox.Show("Settings Applied");
            }

        }

        public void UpdateBoxes(IntPtr affinity)
        {            
            BitArray bits = new BitArray(System.BitConverter.GetBytes((int)affinity));
            for (int i = 0; i < _cpuCount; i++)
            {
                int bitIndex = (_cpuCount - 1 - i);
                checkBoxes[bitIndex].Checked = bits[i];
            }
        }
    }
}
