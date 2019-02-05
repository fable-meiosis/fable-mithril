module HyperScript

open System
open Fable.Import.JS
open Fable.Core
open Fable.Core.JsInterop

type MithrilElementType<'props> = interface end

type MithrilComponentType<'props> =
    inherit MithrilElementType<'props>
    abstract displayName: string option with get, set

type IProp = obj

type [<AllowNullLiteral>] MithrilElement =
    interface end


type HTMLNode =
    | Text of string
    | RawText of string
    | Node of string * IProp seq * MithrilElement seq
    | List of MithrilElement seq
    | Empty
with interface MithrilElement
    /// Instantiate a DOM Mithril element
    let inline domEl (tag: string) (props: IHTMLProp seq) (children: MithrilElement seq): MithrilElement =
        createElement(tag, keyValueList CaseRules.LowerFirst props, children)

    /// Instantiate a DOM Mithril element (void)
    let inline voidEl (tag: string) (props: IHTMLProp seq) : MithrilElement =
        createElement(tag, keyValueList CaseRules.LowerFirst props, [])

    /// Instantiate an SVG Mithril element
    let inline svgEl (tag: string) (props: IProp seq) (children: MithrilElement seq): MithrilElement =
        createElement(tag, keyValueList CaseRules.LowerFirst props, children)


module Helpers =
    [<Import("createElement", from="react")>]
    let createElement(comp: obj, props: obj, [<ParamList>] children: obj): MithrilElement =
        jsNative