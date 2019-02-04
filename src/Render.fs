// ts2fable 0.6.1
module rec Render
open System
open Fable.Core
open Fable.Import.JS

let [<Import("*","module")>] RenderService: RenderService.Static = jsNative

module RenderService =

    type [<AllowNullLiteral>] Static =
        abstract render: obj with get, set