# Wpf手册

> 记录wpf常用指令以及使用方法

## xaml文件

### 常用属性

1. `WindowStartupLocation="CenterScreen"` 将window显示在屏幕中间，仅限`Window`类使用。
2. `WindowStyle="None"` 将window设置为没有关闭/最小化等按钮的样式，仅限`Window`类使用。

## 常用功能

### 获取当前Window

```c#
private static Window CurrentWindow => Application.Current.MainWindow;
```



### 实现鼠标点击屏幕移动

```c#
private static Window CurrentWindow => Application.Current.MainWindow;
protected override void OnMouseMove(MouseEventArgs e) {
    // 需要判断鼠标是否按下
    if (e.LeftButton == MouseButtonState.Pressed) {
        CurrentWindow.DragMove();
    }
}
```

### 动态切换语言/主题

1. 添加中文英文资源文件

   ```xaml
   <ResourceDictionary
       xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
       xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
       xmlns:sys="clr-namespace:System;assembly=mscorlib"
   >
       <!-- zh-en.xaml -->
       <sys:String x:Key="File">文件</sys:String>
   </ResourceDictionary>
   ```

2. (可选)在App.xml添加默认语言文件 

3. 继承`ResourceDictionary` 类标识语言文件

   ```c#
   public class LanguageResource : ResourceDictionary {}
   public enum LanguageType {
       Chinese,
       English
   }
   ```

4. 获取系统资源切换Source

   ```c#
   /// <summary>
   /// 切换全局系统语言，如果有默认语言需要使用LanguageResource导入
   /// </summary>
   /// <param name="type"></param>
   public static void ChangeLanguage(LanguageType type) {
       var res = Application.Current.Resources.MergedDictionaries;
       var language = res.FirstOrDefault(it => it is LanguageResource);
       if (language == null) {
           language = new LanguageResource();
           res.Add(language);
       }
   
       switch (type) {
           case LanguageType.Chinese: {
               // UriKind.RelativeOrAbsolute 允许Uri根据字符串推断是否是相对或者绝对uri
               language.Source = new Uri("/Properties/zh-cn.xaml", UriKind.RelativeOrAbsolute);
               break;
           }
   
           case LanguageType.English: {
               language.Source = new Uri("/Properties/en-us.xaml", UriKind.RelativeOrAbsolute);
               break;
           }
   
           default: {
               return;
           }
       }
   }
   ```

### 去除原来的窗口顶部

1. window属性添加 `WindowStyle="None"`

2. 去除顶部留白

   ```xaml
   <WindowChrome.WindowChrome>
       <WindowChrome CaptionHeight="0" ResizeBorderThickness="5" GlassFrameThickness="0" />
   </WindowChrome.WindowChrome>
   ```

   

## 样式

> 样式属于资源文件，也就是属于`Resource`

### 常用属性

1. `x:Key` 设置样式的key，别的控件可以直接使用key来使用样式。
2. `TargetType` 设置样式的目标控件。
3. `Setter` 指定样式，`Property` 设置属性名称，`Value` 设置具体属性。
4. 使用样式:  `Style="{StaticResource LogoImg}"`。

### 在控件中定义样式

```xaml
<UserControl.Resources>
    <Style x:Key="MenuWindowButton" TargetType="Button">
        <Setter Property="Background" Value="Transparent" />
    </Style>
</UserControl.Resources>
```

### 自定义控件的Content

```c#
<Setter Property="Template">
    <Setter.Value>
        <ControlTemplate TargetType="Button">
    		// TemplateBinding 能够绑定原来的属性
            <Border Padding="2" Background="{TemplateBinding Background}" 
                    BorderBrush="{TemplateBinding BorderBrush}" 
                    BorderThickness="{TemplateBinding BorderThickness}">
    
    			// 自适应显示内容
                <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" />
            </Border>
        </ControlTemplate>
    </Setter.Value>
    
    // MenuItem样式设计
    <ControlTemplate TargetType="MenuItem">
         <Border x:Name="templateRoot" BorderThickness="0.8" SnapsToDevicePixels="true">
            <ContentPresenter 
                x:Name="header" // 控件名称，用于后面设置样式
                TextElement.Foreground ="#1a1c1e" 
                Margin="6 4" 
                ContentSource="Header" // 内容原像素
                HorizontalAlignment="Left"  // 水平对齐
                RecognizesAccessKey="True" // 启用快捷键支持 
                SnapsToDevicePixels="True" // 启用像素对齐，防止模糊渲染
                VerticalAlignment="Center" // 垂直
            />
        </Border>
    </ControlTemplate>
                    
                    
    // 自定义带菜单的menuItem的样式
    
</Setter>
```



### 触发器

| 触发器名称       | 说明                                         |
| ---------------- | -------------------------------------------- |
| Trigger          | 监测依赖属性的变化、触发器生效               |
| MultiTrigger     | 通过多个条件的设置、达到满足条件、触发器生效 |
| DataTrigger      | 通过数据的变化、触发器生效                   |
| MultiDataTrigger | 多个数据条件的触发器                         |
| EventTrigger     | 事件触发器, 触发了某类事件时, 触发器生效。   |

定义触发器

```xaml
<Style.Triggers>
    // 设置鼠标进入时样式
    // TargetName="templateRoot" 指定修改最外层的元素
    <Trigger Property="IsMouseOver" Value="True" TargetName="templateRoot">
        <Setter Property="Background" Value="Pink"/>
        <Setter Property="Cursor" Value="Hand" />
    </Trigger>                
</Style.Triggers>
```

## 常用布局

### SpaceBetween

> 两个控件一左一右，中间占剩余大小

```xaml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto" />
        <ColumnDefinition Width="*" /> 
        <ColumnDefinition Width="Auto" />
    </Grid.ColumnDefinitions>
</Grid>
```

## 动画

> 动画的本质是图片不断的变化，而wpf的动画则是同一时间线上不同的输出组成的。

### DoubleAnimation

> 看名字就知道这是一个数值变化的动画，他在动画时间输出不断变化的数值。下面是他们的6个常用属性。
>
> 表格来自: [WPF中文网](https://www.wpfsoft.com/2024/08/21/2957.html)

| 属性名         | 说明                                           |
| -------------- | ---------------------------------------------- |
| From           | 获取或设置动画的起始值。                       |
| To             | 获取或设置动画的结束值。                       |
| By             | 获取或设置动画更改其起始值所依据的总数。       |
| EasingFunction | 获取或设置应用于此动画的缓动函数。             |
| IsAdditive     | 是否应将目标属性的当前值添加到此动画的起始值。 |
| IsCumulative   | 动画重复时是否累计该动画的值。                 |

如何使用?

1. 在资源文件中定义一个`DoubleAnimation`

   ```xaml
   <Storyboard x:Key="WidthStoryboard" TargetProperty="Width">
       <DoubleAnimation 
            From="200" 
            To="300" 
            Duration="0:0:1.5" 
            AutoReverse="True" 
            RepeatBehavior="Forever" 
       />
   </Storyboard>
   ```

2. 在事件中指定启动动画

   ```xaml
   <EventTrigger RoutedEvent="MouseEnter">
       <EventTrigger.Actions>
           <BeginStoryboard Storyboard="{StaticResource WidthStoryboard}" />
       </EventTrigger.Actions>
   </EventTrigger>
   ```

3. 在代码中使用动画

   ```c#
   var fadeOutAnimation = new DoubleAnimation {
       From = 1.0, // 初始透明度
       To = 0.0,   // 最终透明度
       Duration = TimeSpan.FromSeconds(0.3) // 动画持续时间
   };
   // 启动动画
   BeginAnimation(OpacityProperty, fadeOutAnimation);
   ```

## Tips

- 鼠标的点击移动事件仅对能显示的控件生效，如果要全局生效可以将背景设置透明。