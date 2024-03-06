using System;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XLua;

public static class CSharpCallLuaList
{

  [CSharpCallLua]
  public static List<Type> CSharpCallLua=new List<Type>(){
    typeof(UnityAction<bool>)
  };

}
