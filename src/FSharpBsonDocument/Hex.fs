module Hex

open System
open System.Globalization

let ToByteArray (hex : string) =
    let hex = if hex.Length % 2 = 0 then hex else "0" + hex
    [0 .. 2 .. (hex.Length - 1)]
    |> Seq.map (fun i -> hex.Substring(i, 2))
    |> Seq.map (fun x -> Byte.Parse(x, NumberStyles.AllowHexSpecifier))
    |> Array.ofSeq

let ToHex (bytes : byte[]) =
    String.Join("", bytes |> Seq.map (fun x -> String.Format("{0:x2}", x)))
