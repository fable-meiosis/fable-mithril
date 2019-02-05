// ts2fable 0.6.1
module rec Mag

open System
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

type Hyperscript = Mithril.Hyperscript

type Attrs = obj
type State = obj

type [<AllowNullLiteral>] IExports =
    /// Manually triggers a redraw of mounted components. 
    abstract redraw: unit -> unit
    /// Renders a vnode structure into a DOM element. 
    abstract render: el: Element * vnodes: Mithril.Children -> unit
    /// Mounts a component to a DOM element, enabling it to autoredraw on user events. 
    abstract mount: element: Element * ``component``: Mithril.ComponentTypes<obj option, obj option> -> unit
    /// Unmounts a component from a DOM element. 
    abstract mount: element: Element * ``component``: obj -> unit
    /// Makes an XHR request and returns a promise. 
    abstract request: options: obj -> Promise<'T>
    /// Makes an XHR request and returns a promise. 
    abstract request: url: string * ?options: Mithril.RequestOptions<'T> -> Promise<'T>
    /// Makes a JSON-P request and returns a promise. 
    abstract jsonp: options: obj -> Promise<'T>
    /// Makes a JSON-P request and returns a promise. 
    abstract jsonp: url: string * ?options: Mithril.JsonpOptions -> Promise<'T>

module Mithril =

    type [<AllowNullLiteral>] Lifecycle<'Attrs, 'State> =
        /// The oninit hook is called before a vnode is touched by the virtual DOM engine. 
        abstract oninit: this: 'State * vnode: Vnode<'Attrs, 'State> -> obj option
        /// The oncreate hook is called after a DOM element is created and attached to the document. 
        abstract oncreate: this: 'State * vnode: VnodeDOM<'Attrs, 'State> -> obj option
        /// The onbeforeremove hook is called before a DOM element is detached from the document. If a Promise is returned, Mithril only detaches the DOM element after the promise completes. 
        abstract onbeforeremove: this: 'State * vnode: VnodeDOM<'Attrs, 'State> -> U2<Promise<obj option>, unit>
        /// The onremove hook is called before a DOM element is removed from the document. 
        abstract onremove: this: 'State * vnode: VnodeDOM<'Attrs, 'State> -> obj option
        /// The onbeforeupdate hook is called before a vnode is diffed in a update. 
        abstract onbeforeupdate: this: 'State * vnode: Vnode<'Attrs, 'State> * old: VnodeDOM<'Attrs, 'State> -> U2<bool, unit>
        /// The onupdate hook is called after a DOM element is updated, while attached to the document. 
        abstract onupdate: this: 'State * vnode: VnodeDOM<'Attrs, 'State> -> obj option
        /// WORKAROUND: TypeScript 2.4 does not allow extending an interface with all-optional properties. 
        [<Emit "$0[$1]{{=$2}}">] abstract Item: ``_``: float -> obj option with get, set

    type [<AllowNullLiteral>] Hyperscript =
        /// Creates a virtual element (Vnode). 
        [<Emit "$0($1...)">] abstract Invoke: selector: string * [<ParamArray>] children: ResizeArray<Children> -> Vnode<obj option, obj option>
        /// Creates a virtual element (Vnode). 
        [<Emit "$0($1...)">] abstract Invoke: selector: string * attributes: Attributes * [<ParamArray>] children: ResizeArray<Children> -> Vnode<obj option, obj option>
        /// Creates a virtual element (Vnode). 
        [<Emit "$0($1...)">] abstract Invoke: ``component``: ComponentTypes<Attrs, State> * [<ParamArray>] args: ResizeArray<Children> -> Vnode<Attrs, State>
        /// Creates a virtual element (Vnode). 
        [<Emit "$0($1...)">] abstract Invoke: ``component``: ComponentTypes<Attrs, State> * attributes: obj * [<ParamArray>] args: ResizeArray<Children> -> Vnode<Attrs, State>
        /// Creates a fragment virtual element (Vnode). 
        abstract fragment: attrs: obj * children: ChildArrayOrPrimitive -> Vnode<obj option, obj option>
        /// Turns an HTML string into a virtual element (Vnode). Do not use trust on unsanitized user input. 
        abstract trust: html: string -> Vnode<obj option, obj option>

    type RouteResolver<'State> =
        RouteResolver<obj, 'State>

    type RouteResolver =
        RouteResolver<obj, obj>

    type [<AllowNullLiteral>] RouteResolver<'Attrs, 'State> =
        /// The onmatch hook is called when the router needs to find a component to render. 
        abstract onmatch: this: RouteResolver<'Attrs, 'State> * args: 'Attrs * requestedPath: string -> U3<ComponentTypes<obj option, obj option>, Promise<obj option>, unit>
        /// The render method is called on every redraw for a matching route. 
        abstract render: this: RouteResolver<'Attrs, 'State> * vnode: Vnode<'Attrs, 'State> -> Children

    /// This represents a key-value mapping linking routes to components. 
    type [<AllowNullLiteral>] RouteDefs =
        /// The key represents the route. The value represents the corresponding component. 
        [<Emit "$0[$1]{{=$2}}">] abstract Item: url: string -> U2<ComponentTypes<obj option, obj option>, RouteResolver<obj option, obj option>> with get, set

    type [<AllowNullLiteral>] RouteOptions =
        /// Routing parameters. If path has routing parameter slots, the properties of this object are interpolated into the path string. 
        abstract replace: bool option with get, set
        /// The state object to pass to the underlying history.pushState / history.replaceState call. 
        abstract state: obj option with get, set
        /// The title string to pass to the underlying history.pushState / history.replaceState call. 
        abstract title: string option with get, set

    type [<AllowNullLiteral>] Route =
        /// Creates application routes and mounts Components and/or RouteResolvers to a DOM element. 
        [<Emit "$0($1...)">] abstract Invoke: element: Element * defaultRoute: string * routes: RouteDefs -> unit
        /// Returns the last fully resolved routing path, without the prefix. 
        abstract get: unit -> string
        /// Redirects to a matching route or to the default route if no matching routes can be found. 
        abstract set: route: string * ?data: obj option * ?options: RouteOptions -> unit
        /// Defines a router prefix which is a fragment of the URL that dictates the underlying strategy used by the router. 
        abstract prefix: urlFragment: string -> unit
        /// This method is meant to be used in conjunction with an <a> Vnode's oncreate hook. 
        abstract link: vnode: Vnode<obj option, obj option> -> (Event -> obj option)
        /// Returns the named parameter value from the current route. 
        abstract param: name: string -> string
        /// Gets all route parameters. 
        abstract param: unit -> obj option

    type [<AllowNullLiteral>] RequestOptions<'T> =
        /// The HTTP method to use. 
        abstract ``method``: string option with get, set
        /// The data to be interpolated into the URL and serialized into the querystring (for GET requests) or body (for other types of requests). 
        abstract data: obj option with get, set
        /// Whether the request should be asynchronous. Defaults to true. 
        abstract async: bool option with get, set
        /// A username for HTTP authorization. 
        abstract user: string option with get, set
        /// A password for HTTP authorization. 
        abstract password: string option with get, set
        /// Whether to send cookies to 3rd party domains. 
        abstract withCredentials: bool option with get, set
        /// Exposes the underlying XMLHttpRequest object for low-level configuration. 
        abstract config: xhr: XMLHttpRequest * options: RequestOptions<'T> -> U2<XMLHttpRequest, unit>
        /// Headers to append to the request before sending it. 
        abstract headers: obj option with get, set
        /// A constructor to be applied to each object in the response. 
        abstract ``type``: obj option with get, set
        /// A serialization method to be applied to data. Defaults to JSON.stringify, or if options.data is an instance of FormData, defaults to the identity function. 
        abstract serialize: data: obj option -> obj option
        /// A deserialization method to be applied to the response. Defaults to a small wrapper around JSON.parse that returns null for empty responses. 
        abstract deserialize: data: string -> 'T
        /// A hook to specify how the XMLHttpRequest response should be read. Useful for reading response headers and cookies. Defaults to a function that returns xhr.responseText 
        abstract extract: xhr: XMLHttpRequest * options: RequestOptions<'T> -> 'T
        /// Force the use of the HTTP body section for data in GET requests when set to true,
        /// or the use of querystring for other HTTP methods when set to false.
        /// Defaults to false for GET requests and true for other methods.
        abstract useBody: bool option with get, set
        /// If false, redraws mounted components upon completion of the request. If true, it does not. 
        abstract background: bool option with get, set

    type [<AllowNullLiteral>] JsonpOptions =
        /// The data to be interpolated into the URL and serialized into the querystring. 
        abstract data: obj option with get, set
        /// A constructor to be applied to each object in the response. 
        abstract ``type``: obj option with get, set
        /// The name of the function that will be called as the callback. 
        abstract callbackName: string option with get, set
        /// The name of the querystring parameter name that specifies the callback name. 
        abstract callbackKey: string option with get, set
        /// If false, redraws mounted components upon completion of the request. If true, it does not. 
        abstract background: bool option with get, set

    type [<AllowNullLiteral>] Static =
        inherit Hyperscript
        abstract route: Route with get, set
        abstract mount: obj with get, set
        abstract withAttr: obj with get, set
        abstract render: obj with get, set
        abstract redraw: obj with get, set
        abstract request: obj with get, set
        abstract jsonp: obj with get, set
        /// Returns an object with key/value pairs parsed from a string of the form: ?a=1&b=2 
        abstract parseQueryString: queryString: string -> obj
        /// Turns the key/value pairs of an object into a string of the form: a=1&b=2 
        abstract buildQueryString: values: StaticBuildQueryStringValues -> string
        /// A string containing the semver value for the current Mithril release. 
        abstract version: string with get, set

    type [<AllowNullLiteral>] StaticBuildQueryStringValues =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: p: string -> obj option with get, set

    type Child =
        U4<Vnode<obj option, obj option>, string, float, bool> option

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Child =
        let ofVnodeOption v: Child = v |> Microsoft.FSharp.Core.Option.map U4.Case1
        let ofVnode v: Child = v |> U4.Case1 |> Some
        let isVnode (v: Child) = match v with None -> false | Some o -> match o with U4.Case1 _ -> true | _ -> false
        let asVnode (v: Child) = match v with None -> None | Some o -> match o with U4.Case1 o -> Some o | _ -> None
        let ofStringOption v: Child = v |> Microsoft.FSharp.Core.Option.map U4.Case2
        let ofString v: Child = v |> U4.Case2 |> Some
        let isString (v: Child) = match v with None -> false | Some o -> match o with U4.Case2 _ -> true | _ -> false
        let asString (v: Child) = match v with None -> None | Some o -> match o with U4.Case2 o -> Some o | _ -> None
        let ofFloatOption v: Child = v |> Microsoft.FSharp.Core.Option.map U4.Case3
        let ofFloat v: Child = v |> U4.Case3 |> Some
        let isFloat (v: Child) = match v with None -> false | Some o -> match o with U4.Case3 _ -> true | _ -> false
        let asFloat (v: Child) = match v with None -> None | Some o -> match o with U4.Case3 o -> Some o | _ -> None
        let ofBoolOption v: Child = v |> Microsoft.FSharp.Core.Option.map U4.Case4
        let ofBool v: Child = v |> U4.Case4 |> Some
        let isBool (v: Child) = match v with None -> false | Some o -> match o with U4.Case4 _ -> true | _ -> false
        let asBool (v: Child) = match v with None -> None | Some o -> match o with U4.Case4 o -> Some o | _ -> None

    type [<AllowNullLiteral>] ChildArray =
        inherit Array<Children>

    type Children =
        U2<Child, ChildArray>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Children =
        let ofChild v: Children = v |> U2.Case1
        let isChild (v: Children) = match v with U2.Case1 _ -> true | _ -> false
        let asChild (v: Children) = match v with U2.Case1 o -> Some o | _ -> None
        let ofChildArray v: Children = v |> U2.Case2
        let isChildArray (v: Children) = match v with U2.Case2 _ -> true | _ -> false
        let asChildArray (v: Children) = match v with U2.Case2 o -> Some o | _ -> None

    type ChildArrayOrPrimitive =
        U4<ChildArray, string, float, bool>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module ChildArrayOrPrimitive =
        let ofChildArray v: ChildArrayOrPrimitive = v |> U4.Case1
        let isChildArray (v: ChildArrayOrPrimitive) = match v with U4.Case1 _ -> true | _ -> false
        let asChildArray (v: ChildArrayOrPrimitive) = match v with U4.Case1 o -> Some o | _ -> None
        let ofString v: ChildArrayOrPrimitive = v |> U4.Case2
        let isString (v: ChildArrayOrPrimitive) = match v with U4.Case2 _ -> true | _ -> false
        let asString (v: ChildArrayOrPrimitive) = match v with U4.Case2 o -> Some o | _ -> None
        let ofFloat v: ChildArrayOrPrimitive = v |> U4.Case3
        let isFloat (v: ChildArrayOrPrimitive) = match v with U4.Case3 _ -> true | _ -> false
        let asFloat (v: ChildArrayOrPrimitive) = match v with U4.Case3 o -> Some o | _ -> None
        let ofBool v: ChildArrayOrPrimitive = v |> U4.Case4
        let isBool (v: ChildArrayOrPrimitive) = match v with U4.Case4 _ -> true | _ -> false
        let asBool (v: ChildArrayOrPrimitive) = match v with U4.Case4 o -> Some o | _ -> None

    type Vnode<'State> =
        Vnode<obj, 'State>

    type Vnode =
        Vnode<obj, obj>

    /// Virtual DOM nodes, or vnodes, are Javascript objects that represent an element (or parts of the DOM). 
    type [<AllowNullLiteral>] Vnode<'Attrs, 'State> =
        /// The nodeName of a DOM element. It may also be the string [ if a vnode is a fragment, # if it's a text vnode, or < if it's a trusted HTML vnode. Additionally, it may be a component. 
        abstract tag: U2<string, ComponentTypes<'Attrs, 'State>> with get, set
        /// A hashmap of DOM attributes, events, properties and lifecycle methods. 
        abstract attrs: 'Attrs with get, set
        /// An object that is persisted between redraws. In component vnodes, state is a shallow clone of the component object. 
        abstract state: 'State with get, set
        /// The value used to map a DOM element to its respective item in an array of data. 
        abstract key: U2<string, float> option with get, set
        /// In most vnode types, the children property is an array of vnodes. For text and trusted HTML vnodes, The children property is either a string, a number or a boolean. 
        abstract children: ChildArrayOrPrimitive option with get, set
        /// This is used instead of children if a vnode contains a text node as its only child.
        /// This is done for performance reasons.
        /// Component vnodes never use the text property even if they have a text node as their only child.
        abstract text: U3<string, float, bool> option with get, set

    type VnodeDOM<'State> =
        VnodeDOM<obj, 'State>

    type VnodeDOM =
        VnodeDOM<obj, obj>

    type [<AllowNullLiteral>] VnodeDOM<'Attrs, 'State> =
        inherit Vnode<'Attrs, 'State>
        /// Points to the element that corresponds to the vnode. 
        abstract dom: Element with get, set
        /// This defines the number of DOM elements that the vnode represents (starting from the element referenced by the dom property). 
        abstract domSize: float option with get, set

    type CVnode =
        CVnode<obj>

    type [<AllowNullLiteral>] CVnode<'A> =
        inherit Vnode<'A, ClassComponent<'A>>

    type CVnodeDOM =
        CVnodeDOM<obj>

    type [<AllowNullLiteral>] CVnodeDOM<'A> =
        inherit VnodeDOM<'A, ClassComponent<'A>>

    type Component<'State> =
        Component<obj, 'State>

    type Component =
        Component<obj, obj>

    /// Components are a mechanism to encapsulate parts of a view to make code easier to organize and/or reuse.
    /// Any Javascript object that has a view method can be used as a Mithril component.
    /// Components can be consumed via the m() utility.
    type [<AllowNullLiteral>] Component<'Attrs, 'State> =
        inherit Lifecycle<'Attrs, 'State>
        /// Creates a view out of virtual elements. 
        abstract view: this: 'State * vnode: Vnode<'Attrs, 'State> -> U2<Children, unit> option

    type ClassComponent =
        ClassComponent<obj>

    /// Components are a mechanism to encapsulate parts of a view to make code easier to organize and/or reuse.
    /// Any class that implements a view method can be used as a Mithril component.
    /// Components can be consumed via the m() utility.
    type [<AllowNullLiteral>] ClassComponent<'A> =
        inherit Lifecycle<'A, ClassComponent<'A>>
        /// The oninit hook is called before a vnode is touched by the virtual DOM engine. 
        abstract oninit: vnode: Vnode<'A, ClassComponent<'A>> -> obj option
        /// The oncreate hook is called after a DOM element is created and attached to the document. 
        abstract oncreate: vnode: VnodeDOM<'A, ClassComponent<'A>> -> obj option
        /// The onbeforeremove hook is called before a DOM element is detached from the document. If a Promise is returned, Mithril only detaches the DOM element after the promise completes. 
        abstract onbeforeremove: vnode: VnodeDOM<'A, ClassComponent<'A>> -> U2<Promise<obj option>, unit>
        /// The onremove hook is called before a DOM element is removed from the document. 
        abstract onremove: vnode: VnodeDOM<'A, ClassComponent<'A>> -> obj option
        /// The onbeforeupdate hook is called before a vnode is diffed in a update. 
        abstract onbeforeupdate: vnode: Vnode<'A, ClassComponent<'A>> * old: VnodeDOM<'A, ClassComponent<'A>> -> U2<bool, unit>
        /// The onupdate hook is called after a DOM element is updated, while attached to the document. 
        abstract onupdate: vnode: VnodeDOM<'A, ClassComponent<'A>> -> obj option
        /// Creates a view out of virtual elements. 
        abstract view: vnode: Vnode<'A, ClassComponent<'A>> -> U2<Children, unit> option

    type FactoryComponent =
        FactoryComponent<obj>

    type [<AllowNullLiteral>] FactoryComponent<'A> =
        [<Emit "$0($1...)">] abstract Invoke: vnode: Vnode<'A> -> Component<'A>

    type ClosureComponent =
        ClosureComponent<obj>

    type ClosureComponent<'A> =
        FactoryComponent<'A>

    type Comp<'State> =
        Comp<obj, 'State>

    type Comp =
        Comp<obj, obj>

    type [<AllowNullLiteral>] Comp<'Attrs, 'State> =
        interface end

    type ComponentTypes<'S> =
        ComponentTypes<obj, 'S>

    type ComponentTypes =
        ComponentTypes<obj, obj>

    type ComponentTypes<'A, 'S> =
        U3<Component<'A, 'S>, (CVnode<'A> -> obj), FactoryComponent<'A>>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module ComponentTypes =
        let ofComponent v: ComponentTypes<'A, 'S> = v |> U3.Case1
        let isComponent (v: ComponentTypes<'A, 'S>) = match v with U3.Case1 _ -> true | _ -> false
        let asComponent (v: ComponentTypes<'A, 'S>) = match v with U3.Case1 o -> Some o | _ -> None
        let ofCreate v: ComponentTypes<'A, 'S> = v |> U3.Case2
        let isCreate (v: ComponentTypes<'A, 'S>) = match v with U3.Case2 _ -> true | _ -> false
        let asCreate (v: ComponentTypes<'A, 'S>) = match v with U3.Case2 o -> Some o | _ -> None
        let ofFactoryComponent v: ComponentTypes<'A, 'S> = v |> U3.Case3
        let isFactoryComponent (v: ComponentTypes<'A, 'S>) = match v with U3.Case3 _ -> true | _ -> false
        let asFactoryComponent (v: ComponentTypes<'A, 'S>) = match v with U3.Case3 o -> Some o | _ -> None

    /// This represents the attributes available for configuring virtual elements, beyond the applicable DOM attributes. 
    type [<AllowNullLiteral>] Attributes =
        inherit Lifecycle<obj option, obj option>
        /// The class name(s) for this virtual element, as a space-separated list. 
        abstract className: string option with get, set
        /// The class name(s) for this virtual element, as a space-separated list. 
        abstract ``class``: string option with get, set
        /// A key to optionally associate with this element. 
        abstract key: U2<string, float> option with get, set
        /// Any other virtual element properties, including attributes and event handlers. 
        [<Emit "$0[$1]{{=$2}}">] abstract Item: property: string -> obj option with get, set

   
    module RedrawService =

        type [<AllowNullLiteral>] Static =
            abstract render: obj with get, set
            abstract redraw: obj with get, set       


    module RenderService =

        type [<AllowNullLiteral>] Static =
            abstract render: obj with get, set


    module RequestService =

        type [<AllowNullLiteral>] Static =
            abstract request: obj with get, set
            abstract jsonp: obj with get, set


    module Stream =

        type [<AllowNullLiteral>] Stream<'T> =
            /// Returns the value of the stream. 
            [<Emit "$0($1...)">] abstract Invoke: unit -> 'T
            /// Sets the value of the stream. 
            [<Emit "$0($1...)">] abstract Invoke: value: 'T -> Stream<'T>
            /// Creates a dependent stream whose value is set to the result of the callback function. 
            abstract map: f: ('T -> U3<Stream<'T>, 'T, unit>) -> Stream<'T>
            /// Creates a dependent stream whose value is set to the result of the callback function. 
            abstract map: f: ('T -> U2<Stream<'U>, 'U>) -> Stream<'U>
            /// This method is functionally identical to stream. It exists to conform to Fantasy Land's Applicative specification. 
            abstract ``of``: ?``val``: 'T -> Stream<'T>
            /// Apply. 
            abstract ap: f: Stream<('T -> 'U)> -> Stream<'U>
            /// A co-dependent stream that unregisters dependent streams when set to true. 
            abstract ``end``: Stream<bool> with get, set
            /// When a stream is passed as the argument to JSON.stringify(), the value of the stream is serialized. 
            abstract toJSON: unit -> string
            /// Returns the value of the stream. 
            abstract valueOf: unit -> 'T

        type [<AllowNullLiteral>] Static =
            /// Creates a stream. 
            [<Emit "$0($1...)">] abstract Invoke: ?value: 'T -> Stream<'T>
            /// Creates a computed stream that reactively updates if any of its upstreams are updated. 
            abstract combine: combiner: (ResizeArray<obj option> -> 'T) * streams: Array<Stream<obj option>> -> Stream<'T>
            /// Creates a stream whose value is the array of values from an array of streams. 
            abstract merge: streams: Array<Stream<obj option>> -> Stream<ResizeArray<obj option>>
            /// Creates a new stream with the results of calling the function on every incoming stream with and accumulator and the incoming value. 
            abstract scan: fn: ('U -> 'T -> 'U) * acc: 'U * stream: Stream<'T> -> Stream<'U>
            /// Takes an array of pairs of streams and scan functions and merges all those streams using the given functions into a single stream. 
            abstract scanMerge: pairs: Array<Stream<'T> * ('U -> 'T -> 'U)> * acc: 'U -> Stream<'U>
            /// Takes an array of pairs of streams and scan functions and merges all those streams using the given functions into a single stream. 
            abstract scanMerge: pairs: Array<Stream<obj option> * ('U -> obj option -> 'U)> * acc: 'U -> Stream<'U>
            /// A special value that can be returned to stream callbacks to halt execution of downstreams. 
            abstract HALT: obj option

// let [<Import("*","module")>] RedrawService: Mithril.RedrawService.Static = jsNative            
// let [<Import("*","module")>] RenderService: Mithril.RenderService.Static = jsNative
// let [<Import("*","module")>] RequestService: Mithril.RequestService.Static = jsNative
// let [<Import("*","module")>] Stream: Mithril.Stream.Static = jsNative
// let [<Import("*","module")>] h: Hyperscript = jsNative
// let [<Import("*","module")>] Mithril: Mithril.Static = jsNative

let [<Import("*","module")>] MithrilRender: IExports = jsNative
