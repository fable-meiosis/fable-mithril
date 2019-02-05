module MithrilApp

open Mag
open Fable.Import.Browser

let root = document.body
type Txt = string option
let x = Some "hello"
m.render (root, x) |> ignore

printfn "Hello Mithril world"
