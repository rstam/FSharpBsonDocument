namespace FSharpBsonDocument

type BsonString =
    struct
        // fields
        val _value : string

        // constructors
        new (value : string) =
            { _value = value }

        // members
        override this.ToString () =
            "\"" + this._value.Replace("\"", "\"\"") + "\""

        // interfaces
        interface IBsonString with
            member this.Type = BsonType.String
            member this.Value = this._value
    end
