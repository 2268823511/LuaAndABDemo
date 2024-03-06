--测试玩家数据
--全局表
PlayerData={}

PlayerData.equips={}
PlayerData.items={}
PlayerData.gems={}

function PlayerData:Init()
    --测试
    table.insert(self.equips,{id=1,number=2})
    table.insert(self.equips,{id=2,number=3})

    table.insert(self.items,{id=3,number=21})
    table.insert(self.items,{id=4,number=22})

    table.insert(self.gems,{id=5,number=23})
    table.insert(self.gems,{id=6,number=99})
end