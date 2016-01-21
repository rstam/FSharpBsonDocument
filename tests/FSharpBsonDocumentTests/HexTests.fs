namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type HexTests =
    class
        new() =
            {}

        [<Theory>]
        [<InlineData("", 0, 0)>]
        [<InlineData("0", 1, 0)>]
        [<InlineData("00", 1, 0)>]
        [<InlineData("001", 2, 0)>]
        [<InlineData("0001", 2, 0)>]
        [<InlineData("000102", 3, 0)>]
        [<InlineData("000102", 3, 0)>]
        [<InlineData("f0", 1, 0xf0)>]
        [<InlineData("f0f1", 2, 0xf0)>]
        [<InlineData("f0f1f2", 3, 0xf0)>]
        member this.``ToByteArray should return expected result``(value : string, length : int, offset : int) =
            let bytes = Seq.init length (fun i -> byte (offset + i)) |> Seq.toArray
            let result = Hex.ToByteArray(value)
            Assert.Equal<byte>(bytes, result)

        [<Theory>]
        [<InlineData(0, 0, "")>]
        [<InlineData(1, 0, "00")>]
        [<InlineData(2, 0, "0001")>]
        [<InlineData(3, 0, "000102")>]
        [<InlineData(1, 0xf0, "f0")>]
        [<InlineData(2, 0xf0, "f0f1")>]
        [<InlineData(3, 0xf0, "f0f1f2")>]
        member this.``ToHex should return expected result``(length : int, offset : int, expectedResult : string) =
            let bytes = Seq.init length (fun i -> byte (offset + i)) |> Seq.toArray
            let result = Hex.ToHex(bytes)
            Assert.Equal(expectedResult, result)
    end
