using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JavaAffinity
{
    public partial class AffinityBoy : Form
    {

        private int _cpuCount = 0;
        private string[] _processNames = new string[]
        {
            "java", "javaw"
        };
        private List<ProcessPanel> processPanels;

        public AffinityBoy()
        {
            InitializeComponent();
        }

        private void AffinityBoy_Load(object sender, EventArgs e)
        {
            _cpuCount = Environment.ProcessorCount;
            label_systemInfo.Text = $"CPUs: {_cpuCount}";

            textBox_processNames.Lines = _processNames;


            ListProcesses();
        }

        const int h = (12 * 6);
        const int w = (320);
        private void textBox_processNames_TextChanged(object sender, EventArgs e)
        {
            return;
        }

        private void button_selectProcesses_Click(object sender, EventArgs e)
        {
            _processNames = textBox_processNames.Lines;
            ListProcesses();
        }


        private void button_setAffinity_Click(object sender, EventArgs e)
        {
            SetAffinity();
        }

        private void ClearPanels()
        {
            foreach (var p in processPanels)
            {
                p.panel.Dispose();
            }
        }

        private void ListProcesses()
        {
            if (processPanels != null)
            {
                ClearPanels();
            }

            List<Process> processes = new List<Process>();
            foreach (var pName in _processNames)
            {
                var processesWithName = Process.GetProcessesByName(pName);

                foreach (var proc in processesWithName)
                {
                    processes.Add(proc);
                }
            }

            var parentPanel = panel_bottom;
            processPanels = new List<ProcessPanel>();

            int xM = 2, yM = 2;
            int w = parentPanel.Width - (xM * 3);
            int h = 56;
            for (int i = 0; i < processes.Count; i++)
            {
                int xPos = xM;
                int yPos = yM + i * (h + xM);
                var newPanel = CreateProcessPanel(processes[i], parentPanel, new Point(xPos, yPos), new Size(w, h));

                processPanels.Add(newPanel);
            }
        }

        private ProcessPanel CreateProcessPanel(Process process, Panel parent, Point location, Size size)
        {
            var panel = new Panel()
            {
                Parent = parent,
                Location = location,
                Size = size,
                BorderStyle = BorderStyle.Fixed3D
            };

            var panelTitleLabel = new Label()
            {
                Parent = panel,
                Location = new Point(2, 2),
                Text = process.ProcessName + " | " + process.MainWindowTitle
            };

            var boxes = new CheckBox[_cpuCount];
            var labels = new Label[_cpuCount];

            // Current affinity. For presetting check boxes
            IntPtr currentAffinity = process.ProcessorAffinity;
            BitArray bits = new BitArray(System.BitConverter.GetBytes((int)currentAffinity));

            for (int i = 0; i < _cpuCount; i++)
            {
                int bitIndex = (_cpuCount - 1 - i);
                var cb = new CheckBox()
                {
                    Parent = panel,
                    Checked = bits[bitIndex],
                    Location = new Point(2 + 12 + (40 * i), 24),
                    Size = new Size(16, 16)
                };
                var lb = new Label()
                {
                    Parent = panel,
                    Text = bitIndex.ToString(),
                    Location = new Point(2 + 40 * i, 24),
                    Size = new Size(16, 16)
                };
                boxes[i] = cb;
                labels[i] = lb;
            }

            var button_setAll = new Button()
            {
                Parent = panel,
                Location = new Point(2 + 12 + (40 * _cpuCount) + (64 * 1), 20),
                Text = "ALL",
                Size = new Size(64, 24)
            };
            var button_setNone = new Button()
            {
                Parent = panel,
                Location = new Point(2 + 12 + (40 * _cpuCount) + (64 * 2), 20),
                Text = "NONE",
                Size = new Size(64, 24)
            };
            var button_setLeft = new Button()
            {
                Parent = panel,
                Location = new Point(2 + 12 + (40 * _cpuCount) + (32 * 8), 20),
                Text = "L",
                Size = new Size(32, 24)
            };
            var button_setRight = new Button()
            {
                Parent = panel,
                Location = new Point(2 + 12 + (40 * _cpuCount) + (32 * 9), 20),
                Text = "R",
                Size = new Size(32, 24)
            };

            var newProcessPanel = new ProcessPanel()
            {
                panel = panel,
                titleLabel = panelTitleLabel,
                checkBoxes = boxes,
                boxLabels = labels,
                process = process,
                button_setAll = button_setAll,
                button_setNone = button_setNone,
                button_setLeft = button_setLeft,
                button_setRight = button_setRight
            };

            newProcessPanel.Initialize();

            return newProcessPanel;
        }

        private void SetAffinity()
        {
            foreach (var pp in processPanels)
            {
                pp.UpdateProcessAffinity();
            }
        }

    }
}
