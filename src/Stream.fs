// ts2fable 0.6.1
module rec ModuleName
open System
open Fable.Core
open Fable.Import.JS

let [<Import("*","module")>] Stream: Stream.Static = jsNative

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