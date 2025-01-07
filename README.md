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
    <Trigger Property="IsMouseOver" Value="True">
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

## Tips

- 鼠标的点击移动事件仅对能显示的控件生效，如果要全局生效可以将背景设置透明。
- 