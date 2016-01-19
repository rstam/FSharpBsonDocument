namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type BsonDoubleTests =
    class
        new() =
            {}

        [<Theory>]
        [<InlineData(0.0)>]
        [<InlineData(1.0)>]
        [<InlineData(-1.0)>]
        member this.``constructor should initialize instance``(value : double) =
            let result = BsonDouble value :> IBsonDouble
            Assert.Equal(BsonType.Double, result.Type)
            Assert.Equal(value, result.Value)

        [<Fact>]
        member this.``default constructor should initialize instance``() =
            let result = BsonDouble() :> IBsonDouble
            Assert.Equal(BsonType.Double, result.Type)
            Assert.Equal(0.0, result.Value)

        [<Theory>]
        [<InlineData(0.0, "0.0")>]
        [<InlineData(1.0, "1.0")>]
        [<InlineData(1.5, "1.5")>]
        [<InlineData(-1.0, "-1.0")>]
        [<InlineData(-1.5, "-1.5")>]
        [<InlineData(1.0e100, "1E+100")>]
        member this.``ToString should return expected result``(value : double, expectedResult : string) =
            let subject = BsonDouble value :> IBsonDouble
            let result = subject.ToString()
            Assert.Equal(expectedResult, result)

        [<Fact>]
        member this.``Type should return expected result``() =
            let subject = BsonDouble() :> IBsonDouble
            let result = subject.Type
            Assert.Equal(BsonType.Double, result)
 
        [<Theory>]
        [<InlineData(0.0)>]
        [<InlineData(1.0)>]
        [<InlineData(-1.0)>]
        member this.``Value should return expected result``(value : double) =
            let subject = BsonDouble value :> IBsonDouble
            let result = subject.Value
            Assert.Equal(value, result)
   end
