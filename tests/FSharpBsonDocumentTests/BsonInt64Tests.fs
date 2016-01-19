namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type BsonInt64Tests =
    class
        new() =
            {}

        [<Theory>]
        [<InlineData(0L)>]
        [<InlineData(1L)>]
        [<InlineData(-1L)>]
        member this.``constructor should initialize instance``(value : int64) =
            let result = BsonInt64 value :> IBsonInt64
            Assert.Equal(BsonType.Int64, result.Type)
            Assert.Equal(value, result.Value)

        [<Fact>]
        member this.``default constructor should initialize instance``() =
            let result = BsonInt64() :> IBsonInt64
            Assert.Equal(BsonType.Int64, result.Type)
            Assert.Equal(0L, result.Value)

        [<Theory>]
        [<InlineData(0L, "0L")>]
        [<InlineData(1L, "1L")>]
        [<InlineData(-1L, "-1L")>]
        member this.``ToString should return expected result``(value : int64, expectedResult : string) =
            let subject = BsonInt64 value :> IBsonInt64
            let result = subject.ToString()
            Assert.Equal(expectedResult, result)

        [<Fact>]
        member this.``Type should return expected result``() =
            let subject = BsonInt64() :> IBsonInt64
            let result = subject.Type
            Assert.Equal(BsonType.Int64, result)
 
        [<Theory>]
        [<InlineData(0L)>]
        [<InlineData(1L)>]
        [<InlineData(-1L)>]
        member this.``Value should return expected result``(value : int64) =
            let subject = BsonInt64 value :> IBsonInt64
            let result = subject.Value
            Assert.Equal(value, result)
   end
