using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    /// <summary>
    /// Printer Contorl Class
    /// Reference from Microsoft
    /// </summary>
    public class RawPrinterHelper
    {
        public const string printerName = "SAM4S GIANT-100";
        public static string applicationPath = Environment.CurrentDirectory;

        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }

        #region DllImport to Control the Printer

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        #endregion

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "SAM4S PRINTER CONTROL EXAMPLE";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        /// <summary>
        /// Open Printer Cash Drawer
        /// </summary>
        /// <param name="drawNo">Drawer Number (1 or 2)</param>
        /// <param name="time">Open Time</param>
        /// <returns></returns>
        public static bool OpenCashDrawer(byte drawNo, byte time)
        {
            Byte[] bytes = new Byte[5];
            bool bSuccess = false;

            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = 5;

            // Drawer Control Command
            bytes[0] = 27;
            bytes[1] = 112;

            // Drawer Pin No
            if (drawNo == 1)
                // Drawer Connector Pin2
                bytes[2] = 48;
            else
                // Drawer Connector Pin5
                bytes[2] = 49;

            // On Time
            bytes[3] = time;

            // Off time
            bytes[4] = 0;

            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(printerName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);

            return bSuccess;
        }

        /// <summary>
        /// Partial Cut Without Feed
        /// </summary>
        /// <returns></returns>
        public static bool PartialCut()
        {
            Byte[] bytes = new Byte[3];
            bool bSuccess = false;

            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = 3;

            // Cut Control Command
            bytes[0] = 29;
            bytes[1] = 86;
            bytes[2] = 49;

            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(printerName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);

            return bSuccess;
        }

        /// <summary>
        /// Partial Cut
        /// </summary>
        /// <param name="feedLength"></param>
        /// <returns></returns>
        public static bool PartialCut(byte feedLength)
        {
            Byte[] bytes = new Byte[12];
            bool bSuccess = false;

            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = 12;

            // Feed and Cut Control Command
            bytes[0] = 29;
            bytes[1] = 86;
            bytes[2] = 66;
            bytes[3] = feedLength;

            bytes[4] = 29;
            bytes[5] = 86;
            bytes[6] = 66;
            bytes[7] = feedLength;

            bytes[8] = 29;
            bytes[9] = 86;
            bytes[10] = 66;
            bytes[11] = feedLength;

            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(printerName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);

            return bSuccess;
        }

        /// <summary>
        /// Send String to Printer
        /// </summary>
        /// <param name="szPrinterName"></param>
        /// <param name="szString"></param>
        /// <returns></returns>
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }

        /// <summary>
        /// Send File to Printer
        /// </summary>
        /// <param name="szPrinterName"></param>
        /// <param name="szFileName"></param>
        /// <returns></returns>
        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            fs.Close();

            return bSuccess;
        }

        /// <summary>
        /// Print Barcode
        /// </summary>
        /// <returns></returns>
        public static bool PrintBarcode()
        {
            // Barcode Data
            string testStr = "{A{STESTBARCODE";
            byte[] tempByte = Encoding.Default.GetBytes(testStr);

            Byte[] bytes = new Byte[tempByte.Length + 7];
            bool bSuccess = false;

            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = bytes.Length;

            // Set Barcode Height
            bytes[0] = 29;
            bytes[1] = 104;
            bytes[2] = 90;

            // Print Barcode
            bytes[3] = 29;
            bytes[4] = 107;
            // Barcode Type : Code128
            bytes[5] = 73;
            bytes[6] = (byte)tempByte.Length;

            for (int i = 0; i < tempByte.Length; i++)
            {
                bytes[7 + i] = tempByte[i];
            }

            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(printerName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);

            return bSuccess;
        }
    }

    class RawPrinter
    {
        static void Main()
        {
            //RawPrinterHelper.PartialCut();
            string printStr = "SAM4S(C)" + "\n\n";
            printStr += "777-77-77777  BONG\n";
            printStr += "서울시 금천구 가산동 371-28\n";
            printStr += "Tel : 02-777-8888\n";
            printStr += "2011년 06월 16일 일요일  No.555555-7777\n\n";
            printStr += "신문화를 창조하는 SAM4S 플라자\n";
            //RawPrinterHelper.SendStringToPrinter(RawPrinterHelper.printerName, printStr);

            RawPrinterHelper.PartialCut();

            Console.WriteLine("완료");

            /*
            /// <summary>
            /// Draw Open Test
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btn_DrawTest_Click(object sender, EventArgs e)
            {
                try
                {
                    byte DrawNo, Speed;

                    // Set Draw No
                    if (rb_Draw1.Checked == true) DrawNo = 1;
                    else DrawNo = 2;

                    // Set Draw Speed
                    Speed = Convert.ToByte(cb_DrawSpeedList.Text.Replace("ms", ""));

                    // Open Drawer
                    RawPrinterHelper.OpenCashDrawer(DrawNo, Speed);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Draw Open Error");
                }
            }

            /// <summary>
            /// Partial Cut Test
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btn_PartialCut_Click(object sender, EventArgs e)
            {
                try
                {
                    RawPrinterHelper.PartialCut(10);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Partial Cut Error");
                }
            }

            /// <summary>
            /// Partial Cut without Feed Test
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btn_CutNoFeed_Click(object sender, EventArgs e)
            {
                try
                {
                    RawPrinterHelper.PartialCut();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Partial Cut Without Feed Error");
                }
            }

            /// <summary>
            /// Print Receipt using Text Print
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btn_PrintReceipt_Click(object sender, EventArgs e)
            {
                try
                {
                    // This receipt is written by Korean,
                    // You can change as your own language

                    string printStr = "SAM4S(C)" + "\n\n";
                    printStr += "777-77-77777  BONG\n";
                    printStr += "서울시 금천구 가산동 371-28\n";
                    printStr += "Tel : 02-777-8888\n";
                    printStr += "2011년 06월 16일 일요일  No.555555-7777\n\n";
                    printStr += "신문화를 창조하는 SAM4S 플라자\n";
                    printStr += "항상 최고로 모시겠습니다.\n\n";
                    printStr += "------------------------------------------\n";
                    printStr += "상  품                수량         금 액\n";
                    printStr += "------------------------------------------\n";
                    printStr += "001 켐코더(SPT-53MEF)        9,000,000 (*)\n";
                    printStr += "2096790005033   8902    1    9,000,000 원\n\n";
                    printStr += "면세 공급가                            0원\n";
                    printStr += "과세 공급가                      7,500,000\n";
                    printStr += "부가 가치세                      1,500,000\n\n";
                    printStr += "매출액    9,000,000원\n";
                    printStr += "받는돈    9,000,000원\n";
                    printStr += "거스름돈             0원\n";
                    printStr += "------------------------------------------\n";
                    printStr += "SAM4S 보너스 카드\n\n";
                    printStr += "3개월                          9,000,000원\n";
                    printStr += "카드:3333-55**-*666-111            *******\n";
                    printStr += "승인:55994411      청구금액:   9,000,000원\n";
                    printStr += "승인 시간: 170411063003\n\n";
                    printStr += "총 품목수 : 1              총 구매수량 : 1\n\n";
                    printStr += "(*)표시는   과세  품목입니다.\n";
                    printStr += "본 영수증은 교환 및 환불시 필요합니다.\n";
                    printStr += "잘 보관하시기 바랍니다. 감사합니다.\n\n";
                    printStr += "17시04분13초              담당자: 김하늘\n";

                    // Blank String to Print out properly
                    printStr += "                                                                                                                  \n";
                    printStr += "                                                                                                                  \n";

                    RawPrinterHelper.SendStringToPrinter(Program.printerName, printStr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Print Receipt");
                }
            }

            /// <summary>
            /// Print test page using c# component
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btn_PrintUsingComponet_Click(object sender, EventArgs e)
            {
                try
                {
                    PrintDocument doc = new PrintDocument();

                    doc.PrinterSettings.PrinterName = Program.printerName;
                    doc.DocumentName = "SAM4S ELLIX20II TEST PRINT";

                    doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);


                    PrintPreviewDialog dlg = new PrintPreviewDialog();
                    dlg.Document = doc;
                    dlg.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Print using C# component");
                }
            }

            /// <summary>
            /// Print Page Setting
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void doc_PrintPage(object sender, PrintPageEventArgs e)
            {
                Font printFont = new Font("Code128", 20);

                Point pin = new Point(10, 10);

                e.Graphics.DrawImage(Image.FromFile(Program.applicationPath + "\\sam4s.bmp"), pin);
                e.Graphics.DrawString("** Test Print **", printFont, Brushes.Black, 10, 100);
            }

            /// <summary>
            /// Print test page from a file
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btn_PrintFromFile_Click(object sender, EventArgs e)
            {
                try
                {
                    // Allow the user to select a file.
                    OpenFileDialog ofd = new OpenFileDialog();

                    if (DialogResult.OK == ofd.ShowDialog(this))
                    {
                        // Print the file to the printer.
                        RawPrinterHelper.SendFileToPrinter(Program.printerName, ofd.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Print from a file");
                }
            }

            /// <summary>
            /// Print Barcode
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btn_PrintBarcode_Click(object sender, EventArgs e)
            {
                try
                {
                    // Print the file to the printer.
                    RawPrinterHelper.PrintBarcode();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Print Barcode");
                }
            }

            /// <summary>
            /// Show about dialog
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btn_About_Click(object sender, EventArgs e)
            {
                FrmAbout about = new FrmAbout();
                about.ShowDialog();
                about = null;
            }

            /// <summary>
            /// Exit Program
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btn_Exit_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
            */
        }
    }
}
