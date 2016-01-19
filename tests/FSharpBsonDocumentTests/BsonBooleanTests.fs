namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type BsonBooleanTests =
    class
        new() =
            {}

        [<Theory>]
        [<InlineData(false)>]
        [<InlineData(true)>]
        member this.``constructor should initialize instance``(value : bool) =
            let result = BsonBoolean value :> IBsonBoolean
            Assert.Equal(BsonType.Boolean, result.Type)
            Assert.Equal(value, result.Value)

        [<Fact>]
        member this.``default constructor should initialize instance``() =
            let result = BsonBoolean() :> IBsonBoolean
            Assert.Equal(BsonType.Boolean, result.Type)
            Assert.Equal(false, result.Value)

        [<Theory>]
        [<InlineData(false, "false")>]
        [<InlineData(true, "true")>]
        member this.``ToString should return expected result``(value : bool, expectedResult : string) =
            let subject = BsonBoolean value :> IBsonBoolean
            let result = subject.ToString()
            Assert.Equal(expectedResult, result)

        [<Fact>]
        member this.``Type should return expected result``() =
            let subject = BsonBoolean() :> IBsonBoolean
            let result = subject.Type
            Assert.Equal(BsonType.Boolean, result)
 
        [<Theory>]
        [<InlineData(false)>]
        [<InlineData(true)>]
        member this.``Value should return expected result``(value : bool) =
            let subject = BsonBoolean value :> IBsonBoolean
            let result = subject.Value
            Assert.Equal(value, result)
   end
