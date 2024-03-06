Object:subClass("ItemGrid")

--成员变量
ItemGrid.obj=nil
ItemGrid.imgIcon=nil
ItemGrid.Text=nil


--成员方法
--初始化位置
--father....父对象transform
function ItemGrid:Init(father)
    --实例化
    self.obj=ABMgr:LoadRes("ui","ItemGrid",typeof(GameObject))
    --设置父对象
    self.obj.transform:SetParent(father,false) 
    --设置控件
    self.imgIcon=self.obj.transform:Find("imgIcon"):GetComponent(typeof(Image))
    self.Text=self.obj.transform:Find("Text"):GetComponent(typeof(Text))
end


--设置位置信息
function ItemGrid:InitPos(Position3D)
   --设置位置信息
   --self.obj.transform.localPosition=Position3D
   self.obj:GetComponent(typeof(RectTransform)).anchoredPosition3D=Position3D
end


--初始化格子信息
--data....PlayerData
function ItemGrid:InitData(Data)
    local itemdata=ItemData[Data.id]
    --切分字符串 获得图集名
    local AtlasStrs=string.split(itemdata.icon,"_")
    --加载图集
    local SpriteAltas=ABMgr:LoadRes("ui",AtlasStrs[1],typeof(SpriteAtlas))
    self.imgIcon.sprite=SpriteAltas:GetSprite(AtlasStrs[2])
    self.Text.text=Data.number
end



--销毁格子
function ItemGrid:DestoryItem()
    GameObject.Destroy(self.obj)
    self.obj=nil
end
