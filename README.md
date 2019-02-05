# Fable mithril: WIP

Fable bindings for [MithrilJS 2.x](https://github.com/MithrilJS/mithril.js) micro UI "framework".

## Why?

Mithril can be used with the excellent [Meiosis pattern](https://meiosis.js.org/) as building blocks for next gen _elmish_ like architecture.

## Status

WIP: Not yet tested

## Usage

See [Fable interop docs](https://fable.io/docs/interacting.html)

Aiming for something like this:

```fsharp
module MithrilApp

open Mag
open Fable.Import.Browser

let root = document.body
m.render (root, "hello") |> ignore
```

However the `Mithril.Children` type generated does not currently support a single `string` as the type.

```fsharp
type [<AllowNullLiteral>] IExports =
  abstract render: el: Element * vnodes: Mithril.Children -> unit`
```

In JavaScript a variable can have several types but not in F#. Fable provides `U2`, `U3`, etc. to mimic this behavior. See the [erase section](https://fable.io/docs/interacting.html#erase-attribute) of the documentation.

Also check out [F# Interop with Javascript in Fable: The Complete Guide](https://medium.com/@zaid.naom/f-interop-with-javascript-in-fable-the-complete-guide-ccc5b896a59f)

PS: Please help out improving the bindings and the sample app bindings consumer ;)

## Overview

This example aims to showcase how to create custom Fable bindings for JS libraries.

The bindings in `Mihtril.fs` were created using `mithril.d.ts`, created from the raw `mithril.js` file using [dts](https://github.com/Microsoft/dts-gen#how-do-i-use-it) CLI.

Checkout other sample apps at [fable2-samples](https://github.com/fable2-samples)

## Requirements

- [dotnet SDK](https://www.microsoft.com/net/download/core) 2.1 or higher
- [Paket](https://fsprojects.github.io/Paket/installation.html) to manage F# dependencies
- [node.js](https://nodejs.org) with [npm](https://www.npmjs.com/)
- An F# editor like Visual Studio, Visual Studio Code with [Ionide](http://ionide.io/) or [JetBrains Rider](https://www.jetbrains.com/rider/).

## Building and running the app

### install JS dependencies

- `yarn install`

### install F# dependencies

- Windows: `.paket/paket.exe install`
- Non-Windows: `mono .paket/paket.exe install`

Alternatively install paket as a global .NET tool

```bash
$ dotnet tool install --tool-path ".paket" Paket --add-source https://api.nuget.org/v3/index.json --framework netcoreapp2.1
```

With defaults, try simply: `$ dotnet tool install Paket`

In this case, make sure that the install location of `paket` is in your system `PATH`, see: [dotnet-tool-install](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-tool-install)

### Start and run

- `npm start` to compile and watch with fable-splitter.

Alternatively:

- `npm run build` - same but outputs javascript to `/out`.

## Add F# Modules

While fable-splitter is watching with one of above `npm` commands:

- Add `nuget ModuleName` to paket.dependencies and run paket install command above.
- Add `ModuleName` to src/paket.references

## Source Files

- `App.fsporj` - add source paths here. Note `paket.references` is referenced here.
- `App.fs` - starting point.
- `Util/File.fs` - sample lib file.
