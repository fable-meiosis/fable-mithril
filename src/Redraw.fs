// ts2fable 0.6.1
module rec ReDraw
open System
open Fable.Core
open Fable.Import.JS

let [<Import("*","module")>] RedrawService: RedrawService.Static = jsNative

module RedrawService =

    type [<AllowNullLiteral>] Static =
        abstract render: obj with get, set
        abstract redraw: obj with get, set