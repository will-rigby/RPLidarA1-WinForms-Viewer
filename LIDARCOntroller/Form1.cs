using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace LIDARCOntroller
{
    public partial class Form1 : Form
    {
        SerialPort serialPort;
        Boolean serialConnected;
        Thread serialPortThread;
        Boolean scanning;
        long scanInterval = 100000;
        long lastScan = 0;
        Boolean dataResponseState = false;
        int size = 8000;
        Boolean drawLine = false;
        int count = 0;
        List<Double> pointX = new List<Double>();
        List<Double> pointY = new List<Double>();
        List<Double> rayX = new List<Double>();
        List<Double> rayY = new List<Double>();
        int renderCount = 0;
        Boolean renderStatus = false;
        System.Drawing.Graphics formGraphics;

        public Form1()
        {
            InitializeComponent();

            serialPortBox.DataSource = SerialPort.GetPortNames();
            scanning = false;
            serialConnected = false;




        }

        private void Draw_Background()
        {

            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(40, 20, 700, 700));
            myBrush.Dispose();
            formGraphics.Dispose();

        }

        private void DrawPoint(double x, double y)
        {
            /* Convert to grid coordinates */
            int newX = -((Convert.ToInt32(x) * 350) / size) + 370;
            int newY = ((Convert.ToInt32(y) * 350) / size) + 370;
            formGraphics = this.CreateGraphics();
            Pen pen = new Pen(Color.LimeGreen);
            formGraphics.DrawLine(pen, newX-1, newY-1, newX, newY);
            if (drawLine)
            {
                Pen pen2 = new Pen(Color.Green);
                formGraphics.DrawLine(pen, 370, 370, newX, newY);
                pen2.Dispose();
            }
            
            formGraphics.Dispose();
            pen.Dispose();
        }



        private void Map_Click(object sender, EventArgs e)
        {

        }

        private void SerialPortBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (serialConnected == false)
            {
                try
                {
                    serialPort = new SerialPort();
                    serialPort.PortName = serialPortBox.SelectedItem.ToString();
                    serialPort.ReadBufferSize = 1024 * 1024 * 10;
                    serialPort.BaudRate = 115200;
                    serialPort.Open();
                    serialConnected = true;
                    connectButton.Text = "Disconnect";
                }
                catch (Exception ex)
                {
                    //serialPort.Close();
                    serialConnected = false;
                    MessageBox.Show("Failed to Open Serial Port", "Serial Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                if (serialPort.IsOpen)
                {
                    serialPortThread = new Thread(new ThreadStart(this.serialPortHandler));
                    serialPortThread.Start();
                    startButton.Enabled = true;

                }



            }
            else
            {
                serialPort.Close();
                if (serialPortThread.IsAlive) serialPortThread.Abort();
                startButton.Enabled = false;
                startButton.Text = "Start";
                connectButton.Text = "Connect";
                serialConnected = false;
            }
        }



        private void serialPortHandler()
        {
            int receivedData;
            int commandIndex = 0;
            int payloadLength = 0;
            int[] payload = new int[1];
            int payloadIndex = 0;
            int command = 0;
            byte checkSum;
            byte[] dataPacket = new byte[5];
            int packetIndex = 0;

            while ((serialConnected == true) && serialPort.IsOpen)
            {
                if ((serialPort.BytesToRead > 0) && serialPort.IsOpen)
                {
                    receivedData = serialPort.ReadByte();
                    if (dataResponseState == false)
                    {
                        if ((commandIndex == 0) && (receivedData == 0xA5))
                        {
                            commandIndex = 1;
                        }
                        else if (commandIndex == 1)
                        {
                            command = receivedData;
                            commandIndex = 2;
                        }
                        else if (commandIndex == 2)
                        {

                            payloadLength = receivedData;

                            payload = new int[payloadLength];
                            commandIndex = 3;
                            payloadIndex = 0;

                        }
                        else if ((commandIndex == 3) && (payloadIndex < (payloadLength)))
                        {
                            payload[payloadIndex] = receivedData;
                            payloadIndex++;
                        }
                        else if (commandIndex == 3)
                        {
                            checkSum = (byte)receivedData;
                            ProcessCommand(command, payloadLength, payload, checkSum);
                            commandIndex = 0;
                            payloadLength = 0;
                            payloadIndex = 0;
                        }
                    }
                    else
                    {
                        if (packetIndex == 0)
                        {
                            if (((receivedData & 1)) != ((receivedData >> 1) & 1))
                            {
                                dataPacket[packetIndex] = (byte)receivedData;
                                packetIndex++;
                            }

                        }
                        else if (packetIndex == 1)
                        {
                            if ((receivedData & 1) == 1)
                            {
                                dataPacket[packetIndex] = (byte)receivedData;
                                packetIndex++;
                            }
                            else
                            {
                                packetIndex = 0;
                            }
                        }
                        else
                        {
                            dataPacket[packetIndex] = (byte)receivedData;
                            packetIndex++;
                            if (packetIndex == 5)
                            {
                                packetIndex = 0;

                                ProcessDataPacket(dataPacket);


                            }
                        }
                    }


                    /* 
                 } if (scanning)
                 {
                     if(DateTime.UtcNow.ToFileTimeUtc() > (lastScan + scanInterval))
                     {
                         Byte[] packet = SmallRequestPacket(0x20);
                         serialPort.Write(packet, 0, packet.Length);
                         lastScan = DateTime.UtcNow.ToFileTimeUtc();
                     }*/

                }
            }
        }

        private byte[] RequestPacket(byte command, byte payloadSize, byte[] data)
        {
            byte[] packet = new byte[4 + payloadSize];
            packet[0] = 0xA5;
            packet[1] = command;
            packet[2] = payloadSize;
            for (int i = 0; i < payloadSize; i++)
            {
                packet[3 + i] = data[i];
            }
            if (data != null)
            {
                packet[3 + payloadSize] = calculateCheckSum(command, payloadSize, data);
            }
            else
            {
                packet[3] = calculateCheckSum(command, payloadSize);
            }

            return packet;
        }

        private byte[] SmallRequestPacket(byte command)
        {
            byte[] packet = new byte[2];
            packet[0] = 0xA5;
            packet[1] = command;


            return packet;
        }

        private double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        private void ProcessDataPacket(Byte[] dataPacket)
        {
            if ((dataPacket[0] & 1) == 1)
            {
                
                   




                if (renderCount == 5)
                {
                    /*
                    Thread.Sleep(3);
                    Byte[] stopPacket = SmallRequestPacket(0x25);
                    serialPort.Write(stopPacket, 0, stopPacket.Length);

                    Thread.Sleep(3);
                    Byte[] resetPacket = SmallRequestPacket(0x40);
                    serialPort.Write(resetPacket, 0, resetPacket.Length);
                    Thread.Sleep(3);
                    Byte[] packet = SmallRequestPacket(0x20);
                    serialPort.Write(packet, 0, packet.Length);
                    count = 0;
                    while (serialPort.BytesToRead > 0) serialPort.ReadExisting();
                    dataResponseState = false;
                    */
                    renderCount = 0;
                    formGraphics = this.CreateGraphics();
                    formGraphics.Clear(Color.White);
                    formGraphics.Dispose();
                    Draw_Background();
                }
                else
                {
                    renderCount++;
                }
                



            }
            
            
                int angle = ((0b1111111 & (dataPacket[1] >> 1)) | ((dataPacket[2] << 7))) / 64;
                int distance = (dataPacket[3] | (dataPacket[4] << 8)) / 4;

                double x = -1 * (Convert.ToDouble(distance) * Math.Cos(ConvertToRadians(Convert.ToDouble(angle))));
                double y = Convert.ToDouble(distance) * Math.Sin(ConvertToRadians(Convert.ToDouble(angle)));

                DrawPoint(x, y);
                //this.Invoke(new MethodInvoker(delegate () { DrawPoint(x, y); }));




        }

        private void ProcessCommand(int command, int payloadLength, int[] payload, byte checkSum)
        {
            Console.Write(DateTime.Now.ToLongTimeString() + "\t" + command.ToString("X2") + "\t" + payloadLength.ToString("X2") + "\t");
            foreach (int p in payload)
            {
                Console.Write(p.ToString("X2"));
            }
            Console.WriteLine("");
            byte[] payloadBytes = new byte[payloadLength];
            for (int i = 0; i < payloadLength; i++)
            {
                payloadBytes[i] = (byte)payload[i];
            }
            if (true)
            {
                if ((command == 0x5A) && (payloadLength == 5))
                {


                    if (scanning)
                    {
                        dataResponseState = true;
                    }

                }
                else if ((command == 0x5A) && (payloadLength == 3))
                {
                    if (payload[0] == 0)
                    {
                        this.Invoke(new MethodInvoker(delegate () { statusBox.Text = "GOOD"; }));
                    }
                    else if (payload[0] == 1)
                    {
                        this.Invoke(new MethodInvoker(delegate () { statusBox.Text = "WARNING"; }));
                    }
                    else if (payload[0] == 2)
                    {
                        this.Invoke(new MethodInvoker(delegate () { statusBox.Text = "ERROR"; }));
                    }
                }
            }

        }

        private byte calculateCheckSum(byte cmdType, byte payloadSize, byte[] payload)
        {
            int checkSum = 0 ^ 0xA5 ^ cmdType ^ payloadSize;
            if (payload != null)
            {
                foreach (byte b in payload)
                {
                    checkSum ^= b;
                }
            }


            return (byte)checkSum;
        }

        private byte calculateCheckSum(byte cmdType, byte payloadSize)
        {
            int checkSum = 0 ^ 0xA5 ^ cmdType ^ payloadSize;



            return (byte)checkSum;
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (scanning == false)
            {
                startButton.Text = "Stop";
                scanning = true;
                Byte[] packet = SmallRequestPacket(0x20);
                serialPort.Write(packet, 0, packet.Length);
                statusButton.Enabled = false;
            }
            else
            {
                startButton.Text = "Start";
                scanning = false;
                Byte[] stopPacket = SmallRequestPacket(0x25);
                serialPort.Write(stopPacket, 0, stopPacket.Length);
                Byte[] resetPacket = SmallRequestPacket(0x40);
                serialPort.Write(resetPacket, 0, resetPacket.Length);
                statusButton.Enabled = true;
                dataResponseState = false;
                serialPort.DiscardInBuffer();
            }
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            serialPortBox.DataSource = ports;
            Draw_Background();
        }

        private void StatusButton_Click(object sender, EventArgs e)
        {
            Byte[] packet = SmallRequestPacket(0x52);
            dataResponseState = false;
            serialPort.Write(packet, 0, packet.Length);
        }

        private void setScaleButton_Click(object sender, EventArgs e)
        {
            size = Convert.ToInt32(scaleUpDown.Value);
        }

        

        private void scaleUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rayTraceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            drawLine = rayTraceCheckBox.Checked;
        }
    }
}
