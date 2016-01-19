namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type BsonInt32Tests =
    class
        new() =
            {}

        [<Theory>]
        [<InlineData(0)>]
        [<InlineData(1)>]
        [<InlineData(-1)>]
        member this.``constructor should initialize instance``(value : int) =
            let result = BsonInt32 value :> IBsonInt32
            Assert.Equal(BsonType.Int32, result.Type)
            Assert.Equal(value, result.Value)

        [<Fact>]
        member this.``default constructor should initialize instance``() =
            let result = BsonInt32() :> IBsonInt32
            Assert.Equal(BsonType.Int32, result.Type)
            Assert.Equal(0, result.Value)

        [<Theory>]
        [<InlineData(0, "0")>]
        [<InlineData(1, "1")>]
        [<InlineData(-1, "-1")>]
        member this.``ToString should return expected result``(value : int, expectedResult : string) =
            let subject = BsonInt32 value :> IBsonInt32
            let result = subject.ToString()
            Assert.Equal(expectedResult, result)

        [<Fact>]
        member this.``Type should return expected result``() =
            let subject = BsonInt32() :> IBsonInt32
            let result = subject.Type
            Assert.Equal(BsonType.Int32, result)
 
        [<Theory>]
        [<InlineData(0)>]
        [<InlineData(1)>]
        [<InlineData(-1)>]
        member this.``Value should return expected result``(value : int) =
            let subject = BsonInt32 value :> IBsonInt32
            let result = subject.Value
            Assert.Equal(value, result)
   end
