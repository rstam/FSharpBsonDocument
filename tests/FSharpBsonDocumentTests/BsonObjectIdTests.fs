namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type BsonObjectIdTests =
    class
        new() =
            {}

        [<Fact>]
        member this.``constructor should initialize instance``() =
            let value = ObjectId.NewId()
            let result = BsonObjectId value :> IBsonObjectId
            Assert.Equal(BsonType.ObjectId, result.Type)
            Assert.Equal(value, result.Value)

        [<Fact>]
        member this.``default constructor should initialize instance``() =
            let result = BsonObjectId() :> IBsonObjectId
            Assert.Equal(BsonType.ObjectId, result.Type)
            Assert.Equal(ObjectId.Empty, result.Value)

        [<Fact>]
        member this.``ToString should return expected result``() =
            let subject = BsonObjectId ObjectId.Empty :> IBsonObjectId
            let result = subject.ToString()
            Assert.Equal("ObjectId(\"000000000000000000000000\")", result)

        [<Fact>]
        member this.``Type should return expected result``() =
            let subject = BsonObjectId() :> IBsonObjectId
            let result = subject.Type
            Assert.Equal(BsonType.ObjectId, result)
 
        [<Fact>]
        member this.``Value should return expected result``() =
            let value = ObjectId.NewId()
            let subject = BsonObjectId value :> IBsonObjectId
            let result = subject.Value
            Assert.Equal(value, result)
   end
