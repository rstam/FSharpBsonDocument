namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type BsonTimestampTests =
    class
        new() =
            {}

        [<Theory>]
        [<InlineData(0x01020304, 0x05060708, 0x0102030405060708L)>]
        [<InlineData(0xf1f2f3f4, 0xf5f6f7f8, 0xf1f2f3f4f5f6f7f8L)>]
        member this.``constructor with timestamp, increment should initialize instance``(timestamp : int, increment : int, value : int64) =
            let result = BsonTimestamp(timestamp, increment) :> IBsonTimestamp
            Assert.Equal(value, result.Value)

        [<Theory>]
        [<InlineData(0L)>]
        [<InlineData(1L)>]
        [<InlineData(-1L)>]
        member this.``constructor with value should initialize instance``(value : int64) =
            let result = BsonTimestamp value :> IBsonTimestamp
            Assert.Equal(BsonType.Timestamp, result.Type)
            Assert.Equal(value, result.Value)

        [<Fact>]
        member this.``default constructor should initialize instance``() =
            let result = BsonTimestamp() :> IBsonTimestamp
            Assert.Equal(BsonType.Timestamp, result.Type)
            Assert.Equal(0L, result.Value)

        [<Theory>]
        [<InlineData(0x0102030405060708L, 0x05060708)>]
        [<InlineData(0xf1f2f3f4f5f6f7f8L, 0xf5f6f7f8)>]
        member this.``Increment should return expected result``(value : int64, increment : int) =
            let subject = BsonTimestamp value :> IBsonTimestamp
            let result = subject.Increment
            Assert.Equal(increment, result)

        [<Theory>]
        [<InlineData(0x0102030405060708L, 0x01020304)>]
        [<InlineData(0xf1f2f3f4f5f6f7f8L, 0xf1f2f3f4)>]
        member this.``Timestamp should return expected result``(value : int64, timestamp : int) =
            let subject = BsonTimestamp value :> IBsonTimestamp
            let result = subject.Timestamp
            Assert.Equal(timestamp, result)

        [<Theory>]
        [<InlineData(0x01020304, 0x05060708)>]
        [<InlineData(0xf1f2f3f4, 0xf5f6f7f8)>]
        member this.``ToString should return expected result``(timestamp : int, increment : int) =
            let subject = BsonTimestamp(timestamp, increment) :> IBsonTimestamp
            let expectedResult = sprintf "{ \"$timestamp\" : { \"t\" : %i, \"i\" : %i } }" timestamp increment
            let result = subject.ToString()
            Assert.Equal(expectedResult, result)

        [<Fact>]
        member this.``Type should return expected result``() =
            let subject = BsonTimestamp() :> IBsonTimestamp
            let result = subject.Type
            Assert.Equal(BsonType.Timestamp, result)
 
        [<Theory>]
        [<InlineData(0L)>]
        [<InlineData(1L)>]
        [<InlineData(-1L)>]
        member this.``Value should return expected result``(value : int64) =
            let subject = BsonTimestamp value :> IBsonTimestamp
            let result = subject.Value
            Assert.Equal(value, result)
   end
