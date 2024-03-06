--常用別名定位
require("Object")
require("SplitTools")
Json=require("JsonUtility")

--unit引擎库
GameObject=CS.UnityEngine.GameObject
Resources=CS.UnityEngine.Resources
Transform=CS.UnityEngine.Transform
RectTransform=CS.UnityEngine.RectTransform
TextAsset=CS.UnityEngine.TextAsset
--图集对象类
SpriteAtlas=CS.UnityEngine.U2D.SpriteAtlas

Vector3=CS.UnityEngine.Vector3
Vector2=CS.UnityEngine.Vector2

--UI相关的
UI=CS.UnityEngine.UI
Image=UI.Image
Button=UI.Button
Text=UI.Text
ScrollRect=UI.ScrollRect
Toggle=UI.Toggle
UIBehaviour=CS.UnityEngine.EventSystems.UIBehaviour

--UI 拓展
TextMeshProUGUI=CS.TMPro.TextMeshProUGUI


--C#脚本
--获取单例对象
ABMgr=CS.ABMgr.GetInstance()
--画布的transform
Canvas=GameObject.Find("Canvas").transform

