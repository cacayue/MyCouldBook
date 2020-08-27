

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
                    
                     "BookName": "书籍名称",
                    "BookNameInputDesc": "请输入书籍名称",
                     
                    
                     "BookAuthor": "作者",
                    "BookAuthorInputDesc": "请输入作者",
                     
                    
                     "BookPriceUrl": "购买链接",
                    "BookPriceUrlInputDesc": "请输入购买链接",
                     
                    
                     "BookImgUrl": "封面链接",
                    "BookImgUrlInputDesc": "请输入封面链接",
                     
                    
                     "BookIntro": "简介",
                    "BookIntroInputDesc": "请输入简介",
                     
					                     
                    "Book": "",
                    "ManageBook": "管理",
                    "QueryBook": "查询",
                    "CreateBook": "添加",
                    "EditBook": "编辑",
                    "DeleteBook": "删除",
                    "BatchDeleteBook": "批量删除",
                    "ExportBook": "导出",
                    "BookList": "列表",
                     //的多语言配置==End
                    


```


### 英语本地化的内容English localized content
找到Json文件夹下的MyCouldBook.json文件，复制以下代码进入即可。
```json
             //的多语言配置==>英文
                    
                     "BookName": "BookName",
                    "BookNameInputDesc": "Please input your BookName",
                     
                    
                     "BookAuthor": "BookAuthor",
                    "BookAuthorInputDesc": "Please input your BookAuthor",
                     
                    
                     "BookPriceUrl": "BookPriceUrl",
                    "BookPriceUrlInputDesc": "Please input your BookPriceUrl",
                     
                    
                     "BookImgUrl": "BookImgUrl",
                    "BookImgUrlInputDesc": "Please input your BookImgUrl",
                     
                    
                     "BookIntro": "BookIntro",
                    "BookIntroInputDesc": "Please input your BookIntro",
                     
					                     
                    "Book": "Book",
                    "ManageBook": "ManageBook",
                    "QueryBook": "QueryBook",
                    "CreateBook": "CreateBook",
                    "EditBook": "EditBook",
                    "DeleteBook": "DeleteBook",
                    "BatchDeleteBook": "BatchDeleteBook",
                    "ExportBook": "ExportBook",
                    "BookList": "BookList",
                     //的多语言配置==End
                    




```