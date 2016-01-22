namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type BsonBinaryTests =
    class
        new() =
            {}

        [<Theory>]
        [<InlineData(BinarySubType.Binary, "01")>]
        [<InlineData(BinarySubType.MD5, "02")>]
        member this.``constructor should initialize instance``(subType : BinarySubType, value : string) =
            let value = Hex.ToByteArray(value)
            let result = BsonBinary(subType, value) :> IBsonBinary
            Assert.Equal(BsonType.Binary, result.Type)
            Assert.Equal(subType, result.SubType)
            Assert.Equal<byte>(value, result.Value)

        [<Theory>]
        [<InlineData(BinarySubType.Binary)>]
        [<InlineData(BinarySubType.MD5)>]
        member this.``SubType should return expected result``(subType : BinarySubType) =
            let subject = BsonBinary(subType, Array.empty<byte>) :> IBsonBinary
            let result = subject.SubType
            Assert.Equal(subType, result)

        [<Theory>]
        [<InlineData(BinarySubType.Binary, "01", "{ \"$type\" : 0, \"$hex\" : \"01\" }")>]
        [<InlineData(BinarySubType.MD5, "02", "{ \"$type\" : 5, \"$hex\" : \"02\" }")>]
        member this.``ToString should return expected result``(subType : BinarySubType, value : string, expectedResult : string) =
            let value = Hex.ToByteArray(value)
            let subject = BsonBinary(subType, value)  :> IBsonBinary
            let result = subject.ToString()
            Assert.Equal(expectedResult, result)

        [<Fact>]
        member this.``Type should return expected result``() =
            let subject = BsonBinary(BinarySubType.Binary, Array.empty<byte>)  :> IBsonBinary
            let result = subject.Type
            Assert.Equal(BsonType.Binary, result)
 
        [<Theory>]
        [<InlineData("01")>]
        [<InlineData("02")>]
        member this.``Value should return expected result``(value : string) =
            let value = Hex.ToByteArray(value)
            let subject = BsonBinary(BinarySubType.Binary, value) :> IBsonBinary
            let result = subject.Value
            Assert.Equal<byte>(value, result)
   end
