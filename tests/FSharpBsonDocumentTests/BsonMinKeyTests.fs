namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type BsonMinKeyTests =
    class
        new() =
            {}

        [<Fact>]
        member this.``default constructor should initialize instance``() =
            let result = BsonMinKey() :> IBsonMinKey
            Assert.Equal(BsonType.MinKey, result.Type)

        [<Fact>]
        member this.``ToString should return expected result``() =
            let subject = BsonMinKey() :> IBsonMinKey
            let result = subject.ToString()
            Assert.Equal("{ \"$minKey\" : 1 }", result)

        [<Fact>]
        member this.``Type should return expected result``() =
            let subject = BsonMinKey() :> IBsonMinKey
            let result = subject.Type
            Assert.Equal(BsonType.MinKey, result)
   end
