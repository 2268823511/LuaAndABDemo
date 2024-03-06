print("**************主lua文件准备就绪***************");
require("InitClass")
--初始化json表信息
require("ItemData")

--玩家信息
--1.单机从本地读取
--2.网络从服务器读取
--写一个初始化玩家信息
require("PlayerData")
PlayerData:Init()

--面板逻辑
require("BasePanel")
require("MainPanel")
require("BagPanel")
require("ItemGrid")
MainPanel:ShowMe("MainPanel")



