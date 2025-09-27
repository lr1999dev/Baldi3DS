using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour 
{
    public static int FreeSystemMemory
    {
        get { return UnityEngine.N3DS.Debug.GetSystemFree(); }
    }

    public static int FreeDeviceMemory
    {
        get { return UnityEngine.N3DS.Debug.GetDeviceFree(); }
    }

    public static int VRamAFree
    {
        get { return UnityEngine.N3DS.Debug.GetVRAMAFree(); }
    }

    public static int VRamBFree
    {
        get { return UnityEngine.N3DS.Debug.GetVRAMBFree(); }
    }

    public static bool IsNew3DS
    {
        get { return FreeSystemMemory > 50000000; }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialize()
    {
        AdjustFramerate(false);
        DontDestroyOnLoad(Instantiate(Resources.Load<GameObject>("Main")));
    }

    public static void AdjustFramerate(bool inGame)
    {
#if !UNITY_EDITOR && UNITY_N3DS
        if (inGame)
        {
            Application.targetFrameRate = IsNew3DS ? 60 : 30;
            return;
        }
        Application.targetFrameRate = 60;
#endif
    }
}