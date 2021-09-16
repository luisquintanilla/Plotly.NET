(**
---
title: Styling ternary layouts
category: Ternary Plots
categoryindex: 9 
index: 3
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
# Styling ternary layouts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to style polar layouts in F#.

let's first create some data for the purpose of creating example charts:
*)
open Plotly.NET

// a coordinates
let a  = [ 1; 2; 3; 4; 5; 6; 7;]

// b coordinates
let b  = a |> List.rev

//c
let c  = [ 2; 2; 2; 2; 2; 2; 2;]

(**
Consider this combined ternary chart:
*)

let combinedTernary =
    [
        Chart.PointTernary(a,b,c)
        Chart.LineTernary(a,c,Sum = 10)
    ]
    
    |> Chart.combine

(*** condition: ipynb ***)
#if IPYNB
combinedTernary
#endif // IPYNB

(***hide***)
combinedTernary |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Styling the polar layout

Use the `Chart.withTernary` function and initialize a Ternary layout with the desired looks
*)
open Plotly.NET.LayoutObjects

let styledTernary = 
    combinedTernary
    |> Chart.withTernary(
        Ternary.init(
            AAxis = LinearAxis.init(Title = Title.init("A"), Color = Color.fromKeyword ColorKeyword.DarkOrchid),
            BAxis = LinearAxis.init(Title = Title.init("B"), Color = Color.fromKeyword ColorKeyword.DarkRed)
        )
    )

(*** condition: ipynb ***)
#if IPYNB
styledTernary
#endif // IPYNB

(***hide***)
styledTernary |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Styling A, B, and C Axes

You could pass these axes to `Chart.withTernary` as above, but for the case where you want to specifically set one axis, there are the `Chart.withAAxis`, `Chart.withBAxis`, `Chart.withCAxis` functions:
*)

let styledTernary2 =
    styledTernary
    |> Chart.withCAxis(LinearAxis.init(Title = Title.init("C"), Color = Color.fromKeyword ColorKeyword.DarkCyan))
    


(*** condition: ipynb ***)
#if IPYNB
styledTernary2
#endif // IPYNB

(***hide***)
styledTernary2 |> GenericChart.toChartHTML
(***include-it-raw***)