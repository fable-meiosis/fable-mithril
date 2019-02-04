// ts2fable 0.6.1
module rec Request
open System
open Fable.Core
open Fable.Import.JS

let [<Import("*","module")>] RequestService: RequestService.Static = jsNative

module RequestService =

    type [<AllowNullLiteral>] Static =
        abstract request: obj with get, set
        abstract jsonp: obj with get, set