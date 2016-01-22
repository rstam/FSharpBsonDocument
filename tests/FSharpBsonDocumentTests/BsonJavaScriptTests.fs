namespace FSharpBsonDocumentTests

open FSharpBsonDocument
open Xunit

type BsonJavaScriptTests =
    class
        new() =
            {}
 
        [<Theory>]
        [<InlineData("abc")>]
        [<InlineData("def")>]
        member this.``Code should return expected result``(code : string) =
            let subject = BsonJavaScript code :> IBsonJavaScript
            let result = subject.Code
            Assert.Equal(code, result)

        [<Theory>]
        [<InlineData("abc")>]
        [<InlineData("def")>]
        member this.``constructor should initialize instance``(code : string) =
            let result = BsonJavaScript code :> IBsonJavaScript
            Assert.Equal(BsonType.JavaScript, result.Type)
            Assert.Equal(code, result.Code)

        [<Theory>]
        [<InlineData("abc")>]
        [<InlineData("def")>]
        [<InlineData("\"def\"")>]
        member this.``ToString should return expected result``(code : string) =
            let subject = BsonJavaScript code :> IBsonJavaScript
            let expectedResult = sprintf "{ \"$code\" : \"%s\" }" (code.Replace("\"", "\\\""))
            let result = subject.ToString()
            Assert.Equal(expectedResult, result)

        [<Fact>]
        member this.``Type should return expected result``() =
            let subject = BsonJavaScript("code") :> IBsonJavaScript
            let result = subject.Type
            Assert.Equal(BsonType.JavaScript, result)
   end
