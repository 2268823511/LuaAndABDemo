--加载AB包
--加载Json文件 TextAsset对象
local txt=ABMgr:LoadRes("json","ItemData",typeof(TextAsset))
--获取文本解析
print(txt.text)
local itemList=Json.decode(txt.text)
--存为全局的表
ItemData={}
--key为id,value为对应key的一行信息
for _,v in pairs(itemList) do
    ItemData[v.id]=v
end

