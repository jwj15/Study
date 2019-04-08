using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Runtime.InteropServices;

namespace GLCombineSample
{
    public struct typeTest
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public String strTest;

        public int intTest;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byteTest;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public UInt32[] uintTest;
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        [DllImport("dll_sample.dll")]
        extern public static void OnTest1();

        [DllImport("dll_sample.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static int intOnTest2(int intTemp);

        [DllImport("dll_sample.dll", CharSet = CharSet.Ansi)]
        extern public static IntPtr strOnTest3();

        [DllImport("dll_sample.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static void OnTest4(ref typeTest testTemp);

        [DllImport("dll_sample.dll", CallingConvention = CallingConvention.Cdecl)]
        extern public static void OnTest5(int[] intTemp);

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            OnTest1();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            int a = 1;
            a = intOnTest2(a);
            System.Console.WriteLine(a);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            IntPtr a = strOnTest3();
            string s = Marshal.PtrToStringAnsi(a);
            System.Console.WriteLine(s);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            typeTest testTemp = new typeTest();

            testTemp.byteTest = new byte[64];
            testTemp.uintTest = new uint[4];

            testTemp.strTest = "asd";
            testTemp.intTest = 3;
            testTemp.byteTest[0] = (byte)'a';
            testTemp.uintTest[0] = 12;


            OnTest4(ref testTemp);

            System.Console.WriteLine(testTemp.byteTest);
            System.Console.WriteLine(testTemp.intTest);
            System.Console.WriteLine(testTemp.strTest);
            System.Console.WriteLine(testTemp.uintTest);

        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            int[] intTemp = new int[2];
            intTemp[0] = 1;
            intTemp[1] = 2;
            OnTest5(intTemp);
            System.Console.WriteLine(intTemp);

        }
    }
}
