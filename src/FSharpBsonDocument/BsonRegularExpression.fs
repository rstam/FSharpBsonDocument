namespace FSharpBsonDocument

type BsonRegularExpression =
    struct
        // fields
        val _pattern : string
        val _options : string

        // constructors
        new (pattern : string, options : string) =
            { _pattern = pattern; _options = options }

        // members
        override this.ToString () =
            let pattern = this._pattern.Replace ("/", "\\/")
            "/" + pattern + "/" + this._options

        // interfaces
        interface IBsonRegularExpression with
            member this.Type = BsonType.RegularExpression
            member this.Pattern = this._pattern
            member this.Options = this._options
    end
