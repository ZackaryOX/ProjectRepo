using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Wrapper : MonoBehaviour
{
    const string DLL_NAME = "PluginWrapper";

    [DllImport(DLL_NAME)]
    private static extern void SaveLocation(float x, float y, float z);

    [DllImport(DLL_NAME)]
    private static extern void LoadLocation();

    [DllImport(DLL_NAME)]
    private static extern float getX();
    [DllImport(DLL_NAME)]
    private static extern float getY();
    [DllImport(DLL_NAME)]
    private static extern float getZ();

    private void Start()
    {

        
    }
}
