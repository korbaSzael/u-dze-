using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace gra
{
    public partial class statystics : Form
    {
        public statystics()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            if (chart1.Series.Count == 0) return;
            didSaveUpper = true;
            chart1.SaveImage(common.gamePath+"UpperChart.png",ChartImageFormat.Png);
        }
        class ChartEntry
        {
            public string name;
            public int count=0;
            public int order=0;
            public Series srs = null;
            public int isIn(List<ChartEntry> lcEntries)
            {
                int containsIt = -1;
                for(int i=0;i<lcEntries.Count&&containsIt==-1;i++)
                {
                    if (lcEntries[i].name == name)containsIt = i;
                }
                return containsIt;
            }
        }
        private void statystics_Load(object sender, EventArgs e)
        {
            List<ChartEntry> lce = new List<ChartEntry>();
            chart1.Titles.Add("Porównanie każdego z osiągnięć");
            foreach (gameResult gr in common.database.gameResult)
            {
                ChartEntry ce = new ChartEntry { name = gr.name,count=gr.points};
                int where=ce.isIn(lce);
                if ( where == -1)
                {
                    lce.Add(ce);
                    ce.srs = chart1.Series.Add(gr.name);
                    ce.srs.ChartType = SeriesChartType.Line;
                    ce.srs.Points.Add(new DataPoint(ce.order++, gr.points));
                }
                else {
                    lce[where].srs.Points.Add(new DataPoint(lce[where].count++, gr.points));
                    lce[where].count += gr.points;
                }
            }
            chart2.Titles.Add("Podliczenie osiągnięć");
            foreach (ChartEntry ce in lce)
            {
                Series current = chart2.Series.Add(ce.name);
                current.Points.Add(ce.count);
            }
            return;
        }
        bool didSaveUpper = false;
        bool didSaveLower = false;

        private void chart1_MouseEnter(object sender, EventArgs e)
        {
            if (chart1.Series.Count == 0) return;
            if (!didSaveUpper)
            {
                toolTip1.SetToolTip(chart1, "Wciśnij mysz raz aby zapisać wykres jako obrazek...");
            }
            else
            {
                toolTip1.SetToolTip(chart1, "Zapisano wykres w pliku UpperChart.png");
            }
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            if (chart2.Series.Count == 0) return;
            didSaveLower = true;
            chart2.SaveImage(common.gamePath + "LowerChart.png", ChartImageFormat.Png);
        }

        private void chart2_MouseEnter(object sender, EventArgs e)
        {
            if (chart2.Series.Count == 0) return;
            if (!didSaveLower)
            {
                toolTip1.SetToolTip(chart2, "Wciśnij mysz raz aby zapisać wykres jako obrazek...");
            }
            else
            {
                toolTip1.SetToolTip(chart2, "Zapisano wykres w pliku LowerChart.png");
            }
        }
    }
}
