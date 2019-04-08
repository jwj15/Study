using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Class7
    {
        static void Main()
        {
            string filePath = "C:\\test.txt"; // @"C:\test.txt" 로 설정 권장
            // 파일 읽기
            // string settings = File.ReadAllText(filePath);
            // Console.WriteLine(settings);

            // 파일 쓰기
            string[] hosts = { "86.120.1.203", "113.45.80.31", "168.195.23.29" };
            // File.WriteAllLines(filePath, hosts);  한줄씩 입력

            // binary file
            byte[] rawSettings = {99,111,109,112,97,110,121,78,97,109,101,61,102,111,
                                    117,114,116,104,32,99,111,102,102,101,101};
            // File.WriteAllBytes(filePath, rawSettings); // companyName=fourth coffee 출력

            string settings = "companyContact= Dean Halstead"; // \r\n 개행
            // write~메소드는 파일을 새로 쓰지만 append~ 는 기존 내용에 추가한다.
            File.AppendAllText(filePath, settings);
            // File.AppendAllLines(filePath, hosts);

            string filePath2 = @"C:/test2.txt"; // 경로는 슬래쉬 역슬래쉬 다 가능!!
            File.Copy(filePath, filePath2, true); // 파일 카피 false면 이미 존재하는 파일 불가, 오류
            //File.Delete(filePath2); // 파일 삭제
            Console.WriteLine(File.Exists(filePath)); // 파일 존재 여부 return bool type

            // FileInfo 사용법
            FileInfo fileInfo = new FileInfo(filePath);
            // fileInfo.CopyTo(filePath2, false); // 카피
            // fileInfo.Delete(); // 삭제
            string dirName = fileInfo.DirectoryName; // 디렉토리 리턴
            // bool b1 = fileInfo.Exists; // 존재여부
            string ext = fileInfo.Extension; // 확장자 리턴
            long length = fileInfo.Length; // 용량 바이트단위
            Console.WriteLine("{0}, {1}, {2}Byte ", ext, dirName, length);

            // 디렉토리 생성 및 삭제
            Directory.CreateDirectory(@"C:/test"); // 생성
            // Directory.Delete(@"C:/test", true); // 하위 디렉토리 및 파일 삭제 true
            Directory.Exists(@"C:/Temp"); // 디렉토리 존재여부
            string[] subDirectories = Directory.GetDirectories(@"C:/ProgramData"); // 하위 디렉토리 가져오기
            foreach (var dir in subDirectories)
            {
                Console.WriteLine(dir);
            }
            string[] files = Directory.GetFiles(@"C:/ProgramData");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

            // DirectoryInfo
            DirectoryInfo directory = new DirectoryInfo(@"C:/test");
            // directory.Create(); // 디렉토리 생성
            // directory.Delete(true); // 하위 폴더 포함 삭제
            bool tempDataDirectoryExists = directory.Exists;
            string fullPath = directory.FullName; // 풀경로 출력
            DirectoryInfo[] subDirectories2 = directory.GetDirectories(); // 하위 디렉토리 목록 가져오기
            foreach (var dir in subDirectories2)
            {
                Console.WriteLine(dir);
            }
            FileInfo[] subFiles = directory.GetFiles(); // 파일목록 가져오기

            Console.WriteLine(Path.GetTempPath()); // 윈도우즈 temp 폴더 경로 출력
            Console.WriteLine(Path.HasExtension("advae"));// 경로에 확장자가 있는지 여부 뒤에 .+1개문자이상 일경우 true
            Console.WriteLine(Path.GetTempFileName()); 
           


        }

    }
}
