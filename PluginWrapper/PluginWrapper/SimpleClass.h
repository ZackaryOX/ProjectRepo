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
	void SavePosition(float, float, float);
	void LoadPosition();
	float getX();
	float getY();
	float getZ();
	float X;
	float Y;
	float Z;
	
};