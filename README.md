# MVVMDemo
实现了[文档](https://www.oschina.net/translate/wpf-mvvm-step-by-step-basics-to-advance-level?print)中的代码

## MVVM模式

### STEP 1 消灭后台代码中的转换逻辑 
将转换逻辑移到`ViewModel`类中，它封装实体类，属性是UI控件的`NAME`，这时后台代码中只有映射逻辑
### STEP 2 添加绑定，消灭后台代码
WPF特性：绑定/命令/声明式编程

拿掉后台代码中的映射逻辑=》将`ViewModel`的数据绑定到`XMAL`里的控件上

1. 命名空间`xmlns:custns="clr-namespace:DEMO.Views"`
2. 添加`<UserControl.Resources><custns:CustomerViewModel x:Key="custviewobj"/></UserControl.Resources>` 
3. 控件上绑定数据`<TextBlock Text=""{Binding TxtAmount, Source={StaticResource custviewobj}}>`
### STEP 3 添加执行动作和`INotifyPropertyChanged`接口
我们想在`XMAL`中调用`ViewModel`中的方法，但是不能直接调用，需要`WPF`的`Command`类。

所有从视图元素产生的动作都发送给Command类。

所有的动作调用都发送到`Command`类中，再路由到`ViewModel`中

简而言之：在`Command`类的`Execute()`中调用`ViewModel`中定义的方法，然后再在`ViewModel`中暴露这个`Command`给`XMAL`

问题又来了：虽然可以绑定方法了，但是修改后的值不能更新，所以我们需要从对象发送某种通知给UI。

在`ViewModel`的要调用的方法里发送`INotify`事件给视图，通知它更新有关的数据。

### STEP 4 在`ViewModel`中解构执行动作 
问题又又又来了：`ViewModel`和`Command`类过度耦合，即一个方法对应一个`Command`太低效了。

使用更通用的表达方式来表示方法/动作，通过**委托**的方法创建更通用的`Command`类

