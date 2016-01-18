module Hex

open System
open System.Globalization

let ToByteArray(hex : string) =
    [0 .. 2 .. (hex.Length - 1)]
    |> Seq.map (fun i -> hex.Substring(i, 2))
    |> Seq.map (fun x -> Byte.Parse(x, NumberStyles.AllowHexSpecifier))
    |> Array.ofSeq

let ToHex(bytes : byte[]) =
    String.Join("", bytes |> Seq.map (fun x -> String.Format("{0:x2}", x)))
