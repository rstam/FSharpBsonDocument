namespace FSharpBsonDocumentTests

open BsonValueOperators
open FSharpBsonDocument
open Xunit

type BsonJavaScriptWithScopeTests =
    class
        new() =
            {}
 
        [<Theory>]
        [<InlineData("abc")>]
        [<InlineData("def")>]
        member this.``Code should return expected result``(code : string) =
            let scope = BsonDocument [| "x" @= 1 |]
            let subject = BsonJavaScriptWithScope(code, scope) :> IBsonJavaScriptWithScope
            let result = subject.Code
            Assert.Equal(code, result)

        [<Theory>]
        [<InlineData("abc", 1)>]
        [<InlineData("def", 2)>]
        member this.``constructor should initialize instance``(code : string, x : int) =
            let scope = BsonDocument [| "x" @= 1 |]
            let result = BsonJavaScriptWithScope(code, scope) :> IBsonJavaScriptWithScope
            Assert.Equal(BsonType.JavaScriptWithScope, result.Type)
            Assert.Equal(code, result.Code)
            Assert.Equal(scope, result.Scope)

        [<Theory>]
        [<InlineData(1)>]
        [<InlineData(2)>]
        member this.``Scope should return expected result``(x : int) =
            let scope = BsonDocument [| "x" @= 1 |]
            let subject = BsonJavaScriptWithScope("code", scope) :> IBsonJavaScriptWithScope
            let result = subject.Scope
            Assert.Equal(scope, result)

        [<Theory>]
        [<InlineData("abc", 1)>]
        [<InlineData("def", 2)>]
        [<InlineData("\"def\"", 3)>]
        member this.``ToString should return expected result``(code : string, x : int) =
            let scope = BsonDocument [| "x" @= 1 |]
            let subject = BsonJavaScriptWithScope(code, scope) :> IBsonJavaScriptWithScope
            let expectedResult = sprintf "{ \"$code\" : \"%s\", \"$scope\" : %s }" (code.Replace("\"", "\\\"")) (scope.ToString())
            let result = subject.ToString()
            Assert.Equal(expectedResult, result)

        [<Fact>]
        member this.``Type should return expected result``() =
            let scope = BsonDocument [| "x" @= 1 |]
            let subject = BsonJavaScriptWithScope("code", scope) :> IBsonJavaScriptWithScope
            let result = subject.Type
            Assert.Equal(BsonType.JavaScriptWithScope, result)
   end
