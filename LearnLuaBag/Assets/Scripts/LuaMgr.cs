using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;
/// <summary>
/// lua管理器
/// 提供 lua解析器
/// </summary>
public class LuaMgr :BaseManager<LuaMgr>
{
    //执行Lua语言的函数
    //释放垃圾
    //销毁
    //重定向
    private LuaEnv luaEnv;


    /// <summary>
    /// 得到Lua中的_G
    /// </summary>
    public LuaTable Global
    {
        get
        {
            return luaEnv.Global;
        }
    }

    public void Init()
    {
        //已经初始化了 别初始化 直接返回
        if (luaEnv != null)
            return;
        //初始化
        luaEnv = new LuaEnv();
        //加载lua脚本 重定向
        //luaEnv.AddLoader(MyCustomLoader);
        luaEnv.AddLoader(MyCustomABLoader);
    }


    private byte[] MyCustomLoader(ref string filePath)
    {

        //拼接lua文件所在的路径
        string path = Application.dataPath + "/Lua/" + filePath + ".lua";  
        //如果对应的文件存在
        if (File.Exists(path))
        {
            return File.ReadAllBytes(path);
        }
        else 
        {
            Debug.LogError("MyCustomLoaderPath 重定向失败,文件路劲为:\n" + path + "文件名为:\n" + filePath);
        }

        return null;
    }


    private byte[] MyCustomABLoader(ref string filePath)
    {
        //Debug.Log("进入AB包加载 重定向函数");
        ////从AB包中加载lua文件
        ////加载AB包
        //string path = Application.streamingAssetsPath + "/lua";
        //AssetBundle ab = AssetBundle.LoadFromFile(path);

        ////加载Lua文件 返回
        //TextAsset tx = ab.LoadAsset<TextAsset>(filePath + ".lua");
        ////加载Lua文件 byte数组
        //return tx.bytes;

        //通过我们的AB包管理器 加载的lua脚本资源
        TextAsset lua = ABMgr.GetInstance().LoadRes<TextAsset>("Lua", filePath + ".lua");
        if (lua != null)
            return lua.bytes;
        else
            Debug.Log("MyCustomABLoader重定向失败，文件名为：" + filePath);

        return null;
    }

    /// <summary>
    /// 传入lua文件名 执行lua脚本
    /// </summary>
    /// <param name="fileName"></param>
    public void DoLuaFile(string fileName)
    {
        string str = string.Format("require('{0}')", fileName);
        Debug.Log(str);
        DoString(str);
    }

    /// <summary>
    /// 执行Lua语言
    /// </summary>
    /// <param name="str"></param>
    public void DoString(string str)
    {
        if (luaEnv == null)
        {
            Debug.Log("解析器为初始化");
            return;
        }
        luaEnv.DoString(str);
    }

    /// <summary>
    /// 释放lua 垃圾
    /// </summary>
    public void Tick()
    {
        if (luaEnv == null)
        {
            Debug.Log("解析器为初始化");
            return;
        }
        luaEnv.Tick();
    }

    /// <summary>
    /// 销毁解析器
    /// </summary>
    public void Dispose()
    {
        if (luaEnv == null)
        {
            Debug.Log("解析器为初始化");
            return;
        }
        luaEnv.Dispose();
        luaEnv = null;
    }

}
