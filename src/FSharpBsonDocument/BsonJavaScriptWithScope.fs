namespace FSharpBsonDocument

type BsonJavaScriptWithScope =
    struct
        // fields
        val _code : string
        val _scope : IBsonDocument

        // constructors
        new (code : string, scope : IBsonDocument) =
            { _code = code; _scope = scope }

        // members
        override this.ToString () =
            let code = this._code.Replace ("\"", "\\\"")
            let scope = this._scope.ToString ()
            "{ \"$code\" : \"" + code + "\", \"$scope\" : " + scope + " }"

        // interfaces
        interface IBsonJavaScriptWithScope with
            member this.Type = BsonType.JavaScriptWithScope
            member this.Code = this._code
            member this.Scope = this._scope
    end
