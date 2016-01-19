namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type BsonUndefinedTests =
    class
        new() =
            {}

        [<Fact>]
        member this.``default constructor should initialize instance``() =
            let result = BsonUndefined() :> IBsonUndefined
            Assert.Equal(BsonType.Undefined, result.Type)

        [<Fact>]
        member this.``ToString should return expected result``() =
            let subject = BsonUndefined() :> IBsonUndefined
            let result = subject.ToString()
            Assert.Equal("undefined", result)

        [<Fact>]
        member this.``Type should return expected result``() =
            let subject = BsonUndefined() :> IBsonUndefined
            let result = subject.Type
            Assert.Equal(BsonType.Undefined, result)
   end
