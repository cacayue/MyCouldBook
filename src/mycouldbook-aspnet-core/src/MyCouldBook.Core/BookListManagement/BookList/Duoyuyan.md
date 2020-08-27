

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
                    
                     "BookListListName": "书单名称",
                    "BookListListNameInputDesc": "请输入书单名称",
                     
                    
                     "BookListIntro": "简介",
                    "BookListIntroInputDesc": "请输入简介",
                     
"BookListAndBooks": "BookListAndBooks",
					                     
                    "BookList": "",
                    "ManageBookList": "管理",
                    "QueryBookList": "查询",
                    "CreateBookList": "添加",
                    "EditBookList": "编辑",
                    "DeleteBookList": "删除",
                    "BatchDeleteBookList": "批量删除",
                    "ExportBookList": "导出",
                    "BookListList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的MyCouldBook.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
                    
                     "BookListListName": "BookListListName",
                    "BookListListNameInputDesc": "Please input your BookListListName",
                     
                    
                     "BookListIntro": "BookListIntro",
                    "BookListIntroInputDesc": "Please input your BookListIntro",
                     
"BookListAndBooks": "BookListAndBooks",
					                     
                    "BookList": "BookList",
                    "ManageBookList": "ManageBookList",
                    "QueryBookList": "QueryBookList",
                    "CreateBookList": "CreateBookList",
                    "EditBookList": "EditBookList",
                    "DeleteBookList": "DeleteBookList",
                    "BatchDeleteBookList": "BatchDeleteBookList",
                    "ExportBookList": "ExportBookList",
                    "BookListList": "BookListList",
                     //的多语言配置==End
                    




```