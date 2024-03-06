using UnityEngine;
using UnityEngine.UI;


public class Main : MonoBehaviour
{
    public Button btn;
    void Start()
    {
       
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");
              
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
