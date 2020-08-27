

# 配置52ABP-PRO的多语言
 
 
**请注意：**
- 从52ABP-PRO 2.5.0的版本开始默认采用json配置多语言
- 属性名和字段不能重复否则框架会验证失败，需要你删除重复的键名

## Json的配置方法如下

在MyCouldBook.Core类库中，找到路径为 Localization->SourceFiles->Json文件夹下的对应文件

### 中文本地化的内容Chinese localized content

找到Json文件夹下的MyCouldBook-zh-Hans.json文件，复制以下代码进入即可。

> 请注意防止键名重复，产生异常

```json
                    //的多语言配置==>中文
                    
                     "BookTagTagName": "标签名称",
                    "BookTagTagNameInputDesc": "请输入标签名称",
                     
					                     
                    "BookTag": "",
                    "ManageBookTag": "管理",
                    "QueryBookTag": "查询",
                    "CreateBookTag": "添加",
                    "EditBookTag": "编辑",
                    "DeleteBookTag": "删除",
                    "BatchDeleteBookTag": "批量删除",
                    "ExportBookTag": "导出",
                    "BookTagList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的MyCouldBook.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
                    
                     "BookTagTagName": "BookTagTagName",
                    "BookTagTagNameInputDesc": "Please input your BookTagTagName",
                     
					                     
                    "BookTag": "BookTag",
                    "ManageBookTag": "ManageBookTag",
                    "QueryBookTag": "QueryBookTag",
                    "CreateBookTag": "CreateBookTag",
                    "EditBookTag": "EditBookTag",
                    "DeleteBookTag": "DeleteBookTag",
                    "BatchDeleteBookTag": "BatchDeleteBookTag",
                    "ExportBookTag": "ExportBookTag",
                    "BookTagList": "BookTagList",
                     //的多语言配置==End
                    




```