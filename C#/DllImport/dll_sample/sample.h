// Ŭnicode please
#pragma once

#include <cstdio>

namespace ns {;
typedef struct tTest {
    char  strTest[128]; //문자열 128
    int   intTest;    //숫자형
    char byteTest[64]; //바이트형 배열
    unsigned int  uintTest[4];  //유니트형 배열

} typeTest;
}

extern "C" __declspec(dllexport) void   OnTest1(void);      //기본형
extern "C" __declspec(dllexport) int    intOnTest2(int intTemp);    //입출력 숫자형
extern "C" __declspec(dllexport) int*  strOnTest3();  //입출력 문자열형
extern "C" __declspec(dllexport) void   OnTest4(ns::typeTest *testTemp);    //입력 구조체(포인터 출력가능)
extern "C" __declspec(dllexport) void   OnTest5(int *intTemp);  //입출력 배열(포인터 출력가능)