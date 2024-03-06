--对主面板处理
BasePanel:subClass("MainPanel")

--初始化面板 实例化对象 控件事件监听
function MainPanel:Init(name)
    self.base.Init(self,name)
    if self.isInitEvent==false then
        self:GetControl("btnRole","Button").onClick:AddListener(function() 
            self:btnRoleClick()
        end)
        self.isInitEvent=true
    end
end 


--点击函数
function MainPanel:btnRoleClick()
    --print(self.paenlObj);
    BagPanel:ShowMe("BagPanel");
end