namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type BsonRegularExpressionTests =
    class
        new() =
            {}

        [<Theory>]
        [<InlineData("", "")>]
        [<InlineData("abc", "i")>]
        member this.``constructor should initialize instance``(pattern : string, options : string) =
            let result = BsonRegularExpression(pattern, options) :> IBsonRegularExpression
            Assert.Equal(BsonType.RegularExpression, result.Type)
            Assert.Equal(pattern, result.Pattern)
            Assert.Equal(options, result.Options)

        [<Fact>]
        member this.``default constructor should initialize instance``() =
            let result = BsonRegularExpression() :> IBsonRegularExpression
            Assert.Equal(BsonType.RegularExpression, result.Type)
            Assert.Equal(null, result.Pattern)
            Assert.Equal(null, result.Options)
 
        [<Theory>]
        [<InlineData("")>]
        [<InlineData("i")>]
        member this.``Options should return expected result``(options : string) =
            let subject = BsonRegularExpression("", options) :> IBsonRegularExpression
            let result = subject.Options
            Assert.Equal(options, result)
 
        [<Theory>]
        [<InlineData("")>]
        [<InlineData("abc")>]
        member this.``Pattern should return expected result``(pattern : string) =
            let subject = BsonRegularExpression(pattern, "") :> IBsonRegularExpression
            let result = subject.Pattern
            Assert.Equal(pattern, result)

        [<Theory>]
        [<InlineData("", "", "//")>]
        [<InlineData("abc", "", "/abc/")>]
        [<InlineData("abc", "i", "/abc/i")>]
        [<InlineData("a/c", "", "/a\/c/")>]
        member this.``ToString should return expected result``(pattern : string, options : string, expectedResult : string) =
            let subject = BsonRegularExpression(pattern, options) :> IBsonRegularExpression
            let result = subject.ToString()
            Assert.Equal(expectedResult, result)

        [<Fact>]
        member this.``Type should return expected result``() =
            let subject = BsonRegularExpression() :> IBsonRegularExpression
            let result = subject.Type
            Assert.Equal(BsonType.RegularExpression, result)
   end
