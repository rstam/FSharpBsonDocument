namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type BsonNullTests =
    class
        new() =
            {}

        [<Fact>]
        member this.``default constructor should initialize instance``() =
            let result = BsonNull() :> IBsonNull
            Assert.Equal(BsonType.Null, result.Type)

        [<Fact>]
        member this.``ToString should return expected result``() =
            let subject = BsonNull() :> IBsonNull
            let result = subject.ToString()
            Assert.Equal("null", result)

        [<Fact>]
        member this.``Type should return expected result``() =
            let subject = BsonNull() :> IBsonNull
            let result = subject.Type
            Assert.Equal(BsonType.Null, result)
   end
