using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Wrapper 
{
    const string DLL_NAME = "PluginWrapper";

    [DllImport(DLL_NAME)]
    private static extern void SaveLocation(int ID, float x, float y, float z, float x2, float y2, float z2);

    [DllImport(DLL_NAME)]
    private static extern void LoadLocation();

    [DllImport(DLL_NAME)]
    private static extern int CountLines();



    [DllImport(DLL_NAME)]
    private static extern int getID();

    [DllImport(DLL_NAME)]
    private static extern float getX();
    [DllImport(DLL_NAME)]
    private static extern float getY();
    [DllImport(DLL_NAME)]
    private static extern float getZ();

    [DllImport(DLL_NAME)]
    private static extern float getX2();
    [DllImport(DLL_NAME)]
    private static extern float getY2();
    [DllImport(DLL_NAME)]
    private static extern float getZ2();
    [DllImport(DLL_NAME)]
    private static extern void Clear();

    [DllImport(DLL_NAME)]
    private static extern void SetCurrentLine(int x);

    public Vector3 Pos;
    public Vector3 Rot;
    public int ID;

    public void LoadPos()
    {
        LoadLocation();

        this.Pos = new Vector3(getX(), getY(), getZ()); 
        this.Rot = new Vector3(getX2(), getY2(), getZ2());
        this.ID = getID();
    }

    public void SetLine(int x)
    {
        SetCurrentLine(x);
    }


    public void SavePos(int ID, float x, float y, float z, float x2, float y2, float z2)
    {
        SaveLocation(ID,x,y,z,x2,y2,z2);
    }
    public void ClearFile()
    {
        Clear();
    }
    public int Count()
    {
        return CountLines();
    }
    private void Start()
    {

        
    }
}
