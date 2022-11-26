# DgutAutoCheck
***
***使用此软件造成的一切后果自行承担***  
***
**DgutAutoCheck**是一个基于收发http数据包的一键打卡脚本，支持复数用户打卡并可以在打卡失败后发送邮件进行提醒  
通过设置Windows计划任务可以做到每日自动打卡

## 更新计划
转到[Preview](https://github.com/Kagam11/DgutAutoCheck/tree/preview)了解打算实现的功能

## 下载
你可以在[Latest Release](https://github.com/Kagam11/DgutAutoCheck/releases/latest)下载编译好的最新版本

## 使用方法
按要求设置好*Users.json*、*Custom.json*及*Config.json*后运行*DgutAutoCheck.exe*即可 
<details>
    <summary>关于Config.json及smtp服务</summary></br>
    
本软件使用smtp服务进行邮件发送提醒，要使用smtp服务，你需要在你的邮件提供商处开启smtp服务并获得smtp服务的密码。

以qq邮箱为例，相关选项在`设置→账户→POP3/IMAP/SMTP/Exchange/CardDAV/CalDAV服务`下，授权码即为smtp服务密码。

开启服务并获取服务密码后，可以搜索邮件提供商的smtp服务端口及服务器。

qq邮箱的smtp服务器为`smtp.qq.com`，端口为`587`。
</details>

<details>
    <summary>Windows计划任务的设置</summary></br>
    
通过计划任务可以使软件自动运行，以下展示每日零点十分运行一次软件的设置方法。

打开任务计划程序，在win10/11下直接可以在任务栏中搜索`任务计划程序`，也可按`win+R`键打开`运行`之后输入`taskschd.msc`并确定。

在右边的`操作`中点击`创建基本任务`，任意指定名称和描述、在触发器中选择`每天`并设置时间至`00:10:00`，每隔`1`天发生一次。

在操作中选择`启动程序`，在程序或脚本中选择`DgutAutoCheck.exe`**并设置起始于exe所在的文件夹**。
>例：假如exe路径为`C:\Users\Administrator\Desktop\DgutAutoCheck.exe`，则“起始于”应填写`C:\Users\Administrator\Desktop`。

如设置无误，只要Windows处于唤醒状态，便会在每日零点十分运行一次软件。
</details>

<details>
    <summary>Users.json的几个例子</summary></br>
    
仅需一人打卡时的例子

```javascript
[
    {
        "Username": "111111111111",
        "Password": "Password1"
    }// 注意这里并不需要逗号
]
```

三人打卡时的例子
```javascript
[
    {
        "Username": "111111111111",
        "Password": "Password1"
    },
    {
        "Username": "222222222222",
        "Password": "Password2"
    },
    {
        "Username": "333333333333",
        "Password": "Password2"
    }
]
```
</details>

## 注意事项
打卡过程为获取上一次存储的打卡信息并提交，在相关信息修改后请手动打一次卡以保证数据准确性

## 更新历史
*1.0.2*  
* 应对最新提交要求，增加详细地址项目

<details>
    <summary>过往版本</summary></br>

*1.0.1*  
* 将体温、是否在校、健康状况单独提取为可设置项目

*1.0.0*
* 发布
</details>
