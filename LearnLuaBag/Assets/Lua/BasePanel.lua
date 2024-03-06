--面板基类
Object:subClass("BasePanel")
BasePanel.panelObj=nil
--存储各种控件
BasePanel.controls={}
BasePanel.isInitEvent=false

function BasePanel:Init(name)
    if self.panelObj==nil then
        --实例化对应面板
        self.panelObj=ABMgr:LoadRes("ui",name,typeof(GameObject))
        self.panelObj.transform:SetParent(Canvas,false)
        local allControls=self.panelObj:GetComponentsInChildren(typeof(UIBehaviour))
        --按照对象名去找对象
        --一个对象可能有多个UI 控件,所以controls最好存一个key table表
        for i=0,allControls.Length-1 do
            local ControlName=allControls[i].name;
            if  string.find(ControlName,"btn")~=nil or
                string.find(ControlName,"tog")~=nil or
                string.find(ControlName,"img")~=nil or
                string.find(ControlName,"sv")~=nil or
                string.find(ControlName,"Text")~=nil then
                --lua没有泛型 所以使用type类型保存
                local typeName=allControls[i]:GetType().Name
                    --{btnRole={Iamge=控件,Button=控件}}
                    --{togItem={Toggle=控件}}
                    if self.controls[ControlName]~=nil then
                        self.controls[ControlName][typeName]=allControls[i]
                    else
                        self.controls[ControlName]={[typeName]=allControls[i]}    
                    end
            end
        end  
    end
end

--获取指定某个控件
function BasePanel:GetControl(name,typeName)
    if self.controls[name]~=nil then
        if self.controls[name][typeName] ~=nil then
            return self.controls[name][typeName]
        end
    end
    return nil
end


--显示
function BasePanel:ShowMe(name)
    self:Init(name)
    self.panelObj:SetActive(true)
end


--隐藏
function BasePanel:HideMe() 
    self.panelObj:SetActive(false)
end