------------------------------------------------
-----------   READ ME   ------------------------
------------------------------------------------

ProEssentials v9 Pro Winforms for .Net Framework (Window), by Gigasoft, Inc.

ProEssentials.Chart.Net.WinForms.nupkg is for .Net Framework 4.8 and earlier. Search for our .NetCore.Winforms file for .NetCore/50

Note, using earlier than VS2019, add Winforms tools to the ToolBox by right clicking ToolBox "Choose Items..." and follow steps 
1) Browse to our file Gigasoft.ProEssentials.DLL and add.  
2) Or it's also a good idea to copy Gigasoft.ProEssentials.Dll to a new folder where the IDE can always find it;
and add to the ToolBox from this new location will help using our controls in multiple projects earlier than VS2019 

Note, first time dragging a tool from toolbox may require Visual Studio be running with Admin privileges. 
This Nuget uses an embedded resourse that must unpack upon first use to support the designer.  Subsequent uses will not require Admin.  

1) Gigasoft's engineers will freely/no-hassle/quickly answer your questions and provide programming services as needed.  Just ask. 

2) The ProEssentials Nuget Charting component will provide an instant charting evaluation to your .Net Windows application. 

3) ProEssentials is ideal for large mission critical data visualization projects with many variations of proprietary interactive charts. 

4) Gigasoft's attention to rendering detail quickly creates a clean professional end-user experience hard to achieve this easy.

5) ProEssentials provides charts packed with data and annotations producing your proprietary visions mostly free of overlapping text and odd behaviors. 

6) Using ProEssentials means spending less time creating that polished final solution (with reduced need for testing) that is guaranteed to impress.

What/Why ProEssentials? Watch a short video:    https://www.youtube.com/watch?v=yhC0BwEm8M8 

For a quick look, achieved with a few lines of code : 
https://gigasoft.com/wpf-chart-net-data-visualization

Documentation :
https://gigasoft.com/netchart/controlcomponentslibrary.htm
 
This Nuget is fine for a first look, however, for a complete functional evaluation, including example projects, local help...
Download the full eval :
https://gigasoft.com/net-chart-component-wpf-winforms-download

The eval download is the best way to learn ... 
 - examples 000, 100, 400 to know the basics
 - examples 007, 014, 105, 107, 125  to know how to interact with chart programmatically 
 - examples 015, 005, 101, 026, 027, 028 to know about annotations 
 - examples 012, 013 for multiple axes, and 103 and 104 to overlap multiple axes 
 - example 005, and 132 to know how to create custom axes 
 - the more you play with our demo projects, the faster you master ProEssentials.  
 

Basic Walk-Through:  Winforms C# 
----------------------------------------------------

1) Place a Pego control on your form.  Default control name will be pego1.

2) Add a Form load event, Form1_Load.  Tip, double click the forms top title/caption bar to quickly create a form load event. 

3) Paste this code into your Load event handler....   Build, Run, Right-Click the chart to tinker with UI. 

---------------------------------------------------

pego1.PeString.MainTitle = "Hello World";
pego1.PeString.SubTitle = "";

pego1.PeData.Subsets = 2; // Subsets = Rows //
pego1.PeData.Points = 6; // Points = Columns //
pego1.PeData.Y[0, 0] = 10; pego1.PeData.Y[0, 1] = 30;
pego1.PeData.Y[0, 2] = 20; pego1.PeData.Y[0, 3] = 40;
pego1.PeData.Y[0, 4] = 30; pego1.PeData.Y[0, 5] = 50;
pego1.PeData.Y[1, 0] = 15; pego1.PeData.Y[1, 1] = 63;
pego1.PeData.Y[1, 2] = 74; pego1.PeData.Y[1, 3] = 54;
pego1.PeData.Y[1, 4] = 25; pego1.PeData.Y[1, 5] = 34;

pego1.PeString.PointLabels[0] = "Jan";
pego1.PeString.PointLabels[1] = "Feb";
pego1.PeString.PointLabels[2] = "Mar";
pego1.PeString.PointLabels[3] = "Apr";
pego1.PeString.PointLabels[4] = "May";
pego1.PeString.PointLabels[5] = "June";

pego1.PeString.SubsetLabels[0] = "For .Net Framework";
pego1.PeString.SubsetLabels[1] = "or MFC, ActiveX, VCL";
pego1.PeString.YAxisLabel = "Simple Quality Rendering";

pego1.PeColor.SubsetColors[0] = Color.FromArgb(60, 0, 180, 0);
pego1.PeColor.SubsetColors[1] = Color.FromArgb(180, 0, 0, 130);

pego1.PeColor.BitmapGradientMode = false;
pego1.PeColor.QuickStyle = Gigasoft.ProEssentials.Enums.QuickStyle.LightShadow;
pego1.PeTable.Show = Gigasoft.ProEssentials.Enums.GraphPlusTable.Both;
pego1.PeData.Precision = Gigasoft.ProEssentials.Enums.DataPrecision.NoDecimals;
pego1.PeFont.Label.Bold = true;
pego1.PePlot.Method = Gigasoft.ProEssentials.Enums.GraphPlottingMethod.Bar;
pego1.PePlot.Option.GradientBars = 8;
pego1.PePlot.Option.BarGlassEffect = true;
pego1.PeLegend.Location = Gigasoft.ProEssentials.Enums.LegendLocation.Left;
pego1.PePlot.DataShadows = Gigasoft.ProEssentials.Enums.DataShadows.ThreeDimensional;
pego1.PeFont.FontSize = Gigasoft.ProEssentials.Enums.FontSize.Large;
pego1.PePlot.SubsetLineTypes[0] = Gigasoft.ProEssentials.Enums.LineType.MediumSolid;
pego1.PePlot.SubsetLineTypes[1] = Gigasoft.ProEssentials.Enums.LineType.MediumDash;
pego1.PePlot.Option.MinimumPointSize = Gigasoft.ProEssentials.Enums.MinimumPointSize.MediumLarge;

// This enables data hot spots, But we need to define code in the HotSpot event //
pego1.PeUserInterface.HotSpot.Data = true;

// These settings will be used for all charts //
pego1.PeConfigure.RenderEngine = Gigasoft.ProEssentials.Enums.RenderEngine.Direct2D;
pego1.PeConfigure.PrepareImages = true;
pego1.PeConfigure.CacheBmp = true;
pego1.PeConfigure.AntiAliasGraphics = true;
pego1.PeConfigure.AntiAliasText = true;

// Call this at end of setting properties //
pego1.PeFunction.ReinitializeResetImage();

pego1.Refresh(); // call standard .NET Refresh method to force paint



--------------------------------------------------------
All Nugets to search for:
1) ProEssentials.Chart.Net.WinForms targets .Net472 Framework and less
2) ProEssentials.Chart.Net.Wpf targets .Net472 Framework and less
3) ProEssentials.Chart.NetCore.Winforms targets .Net50 Windows Apps 
4) ProEssentials.Chart.NetCore.Wpf targets .Net50 Windows Apps 



