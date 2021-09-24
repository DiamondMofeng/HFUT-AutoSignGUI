# HFUT-疫情信息填报自动打卡-图形用户界面版
## 免责声明：
若您下载本脚本，则视为您已经阅读、了解并接受以下内容：


①本软件仅供同学在确认所提交的疫情相关报备信息准确无误的情况下使用，软件所使用打卡信息为前一天成功提交的内容，若其中涉及的任何内容发生改变，须根据真实情况自行修改疫情信息报备内容。 

②作者保证使用此软件所产生的敏感信息均仅存放于使用者的计算机中，且不会用于以目的为疫情信息填报以外的任何功能。

③因使用本软件可能带来的任何风险问题，如信息泄露、未及时打卡等，均由使用者本人承担。


## 介绍：
原理：本软件基于.Net5.0 64位环境，用户界面使用Winform.

若您的电脑中缺少.Net 5.0 Desktop Runtime(x64)运行库，则无法运行本软件。

微软官方下载地址：[.NET 5.0 Desktop Runtime (v5.0.10) - Windows x64 Installer](https://download.visualstudio.microsoft.com/download/pr/78fa839b-2d86-4ece-9d97-5b9fe6fb66fa/10d406c0d247470daa80691d3b3460a6/windowsdesktop-runtime-5.0.10-win-x64.exe
)

打卡脚本AutoSignEXE.exe使用了C#下的selenium，通过自动操作edge来完成打卡。同时用System.Net中的类来完成邮件功能

定时部分使用了windows系统自带的schtasks，并使用同级目录下的XMLTasks.xml来储存用于在列表中显示的任务数据

设定任务时，生成任务项对应的TaskCache.xml，然后将其提交至schtasks.exe，达成向windows系统设置定时任务的目的

在触发用户设定的条件(到达规定时间)时，windows系统将调用AutoSignEXE.exe并传入所需参数，以完成打卡。

默认情况下，AutoSignEXE.exe运行完毕后，会向同级目录下的log.txt输出任务执行情况

(注：传入参数不符合规范时不会产生日志)





## 使用方法：

(软件尚未经过成体系的测试，因为可能存在许多未知bug)

### 主界面

![image](https://z3.ax1x.com/2021/09/21/4YqE0s.png)

### 添加任务界面

![image](https://z3.ax1x.com/2021/09/21/4YqG7R.png)



您仅需要在添加任务界面填入各项信息，并点击保存，即可在本电脑上完成自动打卡功能的设定。

软件提供了登录、邮件模块的单独测试、整体测试 以及 直接执行已创建任务 的多种测试方法，可有效测试设置的有效性

### 使用方法

![image](https://z3.ax1x.com/2021/09/24/40xZSe.jpg)

## 贡献者：
[Spartan-zhu](https://github.com/Spartan-zhu) for debugging

