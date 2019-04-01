using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {

            // 코드 퍼스트 방식 중 데이터베이스 가져오고 난 후 코드 수정 후 DB 업데이트 하는법

            // 도구 -> Nuget패키지 관리자 -> 패키지 관리자 콘솔
            // Enable-Migrations
            // Add-Migration InitialCreate -IgnoreChanges
            // update-database
            // 수정후
            // Add-Migration AddColumn
            // update-database
        }
    }
}
