#pragma once
#include "PluginSettings.h"
#include "SimpleClass.h"
#ifdef __cplusplus
extern "C"
{
#endif
	// Put your functions here
	PLUGIN_API int SimpleFunction();

	PLUGIN_API void SaveLocation(float, float, float);
	PLUGIN_API void LoadLocation();
	PLUGIN_API float getX();
	PLUGIN_API float getY();
	PLUGIN_API float getZ();
#ifdef __cplusplus
}
#endif