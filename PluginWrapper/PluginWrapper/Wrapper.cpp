#include "Wrapper.h"
SimpleClass simpleClass;
int SimpleFunction()
{
	return simpleClass.SimpleFunction();
}

PLUGIN_API void SaveLocation(int ID, float x, float y , float z, float x2, float y2, float z2)
{
	simpleClass.SavePosition(ID, x, y, z, x2, y2, z2);
}

PLUGIN_API void LoadLocation() {
	simpleClass.LoadPosition();
}

PLUGIN_API int CountLines()
{
	return simpleClass.CountLines();
}

PLUGIN_API void Clear()
{
	simpleClass.ClearFile();
}

PLUGIN_API void SetCurrentLine(int x)
{
	simpleClass.setCurrentLine(x);
}

PLUGIN_API float getX()
{
	return simpleClass.getX();
}

PLUGIN_API int getID()
{
	return simpleClass.getID();
}

PLUGIN_API float getY()
{
	return simpleClass.getY();
}

PLUGIN_API float getZ()
{
	return simpleClass.getZ();
}

PLUGIN_API float getX2()
{
	return simpleClass.getX2();
}

PLUGIN_API float getY2()
{
	return simpleClass.getY2();
}

PLUGIN_API float getZ2()
{
	return simpleClass.getZ2();
}


