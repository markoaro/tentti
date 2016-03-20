using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // Otetaan ads kirjasto mukaan
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwinCAT.Ads;

using System.Windows.Forms.DataVisualization.Charting;

namespace Ads1Connect
{
    public partial class AdsForm : Form
    {
        // jäsenmuuttujat
        // viittaus adsClient-olioon
        private TcAdsClient adsClient;
        private AdsStream adsStream;
        private BinaryReader binReader;

        // kahvat TwinCAT-muuttujiin
        private int startHandle;
        private int stopHandle;
        private int measurementDataHandle;
        private int stepHandle;

        private int cntr = 0;

        public AdsForm()
        {
            InitializeComponent();
        }

        private void AdsForm_Load(object sender, EventArgs e)
        {
            buttonConnect.Enabled = true;
            buttonSetSR1.Enabled = false;
            buttonResetSR1.Enabled = false;

            DataPoint dp1 = new DataPoint(1, 1);
            DataPoint dp2 = new DataPoint(2, 2);
            DataPoint dp3 = new DataPoint(3, 1);

            DataPoint dp4 = new DataPoint(1, 1.2);
            DataPoint dp5 = new DataPoint(2, 2.4);
            DataPoint dp6 = new DataPoint(3, 1.1);

            chart1.Series.Clear();
            chart1.Series.Add("Measurement 1");
            chart1.Series.Add("Measurement 2");

            /*
            chart1.Series[0].Points.Add(dp1);
            chart1.Series[0].Points.Add(dp2);
            chart1.Series[0].Points.Add(dp3);

            chart1.Series[1].Points.Add(dp4);
            chart1.Series[1].Points.Add(dp5);
            chart1.Series[1].Points.Add(dp6);
             */

            chart1.Series[0].ChartType =
                    SeriesChartType.Line;
            chart1.Series[1].ChartType =
                    SeriesChartType.Line;
             

            chart1.Series[0].Color = Color.Red;
            chart1.Series[1].Color = Color.Blue;

            for (int i = 0; i < 100; i++)
            {
                xbuff[i] = i;
                y1buff.Enqueue(0);
                y2buff.Enqueue(0);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            // luodaan AdsClient-olio yhteyttä varten
            adsClient = new TcAdsClient();
            // otetaan yhteys TwinCAT PLC:hen portin 851 kautta
            adsClient.Connect(851); 

            // luodaan PLC:n muuttujiin viittaavat "osoittimet"
            startHandle = adsClient.CreateVariableHandle("MAIN.start");
            stopHandle = adsClient.CreateVariableHandle("MAIN.reset");

            // Luodaan tapahtumankäsittelijä. Parametrina näyttöä päivittävän metodin nimi
            adsClient.AdsNotification += new AdsNotificationEventHandler(UpdateVariables);

            // avataan Ads-stream (luettava byte-määrä pitänee antaa parametrina
            this.adsStream = new AdsStream(24);
            binReader = new BinaryReader(this.adsStream);

            /*
                timeHi: UDINT; 		// aika
                timeLo: UDINT;	 		// aika
                measurement1: REAL;	// mittaus 1
                measurement2: REAL;	// mittaus 2
                measurement3: REAL;	// mittaus 3
                counter: INT;			// juokseva numero
                arrayValue: INT;		// jotain
             * */
            measurementDataHandle = adsClient.AddDeviceNotification("MAIN.measurementData", this.adsStream, 0, 24,
                                        AdsTransMode.Cyclic, 100, 0, null);


            buttonConnect.Enabled = false;
            buttonSetSR1.Enabled = true;
            buttonResetSR1.Enabled = false;
        }

        private Queue<double> y1buff = new Queue<double>();
        private Queue<double> y2buff = new Queue<double>();
        private int[] xbuff = new int[100];

        private void UpdateVariables(object sender, AdsNotificationEventArgs e)
        {
            // e.NotificationHandlen avulla tunnistetaan tapahtuman aiheuttava TwinCAT-muuttuja
            if (e.NotificationHandle == measurementDataHandle)
            {
                string aika = e.TimeStamp.ToString();// e.Value.ToString();
                long x = long.Parse(aika);
                DateTime dt = new DateTime(x);

                e.DataStream.Position = e.Offset;

                // lue structin tiedot BinaryReaderin avulla
                UInt32 timeHi = binReader.ReadUInt32();
                UInt32 timeLo = binReader.ReadUInt32();
                double m1 = binReader.ReadSingle();
                double m2 = binReader.ReadSingle();
                double m3 = binReader.ReadSingle();

                int counter = binReader.ReadInt16();
                int joku = binReader.ReadInt16();

                /*
                chart1.Series[0].Points.AddXY(cntr++, m1);
                chart1.Series[1].Points.AddXY(cntr++, m2);
                 */
                y1buff.Enqueue(m1);
                y2buff.Enqueue(m2);
                if (y1buff.Count > 100 )
                {
                    y1buff.Dequeue();
                }
                if (y2buff.Count > 100)
                {
                    y2buff.Dequeue();
                }
                
                
                chart1.Series[0].Points.DataBindXY(xbuff, "x1", y1buff, "y1");
                chart1.Series[1].Points.DataBindXY(xbuff, "x2", y2buff, "y2");

                textBoxStructData.Text = counter + " " + m1 + " " + m2 + " " + m3;
            }
 
        }

        private void buttonSetSR1_Click(object sender, EventArgs e)
        {
            // Laitetaan Start päälle
            adsClient.WriteAny(startHandle, true);
            // Odotetaan 0.5 s
            System.Threading.Thread.Sleep(500);
            // laitetaan Stop päälle
            adsClient.WriteAny(startHandle, false);

            buttonConnect.Enabled = false;
            buttonSetSR1.Enabled = false;
            buttonResetSR1.Enabled = true;
        }

        private void buttonResetSR1_Click(object sender, EventArgs e)
        {
            // Laitetaan Start päälle
            adsClient.WriteAny(stopHandle, true);
            // Odotetaan 0.5 s
            System.Threading.Thread.Sleep(500);
            // laitetaan Stop päälle
            adsClient.WriteAny(stopHandle, false);

            buttonConnect.Enabled = false;
            buttonSetSR1.Enabled = true;
            buttonResetSR1.Enabled = false;
        }


    }
}
