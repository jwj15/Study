using Neodynamic.SDK.Printing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neodynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define a ThermalLabel object and set unit to inch and label size
            ThermalLabel tLabel = new ThermalLabel(UnitType.Inch, 1, 0.7);
            tLabel.GapLength = 0.2;

            //Define a TextItem object
            TextItem txtItem = new TextItem(0.2, 0.2, 2.5, 0.5, "JANG");

            //Define a BarcodeItem object
            BarcodeItem bcItem = new BarcodeItem(0.2, 1, 2, 1, BarcodeSymbology.Code128, "ABC 12345");
            //Set bars height to .75inch
            bcItem.BarHeight = 0.75;
            //Set bars width to 0.0104inch
            bcItem.BarWidth = 0.0104;

            //Add items to ThermalLabel object...
            tLabel.Items.Add(txtItem);
            //tLabel.Items.Add(bcItem);

            //Create a WindowsPrintJob object
            WindowsPrintJob pj = new WindowsPrintJob();
            pj.PrinterSettings = new PrinterSettings();
            //Thermal Printer is connected through Serial Port
            pj.PrinterSettings.Communication.CommunicationType = CommunicationType.Serial;
            //Set Thermal Printer resolution
            pj.PrinterSettings.Dpi = 203;
            //Set Thermal Printer language
            pj.PrinterSettings.ProgrammingLanguage = ProgrammingLanguage.EPL;
            //Set Thermal Printer serial port settings 
            pj.PrinterSettings.Communication.SerialPortName = "COM2";
            pj.PrinterSettings.Communication.SerialPortBaudRate = 9600;
            pj.PrinterSettings.Communication.SerialPortDataBits = 8;
            pj.PrinterSettings.Communication.SerialPortStopBits = SerialPortStopBits.One;
            pj.PrinterSettings.Communication.SerialPortParity = SerialPortParity.None;
            pj.PrinterSettings.Communication.SerialPortFlowControl = SerialPortHandshake.None;
            //pj.PrinterSettings.PrinterName = "SEWOO Label Printer";
            pj.Print(tLabel);
            Console.WriteLine("작업완료");
        }
    }
}
