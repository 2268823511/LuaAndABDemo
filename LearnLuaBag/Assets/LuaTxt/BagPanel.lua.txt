BasePanel:subClass("BagPanel")

BagPanel.Content=nil

BagPanel.nowIndex=-1
BagPanel.items={}

function BagPanel:Init(name)
    self.base.Init(self,name)

    if self.isInitEvent==false then

        self.Content=self:GetControl("svBag","ScrollRect").content  
        --添加监听 
        self:GetControl("btnClose","Button").onClick:AddListener(function() 
            self:HideMe()
        end)
        
        self:GetControl("togEquip","Toggle").onValueChanged:AddListener(function(value)
            self:ChangeType(1)
        end)
        
        self:GetControl("togItem","Toggle").onValueChanged:AddListener(function(value)
            self:ChangeType(2)
        end)
        
        self:GetControl("togGem","Toggle").onValueChanged:AddListener(function(value)
            self:ChangeType(3)
        end)
    end  
end


function BagPanel:ShowMe(name)
    self.base.ShowMe(self,name)

    if self.nowIndex~=-1 then
        self:ChangeType(self.nowIndex)
    else
        self:ChangeType(1)
    end
end


function BagPanel:ChangeType(type)
    --print("当前状态是:"..type)
    if self.nowIndex==type then
        return
    end

    
    --不为空清空
    if self.items~= nil then
        for i=1,#self.items do
            self.items[i]:DestoryItem()
        end
    end
    
    local nowItems=nil
    if type==1 then
        nowItems=PlayerData.equips
    elseif type==2 then
        nowItems=PlayerData.items
    else
        nowItems=PlayerData.gems
    end
    
    --创建格子
    for i=1, #nowItems do
        local grid =ItemGrid:new()
        --实例化
        grid:Init(self.Content)
        local SizeX=grid.obj:GetComponent(typeof(RectTransform)).rect.width;
        local SizeY=grid.obj:GetComponent(typeof(RectTransform)).rect.height;
        --设置位置
        local gridpos=Vector3(((i-1)%5)*(SizeX+2),math.floor((i-1)/5)*(SizeY+2),0)
        grid:InitPos(gridpos)
        --设置格子信息
        grid:InitData(nowItems[i])
        --存为临时对象表
        table.insert(self.items,grid)
    end
     
    self.nowIndex=type
end
