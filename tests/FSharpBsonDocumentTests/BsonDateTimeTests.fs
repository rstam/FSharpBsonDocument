namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type BsonDateTimeTests =
    class
        new() =
            {}

        [<Theory>]
        [<InlineData(0L)>]
        [<InlineData(1L)>]
        [<InlineData(-1L)>]
        member this.``constructor should initialize instance``(value : int64) =
            let result = BsonDateTime value :> IBsonDateTime
            Assert.Equal(BsonType.DateTime, result.Type)
            Assert.Equal(value, result.Value)

        [<Fact>]
        member this.``default constructor should initialize instance``() =
            let result = BsonDateTime() :> IBsonDateTime
            Assert.Equal(BsonType.DateTime, result.Type)
            Assert.Equal(0L, result.Value)

        [<Theory>]
        [<InlineData(0L, "{ \"$date\" : { \"$numberLong\" : \"0\" } }")>]
        [<InlineData(1L, "{ \"$date\" : { \"$numberLong\" : \"1\" } }")>]
        [<InlineData(-1L, "{ \"$date\" : { \"$numberLong\" : \"-1\" } }")>]
        member this.``ToString should return expected result``(value : int64, expectedResult : string) =
            let subject = BsonDateTime value :> IBsonDateTime
            let result = subject.ToString()
            Assert.Equal(expectedResult, result)

        [<Fact>]
        member this.``Type should return expected result``() =
            let subject = BsonDateTime() :> IBsonDateTime
            let result = subject.Type
            Assert.Equal(BsonType.DateTime, result)
 
        [<Theory>]
        [<InlineData(0L)>]
        [<InlineData(1L)>]
        [<InlineData(-1L)>]
        member this.``Value should return expected result``(value : int64) =
            let subject = BsonDateTime value :> IBsonDateTime
            let result = subject.Value
            Assert.Equal(value, result)
   end
