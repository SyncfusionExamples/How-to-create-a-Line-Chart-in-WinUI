# How to create a WinUI Line Chart (SfCartesianChart)?

The [WinUI Line Chart](https://www.syncfusion.com/winui-controls/charts/winui-line-chart) represents and visualizes time-dependent data to show trends at equal intervals. This section explains how to create WinUI Line Chart.

The user guide [Documentation](https://help.syncfusion.com/winui/cartesian-charts/getting-started) helps you to acquire more knowledge on charts and their features. You can also refer to the [Feature Tour](https://www.syncfusion.com/winui-controls/charts) site to get an overview of all the features in a chart.

### Step 1: 
Create a simple project using the instructions given in the Getting Started with your first [WinUI app](https://learn.microsoft.com/en-us/windows/apps/winui/winui3/create-your-first-winui3-app) documentation.

### Step 2: 
Add [Syncfusion.Chart.WinUI](https://www.nuget.org/packages/Syncfusion.Chart.WinUI/) NuGet to the project and import the [SfCartesianChart](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.SfCartesianChart.html?tabs=tabid-1) namespace as follows.

**[XAML]**
```
xmlns:chart="using:Syncfusion.UI.Xaml.Charts"
```
**[C#]**
```
using Syncfusion.UI.Xaml.Charts;
```
### Step 3: 
Initialize an empty chart with XAxes and YAxes as shown in the following code sample.

**[XAML]**
```
<chart:SfCartesianChart>
    <chart:SfCartesianChart.XAxes>
        <chart:CategoryAxis/>
    </chart:SfCartesianChart.XAxes>
    <chart:SfCartesianChart.YAxes>
        <chart:NumericalAxis/>
    </chart:SfCartesianChart.YAxes>
</chart:SfCartesianChart>
```
**[C#]**
```
SfCartesianChart chart = new SfCartesianChart();

//Initializing XAxes
CategoryAxis xAxis = new CategoryAxis();

chart.XAxes.Add.(xAxis);

//Initializing YAxes
NumericalAxis yAxis = new NumericalAxis();

chart.YAxes.Add.(yAxis);

this.Content = chart;
```
### Step 4: 
Initialize a data model that represents a data point for Line Chart.
**[C#]**
```
public class Model
{
     public string Year { get; set; }

     public double Counts { get; set; }

     public Model(string name, double count)
     {
          Year = name;
          Counts = count;
     }
}	
```
### Step 5: 
Create a **ViewModel** class with a **Data Collection** property using the above model and initialize a list of objects as shown in the following code sample.

**[C#]**
```
public class ViewModel
{
    public ObservableCollection<Model> Data { get; set; }
    public ViewModel()
    {
        Data = new ObservableCollection<Model>()
        {
            new Model("1925", 415),
            new Model("1926", 408),
            new Model("1927", 415),
            new Model("1928", 350),
            new Model("1929", 375),
            new Model("1930", 500),
            new Model("1931", 390),
            new Model("1932", 450),
        };
    }
}
```
### Step 6: 
Set the **ViewModel** instance as the **DataContext** of your window; this is done to bind properties of **ViewModel** to the chart.
> **Note:** Add namespace of **ViewModel** class to your XAML page, if you prefer to set **DataContext** in XAML.

**[XAML]**
```
xmlns:viewModel="using:CartesianChartDesktop"
. . .
<chart:SfCartesianChart>

      <chart:SfCartesianChart.DataContext>
             <viewModel:ViewModel/>
      </chart:SfCartesianChart.DataContext>
</chart:SfCartesianChart>
```
**[C#]**
```
SfCartesianChart chart = new SfCartesianChart();
chart.DataContext = new ViewModel();
```
### Step 7: 
Populate the chart with data.

As we are going to visualize the comparison of annual rainfall in the data model, add [LineSeries](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.LineSeries.html) to [SfCartesianChart.Series](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.SfCartesianChart.html?tabs=tabid-1#Syncfusion_UI_Xaml_Charts_SfCartesianChart_Series) property, and then bind the Data property of the above ViewModel to the LineSeries [ItemsSource](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartSeriesBase.html#Syncfusion_UI_Xaml_Charts_ChartSeriesBase_ItemsSource) property as shown in the following code sample.
> **Note:** Need to set [XBindingPath](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartSeriesBase.html#Syncfusion_UI_Xaml_Charts_ChartSeriesBase_XBindingPath) and [YBindingPath](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.XyDataSeries.html?tabs=tabid-1#Syncfusion_UI_Xaml_Charts_XyDataSeries_YBindingPath) properties so that series will fetch values from the respective properties in the data model to plot the series.

**[XAML]**
```
<chart:SfCartesianChart>
    <chart:SfCartesianChart.DataContext>
           <viewModel:ViewModel/>
     </chart:SfCartesianChart.DataContext>
. . .
    <chart:SfCartesianChart.Series>
          <chart:LineSeries ItemsSource="{Binding Data}"
                        XBindingPath="Year" 
                        YBindingPath="Counts"
                        ShowDataLabels="True" >
         </chart:LineSeries>
</chart:SfCartesianChart.Series>

</chart:SfCartesianChart> 
```
**[C#]**
```
SfCartesianChart chart = new SfCartesianChart();
chart.DataContext = new ViewModel();
. . .

LineSeries series = new LineSeries();
series.SetBinding(LineSeries.ItemsSourceProperty, new Binding() { Path = new PropertyPath("Data") });
series.XBindingPath = " Year";
series.YBindingPath = " Counts";
series.ShowDataLabels = true;

chart.Series.Add(series);
this.Content = chart;
```

## Output:

![WinUI Line Chart](https://user-images.githubusercontent.com/63223423/144577880-5c89a712-13df-48bd-8fcd-cbc37e16d76d.png)

KB article - [How to create a WinUI Line Chart (SfCartesianChart)?](https://www.syncfusion.com/kb/13540/how-to-create-a-winui-line-chart-sfcartesianchart)



