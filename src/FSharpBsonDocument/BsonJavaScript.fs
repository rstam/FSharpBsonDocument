namespace FSharpBsonDocument

type BsonJavaScript =
    struct
        // fields
        val _code : string

        // constructors
        new(code : string) =
            { _code = code }

        // members
        override this.ToString() =
            let code = this._code.Replace("\"", "\\\"")
            "{ \"$code\" : \"" + code + "\" }"

        // interfaces
        interface IBsonJavaScript with
            member this.Type = BsonType.JavaScript
            member this.Code = this._code
    end
