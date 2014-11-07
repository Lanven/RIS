// MyDLL.cpp: определяет экспортированные функции для приложения DLL.
//

#include "stdafx.h"
extern "C"
{
	__declspec(dllexport) double __cdecl Add(double a, double b)
	{
		return a + b;
	}

	__declspec(dllexport) double __cdecl Subtract(double a, double b)
	{
		return a - b;
	}

	__declspec(dllexport) double __cdecl Multiply(double a, double b)
	{
		return a * b;
	}
}