#include "Wrapper.h"
SimpleClass simpleClass;
int SimpleFunction()
{
	return simpleClass.SimpleFunction();
}

PLUGIN_API void SaveLocation(float x, float y , float z)
{
	simpleClass.SavePosition(x, y, z);
}

PLUGIN_API void LoadLocation() {
	simpleClass.LoadPosition();
}

PLUGIN_API float getX()
{
	return simpleClass.getX();
}

PLUGIN_API float getY()
{
	return simpleClass.getY();
}

PLUGIN_API float getZ()
{
	return simpleClass.getZ();
}


