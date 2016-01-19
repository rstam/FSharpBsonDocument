namespace FSharpBsonDocument

type BsonBoolean =
    struct
        // fields
        val _value : bool

        // constructors
        new(value : bool) =
            { _value = value }

        // members
        override this.ToString() =
            if this._value then "true" else "false"

        // interfaces
        interface IBsonBoolean with
            member this.Type = BsonType.Boolean
            member this.Value = this._value
    end
