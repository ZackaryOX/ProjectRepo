#pragma once
#include "PluginSettings.h"
#include <string>
#include <iostream>
#include <fstream>
#include <ostream>

class PLUGIN_API SimpleClass
{
public:
	int SimpleFunction();
	int CountLines();
	void ClearFile();
	void SavePosition(int, float, float, float, float, float, float);
	void LoadPosition();
	float getX();
	float getY();
	float getZ();
	float getX2();
	float getY2();
	float getZ2();
	void setCurrentLine(int);
	int getID();
	float X = 0;
	float Y = 0;
	float Z = 0;
	float X2 = 0;
	float Y2 = 0;
	float Z2 = 0;
	int ID = 0;
	int currentLine = 1;
};