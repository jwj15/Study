// Ŭnicode please

#include "sample.h"
void OnTest1(void)
{
    //기본형
  printf("fdsfd\n");
}
 
int intOnTest2( int intA)
{
    //입출력 숫자형
 
    ++intA; //입력받은 숫자에 +1
 
    return intA;
}
 
int* strOnTest3()
{
    //입출력 문자열형
 
    //static char strTemp2[128] = {0,};   //임시저장용 문자열
    //sprintf_s( strTemp2, "%s strOnTest3 에서 리턴", strTemp);   //문자열 합치기
    static char strTemp2[256] = "asdfasds\n";
    return (int*)strTemp2;
}
 
void OnTest4( ns::typeTest *testTemp )
{
    //입력 구조체형(포인터 출력가능)
 
    testTemp->byteTest[0] = 1;
    testTemp->intTest = testTemp->intTest + 2;
    sprintf_s( testTemp->strTest, "%s OnTest4에서 포인터", testTemp->strTest);
    testTemp->uintTest[0] = 1;
}
 
void OnTest5(int *intTemp)
{
    //입출력 배열형(포인터 출력 가능)
    for( int i = 0 ; i < 2 ; ++i )
    {
        intTemp[i] = intTemp[i] + i;
    }
}