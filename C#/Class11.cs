using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Study
{
    class Class11
    {
        // 윈도우 인증
        static string strConn = "Data Source=.\\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=SSPI;";
        // App.Config 에 추가된 값 가져오기
        // System.Configuration 참조추가 후사용
        // string strConn = ConfigurationManager.ConnectionStrings["TESTDB"].ConnectionString;

        // 로그인 계쩡
        // Sql 연결정보(서버:127.0.0.1, 포트:50360, 아이디:sa, 비밀번호 : 12341234, db : TEST)
        static string connectionString = "server = 127.0.0.1,49808; uid = sa; pwd = 12341234; database = TEST;";
        // string connectionString = ConfigurationManager.ConnectionStrings["TESTDB2"].ConnectionString;

        // 사용예1
        public void DbConnect()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            conn.Close();
        }

        // 사용예2
        public void DbConnect2()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        // 사용예3
        public void DbConnect3()
        {
            // using문 사용하면 블럭이 끝나면 자동 리소스 해제(dispose호출)한다
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
            }
        }

        static void Main()
        {
            /* Insert 예제
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT MEMBER(ID,PASSWORD,NAME) VALUES('ddd','1234','jang')";
                cmd.ExecuteNonQuery();
                Console.WriteLine("전송완료");
            }
            */

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM MEMBER";
                SqlDataReader rdr = cmd.ExecuteReader();
                // cmd.ExecuteReader(CommandBehavior.CloseConnection) -> rdr클로즈하면 컨넥션 끊김(아마도?)

                // 가져온 데이터 Member클래스타입에 넣기
                List<Member> memberList = new List<Member>();
                while (rdr.Read())
                {
                    Member m = new Member();
                    m.ID = rdr.GetString(0);
                    // m.ID = rdr["ID"] as string; 컬럼명을 지정하여 가져올 수도 있다
                    m.PASSWORD = rdr.GetString(1);
                    m.NAME = rdr.GetString(2);
                    m.AGE = rdr.GetInt32(3);
                    // rdr.getString(4) 가 null이면 오류 출력
                    // 아래와 같이 널체크후 널이 아닐경우만 불러온다.
                    if (rdr.IsDBNull(4))
                    {
                        m.ADDRESS = "null";
                    }
                    else
                    {
                        m.ADDRESS = rdr.GetString(4);
                    }
                    memberList.Add(m);
                }
                rdr.Close();
                foreach (Member m in memberList)
                {
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4}", m.ID, m.PASSWORD, m.NAME, m.AGE, m.ADDRESS);
                }

            }
            // SqlDataAdapter
            // SqlDataReader와는 달리 연결을 끊고 가져온 데이타를 DataSet에 할당.
            DataSet ds = new DataSet();
            SqlConnection conn2 = new SqlConnection(strConn);
            conn2.Open();

            string sql = "SELECT ID, PASSWORD,ADDRESS NAME FROM MEMBER ORDER BY NAME ASC";

            // SqlDataAdapter 초기화
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn2);

            // Fill 메서드 실행하여 결과 DataSet을 리턴받음
            adapter.Fill(ds);
            // SqlDataAdapter는 널값 받아도 오류가 안나네?
            // adapter.Fill(ds,2,2,"member"); // 페이징 처리도 가능 (dataset,시작페이지,페이지크기,table이름)
            conn2.Close();
            ds.WriteXml(Console.Out); // 콘솔에 출력한다.

        }

        class Member
        {
            public string ID;
            public string PASSWORD;
            public string NAME;
            public int AGE;
            public string ADDRESS;
        }
    }
}
