using UnityEngine;

public class Initialization : MonoBehaviour
{
    private static bool isInit;

    private void Awake()
    {
        if (isInit)
        {
            return;
        }
        
        ArObject.Init();
        isInit = true;
    }
}
