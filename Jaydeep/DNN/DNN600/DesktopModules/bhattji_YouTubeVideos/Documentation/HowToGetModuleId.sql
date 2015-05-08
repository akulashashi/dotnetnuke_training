Select tm.ModuleId, tm.TabId, m.ModuleTitle, t.TabName 

From TabModules AS tm 
JOIN Modules AS m ON tm.ModuleId=m.ModuleId 
JOIN Tabs AS t ON tm.TabId=t.TabId
JOIN ModuleDefinitions AS md ON m.ModuleDefId=md.ModuleDefId 

Where md.FriendlyName='bhattji.YouTubeVideos' 

=======================================================
Select tm.ModuleId, tm.TabId, m.ModuleDefId 

From Modules AS m 
JOIN ModuleDefinitions AS md ON m.ModuleDefId=md.ModuleDefId 
JOIN TabModules AS tm ON m.ModuleId=tm.ModuleId 

Where FriendlyName='bhattji.YouTubeVideos'
