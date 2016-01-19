namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type BsonMaxKeyTests =
    class
        new() =
            {}

        [<Fact>]
        member this.``default constructor should initialize instance``() =
            let result = BsonMaxKey() :> IBsonMaxKey
            Assert.Equal(BsonType.MaxKey, result.Type)

        [<Fact>]
        member this.``ToString should return expected result``() =
            let subject = BsonMaxKey() :> IBsonMaxKey
            let result = subject.ToString()
            Assert.Equal("{ \"$maxKey\" : 1 }", result)

        [<Fact>]
        member this.``Type should return expected result``() =
            let subject = BsonMaxKey() :> IBsonMaxKey
            let result = subject.Type
            Assert.Equal(BsonType.MaxKey, result)
   end
