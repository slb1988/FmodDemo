
这是Fmod音频测试工程
经测试基本工程使用无问题，可以和音效工程师的Fmod编辑器无缝对接，效果很赞

当你在FMOD你设计好后，将EVENT事件放入你需要的bank里，然后点FILE --BUILD 再点FILE--EXPORT GUIDS，这时你需要去FMOD官网下载对应UNITY的插件，安装好后UNITY上会出现FMOD字样，点击导入BANK，这时选择你FMOD工程里的BUILD文件夹，你会发现FMOD的资源都出现了，在主摄像机上加载FMOD listener 然后选择你需要添加音效的物件，为之加载一个FMOD studio event emitter把你做好的音效事件放到ASSET里就可以了

