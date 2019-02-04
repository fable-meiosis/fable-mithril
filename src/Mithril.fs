// ts2fable 0.6.1
module rec ModuleName
open System
open Fable.Core
open Fable.Import.JS

let [<Import("*","module")>] mithriljs: Mithriljs.IExports = jsNative

type [<AllowNullLiteral>] IExports =
    abstract mithriljs: [<ParamArray>] args: ResizeArray<obj option> -> obj option

module Mithriljs =
    let [<Import("buildQueryString","module/mithriljs")>] buildQueryString: BuildQueryString.IExports = jsNative
    let [<Import("fragment","module/mithriljs")>] fragment: Fragment.IExports = jsNative
    let [<Import("jsonp","module/mithriljs")>] jsonp: Jsonp.IExports = jsNative
    let [<Import("m","module/mithriljs")>] m: M.IExports = jsNative
    let [<Import("mount","module/mithriljs")>] mount: Mount.IExports = jsNative
    let [<Import("parseQueryString","module/mithriljs")>] parseQueryString: ParseQueryString.IExports = jsNative
    let [<Import("redraw","module/mithriljs")>] redraw: Redraw.IExports = jsNative
    let [<Import("render","module/mithriljs")>] render: Render.IExports = jsNative
    let [<Import("request","module/mithriljs")>] request: Request.IExports = jsNative
    let [<Import("route","module/mithriljs")>] route: Route.IExports = jsNative
    let [<Import("trust","module/mithriljs")>] trust: Trust.IExports = jsNative
    let [<Import("vnode","module/mithriljs")>] vnode: Vnode.IExports = jsNative

    type [<AllowNullLiteral>] IExports =
        abstract PromisePolyfill: PromisePolyfillStatic
        abstract prototype: obj
        abstract version: string
        abstract buildQueryString: ``object``: obj option -> obj option
        abstract fragment: [<ParamArray>] args: ResizeArray<obj option> -> obj option
        abstract jsonp: url: obj option * args: obj option * [<ParamArray>] args: ResizeArray<obj option> -> obj option
        abstract m: selector: obj option * [<ParamArray>] args: ResizeArray<obj option> -> obj option
        abstract mount: root: obj option * ``component``: obj option -> unit
        abstract parseQueryString: string: obj option -> obj option
        abstract redraw: unit -> unit
        abstract render: dom: obj option * vnodes: obj option -> unit
        abstract request: url: obj option * args: obj option * [<ParamArray>] args: ResizeArray<obj option> -> obj option
        abstract route: root: obj option * defaultRoute: obj option * routes: obj option -> unit
        abstract trust: html: obj option -> obj option
        abstract vnode: tag: obj option * key: obj option * attrs0: obj option * children0: obj option * text: obj option * dom: obj option -> obj option

    type [<AllowNullLiteral>] PromisePolyfill =
        abstract catch: p0: obj option -> obj option
        abstract ``finally``: p0: obj option -> obj option
        abstract ``then``: p0: obj option * p1: obj option -> obj option

    type [<AllowNullLiteral>] PromisePolyfillStatic =
        [<Emit "new $0($1...)">] abstract Create: p0: obj option -> PromisePolyfill
        abstract all: p0: obj option -> obj option
        abstract race: p0: obj option -> obj option
        abstract reject: p0: obj option -> obj option
        abstract resolve: p0: obj option -> obj option

    module PromisePolyfill =
        let [<Import("prototype","module/mithriljs/PromisePolyfill")>] prototype: Prototype.IExports = jsNative

        module Prototype =

            type [<AllowNullLiteral>] IExports =
                abstract ``then``: p0: obj option * p1: obj option -> obj option

    module BuildQueryString =

        type [<AllowNullLiteral>] IExports =
            abstract prototype: obj

    module Fragment =

        type [<AllowNullLiteral>] IExports =
            abstract prototype: obj

    module Jsonp =

        type [<AllowNullLiteral>] IExports =
            abstract prototype: obj

    module M =
        let [<Import("fragment","module/mithriljs/m")>] fragment: Fragment.IExports = jsNative
        let [<Import("trust","module/mithriljs/m")>] trust: Trust.IExports = jsNative

        type [<AllowNullLiteral>] IExports =
            abstract prototype: obj
            abstract fragment: [<ParamArray>] args: ResizeArray<obj option> -> obj option
            abstract trust: html: obj option -> obj option

        module Fragment =

            type [<AllowNullLiteral>] IExports =
                abstract prototype: obj

        module Trust =

            type [<AllowNullLiteral>] IExports =
                abstract prototype: obj

    module Mount =

        type [<AllowNullLiteral>] IExports =
            abstract prototype: obj

    module ParseQueryString =

        type [<AllowNullLiteral>] IExports =
            abstract prototype: obj

    module Redraw =
        let [<Import("sync","module/mithriljs/redraw")>] sync: Sync.IExports = jsNative

        type [<AllowNullLiteral>] IExports =
            abstract prototype: obj
            abstract sync: unit -> unit

        module Sync =

            type [<AllowNullLiteral>] IExports =
                abstract prototype: obj

    module Render =

        type [<AllowNullLiteral>] IExports =
            abstract prototype: obj

    module Request =

        type [<AllowNullLiteral>] IExports =
            abstract prototype: obj

    module Route =
        let [<Import("get","module/mithriljs/route")>] get: Get.IExports = jsNative
        let [<Import("link","module/mithriljs/route")>] link: Link.IExports = jsNative
        let [<Import("param","module/mithriljs/route")>] param: Param.IExports = jsNative
        let [<Import("prefix","module/mithriljs/route")>] prefix: Prefix.IExports = jsNative
        let [<Import("set","module/mithriljs/route")>] set: Set.IExports = jsNative

        type [<AllowNullLiteral>] IExports =
            abstract prototype: obj
            abstract get: unit -> obj option
            abstract link: args0: obj option -> obj option
            abstract param: key0: obj option -> obj option
            abstract prefix: prefix: obj option -> unit
            abstract set: path: obj option * data0: obj option * options: obj option -> unit

        module Get =

            type [<AllowNullLiteral>] IExports =
                abstract prototype: obj

        module Link =

            type [<AllowNullLiteral>] IExports =
                abstract prototype: obj

        module Param =

            type [<AllowNullLiteral>] IExports =
                abstract prototype: obj

        module Prefix =

            type [<AllowNullLiteral>] IExports =
                abstract prototype: obj

        module Set =

            type [<AllowNullLiteral>] IExports =
                abstract prototype: obj

    module Trust =

        type [<AllowNullLiteral>] IExports =
            abstract prototype: obj

    module Vnode =
        let [<Import("normalize","module/mithriljs/vnode")>] normalize: Normalize.IExports = jsNative
        let [<Import("normalizeChildren","module/mithriljs/vnode")>] normalizeChildren: NormalizeChildren.IExports = jsNative

        type [<AllowNullLiteral>] IExports =
            abstract prototype: obj
            abstract normalize: node: obj option -> obj option
            abstract normalizeChildren: input: obj option -> obj option

        module Normalize =

            type [<AllowNullLiteral>] IExports =
                abstract prototype: obj

        module NormalizeChildren =

            type [<AllowNullLiteral>] IExports =
                abstract prototype: obj