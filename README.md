# QueryExcel

### 多Excel文件内容查询工具。

* **告别繁琐重复的体力劳动，一分钟干完一天的活。**:hear_no_evil:

* [码云](https://gitee.com/mahuifa/QueryExcel.git)

* [github](https://github.com/mahuifa/QueryExcel.git)
* [下载](https://github.com/mahuifa/QueryExcel/releases)

当需要在多个Excel表格中查询需要的信息是，一个文件一个文件的去查询非常麻烦。

虽然有其他方法可以实现在多个Excel表格中查询目标信息，但使用起来不是很方便，对小白也不是很友好。

受够了CTRL + C、CTRL + V 、CTRL + F的查询方式，如果是数量少时还问题不大，如果数量大时那就要人命了，比如我有100条数据，需要在100各Excel表格中查询，每个Excel表格有10个Sheet，每个Sheet有1000行，如果人工去一条一条看或者一个文件一个文件的查询，基本上一天就过去了。

所以开发了这一个小工具（QueryExcel）。



### 1、主要功能

* 在指定路径下所有Excel表格（包括子文件夹下的Excel）的所有Sheet中查询目标信息；
* 在当前路径下所有Excel表格（不查询子文件夹下的Excel）的所有Sheet中查询目标信息；
* 在选中Excel表格（只查询一个文件）的所有Sheet中查询指定信息；
* 同时查询任意条数信息。
* 支持.xls、.xlsx。
* 将包含所查询的内容的文件全部另存到一个文件夹中。



### 2、优点

* 使用简单：表格查询分三步（根本不需要学）
  * 选中需要查询的Excel所在的文件夹；
  * 输入需要查询的内容；
  * 点击查询。
* 体积小，无需安装；
* 速度快。



### 3、演示

![QueryExcel-tuya](README.assets/QueryExcel-tuya.gif)



* 如下图所示，在输入栏中输入一行为一条查询的信息，可同时查询多条信息。

![image-20210227172138813](README.assets/image-20210227172138813.png)

