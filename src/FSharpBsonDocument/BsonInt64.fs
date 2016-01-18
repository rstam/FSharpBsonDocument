namespace FSharpBsonDocument

type BsonInt64 =
    struct
        // fields
        val _value : int64

        // constructors
        new (value : int64) =
            { _value = value }

        // members
        override this.ToString () =
            this._value.ToString() + "L"

        // interfaces
        interface IBsonInt64 with
            member this.Type = BsonType.Int64
            member this.Value = this._value
    end
