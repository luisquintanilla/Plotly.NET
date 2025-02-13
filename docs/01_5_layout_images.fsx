(**
---
title: Layout images
category: Chart Layout
categoryindex: 2
index: 6
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 12.0.3"
#r "nuget: DynamicObj"
#r "../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# Annotations

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)


*Summary:* This example shows how to create Images and add them to the Charts in F#.

let's first create some data for the purpose of creating example charts:

*)

open Plotly.NET 
  
let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y' = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

(**
use the `LayoutImage.init` function to generate an image, and either the `Chart.withLayoutImage` or the `Chart.withLayoutImages` function to add
multiple annotations at once.

*)

open Plotly.NET.LayoutObjects

let image = 
    LayoutImage.init(
        Source="https://fsharp.org/img/logo/fsharp.svg",
        XRef="x",
        YRef="y",
        X=0,
        Y=3,
        SizeX=2,
        SizeY=2,
        Sizing=StyleParam.LayoutImageSizing.Stretch,
        Opacity=0.5,
        Layer=StyleParam.Layer.Below
    )

let imageChart =
    Chart.Line(x,y',Name="line")    
    |> Chart.withLayoutImage(image)

(*** condition: ipynb ***)
#if IPYNB
imageChart
#endif // IPYNB

(***hide***)
imageChart |> GenericChart.toChartHTML
(***include-it-raw***)

