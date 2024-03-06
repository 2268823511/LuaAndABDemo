using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;


public class LuaCopyEdior : Editor
{
    [MenuItem("XLua/copy lua to txt")]
    public static void CopyLuaToTXT(){
         
        string path=Application.dataPath+"/Lua/";
        if(!Directory.Exists(path)){
            return;
        }

        string[] strs=Directory.GetFiles(path,"*.lua");
        string newpath=Application.dataPath+"/LuaTxt/";
        if(!Directory.Exists(newpath))
           Directory.CreateDirectory(newpath);
        else{
            string[] oldFileStrs=Directory.GetFiles(newpath,"*.txt");
            for (int i = 0; i < oldFileStrs.Length; i++)
            {
                File.Delete(oldFileStrs[i]);
            }
        }  
        List<string> newFileNames=new List<string>(); 
        string fileName;
        for (int i = 0; i < strs.Length; i++)
        {
            fileName=newpath+strs[i].Substring(strs[i].LastIndexOf("/")+1)+".txt";
            File.Copy(strs[i],fileName);
            newFileNames.Add(fileName);
        }
        AssetDatabase.Refresh();
        //顺便打到ab包中
        for (int i = 0; i < newFileNames.Count; i++)
        {
            AssetImporter ASI=AssetImporter.GetAtPath(newFileNames[i].Substring(newFileNames[i].LastIndexOf("Assets")));
            if(ASI!=null){
                ASI.assetBundleName="lua";
            }
        }

    }
    
}
