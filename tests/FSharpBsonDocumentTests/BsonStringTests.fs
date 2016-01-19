namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type BsonStringTests =
    class
        new() =
            {}

        [<Theory>]
        [<InlineData("")>]
        [<InlineData("abc")>]
        member this.``constructor should initialize instance``(value : string) =
            let result = BsonString value :> IBsonString
            Assert.Equal(BsonType.String, result.Type)
            Assert.Equal(value, result.Value)

        [<Fact>]
        member this.``default constructor should initialize instance``() =
            let result = BsonString() :> IBsonString
            Assert.Equal(BsonType.String, result.Type)
            Assert.Equal(null, result.Value)

        [<Theory>]
        [<InlineData("", "\"\"")>]
        [<InlineData("abc", "\"abc\"")>]
        [<InlineData("\"abc\"", "\"\"\"abc\"\"\"")>]
        member this.``ToString should return expected result``(value : string, expectedResult : string) =
            let subject = BsonString value :> IBsonString
            let result = subject.ToString()
            Assert.Equal(expectedResult, result)

        [<Fact>]
        member this.``Type should return expected result``() =
            let subject = BsonString() :> IBsonString
            let result = subject.Type
            Assert.Equal(BsonType.String, result)
 
        [<Theory>]
        [<InlineData("")>]
        [<InlineData("abc")>]
        member this.``Value should return expected result``(value : string) =
            let subject = BsonString value :> IBsonString
            let result = subject.Value
            Assert.Equal(value, result)
   end
