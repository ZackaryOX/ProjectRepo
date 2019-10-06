#pragma once
#include "PluginSettings.h"
#include "SimpleClass.h"
#ifdef __cplusplus
extern "C"
{
#endif
	// Put your functions here
	PLUGIN_API int SimpleFunction();

	PLUGIN_API void SaveLocation(int, float, float, float, float, float, float);
	PLUGIN_API void LoadLocation();
	PLUGIN_API int CountLines();
	PLUGIN_API void Clear();
	PLUGIN_API void SetCurrentLine(int);
	PLUGIN_API float getX();
	PLUGIN_API int getID();
	PLUGIN_API float getY();
	PLUGIN_API float getZ();
	PLUGIN_API float getX2();
	PLUGIN_API float getY2();
	PLUGIN_API float getZ2();
#ifdef __cplusplus
}
#endif